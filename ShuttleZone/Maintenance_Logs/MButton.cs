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
        public MButton(string courtName = "", string status = "")
        {
            InitializeComponent();

            //click
            guna2Panel1.Click += Guna2Panel1_Click;
            AttachClickHandlers(guna2Panel1);
            //hover
            guna2Panel1.MouseEnter += Guna2Panel1_MouseEnter;
            guna2Panel1.MouseLeave += Guna2Panel1_MouseLeave;
            //load ng court may panagalan
            label1.Text = courtName;


            // COLORS PART PER STATUS 
            label2.Text = status;
            changeColorforStatus(status);


        }

        private void Guna2Panel1_Click(object sender, EventArgs e) // parent
        {
            ChangeStatus changeStatusForm = new ChangeStatus();
            changeStatusForm.Show();
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
            guna2Panel1.Size = new Size(385, 441);
        }
        private void Guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.Size = new Size(285, 341);
        }

        public void changeColorforStatus(string statusForColor)
        {
            switch (statusForColor.ToLower())
            {
                case "operational":
                    guna2Panel1.FillColor = Color.FromArgb(202, 231, 192);
                    guna2CirclePictureBox1.Image = Properties.Resources.Operational;
                    break;
                case "under maintenance":
                    guna2Panel1.FillColor = Color.Orange;
                    guna2CirclePictureBox1.Image = Properties.Resources.Maintenance1;
                    break;
                case "out of service":
                    guna2Panel1.FillColor = Color.Red;
                    guna2CirclePictureBox1.Image = Properties.Resources.Not;
                    break;
                default:
                    guna2Panel1.FillColor = Color.Black;
                    break;
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
