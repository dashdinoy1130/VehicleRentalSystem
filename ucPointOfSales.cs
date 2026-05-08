using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QRCoder;

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

            // initial setup
            dtpStart.MinDate = DateTime.Now;
            dtpEnd.MinDate = DateTime.Now.AddDays(1);
            lblTotalDays.Text = "Total Days: 0";

            // ensure payment combobox has default
            if (cmbPayment.Items.Count == 0)
            {
                cmbPayment.Items.AddRange(new object[] { "Cash", "GCash" });
                cmbPayment.SelectedIndex = 0;
            }

            // load fleet
            LoadFleet();

            // UI restrictions
            bool isEmployee = UserSession.Role == "Employee";
            btnFinalize.Enabled = isEmployee;
            btnReceipt.Enabled = isEmployee;

            picQR.Visible = false;
            btnMarkPaid.Visible = false;

            // Ensure MarkPaid click is wired (defensive)
            btnMarkPaid.Click -= BtnMarkPaid_Click;
            btnMarkPaid.Click += BtnMarkPaid_Click;

            // Ensure payment combobox change updates UI (optional)
            cmbPayment.SelectedIndexChanged -= CmbPayment_SelectedIndexChanged;
            cmbPayment.SelectedIndexChanged += CmbPayment_SelectedIndexChanged;

            cmbFleetStatusFilter.Items.Clear();
            cmbFleetStatusFilter.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            cmbFleetStatusFilter.SelectedIndex = 0; // Default to "All"

            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Hatchback", "Van", "Pickup", "MPV" });
            cmbTypeFilter.SelectedIndex = 0;

            // Wire the event
            cmbFleetStatusFilter.SelectedIndexChanged += (s, e) => LoadFleet(txtSearch.Text.Trim());
            cmbTypeFilter.SelectedIndexChanged += (s, e) => LoadFleet(txtSearch.Text.Trim());
        }

        private void CmbPayment_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // hide QR/mark paid when switching payment methods
            picQR.Visible = false;
            btnMarkPaid.Visible = false;
            pendingGCash = false;
            transactionFinalized = false;

            // re-enable finalize only for employee and non-GCash
            bool isEmployee = UserSession.Role == "Employee";
            btnFinalize.Enabled = isEmployee;
        }

        private void LoadFleet(string filter = "")
        {
            string selectedStatus = cmbFleetStatusFilter.SelectedItem?.ToString() ?? "All";
            string selectedType = cmbTypeFilter.SelectedItem?.ToString() ?? "All"; // Get selected type

            try
            {
                using (var conn = new OleDbConnection(connString))
                using (var cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;
                    // Updated query to include VehicleType
                    string sql = "SELECT PlateNumber, Brand, Model, VehicleType, PricePerDay, [Status] FROM Vehicles WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        sql += " AND (PlateNumber LIKE ? OR Brand LIKE ? OR Model LIKE ?)";
                    }

                    if (selectedStatus != "All")
                    {
                        sql += " AND [Status] = ?";
                    }

                    // Add the VehicleType filter to the SQL string
                    if (selectedType != "All")
                    {
                        sql += " AND VehicleType = ?";
                    }

                    cmd.CommandText = sql;

                    // Add parameters in the EXACT order they appear in the SQL string
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

        // search box text changed
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadFleet(txtSearch.Text.Trim());
        }

        // clicking a fleet row fills left detail fields
        private void DgvFleet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvFleet.Rows[e.RowIndex];
            txtPlateNumber.Text = row.Cells["PlateNumber"].Value?.ToString() ?? "";
            txtBrand.Text = row.Cells["Brand"].Value?.ToString() ?? "";
            txtModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["PricePerDay"].Value?.ToString() ?? "0";
        }

        // Save/Update/Delete operate on Vehicles table (left panel)
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



        // Calculate total days and amount
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

        // When user clicks Finalize:
        private void BtnFinalize_Click(object sender, EventArgs e)
        {
            // If GCash selected, show QR and require employee to confirm payment
            if (string.Equals(cmbPayment.Text, "GCash", StringComparison.OrdinalIgnoreCase))
            {
                UpdateTotals();

                // generate QR payload
                string payload = $"GCash Payment for {txtPlateNumber.Text} - {lblTotalAmountLabel.Text}";
                GenerateQRCode(payload);

                // show QR and make MarkPaid clearly actionable
                picQR.Visible = true;
                picQR.BringToFront();
                picQR.Enabled = true;

                pendingGCash = true;
                transactionFinalized = false;

                // only employees can press Payment Sent — make it enabled and focusable
                btnMarkPaid.Visible = (UserSession.Role == "Employee");
                btnMarkPaid.Enabled = (UserSession.Role == "Employee");
                btnMarkPaid.BringToFront();
                if (btnMarkPaid.Visible && btnMarkPaid.Enabled) btnMarkPaid.Focus();

                // disable finalize to avoid duplicate clicks while waiting
                btnFinalize.Enabled = false;

                MessageBox.Show("Scan the QR to pay. When payment is received, an employee should click Payment Sent to finalize.");
                return;
            }

            // For cash or other methods finalize immediately
            FinalizeTransactionFlow();
            MessageBox.Show("Transaction finalized. You can now generate a receipt.");
            LoadFleet();
        }

        // Employee clicks Payment Sent to finalize GCASH flow
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

            // hide QR and button
            picQR.Visible = false;
            btnMarkPaid.Visible = false;
            btnMarkPaid.Enabled = false;
            pendingGCash = false;
            transactionFinalized = true;

            // re-enable finalize so UI remains consistent (it's done)
            btnFinalize.Enabled = UserSession.Role == "Employee";

            ShowReceipt();
            LoadFleet();
        }

        // Single helper that performs DB insert/update (used by Cash finalize and GCash mark paid)
        private void FinalizeTransactionFlow()
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text) || string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Customer name and vehicle plate are required.");
                return;
            }

            UpdateTotals(); // ensure totals up-to-date

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
            var receipt = new System.Text.StringBuilder();
            receipt.AppendLine("----- RECEIPT -----");
            receipt.AppendLine($"Operator: {UserSession.Username}");
            receipt.AppendLine($"Customer: {txtCustomer.Text}");
            receipt.AppendLine($"License: {txtLicense.Text}");
            receipt.AppendLine($"Contact: {txtContact.Text}");
            receipt.AppendLine($"Vehicle: {txtBrand.Text} {txtModel.Text} ({txtPlateNumber.Text})");
            receipt.AppendLine($"Rental: {dtpStart.Value:d} - {dtpEnd.Value:d}");
            receipt.AppendLine($"Payment: {cmbPayment.Text}");
            receipt.AppendLine($"Total: {lblTotalAmountLabel.Text}");
            receipt.AppendLine("Status: PAID");

            MessageBox.Show(receipt.ToString(), "Receipt");
        }

        // helper to parse decimal invariant
        private decimal DecimalParseInvariant(string s)
        {
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal d)) return d;
            // try to strip non-numeric chars then parse
            var cleaned = Regex.Replace(s ?? string.Empty, @"[^0-9\.\-]", "");
            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            return 0m;
        }

        // generate QR code (uses QRCoder)
        private void GenerateQRCode(string text)
        {
            try
            {
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new QRCode(qrData))
                {
                    var bmp = qrCode.GetGraphic(20);
                    // Dispose previous image safely
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

        // PASTE IT HERE
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
    }
}