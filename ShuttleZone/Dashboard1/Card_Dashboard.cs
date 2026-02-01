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
                case "daily sales":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Money;
                    label1.Text = "PHP 100,000.00"; 
                    break;
                case "active rentals":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Time;
                    label1.Text = "9";
                    break;
                case "available equipments":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Box;
                    label1.Text = "42";
                    break;
                case "available courts":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Grid;
                    label1.Text = "2/4";
                    break;
                default:

                    break;
            }

        }

    }

}
