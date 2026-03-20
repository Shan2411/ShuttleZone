using System;
using System.Windows.Forms;
using System.Drawing;

namespace ShuttleZone.Rent_History
{
    public partial class View : Form
    {
        
    

string id, date, time, customer, total, payment, status;

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

       

        // CLOSE BUTTON (BOTTOM)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // CLOSE (X PICTUREBOX)
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // HOVER EFFECT (OPTIONAL)
        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.Red;
        }

        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            CloseBtn.BackColor = Color.Transparent;
        }

        // ESC KEY CLOSE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}