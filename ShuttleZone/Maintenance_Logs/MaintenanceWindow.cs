using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Maintenance_Logs
{
    public partial class MaintenanceWindow : UserControl
    {
        public MaintenanceWindow()
        {
            InitializeComponent();

            MButton court1_button = new MButton();
            MButton court2_button = new MButton();
            MButton court3_button = new MButton();
            MButton court4_button = new MButton();

            tableLayoutPanel5.Controls.Clear();

            // status should come from database l8r
            string statusFromDB = "operational";
            tableLayoutPanel5.Controls.Add(new MButton("Court A", statusFromDB), 1, 1);
            tableLayoutPanel5.Controls.Add(new MButton("Court B", "under maintenance"), 3, 1);
            tableLayoutPanel5.Controls.Add(new MButton("Court C", statusFromDB), 5, 1);
            tableLayoutPanel5.Controls.Add(new MButton("Court D", "out of service"), 7, 1);

        }

        private void MaintenanceWindow_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_3(object sender, PaintEventArgs e)
        {

        }
    }
}
