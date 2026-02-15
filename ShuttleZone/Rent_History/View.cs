using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.Rent_History  
{
    public partial class View : Form
    {
   
        public View()
        {
            InitializeComponent();
        }

   
        public View(
            string transactionId,
            string dateTime,
            string court,
            string hours,
            string quantity,
            string amount,
            string payment,
            string status)
        {
            InitializeComponent();

            string[] parts = dateTime.Split(' ');
            string date = parts[0];
            string time = parts.Length > 1 ? parts[1] + " " + parts[2] : "";

            label3.Text = transactionId;
            lblDate.Text = date;
            lblTime.Text = time;
            lblCourt.Text = court;
            lblHours.Text = hours;
            lblQuantity.Text = quantity;
            lblAmount.Text = amount;
            lblPayment.Text = payment;
            lblStatus.Text = status;

            lblProcessed.Text = "Admin";

            if (status == "Completed")
                lblStatus.ForeColor = Color.Green;
            else if (status == "Cancelled")
                lblStatus.ForeColor = Color.Red;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
