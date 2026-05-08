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
        private ComboBox cmbVehicleType;
        public ucRenterBooking()
        {
            InitializeComponent();
        }

        private void ucRenterBooking_Load(object sender, EventArgs e)
        {
            SetupFilterUI();           // 1. Create and show the UI
            LoadVehiclesFromDatabase();
        }

        private void SetupFilterUI()
        {
            if (cmbVehicleType == null)
            {
                cmbVehicleType = new ComboBox();
                panel1.Controls.Add(cmbVehicleType);

                cmbVehicleType.Size = new Size(150, 25);
                cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbVehicleType.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Hatchback", "Van", "Pickup", "MPV" });
                cmbVehicleType.SelectedIndex = 0;
                cmbVehicleType.Location = new Point(10, 10);
                cmbVehicleType.BringToFront();

                cmbVehicleType.SelectedIndexChanged += (s, ev) => {
                    LoadVehiclesFromDatabase(txtSearch.Text.Trim());
                };

                panel1.Dock = DockStyle.Top;
                panel1.BringToFront();
                flpVehicles.Dock = DockStyle.Fill;
                flpVehicles.AutoScroll = true;
            }

        }
        private void CmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVehiclesFromDatabase(txtSearch.Text.Trim());
        }

        public void LoadVehiclesFromDatabase(string searchFilter = "")
        {
            flpVehicles.Controls.Clear();
            string selectedType = (cmbVehicleType != null && cmbVehicleType.SelectedItem != null)
                      ? cmbVehicleType.SelectedItem.ToString()
                      : "All";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "SELECT Brand, Model, PricePerDay, PlateNumber, VehicleType FROM Vehicles WHERE [Status] = 'Available'";

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query += " AND (Brand LIKE ? OR Model LIKE ?)";
                    }
                    if (selectedType != "All")
                    {
                        query += " AND VehicleType = ?";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchFilter))
                        {
                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = "%" + searchFilter + "%";
                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = "%" + searchFilter + "%";
                        }

                        if (selectedType != "All")
                        {
                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = selectedType;
                        }

                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        bool hasData = false;
                        while (reader.Read())
                        {
                            hasData = true;
                            // FIXED: Now correctly calling the method with 5 arguments
                            CreateVehicleCard(
                                reader["Brand"].ToString(),
                                reader["Model"].ToString(),
                                reader["PricePerDay"].ToString(),
                                reader["PlateNumber"].ToString(),
                                reader["VehicleType"].ToString()
                            );
                        }

                        if (!hasData)
                        {
                            Label lblNoData = new Label { Text = "No vehicles found.", AutoSize = true, ForeColor = Color.Red, Font = new Font("Segoe UI", 10) };
                            flpVehicles.Controls.Add(lblNoData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }
        private void CreateVehicleCard(string brand, string model, string price, string plate, string type)
        {
            Panel card = new Panel();
            card.Size = new Size(260, 200); // Increased height to 200 to fit everything
            card.BackColor = Color.White;
            card.Margin = new Padding(15);
            card.Padding = new Padding(10);

            // 1. Brand and Model Title
            Label lblTitle = new Label();
            lblTitle.Text = $"{brand.ToUpper()} {model}";
            lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitle.Location = new Point(15, 20); // Moved down to Y=20 to clear the panel edge
            lblTitle.Size = new Size(230, 25);
            lblTitle.AutoSize = false;

            // 2. Vehicle Type Badge
            Label lblType = new Label();
            lblType.Text = type.ToUpper();
            lblType.Font = new Font("Segoe UI", 7, FontStyle.Bold);
            lblType.ForeColor = Color.DimGray;
            lblType.BackColor = Color.FromArgb(240, 240, 240);
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblType.Size = new Size(75, 20);
            lblType.Location = new Point(15, 50); // Shifted down

            // 3. Plate Number
            Label lblPlate = new Label();
            lblPlate.Text = "PLATE: " + plate;
            lblPlate.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblPlate.ForeColor = Color.Gray;
            lblPlate.Location = new Point(15, 75); // Shifted down
            lblPlate.AutoSize = true;

            // 4. Price
            Label lblPrice = new Label();
            lblPrice.Text = $"₱{price}/Day";
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(0, 122, 204);
            lblPrice.Location = new Point(15, 145); // Lowered near bottom
            lblPrice.AutoSize = true;

            // 5. Rent Button
            Button btnRent = new Button();
            btnRent.Text = "RENT NOW";
            btnRent.Size = new Size(100, 35);
            btnRent.Location = new Point(140, 140); // Aligned with Price
            btnRent.BackColor = Color.FromArgb(31, 30, 68);
            btnRent.ForeColor = Color.White;
            btnRent.FlatStyle = FlatStyle.Flat;
            btnRent.Cursor = Cursors.Hand;
            btnRent.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            btnRent.Tag = plate;
            btnRent.Click += (s, e) => {
                string selectedPlate = ((Button)s).Tag.ToString();
                using (frmCheckout checkoutForm = new frmCheckout(selectedPlate, $"{brand} {model}", price))
                {
                    if (checkoutForm.ShowDialog() == DialogResult.OK) LoadVehiclesFromDatabase();
                }
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblType);
            card.Controls.Add(lblPlate);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnRent);

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
       
        