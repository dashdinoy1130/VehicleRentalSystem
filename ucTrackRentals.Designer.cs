namespace VehicleRentalSystem
{
    partial class ucTrackRentals
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
            label1 = new Label();
            label2 = new Label();
            cmbStatusFilter = new ComboBox();
            label3 = new Label();
            txtTrackSearch = new TextBox();
            btnRefresh = new Button();
            btnLogReturn = new Button();
            dgvTracking = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTracking).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F);
            label1.Location = new Point(32, 27);
            label1.Name = "label1";
            label1.Size = new Size(292, 30);
            label1.TabIndex = 0;
            label1.Text = "RENTAL VEHICLE TRACKING";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 95);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 1;
            label2.Text = "Filter by Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All Active", "Ongoing", "Overdue", "Pending Cleanup" });
            cmbStatusFilter.Location = new Point(161, 92);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(183, 23);
            cmbStatusFilter.TabIndex = 2;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 159);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 3;
            label3.Text = "Search Plate/Customer:";
            // 
            // txtTrackSearch
            // 
            txtTrackSearch.Location = new Point(184, 156);
            txtTrackSearch.Name = "txtTrackSearch";
            txtTrackSearch.Size = new Size(173, 23);
            txtTrackSearch.TabIndex = 4;
            txtTrackSearch.TextChanged += txtTrackSearch_TextChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.LimeGreen;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(584, 98);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(111, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogReturn
            // 
            btnLogReturn.BackColor = Color.Gold;
            btnLogReturn.FlatStyle = FlatStyle.Flat;
            btnLogReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogReturn.Location = new Point(720, 98);
            btnLogReturn.Name = "btnLogReturn";
            btnLogReturn.Size = new Size(111, 40);
            btnLogReturn.TabIndex = 6;
            btnLogReturn.Text = "Log Return";
            btnLogReturn.UseVisualStyleBackColor = false;
            btnLogReturn.Click += btnLogReturn_Click;
            // 
            // dgvTracking
            // 
            dgvTracking.AllowUserToAddRows = false;
            dgvTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTracking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTracking.Dock = DockStyle.Bottom;
            dgvTracking.Location = new Point(0, 185);
            dgvTracking.Name = "dgvTracking";
            dgvTracking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTracking.Size = new Size(1308, 322);
            dgvTracking.TabIndex = 8;
            // 
            // ucTrackRentals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTracking);
            Controls.Add(btnLogReturn);
            Controls.Add(btnRefresh);
            Controls.Add(txtTrackSearch);
            Controls.Add(label3);
            Controls.Add(cmbStatusFilter);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucTrackRentals";
            Size = new Size(1308, 507);
            Load += ucTrackRentals_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTracking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbStatusFilter;
        private Label label3;
        private TextBox txtTrackSearch;
        private Button btnRefresh;
        private Button btnLogReturn;
        private DataGridView dgvTracking;
    }
}
