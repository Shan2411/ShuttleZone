using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace ShuttleZone
{
    public partial class UC_PendingCard : UserControl
    {
        public event EventHandler PaymentCleared; // Event to notify RentHistory

        public UC_PendingCard(string stubNo)
        {
            InitializeComponent();
            LoadCard(stubNo);
        }

        private void LoadCard(string stubNo)
        {
            decimal grandTotal = 0;
            pnlPendingItemRowTemplate.Visible = false;
            flowPendingItemsContainer.Controls.Clear();

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

                            var row = new Guna.UI2.WinForms.Guna2Panel
                            {
                                Size = pnlPendingItemRowTemplate.Size,
                                Margin = pnlPendingItemRowTemplate.Margin
                            };

                            var lblName = new Label
                            {
                                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                                AutoSize = true,
                                Location = new Point(17, 5),
                                Text = itemName
                            };

                            var lblPrice = new Label
                            {
                                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                                AutoSize = true,
                                Location = new Point(329, 5),
                                Text = $"₱{total:N2}"
                            };

                            var lblQty = new Label
                            {
                                Font = new Font("Segoe UI", 8.25F),
                                AutoSize = true,
                                Location = new Point(17, 23),
                                BackColor = Color.Transparent,
                                Text = $"₱{unitPrice:N2} x {qty}"
                            };

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

        private void btnPaymentCleared_Click(object sender, EventArgs e)
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
                    // Get pending rows
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

                    // 2. Check if any row is a court booking and validate its status
                    foreach (var row in rows)
                    {
                        string courtName = ExtractCourtName(row.itemName);
                        if (courtName == null) continue; // not a court item, skip

                        string courtStatus = GetCourtStatusFromDB(courtName, conn);
                        if (courtStatus == null) continue; // court not found, skip

                        if (!courtStatus.Equals("Operational", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show(
                                $"Cannot proceed with payment.\n\n" +
                                $"{courtName} is currently '{courtStatus}'.\n" +
                                $"Please wait until the court is available before clearing this stub.",
                                "Court Unavailable",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return; // block payment
                        }
                    }

                    // 3. Generate a receipt number
                    string receiptNo = "KIOSK-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + stubNo;

                    // 4. Insert each row into transactions
                    string insertQuery = @"
                        INSERT INTO transactions 
                            (receipt_no, transaction_date, transaction_time, income_type, 
                             item_name, quantity, unit_price, total_amount, payment_method, 
                             created_at, transaction_source)
                        VALUES 
                            (@receipt_no, CURDATE(), CURTIME(), 'Sales',
                             @item_name, @quantity, @unit_price, @total_amount, 'Cash',
                             NOW(), 'Kiosk')";

                    foreach (var row in rows)
                    {
                        using (var cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_no", receiptNo);
                            cmd.Parameters.AddWithValue("@item_name", row.itemName);
                            cmd.Parameters.AddWithValue("@quantity", row.qty);
                            cmd.Parameters.AddWithValue("@unit_price", row.unitPrice);
                            cmd.Parameters.AddWithValue("@total_amount", row.total);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 5. Delete from kiosk_pending_payments
                    string deleteQuery = "DELETE FROM kiosk_pending_payments WHERE stub_no = @stub";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@stub", stubNo);
                        cmd.ExecuteNonQuery();
                    }

                    // Notify RentHistory to refresh
                    PaymentCleared?.Invoke(this, EventArgs.Empty);

                    // 6. Show receipt
                    var cartItems = rows.Select(r => new CartItem
                    {
                        Name = r.itemName,
                        Qty = r.qty,
                        Price = r.unitPrice
                    }).ToList();

                    decimal grandTotal = rows.Sum(r => r.total);

                    var receipt = new ReceiptForm(cartItems, grandTotal, "Cash", DateTime.Now);
                    receipt.Show();

                    // 7. Remove card from UI
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

        // ── HELPERS ───────────────────────────────────────────────────────────────

        /// <summary>
        /// Extracts "Court A", "Court B" etc. from item names like "Court A - 1 Hour Rental".
        /// Returns null if the item is not a court booking.
        /// </summary>
        private string ExtractCourtName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName)) return null;

            // Matches "Court A", "Court B", "Court C", "Court D" at the start of the string
            foreach (var name in new[] { "Court A", "Court B", "Court C", "Court D" })
            {
                if (itemName.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    return name;
            }

            return null; // not a court item
        }

        /// <summary>
        /// Fetches the current status of a court from the DB.
        /// Reuses the existing open connection to avoid "connection already open" errors.
        /// </summary>
        private string GetCourtStatusFromDB(string courtName, MySqlConnection conn)
        {
            string query = "SELECT status FROM courts WHERE court_name = @court_name LIMIT 1";
            try
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_name", courtName);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch { return null; }
        }

        private void btnRemove_Click(object sender, EventArgs e)
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