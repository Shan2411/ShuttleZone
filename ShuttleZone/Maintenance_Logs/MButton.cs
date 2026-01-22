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

namespace ShuttleZone.Maintenance_Logs
{
    public partial class MButton : UserControl
    {
        public MButton()
        {
            InitializeComponent();

        }

        private void guna2Panel1_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(45, 45, 45);
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.Transparent;
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(60, 60, 60);
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(45, 45, 45);
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
