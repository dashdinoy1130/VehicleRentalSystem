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

            this.DoubleBuffered = true;
        }

        private void showControl(Control uc)
        {
            if (pnlMainContent.Controls.Count > 0)
            {
                Control oldControl = pnlMainContent.Controls[0];


                pnlMainContent.Controls.Remove(oldControl);


                Application.DoEvents();


                oldControl.Dispose();
            }

            if (uc != null)
            {
                uc.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(uc);
            }
        }



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            showControl(new ucDashboard());
        }

        private void btnManageFleet_Click(object sender, EventArgs e)
        {
            ucManageFleet fleet = new ucManageFleet();
            showControl(fleet);
            fleet.LoadFleetData();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            showControl(new ucTransactionLogs());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ucReports reports = new ucReports();
            showControl(reports);
            reports.LoadReportsDashboard();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            showControl(new ucSalesReport());
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            showControl(new ucManageUsers());
        }

        private void BtnPointOfSales_Click(object sender, EventArgs e)
        {
            showControl(new ucPointOfSales());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Username = "";
            UserSession.Role = "";
            new frmLogin().Show();
            this.Close();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            if (UserSession.Role == "Employee")
            {
                btnReports.Visible = false;
                btnSalesReport.Visible = false;
                btnManageUsers.Visible = false;
            }
            showControl(new ucDashboard());
        }

        private void btnPointOfSales_Click_1(object sender, EventArgs e)
        {
            showControl(new ucPointOfSales());
        }

        private void btnTrackRentals_Click(object sender, EventArgs e)
        {
            // Initialize the tracking control
            ucTrackRentals tracking = new ucTrackRentals();

            // Use your existing showControl method to swap the panels
            showControl(tracking);

            // Call the method to load the data from the database
            tracking.LoadTrackingData();
        }
    }
}