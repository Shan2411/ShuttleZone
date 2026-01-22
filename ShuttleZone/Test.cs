using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuttleZone.Maintenance_Logs;

namespace ShuttleZone
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            MaintenanceWindow uc = new MaintenanceWindow();

            tableLayoutPanel1.Controls.Add(uc, 1, 0);
            uc.Dock = DockStyle.Fill;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
