using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.topbar
{
    public partial class AdminTopbar : UserControl
    {
        public event EventHandler AdminBtnClicked;
        public event EventHandler ManagerBtnClicked;
        public event EventHandler FrontDeskBtnClicked;
        public event EventHandler SettingsBtnClicked;
        public AdminTopbar()
        {
            InitializeComponent();
            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AdminBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ManagerBtn_Click(object sender, EventArgs e)
        {
            ManagerBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void FrontDeskBtn_Click(object sender, EventArgs e)
        {
            FrontDeskBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsBtnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
