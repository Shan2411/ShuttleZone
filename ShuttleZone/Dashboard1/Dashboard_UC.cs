using Guna.UI2.WinForms;
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
    public partial class Dashboard_UC : UserControl
    {
        public Dashboard_UC()
        {
            InitializeComponent();

            flowLayoutPanel1.VerticalScroll.Enabled = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;

            Card_Dashboard card1 = new Card_Dashboard("Daily Sales");
            Card_Dashboard card2 = new Card_Dashboard("Active Rentals");
            Card_Dashboard card3 = new Card_Dashboard("Available Equipments");
            Card_Dashboard card4 = new Card_Dashboard("Available Courts");

            flowLayoutPanel1.Controls.Add(card1);
            flowLayoutPanel1.Controls.Add(card2);
            flowLayoutPanel1.Controls.Add(card3);
            flowLayoutPanel1.Controls.Add(card4);
        }

 

    }
}
