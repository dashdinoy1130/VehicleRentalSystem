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
            cmbPayment = new ComboBox();
            label9 = new Label();
            btnConfirmPayment = new Button();
            btnCancel = new Button();
            lblCarInfo = new Label();
            lblPlate = new Label();
            SuspendLayout();
            // 
            // v
            // 
            v.AutoSize = true;
            v.Location = new Point(68, 166);
            v.Name = "v";
            v.Size = new Size(76, 20);
            v.TabIndex = 0;
            v.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 226);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 1;
            label2.Text = "License Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 293);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 2;
            label3.Text = "Contact No.";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(68, 189);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(322, 27);
            txtFullName.TabIndex = 3;
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(68, 249);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(322, 27);
            txtLicense.TabIndex = 4;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(68, 316);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(322, 27);
            txtContactNumber.TabIndex = 5;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(68, 388);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(142, 27);
            dtpStart.TabIndex = 6;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 365);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 7;
            label4.Text = "Date Start";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(253, 365);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 8;
            label5.Text = "Date End";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(253, 388);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(137, 27);
            dtpEnd.TabIndex = 9;
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(84, 95);
            label1.Name = "label1";
            label1.Size = new Size(276, 46);
            label1.TabIndex = 10;
            label1.Text = "Check Out Form";
            // 
            // lblPricePerDay
            // 
            lblPricePerDay.AutoSize = true;
            lblPricePerDay.Location = new Point(175, 440);
            lblPricePerDay.Name = "lblPricePerDay";
            lblPricePerDay.Size = new Size(17, 20);
            lblPricePerDay.TabIndex = 11;
            lblPricePerDay.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 440);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 12;
            label6.Text = "Price Per Day:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(68, 472);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 14;
            label7.Text = "Total Days:";
            // 
            // lblTotalDays
            // 
            lblTotalDays.AutoSize = true;
            lblTotalDays.Location = new Point(175, 472);
            lblTotalDays.Name = "lblTotalDays";
            lblTotalDays.Size = new Size(17, 20);
            lblTotalDays.TabIndex = 13;
            lblTotalDays.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(68, 501);
            label8.Name = "label8";
            label8.Size = new Size(133, 25);
            label8.TabIndex = 16;
            label8.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(207, 503);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(20, 23);
            lblTotalAmount.TabIndex = 15;
            lblTotalAmount.Text = "0";
            // 
            // cmbPayment
            // 
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Items.AddRange(new object[] { "Cash", "Gcash" });
            cmbPayment.Location = new Point(207, 537);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(183, 28);
            cmbPayment.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(68, 540);
            label9.Name = "label9";
            label9.Size = new Size(121, 20);
            label9.TabIndex = 18;
            label9.Text = "Payment Method";
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.BackColor = Color.Green;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmPayment.Location = new Point(122, 592);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(223, 39);
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
            btnCancel.Location = new Point(148, 637);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 39);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel\r\n";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCarInfo
            // 
            lblCarInfo.AutoSize = true;
            lblCarInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCarInfo.Location = new Point(55, 21);
            lblCarInfo.Name = "lblCarInfo";
            lblCarInfo.Size = new Size(100, 28);
            lblCarInfo.TabIndex = 21;
            lblCarInfo.Text = "Full Name";
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlate.Location = new Point(55, 58);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(100, 28);
            lblPlate.TabIndex = 22;
            lblPlate.Text = "Full Name";
            // 
            // frmCheckout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(482, 703);
            Controls.Add(lblPlate);
            Controls.Add(lblCarInfo);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmPayment);
            Controls.Add(label9);
            Controls.Add(cmbPayment);
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
            Name = "frmCheckout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmCheckout";
            Load += frmCheckout_Load_1;
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
        private ComboBox cmbPayment;
        private Label label9;
        private Button btnConfirmPayment;
        private Button btnCancel;
        private Label lblCarInfo;
        private Label lblPlate;
    }
}