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

          
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AllowUserToAddRows = false; 
            dgvUsers.AllowUserToDeleteRows = false; 
            dgvUsers.ReadOnly = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

          
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.CellClick += dgvUsers_SelectionChanged;

            
            btnUpdate.Click += btnUpdate_Click_1;

         
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

  
                string query = "SELECT ID, Username, [Password], FullName, [Role] FROM Users";

                adapter = new OleDbDataAdapter(query, conn);

       
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

       
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);

    
                dgvUsers.DataSource = dt.DefaultView;

          
                if (dgvUsers.Columns.Contains("ID"))
                {
                    dgvUsers.Columns["ID"].Visible = false;
                }

            
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

                
                dgvUsers.EndEdit();
                BindingSource bs = dgvUsers.DataSource as BindingSource;
                if (bs != null && bs.Current is DataRowView drv)
                    drv.EndEdit();

             
                DataTable tableToUpdate = dt;

                adapter.Update(tableToUpdate);

                MessageBox.Show("Changes saved successfully!");
                LoadUserData(); 
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

           
                dr["Username"] = "";
                dr["Password"] = "";
                dr["FullName"] = "";
                dr["Role"] = "Renter";

                dt.Rows.Add(dr);

               
                dgvUsers.DataSource = dt.DefaultView;

               
                if (dgvUsers.Columns.Contains("ID"))
                {
                    dgvUsers.Columns["ID"].Visible = false;
                }

             
                int rowIndex = dgvUsers.Rows.Count - 1;
                if (rowIndex >= 0)
                {
                   
                    int usernameIndex = dgvUsers.Columns.Contains("Username") ? dgvUsers.Columns["Username"].Index : Math.Min(1, dgvUsers.Columns.Count - 1);
                    dgvUsers.CurrentCell = dgvUsers.Rows[rowIndex].Cells[usernameIndex];
                    dgvUsers.BeginEdit(true);
                }

                ClearDetailFields(); 
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
                            
                            drv.Row.Delete();
                        }
                        else
                        {
                           
                            dgvUsers.Rows.RemoveAt(row.Index);
                        }
                    }

            
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

   
        private void dgvUsers_SelectionChanged(object? sender, EventArgs e)
        {
            FillDetailFieldsFromCurrentRow();
        }


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

   
            string username = drv.Row.Table.Columns.Contains("Username") ? drv["Username"]?.ToString() ?? "" : "";
            string password = drv.Row.Table.Columns.Contains("Password") ? drv["Password"]?.ToString() ?? "" : "";
            string fullname = drv.Row.Table.Columns.Contains("FullName") ? drv["FullName"]?.ToString() ?? "" : "";
            string role = drv.Row.Table.Columns.Contains("Role") ? drv["Role"]?.ToString() ?? "" : "";

      
            SetTextBoxIfExists("txtUsername", username);
            SetTextBoxIfExists("txtPassword", password);
            SetTextBoxIfExists("txtFullName", fullname);
            SetTextBoxIfExists("txtRole", role);

     
            var tbList = pnlDetails.Controls.OfType<TextBox>()
                                .OrderBy(t => t.TabIndex)
                                .ToArray();


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

        private void SetTextBoxIfExists(string name, string value)
        {
            var ctl = pnlDetails.Controls.Find(name, true).FirstOrDefault() as TextBox;
            if (ctl != null) ctl.Text = value;
        }


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

        private void btnUpdate_Click_1(object? sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null || !(dgvUsers.CurrentRow.DataBoundItem is DataRowView drv))
                {
                    MessageBox.Show("Please select a row to update.");
                    return;
                }

     
                string username = GetDetailValue("txtUsername", 0);
                string password = GetDetailValue("txtPassword", 1);
                string fullname = GetDetailValue("txtFullName", 2);
                string role = GetDetailValue("txtRole", 3);

    
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username cannot be empty.");
                    return;
                }

   
                if (drv.Row.Table.Columns.Contains("Username")) drv["Username"] = username;
                if (drv.Row.Table.Columns.Contains("Password")) drv["Password"] = password;
                if (drv.Row.Table.Columns.Contains("FullName")) drv["FullName"] = fullname;
                if (drv.Row.Table.Columns.Contains("Role")) drv["Role"] = role;

     
                drv.EndEdit();

             
                dgvUsers.Refresh();

                MessageBox.Show("Row updated in grid. Click Save to persist changes to database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating row: " + ex.Message);
            }
        }

      
        private void ClearDetailFields()
        {
            foreach (var tb in pnlDetails.Controls.OfType<TextBox>())
                tb.Text = string.Empty;
        }
    }
}