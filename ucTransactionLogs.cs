using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class ucTransactionLogs : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucTransactionLogs()
        {
            InitializeComponent();
            this.txtSearchLogs.TextChanged += new System.EventHandler(this.txtSearchLogs_TextChanged);
            this.dgvTransactions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactions_DataBindingComplete);
        }
        private void ucTransactionLogs_Load(object sender, EventArgs e)
        {
            LoadTransactionData();
        }
        public void LoadTransactionData(string filter = "")
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Transactions";

                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += " WHERE RenterName LIKE ? OR PlateNumber LIKE ? OR FullName LIKE ? OR LicenseNumber LIKE ?";
                    }

                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    if (!string.IsNullOrEmpty(filter))
                    {
                        string searchVal = "%" + filter + "%";
                        cmd.Parameters.AddWithValue("?", searchVal);
                        cmd.Parameters.AddWithValue("?", searchVal);
                        cmd.Parameters.AddWithValue("?", searchVal);
                        cmd.Parameters.AddWithValue("?", searchVal);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTransactions.DataSource = dt;

                    if (dgvTransactions.Columns.Contains("FullName")) dgvTransactions.Columns["FullName"].HeaderText = "Renter Full Name";
                    if (dgvTransactions.Columns.Contains("LicenseNumber")) dgvTransactions.Columns["LicenseNumber"].HeaderText = "License No.";
                    if (dgvTransactions.Columns.Contains("ContactNumber")) dgvTransactions.Columns["ContactNumber"].HeaderText = "Contact No.";

                    if (dgvTransactions.Columns.Contains("TransactionID")) dgvTransactions.Columns["TransactionID"].Visible = false;

                    if (dgvTransactions.Columns.Contains("TotalAmount"))
                        dgvTransactions.Columns["TotalAmount"].DefaultCellStyle.Format = "₱#,##0.00";

                    dgvTransactions.EnableHeadersVisualStyles = false;
                    dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
                    dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgvTransactions.ColumnHeadersHeight = 40;

                    dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvTransactions.BackgroundColor = Color.White;
                    dgvTransactions.BorderStyle = BorderStyle.None;
                    dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading logs: " + ex.Message);
                }
            }
        }
        private void dgvTransactions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();

                    if (status == "Pending Return")
                    {
                        row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    }
                    else if (status == "Completed")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else if (status == "Active")
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                }
            }
        }
        private void txtSearchLogs_TextChanged(object sender, EventArgs e)
        {
            LoadTransactionData(txtSearchLogs.Text.Trim());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FinalizeReturn(string plate)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryVeh = "UPDATE Vehicles SET [Status] = 'Available' WHERE PlateNumber = ?";
                    using (OleDbCommand cmd1 = new OleDbCommand(queryVeh, conn))
                    {
                        cmd1.Parameters.AddWithValue("?", plate);
                        cmd1.ExecuteNonQuery();
                    }

                    string queryTrans = "UPDATE Transactions SET [Status] = 'Completed' WHERE PlateNumber = ? AND [Status] = 'Pending Return'";
                    using (OleDbCommand cmd2 = new OleDbCommand(queryTrans, conn))
                    {
                        cmd2.Parameters.AddWithValue("?", plate);
                        cmd2.ExecuteNonQuery();
                    }

                    MessageBox.Show("Vehicle is now back in inventory!", "Return Confirmed");
                    LoadTransactionData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                string plate = dgvTransactions.SelectedRows[0].Cells["PlateNumber"].Value.ToString();
                string status = dgvTransactions.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status != "Pending Return")
                {
                    MessageBox.Show("This transaction is not waiting for a return confirmation.", "Invalid Action");
                    return;
                }

                DialogResult res = MessageBox.Show($"Confirm that Vehicle {plate} has been returned in good condition?", "Admin Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FinalizeReturn(plate);
                }
            }
        }
    }
}
