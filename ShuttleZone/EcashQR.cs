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
    public partial class EcashQR : Form
    {
        public event EventHandler PaymentCompleted;

        public EcashQR()
        {
            InitializeComponent();
            btnPaymentComplete.Click += BtnPaymentComplete_Click;
            btnCancelEcashPayment.Click += BtnCancelEcashPayment_Click;
        }

        public EcashQR(decimal totalAmount)
        {
            InitializeComponent();
            btnPaymentComplete.Click += BtnPaymentComplete_Click;
            btnCancelEcashPayment.Click += BtnCancelEcashPayment_Click;
            lblTotalAmount.Text = $"₱{totalAmount:0.00}";
        }

        private void BtnPaymentComplete_Click(object sender, EventArgs e)
        {
            PaymentCompleted?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void BtnCancelEcashPayment_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPaymentComplete_Click_1(object sender, EventArgs e)
        {

        }
    }
}
