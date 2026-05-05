namespace VehicleRentalSystem
{
    partial class ucRenterBooking
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            flpVehicles = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1495, 75);
            panel1.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.None;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(1081, 34);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(53, 20);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.None;
            txtSearch.Location = new Point(1140, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(342, 27);
            txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(209, 38);
            label1.TabIndex = 0;
            label1.Text = "Available Fleet";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // flpVehicles
            // 
            flpVehicles.AutoScroll = true;
            flpVehicles.Dock = DockStyle.Fill;
            flpVehicles.Location = new Point(0, 75);
            flpVehicles.Name = "flpVehicles";
            flpVehicles.Padding = new Padding(20);
            flpVehicles.Size = new Size(1495, 601);
            flpVehicles.TabIndex = 2;
            flpVehicles.Paint += flowLayoutPanel1_Paint;
            // 
            // ucRenterBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpVehicles);
            Controls.Add(panel1);
            Name = "ucRenterBooking";
            Size = new Size(1495, 676);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSearch;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblSearch;
        private FlowLayoutPanel flpVehicles;
    }
}
