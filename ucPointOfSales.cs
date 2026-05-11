using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QRCoder;
using System.Drawing.Printing;

namespace VehicleRentalSystem
{
    public partial class ucPointOfSales : UserControl
    {


        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        private bool pendingGCash = false;
        private bool transactionFinalized = false;

        public ucPointOfSales()
        {
            InitializeComponent();

            dtpStart.MinDate = DateTime.Now;
            dtpEnd.MinDate = DateTime.Now.AddDays(1);
            lblTotalDays.Text = "Total Days: 0";


            if (cmbPayment.Items.Count == 0)
            {
                cmbPayment.Items.AddRange(new object[] { "Cash", "GCash" });
                cmbPayment.SelectedIndex = 0;
            }


            LoadFleet();


            bool isEmployee = UserSession.Role == "Employee";
            btnFinalize.Enabled = isEmployee;
            btnReceipt.Enabled = isEmployee;

            picQR.Visible = false;
            btnMarkPaid.Visible = false;


            btnMarkPaid.Click -= BtnMarkPaid_Click;
            btnMarkPaid.Click += BtnMarkPaid_Click;


            cmbPayment.SelectedIndexChanged -= CmbPayment_SelectedIndexChanged;
            cmbPayment.SelectedIndexChanged += CmbPayment_SelectedIndexChanged;

            cmbFleetStatusFilter.Items.Clear();
            cmbFleetStatusFilter.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            cmbFleetStatusFilter.SelectedIndex = 0;

            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Hatchback", "Van", "Pickup", "MPV" });
            cmbTypeFilter.SelectedIndex = 0;


            cmbFleetStatusFilter.SelectedIndexChanged += (s, e) => LoadFleet(txtSearch.Text.Trim());
            cmbTypeFilter.SelectedIndexChanged += (s, e) => LoadFleet(txtSearch.Text.Trim());
        }

        private void CmbPayment_SelectedIndexChanged(object? sender, EventArgs e)
        {

            picQR.Visible = false;
            btnMarkPaid.Visible = false;
            pendingGCash = false;
            transactionFinalized = false;


            bool isEmployee = UserSession.Role == "Employee";
            btnFinalize.Enabled = isEmployee;
        }

        private void LoadFleet(string filter = "")
        {
            string selectedStatus = cmbFleetStatusFilter.SelectedItem?.ToString() ?? "All";
            string selectedType = cmbTypeFilter.SelectedItem?.ToString() ?? "All";

            try
            {
                using (var conn = new OleDbConnection(connString))
                using (var cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;

                    string sql = "SELECT PlateNumber, Brand, Model, VehicleType, PricePerDay, [Status] FROM Vehicles WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        sql += " AND (PlateNumber LIKE ? OR Brand LIKE ? OR Model LIKE ?)";
                    }

                    if (selectedStatus != "All")
                    {
                        sql += " AND [Status] = ?";
                    }


                    if (selectedType != "All")
                    {
                        sql += " AND VehicleType = ?";
                    }

                    cmd.CommandText = sql;


                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        string f = "%" + filter + "%";
                        cmd.Parameters.AddWithValue("?", f);
                        cmd.Parameters.AddWithValue("?", f);
                        cmd.Parameters.AddWithValue("?", f);
                    }

                    if (selectedStatus != "All")
                    {
                        cmd.Parameters.AddWithValue("?", selectedStatus);
                    }

                    if (selectedType != "All")
                    {
                        cmd.Parameters.AddWithValue("?", selectedType);
                    }

                    var adapter = new OleDbDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvFleet.DataSource = dt;
                    FormatFleetGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fleet: " + ex.Message);
            }
        }


        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadFleet(txtSearch.Text.Trim());
        }


        private void DgvFleet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvFleet.Rows[e.RowIndex];
            txtPlateNumber.Text = row.Cells["PlateNumber"].Value?.ToString() ?? "";
            txtBrand.Text = row.Cells["Brand"].Value?.ToString() ?? "";
            txtModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["PricePerDay"].Value?.ToString() ?? "0";
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new OleDbConnection(connString))
                using (var cmd = new OleDbCommand("INSERT INTO Vehicles (PlateNumber, Brand, Model, PricePerDay, [Status]) VALUES (?, ?, ?, ?, 'Available')", conn))
                {
                    cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("?", DecimalParseInvariant(txtPrice.Text.Trim()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vehicle saved.");
                    LoadFleet();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error saving vehicle: " + ex.Message); }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Select a vehicle to update (click row in the grid).");
                return;
            }

            try
            {
                using (var conn = new OleDbConnection(connString))
                using (var cmd = new OleDbCommand("UPDATE Vehicles SET Brand = ?, Model = ?, PricePerDay = ? WHERE PlateNumber = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("?", DecimalParseInvariant(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vehicle updated.");
                    LoadFleet();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating vehicle: " + ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Select a vehicle to delete (click row in the grid).");
                return;
            }

            if (MessageBox.Show("Delete selected vehicle?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (var conn = new OleDbConnection(connString))
                using (var cmd = new OleDbCommand("DELETE FROM Vehicles WHERE PlateNumber = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vehicle deleted.");
                    ClearLeftFields();
                    LoadFleet();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error deleting vehicle: " + ex.Message); }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearLeftFields();
        }



        private void DtpStart_ValueChanged(object? sender, EventArgs e) => UpdateTotals();
        private void DtpEnd_ValueChanged(object? sender, EventArgs e) => UpdateTotals();

        private void UpdateTotals()
        {
            var days = (dtpEnd.Value.Date - dtpStart.Value.Date).Days;
            if (days <= 0) days = 1;
            lblTotalDays.Text = $"Total Days: {days}";

            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rate)) rate = 0m;
            decimal total = rate * days;
            lblTotalAmountLabel.Text = "₱" + total.ToString("N2");
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            UpdateTotals();
        }


        private void BtnFinalize_Click(object sender, EventArgs e)
        {

            if (string.Equals(cmbPayment.Text, "GCash", StringComparison.OrdinalIgnoreCase))
            {
                UpdateTotals();


                string payload = $"GCash Payment for {txtPlateNumber.Text} - {lblTotalAmountLabel.Text}";
                GenerateQRCode(payload);


                picQR.Visible = true;
                picQR.BringToFront();
                picQR.Enabled = true;

                pendingGCash = true;
                transactionFinalized = false;


                btnMarkPaid.Visible = (UserSession.Role == "Employee");
                btnMarkPaid.Enabled = (UserSession.Role == "Employee");
                btnMarkPaid.BringToFront();
                if (btnMarkPaid.Visible && btnMarkPaid.Enabled) btnMarkPaid.Focus();


                btnFinalize.Enabled = false;

                MessageBox.Show("Scan the QR to pay. When payment is received, an employee should click Payment Sent to finalize.");
                return;
            }


            FinalizeTransactionFlow();
            MessageBox.Show("Transaction finalized. You can now generate a receipt.");
            LoadFleet();
        }


        private void BtnMarkPaid_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Employee")
            {
                MessageBox.Show("Only employees can confirm GCash payments.");
                return;
            }

            if (!pendingGCash)
            {
                MessageBox.Show("No pending GCash payment.");
                return;
            }

            FinalizeTransactionFlow();


            picQR.Visible = false;
            btnMarkPaid.Visible = false;
            btnMarkPaid.Enabled = false;
            pendingGCash = false;
            transactionFinalized = true;


            btnFinalize.Enabled = UserSession.Role == "Employee";

            ShowReceipt();
            LoadFleet();
        }


        private void FinalizeTransactionFlow()
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text) || string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Customer name and vehicle plate are required.");
                return;
            }

            UpdateTotals();

            try
            {
                using (var conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    using (var trans = conn.BeginTransaction())
                    {
                        using (var cmd = new OleDbCommand("INSERT INTO Transactions (RenterName, FullName, LicenseNumber, ContactNumber, PlateNumber, RentalDate, ReturnDate, TotalAmount, PaymentMethod, [Status]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, 'Active')", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("?", UserSession.Username ?? string.Empty);
                            cmd.Parameters.AddWithValue("?", txtCustomer.Text.Trim());
                            cmd.Parameters.AddWithValue("?", txtLicense.Text.Trim());
                            cmd.Parameters.AddWithValue("?", txtContact.Text.Trim());
                            cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("?", dtpStart.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("?", dtpEnd.Value.ToShortDateString());

                            var totalText = lblTotalAmountLabel.Text.Replace("₱", "").Replace(",", "");
                            if (!decimal.TryParse(totalText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalAmt)) totalAmt = 0m;
                            cmd.Parameters.AddWithValue("?", totalAmt);
                            cmd.Parameters.AddWithValue("?", cmbPayment.Text ?? "Cash");

                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd2 = new OleDbCommand("UPDATE Vehicles SET [Status] = 'Rented' WHERE PlateNumber = ?", conn, trans))
                        {
                            cmd2.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                            cmd2.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }

                transactionFinalized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finalizing transaction: " + ex.Message);
            }
        }

        private void BtnReceipt_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Employee")
            {
                MessageBox.Show("Only employees can generate receipts.");
                return;
            }

            if (!transactionFinalized)
            {
                MessageBox.Show("Transaction not finalized yet. Finalize first (or confirm payment).");
                return;
            }

            ShowReceipt();
        }

        private void ShowReceipt()
        {
          
            string vehicleDetails = $"{txtBrand.Text} {txtModel.Text}".PadRight(20);
            string plateInfo = $"({txtPlateNumber.Text})";

          
            System.Text.StringBuilder details = new System.Text.StringBuilder();
            details.AppendLine("VEHICLE DETAILS:");
            details.AppendLine($"{vehicleDetails} {plateInfo}");
            details.AppendLine("----------------------------------");
            details.AppendLine($"Customer: {txtCustomer.Text}");
            details.AppendLine($"Contact : {txtContact.Text}");
            details.AppendLine($"Rental  : {dtpStart.Value:d} to {dtpEnd.Value:d}");
            details.AppendLine($"Payment : {cmbPayment.Text}");
            details.AppendLine("----------------------------------");
            details.AppendLine("Status  : PAID");

            
            string totalAmount = lblTotalAmountLabel.Text.Replace("₱", "").Trim();

           
            using (frmReceipt receiptForm = new frmReceipt(details.ToString(), totalAmount))
            {
                receiptForm.ShowDialog();
            }
        }


        private decimal DecimalParseInvariant(string s)
        {
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal d)) return d;

            var cleaned = Regex.Replace(s ?? string.Empty, @"[^0-9\.\-]", "");
            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            return 0m;
        }

        private void GenerateQRCode(string text)
        {
            try
            {
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new QRCode(qrData))
                {
                    var bmp = qrCode.GetGraphic(20);

                    var prev = picQR.Image;
                    picQR.Image = new Bitmap(bmp);
                    prev?.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("QR generation failed: " + ex.Message);
            }
        }
        private void ClearLeftFields()
        {
            txtPlateNumber.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtPrice.Text = "0";
        }


        private void FormatFleetGrid()
        {
            if (dgvFleet.Columns.Contains("PricePerDay"))
                dgvFleet.Columns["PricePerDay"].DefaultCellStyle.Format = "₱#,##0.00";

            foreach (DataGridViewRow row in dgvFleet.Rows)
            {
                var status = row.Cells["Status"].Value?.ToString() ?? "";
                if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                else if (status.Equals("Rented", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                else if (status.Equals("Maintenance", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void cmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMarkPaid_Click_1(object sender, EventArgs e)
        {

        }
    }
}