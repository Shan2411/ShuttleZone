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
    public partial class MFTopbar : UserControl
    {
        public event EventHandler AdminBtnClicked;
        public event EventHandler ManagerBtnClicked;
        public event EventHandler FrontDeskBtnClicked;
        public MFTopbar()
        {
            InitializeComponent();
            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
