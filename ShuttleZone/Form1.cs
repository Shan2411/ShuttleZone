    using ShuttleZone.Dashboard1;
    using ShuttleZone.Maintenance_Logs;
    using ShuttleZone.sidebars;
    using System;
    using System.Drawing;
    using System.Web.Security;
    using System.Windows.Forms;
    using ShuttleZone.UserManagement;


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

            private void HistoryBtn_Click(object sender, EventArgs e)
            {
            DynamicContentPanel.Controls.Clear();
        }

            private void EquipmentBtn_Click(object sender, EventArgs e)
            {
          
        
            DynamicContentPanel.Controls.Clear();
            Equipment_and_Inventory.Equipment equipmentWindowUC = new Equipment_and_Inventory.Equipment();
            DynamicContentPanel.Controls.Add(equipmentWindowUC);
            equipmentWindowUC.Dock = DockStyle.Fill;
        }

            private void UsersBtn_Click(object sender, EventArgs e)
            {
            DynamicContentPanel.Controls.Clear();
        }

            private void FacilityBtn_Click(object sender, EventArgs e)
            {
            DynamicContentPanel.Controls.Clear();
        }


            private void DashboardBtn_Click(object sender, EventArgs e)
            {
              
                DynamicContentPanel.Controls.Clear();
            
                Dashboard1.Dashboard_UC ucDashboard = new Dashboard1.Dashboard_UC();
                DynamicContentPanel.Controls.Add(ucDashboard);
                ucDashboard.Dock = DockStyle.Fill;
            }

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
            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            ManagerSidebar managerSidebarUC = new ManagerSidebar();
            managerSidebarUC.Dock = DockStyle.Fill;

            
            managerSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            managerSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            managerSidebarUC.InventoryBtnClicked += InventoryBtn_Click;
            managerSidebarUC.FacilityBtnClicked += FacilityBtn_Click;
            managerSidebarUC.UsersBtnClicked += UsersBtn_Click;
            managerSidebarUC.KioskBtnClicked += KioskBtn_Click;
            SidebarDynamicPanel.Controls.Add(managerSidebarUC);
            }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            AdminSidebar adminSidebarUC = new AdminSidebar();
            adminSidebarUC.Dock = DockStyle.Fill;

            adminSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            adminSidebarUC.ReportsBtnClicked += ReportsBtn_Click;
            adminSidebarUC.UsersBtnClicked += UsersBtn_Click;
            SidebarDynamicPanel.Controls.Add(adminSidebarUC);
        }

        private void SidebarTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrontDeskBtn_Click(object sender, EventArgs e)
        {
            SidebarDynamicPanel.Controls.Clear();
            DynamicContentPanel.Controls.Clear();
            FrontDeskSidebar frontDeskSidebarUC = new FrontDeskSidebar();
            frontDeskSidebarUC.Dock = DockStyle.Fill;

            frontDeskSidebarUC.DashboardBtnClicked += DashboardBtn_Click;
            frontDeskSidebarUC.POSBtnClicked += POSBtn_Click;
            frontDeskSidebarUC.MembershipBtnClicked += MembershipBtn_Click;
            frontDeskSidebarUC.HistoryBtnClicked += HistoryBtn_Click;
            SidebarDynamicPanel.Controls.Add(frontDeskSidebarUC);
        }

        private void DynamicContentPanel_Paint(object sender, PaintEventArgs e)
        {
                
        }
    }
    }
