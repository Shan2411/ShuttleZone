using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.sidebars
{
    public partial class ManagerSidebar : UserControl
    {
        public event EventHandler ManagerDashboardBtnClicked;
        public event EventHandler MembershipBtnClicked;
        public event EventHandler InventoryBtnClicked;
        public event EventHandler FacilityBtnClicked;
        public event EventHandler UsersBtnClicked;
        public event EventHandler KioskBtnClicked;
        public event EventHandler LogoutClicked;

        public ManagerSidebar()
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

        public void SetUsername(string username)
        {
            managerUsername.Text = username;
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(DashboardBtn);
            ManagerDashboardBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MembershipBtn);
            MembershipBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void InventoryBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(InventoryBtn);
            InventoryBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void FacilityBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(FacilityBtn);
            FacilityBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void UsersBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(UsersBtn);
            UsersBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void KioskBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(KioskBtn);
            KioskBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void managerUsername_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LogoutClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
