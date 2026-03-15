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
    public partial class CourtInUse : UserControl
    {
        public CourtInUse()
        {
            // Enable double buffering BEFORE InitializeComponent
            this.DoubleBuffered = true;

            InitializeComponent();

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
                new CourtCardInUse("Court A", "inUse"),
                new CourtCardInUse("Court B", "inUse"),
                new CourtCardInUse("Court C", "notInUse"),
                new CourtCardInUse("Court D", "inUse")
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // RESUME LAYOUT
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout(); // Force final layout

        }
    }
}
