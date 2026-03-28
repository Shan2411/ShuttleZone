using ShuttleZone.Maintenance_Logs;
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
    public partial class Card_Dashboard : UserControl
    {
        public Card_Dashboard(String category)
        {
            InitializeComponent();

            label2.Text = category;

            loadPictures(category);
        }

        public void loadPictures(string categorySwitchCase)
        {

            switch (categorySwitchCase.ToLower()) // label1 texts should come from db 
            {
                case "today's transactions":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Money;
                    label1.Text = Globals.GetTodaysTransaction().ToString(); 
                    break;
                case "active rentals":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Time;
                    Globals.GetActiveRentals();
                    label1.Text = Globals.activeRentals.ToString() + "/4";
                    break;
                case "new memberships":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Person;
                    label1.Text = "2";
                    break;
                case "pending payments":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Grid;
                    label1.Text = "9";
                    break;

                //admin cases

                case "today's revenue":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Money;
                    label1.Text = "₱" + Globals.todaysRevenue.ToString("F2");
                    break;

                case "average monthly revenue":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Arrow;
                    label1.Text = "₱" + Globals.avgRevenue.ToString("F2");
                    break;

                case "total transactions":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Receipt;
                    label1.Text = Globals.totalTransactions.ToString();
                    break;

                case "active members":
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Person;
                    label1.Text = Globals.activeMemberships.ToString();
                    break;

                // manager cases

                case "kiosk transactions":
                      guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Money;
                      label1.Text = Globals.kioskTransactions().ToString();
                    break;

                case "peak hour today":
                    Globals.GetPeakHourToday();
                    guna2PictureBox1.Image = global::ShuttleZone.Properties.Resources.Dashboard_Time;
                    label1.Text = Globals.peakHourTodayFormatted;
                    break;

                default:

                    break;
            }

        }

    }

}
