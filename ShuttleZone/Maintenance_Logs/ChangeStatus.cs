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
    public partial class ChangeStatus : Form
    {
        public ChangeStatus()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;

            // status should come from database l8r
            string statusFromDB = "operational";
            flowLayoutPanel1.Controls.Add(new C_StatusButton(statusFromDB));
            flowLayoutPanel1.Controls.Add(new C_StatusButton("under maintenance"));
            flowLayoutPanel1.Controls.Add(new C_StatusButton("Out of Service"));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
