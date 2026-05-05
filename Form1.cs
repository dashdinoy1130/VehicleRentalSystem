using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class frmLogin : Form
    {
        OleDbConnection myConn;
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }


        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection myConn = new OleDbConnection(connectionString))
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                string query = "SELECT Role, Username FROM Users WHERE [Username] = ? AND [Password] = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);

                    try
                    {
                        myConn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            UserSession.Role = reader["Role"].ToString();
                            UserSession.Username = reader["Username"].ToString();

                            if (UserSession.Role == "Admin" || UserSession.Role == "Employee")
                            {
                                frmDashboard adminDash = new frmDashboard();
                                adminDash.Show();
                            }
                            else if (UserSession.Role == "Renter")
                            {
                                frmRenterDashboard renterDash = new frmRenterDashboard();
                                renterDash.Show();
                            }
                            else
                            {
                                MessageBox.Show("Account role not recognized. Please contact support.");
                                return;
                            }

                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterForm registrationForm = new RegisterForm();

            registrationForm.ShowDialog();
        }
    }
}
