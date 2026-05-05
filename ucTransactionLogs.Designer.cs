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
            label2 = new Label();
            txtSearchLogs = new TextBox();
            dgvTransactions = new DataGridView();
            btnConfirmReturn = new Button();
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
            panel2.Name = "panel2";
            panel2.Size = new Size(1495, 64);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(318, 46);
            label1.TabIndex = 0;
            label1.Text = "Transaction History";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConfirmReturn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSearchLogs);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 58);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 19);
            label2.Name = "label2";
            label2.Size = new Size(175, 20);
            label2.TabIndex = 1;
            label2.Text = "Search by Renter or Plate";
            // 
            // txtSearchLogs
            // 
            txtSearchLogs.Location = new Point(214, 16);
            txtSearchLogs.Name = "txtSearchLogs";
            txtSearchLogs.Size = new Size(314, 27);
            txtSearchLogs.TabIndex = 0;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.Location = new Point(0, 122);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(1495, 554);
            dgvTransactions.TabIndex = 4;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            // 
            // btnConfirmReturn
            // 
            btnConfirmReturn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmReturn.FlatStyle = FlatStyle.Flat;
            btnConfirmReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmReturn.Location = new Point(1308, 6);
            btnConfirmReturn.Name = "btnConfirmReturn";
            btnConfirmReturn.Size = new Size(175, 39);
            btnConfirmReturn.TabIndex = 22;
            btnConfirmReturn.Text = "Confirm Return";
            btnConfirmReturn.UseVisualStyleBackColor = true;
            btnConfirmReturn.Click += btnConfirmReturn_Click;
            // 
            // ucTransactionLogs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTransactions);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucTransactionLogs";
            Size = new Size(1495, 676);
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
    }
}
