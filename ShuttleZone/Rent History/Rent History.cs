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
            colCustomer.DataPropertyName = "colCustomer";
            colTotal.DataPropertyName = "colTotal";
            colPayment.DataPropertyName = "colPayment";
            colStatus.DataPropertyName = "colStatus";

            colId.HeaderText = "Receipt No";
            colDate.HeaderText = "Date";
            colTime.HeaderText = "Time";
            colCustomer.HeaderText = "Item/Customer";
            colTotal.HeaderText = "Total Amount";
            colPayment.HeaderText = "Payment Method";
            colStatus.HeaderText = "Source";

            LoadData();
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
                        IFNULL(TIME_FORMAT(transaction_time, '%H:%i:%s'), '') AS colTime,
                        item_name AS colCustomer,
                        CONCAT('₱', FORMAT(total_amount,2)) AS colTotal,
                        payment_method AS colPayment,
                        transaction_source AS colStatus
                    FROM transactions
                    WHERE transaction_source = 'Kiosk'
                    ORDER BY transaction_date DESC, transaction_time DESC";

                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            dgvTable.DataSource = dt.Rows.Count > 0 ? dt : null;
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvTable.Columns[e.ColumnIndex].Name != "colView")
                return;

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
                    $"colCustomer LIKE '%{search}%' OR " +
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

        // 🔹 Public method to refresh the DataGridView externally
        public void RefreshDataGrid()
        {
            LoadData();
        }
    }
}