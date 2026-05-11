using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class ucTrackRentals : UserControl
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";
        public ucTrackRentals()
        {
            InitializeComponent();
            cmbStatusFilter.Items.Clear();
            // Setting these items to match your request
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Active", "Overdue" });
            cmbStatusFilter.SelectedIndex = 0;
            LoadTrackingData();
        }

        public void LoadTrackingData(string search = "")
        {
            try
            {
                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connString))
                {
                    string sql = "SELECT TransactionID, PlateNumber, FullName, ContactNumber, RentalDate, ReturnDate, Status " +
                                 "FROM Transactions WHERE Status = 'Active'";

                    if (!string.IsNullOrWhiteSpace(search))
                        sql += " AND (PlateNumber LIKE @s OR FullName LIKE @s)";

                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@s", "%" + search + "%");

                    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTracking.DataSource = dt;

                    // Apply colors and calculate "Overdue" status text
                    ApplyColorCoding();

                    // Filter logic based on ComboBox selection
                    string filter = cmbStatusFilter.Text;

                    if (filter != "All")
                    {
                        CurrencyManager cm = (CurrencyManager)BindingContext[dgvTracking.DataSource];
                        cm.SuspendBinding();

                        foreach (DataGridViewRow row in dgvTracking.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string rowStatus = row.Cells["Status"].Value.ToString();

                            // If filter is 'Active', hide anything marked 'Overdue'
                            // If filter is 'Overdue', hide anything marked 'Active'
                            if (filter == "Active" && rowStatus == "Overdue")
                                row.Visible = false;
                            else if (filter == "Overdue" && rowStatus == "Active")
                                row.Visible = false;
                            else
                                row.Visible = true;
                        }
                        cm.ResumeBinding();
                    }

                    // Fill vacant space
                    dgvTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void ApplyColorCoding()
        {
            foreach (DataGridViewRow row in dgvTracking.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ReturnDate"].Value == DBNull.Value) continue;

                DateTime returnDate = Convert.ToDateTime(row.Cells["ReturnDate"].Value);

                // Check if the current date is strictly past the ReturnDate
                if (DateTime.Now.Date > returnDate.Date)
                {
                    // Overdue Styling
                    row.Cells["Status"].Value = "Overdue";
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    // Active/Ongoing Styling
                    row.Cells["Status"].Value = "Active";
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void ucTrackRentals_Load(object sender, EventArgs e)
        {
            // Grid settings for better visualization
            dgvTracking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTracking.AllowUserToAddRows = false;
            dgvTracking.ReadOnly = true;
        }

        private void btnLogReturn_Click(object sender, EventArgs e)
        {
            if (dgvTracking.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to return.");
                return;
            }

            string plate = dgvTracking.CurrentRow.Cells["PlateNumber"].Value.ToString();
            string transID = dgvTracking.CurrentRow.Cells["TransactionID"].Value.ToString();

            if (MessageBox.Show($"Mark Plate {plate} as returned?", "Confirm Return", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connString))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    try
                    {
                        // 1. Update Transaction to Completed
                        var cmd1 = new System.Data.OleDb.OleDbCommand("UPDATE Transactions SET Status = 'Completed' WHERE TransactionID = ?", conn, trans);
                        cmd1.Parameters.AddWithValue("?", transID);
                        cmd1.ExecuteNonQuery();

                        // 2. Make Vehicle Available again
                        var cmd2 = new System.Data.OleDb.OleDbCommand("UPDATE Vehicles SET Status = 'Available' WHERE PlateNumber = ?", conn, trans);
                        cmd2.Parameters.AddWithValue("?", plate);
                        cmd2.ExecuteNonQuery();

                        trans.Commit();
                        MessageBox.Show("Return successful!");
                        LoadTrackingData();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Return failed: " + ex.Message);
                    }
                }
            }
        }

        private void txtTrackSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTrackingData(txtTrackSearch.Text);
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add logic here to filter the DataTable further if needed
            LoadTrackingData(txtTrackSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrackingData();
        }
    }
}