// Replace frmDashboard.cs (only small change: wire PointOfSales button if present)
using System;
using System.Linq;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void showControl(Control uc)
        {
            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Username = "";
            UserSession.Role = "";

            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Hide admin/reporting UI for employees
            if (UserSession.Role == "Employee")
            {
                btnReports.Visible = false;
                btnSalesReport.Visible = false;
                btnManageUsers.Visible = false;
            }

            // If a Point of Sales button named 'btnPointOfSales' exists in the Designer, wire it.
            var posBtn = this.Controls.Find("btnPointOfSales", true).FirstOrDefault() as Button;
            if (posBtn != null)
            {
                posBtn.Visible = (UserSession.Role == "Employee");
                posBtn.Click -= BtnPointOfSales_Click;
                posBtn.Click += BtnPointOfSales_Click;
            }

            showControl(new ucDashboard());
        }

        private void BtnPointOfSales_Click(object? sender, EventArgs e)
        {
            showControl(new ucPointOfSales());
        }

        private void btnManageFleet_Click(object sender, EventArgs e)
        {
            ucManageFleet fleetControl = new ucManageFleet();
            showControl(fleetControl);
            fleetControl.LoadFleetData();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            showControl(new ucTransactionLogs());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            showControl(new ucDashboard());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ucReports reportsControl = new ucReports();
            showControl(reportsControl);
            reportsControl.LoadReportsDashboard();
        }

        private void pnlNavBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMainContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            showControl(new ucSalesReport());
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            showControl(new ucManageUsers());
        }
    }
}