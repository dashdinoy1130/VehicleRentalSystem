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
    public partial class ucReports : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucReports()
        {
            InitializeComponent();
            this.dgvReportsDetailed.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvReportsDetailed_CellFormatting);
        }
        private void ucReports_Load(object sender, EventArgs e)
        {
            LoadReportsDashboard();
        }
        public void LoadReportsDashboard()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string revenueQuery = "SELECT SUM(TotalAmount) FROM Transactions WHERE [Status] = 'Completed'";
                    OleDbCommand revCmd = new OleDbCommand(revenueQuery, conn);
                    object revenueResult = revCmd.ExecuteScalar();
                    decimal totalRevenue = (revenueResult != DBNull.Value) ? Convert.ToDecimal(revenueResult) : 0;

                    lblTotalRevenue.Text = totalRevenue.ToString("₱#,##0.00");

                    string activeQuery = "SELECT COUNT(*) FROM Transactions WHERE [Status] = 'Active'";
                    OleDbCommand activeCmd = new OleDbCommand(activeQuery, conn);
                    int activeCount = Convert.ToInt32(activeCmd.ExecuteScalar());
                    lblActiveCount.Text = activeCount.ToString();

                    string fleetQuery = "SELECT COUNT(*) FROM Vehicles";
                    OleDbCommand fleetCmd = new OleDbCommand(fleetQuery, conn);
                    int fleetCount = Convert.ToInt32(fleetCmd.ExecuteScalar());
                    lblTotalFleet.Text = fleetCount.ToString();

                    string detailsQuery = "SELECT TOP 50 RenterName, PlateNumber, TotalAmount, [Status], RentalDate FROM Transactions ORDER BY TransactionID DESC";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(detailsQuery, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvReportsDetailed.DataSource = dt;

                    FormatReportsGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reports: " + ex.Message);
                }
            }
        }
        private void FormatReportsGrid()
        {
            dgvReportsDetailed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportsDetailed.BackgroundColor = Color.White;
            dgvReportsDetailed.BorderStyle = BorderStyle.None;
            dgvReportsDetailed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportsDetailed.EnableHeadersVisualStyles = false;
            dgvReportsDetailed.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            dgvReportsDetailed.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportsDetailed.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReportsDetailed.ColumnHeadersHeight = 40;

            if (dgvReportsDetailed.Columns.Contains("TotalAmount"))
            {
                dgvReportsDetailed.Columns["TotalAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvReportsDetailed.Columns["TotalAmount"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }

            dgvReportsDetailed.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }
        private void dgvReportsDetailed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReportsDetailed.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Active")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else if (status == "Completed")
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
                else if (status == "Pending Return")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReportsDashboard();
        }

        private void dgvReportsDetailed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
