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

namespace ShuttleZone
{
    public partial class CashPayment : Form
    {
        private decimal _amountDue;
        private List<CartItem> _cartItems;


        public CashPayment(decimal amountDue, List<CartItem> cartItems)
        {
            InitializeComponent();
            _amountDue = amountDue;

            // Make a copy of the list to avoid reference issues
            _cartItems = new List<CartItem>(cartItems);

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

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCash.Text, out decimal cash))
            {
                MessageBox.Show("Please enter valid cash amount.");
                return;
            }

            if (cash < _amountDue)
            {
                MessageBox.Show("Insufficient cash.");
                return;
            }

            DateTime timeIssued = DateTime.Now;
            int courtHours = _cartItems.FirstOrDefault(c => c.Name.StartsWith("Court"))?.Qty ?? 0;

            ReceiptForm receiptForm = new ReceiptForm(
                _cartItems,
                cash,
                "Cash",
                timeIssued,
                courtHours
            );
            receiptForm.Show();

            //this part changes the status to "in use" once sale of court is made

            foreach (var item in _cartItems)
            {
                if (item.Name.StartsWith("Court"))
                {
                    string courtName = item.Name.Contains("-")
                        ? item.Name.Split('-')[0].Trim()
                        : item.Name.Trim();

                    try
                    {
                        using (MySqlConnection conn = DBconnection.GetConnection())
                        {
                            string sql = @"UPDATE courts 
                               SET status = 'In Use', 
                                   status_reason = 'Paid via Cash'
                               WHERE court_name = @CourtName";

                            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@CourtName", courtName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update court status.\n\n" + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            this.Close();
        }
    }
}

