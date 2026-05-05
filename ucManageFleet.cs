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
    public partial class ucManageFleet : UserControl
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

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
                    string query = "SELECT VehicleID, PlateNumber, Brand, Model, PricePerDay, [Status] FROM Vehicles";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFleet.DataSource = dt;

                    if (dgvFleet.Columns.Contains("VehicleID"))
                        dgvFleet.Columns["VehicleID"].Visible = false;

                    foreach (DataGridViewRow row in dgvFleet.Rows)
                    {
                        string status = row.Cells["Status"].Value?.ToString();

                        if (status == "Maintenance")
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        else if (status == "Available")
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        else if (status == "Rented")
                            row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
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
                    string query = "INSERT INTO Vehicles (PlateNumber, Brand, Model, PricePerDay, [Status]) VALUES (?, ?, ?, ?, 'Available')";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtPrice.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle saved successfully!");
                        LoadFleetData();
                        ClearFields();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVehicleID == 0) { MessageBox.Show("Please select a vehicle from the list first."); return; }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Vehicles SET PlateNumber=?, Brand=?, Model=?, PricePerDay=?, [Status]=? WHERE VehicleID=?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", txtPlateNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtModel.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtPrice.Text.Trim());
                        cmd.Parameters.AddWithValue("?", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("?", selectedVehicleID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Vehicle updated successfully.");
                        LoadFleetData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Rented");
            cmbStatus.Items.Add("Pending Return");
            cmbStatus.Items.Add("Maintenance");
            cmbStatus.SelectedIndex = 0;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvFleet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
