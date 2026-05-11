namespace VehicleRentalSystem
{
    partial class frmReceipt
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
            pnlPaper = new Panel();
            btnPrint = new Button();
            lblTotal = new Label();
            lblItems = new Label();
            lblDate = new Label();
            lblHeader = new Label();
            pnlPaper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaper
            // 
            pnlPaper.Controls.Add(btnPrint);
            pnlPaper.Controls.Add(lblTotal);
            pnlPaper.Controls.Add(lblItems);
            pnlPaper.Controls.Add(lblDate);
            pnlPaper.Controls.Add(lblHeader);
            pnlPaper.Dock = DockStyle.Fill;
            pnlPaper.Location = new Point(0, 0);
            pnlPaper.Name = "pnlPaper";
            pnlPaper.Size = new Size(454, 561);
            pnlPaper.TabIndex = 0;
            pnlPaper.Paint += pnlPaper_Paint;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(131, 473);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(169, 36);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Print Receipt";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(54, 269);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(113, 25);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItems.Location = new Point(54, 215);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(75, 25);
            lblItems.TabIndex = 2;
            lblItems.Text = "Items...";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(54, 149);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(183, 30);
            lblDate.TabIndex = 1;
            lblDate.Text = "Date: 00/00/0000";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(131, 43);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(202, 21);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "VEHICLE RENTAL SYSTEM";
            // 
            // frmReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(454, 561);
            Controls.Add(pnlPaper);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmReceipt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmReceipt";
            pnlPaper.ResumeLayout(false);
            pnlPaper.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaper;
        internal Button btnPrint;
        private Label lblTotal;
        private Label lblItems;
        private Label lblDate;
        private Label lblHeader;
    }
}