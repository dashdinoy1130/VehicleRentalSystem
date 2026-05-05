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

            if (UserSession.Role == "Employee")
            {

                btnReports.Visible = false;
            }

            showControl(new ucDashboard());

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
    }
}
