using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ShuttleZone.reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// ── Aliases to resolve ambiguous references ───────────────────────────────────
using DrawingFont = System.Drawing.Font;
using DrawingRect = System.Drawing.Rectangle;
using iFont = iTextSharp.text.Font;
using iRectangle = iTextSharp.text.Rectangle;

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
            cmbCourt.Items.Clear();
            cmbCourt.Items.AddRange(new object[] {
                "All Courts", "Court A", "Court B", "Court C", "Court D"
            });
            cmbCourt.SelectedIndex = 0;

            cmbEquipment.Items.Clear();
            cmbEquipment.Items.AddRange(new object[] {
                "All Equipments", "Rackets", "Shuttlecocks", "Grip Tape", "Towel", "Badminton Net", "Scoreboard"
            });
            cmbEquipment.SelectedIndex = 0;

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
            int daysFromMonday = (int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday;
            if (daysFromMonday < 0) daysFromMonday += 7;
            _filterFrom = DateTime.Today.AddDays(-daysFromMonday);
            _filterTo = DateTime.Today;
            SetActiveButton(btnWeekly);
            LoadData(_filterFrom, _filterTo);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
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
            foreach (Guna.UI2.WinForms.Guna2Button btn in
                new Guna.UI2.WinForms.Guna2Button[] { btnDaily, btnWeekly, btnMonthly })
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.FromArgb(88, 72, 183);
            }
            active.FillColor = Color.FromArgb(88, 72, 183);
            active.ForeColor = Color.White;
        }

        // ── Data Loading ──────────────────────────────────────────────────────

        public void LoadData(DateTime from, DateTime to)
        {
            _filterFrom = from;
            _filterTo = to;

            try { LoadFromDatabase(from, to); }
            catch { UseFallbackData(); }

            RefreshPieData();
            guna2PanelLineGraph.Invalidate();
            guna2PanelPieChart.Invalidate();
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

        private void UpdateSummaryLabels()
        {
            try
            {
                int totalCourt = courtIncome.Sum();
                int totalEquip = equipIncome.Sum();
                int totalMember = memberIncome.Sum();
                int grandTotal = totalCourt + totalEquip + totalMember;
                if (grandTotal == 0) grandTotal = 1;

                int txCount = 0;
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string courtWhere = _filterCourt == "All Courts"
                        ? "" : " AND (income_type != 'Court' OR item_name LIKE @CourtFilter)";
                    string equipWhere = _filterEquip == "All Equipments"
                        ? "" : " AND (income_type != 'Equipment' OR item_name LIKE @EquipFilter)";

                    string sql = string.Format(@"
                        SELECT COUNT(DISTINCT receipt_no)
                        FROM transactions
                        WHERE transaction_date BETWEEN @From AND @To
                        {0}{1}", courtWhere, equipWhere);

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@From", _filterFrom.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@To", _filterTo.ToString("yyyy-MM-dd"));
                        if (_filterCourt != "All Courts")
                            cmd.Parameters.AddWithValue("@CourtFilter", "%" + _filterCourt + "%");
                        if (_filterEquip != "All Equipments")
                            cmd.Parameters.AddWithValue("@EquipFilter", "%" + _filterEquip + "%");
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            txCount = Convert.ToInt32(result);
                    }
                }

                lblTotalIncome.Text = "₱" + grandTotal.ToString("N0");
                lblCourtSales.Text = "₱" + totalCourt.ToString("N0");
                lblEquipmentSales.Text = "₱" + totalEquip.ToString("N0");
                lblMembershipSales.Text = "₱" + totalMember.ToString("N0");
                lblTotalTransaction.Text = txCount.ToString();

                float pCourt = (float)totalCourt / grandTotal * 100f;
                float pEquip = (float)totalEquip / grandTotal * 100f;
                float pMember = (float)totalMember / grandTotal * 100f;

                lblCourtPercentage.Text = string.Format("{0:0.0}%", pCourt);
                lblEquipmentPercentage.Text = string.Format("{0:0.0}%", pEquip);
                lblMembershipPercentage.Text = string.Format("{0:0.0}%", pMember);

                int totalDays = Math.Max(1, (int)(_filterTo - _filterFrom).TotalDays + 1);
                lblAverageTransactions.Text = string.Format("{0:0.0}", (float)txCount / totalDays);
            }
            catch { }
        }

        // ── Export Helpers ────────────────────────────────────────────────────

        private List<string[]> GetExportRows()
        {
            List<string[]> rows = new List<string[]>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT
                            transaction_date,
                            SUM(CASE WHEN income_type='Court'      THEN total_amount ELSE 0 END) AS court,
                            SUM(CASE WHEN income_type='Equipment'  THEN total_amount ELSE 0 END) AS equip,
                            SUM(CASE WHEN income_type='Membership' THEN total_amount ELSE 0 END) AS membership,
                            SUM(total_amount) AS total,
                            COUNT(DISTINCT receipt_no) AS txcount
                        FROM transactions
                        WHERE transaction_date BETWEEN @From AND @To
                        GROUP BY transaction_date
                        ORDER BY transaction_date";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@From", _filterFrom.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@To", _filterTo.ToString("yyyy-MM-dd"));
                        using (MySqlDataReader r = cmd.ExecuteReader())
                            while (r.Read())
                                rows.Add(new string[] {
                                    Convert.ToDateTime(r["transaction_date"]).ToString("MMM dd, yyyy"),
                                    "₱" + Math.Round(Convert.ToDecimal(r["court"])).ToString("N0"),
                                    "₱" + Math.Round(Convert.ToDecimal(r["equip"])).ToString("N0"),
                                    "₱" + Math.Round(Convert.ToDecimal(r["membership"])).ToString("N0"),
                                    "₱" + Math.Round(Convert.ToDecimal(r["total"])).ToString("N0"),
                                    r["txcount"].ToString()
                                });
                    }
                }
            }
            catch { }
            return rows;
        }

        private string GetFilterLabel()
        {
            return string.Format("{0} to {1}",
                _filterFrom.ToString("MMM dd, yyyy"),
                _filterTo.ToString("MMM dd, yyyy"));
        }

        // ── CSV Export ────────────────────────────────────────────────────────

        private void btnCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save CSV Report";
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = string.Format("ShuttleZone_Report_{0}.csv",
                    DateTime.Today.ToString("yyyyMMdd"));

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string[]> rows = GetExportRows();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ShuttleZone Income Report");
                sb.AppendLine("Period: " + GetFilterLabel());
                sb.AppendLine();
                sb.AppendLine("Date,Court Income,Equipment Income,Membership Income,Total Income,Transactions");

                foreach (string[] row in rows)
                    sb.AppendLine(string.Join(",", row));

                sb.AppendLine();
                sb.AppendLine("Total Court Income,₱" + courtIncome.Sum().ToString("N0"));
                sb.AppendLine("Total Equipment Income,₱" + equipIncome.Sum().ToString("N0"));
                sb.AppendLine("Total Membership Income,₱" + memberIncome.Sum().ToString("N0"));
                sb.AppendLine("Grand Total,₱" +
                    (courtIncome.Sum() + equipIncome.Sum() + memberIncome.Sum()).ToString("N0"));

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("CSV exported successfully!\n" + sfd.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── PDF Export ────────────────────────────────────────────────────────

        private void btnPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save PDF Report";
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = string.Format("ShuttleZone_Report_{0}.pdf",
                    DateTime.Today.ToString("yyyyMMdd"));

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string[]> rows = GetExportRows();

                Document doc = new Document(PageSize.A4.Rotate(), 30, 30, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc,
                    new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                BaseFont bfBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);

                // Use iFont alias instead of bare "Font" to avoid ambiguity
                iFont fTitle = new iFont(bfBold, 16, iFont.NORMAL, new BaseColor(88, 72, 183));
                iFont fSub = new iFont(bf, 10, iFont.NORMAL, new BaseColor(100, 100, 115));
                iFont fHeader = new iFont(bfBold, 9, iFont.NORMAL, BaseColor.WHITE);
                iFont fCell = new iFont(bf, 9, iFont.NORMAL, new BaseColor(50, 50, 60));

                doc.Add(new Paragraph("ShuttleZone Income Report", fTitle));
                doc.Add(new Paragraph("Period: " + GetFilterLabel(), fSub));
                doc.Add(new Paragraph(" "));

                // Summary boxes
                PdfPTable summary = new PdfPTable(4);
                summary.WidthPercentage = 100;
                summary.SetWidths(new float[] { 1f, 1f, 1f, 1f });
                AddPdfSummaryCell(summary, "Court Income", "₱" + courtIncome.Sum().ToString("N0"), bfBold, bf);
                AddPdfSummaryCell(summary, "Equipment Income", "₱" + equipIncome.Sum().ToString("N0"), bfBold, bf);
                AddPdfSummaryCell(summary, "Membership Income", "₱" + memberIncome.Sum().ToString("N0"), bfBold, bf);
                AddPdfSummaryCell(summary, "Grand Total",
                    "₱" + (courtIncome.Sum() + equipIncome.Sum() + memberIncome.Sum()).ToString("N0"),
                    bfBold, bf);
                doc.Add(summary);
                doc.Add(new Paragraph(" "));

                // Data table
                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1.4f, 1.2f, 1.4f, 1.4f, 1.2f, 0.9f });

                foreach (string h in new string[] {
                    "Date", "Court Income", "Equipment Income",
                    "Membership Income", "Total Income", "Transactions" })
                {
                    PdfPCell cell = new PdfPCell(new Phrase(h, fHeader));
                    cell.BackgroundColor = new BaseColor(88, 72, 183);
                    cell.Padding = 6;
                    cell.BorderColor = BaseColor.WHITE;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(cell);
                }

                bool alt = false;
                foreach (string[] row in rows)
                {
                    BaseColor bg = alt
                        ? new BaseColor(245, 244, 254)
                        : BaseColor.WHITE;
                    foreach (string cellText in row)
                    {
                        PdfPCell c = new PdfPCell(new Phrase(cellText, fCell));
                        c.BackgroundColor = bg;
                        c.Padding = 5;
                        c.BorderColor = new BaseColor(220, 220, 230);
                        c.BorderWidth = 0.5f;
                        table.AddCell(c);
                    }
                    alt = !alt;
                }

                doc.Add(table);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(
                    "Generated: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"), fSub));
                doc.Close();

                MessageBox.Show("PDF exported successfully!\n" + sfd.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddPdfSummaryCell(PdfPTable table, string label, string value,
            BaseFont bfBold, BaseFont bf)
        {
            // Use iFont alias instead of bare "Font" to avoid ambiguity
            iFont fL = new iFont(bf, 8, iFont.NORMAL, new BaseColor(100, 100, 115));
            iFont fV = new iFont(bfBold, 13, iFont.NORMAL, new BaseColor(88, 72, 183));

            PdfPCell cell = new PdfPCell();
            cell.BackgroundColor = new BaseColor(245, 244, 254);
            cell.Padding = 10;
            cell.BorderColor = new BaseColor(220, 218, 245);
            cell.BorderWidth = 1f;
            cell.AddElement(new Paragraph(label, fL));
            cell.AddElement(new Paragraph(value, fV));
            table.AddCell(cell);
        }

        // ── Excel Export ──────────────────────────────────────────────────────

        private void btnExcel_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Excel Report";
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = string.Format("ShuttleZone_Report_{0}.xlsx",
                    DateTime.Today.ToString("yyyyMMdd"));

                if (sfd.ShowDialog() != DialogResult.OK) return;

                List<string[]> rows = GetExportRows();
                 // ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Income Report");

                    // Title
                    ws.Cells["A1"].Value = "ShuttleZone Income Report";
                    ws.Cells["A1"].Style.Font.Size = 16;
                    ws.Cells["A1"].Style.Font.Bold = true;
                    ws.Cells["A1"].Style.Font.Color.SetColor(
                        System.Drawing.Color.FromArgb(88, 72, 183));
                    ws.Cells["A2"].Value = "Period: " + GetFilterLabel();
                    ws.Cells["A2"].Style.Font.Color.SetColor(
                        System.Drawing.Color.FromArgb(100, 100, 115));

                    // Summary boxes
                    AddExcelSummary(ws, 4, 1, "Court Income", "₱" + courtIncome.Sum().ToString("N0"));
                    AddExcelSummary(ws, 4, 2, "Equipment Income", "₱" + equipIncome.Sum().ToString("N0"));
                    AddExcelSummary(ws, 4, 3, "Membership Income", "₱" + memberIncome.Sum().ToString("N0"));
                    AddExcelSummary(ws, 4, 4, "Grand Total",
                        "₱" + (courtIncome.Sum() + equipIncome.Sum() + memberIncome.Sum()).ToString("N0"));

                    // Headers
                    string[] headers = {
                        "Date", "Court Income", "Equipment Income",
                        "Membership Income", "Total Income", "Transactions"
                    };
                    int startRow = 7;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cells[startRow, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(
                            System.Drawing.Color.FromArgb(88, 72, 183));
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin,
                            System.Drawing.Color.White);
                    }

                    // Data rows
                    for (int i = 0; i < rows.Count; i++)
                    {
                        for (int j = 0; j < rows[i].Length; j++)
                        {
                            var cell = ws.Cells[startRow + 1 + i, j + 1];
                            cell.Value = rows[i][j];
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(
                                i % 2 == 0
                                    ? System.Drawing.Color.White
                                    : System.Drawing.Color.FromArgb(245, 244, 254));
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin,
                                System.Drawing.Color.FromArgb(220, 220, 230));
                        }
                    }

                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    int lastRow = startRow + rows.Count + 2;
                    ws.Cells[lastRow, 1].Value = "Generated: " +
                        DateTime.Now.ToString("MMM dd, yyyy hh:mm tt");
                    ws.Cells[lastRow, 1].Style.Font.Color.SetColor(
                        System.Drawing.Color.FromArgb(130, 130, 145));

                    pkg.SaveAs(new FileInfo(sfd.FileName));
                }

                MessageBox.Show("Excel exported successfully!\n" + sfd.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddExcelSummary(ExcelWorksheet ws, int row, int col,
            string label, string value)
        {
            ws.Cells[row, col].Value = label;
            ws.Cells[row, col].Style.Font.Size = 8;
            ws.Cells[row, col].Style.Font.Color.SetColor(
                System.Drawing.Color.FromArgb(100, 100, 115));

            ws.Cells[row + 1, col].Value = value;
            ws.Cells[row + 1, col].Style.Font.Bold = true;
            ws.Cells[row + 1, col].Style.Font.Size = 12;
            ws.Cells[row + 1, col].Style.Font.Color.SetColor(
                System.Drawing.Color.FromArgb(88, 72, 183));

            ws.Cells[row, col, row + 1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[row, col, row + 1, col].Style.Fill.BackgroundColor.SetColor(
                System.Drawing.Color.FromArgb(245, 244, 254));
            ws.Cells[row, col, row + 1, col].Style.Border.BorderAround(
                ExcelBorderStyle.Thin, System.Drawing.Color.FromArgb(200, 198, 235));
        }

        // ── Existing Event Handlers (unchanged) ───────────────────────────────
        private void lblReportsAnalytics_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblPercentage_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e) { }

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
        private void lblCourtPercentage_Click(object sender, EventArgs e) { }
        private void lblEquipmentPercentage_Click(object sender, EventArgs e) { }

        private void lblMembershipPercentage_Click(object sender, EventArgs e)
        {
            Reports_Dashboard_Page2 page2 = new Reports_Dashboard_Page2();
            page2.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(page2);
        }

        private void lblAverageTransactions_Click(object sender, EventArgs e) { }
        private void lblStatusUpdate_Click(object sender, EventArgs e) { }

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
                // Use DrawingFont alias instead of bare "Font"
                g.DrawString("No data", new DrawingFont("Segoe UI", 9f), Brushes.Gray, padL, padT);
                return;
            }

            // Use DrawingFont alias instead of bare "Font"
            using (DrawingFont f = new DrawingFont("Segoe UI", 10f, FontStyle.Bold))
                g.DrawString("Income Trend", f, Brushes.Black, padL, 12);

            int dataMax = Math.Max(1, courtIncome.Concat(equipIncome).Concat(memberIncome).Max());
            int maxVal = (int)(Math.Ceiling(dataMax / 5000.0) * 5000);
            int step = maxVal / 4;
            int[] yTicks = { 0, step, step * 2, step * 3, maxVal };

            using (Pen gridPen = new Pen(Color.FromArgb(230, 230, 235), 1f))
            // Use DrawingFont alias instead of bare "Font"
            using (DrawingFont lf = new DrawingFont("Segoe UI", 7.5f))
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
            // Use DrawingFont alias instead of bare "Font"
            using (DrawingFont lf = new DrawingFont("Segoe UI", 7.5f))
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

            // Use DrawingFont alias instead of bare "Font"
            using (DrawingFont f = new DrawingFont("Segoe UI", 10f, FontStyle.Bold))
                g.DrawString("Income Distribution", f, Brushes.Black, 16, 12);

            if (pieValues == null || pieValues.Length == 0) return;

            int size = (int)(Math.Min(W, H) * 0.50f);
            // Use DrawingRect alias instead of bare "Rectangle"
            DrawingRect pieRect = new DrawingRect((W - size) / 2 - 15, (H - size) / 2 + 8, size, size);

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

        private void DrawPieLabel(Graphics g, DrawingRect pieRect,
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

            using (Pen lp = new Pen(Color.FromArgb(170, 170, 185), 1f))
            // Use DrawingFont alias instead of bare "Font"
            using (DrawingFont lf = new DrawingFont("Segoe UI", 8f))
            using (SolidBrush tb = new SolidBrush(Color.FromArgb(70, 70, 90)))
            {
                g.DrawLine(lp, lx1, ly1, lx2, ly2);
                bool right = Math.Cos(midRad) >= 0;
                float tx = lx2 + (right ? 4f : -4f);
                float ty = ly2 - 7f;
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

        private void btnDetailed_Report_Click(object sender, EventArgs e)
        {
            Reports_Dashboard_Page2 page2 = new Reports_Dashboard_Page2();
            page2.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(page2);
        }
    }
}