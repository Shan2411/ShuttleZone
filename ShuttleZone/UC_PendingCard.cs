using MySql.Data.MySqlClient;
using ShuttleZone.database;
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
    }
}