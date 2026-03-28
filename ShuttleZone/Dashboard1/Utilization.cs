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

        // ── Track current filter ──────────────────────────────────────────────
        public enum DateFilter { Today, ThisMonth, ThisYear }
        private DateFilter _currentFilter = DateFilter.ThisMonth;

        private static readonly Color[] CourtColors = new[]
        {
            Color.FromArgb(94, 148, 255),
            Color.FromArgb(46, 204, 113),
            Color.FromArgb(155, 89, 182),
            Color.FromArgb(230, 126, 34),
        };

        public Utilization()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            EnableDoubleBuffer(flowLayoutPanel1);
            LoadUtilizationData();
        }

        // ── BUTTONS ───────────────────────────────────────────────────────────

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _currentFilter = DateFilter.Today;
            HighlightActiveButton(guna2Button1);
            LoadUtilizationData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            _currentFilter = DateFilter.ThisMonth;
            HighlightActiveButton(guna2Button2);
            LoadUtilizationData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _currentFilter = DateFilter.ThisYear;
            HighlightActiveButton(guna2Button3);
            LoadUtilizationData();
        }

        // Visually marks which button is active
        private void HighlightActiveButton(Guna.UI2.WinForms.Guna2Button active)
        {
            var buttons = new[]
            {
                guna2Button1,
                guna2Button2,
                guna2Button3
            };

            foreach (var btn in buttons)
            {
                btn.FillColor = Color.FromArgb(230, 230, 230); // inactive
                btn.ForeColor = Color.FromArgb(100, 100, 100);
            }

            active.FillColor = Color.FromArgb(94, 148, 255);    // active
            active.ForeColor = Color.White;
        }

        // ── LOAD ──────────────────────────────────────────────────────────────

        public void LoadUtilizationData()
        {
            var data = FetchCourtIncomeFromDB(_currentFilter);
            if (data == null || data.Count == 0) return;

            decimal maxIncome = data.Max(d => d.TotalAmount);
            decimal totalIncome = data.Sum(d => d.TotalAmount);

            int progressValue = totalIncome > 0
                ? (int)Math.Round((maxIncome / totalIncome) * 100)
                : 0;

            guna2CircleProgressBar1.Value = Math.Min(progressValue, 100);

            var busiestCourt = data.OrderByDescending(d => d.TotalAmount).First();

            // Update your progress bar center label here if you have one
            // e.g. label8.Text = $"{busiestCourt.CourtName}\n{progressValue}%";

            RebuildLabels(data, totalIncome, busiestCourt.CourtName);
        }

        private void RebuildLabels(List<CourtIncomeData> data,
            decimal totalIncome, string busiestCourtName)
        {
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

                    int sharePercent = totalIncome > 0
                        ? (int)Math.Round((court.TotalAmount / totalIncome) * 100)
                        : 0;

                    AddCourtLabel(
                        court.CourtName,
                        court.TotalAmount,
                        sharePercent,
                        accent,
                        isBusiest: court.CourtName == busiestCourtName
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

        private List<CourtIncomeData> FetchCourtIncomeFromDB(DateFilter filter)
        {
            var result = new List<CourtIncomeData>();

            // Build the WHERE clause depending on the filter
            string dateCondition;
            switch (filter)
            {
                case DateFilter.Today:
                    dateCondition = "AND DATE(t.transaction_date) = CURDATE()";
                    break;
                case DateFilter.ThisYear:
                    dateCondition = "AND YEAR(t.transaction_date) = YEAR(CURDATE())";
                    break;
                default: // ThisMonth
                    dateCondition = @"AND MONTH(t.transaction_date) = MONTH(CURDATE())
                                      AND YEAR(t.transaction_date)  = YEAR(CURDATE())";
                    break;
            }

            string query = $@"
                SELECT
                    c.court_name,
                    COALESCE(SUM(t.total_amount), 0) AS total_amount
                FROM courts c
                LEFT JOIN transactions t
                    ON t.court_id = c.court_id
                    {dateCondition}
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

            // Show the period label based on current filter
            string periodLabel;
            switch (_currentFilter)
            {
                case DateFilter.Today: periodLabel = "today"; break;
                case DateFilter.ThisYear: periodLabel = "this year"; break;
                default: periodLabel = "this month"; break;
            }

            var label = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Text = $"<b style='color:{hexColor}; font-size:11pt;'>" +
                           $"{courtName}{goldStar}" +
                       $"</b><br/>" +
                       $"<span style='color:#7f8c8d; font-size:10pt;'>" +
                           $"{amountStr} · {sharePercent}% of {periodLabel}" +
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
        private void label5_Click(object sender, EventArgs e) { }
        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e) { }
    }
}