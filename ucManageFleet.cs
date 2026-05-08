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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VehicleRentalSystem
{
    public partial class ucManageFleet : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";
        DataTable fleetTable = new DataTable();
        private int selectedVehicleID = 0;
        public ucManageFleet()
        {
            InitializeComponent();
            this.dgvFleet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFleet_CellClick);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        }

        public void LoadFleetData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    // Updated query to include VehicleType
                    string query = "SELECT VehicleID, PlateNumber, Brand, Model, VehicleType, PricePerDay, [Status] FROM Vehicles";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFleet.DataSource = dt;

                    if (dgvFleet.Columns.Contains("VehicleID"))
                        dgvFleet.Columns["VehicleID"].Visible = false;

                    FormatFleetGrid(); // Use our new method here
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    // Match the order of your Access Table: Plate, Type, Brand, Model, Price
                    string query = "INSERT INTO Vehicles (PlateNumber, VehicleType, Brand, Model, PricePerDay, [Status]) VALUES (?, ?, ?, ?, ?, 'Available')";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Order must be 1:1 with the query above
                        cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("?", cmbVehicleType.Text.Trim()); // Moved to 2nd
                        cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());       // Moved to 3rd
                        cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());

                        // Since PricePerDay is 'Number' in Access, we convert it to double/decimal
                        double price = 0;
                        double.TryParse(txtPrice.Text, out price);
                        cmd.Parameters.AddWithValue("?", price);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle saved successfully!");
                        LoadFleetData();
                        ClearFields();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Save Error: " + ex.Message); }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVehicleID == 0) { MessageBox.Show("Please select a vehicle first."); return; }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Vehicles SET PlateNumber=?, VehicleType=?, Brand=?, Model=?, PricePerDay=?, [Status]=? WHERE VehicleID=?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("?", cmbVehicleType.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());

                        double price = 0;
                        double.TryParse(txtPrice.Text, out price);
                        cmd.Parameters.AddWithValue("?", price);

                        cmd.Parameters.AddWithValue("?", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("?", selectedVehicleID); // The WHERE clause ID must be LAST

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle updated successfully.");
                        LoadFleetData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVehicleID == 0)
            {
                MessageBox.Show("Please select a vehicle from the list first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this vehicle?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    try
                    {
                        string query = "DELETE FROM Vehicles WHERE VehicleID = ?";

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", selectedVehicleID);

                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Vehicle removed from system.");
                                selectedVehicleID = 0;
                                ClearFields();
                                LoadFleetData();
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. Vehicle ID not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting: " + ex.Message);
                    }
                }
            }
        }



        private void dgvFleet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFleet.Rows[e.RowIndex];

                selectedVehicleID = Convert.ToInt32(row.Cells["VehicleID"].Value);

                txtPlateNumber.Text = row.Cells["PlateNumber"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtPrice.Text = row.Cells["PricePerDay"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
                cmbVehicleType.Text = row.Cells["VehicleType"].Value.ToString();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtPlateNumber.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtPrice.Clear();

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
            selectedVehicleID = 0;
            dgvFleet.ClearSelection();
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadFleetData();

            // Setup the Status ComboBox for Editing a vehicle
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Available", "Rented", "Pending Return", "Maintenance" });
            cmbStatus.SelectedIndex = 0;

            // Setup the Filter ComboBox (the new one we added)
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            cmbStatusFilter.SelectedIndex = 0; // Default to "All"

            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Hatchback", "Van", "Pickup", "MPV" });
            cmbTypeFilter.SelectedIndex = 0;
            // Wire up the event for the Filter ComboBox
            cmbStatusFilter.SelectedIndexChanged += (s, ev) => ApplyFilters();
            cmbTypeFilter.SelectedIndexChanged += (s, ev) => ApplyFilters();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvFleet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            try
            {
                if (dgvFleet.DataSource == null) return;

                string filterValue = txtSearch.Text.Replace("'", "''");
                string selectedStatus = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
                string selectedType = cmbTypeFilter.SelectedItem?.ToString() ?? "All";

                CurrencyManager cm = (CurrencyManager)BindingContext[dgvFleet.DataSource];
                DataView dv = (DataView)cm.List;

                // 1. Base Search Filter
                string filter = string.Format(
                    "(PlateNumber LIKE '%{0}%' OR Brand LIKE '%{0}%' OR Model LIKE '%{0}%')",
                    filterValue);

                // 2. Add Status Filter
                if (selectedStatus != "All")
                    filter += string.Format(" AND Status = '{0}'", selectedStatus);

                // 3. Add Type Filter
                if (selectedType != "All")
                    filter += string.Format(" AND VehicleType = '{0}'", selectedType);

                dv.RowFilter = filter;

                // Re-apply formatting
                FormatFleetGrid();
            }
            catch (Exception ex) { MessageBox.Show("Filter Error: " + ex.Message); }
        }
        private void UpdateRowColor(DataGridViewRow row)
        {
            string status = row.Cells["Status"].Value?.ToString();
            if (status == "Maintenance") row.DefaultCellStyle.ForeColor = Color.Red;
            else if (status == "Available") row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            else if (status == "Rented") row.DefaultCellStyle.ForeColor = Color.Blue;
        }
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FormatFleetGrid()
        {
            foreach (DataGridViewRow row in dgvFleet.Rows)
            {
                UpdateRowColor(row);
            }
        }
    }
}
