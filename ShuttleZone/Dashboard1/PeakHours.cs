using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShuttleZone.Dashboard1
{
    public partial class PeakHours : UserControl
    {
        public PeakHours()
        {
            InitializeComponent();
            LoadSalesChart();
        }

        private void LoadSalesChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            Series salesSeries = new Series("Peak Hours:");
            salesSeries.ChartType = SeriesChartType.Line;
            salesSeries.BorderWidth = 3;
            salesSeries["LineTension"] = "0.4";
            salesSeries.IsValueShownAsLabel = true;
            salesSeries.LabelFormat = "₱#,##0.00";
            salesSeries.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            salesSeries.LabelForeColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // Fetch sorted hourly revenue from DB
            SortedDictionary<int, decimal> hourlyData = GetHourlyRevenue();

            // Define the hour range you want to display (6 AM to 11 PM)
            for (int h = 8; h <= 17; h++)
            {
                string label = DateTime.Today.AddHours(h).ToString("h tt");
                decimal revenue = hourlyData.ContainsKey(h) ? hourlyData[h] : 0;
                salesSeries.Points.AddXY(label, revenue);
            }

            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Sales (₱)";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            chart1.Series.Add(salesSeries);
        }

        private SortedDictionary<int, decimal> GetHourlyRevenue()
        {
            var result = new SortedDictionary<int, decimal>();

            string query = @"
                SELECT 
                    HOUR(transaction_time) AS hour,
                    SUM(total_amount) AS revenue
                FROM transactions
                WHERE DATE(transaction_date) = CURDATE()
                GROUP BY HOUR(transaction_time)
                ORDER BY hour ASC";

            try
            {
                using (MySqlConnection conn = DBconnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int hour = reader.GetInt32("hour");
                            decimal revenue = reader.GetDecimal("revenue");
                            result[hour] = revenue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
    }
}