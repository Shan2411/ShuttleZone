using System;
using System.Windows.Forms;
using System.Drawing;

namespace ShuttleZone.Rent_History
{
    public partial class View : Form
    {
        string id, date, time, customer, total, payment, status;

        // ✅ REQUIRED for Designer
        public View()
        {
            InitializeComponent();
        }

        public View(string id, string date, string time, string customer, string total, string payment, string status)
        {
            InitializeComponent();

            this.id = id;
            this.date = date;
            this.time = time;
            this.customer = customer;
            this.total = total;
            this.payment = payment;
            this.status = status;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // optional
        }

        private void guna2HtmlLabel38_Click(object sender, EventArgs e)
        {
            // optional
        }
    }
}