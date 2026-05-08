// Replace your existing frmCheckout.cs with this version
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class frmCheckout : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        decimal dailyRate = 0;
        string vehiclePlate = "";

        // State for GCash flow
        private bool pendingGCash = false;
        private bool transactionFinalized = false;

        public frmCheckout(string plate, string brandModel, string price)
        {
            InitializeComponent();

            vehiclePlate = plate;
            dailyRate = decimal.Parse(price);

            lblPlate.Text = "Vehicle Plate: " + plate;
            lblCarInfo.Text = brandModel;
            lblPricePerDay.Text = "₱" + dailyRate.ToString("N2");

            // Ensure QR and receipt/payment-sent button are hidden until needed
            picQR.Visible = false;
            btnGenerateReceipt.Visible = false;

            // Change button text to "Pay"
            btnConfirmPayment.Text = "Pay";

            // Wire up payment method change handler (safe even if Designer already wires an event)
            cmbPaymentMethod.SelectedIndexChanged += cmbPaymentMethod_SelectedIndexChanged;
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

        // Clicking "Pay"
        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtLicense.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Please fill in all renter information fields.");
                return;
            }

            string paymentMethod = cmbPaymentMethod.Text?.Trim() ?? string.Empty;

            // If GCash selected, show QR and a "Payment Sent" button below it to finalize
            if (string.Equals(paymentMethod, "GCash", StringComparison.OrdinalIgnoreCase))
            {
                picQR.Visible = true;

                // Change this: Remove the (UserSession.Role == "Employee") restriction
                btnGenerateReceipt.Text = "Payment Sent";
                btnGenerateReceipt.Visible = true; // Make it visible for Renters too!

                pendingGCash = true;
                transactionFinalized = false;

                MessageBox.Show("Scan the QR to pay. Once done, click 'Payment Sent' to notify the staff.");
                return;
            }

            // For non-GCash (e.g., Cash) finalize immediately.
            FinalizeTransaction(paymentMethod);

            // Only employees may generate a receipt
            btnGenerateReceipt.Text = "Generate Receipt";
            btnGenerateReceipt.Visible = (UserSession.Role == "Employee");
        }

        // Finalize DB insert and vehicle status update
        private void FinalizeTransaction(string paymentMethod)
        {
            if (transactionFinalized) return;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // CHANGE: Status is now 'Pending Payment'
                    string insertQuery = "INSERT INTO Transactions (RenterName, FullName, LicenseNumber, ContactNumber, PlateNumber, RentalDate, ReturnDate, TotalAmount, PaymentMethod, [Status]) " +
                                         "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, 'Pending Payment')";

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
                        cmd.Parameters.AddWithValue("?", paymentMethod);

                        cmd.ExecuteNonQuery();
                    }

                    // REMOVED: The Vehicle Update (Wait for employee confirmation)
                    transactionFinalized = true;
                    MessageBox.Show("Payment request submitted! Please wait for employee confirmation.", "Pending Approval");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaymentUI();
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaymentUI();
        }

        private void UpdatePaymentUI()
        {
            if (string.Equals(cmbPaymentMethod.Text, "GCash", StringComparison.OrdinalIgnoreCase))
            {
                picQR.Visible = false;
                btnGenerateReceipt.Visible = false;
            }
            else
            {
                picQR.Visible = false;
                btnGenerateReceipt.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // btnGenerateReceipt now doubles as "Payment Sent" (to finalize) and "Generate Receipt"
        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            // Only employees are allowed to finalize/generate receipt here.
            string btnText = btnGenerateReceipt.Text?.Trim() ?? string.Empty;

            if (string.Equals(btnText, "Payment Sent", StringComparison.OrdinalIgnoreCase))
            {
                // This will now run for the Renter and save the "Pending Payment" status to the DB
                FinalizeTransaction("GCash");

                // After clicking, close the form or show a success message
                if (transactionFinalized)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                // Keep the restriction for ACTUAL receipt generation
                if (UserSession.Role != "Employee")
                {
                    MessageBox.Show("Only employees can print the official receipt.");
                    return;
                }
                ShowReceipt();
            }
        }

        // Use actual form fields to generate the receipt content
        private void ShowReceipt()
        {
            string receipt = "----- RECEIPT -----\n";
            receipt += $"Customer: {txtFullName.Text.Trim()}\n";
            receipt += $"License: {txtLicense.Text.Trim()}\n";
            receipt += $"Contact: {txtContactNumber.Text.Trim()}\n";
            receipt += $"Vehicle: {lblCarInfo.Text} ({vehiclePlate})\n";
            receipt += $"Rental: {dtpStart.Value.ToShortDateString()} - {dtpEnd.Value.ToShortDateString()}\n";
            receipt += $"Payment Method: {cmbPaymentMethod.Text}\n";
            receipt += $"Total: {lblTotalAmount.Text}\n";
            receipt += "Status: PAID\n";

            MessageBox.Show(receipt, "Receipt");
        }

        private void picQR_Click(object sender, EventArgs e)
        {

        }
    }
}