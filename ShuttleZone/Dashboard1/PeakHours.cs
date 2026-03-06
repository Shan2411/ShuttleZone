using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Series salesSeries = new Series("Peak Hours:");
            salesSeries.ChartType = SeriesChartType.Line;
            salesSeries.BorderWidth = 3;
            salesSeries["LineTension"] = "0.4";

            salesSeries.Points.AddXY("9 AM", 1200);
            salesSeries.Points.AddXY("12 PM", 3200);
            salesSeries.Points.AddXY("3 PM", 2800);
            salesSeries.Points.AddXY("6 PM", 5400);
            salesSeries.Points.AddXY("9 PM", 4300);

            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Sales (₱)";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            chart1.Series.Add(salesSeries);
        }
    }
}
