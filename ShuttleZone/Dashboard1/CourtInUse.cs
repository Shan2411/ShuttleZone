using Mysqlx.Connection;
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
using ShuttleZone.database;
using MySql.Data.MySqlClient;

namespace ShuttleZone.Dashboard1
{
    public partial class CourtInUse : UserControl
    {
        public CourtInUse()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;

            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            timer1.Interval = 5000; // Refresh every 5 seconds
            timer1.Start();

            RefreshData(); // Initial load
        }

        private void RefreshData()
        {
            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();

            var buttons = new[]
            {
                new CourtCardInUse("Court A", Globals.statusFromDB),
                new CourtCardInUse("Court B", Globals.statusFromDB1),
                new CourtCardInUse("Court C", Globals.statusFromDB2),
                new CourtCardInUse("Court D", Globals.statusFromDB3)
            };

            label5.Text = Globals.activeRentals.ToString() + "/4 In Use";
            label6.Text = Globals.GetAverageRentHours().ToString("F1") + " Avg Hours";

            flowLayoutPanel1.Controls.AddRange(buttons);

            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
