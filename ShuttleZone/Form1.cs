using System;
using System.Windows.Forms;
using ShuttleZone.Maintenance_Logs;
using System.Drawing;

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

        private void DateLbl_Click(object sender, EventArgs e)
        {
            // Optional: leave empty or remove
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void MainContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
           
        }


        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("membership clicked");
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dashboard clicked");
        }

        private void PosBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("pos clicked");
        }

        private void RentalBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("rental clicked");
        }

        private void EquipmentBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("equipment clicked");
        }

        private void SysSettingsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("settings clicked");
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("user clicked");
        }

        private void MaintenanceBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("maintenance clicked");
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
        }

        private void SystemSettingsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(SystemSettingsBtn);
            DynamicContentPanel.Controls.Clear();
        }

        private void DynamicContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
