namespace VehicleRentalSystem
{
    partial class ucTransactionLogs
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
            panel2 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            cmbStatusFilter = new ComboBox();
            btnConfirmPayment = new Button();
            btnConfirmReturn = new Button();
            label2 = new Label();
            txtSearchLogs = new TextBox();
            dgvTransactions = new DataGridView();
            btnDeleteLog = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1308, 48);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(255, 37);
            label1.TabIndex = 0;
            label1.Text = "Transaction History";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteLog);
            panel1.Controls.Add(cmbStatusFilter);
            panel1.Controls.Add(btnConfirmPayment);
            panel1.Controls.Add(btnConfirmReturn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearchLogs);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 48);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1308, 44);
            panel1.TabIndex = 3;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(538, 11);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(161, 23);
            cmbStatusFilter.TabIndex = 24;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmPayment.BackColor = SystemColors.ActiveCaption;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmPayment.Location = new Point(985, 4);
            btnConfirmPayment.Margin = new Padding(3, 2, 3, 2);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(153, 29);
            btnConfirmPayment.TabIndex = 23;
            btnConfirmPayment.Text = "Confirm Payment";
            btnConfirmPayment.UseVisualStyleBackColor = false;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            // 
            // btnConfirmReturn
            // 
            btnConfirmReturn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmReturn.BackColor = SystemColors.ActiveCaption;
            btnConfirmReturn.FlatStyle = FlatStyle.Flat;
            btnConfirmReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmReturn.Location = new Point(1144, 4);
            btnConfirmReturn.Margin = new Padding(3, 2, 3, 2);
            btnConfirmReturn.Name = "btnConfirmReturn";
            btnConfirmReturn.Size = new Size(153, 29);
            btnConfirmReturn.TabIndex = 22;
            btnConfirmReturn.Text = "Confirm Return";
            btnConfirmReturn.UseVisualStyleBackColor = false;
            btnConfirmReturn.Click += btnConfirmReturn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 14);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 1;
            label2.Text = "Search by Renter or Plate";
            // 
            // txtSearchLogs
            // 
            txtSearchLogs.Location = new Point(187, 12);
            txtSearchLogs.Margin = new Padding(3, 2, 3, 2);
            txtSearchLogs.Name = "txtSearchLogs";
            txtSearchLogs.Size = new Size(275, 23);
            txtSearchLogs.TabIndex = 0;
            txtSearchLogs.TextChanged += txtSearchLogs_TextChanged_1;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.Location = new Point(0, 92);
            dgvTransactions.Margin = new Padding(3, 2, 3, 2);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(1308, 415);
            dgvTransactions.TabIndex = 4;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            // 
            // btnDeleteLog
            // 
            btnDeleteLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteLog.BackColor = Color.IndianRed;
            btnDeleteLog.FlatStyle = FlatStyle.Flat;
            btnDeleteLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteLog.Location = new Point(862, 5);
            btnDeleteLog.Margin = new Padding(3, 2, 3, 2);
            btnDeleteLog.Name = "btnDeleteLog";
            btnDeleteLog.Size = new Size(117, 29);
            btnDeleteLog.TabIndex = 25;
            btnDeleteLog.Text = "Delete Log";
            btnDeleteLog.UseVisualStyleBackColor = false;
            btnDeleteLog.Click += btnDeleteLog_Click;
            // 
            // ucTransactionLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTransactions);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucTransactionLogs";
            Size = new Size(1308, 507);
            Load += ucTransactionLogs_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox txtSearchLogs;
        private DataGridView dgvTransactions;
        private Button btnConfirmReturn;
        private Button btnConfirmPayment;
        private ComboBox cmbStatusFilter;
        private Button btnDeleteLog;
    }
}
