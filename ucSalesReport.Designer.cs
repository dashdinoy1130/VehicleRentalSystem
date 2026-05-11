namespace VehicleRentalSystem
{
    partial class ucSalesReport
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
            chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cmbFilter = new ComboBox();
            label2 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSales).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1308, 48);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(169, 37);
            label1.TabIndex = 0;
            label1.Text = "Sales Report";
            // 
            // chartSales
            // 
            chartSales.BackColor = Color.Transparent;
            chartSales.BorderlineColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartSales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartSales.Legends.Add(legend1);
            chartSales.Location = new Point(182, 152);
            chartSales.Name = "chartSales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSales.Series.Add(series1);
            chartSales.Size = new Size(1060, 355);
            chartSales.TabIndex = 4;
            chartSales.Text = "chart1";
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(253, 60);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(154, 29);
            cmbFilter.TabIndex = 5;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 60);
            label2.Name = "label2";
            label2.Size = new Size(244, 29);
            label2.TabIndex = 9;
            label2.Text = "Select Day | Month | Year: ";
            // 
            // ucSalesReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(cmbFilter);
            Controls.Add(chartSales);
            Controls.Add(panel2);
            Name = "ucSalesReport";
            Size = new Size(1308, 507);
            Load += ucSalesReport_Load_1;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private ComboBox cmbFilter;
        private Label label2;
    }
}
