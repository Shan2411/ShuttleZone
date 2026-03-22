using ShuttleZone.reports;
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

namespace ShuttleZone.Reports
{
    public partial class Reports_Dashboard : UserControl
    {
        // ── Hardcoded Income Data ─────────────────────────────────────────────

        private readonly string[] dates = { "Feb 08", "Feb 09", "Feb 10", "Feb 11", "Feb 12", "Feb 13", "Feb 14" };

        private readonly int[] courtIncome = { 13000, 14500, 12000, 15500, 14000, 16000, 19000 };
        private readonly int[] equipIncome = { 2000, 5000, 4500, 1500, 3000, 4500, 6500 };
        private readonly int[] memberIncome = { 2500, 2000, 2500, 3500, 3000, 4500, 5000 };

        private readonly float[] pieValues = { 62f, 23f, 15f };
        private readonly string[] pieLabels = { "Court Rentals 62%", "Equipment Rentals 23%", "Memberships 15%" };
        private readonly Color[] pieColors = {
            Color.FromArgb(88,  72, 183),
            Color.FromArgb(174, 165, 236),
            Color.FromArgb(207, 202, 246)
        };

        // ── Constructor ───────────────────────────────────────────────────────

        public Reports_Dashboard()
        {
            InitializeComponent();

            SetPanelDoubleBuffered(guna2PanelLineGraph);
            SetPanelDoubleBuffered(guna2PanelPieChart);

            guna2PanelLineGraph.Resize += (s, e) => guna2PanelLineGraph.Invalidate();
            guna2PanelPieChart.Resize += (s, e) => guna2PanelPieChart.Invalidate();
        }

        private static void SetPanelDoubleBuffered(Control ctrl)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(ctrl, true, null);
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
           
        }

        // ── Line Chart ────────────────────────────────────────────────────────

        private void guna2PanelLineGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Control panel = (Control)sender;
            int W = panel.ClientSize.Width;
            int H = panel.ClientSize.Height;

            int padL = 60, padT = 40, padR = 20, padB = 65;
            int cW = W - padL - padR;
            int cH = H - padT - padB;

            // Title
            using (Font titleFont = new Font("Segoe UI", 10f, FontStyle.Bold))
            {
                g.DrawString("Income Trend", titleFont, Brushes.Black, padL, 12);
            }

            int maxVal = 22000;
            int[] yTicks = { 0, 5000, 10000, 15000, 20000 };

            using (Pen gridPen = new Pen(Color.FromArgb(230, 230, 235), 1f))
            using (Font labelFont = new Font("Segoe UI", 7.5f))
            using (SolidBrush labelBrush = new SolidBrush(Color.FromArgb(140, 140, 155)))
            {
                gridPen.DashStyle = DashStyle.Dash;

                foreach (int tick in yTicks)
                {
                    float yPos = padT + cH - (float)tick / maxVal * cH;
                    g.DrawLine(gridPen, padL, yPos, padL + cW, yPos);

                    string lbl = tick == 0 ? "0" : (tick / 1000) + "000";
                    g.DrawString(lbl, labelFont, labelBrush, padL - 48, yPos - 7);
                }

                float xStep = (float)cW / (dates.Length - 1);
                float legendY = H - padB + 32;

                for (int i = 0; i < dates.Length; i++)
                {
                    float xPos = padL + i * xStep;
                    g.DrawString(dates[i], labelFont, labelBrush, xPos - 16, padT + cH + 8);
                }

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
            PointF[] pts = new PointF[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                pts[i] = new PointF(
                    padL + i * xStep,
                    padT + cH - (float)data[i] / maxVal * cH);
            }

            using (Pen linePen = new Pen(color, 2f))
            using (SolidBrush dotBrush = new SolidBrush(color))
            using (Font legendFont = new Font("Segoe UI", 7.5f))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(110, 110, 125)))
            {
                linePen.LineJoin = LineJoin.Round;

                g.DrawCurve(linePen, pts, 0.4f);

                foreach (PointF pt in pts)
                {
                    g.FillEllipse(dotBrush, pt.X - 3.5f, pt.Y - 3.5f, 7f, 7f);
                    g.DrawEllipse(Pens.White, pt.X - 2.5f, pt.Y - 2.5f, 5f, 5f);
                }

                float lx = padL + legendIdx * 145f;
                g.FillEllipse(dotBrush, lx, legendY + 3, 8, 8);
                g.DrawString(label, legendFont, textBrush, lx + 12, legendY);
            }
        }

        // ── Pie Chart ─────────────────────────────────────────────────────────

        private void guna2PanelPieChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Control panel = (Control)sender;
            int W = panel.ClientSize.Width;
            int H = panel.ClientSize.Height;

            using (Font titleFont = new Font("Segoe UI", 10f, FontStyle.Bold))
            {
                g.DrawString("Income Distribution", titleFont, Brushes.Black, 16, 12);
            }

            int size = (int)(Math.Min(W, H) * 0.50f);
            int pieX = (W - size) / 2 - 15;
            int pieY = (H - size) / 2 + 8;
            Rectangle pieRect = new Rectangle(pieX, pieY, size, size);

            float startAngle = -90f;
            for (int i = 0; i < pieValues.Length; i++)
            {
                float sweep = pieValues[i] / 100f * 360f;

                using (SolidBrush fillBrush = new SolidBrush(pieColors[i]))
                {
                    g.FillPie(fillBrush, pieRect, startAngle, sweep);
                }

                using (Pen borderPen = new Pen(Color.White, 2f))
                {
                    g.DrawPie(borderPen, pieRect, startAngle, sweep);
                }

                DrawPieLabel(g, pieRect, startAngle, sweep, pieLabels[i]);

                startAngle += sweep;
            }
        }

        private void DrawPieLabel(Graphics g, Rectangle pieRect,
            float startAngle, float sweep, string label)
        {
            double midRad = (startAngle + sweep / 2f) * Math.PI / 180.0;
            float cx = pieRect.X + pieRect.Width / 2f;
            float cy = pieRect.Y + pieRect.Height / 2f;
            float r = pieRect.Width / 2f;

            float lx1 = cx + (float)Math.Cos(midRad) * r * 0.78f;
            float ly1 = cy + (float)Math.Sin(midRad) * r * 0.78f;
            float lx2 = cx + (float)Math.Cos(midRad) * r * 1.18f;
            float ly2 = cy + (float)Math.Sin(midRad) * r * 1.18f;

            using (Pen linePen = new Pen(Color.FromArgb(170, 170, 185), 1f))
            using (Font labelFont = new Font("Segoe UI", 8f))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(70, 70, 90)))
            {
                g.DrawLine(linePen, lx1, ly1, lx2, ly2);

                bool rightSide = Math.Cos(midRad) >= 0;
                float tx = lx2 + (rightSide ? 4f : -4f);
                float ty = ly2 - 7f;

                if (!rightSide)
                {
                    SizeF sz = g.MeasureString(label, labelFont);
                    tx -= sz.Width;
                }

                g.DrawString(label, labelFont, textBrush, tx, ty);
            }
        }

        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            Reports_Dashboard_Page2 page2 = new Reports_Dashboard_Page2();
            page2.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(page2);
        }
    }
}