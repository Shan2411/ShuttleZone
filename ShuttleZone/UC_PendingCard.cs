using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_PendingCard : UserControl
    {
        public UC_PendingCard(string stubNo)
        {
            InitializeComponent();
            LoadCard(stubNo);
        }

        private void LoadCard(string stubNo)
        {
            decimal grandTotal = 0;

            // Hide the designer template row — we'll clone it for each real item
            pnlPendingItemRowTemplate.Visible = false;

            using (var conn = DBconnection.GetConnection())
            {
                string query = @"SELECT item_name, quantity, unit_price, total_amount, 
                                        date_issued, time_issued 
                                 FROM kiosk_pending_payments 
                                 WHERE stub_no = @stub 
                                 ORDER BY id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@stub", stubNo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        bool firstRow = true;

                        while (reader.Read())
                        {
                            // Set header info once from the first row
                            if (firstRow)
                            {
                                lblPendingStubNo.Text = stubNo;
                                lblPendingDate.Text = reader["date_issued"].ToString();
                                lblPendingTime.Text = reader["time_issued"].ToString();
                                firstRow = false;
                            }

                            string itemName = reader["item_name"].ToString();
                            int qty = int.Parse(reader["quantity"].ToString());
                            decimal unitPrice = decimal.Parse(reader["unit_price"].ToString());
                            decimal total = decimal.Parse(reader["total_amount"].ToString());

                            grandTotal += total;

                            // Clone the template row panel
                            var row = new Guna.UI2.WinForms.Guna2Panel();
                            row.Size = pnlPendingItemRowTemplate.Size;
                            row.Margin = pnlPendingItemRowTemplate.Margin;

                            var lblName = new Label();
                            lblName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                            lblName.AutoSize = true;
                            lblName.Location = new Point(17, 5);
                            lblName.Text = itemName;

                            var lblPrice = new Label();
                            lblPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                            lblPrice.AutoSize = true;
                            lblPrice.Location = new Point(329, 5);
                            lblPrice.Text = $"₱{total:N2}";

                            var lblQty = new Label();
                            lblQty.Font = new Font("Segoe UI", 8.25F);
                            lblQty.AutoSize = true;
                            lblQty.Location = new Point(17, 23);
                            lblQty.BackColor = Color.Transparent;
                            lblQty.Text = $"₱{unitPrice:N2} x {qty}";

                            row.Controls.Add(lblName);
                            row.Controls.Add(lblPrice);
                            row.Controls.Add(lblQty);

                            flowPendingItemsContainer.Controls.Add(row);
                        }
                    }
                }
            }

            lblPendingTotalAmount.Text = $"₱{grandTotal:N2}";
        }

        private void btnPaymentCleared_Click(object sender, System.EventArgs e)
        {
            string stubNo = lblPendingStubNo.Text;

            DialogResult confirm = MessageBox.Show(
                $"Confirm payment cleared for Stub #{stubNo}?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    // 1. Fetch all pending rows for this stub
                    string selectQuery = @"
                SELECT item_name, quantity, unit_price, total_amount, date_issued, time_issued 
                FROM kiosk_pending_payments 
                WHERE stub_no = @stub";

                    var rows = new List<(string itemName, int qty, decimal unitPrice, decimal total, string date, string time)>();

                    using (var cmd = new MySqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@stub", stubNo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rows.Add((
                                    reader["item_name"].ToString(),
                                    int.Parse(reader["quantity"].ToString()),
                                    decimal.Parse(reader["unit_price"].ToString()),
                                    decimal.Parse(reader["total_amount"].ToString()),
                                    reader["date_issued"].ToString(),
                                    reader["time_issued"].ToString()
                                ));
                            }
                        }
                    }

                    // 2. Generate a receipt number
                    string receiptNo = "KIOSK-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + stubNo;

                    // 3. Insert each row into transactions
                    string insertQuery = @"
                INSERT INTO transactions 
                    (receipt_no, transaction_date, transaction_time, income_type, 
                     item_name, quantity, unit_price, total_amount, payment_method, 
                     created_at, transaction_source)
                VALUES 
                    (@receipt_no, @transaction_date, @transaction_time, 'Sales',
                     @item_name, @quantity, @unit_price, @total_amount, 'Cash',
                     NOW(), 'Kiosk')";

                    foreach (var row in rows)
                    {
                        using (var cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_no", receiptNo);
                            cmd.Parameters.AddWithValue("@transaction_date", row.date);
                            cmd.Parameters.AddWithValue("@transaction_time", row.time);
                            cmd.Parameters.AddWithValue("@item_name", row.itemName);
                            cmd.Parameters.AddWithValue("@quantity", row.qty);
                            cmd.Parameters.AddWithValue("@unit_price", row.unitPrice);
                            cmd.Parameters.AddWithValue("@total_amount", row.total);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. Delete all rows with this stub from kiosk_pending_payments
                    string deleteQuery = "DELETE FROM kiosk_pending_payments WHERE stub_no = @stub";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@stub", stubNo);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Payment cleared and recorded for Stub #{stubNo}.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Remove the card from the UI
                    this.Parent?.Controls.Remove(this);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            string stubNo = lblPendingStubNo.Text;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to remove Stub #{stubNo}?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    string deleteQuery = "DELETE FROM kiosk_pending_payments WHERE stub_no = @stub";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@stub", stubNo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Stub #{stubNo} has been removed.",
                    "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remove the card from the UI
                this.Parent?.Controls.Remove(this);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing stub: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}