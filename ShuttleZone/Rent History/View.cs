using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System.Data;

namespace ShuttleZone.Rent_History
{
    public partial class View : Form
    {
        string receiptNo, date, time, customer, total, payment, status;
        string transactionID; // 🔹 Store transaction_id

        // 🔹 For draggable form
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public View()
        {
            InitializeComponent();
        }

        public View(string receiptNo, string date, string time, string customer, string total, string payment, string status)
        {
            InitializeComponent();

            this.receiptNo = receiptNo;
            this.date = date;
            this.time = time;
            this.customer = customer;
            this.total = total;
            this.payment = payment;
            this.status = status;

            Load += View_Load;

            // 🔹 Make form draggable via top panel or the whole form
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // 🔹 Make guna2Panel1 draggable
            guna2Panel1.MouseDown += Form_MouseDown;
            guna2Panel1.MouseMove += Form_MouseMove;
            guna2Panel1.MouseUp += Form_MouseUp;
        }

        private void View_Load(object sender, EventArgs e)
        {
            // 🔹 Load transaction_id from the database
            LoadTransactionID();

            // Fill UI values
            ReceiptNumber_Click(null, null);
            TransactionDate_Click(null, null);
            TransactionTime_Click(null, null);
            PaymentMethod_Click(null, null);
            TotalAmount_Click(null, null);
            TransactionSource_Click(null, null);
            TransactionID_Click(null, null);

            LoadItems();
        }

        // 🔹 Load actual transaction_id (first transaction in this receipt)
        private void LoadTransactionID()
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = @"
                    SELECT transaction_id 
                    FROM transactions 
                    WHERE receipt_no = @receipt
                    ORDER BY transaction_id ASC
                    LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receipt", receiptNo);
                    var result = cmd.ExecuteScalar();
                    transactionID = result != null ? result.ToString() : "";
                }
            }
        }

        // 🔹 LOAD ALL ITEMS UNDER SAME RECEIPT
        private void LoadItems()
        {
            DataTable itemsTable = new DataTable();

            using (var conn = DBconnection.GetConnection())
            {
                string query = @"
                    SELECT 
                        item_name AS Item,
                        quantity AS Quantity,
                        CONCAT('₱', FORMAT(unit_price,2)) AS Price,
                        CONCAT('₱', FORMAT(total_amount,2)) AS Total
                    FROM transactions
                    WHERE receipt_no = @receipt
                    ORDER BY transaction_id ASC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receipt", receiptNo);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(itemsTable);
                    }
                }
            }

            ItemsDataGrid.DataSource = itemsTable;

            // 🔹 Set headers
            if (ItemsDataGrid.Columns.Contains("Item"))
                ItemsDataGrid.Columns["Item"].HeaderText = "Item Name";
            if (ItemsDataGrid.Columns.Contains("Quantity"))
                ItemsDataGrid.Columns["Quantity"].HeaderText = "Qty";
            if (ItemsDataGrid.Columns.Contains("Price"))
                ItemsDataGrid.Columns["Price"].HeaderText = "Price";
            if (ItemsDataGrid.Columns.Contains("Total"))
                ItemsDataGrid.Columns["Total"].HeaderText = "Total";

            // 🔹 Make it read-only
            ItemsDataGrid.ReadOnly = true;

            // 🔹 Show column headers
            ItemsDataGrid.ColumnHeadersVisible = true;

            // 🔹 Prevent adding/deleting rows
            ItemsDataGrid.AllowUserToAddRows = false;
            ItemsDataGrid.AllowUserToDeleteRows = false;

            // 🔹 Auto size columns
            ItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 🔹 Fix header height and style
            ItemsDataGrid.ColumnHeadersHeight = 40;
            ItemsDataGrid.EnableHeadersVisualStyles = false;
            ItemsDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ItemsDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        // 🔹 Form dragging logic
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TotalAmount_Click(object sender, EventArgs e)
        {
            TotalAmount.Text = total;
        }

        private void PaymentMethod_Click(object sender, EventArgs e)
        {
            PaymentMethod.Text = payment;
        }

        private void ReceiptNumber_Click(object sender, EventArgs e)
        {
            ReceiptNumber.Text = receiptNo;
        }

        private void TransactionID_Click(object sender, EventArgs e)
        {
            TransactionID.Text = transactionID;
        }

        private void TransactionDate_Click(object sender, EventArgs e)
        {
            TransactionDate.Text = date;
        }

        private void TransactionTime_Click(object sender, EventArgs e)
        {
            TransactionTime.Text = time;
        }

        private void TransactionSource_Click(object sender, EventArgs e)
        {
            TransactionSource.Text = status;
        }

        private void ItemsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.Red;
        }

        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.Transparent;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel38_Click(object sender, EventArgs e) { }
    }
}