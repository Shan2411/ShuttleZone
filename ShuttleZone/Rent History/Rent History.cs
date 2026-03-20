using System;
using System.Windows.Forms;
using System.Drawing;

namespace ShuttleZone.Rent_History
{
    public partial class View : Form
    {
        
DataTable dt = new DataTable();

        public RentHistory()
        {
            InitializeComponent();

            // Hook events manually (safe)
            this.Load += RentHistory_Load;
            dgvTable.CellClick += dgvTable_CellClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnExport.Click += btnExport_Click;
        }

        private void RentHistory_Load(object sender, EventArgs e)
        {
            dgvTable.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            if (dt.Columns.Count == 0) // prevent duplicate columns
            {
                dt.Columns.Add("ID");
                dt.Columns.Add("Date");
                dt.Columns.Add("Time");
                dt.Columns.Add("Customer");
                dt.Columns.Add("Total");
                dt.Columns.Add("Payment");
                dt.Columns.Add("Status");
            }

            dt.Rows.Clear();

            dt.Rows.Add("TXN001", "Jan 17", "12:14:50", "John Doe", "₱950", "Cash", "Completed");

            dgvTable.DataSource = dt;
        }

        // VIEW BUTTON CLICK
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTable.Columns[e.ColumnIndex].Name == "colView")
            {
                var row = dgvTable.Rows[e.RowIndex];

                string id = row.Cells["colId"].Value?.ToString();
                string date = row.Cells["colDate"].Value?.ToString();
                string time = row.Cells["colTime"].Value?.ToString();
                string customer = row.Cells["colCustomer"].Value?.ToString();
                string total = row.Cells["colTotal"].Value?.ToString();
                string payment = row.Cells["colPayment"].Value?.ToString();
                string status = row.Cells["colStatus"].Value?.ToString();

                View frm = new View(id, date, time, customer, total, payment, status);
                frm.ShowDialog();
            }
        }

        // SMART SEARCH
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(search))
            {
                dgvTable.DataSource = dt;
            }
            else
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter =
                    $"ID LIKE '%{search}%' OR " +
                    $"Date LIKE '%{search}%' OR " +
                    $"Time LIKE '%{search}%' OR " +
                    $"Customer LIKE '%{search}%' OR " +
                    $"Total LIKE '%{search}%' OR " +
                    $"Payment LIKE '%{search}%' OR " +
                    $"Status LIKE '%{search}%'";

                dgvTable.DataSource = dv;
            }
        }

        // EXPORT TO EXCEL
        private void btnExport_Click(object sender, EventArgs e)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add();

            int colIndex = 1;

            foreach (DataGridViewColumn col in dgvTable.Columns)
            {
                if (col.Name == "colView") continue;
                excel.Cells[1, colIndex++] = col.HeaderText;
            }

            for (int i = 0; i < dgvTable.Rows.Count; i++)
            {
                colIndex = 1;

                foreach (DataGridViewColumn col in dgvTable.Columns)
                {
                    if (col.Name == "colView") continue;

                    excel.Cells[i + 2, colIndex++] =
                        dgvTable.Rows[i].Cells[col.Name].Value;
                }
            }

            excel.Visible = true;
        }

        // ✅ FIX FOR YOUR ORIGINAL ERRORS
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
    }
}