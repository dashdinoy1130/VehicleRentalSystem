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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Active");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.Items.Add("Pending Return");
            cmbStatusFilter.Items.Add("Pending Payment");
            cmbStatusFilter.SelectedIndex = 0;
        }
        public void LoadTransactionData(string filter = "")
        {
            string searchText = txtSearchLogs.Text.Trim();
            string selectedStatus = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    
                    string query = "SELECT * FROM Transactions WHERE (RenterName LIKE ? OR PlateNumber LIKE ? OR FullName LIKE ?)";

                    if (selectedStatus != "All")
                    {
                        query += " AND [Status] = ?";
                    }

                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    string searchVal = "%" + searchText + "%";
                    cmd.Parameters.AddWithValue("?", searchVal);
                    cmd.Parameters.AddWithValue("?", searchVal);
                    cmd.Parameters.AddWithValue("?", searchVal);

                    if (selectedStatus != "All")
                    {
                        cmd.Parameters.AddWithValue("?", selectedStatus);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTransactions.DataSource = dt;

                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering logs: " + ex.Message);
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

                    if (status == "Pending Payment")
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose; 
                        row.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else if (status == "Pending Return")
                    {
                        row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    }
                    else if (status == "Active")
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (status == "Completed")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.BackColor = Color.White;
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

        private void ShowReceiptFromRow(DataGridViewRow row)
        {
     
            string renterName = row.Cells["FullName"].Value?.ToString() ?? "N/A";
            string plate = row.Cells["PlateNumber"].Value?.ToString() ?? "N/A";
            string amount = row.Cells["TotalAmount"].Value?.ToString() ?? "0.00";
            string method = row.Cells["PaymentMethod"].Value?.ToString() ?? "N/A";

            string receipt = "------------------------------------------\n" +
                             "          OFFICIAL RECEIPT          \n" +
                             "------------------------------------------\n" +
                             $"Customer: {renterName}\n" +
                             $"Vehicle Plate: {plate}\n" +
                             $"Payment Method: {method}\n" +
                             $"Total Paid: {amount}\n" +
                             "------------------------------------------\n" +
                             "Status: ACTIVE / PAID\n" +
                             "Thank you for choosing our service!\n" +
                             "------------------------------------------";

            MessageBox.Show(receipt, "Receipt Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTransactions.SelectedRows[0];
                string status = row.Cells["Status"].Value.ToString();
                string plate = row.Cells["PlateNumber"].Value.ToString();

       
                if (status != "Pending Payment")
                {
                    MessageBox.Show("This transaction is already active or completed.");
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
        
                        string updateTrans = "UPDATE Transactions SET [Status] = 'Active' WHERE PlateNumber = ? AND [Status] = 'Pending Payment'";
                        using (OleDbCommand cmd1 = new OleDbCommand(updateTrans, conn))
                        {
                            cmd1.Parameters.AddWithValue("?", plate);
                            cmd1.ExecuteNonQuery();
                        }

                     
                        string updateVeh = "UPDATE Vehicles SET [Status] = 'Rented' WHERE PlateNumber = ?";
                        using (OleDbCommand cmd2 = new OleDbCommand(updateVeh, conn))
                        {
                            cmd2.Parameters.AddWithValue("?", plate);
                            cmd2.ExecuteNonQuery();
                        }

                        MessageBox.Show("Payment Confirmed! Vehicle is now marked as Rented.", "Success");

                       
                        ShowReceiptFromRow(row);

                        LoadTransactionData();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransactionData();
        }

        private void txtSearchLogs_TextChanged_1(object sender, EventArgs e)
        {
            LoadTransactionData();
        }

        private void btnDeleteLog_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTransactions.SelectedRows[0];

            
                string transactionID = row.Cells["TransactionID"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();

          
                if (status != "Completed")
                {
                    DialogResult warn = MessageBox.Show("This transaction is not 'Completed'. Are you sure you want to delete a record of an ongoing rental?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (warn == DialogResult.No) return;
                }

        
                DialogResult res = MessageBox.Show("Are you sure you want to permanently delete this transaction log?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM Transactions WHERE TransactionID = ?";
                            using (OleDbCommand cmd = new OleDbCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("?", transactionID);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Transaction record deleted successfully.", "Deleted");
                            LoadTransactionData(); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting record: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a full row to delete.", "Selection Required");
            }
        }
    }
}
