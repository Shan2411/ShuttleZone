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

            switch (categorySwitchCase.ToLower())
            {
                case "daily dales":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Money;
                    break;
                case "active rentals":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Time;
                    break;
                case "available equipments":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Box;
                    break;
                case "available courts":
                    guna2PictureBox1.Image = Properties.Resources.Dashboard_Grid;
                    break;
                default:

                    break;
            }

        }
    }
}
