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
    public partial class ucRenterBooking : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucRenterBooking()
        {
            InitializeComponent();
        }
        private void ucRenterBooking_Load(object sender, EventArgs e)
        {
            LoadVehiclesFromDatabase();
        }
        public void LoadVehiclesFromDatabase(string searchFilter = "")
        {
            flpVehicles.Controls.Clear(); 

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "SELECT Brand, Model, PricePerDay, PlateNumber FROM Vehicles WHERE [Status] = 'Available'";

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query += " AND (Brand LIKE ? OR Model LIKE ?)";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchFilter))
                        {
                            cmd.Parameters.AddWithValue("?", "%" + searchFilter + "%");
                            cmd.Parameters.AddWithValue("?", "%" + searchFilter + "%");
                        }

                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CreateVehicleCard(
                                reader["Brand"].ToString(),
                                reader["Model"].ToString(),
                                reader["PricePerDay"].ToString(),
                                reader["PlateNumber"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void CreateVehicleCard(string brand, string model, string price, string plate)
        {
            Panel card = new Panel();
            card.Size = new Size(260, 160);
            card.BackColor = Color.White;
            card.Margin = new Padding(15);
            card.Padding = new Padding(15);

            
            Label lblTitle = new Label();
            lblTitle.Text = $"{brand.ToUpper()} {model}";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 45, 48);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 35;

            
            Label lblPlate = new Label();
            lblPlate.Text = "PLATE: " + plate;
            lblPlate.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblPlate.ForeColor = Color.Gray;
            lblPlate.Dock = DockStyle.Top;
            lblPlate.Height = 20;

           
            Label lblPrice = new Label();
            lblPrice.Text = $"₱{price}/Day";
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(0, 122, 204); 
            lblPrice.Dock = DockStyle.Bottom;
            lblPrice.Height = 30;

            
            Button btnRent = new Button();
            btnRent.Text = "RENT NOW";
            btnRent.Size = new Size(100, 35);
            btnRent.Location = new Point(145, 110); 
            btnRent.BackColor = Color.FromArgb(31, 30, 68); 
            btnRent.ForeColor = Color.White;
            btnRent.FlatStyle = FlatStyle.Flat;
            btnRent.Cursor = Cursors.Hand;
            btnRent.Tag = plate; 
            btnRent.Click += (s, e) => {
                string selectedPlate = ((Button)s).Tag.ToString();
                using (frmCheckout checkoutForm = new frmCheckout(selectedPlate, $"{brand} {model}", price))
                {
                    if (checkoutForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadVehiclesFromDatabase();
                    }
                }
            };

            card.Controls.Add(btnRent);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblPlate);
            card.Controls.Add(lblTitle);

            flpVehicles.Controls.Add(card);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadVehiclesFromDatabase(txtSearch.Text.Trim());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
