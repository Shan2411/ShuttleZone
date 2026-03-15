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
    public partial class AdminSidebar : UserControl
    {
        public event EventHandler AdminDashboardBtnClicked;
        public event EventHandler ReportsBtnClicked;
        public event EventHandler UsersBtnClicked;
        public AdminSidebar()
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
            AdminDashboardBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(ReportsBtn);
            ReportsBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            HighlightButton(UsersBtn);
            UsersBtnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
