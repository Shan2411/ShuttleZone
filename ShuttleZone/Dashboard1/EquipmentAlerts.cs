using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class EquipmentAlerts : UserControl
    {
        public EquipmentAlerts()
        {
            InitializeComponent();

            // Enable double buffering for this UserControl
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            var alert1 = new Alerts_Dashboard("Red", "Low on Shuttlecock Supply");
            var alert2 = new Alerts_Dashboard("Red", "No New Nets Available");

            alert1.Width = flowLayoutPanel1.ClientSize.Width - flowLayoutPanel1.Padding.Horizontal;
            alert2.Width = flowLayoutPanel1.ClientSize.Width - flowLayoutPanel1.Padding.Horizontal;

            // double buffering on the FlowLayoutPanel to reduce flicker
            typeof(FlowLayoutPanel).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null,
                flowLayoutPanel1,
                new object[] { true });

            flowLayoutPanel1.Controls.Add(alert1);
            flowLayoutPanel1.Controls.Add(alert2);
        }
    }
}
