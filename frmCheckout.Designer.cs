namespace VehicleRentalSystem
{
    partial class frmCheckout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            v = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFullName = new TextBox();
            txtLicense = new TextBox();
            txtContactNumber = new TextBox();
            dtpStart = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dtpEnd = new DateTimePicker();
            label1 = new Label();
            lblPricePerDay = new Label();
            label6 = new Label();
            label7 = new Label();
            lblTotalDays = new Label();
            label8 = new Label();
            lblTotalAmount = new Label();
            cmbPaymentMethod = new ComboBox();
            label9 = new Label();
            btnConfirmPayment = new Button();
            btnCancel = new Button();
            lblCarInfo = new Label();
            lblPlate = new Label();
            picQR = new PictureBox();
            btnGenerateReceipt = new Button();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // v
            // 
            v.AutoSize = true;
            v.Location = new Point(60, 124);
            v.Name = "v";
            v.Size = new Size(61, 15);
            v.TabIndex = 0;
            v.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 170);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "License Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 220);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 2;
            label3.Text = "Contact No.";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(60, 142);
            txtFullName.Margin = new Padding(3, 2, 3, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(282, 23);
            txtFullName.TabIndex = 3;
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(60, 187);
            txtLicense.Margin = new Padding(3, 2, 3, 2);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(282, 23);
            txtLicense.TabIndex = 4;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(60, 237);
            txtContactNumber.Margin = new Padding(3, 2, 3, 2);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(282, 23);
            txtContactNumber.TabIndex = 5;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(60, 291);
            dtpStart.Margin = new Padding(3, 2, 3, 2);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(125, 23);
            dtpStart.TabIndex = 6;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 274);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 7;
            label4.Text = "Date Start";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(221, 274);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 8;
            label5.Text = "Date End";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(221, 291);
            dtpEnd.Margin = new Padding(3, 2, 3, 2);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(120, 23);
            dtpEnd.TabIndex = 9;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 71);
            label1.Name = "label1";
            label1.Size = new Size(221, 37);
            label1.TabIndex = 10;
            label1.Text = "Check Out Form";
            // 
            // lblPricePerDay
            // 
            lblPricePerDay.AutoSize = true;
            lblPricePerDay.Location = new Point(153, 330);
            lblPricePerDay.Name = "lblPricePerDay";
            lblPricePerDay.Size = new Size(13, 15);
            lblPricePerDay.TabIndex = 11;
            lblPricePerDay.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 330);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 12;
            label6.Text = "Price Per Day:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 354);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 14;
            label7.Text = "Total Days:";
            // 
            // lblTotalDays
            // 
            lblTotalDays.AutoSize = true;
            lblTotalDays.Location = new Point(153, 354);
            lblTotalDays.Name = "lblTotalDays";
            lblTotalDays.Size = new Size(13, 15);
            lblTotalDays.TabIndex = 13;
            lblTotalDays.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(60, 376);
            label8.Name = "label8";
            label8.Size = new Size(110, 20);
            label8.TabIndex = 16;
            label8.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(181, 377);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(17, 19);
            lblTotalAmount.TabIndex = 15;
            lblTotalAmount.Text = "0";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Gcash" });
            cmbPaymentMethod.Location = new Point(181, 403);
            cmbPaymentMethod.Margin = new Padding(3, 2, 3, 2);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(161, 23);
            cmbPaymentMethod.TabIndex = 17;
            cmbPaymentMethod.SelectedIndexChanged += cmbPayment_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(60, 405);
            label9.Name = "label9";
            label9.Size = new Size(99, 15);
            label9.TabIndex = 18;
            label9.Text = "Payment Method";
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.BackColor = Color.Green;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmPayment.Location = new Point(107, 444);
            btnConfirmPayment.Margin = new Padding(3, 2, 3, 2);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(195, 29);
            btnConfirmPayment.TabIndex = 19;
            btnConfirmPayment.Text = "Confirm Payment";
            btnConfirmPayment.UseVisualStyleBackColor = false;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(131, 510);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 29);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel\r\n";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCarInfo
            // 
            lblCarInfo.AutoSize = true;
            lblCarInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCarInfo.Location = new Point(48, 16);
            lblCarInfo.Name = "lblCarInfo";
            lblCarInfo.Size = new Size(81, 21);
            lblCarInfo.TabIndex = 21;
            lblCarInfo.Text = "Full Name";
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlate.Location = new Point(48, 44);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(81, 21);
            lblPlate.TabIndex = 22;
            lblPlate.Text = "Full Name";
            // 
            // picQR
            // 
            picQR.Image = Properties.Resources.qr;
            picQR.Location = new Point(404, 91);
            picQR.Name = "picQR";
            picQR.Size = new Size(373, 382);
            picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            picQR.TabIndex = 23;
            picQR.TabStop = false;
            picQR.Visible = false;
            picQR.Click += picQR_Click;
            // 
            // btnGenerateReceipt
            // 
            btnGenerateReceipt.BackColor = Color.Green;
            btnGenerateReceipt.FlatStyle = FlatStyle.Flat;
            btnGenerateReceipt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateReceipt.Location = new Point(107, 477);
            btnGenerateReceipt.Margin = new Padding(3, 2, 3, 2);
            btnGenerateReceipt.Name = "btnGenerateReceipt";
            btnGenerateReceipt.Size = new Size(195, 29);
            btnGenerateReceipt.TabIndex = 24;
            btnGenerateReceipt.Text = "Generate Receipt";
            btnGenerateReceipt.UseVisualStyleBackColor = false;
            btnGenerateReceipt.Visible = false;
            btnGenerateReceipt.Click += btnGenerateReceipt_Click;
            // 
            // frmCheckout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(856, 569);
            Controls.Add(btnGenerateReceipt);
            Controls.Add(picQR);
            Controls.Add(lblPlate);
            Controls.Add(lblCarInfo);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmPayment);
            Controls.Add(label9);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label8);
            Controls.Add(lblTotalAmount);
            Controls.Add(label7);
            Controls.Add(lblTotalDays);
            Controls.Add(label6);
            Controls.Add(lblPricePerDay);
            Controls.Add(label1);
            Controls.Add(dtpEnd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpStart);
            Controls.Add(txtContactNumber);
            Controls.Add(txtLicense);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(v);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmCheckout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmCheckout";
            Load += frmCheckout_Load_1;
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label v;
        private Label label2;
        private Label label3;
        private TextBox txtFullName;
        private TextBox txtLicense;
        private TextBox txtContactNumber;
        private DateTimePicker dtpStart;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpEnd;
        private Label label1;
        private Label lblPricePerDay;
        private Label label6;
        private Label label7;
        private Label lblTotalDays;
        private Label label8;
        private Label lblTotalAmount;
        private ComboBox cmbPaymentMethod;
        private Label label9;
        private Button btnConfirmPayment;
        private Button btnCancel;
        private Label lblCarInfo;
        private Label lblPlate;
        private PictureBox picQR;
        private Button btnGenerateReceipt;
    }
}