using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Data;
using System.Windows.Forms;

namespace ShuttleZone.Rent_History
{
    public partial class RentHistory : UserControl
    {
        private DataTable dt = new DataTable();

        public RentHistory()
        {
            InitializeComponent();

            this.Load += RentHistory_Load;
            dgvTable.CellClick += dgvTable_CellClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnExport.Click += btnExport_Click;
        }

        private void RentHistory_Load(object sender, EventArgs e)
        {
            dgvTable.AutoGenerateColumns = false;

            colId.DataPropertyName = "colId";
            colDate.DataPropertyName = "colDate";
            colTime.DataPropertyName = "colTime";
            colTotal.DataPropertyName = "colTotal";
            colPayment.DataPropertyName = "colPayment";
            colStatus.DataPropertyName = "colStatus";

            colId.HeaderText = "Receipt No";
            colDate.HeaderText = "Date";
            colTime.HeaderText = "Time";
            colTotal.HeaderText = "Total Amount";
            colPayment.HeaderText = "Payment Method";
            colStatus.HeaderText = "Source";

            // 🔥 Remove Customer column safely
            if (dgvTable.Columns.Contains("colCustomer"))
                dgvTable.Columns.Remove("colCustomer");

            LoadData();

            if (dgvTable.Columns.Contains("colView"))
            {
                colView.Text = "View";
                colView.UseColumnTextForButtonValue = true;
            }
        }

        public void LoadData()
        {
            dt.Clear();

            using (var conn = DBconnection.GetConnection())
            {
                string query = @"
            SELECT 
                receipt_no AS colId,
                IFNULL(DATE_FORMAT(transaction_date, '%b %d, %Y'), '') AS colDate,
                LOWER(IFNULL(TIME_FORMAT(transaction_time, '%l:%i%p'), '')) AS colTime,
                CONCAT('₱', FORMAT(SUM(total_amount),2)) AS colTotal,
                payment_method AS colPayment,
                transaction_source AS colStatus
            FROM transactions
            WHERE transaction_source IN ('Kiosk', 'Frontdesk')
            GROUP BY receipt_no, transaction_date, transaction_time, payment_method, transaction_source
            ORDER BY transaction_date DESC, transaction_time DESC";

                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            dgvTable.DataSource = dt.Rows.Count > 0 ? dt : null;

            UpdateSummary();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvTable.Columns[e.ColumnIndex].Name != "colView")
                return;

            var row = dgvTable.Rows[e.RowIndex];

            string id = row.Cells["colId"].Value?.ToString();
            string date = row.Cells["colDate"].Value?.ToString();
            string time = row.Cells["colTime"].Value?.ToString();
            string customer = ""; // 🔥 removed column safely
            string total = row.Cells["colTotal"].Value?.ToString();
            string payment = row.Cells["colPayment"].Value?.ToString();
            string status = row.Cells["colStatus"].Value?.ToString();

            View frm = new View(id, date, time, customer, total, payment, status);
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(search))
            {
                dgvTable.DataSource = dt.Rows.Count > 0 ? dt : null;
            }
            else
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter =
                    $"colId LIKE '%{search}%' OR " +
                    $"colDate LIKE '%{search}%' OR " +
                    $"colTime LIKE '%{search}%' OR " +
                    $"colTotal LIKE '%{search}%' OR " +
                    $"colPayment LIKE '%{search}%' OR " +
                    $"colStatus LIKE '%{search}%'";
                dgvTable.DataSource = dv.Count > 0 ? dv : null;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export not implemented yet.");
        }

        private void UpdateSummary()
        {
            if (dt.Rows.Count == 0)
            {
                TodayTransactionTotal.Text = "₱0.00";
                CashTotal.Text = "₱0.00";
                ECashTotal.Text = "₱0.00";
                LatestTransaction.Text = "-";
                TransactionID.Text = "-";
                return;
            }

            decimal todayTotal = 0;
            decimal cashTotal = 0;
            decimal eCashTotal = 0;

            DateTime today = DateTime.Today;

            foreach (DataRow row in dt.Rows)
            {
                // Parse total
                string totalStr = row["colTotal"].ToString().Replace("₱", "").Replace(",", "");
                decimal total = decimal.TryParse(totalStr, out decimal val) ? val : 0;

                DateTime rowDate;
                DateTime.TryParse(row["colDate"].ToString(), out rowDate);

                if (rowDate.Date == today)
                    todayTotal += total;

                string payment = row["colPayment"].ToString().Trim().ToLower();

                if (payment == "cash")
                {
                    cashTotal += total;
                }
                else if (payment == "e-cash")
                {
                    eCashTotal += total;
                }
            }

            var latestRow = dt.Rows[0];

            TodayTransactionTotal.Text = "₱" + todayTotal.ToString("N2");
            CashTotal.Text = "₱" + cashTotal.ToString("N2");
            ECashTotal.Text = "₱" + eCashTotal.ToString("N2");

            LatestTransaction.Text = latestRow["colTime"].ToString();
            TransactionID.Text = latestRow["colId"].ToString();
        }

        public void RefreshDataGrid()
        {
            LoadData();
        }

        private void TodayTransactionTotal_Click(object sender, EventArgs e) { }
        private void LatestTransaction_Click(object sender, EventArgs e) { }
        private void CashTotal_Click(object sender, EventArgs e) { }
        private void ECashTotal_Click(object sender, EventArgs e) { }
        private void TransactionID_Click(object sender, EventArgs e) { }
    }
}