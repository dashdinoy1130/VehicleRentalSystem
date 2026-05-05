namespace VehicleRentalSystem
{
    partial class frmDashboard
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
            pnlNavBar = new Panel();
            pictureBox1 = new PictureBox();
            btnDashboard = new Button();
            btnRentals = new Button();
            btnReports = new Button();
            btnLogout = new Button();
            btnManageFleet = new Button();
            pnlMainContent = new Panel();
            pnlNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlNavBar
            // 
            pnlNavBar.BackColor = Color.White;
            pnlNavBar.Controls.Add(pictureBox1);
            pnlNavBar.Controls.Add(btnDashboard);
            pnlNavBar.Controls.Add(btnRentals);
            pnlNavBar.Controls.Add(btnReports);
            pnlNavBar.Controls.Add(btnLogout);
            pnlNavBar.Controls.Add(btnManageFleet);
            pnlNavBar.Dock = DockStyle.Top;
            pnlNavBar.Location = new Point(0, 0);
            pnlNavBar.Margin = new Padding(3, 2, 3, 2);
            pnlNavBar.Name = "pnlNavBar";
            pnlNavBar.Size = new Size(1213, 52);
            pnlNavBar.TabIndex = 0;
            pnlNavBar.Paint += pnlNavBar_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Untitled_design__6_1;
            pictureBox1.Location = new Point(10, 4);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnDashboard
            // 
            btnDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.Location = new Point(560, 9);
            btnDashboard.Margin = new Padding(3, 2, 3, 2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(124, 36);
            btnDashboard.TabIndex = 8;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnRentals
            // 
            btnRentals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRentals.Location = new Point(819, 9);
            btnRentals.Margin = new Padding(3, 2, 3, 2);
            btnRentals.Name = "btnRentals";
            btnRentals.Size = new Size(124, 36);
            btnRentals.TabIndex = 7;
            btnRentals.Text = "Transaction Logs";
            btnRentals.UseVisualStyleBackColor = true;
            btnRentals.Click += btnRentals_Click;
            // 
            // btnReports
            // 
            btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.Location = new Point(949, 9);
            btnReports.Margin = new Padding(3, 2, 3, 2);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(124, 36);
            btnReports.TabIndex = 6;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1078, 9);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(124, 36);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout\r\n";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageFleet
            // 
            btnManageFleet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManageFleet.FlatStyle = FlatStyle.Flat;
            btnManageFleet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageFleet.Location = new Point(690, 9);
            btnManageFleet.Margin = new Padding(3, 2, 3, 2);
            btnManageFleet.Name = "btnManageFleet";
            btnManageFleet.Size = new Size(124, 36);
            btnManageFleet.TabIndex = 4;
            btnManageFleet.Text = "Manage Fleet";
            btnManageFleet.UseVisualStyleBackColor = true;
            btnManageFleet.Click += btnManageFleet_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 52);
            pnlMainContent.Margin = new Padding(3, 2, 3, 2);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1213, 508);
            pnlMainContent.TabIndex = 1;
            pnlMainContent.Paint += pnlMainContent_Paint;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 560);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlNavBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmContainer";
            WindowState = FormWindowState.Maximized;
            Load += frmDashboard_Load;
            pnlNavBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNavBar;
        private Button btnRentals;
        private Button btnReports;
        private Button btnLogout;
        private Button btnManageFleet;
        private PictureBox pictureBox1;
        private Button btnDashboard;
        private Panel pnlMainContent;
    }
}