using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ShuttleZone.Rent_History
{
    public partial class RentH : UserControl
    {
        private DataTable dt = new DataTable();

        public RentH()
        {
            InitializeComponent();
            InitializeData();
            LoadData();
            HookEvents();
        }

        // ===============================
        // CREATE TABLE STRUCTURE
        // ===============================
        private void InitializeData()
        {
            dt.Columns.Add("Transaction");
            dt.Columns.Add("Date");
            dt.Columns.Add("Court");
            dt.Columns.Add("Hours");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Payment");
            dt.Columns.Add("Status");
        }

        // ===============================
        // LOAD SAMPLE DATA
        // ===============================
        private void LoadData()
        {
            dt.Rows.Add("TXN001", "2025-01-17 09:30 AM", "Court A", 2, 1, "₱500", "Cash", "Completed");
            dt.Rows.Add("TXN002", "2025-01-17 10:00 AM", "Court B", 1, 1, "₱250", "E-Cash", "Completed");
            dt.Rows.Add("TXN003", "2025-01-17 11:15 AM", "Court C", 3, 1, "₱750", "Cash", "Completed");
            dt.Rows.Add("TXN004", "2025-01-17 11:45 AM", "Badminton Racket", 0, 2, "₱10", "Cash", "Completed");
            dt.Rows.Add("TXN005", "2025-01-17 01:30 PM", "Shuttlecock (Pack)", 0, 3, "₱24", "E-Cash", "Completed");
            dt.Rows.Add("TXN006", "2025-01-16 02:30 PM", "Court A", 2, 1, "₱500", "E-Cash", "Completed");
            dt.Rows.Add("TXN007", "2025-01-16 03:00 PM", "Court D", 1, 1, "₱250", "Cash", "Cancelled");

            RefreshGrid();
        }

        // ===============================
        // EVENT HOOKING
        // ===============================
        private void HookEvents()
        {
            txtSearch.TextChanged += ApplySearch;
            dgvTable.CellContentClick += dgvTable_CellContentClick;
            btnExport.Click += BtnExport_Click;
        }

        // ===============================
        // REFRESH GRID
        // ===============================
        private void RefreshGrid()
        {
            dgvTable.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dgvTable.Rows.Add(
                    row["Transaction"],
                    row["Date"],
                    row["Court"],
                    row["Hours"],
                    row["Quantity"],
                    row["Amount"],
                    row["Payment"],
                    row["Status"],
                    "View"
                );
            }
        }

        // ===============================
        // SMART SEARCH ONLY
        // ===============================
        private void ApplySearch(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            dgvTable.Rows.Clear();

            var filtered = dt.AsEnumerable().Where(row =>
                row["Transaction"].ToString().ToLower().Contains(search) ||
                row["Court"].ToString().ToLower().Contains(search) ||
                row["Payment"].ToString().ToLower().Contains(search) ||
                row["Status"].ToString().ToLower().Contains(search)
            );

            foreach (var row in filtered)
            {
                dgvTable.Rows.Add(
                    row["Transaction"],
                    row["Date"],
                    row["Court"],
                    row["Hours"],
                    row["Quantity"],
                    row["Amount"],
                    row["Payment"],
                    row["Status"],
                    "View"
                );
            }
        }

        // ===============================
        // VIEW BUTTON
        // ===============================
        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTable.Columns[e.ColumnIndex].Name == "colView")
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];

                View viewForm = new View(
                    row.Cells["colTransaction"].Value.ToString(),
                    row.Cells["colDate"].Value.ToString(),
                    row.Cells["colCourt"].Value.ToString(),
                    row.Cells["colHours"].Value.ToString(),
                    row.Cells["colQuantity"].Value.ToString(),
                    row.Cells["colAmount"].Value.ToString(),
                    row.Cells["colPayment"].Value.ToString(),
                    row.Cells["colStatus"].Value.ToString()
                );

                viewForm.ShowDialog();
            }
        }

        // ===============================
        // EXPORT TO EXCEL
        // ===============================
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "RentalHistory.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Rental History");

                        for (int i = 0; i < dgvTable.Columns.Count - 1; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvTable.Columns[i].HeaderText;
                        }

                        for (int i = 0; i < dgvTable.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvTable.Columns.Count - 1; j++)
                            {
                                ws.Cell(i + 2, j + 1).Value =
                                    dgvTable.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Export Successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}