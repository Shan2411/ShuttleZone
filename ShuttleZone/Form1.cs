    using ShuttleZone.Dashboard1;
    using ShuttleZone.Maintenance_Logs;
    using ShuttleZone.sidebars;
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

                DynamicContentPanel.Controls.Clear();
                UC_Pos ucPos = new UC_Pos();
                ucPos.Dock = DockStyle.Fill;

                DynamicContentPanel.Controls.Add(ucPos);

        }

            private void RentalBtn_Click(object sender, EventArgs e)
            {
               HighlightButton(RentalHistoryBtn);
        }

            private void EquipmentBtn_Click(object sender, EventArgs e)
            {
          
            HighlightButton(EquipmentInventoryBtn);
            DynamicContentPanel.Controls.Clear();
            Equipment_and_Inventory.Equipment equipmentWindowUC = new Equipment_and_Inventory.Equipment();
            DynamicContentPanel.Controls.Add(equipmentWindowUC);
            equipmentWindowUC.Dock = DockStyle.Fill;
        }

            private void SysSettingsBtn_Click(object sender, EventArgs e)
            {
               HighlightButton(SystemSettingsBtn);
        }

            private void UserBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(UserManagementBtn);
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
            
                Dashboard1.Dashboard_UC ucDashboard = new Dashboard1.Dashboard_UC();
                DynamicContentPanel.Controls.Add(ucDashboard);
                ucDashboard.Dock = DockStyle.Fill;
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
                UC_Pos ucPos = new UC_Pos();
                ucPos.Dock = DockStyle.Fill;

                DynamicContentPanel.Controls.Add(ucPos);
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
            }

            private void SystemSettingsBtn_Click(object sender, EventArgs e)
            {
                HighlightButton(SystemSettingsBtn);
                DynamicContentPanel.Controls.Clear();
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

        private void DynamicContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
