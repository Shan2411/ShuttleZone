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
            var buttons = new[]
            {
                new Card_Dashboard("Today's Revenue"),
                new Card_Dashboard("Equipment Available"),
                new Card_Dashboard("Active Membership"),
                new Card_Dashboard("Kiosk Sessions")
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // RESUME LAYOUT
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout(); // Force final layout

        }
    }

 }