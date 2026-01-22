using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void MaintenanceLogBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MaintenanceLogBtn);
            DynamicContentPanel.Controls.Clear();
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(ReportsBtn);
            DynamicContentPanel.Controls.Clear();
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
    }
}
