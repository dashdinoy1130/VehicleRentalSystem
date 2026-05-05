namespace VehicleRentalSystem
{
    partial class frmRenterDashboard
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
            label1 = new Label();
            btnMyRentals = new Button();
            pictureBox1 = new PictureBox();
            btnLogout1 = new Button();
            btnBrowseCars = new Button();
            pnlRenterContent = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(207, 12);
            label1.Name = "label1";
            label1.Size = new Size(222, 46);
            label1.TabIndex = 14;
            label1.Text = "Renter Portal";
            // 
            // btnMyRentals
            // 
            btnMyRentals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMyRentals.FlatStyle = FlatStyle.Flat;
            btnMyRentals.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMyRentals.Location = new Point(1182, 12);
            btnMyRentals.Name = "btnMyRentals";
            btnMyRentals.Size = new Size(142, 48);
            btnMyRentals.TabIndex = 13;
            btnMyRentals.Text = "My Rentals";
            btnMyRentals.UseVisualStyleBackColor = true;
            btnMyRentals.Click += btnMyRentals_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Untitled_design__6_1;
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(189, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnLogout1
            // 
            btnLogout1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout1.FlatStyle = FlatStyle.Flat;
            btnLogout1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout1.Location = new Point(1330, 12);
            btnLogout1.Name = "btnLogout1";
            btnLogout1.Size = new Size(142, 48);
            btnLogout1.TabIndex = 11;
            btnLogout1.Text = "Logout\r\n";
            btnLogout1.UseVisualStyleBackColor = true;
            btnLogout1.Click += btnLogout1_Click;
            // 
            // btnBrowseCars
            // 
            btnBrowseCars.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseCars.FlatStyle = FlatStyle.Flat;
            btnBrowseCars.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseCars.Location = new Point(1034, 12);
            btnBrowseCars.Name = "btnBrowseCars";
            btnBrowseCars.Size = new Size(142, 48);
            btnBrowseCars.TabIndex = 10;
            btnBrowseCars.Text = "Browse Cars";
            btnBrowseCars.UseVisualStyleBackColor = true;
            btnBrowseCars.Click += btnBrowseCars_Click;
            // 
            // pnlRenterContent
            // 
            pnlRenterContent.Dock = DockStyle.Fill;
            pnlRenterContent.Location = new Point(0, 0);
            pnlRenterContent.Name = "pnlRenterContent";
            pnlRenterContent.Size = new Size(1495, 746);
            pnlRenterContent.TabIndex = 2;
            pnlRenterContent.Paint += pnlRenterContent_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnMyRentals);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnLogout1);
            panel1.Controls.Add(btnBrowseCars);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 71);
            panel1.TabIndex = 15;
            // 
            // frmRenterDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1495, 746);
            Controls.Add(panel1);
            Controls.Add(pnlRenterContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRenterDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRenterDashboard";
            WindowState = FormWindowState.Maximized;
            Shown += frmRenterDashboard_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button btnMyRentals;
        private Button btnLogout1;
        private Button btnBrowseCars;
        private Label label1;
        private Panel pnlRenterContent;
        private Panel panel1;
    }
}