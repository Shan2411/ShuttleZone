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

            //click
            guna2Panel1.Click += Guna2Panel1_Click;
            AttachClickHandlers(guna2Panel1);
            //hover
            guna2Panel1.MouseEnter += Guna2Panel1_MouseEnter;
            guna2Panel1.MouseLeave += Guna2Panel1_MouseLeave;
        }

        private void Guna2Panel1_Click(object sender, EventArgs e) // parent
        {
            MessageBox.Show("Guna2Panel clicked!");
        }

        private void AttachClickHandlers(Control parent) // Makes the children clickable
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += (s, e) => Guna2Panel1_Click(s, e);

                // Make hover effect work on child controls too
                c.MouseEnter += (s, e) => Guna2Panel1_MouseEnter(s, e);
                c.MouseLeave += (s, e) => Guna2Panel1_MouseLeave(s, e);

                if (c.HasChildren)
                    AttachClickHandlers(c);
            }
        }


        private void Guna2Panel1_MouseEnter(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(213, 236, 205); 
        }
        private void Guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = Color.FromArgb(202, 231, 192);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
