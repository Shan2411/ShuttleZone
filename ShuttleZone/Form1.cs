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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            DynamicContentPanel.Controls.Clear();
        }

        private void MembershipBtn_Click(object sender, EventArgs e)
        {
            DynamicContentPanel.Controls.Clear();
            UC_Membership ucMembership = new UC_Membership();
            ucMembership.Dock = DockStyle.Fill;

            DynamicContentPanel.Controls.Add(ucMembership);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
