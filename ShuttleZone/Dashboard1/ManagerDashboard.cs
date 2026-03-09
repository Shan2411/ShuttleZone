using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class ManagerDashboard : UserControl
    {
        public ManagerDashboard()
        {
            InitializeComponent();
            Utilization utilizationUC = new Utilization();
            utilizationUC.Dock = DockStyle.Fill;

            guna2ShadowPanel1.Controls.Add(utilizationUC);
        }

    }
}