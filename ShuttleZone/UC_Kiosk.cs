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
    public partial class UC_Kiosk : UserControl
    {
        public UC_Kiosk()
        {
            InitializeComponent();
            btnRunKiosk.Click += BtnRunKiosk_Click;
        }

        private void BtnRunKiosk_Click(object sender, EventArgs e)
        {
            var kiosk = new Kiosk();
            kiosk.Show();
        }
    }
}
