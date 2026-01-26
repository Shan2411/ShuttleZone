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
    public partial class ChangeStatus : Form
    {
        public ChangeStatus()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
                        bool ItIsClicked = false;
            // status should come from database l8r
            string statusFromDB = "Operational";
            flowLayoutPanel1.Controls.Add(new C_StatusButton(statusFromDB));
            flowLayoutPanel1.Controls.Add(new C_StatusButton("Under Maintenance"));
            flowLayoutPanel1.Controls.Add(new C_StatusButton("Out of Service"));

            //make everything draggable 
            MakeDraggable(this);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MakeDraggable(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                //guna2BorderlessForm1.SetDragForm(c, true); // ✅ make this control draggable
                if (c.HasChildren)
                    MakeDraggable(c); // recursively add children
            }
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
