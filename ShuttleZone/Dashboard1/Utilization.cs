using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuttleZone.database;
using MySql.Data.MySqlClient;

namespace ShuttleZone.Dashboard1
{
    public partial class Utilization : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private static readonly Color[] CourtColors = new[]
        {
            Color.FromArgb(94, 148, 255),   // Court A - Blue
            Color.FromArgb(46, 204, 113),   // Court B - Green
            Color.FromArgb(155, 89, 182),   // Court C - Purple
            Color.FromArgb(230, 126, 34),   // Court D - Orange
        };

        public Utilization()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            EnableDoubleBuffer(flowLayoutPanel1);
            LoadUtilizationData();
        }

        public void LoadUtilizationData()
        {
            var data = FetchCourtIncomeFromDB();
            if (data == null || data.Count == 0) return;

            // Find the busiest court (highest total_amount this month)
            decimal maxIncome = data.Max(d => d.TotalAmount);

            // Progress bar = busiest court's % share of total income
            decimal totalIncome = data.Sum(d => d.TotalAmount);
            int progressValue = totalIncome > 0
                ? (int)Math.Round((maxIncome / totalIncome) * 100)
                : 0;

            // Update the circle progress bar
            guna2CircleProgressBar1.Value = Math.Min(progressValue, 100);

            // Find busiest court name for the center label (if you have one)
            var busiestCourt = data.OrderByDescending(d => d.TotalAmount).First();

            // Update center label if you have a label inside the progress bar
            // label8.Text = $"{busiestCourt.CourtName}\n{progressValue}%";

            // Rebuild the flow panel labels
            SendMessage(flowLayoutPanel1.Handle, WM_SETREDRAW, false, 0);
            try
            {
                flowLayoutPanel1.SuspendLayout();
                flowLayoutPanel1.Controls.Clear();

                for (int i = 0; i < data.Count; i++)
                {
                    var court = data[i];
                    Color accent = i < CourtColors.Length
                        ? CourtColors[i]
                        : Color.FromArgb(127, 140, 141);

                    // Each court's % of total income this month
                    int sharePercent = totalIncome > 0
                        ? (int)Math.Round((court.TotalAmount / totalIncome) * 100)
                        : 0;

                    bool isBusiest = court.CourtName == busiestCourt.CourtName;

                    AddCourtLabel(
                        court.CourtName,
                        court.TotalAmount,
                        sharePercent,
                        accent,
                        isBusiest
                    );
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(true);
                SendMessage(flowLayoutPanel1.Handle, WM_SETREDRAW, true, 0);
                flowLayoutPanel1.Refresh();
            }
        }

        // ── DB FETCH ──────────────────────────────────────────────────────────

        private class CourtIncomeData
        {
            public string CourtName { get; set; }
            public decimal TotalAmount { get; set; }
        }

        private List<CourtIncomeData> FetchCourtIncomeFromDB()
        {
            var result = new List<CourtIncomeData>();

            string query = @"
                SELECT 
                    c.court_name,
                    COALESCE(SUM(t.total_amount), 0) AS total_amount
                FROM courts c
                LEFT JOIN transactions t 
                    ON t.court_id = c.court_id
                    AND MONTH(t.transaction_date) = MONTH(CURDATE())
                    AND YEAR(t.transaction_date)  = YEAR(CURDATE())
                GROUP BY c.court_id, c.court_name
                ORDER BY c.court_id";

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CourtIncomeData
                        {
                            CourtName = reader.GetString("court_name"),
                            TotalAmount = reader.GetDecimal("total_amount")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Utilization load error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        // ── LABEL BUILDER ─────────────────────────────────────────────────────

        private void AddCourtLabel(string courtName, decimal totalAmount,
            int sharePercent, Color accentColor, bool isBusiest)
        {
            string hexColor = ColorTranslator.ToHtml(accentColor);
            string goldStar = isBusiest ? " ⭐" : "";
            string amountStr = totalAmount.ToString("₱#,##0.00");

            var label = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Text = $"<b style='color:{hexColor}; font-size:11pt;'>" +
                           $"{courtName}{goldStar}" +
                       $"</b><br/>" +
                       $"<span style='color:#7f8c8d; font-size:10pt;'>" +
                           $"{amountStr} &nbsp;·&nbsp; {sharePercent}% of total" +
                       $"</span>",

                Font = new Font("Segoe UI", 12),
                Margin = new Padding(0, 0, 0, 12),
                AutoSize = true
            };

            flowLayoutPanel1.Controls.Add(label);
        }

        // ── HELPERS ───────────────────────────────────────────────────────────

        private static void EnableDoubleBuffer(Control c)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);
            pi?.SetValue(c, true, null);
        }

        private void label8_Click(object sender, EventArgs e) { }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e) { }
    }
}