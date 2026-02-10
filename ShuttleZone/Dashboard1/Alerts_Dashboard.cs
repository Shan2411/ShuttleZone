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
    public partial class Alerts_Dashboard : UserControl
    {
        public Alerts_Dashboard(string color, string comment)
        {
            InitializeComponent();

            switch (color)
            {
                case "Red":
                    guna2Panel1.FillColor = Color.FromArgb(255, 192, 192);
                    break;
                case "Green":
                    guna2Panel1.FillColor = Color.FromArgb(128, 255, 128);
                    break;
                case "Yellow":
                    guna2Panel1.FillColor = Color.FromArgb(255, 255, 128);
                    break;
                default:
                    guna2Panel1.FillColor = Color.FromArgb(200, 200, 200);
                    break;
            }

            label1.Text = comment;


        }
    }
}
