using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class ucManageUsers : UserControl
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataTable dt;

        public ucManageUsers()
        {
            InitializeComponent();

            // Grid settings
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AllowUserToAddRows = false; // use Add button
            dgvUsers.AllowUserToDeleteRows = false; // delete via button (so we control DataTable deletion)
            dgvUsers.ReadOnly = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // wire selection change to populate detail textboxes
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.CellClick += dgvUsers_SelectionChanged;

            // wire update button
            btnUpdate.Click += btnUpdate_Click_1;

            // Load data immediately
            LoadUserData();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadUserData()
        {
            try
            {
                conn = new OleDbConnection(connString);

                // Include primary key (ID) so insert/update/delete commands can be generated correctly
                string query = "SELECT ID, Username, [Password], FullName, [Role] FROM Users";

                adapter = new OleDbDataAdapter(query, conn);

                // Ensure schema with primary key is retrieved so DataTable knows the key field
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                // CommandBuilder will auto-generate Insert/Update/Delete commands
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);

                // Bind the DataTable's DefaultView so RowFilter works and edits stay bound
                dgvUsers.DataSource = dt.DefaultView;

                // Hide the ID column from the user view but keep it in the DataTable for adapter operations
                if (dgvUsers.Columns.Contains("ID"))
                {
                    dgvUsers.Columns["ID"].Visible = false;
                }

                // if there is at least one row, select first so details show
                if (dgvUsers.Rows.Count > 0)
                {
                    dgvUsers.Rows[0].Selected = true;
                    FillDetailFieldsFromCurrentRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null) return;

            // Keep live binding by using the DefaultView's RowFilter
            string filter = txtSearch.Text.Replace("'", "''");
            dt.DefaultView.RowFilter = string.Format("Username LIKE '%{0}%' OR FullName LIKE '%{0}%'", filter);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dt == null || adapter == null)
                {
                    MessageBox.Show("No data to save.");
                    return;
                }

                // End any current edits so changes are written to the DataTable
                dgvUsers.EndEdit();
                BindingSource bs = dgvUsers.DataSource as BindingSource;
                if (bs != null && bs.Current is DataRowView drv)
                    drv.EndEdit();

                // If the grid is bound to a DataView, get the underlying DataTable
                DataTable tableToUpdate = dt;

                adapter.Update(tableToUpdate);

                MessageBox.Show("Changes saved successfully!");
                LoadUserData(); // reload to refresh keys and state
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dt == null)
                    dt = new DataTable();

                DataRow dr = dt.NewRow();

                // set sensible defaults (ID is AutoNumber so leave it null)
                dr["Username"] = "";
                dr["Password"] = "";
                dr["FullName"] = "";
                dr["Role"] = "Renter";

                dt.Rows.Add(dr);

                // refresh grid binding
                dgvUsers.DataSource = dt.DefaultView;

                // hide ID column again in case it reappears after binding
                if (dgvUsers.Columns.Contains("ID"))
                {
                    dgvUsers.Columns["ID"].Visible = false;
                }

                // Move selection to the new row and start edit
                int rowIndex = dgvUsers.Rows.Count - 1;
                if (rowIndex >= 0)
                {
                    // find Username column index (in case column order changed)
                    int usernameIndex = dgvUsers.Columns.Contains("Username") ? dgvUsers.Columns["Username"].Index : Math.Min(1, dgvUsers.Columns.Count - 1);
                    dgvUsers.CurrentCell = dgvUsers.Rows[rowIndex].Cells[usernameIndex];
                    dgvUsers.BeginEdit(true);
                }

                ClearDetailFields(); // prepare detail boxes for manual editing
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding row: " + ex.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvUsers.SelectedRows)
                    {
                        if (row.DataBoundItem is DataRowView drv)
                        {
                            // Mark the DataRow for deletion
                            drv.Row.Delete();
                        }
                        else
                        {
                            // fallback - remove visually
                            dgvUsers.Rows.RemoveAt(row.Index);
                        }
                    }

                    // update detail panel after deletion
                    FillDetailFieldsFromCurrentRow();
                }
                else
                {
                    MessageBox.Show("Please select a full row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting row: " + ex.Message);
            }
        }

        // SelectionChanged handler: populate textboxes with selected row values
        private void dgvUsers_SelectionChanged(object? sender, EventArgs e)
        {
            FillDetailFieldsFromCurrentRow();
        }

        // Copy values from current DataGridView row to the detail textboxes
        private void FillDetailFieldsFromCurrentRow()
        {
            if (dgvUsers.CurrentRow == null)
            {
                ClearDetailFields();
                return;
            }

            if (!(dgvUsers.CurrentRow.DataBoundItem is DataRowView drv))
            {
                ClearDetailFields();
                return;
            }

            // Get column values safely
            string username = drv.Row.Table.Columns.Contains("Username") ? drv["Username"]?.ToString() ?? "" : "";
            string password = drv.Row.Table.Columns.Contains("Password") ? drv["Password"]?.ToString() ?? "" : "";
            string fullname = drv.Row.Table.Columns.Contains("FullName") ? drv["FullName"]?.ToString() ?? "" : "";
            string role = drv.Row.Table.Columns.Contains("Role") ? drv["Role"]?.ToString() ?? "" : "";

            // 1) If developer added descriptive TextBox names, prefer them
            SetTextBoxIfExists("txtUsername", username);
            SetTextBoxIfExists("txtPassword", password);
            SetTextBoxIfExists("txtFullName", fullname);
            SetTextBoxIfExists("txtRole", role);

            // 2) Fallback: map available TextBoxes in pnlDetails by TabIndex order
            var tbList = pnlDetails.Controls.OfType<TextBox>()
                                .OrderBy(t => t.TabIndex)
                                .ToArray();

            // Determine which values are already set by named controls to avoid overwriting
            bool usernameSet = pnlDetails.Controls.Find("txtUsername", true).FirstOrDefault() is TextBox;
            bool passwordSet = pnlDetails.Controls.Find("txtPassword", true).FirstOrDefault() is TextBox;
            bool fullnameSet = pnlDetails.Controls.Find("txtFullName", true).FirstOrDefault() is TextBox;
            bool roleSet = pnlDetails.Controls.Find("txtRole", true).FirstOrDefault() is TextBox;

            int index = 0;
            if (!usernameSet && index < tbList.Length) { tbList[index++].Text = username; }
            if (!passwordSet && index < tbList.Length) { tbList[index++].Text = password; }
            if (!fullnameSet && index < tbList.Length) { tbList[index++].Text = fullname; }
            if (!roleSet && index < tbList.Length) { tbList[index++].Text = role; }
        }

        // Helper to set textbox by name if it exists
        private void SetTextBoxIfExists(string name, string value)
        {
            var ctl = pnlDetails.Controls.Find(name, true).FirstOrDefault() as TextBox;
            if (ctl != null) ctl.Text = value;
        }

        // Helper to read textbox value by name or by fallback order
        private string GetDetailValue(string name, int fallbackIndex)
        {
            var named = pnlDetails.Controls.Find(name, true).FirstOrDefault() as TextBox;
            if (named != null) return named.Text;

            var tbList = pnlDetails.Controls.OfType<TextBox>()
                                .OrderBy(t => t.TabIndex)
                                .ToArray();

            if (fallbackIndex >= 0 && fallbackIndex < tbList.Length)
                return tbList[fallbackIndex].Text;

            return string.Empty;
        }

        // Update button: copy textbox values back into the current DataRow
        private void btnUpdate_Click_1(object? sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null || !(dgvUsers.CurrentRow.DataBoundItem is DataRowView drv))
                {
                    MessageBox.Show("Please select a row to update.");
                    return;
                }

                // Read values from detail controls (prefer named controls)
                string username = GetDetailValue("txtUsername", 0);
                string password = GetDetailValue("txtPassword", 1);
                string fullname = GetDetailValue("txtFullName", 2);
                string role = GetDetailValue("txtRole", 3);

                // Validate minimal requirements
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username cannot be empty.");
                    return;
                }

                // Apply values to DataRow
                if (drv.Row.Table.Columns.Contains("Username")) drv["Username"] = username;
                if (drv.Row.Table.Columns.Contains("Password")) drv["Password"] = password;
                if (drv.Row.Table.Columns.Contains("FullName")) drv["FullName"] = fullname;
                if (drv.Row.Table.Columns.Contains("Role")) drv["Role"] = role;

                // Mark row as edited
                drv.EndEdit();

                // Refresh grid so changes are visible immediately
                dgvUsers.Refresh();

                MessageBox.Show("Row updated in grid. Click Save to persist changes to database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating row: " + ex.Message);
            }
        }

        // Clear available textboxes in the detail panel
        private void ClearDetailFields()
        {
            foreach (var tb in pnlDetails.Controls.OfType<TextBox>())
                tb.Text = string.Empty;
        }
    }
}