using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.reports
{
    public partial class Reports_Dashboard_Page2 : UserControl
    {
        private static string ConnStr => DatabaseConfig.ConnStr;

        // ── Bar Chart Data ────────────────────────────────────────────────────
        private string[] courtLabels = new string[0];
        private int[] courtValues = new int[0];
        private readonly Color courtBarColor = Color.FromArgb(130, 60, 220);

        private string[] equipLabels = new string[0];
        private int[] equipValues = new int[0];
        private readonly Color equipBarColor = Color.FromArgb(30, 120, 255);

        // ── Detailed Report Data ──────────────────────────────────────────────
        private class ReportRow
        {
            public string Date { get; set; }
            public int CourtIncome { get; set; }
            public int EquipIncome { get; set; }
            public int TotalIncome { get; set; }
            public int Transactions { get; set; }
        }
        private List<ReportRow> reportData = new List<ReportRow>();

        // ── Constructor ───────────────────────────────────────────────────────

        public Reports_Dashboard_Page2()
        {
            InitializeComponent();
            SetPanelDoubleBuffered(guna2PanelCourtIncomeBreakdown);
            SetPanelDoubleBuffered(guna2PanelEquipmentIncomeBreakdown);
            guna2PanelCourtIncomeBreakdown.Resize += (s, e) => guna2PanelCourtIncomeBreakdown.Invalidate();
            guna2PanelEquipmentIncomeBreakdown.Resize += (s, e) => guna2PanelEquipmentIncomeBreakdown.Invalidate();

            flpDetailedReportRow.Font = new Font("Segoe UI", 9.5f);
            flpDetailedReportRow.AutoScroll = true;
            flpDetailedReportRow.FlowDirection = FlowDirection.TopDown;
            flpDetailedReportRow.WrapContents = false;
            flpDetailedReportRow.Padding = new Padding(0);
            flpDetailedReportRow.BackColor = Color.White;

            this.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadData(DateTime.Today.AddDays(-6), DateTime.Today);
        }

        // ── Public — wire to filter button ───────────────────────────────────
        //
        //  private void btnFilter_Click(object sender, EventArgs e)
        //  {
        //      LoadData(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        //  }
        //
        public void LoadData(DateTime from, DateTime to)
        {
            try { LoadFromDatabase(from, to); }
            catch { UseFallbackData(); }

            guna2PanelCourtIncomeBreakdown.Invalidate();
            guna2PanelEquipmentIncomeBreakdown.Invalidate();
            PopulateDetailedReportRows();
        }

        // ── Database ──────────────────────────────────────────────────────────

        private void LoadFromDatabase(DateTime from, DateTime to)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();

                // ── Court breakdown — group all variations into Court A/B/C/D ──
                string sqlCourt = @"
                    SELECT
                        CASE
                            WHEN item_name LIKE '%Court A%' THEN 'Court A'
                            WHEN item_name LIKE '%Court B%' THEN 'Court B'
                            WHEN item_name LIKE '%Court C%' THEN 'Court C'
                            WHEN item_name LIKE '%Court D%' THEN 'Court D'
                        END AS grouped_name,
                        SUM(total_amount) AS total
                    FROM transactions
                    WHERE income_type = 'Court'
                      AND transaction_date BETWEEN @From AND @To
                    GROUP BY
                        CASE
                            WHEN item_name LIKE '%Court A%' THEN 'Court A'
                            WHEN item_name LIKE '%Court B%' THEN 'Court B'
                            WHEN item_name LIKE '%Court C%' THEN 'Court C'
                            WHEN item_name LIKE '%Court D%' THEN 'Court D'
                        END
                    HAVING grouped_name IS NOT NULL
                    ORDER BY total DESC";

                List<string> cL = new List<string>();
                List<int> cV = new List<int>();
                using (MySqlCommand cmd = new MySqlCommand(sqlCourt, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            cL.Add(r["grouped_name"].ToString());
                            cV.Add((int)Math.Round(Convert.ToDecimal(r["total"])));
                        }
                }
                courtLabels = cL.ToArray();
                courtValues = cV.ToArray();

                // ── Equipment breakdown — group all variations into standard names ──
                string sqlEquip = @"
                    SELECT
                        CASE
                            WHEN item_name LIKE '%Badminton Racket%'
                              OR item_name LIKE '%Racket%'           THEN 'Badminton Rackets'
                            WHEN item_name LIKE '%Shuttlecock%'      THEN 'Shuttlecocks'
                            WHEN item_name LIKE '%Grip Tape%'        THEN 'Grip Tape'
                            WHEN item_name LIKE '%Towel%'            THEN 'Towel'
                        END AS grouped_name,
                        SUM(total_amount) AS total
                    FROM transactions
                    WHERE income_type = 'Equipment'
                      AND transaction_date BETWEEN @From AND @To
                    GROUP BY
                        CASE
                            WHEN item_name LIKE '%Badminton Racket%'
                              OR item_name LIKE '%Racket%'           THEN 'Badminton Rackets'
                            WHEN item_name LIKE '%Shuttlecock%'      THEN 'Shuttlecocks'
                            WHEN item_name LIKE '%Grip Tape%'        THEN 'Grip Tape'
                            WHEN item_name LIKE '%Towel%'            THEN 'Towel'
                        END
                    HAVING grouped_name IS NOT NULL
                    ORDER BY total DESC";

                List<string> eL = new List<string>();
                List<int> eV = new List<int>();
                using (MySqlCommand cmd = new MySqlCommand(sqlEquip, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            eL.Add(r["grouped_name"].ToString());
                            eV.Add((int)Math.Round(Convert.ToDecimal(r["total"])));
                        }
                }
                equipLabels = eL.ToArray();
                equipValues = eV.ToArray();

                // ── Detailed report — one row per day ─────────────────────────
                string sqlReport = @"
                    SELECT
                        transaction_date,
                        SUM(CASE WHEN income_type = 'Court'     THEN total_amount ELSE 0 END) AS court,
                        SUM(CASE WHEN income_type = 'Equipment' THEN total_amount ELSE 0 END) AS equipment,
                        SUM(total_amount) AS total,
                        COUNT(DISTINCT receipt_no) AS transactions
                    FROM transactions
                    WHERE transaction_date BETWEEN @From AND @To
                    GROUP BY transaction_date
                    ORDER BY transaction_date";

                reportData = new List<ReportRow>();
                using (MySqlCommand cmd = new MySqlCommand(sqlReport, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                            reportData.Add(new ReportRow
                            {
                                Date = Convert.ToDateTime(r["transaction_date"]).ToString("MMM dd"),
                                CourtIncome = (int)Math.Round(Convert.ToDecimal(r["court"])),
                                EquipIncome = (int)Math.Round(Convert.ToDecimal(r["equipment"])),
                                TotalIncome = (int)Math.Round(Convert.ToDecimal(r["total"])),
                                Transactions = Convert.ToInt32(r["transactions"])
                            });
                }
            }
        }

        private void UseFallbackData()
        {
            courtLabels = new[] { "Court A", "Court B", "Court C", "Court D" };
            courtValues = new[] { 28400, 26200, 24800, 22600 };
            equipLabels = new[] { "Badminton Rackets", "Shuttlecocks", "Grip Tape", "Towel" };
            equipValues = new[] { 18200, 10800, 6400, 2700 };
            reportData = new List<ReportRow>
            {
                new ReportRow { Date="Feb 08", CourtIncome=12400, EquipIncome=4200, TotalIncome=18600, Transactions=28 },
                new ReportRow { Date="Feb 09", CourtIncome=14200, EquipIncome=5100, TotalIncome=23800, Transactions=32 },
                new ReportRow { Date="Feb 10", CourtIncome=11800, EquipIncome=3900, TotalIncome=17200, Transactions=25 },
                new ReportRow { Date="Feb 11", CourtIncome=15600, EquipIncome=5800, TotalIncome=24400, Transactions=38 },
                new ReportRow { Date="Feb 12", CourtIncome=13900, EquipIncome=4700, TotalIncome=21100, Transactions=30 },
                new ReportRow { Date="Feb 13", CourtIncome=16200, EquipIncome=6200, TotalIncome=26900, Transactions=41 },
                new ReportRow { Date="Feb 14", CourtIncome=18400, EquipIncome=7100, TotalIncome=31500, Transactions=47 },
            };
        }

        // ── FLP Population ────────────────────────────────────────────────────

        private void PopulateDetailedReportRows()
        {
            flpDetailedReportRow.Controls.Clear();

            int rowWidth = flpDetailedReportRow.ClientSize.Width - 2;
            if (rowWidth <= 0) rowWidth = 890;

            for (int i = 0; i < reportData.Count; i++)
            {
                ReportRow data = reportData[i];

                DetailedReportRows row = new DetailedReportRows();
                row.Width = rowWidth;
                row.Height = 50;
                row.Margin = new Padding(0);

                row.SetAlternateColor(i % 2 == 0);
                row.SetData(data.Date, data.CourtIncome, data.EquipIncome,
                            data.TotalIncome, data.Transactions);

                flpDetailedReportRow.Controls.Add(row);

                Panel sep = new Panel
                {
                    Width = rowWidth,
                    Height = 1,
                    BackColor = Color.FromArgb(235, 235, 240),
                    Margin = new Padding(0)
                };
                flpDetailedReportRow.Controls.Add(sep);
            }

            if (reportData.Count == 0)
            {
                Label noData = new Label
                {
                    Text = "No data available for the selected period.",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = Color.FromArgb(150, 150, 160),
                    AutoSize = false,
                    Width = rowWidth,
                    Height = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(0)
                };
                flpDetailedReportRow.Controls.Add(noData);
            }
        }

        // ── Bar Chart Paint Handlers ──────────────────────────────────────────

        private void guna2PanelCourtIncomeBreakdown_Paint(object sender, PaintEventArgs e)
        {
            DrawBreakdownChart(e.Graphics, (Control)sender,
                "Court Income Breakdown", courtLabels, courtValues, courtBarColor);
        }

        private void guna2PanelEquipmentIncomeBreakdown_Paint(object sender, PaintEventArgs e)
        {
            DrawBreakdownChart(e.Graphics, (Control)sender,
                "Equipment Income Breakdown", equipLabels, equipValues, equipBarColor);
        }

        private void flpDetailedReportRow_Paint(object sender, PaintEventArgs e) { }

        // ── Shared Bar Chart Renderer ─────────────────────────────────────────

        private void DrawBreakdownChart(Graphics g, Control panel,
            string title, string[] labels, int[] values, Color barColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int W = panel.ClientSize.Width, H = panel.ClientSize.Height;

            if (labels == null || labels.Length == 0)
            {
                g.DrawString("No data", new Font("Segoe UI", 9f), Brushes.Gray, 16, 16);
                return;
            }

            int padL = 16, padR = 16, padTop = 48;
            int rowH = (H - padTop - 8) / labels.Length;
            int barH = 6;
            int barTrackW = W - padL - padR - 90;
            int maxVal = Math.Max(1, values.Max());

            using (Font tf = new Font("Segoe UI", 10f, FontStyle.Bold))
                g.DrawString(title, tf, Brushes.Black, padL, 14);

            using (Font lf = new Font("Segoe UI", 8.5f))
            using (Font af = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (SolidBrush lb = new SolidBrush(Color.FromArgb(50, 50, 60)))
            using (SolidBrush ab = new SolidBrush(Color.FromArgb(30, 30, 40)))
            using (SolidBrush tb = new SolidBrush(Color.FromArgb(225, 225, 232)))
            using (SolidBrush bb = new SolidBrush(barColor))
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    int rowY = padTop + i * rowH;
                    g.DrawString(labels[i], lf, lb, padL, rowY + 2);

                    string amount = "₱" + values[i].ToString("N0");
                    SizeF sz = g.MeasureString(amount, af);
                    g.DrawString(amount, af, ab, W - padR - sz.Width, rowY + 2);

                    int trackY = rowY + 22;
                    float fillW = (float)values[i] / maxVal * barTrackW;
                    DrawRoundedBar(g, tb, padL, trackY, barTrackW, barH, barH / 2);
                    DrawRoundedBar(g, bb, padL, trackY, (int)fillW, barH, barH / 2);
                }
            }
        }

        // ── Utility ───────────────────────────────────────────────────────────

        private static void DrawRoundedBar(Graphics g, Brush brush,
            int x, int y, int width, int height, int radius)
        {
            if (width <= 0) return;
            if (width < radius * 2) radius = width / 2;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(x, y, radius * 2, height, 90, 180);
                path.AddArc(x + width - radius * 2, y, radius * 2, height, 270, 180);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }

        private static void SetPanelDoubleBuffered(Control ctrl)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(ctrl, true, null);
        }
    }
}