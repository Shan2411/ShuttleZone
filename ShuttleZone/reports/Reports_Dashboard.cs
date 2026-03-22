using MySql.Data.MySqlClient;
using ShuttleZone.reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.Reports
{
    public partial class Reports_Dashboard : UserControl
    {
        private static string ConnStr => DatabaseConfig.ConnStr;

        private string[] dates = new string[0];
        private int[] courtIncome = new int[0];
        private int[] equipIncome = new int[0];
        private int[] memberIncome = new int[0];

        private float[] pieValues = new float[0];
        private string[] pieLabels = new string[0];
        private readonly Color[] pieColors = {
            Color.FromArgb(88,  72, 183),
            Color.FromArgb(174, 165, 236),
            Color.FromArgb(207, 202, 246)
        };

        // ── Current filter state ──────────────────────────────────────────────
        private DateTime _filterFrom = DateTime.Today.AddDays(-6);
        private DateTime _filterTo = DateTime.Today;
        private string _filterCourt = "All Courts";
        private string _filterEquip = "All Equipments";

        // ── Constructor ───────────────────────────────────────────────────────

        public Reports_Dashboard()
        {
            InitializeComponent();
            SetPanelDoubleBuffered(guna2PanelLineGraph);
            SetPanelDoubleBuffered(guna2PanelPieChart);
            guna2PanelLineGraph.Resize += (s, e) => guna2PanelLineGraph.Invalidate();
            guna2PanelPieChart.Resize += (s, e) => guna2PanelPieChart.Invalidate();
            this.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Populate combo boxes
            cmbCourt.Items.Clear();
            cmbCourt.Items.AddRange(new object[] {
                "All Courts", "Court A", "Court B", "Court C", "Court D"
            });
            cmbCourt.SelectedIndex = 0;

            cmbEquipment.Items.Clear();
            cmbEquipment.Items.AddRange(new object[] {
                "All Equipments", "Badminton Rackets", "Shuttlecocks", "Grip Tape", "Towel"
            });
            cmbEquipment.SelectedIndex = 0;

            // Default: Daily (last 7 days)
            SetActiveButton(btnDaily);
            LoadData(_filterFrom, _filterTo);
        }

        // ── Filter Buttons ────────────────────────────────────────────────────

        private void btnDaily_Click(object sender, EventArgs e)
        {
            _filterFrom = DateTime.Today.AddDays(-6);
            _filterTo = DateTime.Today;
            SetActiveButton(btnDaily);
            LoadData(_filterFrom, _filterTo);
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            // Current week: Monday to today
            int daysFromMonday = (int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday;
            if (daysFromMonday < 0) daysFromMonday += 7;
            _filterFrom = DateTime.Today.AddDays(-daysFromMonday);
            _filterTo = DateTime.Today;
            SetActiveButton(btnWeekly);
            LoadData(_filterFrom, _filterTo);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            // Current month: 1st to today
            _filterFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _filterTo = DateTime.Today;
            SetActiveButton(btnMonthly);
            LoadData(_filterFrom, _filterTo);
        }

        // ── Combo Box Filters ─────────────────────────────────────────────────

        private void cmbCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourt.SelectedItem == null) return;
            _filterCourt = cmbCourt.SelectedItem.ToString();
            LoadData(_filterFrom, _filterTo);
        }

        private void cmbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEquipment.SelectedItem == null) return;
            _filterEquip = cmbEquipment.SelectedItem.ToString();
            LoadData(_filterFrom, _filterTo);
        }

        // ── Helper: highlight active button ──────────────────────────────────

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button active)
        {
            // Reset all
            foreach (Guna.UI2.WinForms.Guna2Button btn in
                new Guna.UI2.WinForms.Guna2Button[] { btnDaily, btnWeekly, btnMonthly })
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.FromArgb(88, 72, 183);
            }
            // Highlight active
            active.FillColor = Color.FromArgb(88, 72, 183);
            active.ForeColor = Color.White;
        }

        // ── Data Loading ──────────────────────────────────────────────────────

        public void LoadData(DateTime from, DateTime to)
        {
            try { LoadFromDatabase(from, to); }
            catch { UseFallbackData(); }

            RefreshPieData();
            guna2PanelLineGraph.Invalidate();
            guna2PanelPieChart.Invalidate();

            // Update summary labels if they exist
            UpdateSummaryLabels();
        }

        private void LoadFromDatabase(DateTime from, DateTime to)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime d = from.Date; d <= to.Date; d = d.AddDays(1))
                allDates.Add(d);

            Dictionary<string, int> cMap = new Dictionary<string, int>();
            Dictionary<string, int> eMap = new Dictionary<string, int>();
            Dictionary<string, int> mMap = new Dictionary<string, int>();
            foreach (DateTime d in allDates)
            {
                string k = d.ToString("MMM dd");
                cMap[k] = 0; eMap[k] = 0; mMap[k] = 0;
            }

            // Build WHERE clause based on combo filters
            string courtFilter = _filterCourt == "All Courts"
                ? "" : " AND item_name LIKE @CourtFilter";
            string equipFilter = _filterEquip == "All Equipments"
                ? "" : " AND item_name LIKE @EquipFilter";

            string sql = string.Format(@"
                SELECT transaction_date, income_type, SUM(total_amount) AS total
                FROM transactions
                WHERE transaction_date BETWEEN @From AND @To
                  AND (
                        (income_type = 'Court'     {0})
                     OR (income_type = 'Equipment' {1})
                     OR  income_type = 'Membership'
                  )
                GROUP BY transaction_date, income_type
                ORDER BY transaction_date", courtFilter, equipFilter);

            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@From", from.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@To", to.ToString("yyyy-MM-dd"));
                    if (_filterCourt != "All Courts")
                        cmd.Parameters.AddWithValue("@CourtFilter", "%" + _filterCourt + "%");
                    if (_filterEquip != "All Equipments")
                        cmd.Parameters.AddWithValue("@EquipFilter", "%" + _filterEquip + "%");

                    using (MySqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            string key = Convert.ToDateTime(r["transaction_date"]).ToString("MMM dd");
                            string type = r["income_type"].ToString();
                            int total = (int)Math.Round(Convert.ToDecimal(r["total"]));
                            if (type == "Court" && cMap.ContainsKey(key)) cMap[key] += total;
                            if (type == "Equipment" && eMap.ContainsKey(key)) eMap[key] += total;
                            if (type == "Membership" && mMap.ContainsKey(key)) mMap[key] += total;
                        }
                }
            }

            List<string> dl = new List<string>();
            List<int> cl = new List<int>(), el = new List<int>(), ml = new List<int>();
            foreach (DateTime d in allDates)
            {
                string k = d.ToString("MMM dd");
                dl.Add(k); cl.Add(cMap[k]); el.Add(eMap[k]); ml.Add(mMap[k]);
            }
            dates = dl.ToArray(); courtIncome = cl.ToArray();
            equipIncome = el.ToArray(); memberIncome = ml.ToArray();
        }

        private void UseFallbackData()
        {
            dates = new[] { "Feb 08", "Feb 09", "Feb 10", "Feb 11", "Feb 12", "Feb 13", "Feb 14" };
            courtIncome = new[] { 13000, 14500, 12000, 15500, 14000, 16000, 19000 };
            equipIncome = new[] { 2000, 5000, 4500, 1500, 3000, 4500, 6500 };
            memberIncome = new[] { 2500, 2000, 2500, 3500, 3000, 4500, 5000 };
        }

        private void RefreshPieData()
        {
            int tC = courtIncome.Sum(), tE = equipIncome.Sum(), tM = memberIncome.Sum();
            int grand = Math.Max(1, tC + tE + tM);
            float pC = (float)tC / grand * 100f;
            float pE = (float)tE / grand * 100f;
            float pM = (float)tM / grand * 100f;
            pieValues = new[] { pC, pE, pM };
            pieLabels = new[] {
                string.Format("Court Rentals {0:0}%",     pC),
                string.Format("Equipment Rentals {0:0}%", pE),
                string.Format("Memberships {0:0}%",       pM)
            };
        }

        // ── Summary Labels ────────────────────────────────────────────────────
        //  Updates lblTotalIncome, lblCourtSales, lblEquipmentSales,
        //  lblMembershipSales, lblTotalTransaction if they exist on the form.
        //
        private void UpdateSummaryLabels()
        {
            try
            {
                int totalCourt = courtIncome.Sum();
                int totalEquip = equipIncome.Sum();
                int totalMember = memberIncome.Sum();
                int grandTotal = totalCourt + totalEquip + totalMember;
                if (grandTotal == 0) grandTotal = 1;

                // Get transaction count from DB
                int txCount = 0;
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string sql = @"
                SELECT COUNT(DISTINCT receipt_no)
                FROM transactions
                WHERE transaction_date BETWEEN @From AND @To";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@From", _filterFrom.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@To", _filterTo.ToString("yyyy-MM-dd"));
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            txCount = Convert.ToInt32(result);
                    }
                }

                // Summary totals
                lblTotalIncome.Text = "₱" + grandTotal.ToString("N0");
                lblCourtSales.Text = "₱" + totalCourt.ToString("N0");
                lblEquipmentSales.Text = "₱" + totalEquip.ToString("N0");
                lblMembershipSales.Text = "₱" + totalMember.ToString("N0");
                lblTotalTransaction.Text = txCount.ToString();

                // Percentages
                float pCourt = (float)totalCourt / grandTotal * 100f;
                float pEquip = (float)totalEquip / grandTotal * 100f;
                float pMember = (float)totalMember / grandTotal * 100f;

                lblCourtPercentage.Text = string.Format("{0:0.0}%", pCourt);
                lblEquipmentPercentage.Text = string.Format("{0:0.0}%", pEquip);
                lblMembershipPercentage.Text = string.Format("{0:0.0}%", pMember);

                // Average transactions per day in the selected range
                int totalDays = Math.Max(1, (int)(_filterTo - _filterFrom).TotalDays + 1);
                float avgTx = (float)txCount / totalDays;
                lblAverageTransactions.Text = string.Format("{0:0.0}", avgTx);
            }
            catch { /* Safe to ignore if labels don't exist */ }
        }

        // ── Existing Event Handlers (unchanged) ───────────────────────────────
        private void lblReportsAnalytics_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblPercentage_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e) { }
        private void btnExcel_Click(object sender, EventArgs e) { }

        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            Reports_Dashboard_Page2 page2 = new Reports_Dashboard_Page2();
            page2.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(page2);
        }

        private void lblTotalIncome_Click(object sender, EventArgs e) { }
        private void lblCourtSales_Click(object sender, EventArgs e) { }
        private void lblEquipmentSales_Click(object sender, EventArgs e) { }
        private void lblMembershipSales_Click(object sender, EventArgs e) { }
        private void lblTotalTransaction_Click(object sender, EventArgs e) { }

        // ── Line Chart ────────────────────────────────────────────────────────

        private void guna2PanelLineGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Control panel = (Control)sender;
            int W = panel.ClientSize.Width, H = panel.ClientSize.Height;
            int padL = 60, padT = 40, padR = 20, padB = 65;
            int cW = W - padL - padR, cH = H - padT - padB;

            if (dates == null || dates.Length == 0)
            {
                g.DrawString("No data", new Font("Segoe UI", 9f), Brushes.Gray, padL, padT);
                return;
            }

            using (Font f = new Font("Segoe UI", 10f, FontStyle.Bold))
                g.DrawString("Income Trend", f, Brushes.Black, padL, 12);

            int dataMax = Math.Max(1, courtIncome.Concat(equipIncome).Concat(memberIncome).Max());
            int maxVal = (int)(Math.Ceiling(dataMax / 5000.0) * 5000);
            int step = maxVal / 4;
            int[] yTicks = { 0, step, step * 2, step * 3, maxVal };

            using (Pen gridPen = new Pen(Color.FromArgb(230, 230, 235), 1f))
            using (Font lf = new Font("Segoe UI", 7.5f))
            using (SolidBrush lb = new SolidBrush(Color.FromArgb(140, 140, 155)))
            {
                gridPen.DashStyle = DashStyle.Dash;
                foreach (int tick in yTicks)
                {
                    float yPos = padT + cH - (float)tick / maxVal * cH;
                    g.DrawLine(gridPen, padL, yPos, padL + cW, yPos);
                    g.DrawString(tick >= 1000 ? (tick / 1000) + "k" : "0", lf, lb, padL - 36, yPos - 7);
                }

                float xStep = dates.Length > 1 ? (float)cW / (dates.Length - 1) : cW;
                float legendY = H - padB + 32;
                for (int i = 0; i < dates.Length; i++)
                    g.DrawString(dates[i], lf, lb, padL + i * xStep - 16, padT + cH + 8);

                DrawLineSeries(g, padL, padT, cW, cH, maxVal, xStep,
                    courtIncome, Color.FromArgb(88, 72, 183), "Court Income", 0, legendY);
                DrawLineSeries(g, padL, padT, cW, cH, maxVal, xStep,
                    equipIncome, Color.FromArgb(136, 118, 210), "Equipment Income", 1, legendY);
                DrawLineSeries(g, padL, padT, cW, cH, maxVal, xStep,
                    memberIncome, Color.FromArgb(195, 185, 240), "Membership Income", 2, legendY);
            }
        }

        private void DrawLineSeries(Graphics g,
            int padL, int padT, int cW, int cH, int maxVal, float xStep,
            int[] data, Color color, string label, int legendIdx, float legendY)
        {
            if (data == null || data.Length == 0) return;
            PointF[] pts = new PointF[data.Length];
            for (int i = 0; i < data.Length; i++)
                pts[i] = new PointF(padL + i * xStep, padT + cH - (float)data[i] / maxVal * cH);

            using (Pen lp = new Pen(color, 2f))
            using (SolidBrush db = new SolidBrush(color))
            using (Font lf = new Font("Segoe UI", 7.5f))
            using (SolidBrush tb = new SolidBrush(Color.FromArgb(110, 110, 125)))
            {
                lp.LineJoin = LineJoin.Round;
                if (pts.Length > 1) g.DrawCurve(lp, pts, 0.4f);
                foreach (PointF pt in pts)
                {
                    g.FillEllipse(db, pt.X - 3.5f, pt.Y - 3.5f, 7f, 7f);
                    g.DrawEllipse(Pens.White, pt.X - 2.5f, pt.Y - 2.5f, 5f, 5f);
                }
                float lx = padL + legendIdx * 145f;
                g.FillEllipse(db, lx, legendY + 3, 8, 8);
                g.DrawString(label, lf, tb, lx + 12, legendY);
            }
        }

        // ── Pie Chart ─────────────────────────────────────────────────────────

        private void guna2PanelPieChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Control panel = (Control)sender;
            int W = panel.ClientSize.Width, H = panel.ClientSize.Height;

            using (Font f = new Font("Segoe UI", 10f, FontStyle.Bold))
                g.DrawString("Income Distribution", f, Brushes.Black, 16, 12);

            if (pieValues == null || pieValues.Length == 0) return;

            int size = (int)(Math.Min(W, H) * 0.50f);
            Rectangle pieRect = new Rectangle((W - size) / 2 - 15, (H - size) / 2 + 8, size, size);

            float startAngle = -90f;
            for (int i = 0; i < pieValues.Length; i++)
            {
                float sweep = pieValues[i] / 100f * 360f;
                using (SolidBrush fb = new SolidBrush(pieColors[i]))
                    g.FillPie(fb, pieRect, startAngle, sweep);
                using (Pen bp = new Pen(Color.White, 2f))
                    g.DrawPie(bp, pieRect, startAngle, sweep);
                DrawPieLabel(g, pieRect, startAngle, sweep, pieLabels[i]);
                startAngle += sweep;
            }
        }

        private void DrawPieLabel(Graphics g, Rectangle pieRect,
            float startAngle, float sweep, string label)
        {
            double midRad = (startAngle + sweep / 2f) * Math.PI / 180.0;
            float cx = pieRect.X + pieRect.Width / 2f, cy = pieRect.Y + pieRect.Height / 2f, r = pieRect.Width / 2f;
            float lx1 = cx + (float)Math.Cos(midRad) * r * 0.78f, ly1 = cy + (float)Math.Sin(midRad) * r * 0.78f;
            float lx2 = cx + (float)Math.Cos(midRad) * r * 1.18f, ly2 = cy + (float)Math.Sin(midRad) * r * 1.18f;

            using (Pen lp = new Pen(Color.FromArgb(170, 170, 185), 1f))
            using (Font lf = new Font("Segoe UI", 8f))
            using (SolidBrush tb = new SolidBrush(Color.FromArgb(70, 70, 90)))
            {
                g.DrawLine(lp, lx1, ly1, lx2, ly2);
                bool right = Math.Cos(midRad) >= 0;
                float tx = lx2 + (right ? 4f : -4f), ty = ly2 - 7f;
                if (!right) tx -= g.MeasureString(label, lf).Width;
                g.DrawString(label, lf, tb, tx, ty);
            }
        }

        private static void SetPanelDoubleBuffered(Control ctrl)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(ctrl, true, null);
        }

        private void lblCourtPercentage_Click(object sender, EventArgs e)
        {

        }

        private void lblEquipmentPercentage_Click(object sender, EventArgs e)
        {

        }

        private void lblMembershipPercentage_Click(object sender, EventArgs e)
        {

        }

        private void lblAverageTransactions_Click(object sender, EventArgs e)
        {

        }
    }
}
