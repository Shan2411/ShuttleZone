using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Kio_sk
{
    public partial class Kiosk_Receipt : Form
    {
        private List<CartItem> cartItems;
        private decimal amountReceived;
        private string paymentMethod;
        private DateTime transactionTime;
        private int courtHours;

        public Kiosk_Receipt(List<CartItem> cartItems, decimal amountReceived, string paymentMethod, DateTime transactionTime, int courtHours)
        {
            InitializeComponent();

            this.cartItems = cartItems;
            this.amountReceived = amountReceived;
            this.paymentMethod = paymentMethod;
            this.transactionTime = transactionTime;
            this.courtHours = courtHours;
        }

        private void Kiosk_Receipt_Load(object sender, EventArgs e)
        {
            // Date and Time
            lblPendingDate.Text = transactionTime.ToString("MMMM dd, yyyy");
            lblPendingTime.Text = transactionTime.ToString("hh:mm tt");

            // Generate and display stub number, save to DB
            string stubNo = GenerateAndSaveStub();
            lblPendingStubNo.Text = stubNo;

            // Total
            decimal total = cartItems.Sum(c => c.Price * c.Qty);
            lblPendingTotalAmount.Text = $"₱{total:F2}";

            // Generate item rows
            foreach (var item in cartItems)
            {
                var row = CloneItemRow(item.Name, item.Qty, item.Price * item.Qty);
                flowPendingItemsContainer.Controls.Add(row); // replace flowPendingItems with your FlowLayoutPanel name
            }
        }

        private string GenerateAndSaveStub()
        {
            string stubNo = "";

            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = "INSERT INTO kiosk_pending_payments (status) VALUES ('Pending'); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        int id = Convert.ToInt32(result);
                        stubNo = $"STUB-{id:D5}"; // e.g. STUB-00001
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving stub: {ex.Message}");
                stubNo = "STUB-ERROR";
            }

            return stubNo;
        }

        private Panel CloneItemRow(string itemName, int qty, decimal rowTotal)
        {
            var clone = new Panel
            {
                Size = pnlPendingItemRowTemplate.Size,
                Margin = pnlPendingItemRowTemplate.Margin,
                Visible = true
            };

            foreach (Control c in pnlPendingItemRowTemplate.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(c.GetType());
                newCtrl.Size = c.Size;
                newCtrl.Location = c.Location;
                newCtrl.Font = c.Font;
                newCtrl.Name = c.Name;
                clone.Controls.Add(newCtrl);
            }

            clone.Controls["lblItemName"].Text = itemName;
            clone.Controls["lblItemQtty"].Text = qty.ToString();
            clone.Controls["lblItemPrice"].Text = $"₱{rowTotal:F2}";

            return clone;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
