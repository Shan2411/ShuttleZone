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
    public partial class FrontDeskDashboard : UserControl
    {
        public FrontDeskDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;

            flowLayoutPanel1.Controls.Clear();

            var buttons = new[]
            {
                new CourtCard("Court A", Globals.statusFromDB),
                new CourtCard("Court B", "in use"),
                new CourtCard("Court C", Globals.statusFromDB2),
                new CourtCard("Court D", Globals.statusFromDB3)
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // Row 1 / Columns 1,3,5,7 with Dock = Fill
            var c1 = new Card_Dashboard("Today's Transactions") { Dock = DockStyle.Fill };
            var c3 = new Card_Dashboard("Active Rentals") { Dock = DockStyle.Fill };
            var c5 = new Card_Dashboard("New Memberships") { Dock = DockStyle.Fill };
            var c7 = new Card_Dashboard("Pending Payments") { Dock = DockStyle.Fill };

            tableLayoutPanel2.Controls.Add(c1, 0, 1);
            tableLayoutPanel2.Controls.Add(c3, 2, 1);
            tableLayoutPanel2.Controls.Add(c5, 4, 1);
            tableLayoutPanel2.Controls.Add(c7, 6, 1);

            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        public void RefreshPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            // Add new controls as needed
            flowLayoutPanel1.Controls.Add(new MButton("Court A", Globals.statusFromDB));
            flowLayoutPanel1.Controls.Add(new MButton("Court B", Globals.statusFromDB1));
            flowLayoutPanel1.Controls.Add(new MButton("Court C", Globals.statusFromDB2));
            flowLayoutPanel1.Controls.Add(new MButton("Court D", Globals.statusFromDB3));
            flowLayoutPanel1.Refresh();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
