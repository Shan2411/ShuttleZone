    using System;
    using System.Windows.Forms;
    using ShuttleZone.Maintenance_Logs;
    using System.Drawing;
    using ShuttleZone.sidebars;
using ShuttleZone.UserManagement;
using ShuttleZone.SystemSettings;



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
        }

            private void Form1_Load(object sender, EventArgs e)
            {
                // Set current date to label
                //DateLbl.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");


            }

            private void CloseBtn_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void LogoutBtn_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void PosBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(POSBtn);
        }

            private void RentalBtn_Click(object sender, EventArgs e)
            {
               HighlightButton(RentalHistoryBtn);
        }

            private void EquipmentBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(EquipmentInventoryBtn);
        }

            
            

            private void MaintenanceBtn_Click(object sender, EventArgs e)
            {
               HighlightButton(MaintenanceLogBtn);
        }
            private void HighlightButton(Guna.UI2.WinForms.Guna2Button activeButton)
            {
                foreach (Control ctrl in SidebarLinksGroup.Controls)
                {
                    if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                    {
                        btn.FillColor = btn == activeButton ? Color.Indigo : Color.Transparent;
                    }
                }
            }


            private void DashboardBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(DashboardBtn);
                DynamicContentPanel.Controls.Clear();
            
            }

            private void MembershipBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(MembershipBtn);
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

                Maintenance_Logs.MaintenanceWindow maintenanceWindowUC = new Maintenance_Logs.MaintenanceWindow();
                DynamicContentPanel.Controls.Add(maintenanceWindowUC);
                maintenanceWindowUC.Dock = DockStyle.Fill;
            }

            private void ReportsBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(ReportsBtn);
                DynamicContentPanel.Controls.Clear();

                Reports.Reports_Dashboard reportsDashboardUC = new Reports.Reports_Dashboard();
                DynamicContentPanel.Controls.Add(reportsDashboardUC);
                reportsDashboardUC.Dock = DockStyle.Fill;
            }

        private void UserManagementBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(UserManagementBtn);
            DynamicContentPanel.Controls.Clear();

            ucUserManagement userUC = new ucUserManagement();
            userUC.Dock = DockStyle.Fill;

            DynamicContentPanel.Controls.Add(userUC);
        }


        private void SystemSettingsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(SystemSettingsBtn);
            DynamicContentPanel.Controls.Clear();

            ShuttleZone.SystemSettings.UC_SystemSettings systemSettingsUC
     = new ShuttleZone.SystemSettings.UC_SystemSettings();

            systemSettingsUC.Dock = DockStyle.Fill;

            DynamicContentPanel.Controls.Add(systemSettingsUC);
        }


        private void ManagerBtn_Click(object sender, EventArgs e)
            {
            SidebarDynamicPanel.Controls.Clear();
            ManagerSidebar managerSidebarUC = new ManagerSidebar();
            managerSidebarUC.Dock = DockStyle.Fill;

            
            managerSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            managerSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            managerSidebarUC.POSBtnClicked += POSBtn_Click;
            managerSidebarUC.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
            managerSidebarUC.EquipmentInventoryBtnClicked += EquipmentInventoryBtn_Click;
            managerSidebarUC.MaintenanceLogBtnClicked += MaintenanceLogBtn_Click;
            managerSidebarUC.ReportsBtnClicked += ReportsBtn_Click;
            SidebarDynamicPanel.Controls.Add(managerSidebarUC);
            }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            SidebarDynamicPanel.Controls.Clear();
            AdminSidebar adminSidebarUC = new AdminSidebar();
            adminSidebarUC.Dock = DockStyle.Fill;

            adminSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            adminSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            adminSidebarUC.POSBtnClicked += POSBtn_Click;
            adminSidebarUC.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
            adminSidebarUC.EquipmentInventoryBtnClicked += EquipmentInventoryBtn_Click;
            adminSidebarUC.MaintenanceLogBtnClicked += MaintenanceLogBtn_Click;
            adminSidebarUC.ReportsBtnClicked += ReportsBtn_Click;
            adminSidebarUC.UserManagementBtnClicked += UserManagementBtn_Click;
            adminSidebarUC.SettingsBtnClicked += SystemSettingsBtn_Click;
            SidebarDynamicPanel.Controls.Add(adminSidebarUC);
        }

        private void SidebarTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrontDeskBtn_Click(object sender, EventArgs e)
        {
            SidebarDynamicPanel.Controls.Clear();
            FrontDeskSidebar frontDeskSidebarUC = new FrontDeskSidebar();
            frontDeskSidebarUC.Dock = DockStyle.Fill;

            frontDeskSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            frontDeskSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            frontDeskSidebarUC.POSBtnClicked += POSBtn_Click;
            frontDeskSidebarUC.RentalHistoryBtnClicked += RentalHistoryBtn_Click;
            SidebarDynamicPanel.Controls.Add(frontDeskSidebarUC);
        }
    }
    }
