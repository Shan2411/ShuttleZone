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

            tableLayoutPanel5.Controls.Add(court1_button, 1, 0);
            tableLayoutPanel5.Controls.Add(court2_button, 3, 0);
            tableLayoutPanel5.Controls.Add(court3_button, 5, 0);
            tableLayoutPanel5.Controls.Add(court4_button, 7, 0);

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
