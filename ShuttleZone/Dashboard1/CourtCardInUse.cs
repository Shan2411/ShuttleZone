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
        }

        public void changeColorforStatus(string statusForColor)
        {
            switch (statusForColor.ToLower())
            {
                case "inuse":
                    guna2Panel1.FillColor = Color.FromArgb(202, 231, 192);
                    
                    break;
                case "notinuse":
                    guna2Panel1.FillColor = Color.Gray;
                    
                    break;
                default:
                    guna2Panel1.FillColor = Color.Black;
                    break;
            }
        }

    }
}
