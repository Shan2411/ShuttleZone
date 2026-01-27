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
    public partial class C_StatusButton : UserControl
    {
        public string statusType; // so it will be accessible file wide
        private bool ItIsClicked;
        public C_StatusButton(string statusType)
        {

            InitializeComponent();
            bool ItIsClicked = false;
            this.statusType = statusType;
            this.ItIsClicked = ItIsClicked;

            //click
            guna2Panel1.Click += Guna2Panel1_Click;
            AttachClickHandlers(guna2Panel1); //Makes children clickable
            

            // Labels text
            label1.Text = statusType;
        }
        public void Guna2Panel1_Click(object sender, EventArgs e) // parent
        {
            this.OnClick(e); 
        }

        public void SelectButton()
        {
            ItIsClicked = true;
            changeColorforStatus(statusType);
        }

        public void DeselectButton()
        {
            ItIsClicked = false;
            guna2Panel1.FillColor = Color.Transparent;
            guna2CirclePictureBox1.Image = Properties.Resources.empty;
        }

        private void AttachClickHandlers(Control parent) // Makes the children clickable
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += (s, e) => Guna2Panel1_Click(s, e);

                if (c.HasChildren)
                    AttachClickHandlers(c);

            }
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
        private void C_StatusButton_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
