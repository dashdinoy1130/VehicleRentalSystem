namespace VehicleRentalSystem
{
    partial class ucManageFleet
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            cmbStatusFilter = new ComboBox();
            label7 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            pnlDetails = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            cmbStatus = new ComboBox();
            label6 = new Label();
            txtPrice = new TextBox();
            label5 = new Label();
            txtModel = new TextBox();
            label4 = new Label();
            txtBrand = new TextBox();
            label3 = new Label();
            txtPlateNumber = new TextBox();
            label2 = new Label();
            dgvFleet = new DataGridView();
            cmbTypeFilter = new ComboBox();
            cmbVehicleType = new ComboBox();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFleet).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1308, 50);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbTypeFilter);
            panel2.Controls.Add(cmbStatusFilter);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1308, 48);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            cmbStatusFilter.Location = new Point(823, 19);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(190, 23);
            cmbStatusFilter.TabIndex = 9;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(360, 13);
            label7.Name = "label7";
            label7.Size = new Size(82, 29);
            label7.TabIndex = 8;
            label7.Text = "Search: ";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(448, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(259, 29);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(246, 37);
            label1.TabIndex = 0;
            label1.Text = "Fleet Management\r\n";
            // 
            // pnlDetails
            // 
            pnlDetails.Controls.Add(label8);
            pnlDetails.Controls.Add(cmbVehicleType);
            pnlDetails.Controls.Add(btnClear);
            pnlDetails.Controls.Add(btnDelete);
            pnlDetails.Controls.Add(btnUpdate);
            pnlDetails.Controls.Add(btnSave);
            pnlDetails.Controls.Add(cmbStatus);
            pnlDetails.Controls.Add(label6);
            pnlDetails.Controls.Add(txtPrice);
            pnlDetails.Controls.Add(label5);
            pnlDetails.Controls.Add(txtModel);
            pnlDetails.Controls.Add(label4);
            pnlDetails.Controls.Add(txtBrand);
            pnlDetails.Controls.Add(label3);
            pnlDetails.Controls.Add(txtPlateNumber);
            pnlDetails.Controls.Add(label2);
            pnlDetails.Dock = DockStyle.Left;
            pnlDetails.Location = new Point(0, 50);
            pnlDetails.Margin = new Padding(3, 2, 3, 2);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(296, 457);
            pnlDetails.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(160, 411);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(114, 27);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(23, 411);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 27);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(160, 366);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 27);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(23, 366);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 27);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "Maintenance" });
            cmbStatus.Location = new Point(23, 258);
            cmbStatus.Margin = new Padding(3, 2, 3, 2);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(252, 23);
            cmbStatus.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 241);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 15;
            label6.Text = "Status";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(23, 206);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(252, 23);
            txtPrice.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 188);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 13;
            label5.Text = "Price/Day";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(23, 154);
            txtModel.Margin = new Padding(3, 2, 3, 2);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(252, 23);
            txtModel.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 137);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 11;
            label4.Text = "Model";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(23, 104);
            txtBrand.Margin = new Padding(3, 2, 3, 2);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(252, 23);
            txtBrand.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 87);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 9;
            label3.Text = "Brand";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(23, 56);
            txtPlateNumber.Margin = new Padding(3, 2, 3, 2);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(252, 23);
            txtPlateNumber.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 38);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 7;
            label2.Text = "Plate Number";
            // 
            // dgvFleet
            // 
            dgvFleet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFleet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFleet.Dock = DockStyle.Fill;
            dgvFleet.Location = new Point(296, 50);
            dgvFleet.Margin = new Padding(3, 2, 3, 2);
            dgvFleet.Name = "dgvFleet";
            dgvFleet.RowHeadersWidth = 51;
            dgvFleet.Size = new Size(1012, 457);
            dgvFleet.TabIndex = 2;
            dgvFleet.CellContentClick += dgvFleet_CellContentClick;
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Items.AddRange(new object[] { "All", "SUV", "Sedan", "Hatchback" });
            cmbTypeFilter.Location = new Point(1036, 19);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(190, 23);
            cmbTypeFilter.TabIndex = 10;
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.FormattingEnabled = true;
            cmbVehicleType.Items.AddRange(new object[] { "Available", "Maintenance" });
            cmbVehicleType.Location = new Point(22, 320);
            cmbVehicleType.Margin = new Padding(3, 2, 3, 2);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(252, 23);
            cmbVehicleType.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 303);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 22;
            label8.Text = "Vehicle Type";
            // 
            // ucManageFleet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvFleet);
            Controls.Add(pnlDetails);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucManageFleet";
            Size = new Size(1308, 507);
            Load += ucDashboard_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFleet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel pnlDetails;
        private DataGridView dgvFleet;
        private TextBox txtBrand;
        private Label label3;
        private TextBox txtPlateNumber;
        private Label label2;
        private ComboBox cmbStatus;
        private Label label6;
        private TextBox txtPrice;
        private Label label5;
        private TextBox txtModel;
        private Label label4;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Label label7;
        private TextBox txtSearch;
        private ComboBox cmbStatusFilter;
        private ComboBox cmbTypeFilter;
        private Label label8;
        private ComboBox cmbVehicleType;
    }
}
