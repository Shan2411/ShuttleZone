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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();

            flowLayoutPanel1.VerticalScroll.Enabled = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;

            flowLayoutPanel1.Controls.Add(new Card_Dashboard("Daily Sales"));
            flowLayoutPanel1.Controls.Add(new Card_Dashboard("Active Rentals"));
            flowLayoutPanel1.Controls.Add(new Card_Dashboard("Available Equipments"));
            flowLayoutPanel1.Controls.Add(new Card_Dashboard("Available Courts"));

            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;

            flowLayoutPanel2.Controls.Add(new Alerts_Dashboard());
            flowLayoutPanel2.Controls.Add(new Alerts_Dashboard());

            flowLayoutPanel1.ResumeLayout();
            flowLayoutPanel2.ResumeLayout();
            this.ResumeLayout();
        }




        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
