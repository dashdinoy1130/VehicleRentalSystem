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
    public partial class frmRenterDashboard : Form
    {
        public frmRenterDashboard()
        {
            InitializeComponent();
        }
        private void frmRenterDashboard_Shown(object sender, EventArgs e)
        {
            ucRenterBooking browsePage = new ucRenterBooking();

            pnlRenterContent.Controls.Clear();
            browsePage.Dock = DockStyle.Fill;
            pnlRenterContent.Controls.Add(browsePage);

            browsePage.LoadVehiclesFromDatabase();
        }
        private void frmRenterDashboard_Load(object sender, EventArgs e)
        {

            btnBrowseCars.PerformClick();
        }

        private void showControl(Control uc)
        {
            pnlRenterContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlRenterContent.Controls.Add(uc);


            if (uc is ucRenterBooking)
            {
                cmbFilterType.Visible = true;
            }
            else
            {
                cmbFilterType.Visible = false;
            }
        }
        private void btnBrowseCars_Click(object sender, EventArgs e)
        {
            ucRenterBooking browsePage = new ucRenterBooking();

 
            if (cmbFilterType.SelectedItem != null)
            {
                browsePage.SelectedTypeFilter = cmbFilterType.SelectedItem.ToString();
            }

            showControl(browsePage);
            browsePage.LoadVehiclesFromDatabase();
        }

        private void btnLogout1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                UserSession.Username = "";
                UserSession.Role = "";

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnMyRentals_Click(object sender, EventArgs e)
        {
            ucMyRentals myRentals = new ucMyRentals();
            showControl(myRentals);
            myRentals.LoadMyRentalData();
        }
        private void LoadBrowseCars()
        {
            ucRenterBooking browse = new ucRenterBooking();
            pnlRenterContent.Controls.Clear();
            browse.Dock = DockStyle.Fill;
            pnlRenterContent.Controls.Add(browse);
            browse.LoadVehiclesFromDatabase();
        }

        private void pnlRenterContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlRenterContent.Controls.Count > 0 && pnlRenterContent.Controls[0] is ucRenterBooking bookingUC)
            {
                bookingUC.FilterCars(cmbFilterType.SelectedItem.ToString());
            }
        }
    }
}
