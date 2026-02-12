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
    public partial class CashPayment : Form
    {
        private decimal _amountDue;

        public CashPayment(decimal amountDue)
        {
            InitializeComponent();
            _amountDue = amountDue;

            lblAmountDue.Text = "₱" + _amountDue.ToString("N2");
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            ComputeChange();
        }

        private void ComputeChange()
        {
            if (!decimal.TryParse(txtCash.Text, out decimal cash))
            {
                lblChangeText.Text = "CHANGE";
                lblChange.Text = "₱0.00";
                return;
            }

            decimal diff = cash - _amountDue;

            if (diff >= 0)
            {
                lblChangeText.Text = "CHANGE";
                lblChangeText.ForeColor = Color.DarkGreen;

                lblChange.Text = "₱" + diff.ToString("N2");
                lblChange.ForeColor = Color.FromArgb(0, 130, 60);
            }
            else
            {
                lblChangeText.Text = "INSUFFICIENT";
                lblChangeText.ForeColor = Color.DarkRed;

                lblChange.Text = "Short by ₱" + Math.Abs(diff).ToString("N2");
                lblChange.ForeColor = Color.DarkRed;
            }
        }

        private void AddCash(decimal amount)
        {
            decimal current = 0;

            if (!string.IsNullOrWhiteSpace(txtCash.Text))
                decimal.TryParse(txtCash.Text, out current);

            current += amount;
            txtCash.Text = current.ToString("0.##");   // no ₱ symbol inside textbox
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            AddCash(100);
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            AddCash(200);
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            AddCash(500);
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            AddCash(1000);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // closes CashPayment form
        }


    }
}

