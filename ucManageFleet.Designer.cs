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
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 67);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1495, 64);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(308, 46);
            label1.TabIndex = 0;
            label1.Text = "Fleet Management\r\n";
            // 
            // pnlDetails
            // 
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
            pnlDetails.Location = new Point(0, 67);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(338, 609);
            pnlDetails.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(183, 474);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 36);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(26, 474);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 36);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(183, 418);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 36);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(26, 418);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 36);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "Maintenance" });
            cmbStatus.Location = new Point(26, 344);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(287, 28);
            cmbStatus.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 321);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 15;
            label6.Text = "Status";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(26, 274);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(287, 27);
            txtPrice.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 251);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 13;
            label5.Text = "Price/Day";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(26, 206);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(287, 27);
            txtModel.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 183);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 11;
            label4.Text = "Model";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(26, 139);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(287, 27);
            txtBrand.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 116);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 9;
            label3.Text = "Brand";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(26, 74);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(287, 27);
            txtPlateNumber.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 51);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 7;
            label2.Text = "Plate Number";
            // 
            // dgvFleet
            // 
            dgvFleet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFleet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFleet.Dock = DockStyle.Fill;
            dgvFleet.Location = new Point(338, 67);
            dgvFleet.Name = "dgvFleet";
            dgvFleet.RowHeadersWidth = 51;
            dgvFleet.Size = new Size(1157, 609);
            dgvFleet.TabIndex = 2;
            dgvFleet.CellContentClick += dgvFleet_CellContentClick;
            // 
            // ucManageFleet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvFleet);
            Controls.Add(pnlDetails);
            Controls.Add(panel1);
            Name = "ucManageFleet";
            Size = new Size(1495, 676);
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
    }
}
