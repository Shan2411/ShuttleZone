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
    public partial class ManagerDashboard : UserControl
    {
        public ManagerDashboard()
        {

            // Enable double buffering BEFORE InitializeComponent
            this.DoubleBuffered = true;

            InitializeComponent();
            Utilization utilizationUC = new Utilization();
            utilizationUC.Dock = DockStyle.Fill;

            guna2ShadowPanel1.Controls.Add(utilizationUC);

            CourtInUse courtInUseUC = new CourtInUse();
            courtInUseUC.Dock = DockStyle.Fill;

            guna2ShadowPanel2.Controls.Add(courtInUseUC);


            // SUSPEND LAYOUT - CRITICAL for performance
            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            // Configure panel once
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false; // If horizontal layout

            // Clear once
            flowLayoutPanel1.Controls.Clear();

            // Add all controls at once
            var boxes1 = new[]
            {
                new Card_Dashboard("Today's Revenue"),
                new Card_Dashboard("Average Monthly Revenue"),
                new Card_Dashboard("Active Membership"),
                new Card_Dashboard("Equipment Availabl")
            };

            flowLayoutPanel1.Controls.AddRange(boxes1);

            var boxes2 = new[]
{
                new Card_Dashboard("Kiosk Sessions"),
                new Card_Dashboard("Peak Hour Today"),
                //new Card_Dashboard("Active Membership"),
                //new Card_Dashboard("Kiosk Sessions")
            };

            flowLayoutPanel2.Controls.AddRange(boxes2);

            // RESUME LAYOUT
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout(); // Force final layout

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

 }