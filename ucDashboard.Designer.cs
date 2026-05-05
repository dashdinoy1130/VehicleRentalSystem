namespace VehicleRentalSystem
{
    partial class ucDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel2 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            panel5 = new Panel();
            lblMaintenance = new Label();
            label4 = new Label();
            panel4 = new Panel();
            lblActiveRentals = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTotalFleet = new Label();
            label2 = new Label();
            panel6 = new Panel();
            chartFleetStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel7 = new Panel();
            dgvRecentActivity = new DataGridView();
            panel8 = new Panel();
            label5 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartFleetStatus).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentActivity).BeginInit();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1495, 64);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(188, 46);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 188);
            panel1.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = SystemColors.ControlDarkDark;
            panel5.Controls.Add(lblMaintenance);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1014, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(481, 188);
            panel5.TabIndex = 2;
            // 
            // lblMaintenance
            // 
            lblMaintenance.AutoSize = true;
            lblMaintenance.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaintenance.Location = new Point(22, 67);
            lblMaintenance.Name = "lblMaintenance";
            lblMaintenance.Size = new Size(54, 62);
            lblMaintenance.TabIndex = 4;
            lblMaintenance.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 10);
            label4.Name = "label4";
            label4.Size = new Size(220, 46);
            label4.TabIndex = 3;
            label4.Text = "Maintenance";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Controls.Add(lblActiveRentals);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(507, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(507, 188);
            panel4.TabIndex = 1;
            // 
            // lblActiveRentals
            // 
            lblActiveRentals.AutoSize = true;
            lblActiveRentals.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveRentals.Location = new Point(13, 67);
            lblActiveRentals.Name = "lblActiveRentals";
            lblActiveRentals.Size = new Size(54, 62);
            lblActiveRentals.TabIndex = 3;
            lblActiveRentals.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 10);
            label3.Name = "label3";
            label3.Size = new Size(236, 46);
            label3.TabIndex = 2;
            label3.Text = "Active Rentals";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(lblTotalFleet);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(507, 188);
            panel3.TabIndex = 0;
            // 
            // lblTotalFleet
            // 
            lblTotalFleet.AutoSize = true;
            lblTotalFleet.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFleet.Location = new Point(23, 67);
            lblTotalFleet.Name = "lblTotalFleet";
            lblTotalFleet.Size = new Size(54, 62);
            lblTotalFleet.TabIndex = 2;
            lblTotalFleet.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 10);
            label2.Name = "label2";
            label2.Size = new Size(178, 46);
            label2.TabIndex = 1;
            label2.Text = "Total Fleet";
            label2.Click += label2_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(chartFleetStatus);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 252);
            panel6.Name = "panel6";
            panel6.Size = new Size(964, 424);
            panel6.TabIndex = 5;
            panel6.Paint += panel6_Paint;
            // 
            // chartFleetStatus
            // 
            chartArea1.Name = "ChartArea1";
            chartFleetStatus.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartFleetStatus.Legends.Add(legend1);
            chartFleetStatus.Location = new Point(93, 64);
            chartFleetStatus.Name = "chartFleetStatus";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartFleetStatus.Series.Add(series1);
            chartFleetStatus.Size = new Size(704, 390);
            chartFleetStatus.TabIndex = 0;
            chartFleetStatus.Text = "chart1";
            // 
            // panel7
            // 
            panel7.Controls.Add(dgvRecentActivity);
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(964, 252);
            panel7.Name = "panel7";
            panel7.Size = new Size(531, 424);
            panel7.TabIndex = 6;
            // 
            // dgvRecentActivity
            // 
            dgvRecentActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentActivity.Dock = DockStyle.Fill;
            dgvRecentActivity.Location = new Point(0, 46);
            dgvRecentActivity.Name = "dgvRecentActivity";
            dgvRecentActivity.RowHeadersWidth = 51;
            dgvRecentActivity.Size = new Size(531, 378);
            dgvRecentActivity.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(label5);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(531, 46);
            panel8.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 3);
            label5.Name = "label5";
            label5.Size = new Size(266, 38);
            label5.TabIndex = 1;
            label5.Text = "Recent Transactions";
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ucDashboard";
            Size = new Size(1495, 676);
            Load += ucDashboard_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartFleetStatus).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentActivity).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private Label label2;
        private Label lblMaintenance;
        private Label label4;
        private Label lblActiveRentals;
        private Label label3;
        private Label lblTotalFleet;
        private Panel panel6;
        private Panel panel7;
        private DataGridView dgvRecentActivity;
        private Panel panel8;
        private Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFleetStatus;
    }
}
