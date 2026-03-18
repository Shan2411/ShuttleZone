using Guna.UI2.WinForms;
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
    public partial class CourtCardInUse : UserControl
    {
        public CourtCardInUse(string courtname, string color)
        {
            InitializeComponent();

            label1.Text = courtname;
            changeColorforStatus(color);
            guna2Button2.Text = color;
        }

        public void changeColorforStatus(string statusForColor)
        {
            switch (statusForColor.ToLower())
            {
                case "operational":
                    guna2Panel1.FillColor = Color.FromArgb(150, 205, 135);       // slightly stronger green
                    guna2Panel1.BorderColor = Color.FromArgb(75, 120, 60);       // much darker green border
                    break;
                case "in use":
                    guna2Panel1.FillColor = Color.FromArgb(100, 160, 255);       // slightly stronger blue
                    guna2Panel1.BorderColor = Color.FromArgb(40, 90, 175);       // much darker blue border
                    break;
                case "maintenance":
                    guna2Panel1.FillColor = Color.FromArgb(255, 210, 80);        // slightly stronger yellow
                    guna2Panel1.BorderColor = Color.FromArgb(175, 130, 20);      // much darker yellow border
                    break;
                case "out of service":
                    guna2Panel1.FillColor = Color.FromArgb(255, 120, 120);       // slightly stronger red
                    guna2Panel1.BorderColor = Color.FromArgb(175, 50, 50);       // much darker red border
                    break;
                default:
                    guna2Panel1.FillColor = Color.Black;
                    guna2Panel1.BorderColor = Color.FromArgb(20, 20, 20);
                    break;
            }
        }

    }
}
