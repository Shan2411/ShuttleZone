using ShuttleZone.Dashboard1;
using ShuttleZone.LogIn_Form;
using ShuttleZone.Maintenance_Logs;
using ShuttleZone.Rent_History;
using ShuttleZone.sidebars;
using ShuttleZone.SystemSettings;
using ShuttleZone.topbar;
using ShuttleZone.UserManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class Form1 : Form
    {
        // 🔥 Store all views here (REUSABLE)
        private Dictionary<Type, UserControl> _views = new Dictionary<Type, UserControl>();
        private string _username;
        public Form1(string username)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.UserPaint, true);

            this.UpdateStyles();

            this.Load += Form1_Load;

            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");
        }

        // Public helper to apply role-specific UI from outside (LoginForm)
        public void SetRole(string role)
        {
            if (string.IsNullOrEmpty(role))
                return;

            // Normalize role string and call internal handlers
            var r = role.Trim().ToLower();
            switch (r)
            {
                case "admin":
                    AdminBtn_Click(this, EventArgs.Empty);
                    break;
                case "manager":
                    ManagerBtn_Click(this, EventArgs.Empty);
                    break;
                case "front desk":
                case "frontdesk":
                case "front_desk":
                    FrontDeskBtn_Click(this, EventArgs.Empty);
                    break;
                default:
                    // default fallback (front desk style)
                    FrontDeskBtn_Click(this, EventArgs.Empty);
                    break;
            }
        }

        // 🔥 HARDCORE flicker fix (Windows-level)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load role-specific dashboard by default
            switch (UserSession.Role?.ToLower())
            {
                case "admin":
                    AdminDashboardBtn_Click(this, EventArgs.Empty);
                    break;
                case "manager":
                    ManagerDashboardBtn_Click(this, EventArgs.Empty);
                    break;
                case "frontdesk":
                case "front desk":
                case "front_desk":
                default:
                    FrontDeskDashboardBtn_Click(this, EventArgs.Empty);
                    break;
            }
        }

        // 🔥 GENERIC VIEW LOADER (CORE SYSTEM)
        private void LoadView<T>() where T : UserControl, new()
        {
            DynamicContentPanel.SuspendLayout();

            if (!_views.ContainsKey(typeof(T)))
            {
                var view = new T();
                view.Dock = DockStyle.Fill;
                _views[typeof(T)] = view;
            }

            DynamicContentPanel.Controls.Clear();
            DynamicContentPanel.Controls.Add(_views[typeof(T)]);

            DynamicContentPanel.ResumeLayout();
        }

        // ================= BUTTONS =================

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_UserManagement>();
        }

        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_Membership>();

            // Pass the current role after loading the view
            if (_views[typeof(UC_Membership)] is UC_Membership membershipUC)
            {
                membershipUC.SetRole(UserSession.Role); // "manager", "frontdesk", etc.
            }
        }

        private void POSBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_Pos>();
        }

        private void InventoryBtn_Click(object sender, EventArgs e)
        {
            LoadView<Equipment_and_Inventory.Equipment>();
        }

        private void FacilityBtn_Click(object sender, EventArgs e)
        {
            LoadView<MaintenanceWindow>();
        }

        private void KioskBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_Kiosk>();
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            LoadView<Reports.Reports_Dashboard>();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_SystemsSettings>();
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            LoadView<RentHistory>();
        }

        private void PendingPaymentsBtn_Click(object sender, EventArgs e)
        {
            LoadView<UC_Pending>();
        }

        // ================= DASHBOARDS =================

        private void AdminDashboardBtn_Click(object sender, EventArgs e)
        {
            LoadView<AdminDashboard>();

            LoadView<AdminDashboard>();

            if (_views[typeof(AdminDashboard)] is AdminDashboard dashboard)
            {
                dashboard.QuickActionReportsClicked -= ReportsBtn_Click;
                dashboard.QuickActionReportsClicked += ReportsBtn_Click;
            }

        }

        private void FrontDeskDashboardBtn_Click(object sender, EventArgs e)
        {
            LoadView<FrontDeskDashboard>();


            // Hook quick action events after the view is loaded
            if (_views[typeof(FrontDeskDashboard)] is FrontDeskDashboard dashboard)
            {
                dashboard.QuickActionPOSClicked -= POSBtn_Click; // prevent double-hooking
                dashboard.QuickActionPendingClicked -= PendingPaymentsBtn_Click;

                dashboard.QuickActionPOSClicked += POSBtn_Click;
                dashboard.QuickActionPendingClicked += PendingPaymentsBtn_Click;
            }

        }

        private void ManagerDashboardBtn_Click(object sender, EventArgs e)
        {
            LoadView<ManagerDashboard>();
        }

        // ================= LOGOUT =================
        public void Logout()
        {
            // Clear session
            UserSession.Clear();

            // Clear cached views (IMPORTANT)
            _views.Clear();
            DynamicContentPanel.Controls.Clear();
            SidebarDynamicPanel.Controls.Clear();
            DynamicTopbarPanel.Controls.Clear();

            // Show login form
            LoginForm login = new LoginForm();
            login.Show();

            // Close current form
            this.Close();
        }

        // ================= ROLE SWITCHING =================

        private void ManagerBtn_Click(object sender, EventArgs e)
        {
            DynamicTopbarPanel.Controls.Clear();
            MFTopbar mfTopbarUC = new MFTopbar();
            mfTopbarUC.Dock = DockStyle.Fill;
            DynamicTopbarPanel.Controls.Add(mfTopbarUC);

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();

            ManagerSidebar managerSidebarUC = new ManagerSidebar();
            managerSidebarUC.SetUsername(UserSession.Username);
            managerSidebarUC.Dock = DockStyle.Fill;

            // 🔥 Hook events
            managerSidebarUC.ManagerDashboardBtnClicked += ManagerDashboardBtn_Click;
            managerSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            managerSidebarUC.InventoryBtnClicked += InventoryBtn_Click;
            managerSidebarUC.FacilityBtnClicked += FacilityBtn_Click;
            managerSidebarUC.UsersBtnClicked += UsersBtn_Click;
            managerSidebarUC.KioskBtnClicked += KioskBtn_Click;
            //logout
            managerSidebarUC.LogoutClicked += (s, ev) =>
            {
                if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Logout();
                }
            };

            SidebarDynamicPanel.Controls.Add(managerSidebarUC);

            mfTopbarUC.AdminBtnClicked += AdminBtn_Click;
            mfTopbarUC.ManagerBtnClicked += ManagerBtn_Click;
            mfTopbarUC.FrontDeskBtnClicked += FrontDeskBtn_Click;
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            DynamicTopbarPanel.Controls.Clear();
            AdminTopbar adminTopbarUC = new AdminTopbar();
            adminTopbarUC.Dock = DockStyle.Fill;
            DynamicTopbarPanel.Controls.Add(adminTopbarUC);

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();

            AdminSidebar adminSidebarUC = new AdminSidebar();
            adminSidebarUC.SetUsername(UserSession.Username);
            adminSidebarUC.Dock = DockStyle.Fill;

            adminSidebarUC.AdminDashboardBtnClicked += AdminDashboardBtn_Click;
            adminSidebarUC.ReportsBtnClicked += ReportsBtn_Click;
            adminSidebarUC.UsersBtnClicked += UsersBtn_Click;
            //logout
            adminSidebarUC.LogoutClicked += (s, ev) =>
            {
                if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Logout();
                }
            };

            SidebarDynamicPanel.Controls.Add(adminSidebarUC);

            adminTopbarUC.AdminBtnClicked += AdminBtn_Click;
            adminTopbarUC.ManagerBtnClicked += ManagerBtn_Click;
            adminTopbarUC.FrontDeskBtnClicked += FrontDeskBtn_Click;
            adminTopbarUC.SettingsBtnClicked += SettingsBtn_Click;
        }

        private void FrontDeskBtn_Click(object sender, EventArgs e)
        {
            DynamicTopbarPanel.Controls.Clear();
            MFTopbar mfTopbarUC = new MFTopbar();
            mfTopbarUC.Dock = DockStyle.Fill;
            DynamicTopbarPanel.Controls.Add(mfTopbarUC);

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();

            FrontDeskSidebar frontDeskSidebarUC = new FrontDeskSidebar();
            frontDeskSidebarUC.SetUsername(UserSession.Username);
            frontDeskSidebarUC.Dock = DockStyle.Fill;

            frontDeskSidebarUC.FrontDeskDashboardBtnClicked += FrontDeskDashboardBtn_Click;
            frontDeskSidebarUC.POSBtnClicked += POSBtn_Click;
            frontDeskSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            frontDeskSidebarUC.HistoryBtnClicked += HistoryBtn_Click;
            frontDeskSidebarUC.PendingPaymentsBtnClicked += PendingPaymentsBtn_Click;
            //logout
            frontDeskSidebarUC.LogoutClicked += (s, ev) =>
            {
                if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Logout();
                }
            };

            SidebarDynamicPanel.Controls.Add(frontDeskSidebarUC);

            mfTopbarUC.AdminBtnClicked += AdminBtn_Click;
            mfTopbarUC.ManagerBtnClicked += ManagerBtn_Click;
            mfTopbarUC.FrontDeskBtnClicked += FrontDeskBtn_Click;
        }

        // ================= SYSTEM =================

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}