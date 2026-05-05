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
    public partial class ucDashboard : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucDashboard()
        {
            InitializeComponent();
        }
        private void ucDashboard_Load(object sender, EventArgs e)
        {
            SetupGridStyle();
            RefreshDashboardData();
            LoadFleetStatusChart();
        }
        public void RefreshDashboardData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    lblTotalFleet.Text = GetCount(conn, "SELECT COUNT(*) FROM Vehicles");
                    lblActiveRentals.Text = GetCount(conn, "SELECT COUNT(*) FROM Vehicles WHERE [Status] = 'Rented'");
                    lblMaintenance.Text = GetCount(conn, "SELECT COUNT(*) FROM Vehicles WHERE [Status] = 'Maintenance'");

                    LoadRecentActivity(conn);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Dashboard Update Error: " + ex.Message);
                }
            }
        }
        private string GetCount(OleDbConnection conn, string query)
        {
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "0";
            }
        }
        private void LoadRecentActivity(OleDbConnection conn)
        {
            string query = "SELECT TOP 10 RenterName, PlateNumber, RentalDate, TotalAmount FROM Transactions ORDER BY RentalDate DESC";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvRecentActivity.DataSource = dt;

            if (dgvRecentActivity.Columns.Count > 0)
            {
                dgvRecentActivity.Columns["RenterName"].HeaderText = "Customer";
                dgvRecentActivity.Columns["PlateNumber"].HeaderText = "Plate No.";
                dgvRecentActivity.Columns["RentalDate"].HeaderText = "Date";
                dgvRecentActivity.Columns["TotalAmount"].HeaderText = "Paid";
                dgvRecentActivity.Columns["TotalAmount"].DefaultCellStyle.Format = "N2"; 
            }
        }
        private void SetupGridStyle()
        {
            dgvRecentActivity.ReadOnly = true;
            dgvRecentActivity.RowHeadersVisible = false;
            dgvRecentActivity.BackgroundColor = Color.White;
            dgvRecentActivity.BorderStyle = BorderStyle.None;
            dgvRecentActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentActivity.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvRecentActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgvRecentActivity.EnableHeadersVisualStyles = false;
            dgvRecentActivity.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }
        public void LoadFleetStatusChart()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT [Status], COUNT(*) AS Total FROM Vehicles GROUP BY [Status]";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    chartFleetStatus.Series.Clear();
                    chartFleetStatus.Titles.Clear();
                    chartFleetStatus.Legends.Clear();

                    var series = chartFleetStatus.Series.Add("Fleet");
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartFleetStatus.Legends.Add("Default");

                    foreach (DataRow row in dt.Rows)
                    {
                        string status = row["Status"].ToString();
                        int count = Convert.ToInt32(row["Total"]);

                        int i = series.Points.AddXY(status, count);

                        if (status == "Available") series.Points[i].Color = Color.MediumSeaGreen;
                        else if (status == "Rented" || status == "Pending Return") series.Points[i].Color = Color.RoyalBlue;
                        else if (status == "Maintenance") series.Points[i].Color = Color.Crimson;
                    }

                    chartFleetStatus.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chartFleetStatus.Titles.Add("Current Fleet Availability");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Chart Error: " + ex.Message);
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
