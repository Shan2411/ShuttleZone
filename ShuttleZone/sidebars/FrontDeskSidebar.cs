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
    public partial class FrontDeskSidebar : UserControl
    {
        public event EventHandler DashboardBtnClicked;
        public event EventHandler POSBtnClicked;
        public event EventHandler RentalHistoryBtnClicked;
        public event EventHandler MembershipBtnClicked;
        public FrontDeskSidebar()
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

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(DashboardBtn);
            DashboardBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void POSBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(POSBtn);
            POSBtnClicked?.Invoke(this, EventArgs.Empty);
        } 
        private void RentalHistoryBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(RentalHistoryBtn);
            RentalHistoryBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MembershipBtn);
            MembershipBtnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
