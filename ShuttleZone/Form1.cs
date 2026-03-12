    using ShuttleZone.Dashboard1;
    using ShuttleZone.Maintenance_Logs;
    using ShuttleZone.sidebars;
using ShuttleZone.SystemSettings;
using ShuttleZone.topbar;
    using ShuttleZone.UserManagement;
    using System;
    using System.Drawing;
    using System.Web.Security;
    using System.Windows.Forms;


namespace ShuttleZone
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();

                this.Load += Form1_Load;

            //AdminSidebar adminSidebarUC = new AdminSidebar();
            //SidebarDynamicPanel.Controls.Clear();
            //SidebarDynamicPanel.Controls.Add(adminSidebarUC);
            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");
        }

            private void Form1_Load(object sender, EventArgs e)
            {
                // Set current date to label
                //DateLbl.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");


            }

            private void HistoryBtn_Click(object sender, EventArgs e)
            {
            DynamicContentPanel.Controls.Clear();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            DynamicContentPanel.Controls.Clear();

            ShuttleZone.UserManagement.ucUserManagement userManagement = new ShuttleZone.UserManagement.ucUserManagement();
            userManagement.Dock = DockStyle.Fill;

            DynamicContentPanel.Controls.Add(userManagement);
        }

        private void FacilityBtn_Click(object sender, EventArgs e)
            {
            DynamicContentPanel.Controls.Clear();
        }

        //DASHBOARD BUTTON CLICKS
        private void AdminDashboardBtn_Click(object sender, EventArgs e)
        {
              
            DynamicContentPanel.Controls.Clear();
            
            Dashboard1.AdminDashboard ucDashboard = new Dashboard1.AdminDashboard();
            DynamicContentPanel.Controls.Add(ucDashboard);
            ucDashboard.Dock = DockStyle.Fill;
        }
        private void FrontDeskDashboardBtn_Click(object sender, EventArgs e)
        {

            DynamicContentPanel.Controls.Clear();

            Dashboard1.FrontDeskDashboard ucDashboard = new Dashboard1.FrontDeskDashboard();
            DynamicContentPanel.Controls.Add(ucDashboard);
            ucDashboard.Dock = DockStyle.Fill;
        }
        private void ManagerDashboardBtn_Click(object sender, EventArgs e)
        {

            DynamicContentPanel.Controls.Clear();  
            Dashboard1.ManagerDashboard ucDashboard = new Dashboard1.ManagerDashboard();
            DynamicContentPanel.Controls.Add(ucDashboard);
            ucDashboard.Dock = DockStyle.Fill;
        }

        //


        private void MembershipBtn_Click(object sender, EventArgs e)
            {
           
                //logic for changing pages on dynamic panel
                DynamicContentPanel.Controls.Clear();
                UC_Membership ucMembership = new UC_Membership();
                ucMembership.Dock = DockStyle.Fill;

                DynamicContentPanel.Controls.Add(ucMembership);
            }

            private void ExitBtn_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void POSBtn_Click(object sender, EventArgs e)
            {
         
                DynamicContentPanel.Controls.Clear();
                UC_Pos ucPos = new UC_Pos();
                ucPos.Dock = DockStyle.Fill;

                DynamicContentPanel.Controls.Add(ucPos);
            }

            private void InventoryBtn_Click(object sender, EventArgs e)
            {
                DynamicContentPanel.Controls.Clear();
                Equipment_and_Inventory.Equipment equipmentWindowUC = new Equipment_and_Inventory.Equipment();
                DynamicContentPanel.Controls.Add(equipmentWindowUC);
                equipmentWindowUC.Dock = DockStyle.Fill;
        }

            private void SettingsBtn_Click(object sender, EventArgs e)
            {
                DynamicContentPanel.Controls.Clear();
                UC_SystemsSettings ucSettings = new UC_SystemsSettings();
                ucSettings.Dock = DockStyle.Fill;

                DynamicContentPanel.Controls.Add(ucSettings);
        }

        private void KioskBtn_Click(object sender, EventArgs e)
            {
                DynamicContentPanel.Controls.Clear();
                UC_Kiosk kioskUC = new UC_Kiosk();
                kioskUC.Dock = DockStyle.Fill;
                DynamicContentPanel.Controls.Add(kioskUC);
            }

            public void MaintenanceLogBtn_Click(object sender, EventArgs e)
            {
              
                DynamicContentPanel.Controls.Clear();

                Maintenance_Logs.MaintenanceWindow maintenanceWindowUC = new Maintenance_Logs.MaintenanceWindow();
                DynamicContentPanel.Controls.Add(maintenanceWindowUC);
                maintenanceWindowUC.Dock = DockStyle.Fill;
            }

            private void ReportsBtn_Click(object sender, EventArgs e)
            {
            
                DynamicContentPanel.Controls.Clear();

                Reports.Reports_Dashboard reportsDashboardUC = new Reports.Reports_Dashboard();
                DynamicContentPanel.Controls.Add(reportsDashboardUC);
                reportsDashboardUC.Dock = DockStyle.Fill;
            }

        private void ManagerBtn_Click(object sender, EventArgs e)
        {
            DynamicTopbarPanel.Controls.Clear();
            MFTopbar mfTopbarUC = new MFTopbar();
            DynamicTopbarPanel.Controls.Add(mfTopbarUC);
            mfTopbarUC.Dock = DockStyle.Fill;

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            ManagerSidebar managerSidebarUC = new ManagerSidebar();
            managerSidebarUC.Dock = DockStyle.Fill;

            
            managerSidebarUC.ManagerDashboardBtnClicked += ManagerDashboardBtn_Click;
            managerSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            managerSidebarUC.InventoryBtnClicked += InventoryBtn_Click;
            managerSidebarUC.FacilityBtnClicked += FacilityBtn_Click;
            managerSidebarUC.UsersBtnClicked += UsersBtn_Click;
            managerSidebarUC.KioskBtnClicked += KioskBtn_Click;
            SidebarDynamicPanel.Controls.Add(managerSidebarUC);

            mfTopbarUC.AdminBtnClicked += AdminBtn_Click;
            mfTopbarUC.ManagerBtnClicked += ManagerBtn_Click;
            mfTopbarUC.FrontDeskBtnClicked += FrontDeskBtn_Click;
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            DynamicTopbarPanel.Controls.Clear();
            AdminTopbar adminTopbarUC = new AdminTopbar();
            DynamicTopbarPanel.Controls.Add(adminTopbarUC);
            adminTopbarUC.Dock = DockStyle.Fill;

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            AdminSidebar adminSidebarUC = new AdminSidebar();
            adminSidebarUC.Dock = DockStyle.Fill;

            adminSidebarUC.AdminDashboardBtnClicked += AdminDashboardBtn_Click;
            adminSidebarUC.ReportsBtnClicked += ReportsBtn_Click;
            adminSidebarUC.UsersBtnClicked += UsersBtn_Click;
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
            DynamicTopbarPanel.Controls.Add(mfTopbarUC);
            mfTopbarUC.Dock = DockStyle.Fill;

            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            FrontDeskSidebar frontDeskSidebarUC = new FrontDeskSidebar();
            frontDeskSidebarUC.Dock = DockStyle.Fill;

            frontDeskSidebarUC.FrontDeskDashboardBtnClicked += FrontDeskDashboardBtn_Click;
            frontDeskSidebarUC.POSBtnClicked += POSBtn_Click;
            frontDeskSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            frontDeskSidebarUC.HistoryBtnClicked += HistoryBtn_Click;
            SidebarDynamicPanel.Controls.Add(frontDeskSidebarUC);

            mfTopbarUC.AdminBtnClicked += AdminBtn_Click;
            mfTopbarUC.ManagerBtnClicked += ManagerBtn_Click;
            mfTopbarUC.FrontDeskBtnClicked += FrontDeskBtn_Click;
        }

        private void DynamicContentPanel_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void Topbar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DateLbl_Click(object sender, EventArgs e)
        {
           
        }
    }
    }
