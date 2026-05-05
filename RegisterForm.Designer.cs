namespace VehicleRentalSystem
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 107);
            label1.Name = "label1";
            label1.Size = new Size(227, 41);
            label1.TabIndex = 1;
            label1.Text = "Create account";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(265, 248);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(164, 27);
            txtUsername.TabIndex = 6;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 225);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(43, 248);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(164, 27);
            txtFullName.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 225);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 7;
            label3.Text = "Full Name";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(43, 325);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(386, 27);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 302);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 9;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(108, 158);
            label5.Name = "label5";
            label5.Size = new Size(242, 20);
            label5.TabIndex = 11;
            label5.Text = "fill in the form to create an account\r\n";
            // 
            // button1
            // 
            button1.Location = new Point(110, 418);
            button1.Name = "button1";
            button1.Size = new Size(240, 41);
            button1.TabIndex = 12;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(466, 532);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtFullName;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}