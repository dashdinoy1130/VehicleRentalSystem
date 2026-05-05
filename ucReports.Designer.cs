namespace VehicleRentalSystem
{
    partial class ucReports
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
            button1 = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            panel2 = new Panel();
            pnlFleet = new Panel();
            lblTotalFleet = new Label();
            label7 = new Label();
            pnlActive = new Panel();
            lblActiveCount = new Label();
            label5 = new Label();
            panel3 = new Panel();
            pnlRevenue = new Panel();
            lblTotalRevenue = new Label();
            label2 = new Label();
            panel4 = new Panel();
            label8 = new Label();
            dgvReportsDetailed = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlFleet.SuspendLayout();
            pnlActive.SuspendLayout();
            panel3.SuspendLayout();
            pnlRevenue.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportsDetailed).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 64);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1303, 10);
            button1.Name = "button1";
            button1.Size = new Size(175, 39);
            button1.TabIndex = 22;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(2612, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(175, 39);
            btnRefresh.TabIndex = 21;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(346, 46);
            label1.TabIndex = 0;
            label1.Text = "Performance Reports";
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlFleet);
            panel2.Controls.Add(pnlActive);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(1495, 213);
            panel2.TabIndex = 5;
            // 
            // pnlFleet
            // 
            pnlFleet.Controls.Add(lblTotalFleet);
            pnlFleet.Controls.Add(label7);
            pnlFleet.Dock = DockStyle.Fill;
            pnlFleet.Location = new Point(998, 0);
            pnlFleet.Name = "pnlFleet";
            pnlFleet.Size = new Size(497, 213);
            pnlFleet.TabIndex = 2;
            // 
            // lblTotalFleet
            // 
            lblTotalFleet.AutoSize = true;
            lblTotalFleet.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFleet.Location = new Point(250, 139);
            lblTotalFleet.Name = "lblTotalFleet";
            lblTotalFleet.Size = new Size(46, 54);
            lblTotalFleet.TabIndex = 4;
            lblTotalFleet.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(165, 33);
            label7.Name = "label7";
            label7.Size = new Size(218, 92);
            label7.TabIndex = 3;
            label7.Text = "TOTAL FLEET\r\n(Inventory)";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlActive
            // 
            pnlActive.Controls.Add(lblActiveCount);
            pnlActive.Controls.Add(label5);
            pnlActive.Dock = DockStyle.Left;
            pnlActive.Location = new Point(499, 0);
            pnlActive.Name = "pnlActive";
            pnlActive.Size = new Size(499, 213);
            pnlActive.TabIndex = 1;
            // 
            // lblActiveCount
            // 
            lblActiveCount.AutoSize = true;
            lblActiveCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveCount.Location = new Point(221, 139);
            lblActiveCount.Name = "lblActiveCount";
            lblActiveCount.Size = new Size(46, 54);
            lblActiveCount.TabIndex = 4;
            lblActiveCount.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(101, 33);
            label5.Name = "label5";
            label5.Size = new Size(292, 92);
            label5.TabIndex = 3;
            label5.Text = " ACTIVE RENTALS\r\n(Current)";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(pnlRevenue);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(499, 213);
            panel3.TabIndex = 0;
            // 
            // pnlRevenue
            // 
            pnlRevenue.Controls.Add(lblTotalRevenue);
            pnlRevenue.Controls.Add(label2);
            pnlRevenue.Dock = DockStyle.Left;
            pnlRevenue.Location = new Point(0, 0);
            pnlRevenue.Name = "pnlRevenue";
            pnlRevenue.Size = new Size(499, 213);
            pnlRevenue.TabIndex = 1;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.Location = new Point(135, 139);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(46, 54);
            lblTotalRevenue.TabIndex = 2;
            lblTotalRevenue.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 33);
            label2.Name = "label2";
            label2.Size = new Size(381, 92);
            label2.TabIndex = 1;
            label2.Text = " TOTAL REVENUE (PHP)\r\n(Completed)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 277);
            panel4.Name = "panel4";
            panel4.Size = new Size(1495, 52);
            panel4.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 3);
            label8.Name = "label8";
            label8.Size = new Size(580, 38);
            label8.TabIndex = 1;
            label8.Text = "DETAILED TRANSACTION LOGS (RECENT 20)\r\n";
            // 
            // dgvReportsDetailed
            // 
            dgvReportsDetailed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportsDetailed.Dock = DockStyle.Fill;
            dgvReportsDetailed.Location = new Point(0, 329);
            dgvReportsDetailed.Name = "dgvReportsDetailed";
            dgvReportsDetailed.RowHeadersWidth = 51;
            dgvReportsDetailed.Size = new Size(1495, 347);
            dgvReportsDetailed.TabIndex = 7;
            dgvReportsDetailed.CellContentClick += dgvReportsDetailed_CellContentClick;
            // 
            // ucReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvReportsDetailed);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucReports";
            Size = new Size(1495, 676);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            pnlFleet.ResumeLayout(false);
            pnlFleet.PerformLayout();
            pnlActive.ResumeLayout(false);
            pnlActive.PerformLayout();
            panel3.ResumeLayout(false);
            pnlRevenue.ResumeLayout(false);
            pnlRevenue.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportsDetailed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRefresh;
        private Label label1;
        private Panel panel2;
        private Panel pnlFleet;
        private Panel pnlActive;
        private Panel panel3;
        private Panel pnlRevenue;
        private Label lblTotalFleet;
        private Label label7;
        private Label lblActiveCount;
        private Label label5;
        private Label lblTotalRevenue;
        private Label label2;
        private Panel panel4;
        private Label label8;
        private DataGridView dgvReportsDetailed;
        private Button button1;
    }
}
