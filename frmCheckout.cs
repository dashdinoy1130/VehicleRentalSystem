using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class frmCheckout : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";


        decimal dailyRate = 0;
        string vehiclePlate = "";
        public frmCheckout(string plate, string brandModel, string price)
        {
            InitializeComponent();

            vehiclePlate = plate;
            dailyRate = decimal.Parse(price);

            lblPlate.Text = "Vehicle Plate: " + plate;
            lblCarInfo.Text = brandModel;
            lblPricePerDay.Text = "₱" + dailyRate.ToString("N2");
        }

        private void frmCheckout_Load_1(object sender, EventArgs e)
        {
            dtpStart.MinDate = DateTime.Now;
            dtpEnd.MinDate = DateTime.Now.AddDays(1);

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TimeSpan duration = dtpEnd.Value.Date - dtpStart.Value.Date;
            int days = duration.Days;

            if (days <= 0) days = 1;

            decimal total = days * dailyRate;

            lblTotalDays.Text = days.ToString() + " Day(s)";
            lblTotalAmount.Text = "₱" + total.ToString("N2");
        }
        private void dtpStart_ValueChanged(object sender, EventArgs e) => CalculateTotal();
        private void dtpEnd_ValueChanged(object sender, EventArgs e) => CalculateTotal();

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtLicense.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Please fill in all renter information fields.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO Transactions (RenterName, FullName, LicenseNumber, ContactNumber, PlateNumber, RentalDate, ReturnDate, TotalAmount, PaymentMethod, [Status]) " +
                                         "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, 'Active')";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", UserSession.Username); 
                        cmd.Parameters.AddWithValue("?", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtLicense.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtContactNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("?", vehiclePlate);
                        cmd.Parameters.AddWithValue("?", dtpStart.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("?", dtpEnd.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("?", lblTotalAmount.Text.Replace("₱", "").Replace(",", ""));
                        cmd.Parameters.AddWithValue("?", cmbPayment.Text);

                        cmd.ExecuteNonQuery();
                    }

                    string updateQuery = "UPDATE Vehicles SET [Status] = 'Rented' WHERE PlateNumber = ?";
                    using (OleDbCommand cmdUpdate = new OleDbCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("?", vehiclePlate);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show("Rental Confirmed! Transaction logged.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }
      
        private void frmCheckout_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
