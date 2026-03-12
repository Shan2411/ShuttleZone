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
    public partial class Stub : Form
    {
        private readonly List<CartItem> _cartItems;
        private readonly decimal _subtotal;
        private readonly decimal _total;
        private readonly DateTime _timeIssued;

        public Stub()
        {
            InitializeComponent();
            WireCloseButton();
        }

        public Stub(List<CartItem> cartItems, decimal subtotal, decimal total, DateTime timeIssued)
        {
            InitializeComponent();
            WireCloseButton();
            _cartItems = cartItems;
            _subtotal = subtotal;
            _total = total;
            _timeIssued = timeIssued;
            GenerateStub();
        }

        private void WireCloseButton()
        {
            var button = Controls.Find("btnStubClose", true).FirstOrDefault();
            if (button != null)
            {
                button.Click += (s, e) => Close();
            }
        }

        private void GenerateStub()
        {
            flowStubItemsContainer.Controls.Clear();

            foreach (var item in _cartItems)
            {
                Panel row = new Panel
                {
                    Size = pnlStubItemRowTemplate.Size,
                    BackColor = pnlStubItemRowTemplate.BackColor
                };

                Label lblName = new Label
                {
                    Text = item.Name,
                    Location = pnlStubItemRowTemplate.Controls["lblStubItemName"].Location,
                    Size = pnlStubItemRowTemplate.Controls["lblStubItemName"].Size,
                    Font = pnlStubItemRowTemplate.Controls["lblStubItemName"].Font
                };
                row.Controls.Add(lblName);

                Label lblQty = new Label
                {
                    Text = $"₱{item.Price:0.00} x {item.Qty}",
                    Location = pnlStubItemRowTemplate.Controls["lblStubItemQty"].Location,
                    Size = pnlStubItemRowTemplate.Controls["lblStubItemQty"].Size,
                    Font = pnlStubItemRowTemplate.Controls["lblStubItemQty"].Font
                };
                row.Controls.Add(lblQty);

                Label lblPrice = new Label
                {
                    Text = (item.Price * item.Qty).ToString("₱0.00"),
                    Location = pnlStubItemRowTemplate.Controls["lblStubItemPrice"].Location,
                    Size = pnlStubItemRowTemplate.Controls["lblStubItemPrice"].Size,
                    Font = pnlStubItemRowTemplate.Controls["lblStubItemPrice"].Font
                };
                row.Controls.Add(lblPrice);

                flowStubItemsContainer.Controls.Add(row);
            }

            lblStubSubtotal.Text = _subtotal.ToString("₱0.00");
            lblStubTotalAmount.Text = _total.ToString("₱0.00");

            lblStubNo.Text = GenerateStubNumber();
            lblStubDateIssued.Text = _timeIssued.ToString("MM/dd/yyyy");
            lblStubTimeIssued.Text = _timeIssued.ToString("hh:mm:ss tt");
        }

        private string GenerateStubNumber()
        {
            Random rnd = new Random();
            return $"S#{rnd.Next(1000, 9999)}";
        }

        private void pnlItemRowTemplate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowItemsContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
