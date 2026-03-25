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

        // Win32 constants to freeze drawing
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public ManagerDashboard()
        {
            //Get the databse status court from globals
            Globals.statusFromDB = Globals.GetCourtStatusFromDB("Court A");
            Globals.statusFromDB1 = Globals.GetCourtStatusFromDB("Court B");
            Globals.statusFromDB2 = Globals.GetCourtStatusFromDB("Court C");
            Globals.statusFromDB3 = Globals.GetCourtStatusFromDB("Court D");

            // 1. Fundamental Double Buffering
            this.DoubleBuffered = true;

            InitializeComponent();

            // 2. Enable deep double buffering on problematic containers
            EnableDoubleBuffer(flowLayoutPanel1);
            EnableDoubleBuffer(flowLayoutPanel2);
            EnableDoubleBuffer(guna2ShadowPanel1);
            EnableDoubleBuffer(guna2ShadowPanel2);

            // 3. Freeze the control visually while we build the UI
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            try
            {
                this.SuspendLayout();

                // Load Heavy Guna Panels
                LoadAnalytics();

                // Load Dashboard Cards
                LoadCards();
            }
            finally
            {
                // 4. Unfreeze and force a single clean paint
                this.ResumeLayout(true);
                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Refresh();
            }
        }

        private void LoadAnalytics()
        {
            // Utilization
            Utilization utilizationUC = new Utilization { Dock = DockStyle.Fill };
            guna2ShadowPanel1.Controls.Add(utilizationUC);

            // Court In Use
            CourtInUse courtInUseUC = new CourtInUse { Dock = DockStyle.Fill };
            guna2ShadowPanel2.Controls.Add(courtInUseUC);
        }

        private void LoadCards()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();

            // Clear existing if any
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            // Bulk Add flowLayoutPanel1
            flowLayoutPanel1.Controls.AddRange(new Control[] {
                new Card_Dashboard("Today's Revenue"),
                new Card_Dashboard("Average Monthly Revenue"),
                new Card_Dashboard("Active Members"),
                new Card_Dashboard("Equipment Available")
            });

            // Bulk Add flowLayoutPanel2
            flowLayoutPanel2.Controls.AddRange(new Control[] {
                new Card_Dashboard("Kiosk Transactions"),
                new Card_Dashboard("Peak Hour Today")
            });

            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
        }

        // Helper to unlock the protected DoubleBuffered property
        private static void EnableDoubleBuffer(Control c)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);
            pi?.SetValue(c, true, null);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

 }