using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VehicleRentalSystem
{
    public partial class ucSalesReport : UserControl
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Administrator\source\repos\VehicleRentalSystem\VehicleRental.accdb";

        public ucSalesReport()
        {
            InitializeComponent();

            // ensure combo contains wanted items and the event is wired in designer
            cmbFilter.Items.Clear();
            cmbFilter.Items.AddRange(new object[] { "Day", "Month", "Year" });

            // choose default after component init
            cmbFilter.SelectedIndex = 0;
        }

        private void ucSalesReport_Load(object sender, EventArgs e)
        {
            LoadChart("Day");
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem != null)
                LoadChart(cmbFilter.SelectedItem.ToString());
        }

        private void LoadChart(string filter)
        {
            // rebuild chart
            chartSales.Series.Clear();
            chartSales.ChartAreas.Clear();
            chartSales.Legends.Clear();
            chartSales.BackColor = Color.White;

            ChartArea ca = new ChartArea();
            ca.BackColor = Color.White;
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisX.Interval = 1;
            ca.AxisX.IsLabelAutoFit = false;
            ca.AxisX.LabelStyle.Angle = -30;
            ca.AxisX.LabelStyle.Font = new Font("Arial", 8);
            ca.AxisX.MajorTickMark.Enabled = true;
            ca.AxisX.IsMarginVisible = true;
            ca.AxisY.MajorGrid.LineColor = Color.LightGray;
            ca.AxisY.Minimum = 0;
            chartSales.ChartAreas.Add(ca);

            Series s = new Series("Sales");
            s.ChartType = SeriesChartType.Column;
            s.XValueType = ChartValueType.String;
            s["PointWidth"] = "0.7";
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Arial", 7, FontStyle.Bold);
            s.LabelForeColor = Color.Black;
            s.IsXValueIndexed = true; // index X values to keep spacing even for string labels
            chartSales.Series.Add(s);

            DataTable dt = new DataTable();
            string query = "";

            if (filter == "Day")
            {
                // Using Weekday(...,2) makes 1=Monday .. 7=Sunday
                query = "SELECT Weekday(RentalDate,2) AS DayNum, SUM(TotalAmount) AS Sales " +
                        "FROM Transactions WHERE RentalDate IS NOT NULL " +
                        "GROUP BY Weekday(RentalDate,2) ORDER BY Weekday(RentalDate,2)";

                dt = GetData(query);

                string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                var map = new Dictionary<int, double>();

                foreach (DataRow r in dt.Rows)
                {
                    if (r["DayNum"] == DBNull.Value) continue;
                    if (!int.TryParse(r["DayNum"].ToString(), out int key)) continue;

                    double val = ParseAmountToDouble(r["Sales"]);
                    map[key] = val;
                }

                // add all 7 day labels in order; use AddXY with string X to force categorical axis
                for (int i = 1; i <= 7; i++)
                {
                    double val = map.ContainsKey(i) ? map[i] : 0;
                    int idx = s.Points.AddXY(days[i - 1], val);
                    s.Points[idx].Color = val > 0 ? Color.SteelBlue : Color.LightGray;
                    if (val == 0) s.Points[idx].Label = "";
                }
            }
            else if (filter == "Month")
            {
                query = "SELECT Month(RentalDate) AS MonthNum, SUM(TotalAmount) AS Sales " +
                        "FROM Transactions WHERE RentalDate IS NOT NULL " +
                        "GROUP BY Month(RentalDate) ORDER BY Month(RentalDate)";

                dt = GetData(query);

                string[] months = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
                // AbbreviatedMonthNames returns 13 entries with last empty, ensure 12 used
                var monthLabels = new string[12];
                for (int i = 0; i < 12; i++) monthLabels[i] = months[i];

                var map = new Dictionary<int, double>();
                foreach (DataRow r in dt.Rows)
                {
                    if (r["MonthNum"] == DBNull.Value) continue;
                    if (!int.TryParse(r["MonthNum"].ToString(), out int key)) continue;
                    double val = ParseAmountToDouble(r["Sales"]);
                    map[key] = val;
                }

                for (int i = 1; i <= 12; i++)
                {
                    double val = map.ContainsKey(i) ? map[i] : 0;
                    int idx = s.Points.AddXY(monthLabels[i - 1], val);
                    s.Points[idx].Color = val > 0 ? Color.SteelBlue : Color.LightGray;
                    if (val == 0) s.Points[idx].Label = "";
                }
            }
            else if (filter == "Year")
            {
                query = "SELECT Year(RentalDate) AS YearNum, SUM(TotalAmount) AS Sales " +
                        "FROM Transactions WHERE RentalDate IS NOT NULL " +
                        "GROUP BY Year(RentalDate) ORDER BY Year(RentalDate)";

                dt = GetData(query);

                var map = new Dictionary<int, double>();
                foreach (DataRow r in dt.Rows)
                {
                    if (r["YearNum"] == DBNull.Value) continue;
                    if (!int.TryParse(r["YearNum"].ToString(), out int key)) continue;
                    double val = ParseAmountToDouble(r["Sales"]);
                    map[key] = val;
                }

                // show 2020..2030 inclusive
                for (int y = 2020; y <= 2030; y++)
                {
                    double val = map.ContainsKey(y) ? map[y] : 0;
                    int idx = s.Points.AddXY(y.ToString(), val);
                    s.Points[idx].Color = val > 0 ? Color.SteelBlue : Color.LightGray;
                    if (val == 0) s.Points[idx].Label = "";
                }
            }

            chartSales.Invalidate();
        }

        // safe data retrieval
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    conn.Open();
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dt;
        }

        // parse DB value to double, tolerates currency formatting and DBNull
        private double ParseAmountToDouble(object dbValue)
        {
            if (dbValue == null || dbValue == DBNull.Value) return 0;
            string s = dbValue.ToString();

            // If the field is numeric already (no currency symbols), TryParse directly
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double v1) ||
                double.TryParse(s, NumberStyles.Currency, CultureInfo.CurrentCulture, out v1))
            {
                return v1;
            }

            // Remove currency symbols, thousands separators but keep digits, dot, minus
            string cleaned = Regex.Replace(s, @"[^0-9\.\-]", "");
            if (double.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out double v2))
                return v2;

            return 0;
        }
    }
}