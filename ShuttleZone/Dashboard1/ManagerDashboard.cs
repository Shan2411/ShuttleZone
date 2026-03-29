using Guna.UI2.WinForms;
using ShuttleZone.Maintenance_Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class ManagerDashboard : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private System.Windows.Forms.Timer refreshTimer;

        // ✅ Store references so controls are created once and reused
        private Utilization _utilizationUC;
        private CourtInUse _courtInUseUC;

        public ManagerDashboard()
        {
            RefreshGlobals();

            this.DoubleBuffered = true;

            InitializeComponent();

            EnableDoubleBuffer(flowLayoutPanel1);
            EnableDoubleBuffer(flowLayoutPanel2);
            EnableDoubleBuffer(guna2ShadowPanel1);
            EnableDoubleBuffer(guna2ShadowPanel2);

            // Freeze only during initial build
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
            try
            {
                this.SuspendLayout();
                LoadAnalytics();
                LoadCards();
            }
            finally
            {
                this.ResumeLayout(true);
                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Refresh();
            }

            InitializeRefreshTimer();
        }

        private void RefreshGlobals()
        {
            Globals.statusFromDB = Globals.GetCourtStatusFromDB("Court A");
            Globals.statusFromDB1 = Globals.GetCourtStatusFromDB("Court B");
            Globals.statusFromDB2 = Globals.GetCourtStatusFromDB("Court C");
            Globals.statusFromDB3 = Globals.GetCourtStatusFromDB("Court D");
            Globals.getThisMonthStats();
            Globals.getThisMonthRevenue();
            Globals.GetActiveRentals();
            Globals.GetRecentTransactions();
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // ✅ Only refresh data — never recreate controls
            RefreshGlobals();

            // Tell Utilization to reload its data from DB
            _utilizationUC?.LoadUtilizationData();

            // Refresh each Card_Dashboard in both panels
            foreach (Control ctrl in flowLayoutPanel1.Controls)
                if (ctrl is Card_Dashboard card) card.RefreshData();

            foreach (Control ctrl in flowLayoutPanel2.Controls)
                if (ctrl is Card_Dashboard card) card.RefreshData();
        }

        private void LoadAnalytics()
        {
            // ✅ Only create once — reuse on subsequent calls
            if (_utilizationUC == null)
            {
                _utilizationUC = new Utilization { Dock = DockStyle.Fill };
                guna2ShadowPanel1.Controls.Add(_utilizationUC);
            }

            if (_courtInUseUC == null)
            {
                _courtInUseUC = new CourtInUse { Dock = DockStyle.Fill };
                guna2ShadowPanel2.Controls.Add(_courtInUseUC);
            }
        }

        private void LoadCards()
        {
            // ✅ Only create cards if panel is empty — never clear and recreate
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                flowLayoutPanel1.SuspendLayout();
                flowLayoutPanel1.Controls.AddRange(new Control[]
                {
                    new Card_Dashboard("Today's Transactions"),
                    new Card_Dashboard("Today's Revenue"),
                    new Card_Dashboard("Average Monthly Revenue"),
                    new Card_Dashboard("Active Members")
                });
                flowLayoutPanel1.ResumeLayout(true);
                flowLayoutPanel1.PerformLayout();
            }

            if (flowLayoutPanel2.Controls.Count == 0)
            {
                flowLayoutPanel2.SuspendLayout();
                flowLayoutPanel2.Controls.AddRange(new Control[]
                {
                    new Card_Dashboard("Kiosk Transactions"),
                    new Card_Dashboard("Peak Hour Today")
                });
                flowLayoutPanel2.ResumeLayout(true);
                flowLayoutPanel2.PerformLayout();
            }
        }

        private static void EnableDoubleBuffer(Control c)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);
            pi?.SetValue(c, true, null);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}