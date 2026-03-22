using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.reports
{
    public partial class Reports_Dashboard_Page2 : UserControl
    {
        // ── Hardcoded Data ────────────────────────────────────────────────────

        private string[] courtLabels = { "Court A", "Court B", "Court C", "Court D" };
        private int[] courtValues = { 28400, 26200, 24800, 22600 };
        private readonly Color courtBarColor = Color.FromArgb(130, 60, 220); // purple

        private string[] equipLabels = { "Rackets", "Shuttlecocks", "Court Shoes", "Accessories" };
        private int[] equipValues = { 18200, 10800, 6400, 2700 };
        private readonly Color equipBarColor = Color.FromArgb(30, 120, 255);  // blue

        // ── Data Model (para sa Detailed Report rows) ─────────────────────────

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

            // Setup FlowLayoutPanel
            flpDetailedReportRow.AutoScroll = true;
            flpDetailedReportRow.FlowDirection = FlowDirection.TopDown;
            flpDetailedReportRow.WrapContents = false;

            // Load initial data
            LoadData();
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        //
        //  This is the ONLY method you need to update when you have a real DB.
        //  Call LoadData() again after any filter change — everything redraws automatically.
        //
        private void LoadData()
        {
            // ── OPTION A: HARDCODED (current) ────────────────────────────────
            //    Delete this block when you have a real DB.
            UseFallbackData();

            // ── OPTION B: REAL DATABASE ──────────────────────────────────────
            //    Uncomment and fill in when DB is ready.
            //
            // try
            // {
            //     LoadFromDatabase();
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("DB error: " + ex.Message);
            //     UseFallbackData();
            // }

            guna2PanelCourtIncomeBreakdown.Invalidate();
            guna2PanelEquipmentIncomeBreakdown.Invalidate();
            PopulateDetailedReportRows();
        }

        private void UseFallbackData()
        {
            courtLabels = new[] { "Court A", "Court B", "Court C", "Court D" };
            courtValues = new[] { 28400, 26200, 24800, 22600 };

            equipLabels = new[] { "Rackets", "Shuttlecocks", "Court Shoes", "Accessories" };
            equipValues = new[] { 18200, 10800, 6400, 2700 };

            reportData = new List<ReportRow>
            {
                new ReportRow { Date = "Feb 08", CourtIncome = 12400, EquipIncome = 4200,  TotalIncome = 18600, Transactions = 28 },
                new ReportRow { Date = "Feb 09", CourtIncome = 14200, EquipIncome = 5100,  TotalIncome = 23800, Transactions = 32 },
                new ReportRow { Date = "Feb 10", CourtIncome = 11800, EquipIncome = 3900,  TotalIncome = 17200, Transactions = 25 },
                new ReportRow { Date = "Feb 11", CourtIncome = 15600, EquipIncome = 5800,  TotalIncome = 24400, Transactions = 38 },
                new ReportRow { Date = "Feb 12", CourtIncome = 13900, EquipIncome = 4700,  TotalIncome = 21100, Transactions = 30 },
                new ReportRow { Date = "Feb 13", CourtIncome = 16200, EquipIncome = 6200,  TotalIncome = 26900, Transactions = 41 },
                new ReportRow { Date = "Feb 14", CourtIncome = 18400, EquipIncome = 7100,  TotalIncome = 31500, Transactions = 47 },
            };
        }

        // private void LoadFromDatabase()
        // {
        //     using (SqlConnection conn = new SqlConnection(ConnStr))
        //     {
        //         conn.Open();
        //
        //         // Court Income Breakdown
        //         string sqlCourt = @"
        //             SELECT CourtName, SUM(Amount) AS Total
        //             FROM Transactions
        //             WHERE IncomeType = 'Court'
        //             GROUP BY CourtName
        //             ORDER BY Total DESC";
        //
        //         var cLabels = new List<string>();
        //         var cValues = new List<int>();
        //         using (SqlCommand cmd = new SqlCommand(sqlCourt, conn))
        //         using (SqlDataReader r = cmd.ExecuteReader())
        //         {
        //             while (r.Read())
        //             {
        //                 cLabels.Add(r["CourtName"].ToString());
        //                 cValues.Add(Convert.ToInt32(r["Total"]));
        //             }
        //         }
        //         courtLabels = cLabels.ToArray();
        //         courtValues = cValues.ToArray();
        //
        //         // Equipment Income Breakdown
        //         string sqlEquip = @"
        //             SELECT EquipmentName, SUM(Amount) AS Total
        //             FROM Transactions
        //             WHERE IncomeType = 'Equipment'
        //             GROUP BY EquipmentName
        //             ORDER BY Total DESC";
        //
        //         var eLabels = new List<string>();
        //         var eValues = new List<int>();
        //         using (SqlCommand cmd = new SqlCommand(sqlEquip, conn))
        //         using (SqlDataReader r = cmd.ExecuteReader())
        //         {
        //             while (r.Read())
        //             {
        //                 eLabels.Add(r["EquipmentName"].ToString());
        //                 eValues.Add(Convert.ToInt32(r["Total"]));
        //             }
        //         }
        //         equipLabels = eLabels.ToArray();
        //         equipValues = eValues.ToArray();
        //
        //         // Detailed Report rows
        //         string sqlReport = @"
        //             SELECT
        //                 CONVERT(varchar, TransactionDate, 107) AS Label,
        //                 SUM(CASE WHEN IncomeType = 'Court'     THEN Amount ELSE 0 END) AS Court,
        //                 SUM(CASE WHEN IncomeType = 'Equipment' THEN Amount ELSE 0 END) AS Equipment,
        //                 SUM(Amount) AS Total,
        //                 COUNT(*)    AS Transactions
        //             FROM Transactions
        //             GROUP BY CONVERT(varchar, TransactionDate, 107), TransactionDate
        //             ORDER BY TransactionDate";
        //
        //         reportData = new List<ReportRow>();
        //         using (SqlCommand cmd = new SqlCommand(sqlReport, conn))
        //         using (SqlDataReader r = cmd.ExecuteReader())
        //         {
        //             while (r.Read())
        //             {
        //                 reportData.Add(new ReportRow
        //                 {
        //                     Date         = r["Label"].ToString(),
        //                     CourtIncome  = Convert.ToInt32(r["Court"]),
        //                     EquipIncome  = Convert.ToInt32(r["Equipment"]),
        //                     TotalIncome  = Convert.ToInt32(r["Total"]),
        //                     Transactions = Convert.ToInt32(r["Transactions"])
        //                 });
        //             }
        //         }
        //     }
        // }

        // ── FlowLayoutPanel Population ────────────────────────────────────────

        private void PopulateDetailedReportRows()
        {
            flpDetailedReportRow.Controls.Clear();

            foreach (ReportRow data in reportData)
            {
                DetailedReportRows row = new DetailedReportRows();

                // Stretch each row to full width of the FLP
                row.Width = flpDetailedReportRow.ClientSize.Width
                             - (flpDetailedReportRow.Padding.Left + flpDetailedReportRow.Padding.Right)
                             - SystemInformation.VerticalScrollBarWidth - 2;
                row.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                row.SetData(
                    data.Date,
                    data.CourtIncome,
                    data.EquipIncome,
                    data.TotalIncome,
                    data.Transactions
                );

                flpDetailedReportRow.Controls.Add(row);
            }
        }

        // ── Filter Hook ───────────────────────────────────────────────────────
        //  Wire this to your filter controls (DatePicker, ComboBox, etc.)
        //
        //  private void btnFilter_Click(object sender, EventArgs e)
        //  {
        //      LoadData();   // fetch new data → rows + charts redraw automatically
        //  }

        // ── Court Income Breakdown Panel ──────────────────────────────────────

        private void guna2PanelCourtIncomeBreakdown_Paint(object sender, PaintEventArgs e)
        {
            DrawBreakdownChart(e.Graphics, (Control)sender,
                "Court Income Breakdown", courtLabels, courtValues, courtBarColor);
        }

        // ── Equipment Income Breakdown Panel ──────────────────────────────────

        private void guna2PanelEquipmentIncomeBreakdown_Paint(object sender, PaintEventArgs e)
        {
            DrawBreakdownChart(e.Graphics, (Control)sender,
                "Equipment Income Breakdown", equipLabels, equipValues, equipBarColor);
        }

        // ── Shared Bar Chart Renderer ─────────────────────────────────────────

        private void DrawBreakdownChart(Graphics g, Control panel,
            string title, string[] labels, int[] values, Color barColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int W = panel.ClientSize.Width;
            int H = panel.ClientSize.Height;

            // Guard
            if (labels == null || labels.Length == 0)
            {
                g.DrawString("No data", new Font("Segoe UI", 9f), Brushes.Gray, 16, 16);
                return;
            }

            // Layout constants
            int padL = 16;
            int padR = 16;
            int padTop = 48;
            int rowH = (H - padTop - 8) / labels.Length;
            int barH = 6;
            int barTrackW = W - padL - padR - 90;

            int maxVal = values.Max();
            if (maxVal == 0) maxVal = 1;

            // Title
            using (Font titleFont = new Font("Segoe UI", 10f, FontStyle.Bold))
            {
                g.DrawString(title, titleFont, Brushes.Black, padL, 14);
            }

            using (Font labelFont = new Font("Segoe UI", 8.5f))
            using (Font amountFont = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (SolidBrush labelBrush = new SolidBrush(Color.FromArgb(50, 50, 60)))
            using (SolidBrush amountBrush = new SolidBrush(Color.FromArgb(30, 30, 40)))
            using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(225, 225, 232)))
            using (SolidBrush barBrush = new SolidBrush(barColor))
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    int rowY = padTop + i * rowH;

                    // Row label (e.g. "Court A")
                    g.DrawString(labels[i], labelFont, labelBrush, padL, rowY + 2);

                    // Amount right-aligned (e.g. "₱28,400")
                    string amount = "₱" + values[i].ToString("N0");
                    SizeF amtSz = g.MeasureString(amount, amountFont);
                    g.DrawString(amount, amountFont, amountBrush,
                        W - padR - amtSz.Width, rowY + 2);

                    // Track (gray background bar)
                    int trackY = rowY + 22;
                    float fillW = (float)values[i] / maxVal * barTrackW;

                    DrawRoundedBar(g, trackBrush, padL, trackY, barTrackW, barH, barH / 2);
                    DrawRoundedBar(g, barBrush, padL, trackY, (int)fillW, barH, barH / 2);
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
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(ctrl, true, null);
        }

        private void flpDetailedReportRow_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}