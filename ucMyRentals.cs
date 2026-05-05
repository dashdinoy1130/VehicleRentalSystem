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
    public partial class ucMyRentals : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucMyRentals()
        {
            InitializeComponent();
            this.dgvMyRentals.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMyRentals_DataBindingComplete);
        }
        private void ucMyRentals_Load(object sender, EventArgs e)
        {
            LoadMyRentalData();
        }
        public void LoadMyRentalData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "SELECT PlateNumber, RentalDate, ReturnDate, TotalAmount, PaymentMethod, [Status] " +
                                   "FROM Transactions WHERE RenterName = ? ORDER BY TransactionID DESC";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", UserSession.Username);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMyRentals.DataSource = dt;

                    StyleGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rentals: " + ex.Message);
                }
            }
        }

       
        private void StyleGrid()
        {
            dgvMyRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyRentals.BackgroundColor = Color.White;
            dgvMyRentals.BorderStyle = BorderStyle.None;
            dgvMyRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyRentals.RowTemplate.Height = 35;
            dgvMyRentals.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvMyRentals.EnableHeadersVisualStyles = false;
            dgvMyRentals.ColumnHeadersHeight = 40;
            dgvMyRentals.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            dgvMyRentals.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMyRentals.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            if (dgvMyRentals.Columns.Contains("TotalAmount"))
            {
                dgvMyRentals.Columns["TotalAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvMyRentals.Columns["TotalAmount"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }
        private void dgvMyRentals_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMyRentals.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();

                    if (status == "Pending Return")
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                    }
                    else if (status == "Active")
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    else if (status == "Completed")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                }
            }
        }

      

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMyRentalData();
        }
        private void UpdateReturnStatus(string plate)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryTrans = "UPDATE Transactions SET [Status] = 'Pending Return' WHERE PlateNumber = ? AND RenterName = ? AND [Status] = 'Active'";

                    using (OleDbCommand cmd = new OleDbCommand(queryTrans, conn))
                    {
                        cmd.Parameters.AddWithValue("?", plate);
                        cmd.Parameters.AddWithValue("?", UserSession.Username);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Return request sent! Please hand over the keys to the Admin for confirmation.", "Request Sent");
                    LoadMyRentalData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvMyRentals.SelectedRows.Count > 0)
            {
                string plate = dgvMyRentals.SelectedRows[0].Cells["PlateNumber"].Value.ToString();
                string status = dgvMyRentals.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status == "Completed")
                {
                    MessageBox.Show("This vehicle has already been returned.");
                    return;
                }

                DialogResult res = MessageBox.Show($"Return vehicle {plate} and end rental?", "Confirm Return", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    UpdateReturnStatus(plate);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMyRentals_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
