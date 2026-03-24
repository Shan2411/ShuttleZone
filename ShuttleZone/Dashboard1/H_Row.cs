using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class H_Row : UserControl
    {
        public H_Row(string transactionID, string payment, string amount, DateTime time)
        {
            InitializeComponent();

            guna2HtmlLabel2.Text = transactionID;
            guna2HtmlLabel4.Text = payment;
            guna2HtmlLabel5.Text = amount;
            guna2HtmlLabel6.Text = time.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
