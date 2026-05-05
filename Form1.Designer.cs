namespace VehicleRentalSystem
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panelContainer = new Panel();
            button3 = new Button();
            label4 = new Label();
            button2 = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Anchor = AnchorStyles.None;
            panelContainer.BackColor = Color.White;
            panelContainer.Controls.Add(button3);
            panelContainer.Controls.Add(label4);
            panelContainer.Controls.Add(button2);
            panelContainer.Controls.Add(txtPassword);
            panelContainer.Controls.Add(label3);
            panelContainer.Controls.Add(pictureBox2);
            panelContainer.Controls.Add(txtUsername);
            panelContainer.Controls.Add(label2);
            panelContainer.Controls.Add(label1);
            panelContainer.Controls.Add(button1);
            panelContainer.Controls.Add(pictureBox1);
            panelContainer.Location = new Point(134, 43);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1200, 650);
            panelContainer.TabIndex = 0;
            panelContainer.Paint += panelContainer_Paint;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(844, 533);
            button3.Name = "button3";
            button3.Size = new Size(120, 29);
            button3.TabIndex = 10;
            button3.Text = "Register Here";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(745, 537);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 9;
            label4.Text = "New Renter?";
            // 
            // button2
            // 
            button2.BackColor = Color.Maroon;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(774, 473);
            button2.Name = "button2";
            button2.Size = new Size(150, 40);
            button2.TabIndex = 8;
            button2.Text = "LOGIN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(668, 409);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(347, 27);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(668, 386);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(691, 66);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(273, 96);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(668, 334);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(347, 27);
            txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(668, 311);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(668, 175);
            label1.Name = "label1";
            label1.Size = new Size(324, 82);
            label1.TabIndex = 2;
            label1.Text = " Welcome back to \r\nVehicle Rental System";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(1143, 22);
            button1.Name = "button1";
            button1.Size = new Size(36, 29);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Red_and_Black_Modern_Car_Rental_Instagram_Post;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(503, 650);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1495, 746);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox2;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private Button button2;
        private Button button3;
        private Label label4;
    }
}
