using ShuttleZone.Dashboard1;
using ShuttleZone.Maintenance_Logs;
using ShuttleZone.sidebars;
using ShuttleZone.Reports;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HighlightButton(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            foreach (Control ctrl in SidebarLinksGroup.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                    btn.FillColor = btn == activeButton ? Color.Indigo : Color.Transparent;
            }
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(DashboardBtn);
            DynamicContentPanel.Controls.Clear();
            Dashboard_UC ucDashboard = new Dashboard_UC();
            ucDashboard.Dock = DockStyle.Fill;
            DynamicContentPanel.Controls.Add(ucDashboard);
        }

        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MembershipBtn);
            DynamicContentPanel.Controls.Clear();
            UC_Membership ucMembership = new UC_Membership();
            ucMembership.Dock = DockStyle.Fill;
            DynamicContentPanel.Controls.Add(ucMembership);
        }

        private void POSBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(POSBtn);
            DynamicContentPanel.Controls.Clear();
        }

        private void RentalHistoryBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(RentalHistoryBtn);
            DynamicContentPanel.Controls.Clear();
        }

        private void EquipmentInventoryBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(EquipmentInventoryBtn);
            DynamicContentPanel.Controls.Clear();
        }

        public void MaintenanceLogBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MaintenanceLogBtn);
            DynamicContentPanel.Controls.Clear();
            MaintenanceWindow maintenanceWindowUC = new MaintenanceWindow();
            maintenanceWindowUC.Dock = DockStyle.Fill;
            DynamicContentPanel.Controls.Add(maintenanceWindowUC);
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(ReportsBtn);
            DynamicContentPanel.Controls.Clear();
            Reports_Dashboard reportsDashboardUC = new Reports_Dashboard();
            reportsDashboardUC.Dock = DockStyle.Fill;
            DynamicContentPanel.Controls.Add(reportsDashboardUC);
        }

        private void UserManagementBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(UserManagementBtn);
            DynamicContentPanel.Controls.Clear();
        }

        private void SystemSettingsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(SystemSettingsBtn);
            DynamicContentPanel.Controls.Clear();
        }

        public void LoadSidebar(UserControl sidebar)
        {
            SidebarDynamicPanel.Controls.Clear();
            sidebar.Dock = DockStyle.Fill;

            if (sidebar is AdminSidebar admin)
            {
                admin.DashboardBtnClicked += DashboardBtn_Click;
                admin.MembershipBtnClicked += MembershipBtn_Click;
                admin.POSBtnClicked += POSBtn_Click;
                admin.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
                admin.EquipmentInventoryBtnClicked += EquipmentInventoryBtn_Click;
                admin.MaintenanceLogBtnClicked += MaintenanceLogBtn_Click;
                admin.ReportsBtnClicked += ReportsBtn_Click;
                admin.UserManagementBtnClicked += UserManagementBtn_Click;
                admin.SettingsBtnClicked += SystemSettingsBtn_Click;
            }
            else if (sidebar is ManagerSidebar manager)
            {
                manager.DashboardBtnClicked += DashboardBtn_Click;
                manager.MembershipBtnClicked += MembershipBtn_Click;
                manager.POSBtnClicked += POSBtn_Click;
                manager.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
                manager.EquipmentInventoryBtnClicked += EquipmentInventoryBtn_Click;
                manager.MaintenanceLogBtnClicked += MaintenanceLogBtn_Click;
                manager.ReportsBtnClicked += ReportsBtn_Click;
            }
            else if (sidebar is FrontDeskSidebar frontDesk)
            {
                frontDesk.DashboardBtnClicked += DashboardBtn_Click;
                frontDesk.MembershipBtnClicked += MembershipBtn_Click;
                frontDesk.POSBtnClicked += POSBtn_Click;
                frontDesk.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
            }

            SidebarDynamicPanel.Controls.Add(sidebar);
        }
    }
}
