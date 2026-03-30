using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShuttleZone.database;

namespace ShuttleZone
{
    public partial class ReceiptForm : Form
    {
        private readonly List<CartItem> _cartItems;
        private readonly decimal _amountReceived;
        private readonly string _paymentMethod;
        private readonly DateTime _timeIssued;
        private readonly int _courtRentalHours;
        private readonly string _receiptNo;
        private readonly bool _shouldSave; // NEW: decide whether to save to DB

        public ReceiptForm(
            List<CartItem> cartItems,
            decimal amountReceived,
            string paymentMethod,
            DateTime timeIssued,
            int courtRentalHours = 0,
            string receiptNo = null,
            bool shouldSave = true) // default true
        {
            InitializeComponent();
            TopMost = true;

            _cartItems = cartItems;
            _amountReceived = amountReceived;
            _paymentMethod = paymentMethod;
            _timeIssued = timeIssued;
            _courtRentalHours = courtRentalHours;
            _receiptNo = receiptNo;
            _shouldSave = shouldSave;

            GenerateReceipt();
        }

        private void GenerateReceipt()
        {
            // 1. Clear existing items
            flowItemsContainer.Controls.Clear();

            // 2. Generate rows dynamically
            foreach (var item in _cartItems)
            {
                Panel row = new Panel
                {
                    Size = pnlItemRowTemplate.Size,
                    BackColor = pnlItemRowTemplate.BackColor
                };

                Label lblName = new Label
                {
                    Text = item.Name,
                    Location = pnlItemRowTemplate.Controls["lblItemName"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemName"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemName"].Font
                };
                row.Controls.Add(lblName);

                Label lblQty = new Label
                {
                    Text = item.Qty.ToString(),
                    Location = pnlItemRowTemplate.Controls["lblItemQty"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemQty"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemQty"].Font
                };
                row.Controls.Add(lblQty);

                Label lblPrice = new Label
                {
                    Text = (item.Price * item.Qty).ToString("₱0.00"),
                    Location = pnlItemRowTemplate.Controls["lblItemPrice"].Location,
                    Size = pnlItemRowTemplate.Controls["lblItemPrice"].Size,
                    Font = pnlItemRowTemplate.Controls["lblItemPrice"].Font
                };
                row.Controls.Add(lblPrice);

                flowItemsContainer.Controls.Add(row);
            }

            // 3. Compute totals
            decimal totalAmount = _cartItems.Sum(x => x.Price * x.Qty);
            lblTotalAmount.Text = totalAmount.ToString("₱0.00");
            lblPaymentMethod.Text = _paymentMethod;
            lblAmountReceived.Text = _amountReceived.ToString("₱0.00");
            decimal change = _amountReceived - totalAmount;
            lblChange.Text = change >= 0 ? change.ToString("₱0.00") : "₱0.00";

            // 4. Receipt number and timestamps
            string receiptNo = _receiptNo ?? GenerateReceiptNumber();
            lblReceiptNo.Text = receiptNo;
            lblDateIssued.Text = _timeIssued.ToString("MM/dd/yyyy");
            lblTimeIssued.Text = _timeIssued.ToString("hh:mm:ss tt");

            // 5. Court rental due time
            lblDueTime.Text = _courtRentalHours > 0
                ? _timeIssued.AddHours(_courtRentalHours).ToString("hh:mm:ss tt")
                : "-";

            /*
            // 6. Conditionally save to database
            if (_shouldSave)
            {
                TransactionRecorder.SaveFromCart(
                    receiptNo,
                    _timeIssued,
                    _cartItems,
                    _paymentMethod,
                    "Kiosk"
                );
            }*/


        }

        private string GenerateReceiptNumber()
        {
            return "Receipt-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── EMPTY PLACEHOLDER EVENTS ──
        private void pnlItemRowTemplate_Paint(object sender, PaintEventArgs e) { }
        private void flowItemsContainer_Paint(object sender, PaintEventArgs e) { }
    }
}