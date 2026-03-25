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
        public event EventHandler FrontDeskDashboardBtnClicked;
        public event EventHandler POSBtnClicked;  
        public event EventHandler MembershipBtnClicked;
        public event EventHandler HistoryBtnClicked;
        public event EventHandler PendingPaymentsBtnClicked;
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
            FrontDeskDashboardBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void POSBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(POSBtn);
            POSBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(MembershipBtn);
            MembershipBtnClicked?.Invoke(this, EventArgs.Empty);
        }
       private void HistoryBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(HistoryBtn);
            HistoryBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PendingPaymentsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(PendingPaymentsBtn);
            PendingPaymentsBtnClicked?.Invoke(this, EventArgs.Empty);
        }   
    }
}
