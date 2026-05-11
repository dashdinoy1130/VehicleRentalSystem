using VehicleRentalSystem;




namespace VehicleRentalSystem
{
    partial class ucPointOfSales
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPointOfSales));
            panelTop = new Panel();
            labelTitle = new Label();
            txtSearch = new TextBox();
            labelSearch = new Label();
            pnlLeft = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            txtPrice = new TextBox();
            labelPrice = new Label();
            txtModel = new TextBox();
            labelModel = new Label();
            txtBrand = new TextBox();
            labelBrand = new Label();
            txtPlateNumber = new TextBox();
            labelPlate = new Label();
            pnlRight = new Panel();
            grpTransaction = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbTypeFilter = new ComboBox();
            cmbFleetStatusFilter = new ComboBox();
            btnMarkPaid = new Button();
            picQR = new PictureBox();
            btnReceipt = new Button();
            btnFinalize = new Button();
            btnCalculate = new Button();
            cmbPayment = new ComboBox();
            lblTotalAmountLabel = new Label();
            lblTotalDays = new Label();
            dtpEnd = new DateTimePicker();
            lblEnd = new Label();
            dtpStart = new DateTimePicker();
            lblStart = new Label();
            txtContact = new TextBox();
            lblContact = new Label();
            txtLicense = new TextBox();
            lblLicense = new Label();
            txtCustomer = new TextBox();
            lblCustomer = new Label();
            dgvFleet = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panelTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            grpTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFleet).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelTitle);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(labelSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1308, 48);
            panelTop.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 19.8F, FontStyle.Bold);
            labelTitle.Location = new Point(12, 8);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(186, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Point Of Sales";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(820, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search fleet (plate, brand, model)...";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(750, 15);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(45, 15);
            labelSearch.TabIndex = 1;
            labelSearch.Text = "Search:";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(btnClear);
            pnlLeft.Controls.Add(btnDelete);
            pnlLeft.Controls.Add(btnUpdate);
            pnlLeft.Controls.Add(btnSave);
            pnlLeft.Controls.Add(txtPrice);
            pnlLeft.Controls.Add(labelPrice);
            pnlLeft.Controls.Add(txtModel);
            pnlLeft.Controls.Add(labelModel);
            pnlLeft.Controls.Add(txtBrand);
            pnlLeft.Controls.Add(labelBrand);
            pnlLeft.Controls.Add(txtPlateNumber);
            pnlLeft.Controls.Add(labelPlate);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 48);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(300, 459);
            pnlLeft.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(105, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 27);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(15, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 27);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(105, 240);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 27);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(15, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 27);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(15, 189);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(260, 23);
            txtPrice.TabIndex = 7;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(12, 171);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(58, 15);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Price/Day";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(15, 136);
            txtModel.Name = "txtModel";
            txtModel.ReadOnly = true;
            txtModel.Size = new Size(260, 23);
            txtModel.TabIndex = 5;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(12, 118);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(41, 15);
            labelModel.TabIndex = 4;
            labelModel.Text = "Model";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(15, 83);
            txtBrand.Name = "txtBrand";
            txtBrand.ReadOnly = true;
            txtBrand.Size = new Size(260, 23);
            txtBrand.TabIndex = 3;
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Location = new Point(12, 65);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(38, 15);
            labelBrand.TabIndex = 2;
            labelBrand.Text = "Brand";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(15, 30);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.ReadOnly = true;
            txtPlateNumber.Size = new Size(260, 23);
            txtPlateNumber.TabIndex = 1;
            // 
            // labelPlate
            // 
            labelPlate.AutoSize = true;
            labelPlate.Location = new Point(12, 12);
            labelPlate.Name = "labelPlate";
            labelPlate.Size = new Size(80, 15);
            labelPlate.TabIndex = 0;
            labelPlate.Text = "Plate Number";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grpTransaction);
            pnlRight.Controls.Add(dgvFleet);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(300, 48);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(10);
            pnlRight.Size = new Size(1008, 459);
            pnlRight.TabIndex = 2;
            // 
            // grpTransaction
            // 
            grpTransaction.Controls.Add(label3);
            grpTransaction.Controls.Add(label2);
            grpTransaction.Controls.Add(label1);
            grpTransaction.Controls.Add(cmbTypeFilter);
            grpTransaction.Controls.Add(cmbFleetStatusFilter);
            grpTransaction.Controls.Add(btnMarkPaid);
            grpTransaction.Controls.Add(picQR);
            grpTransaction.Controls.Add(btnReceipt);
            grpTransaction.Controls.Add(btnFinalize);
            grpTransaction.Controls.Add(btnCalculate);
            grpTransaction.Controls.Add(cmbPayment);
            grpTransaction.Controls.Add(lblTotalAmountLabel);
            grpTransaction.Controls.Add(lblTotalDays);
            grpTransaction.Controls.Add(dtpEnd);
            grpTransaction.Controls.Add(lblEnd);
            grpTransaction.Controls.Add(dtpStart);
            grpTransaction.Controls.Add(lblStart);
            grpTransaction.Controls.Add(txtContact);
            grpTransaction.Controls.Add(lblContact);
            grpTransaction.Controls.Add(txtLicense);
            grpTransaction.Controls.Add(lblLicense);
            grpTransaction.Controls.Add(txtCustomer);
            grpTransaction.Controls.Add(lblCustomer);
            grpTransaction.Dock = DockStyle.Top;
            grpTransaction.Location = new Point(10, 10);
            grpTransaction.Name = "grpTransaction";
            grpTransaction.Size = new Size(988, 220);
            grpTransaction.TabIndex = 0;
            grpTransaction.TabStop = false;
            grpTransaction.Text = "Transaction Panel (Walk-ins)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(633, 91);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 23;
            label3.Text = "Vehicle Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(488, 91);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 22;
            label2.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(340, 90);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 21;
            label1.Text = "Payment Method";
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Items.AddRange(new object[] { "All", "SUV", "Sedan", "Hatchback" });
            cmbTypeFilter.Location = new Point(633, 106);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(130, 23);
            cmbTypeFilter.TabIndex = 20;
            cmbTypeFilter.SelectedIndexChanged += cmbTypeFilter_SelectedIndexChanged;
            // 
            // cmbFleetStatusFilter
            // 
            cmbFleetStatusFilter.FormattingEnabled = true;
            cmbFleetStatusFilter.Location = new Point(488, 109);
            cmbFleetStatusFilter.Name = "cmbFleetStatusFilter";
            cmbFleetStatusFilter.Size = new Size(122, 23);
            cmbFleetStatusFilter.TabIndex = 19;
            // 
            // btnMarkPaid
            // 
            btnMarkPaid.Location = new Point(837, 176);
            btnMarkPaid.Name = "btnMarkPaid";
            btnMarkPaid.Size = new Size(101, 33);
            btnMarkPaid.TabIndex = 18;
            btnMarkPaid.Text = "Mark Paid";
            btnMarkPaid.UseVisualStyleBackColor = true;
            btnMarkPaid.Click += btnMarkPaid_Click_1;
            // 
            // picQR
            // 
            picQR.Image = (Image)resources.GetObject("picQR.Image");
            picQR.Location = new Point(788, 21);
            picQR.Name = "picQR";
            picQR.Size = new Size(185, 147);
            picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            picQR.TabIndex = 17;
            picQR.TabStop = false;
            // 
            // btnReceipt
            // 
            btnReceipt.Location = new Point(365, 168);
            btnReceipt.Name = "btnReceipt";
            btnReceipt.Size = new Size(160, 36);
            btnReceipt.TabIndex = 15;
            btnReceipt.Text = "Generate Receipt";
            btnReceipt.UseVisualStyleBackColor = true;
            btnReceipt.Click += BtnReceipt_Click;
            // 
            // btnFinalize
            // 
            btnFinalize.Location = new Point(180, 167);
            btnFinalize.Name = "btnFinalize";
            btnFinalize.Size = new Size(160, 36);
            btnFinalize.TabIndex = 14;
            btnFinalize.Text = "Finalize Transaction";
            btnFinalize.UseVisualStyleBackColor = true;
            btnFinalize.Click += BtnFinalize_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(3, 169);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(160, 34);
            btnCalculate.TabIndex = 13;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += BtnCalculate_Click;
            // 
            // cmbPayment
            // 
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Items.AddRange(new object[] { "Cash", "GCash" });
            cmbPayment.Location = new Point(343, 108);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(120, 23);
            cmbPayment.TabIndex = 16;
            // 
            // lblTotalAmountLabel
            // 
            lblTotalAmountLabel.AutoSize = true;
            lblTotalAmountLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmountLabel.Location = new Point(614, 183);
            lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            lblTotalAmountLabel.Size = new Size(93, 17);
            lblTotalAmountLabel.TabIndex = 11;
            lblTotalAmountLabel.Text = "Total Amount";
            // 
            // lblTotalDays
            // 
            lblTotalDays.AutoSize = true;
            lblTotalDays.Location = new Point(614, 153);
            lblTotalDays.Name = "lblTotalDays";
            lblTotalDays.Size = new Size(64, 15);
            lblTotalDays.TabIndex = 10;
            lblTotalDays.Text = "Total Days:";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(183, 108);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(140, 23);
            dtpEnd.TabIndex = 9;
            dtpEnd.ValueChanged += DtpEnd_ValueChanged;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(180, 90);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(54, 15);
            lblEnd.TabIndex = 8;
            lblEnd.Text = "End Date";
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(18, 108);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(140, 23);
            dtpStart.TabIndex = 7;
            dtpStart.ValueChanged += DtpStart_ValueChanged;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(15, 90);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(58, 15);
            lblStart.TabIndex = 6;
            lblStart.Text = "Start Date";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(563, 48);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(200, 23);
            txtContact.TabIndex = 5;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(560, 30);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(96, 15);
            lblContact.TabIndex = 4;
            lblContact.Text = "Contact Number";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(343, 48);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(200, 23);
            txtLicense.TabIndex = 3;
            // 
            // lblLicense
            // 
            lblLicense.AutoSize = true;
            lblLicense.Location = new Point(340, 30);
            lblLicense.Name = "lblLicense";
            lblLicense.Size = new Size(98, 15);
            lblLicense.TabIndex = 2;
            lblLicense.Text = "Driver's License #";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(18, 48);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(300, 23);
            txtCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(15, 30);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(94, 15);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer Name";
            // 
            // dgvFleet
            // 
            dgvFleet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFleet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFleet.Location = new Point(10, 240);
            dgvFleet.Name = "dgvFleet";
            dgvFleet.ReadOnly = true;
            dgvFleet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFleet.Size = new Size(988, 200);
            dgvFleet.TabIndex = 1;
            dgvFleet.CellClick += DgvFleet_CellClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ucPointOfSales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(panelTop);
            Name = "ucPointOfSales";
            Size = new Size(1308, 507);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            grpTransaction.ResumeLayout(false);
            grpTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFleet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label labelTitle;
        private TextBox txtSearch;
        private Label labelSearch;
        private Panel pnlLeft;
        private Label labelPlate;
        private TextBox txtPlateNumber;
        private Label labelBrand;
        private TextBox txtBrand;
        private Label labelModel;
        private TextBox txtModel;
        private Label labelPrice;
        private TextBox txtPrice;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel pnlRight;
        private GroupBox grpTransaction;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Label lblLicense;
        private TextBox txtLicense;
        private Label lblContact;
        private TextBox txtContact;
        private Label lblStart;
        private DateTimePicker dtpStart;
        private Label lblEnd;
        private DateTimePicker dtpEnd;
        private Label lblTotalDays;
        private Label lblTotalAmountLabel;
        private ComboBox cmbPayment;
        private Button btnCalculate;
        private Button btnFinalize;
        private Button btnReceipt;
        private DataGridView dgvFleet;
        private Button btnMarkPaid;
        private PictureBox picQR;
        private ComboBox cmbFleetStatusFilter;
        private ComboBox cmbTypeFilter;
        private Label label2;
        private Label label1;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
    }
}