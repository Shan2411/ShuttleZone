using System;
using System.Data;
using System.Drawing;
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
            InitializeFilters();
            LoadData();
        }

    
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

      
        private void LoadData()
        {
            dt.Rows.Add("TXN001", "2025-01-17 09:30 AM", "Court A", 2, 1, "₱500", "Cash", "Completed");
            dt.Rows.Add("TXN002", "2025-01-17 10:00 AM", "Court B", 1, 1, "₱250", "E-Cash", "Completed");
            dt.Rows.Add("TXN003", "2025-01-17 11:15 AM", "Court C", 3, 1, "₱750", "Cash", "Completed");
            dt.Rows.Add("TXN004", "2025-01-17 11:45 AM", "Badminton Racket", 0, 2, "₱10", "Cash", "Completed");
            dt.Rows.Add("TXN005", "2025-01-17 01:30 PM", "Shuttlecock (Pack)", 0, 3, "₱24", "E-Cash", "Completed");
            dt.Rows.Add("TXN006", "2025-01-16 02:30 PM", "Court A", 2, 1, "₱500", "E-Cash", "Completed");
            dt.Rows.Add("TXN007", "2025-01-16 03:00 PM", "Court D", 1, 1, "₱250", "Cash", "Cancelled");

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

            dgvTable.CellContentClick += dgvTable_CellContentClick;
        }

   
        private void InitializeFilters()
        {
            cmbType.Items.AddRange(new string[] { "All", "Court", "Equipment" });
            cmbPayment.Items.AddRange(new string[] { "All", "Cash", "E-Cash" });
            cmbStatus.Items.AddRange(new string[] { "All", "Completed", "Cancelled" });

            cmbType.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            txtSearch.TextChanged += ApplyFilters;
            cmbType.SelectedIndexChanged += ApplyFilters;
            cmbPayment.SelectedIndexChanged += ApplyFilters;
            cmbStatus.SelectedIndexChanged += ApplyFilters;
            guna2TextBox2.TextChanged += ApplyFilters;

            btnExport.Click += BtnExport_Click;
        }

        private void ApplyFilters(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            string type = cmbType.SelectedItem.ToString();
            string payment = cmbPayment.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();
            string date = guna2TextBox2.Text.ToLower();

            dgvTable.Rows.Clear();

            var filtered = dt.AsEnumerable().Where(row =>
            {
                bool matchesSearch =
                    row["Transaction"].ToString().ToLower().Contains(search) ||
                    row["Court"].ToString().ToLower().Contains(search);

                bool matchesType =
                    type == "All" ||
                    (type == "Court" && row["Court"].ToString().Contains("Court")) ||
                    (type == "Equipment" && !row["Court"].ToString().Contains("Court"));

                bool matchesPayment =
                    payment == "All" || row["Payment"].ToString() == payment;

                bool matchesStatus =
                    status == "All" || row["Status"].ToString() == status;

                bool matchesDate =
                    string.IsNullOrEmpty(date) ||
                    row["Date"].ToString().ToLower().Contains(date);

                return matchesSearch && matchesType && matchesPayment && matchesStatus && matchesDate;
            });

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


        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTable.Columns[e.ColumnIndex].Name == "colView")
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];

                string transactionId = row.Cells["colTransaction"].Value.ToString();
                string dateTime = row.Cells["colDate"].Value.ToString();
                string court = row.Cells["colCourt"].Value.ToString();
                string hours = row.Cells["colHours"].Value.ToString();
                string quantity = row.Cells["colQuantity"].Value.ToString();
                string amount = row.Cells["colAmount"].Value.ToString();
                string payment = row.Cells["colPayment"].Value.ToString();
                string status = row.Cells["colStatus"].Value.ToString();

                View viewForm = new View(
                    transactionId,
                    dateTime,
                    court,
                    hours,
                    quantity,
                    amount,
                    payment,
                    status
                );

                viewForm.ShowDialog();
            }
        }

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
