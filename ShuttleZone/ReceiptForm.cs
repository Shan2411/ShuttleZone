using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class Receipt : Form
    {
        private List<CartItem> _cartItems;
        private decimal _amountReceived;
        private string _paymentMethod;
        private DateTime _timeIssued;

        private int _courtRentalHours = 0; // optional, set if any court rental

        public Receipt(List<CartItem> cartItems, decimal amountReceived, string paymentMethod, DateTime timeIssued, int courtRentalHours = 0)
        {
            InitializeComponent();

            _cartItems = cartItems;
            _amountReceived = amountReceived;
            _paymentMethod = paymentMethod;
            _timeIssued = timeIssued;
            _courtRentalHours = courtRentalHours;

            GenerateReceipt();
        }

        private void GenerateReceipt()
        {
            // 1️⃣ Clear existing items
            flowItemsContainer.Controls.Clear();

            // 2️⃣ Generate rows dynamically based on pnlItemRowTemplate
            foreach (var item in _cartItems)
            {
                Panel row = new Panel
                {
                    Size = pnlItemRowTemplate.Size,
                    BackColor = pnlItemRowTemplate.BackColor
                };

                // Item Name
                Label lblName = new Label
                {
                    Text = item.Name,
                    Location = pnlItemRowTemplate.Controls["lblItemName"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemName"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemName"].Font
                };
                row.Controls.Add(lblName);

                // Item Quantity
                Label lblQty = new Label
                {
                    Text = item.Qty.ToString(),
                    Location = pnlItemRowTemplate.Controls["lblItemQty"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemQty"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemQty"].Font
                };
                row.Controls.Add(lblQty);

                // Item Price (total for this row)
                Label lblPrice = new Label
                {
                    Text = (item.Price * item.Qty).ToString("₱0.00"),
                    Location = pnlItemRowTemplate.Controls["lblItemPrice"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemPrice"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemPrice"].Font
                };
                row.Controls.Add(lblPrice);

                // Add row to flow panel
                flowItemsContainer.Controls.Add(row);
            }

            // 3️⃣ Compute totals
            decimal totalAmount = _cartItems.Sum(x => x.Price * x.Qty);
            lblTotalAmount.Text = totalAmount.ToString("₱0.00");

            lblPaymentMethod.Text = _paymentMethod;
            lblAmountReceived.Text = _amountReceived.ToString("₱0.00");

            decimal change = _amountReceived - totalAmount;
            lblChange.Text = change >= 0 ? change.ToString("₱0.00") : "₱0.00";

            // 4️⃣ Set receipt numbers and timestamps
            lblReceiptNo.Text = GenerateReceiptNumber();
            lblDateIssued.Text = _timeIssued.ToString("MM/dd/yyyy");
            lblTimeIssued.Text = _timeIssued.ToString("hh:mm:ss tt");

            // 5️⃣ Compute due time for court rental (if any)
            if (_courtRentalHours > 0)
            {
                DateTime dueTime = _timeIssued.AddHours(_courtRentalHours);
                lblDueTime.Text = dueTime.ToString("hh:mm:ss tt");
            }
            else
            {
                lblDueTime.Text = "-";
            }
        }

        private string GenerateReceiptNumber()
        {
            // Example: random 6-digit number
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}