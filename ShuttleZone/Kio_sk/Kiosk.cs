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
    public partial class Kiosk : Form
    {
        public Kiosk()
        {
            InitializeComponent();
            Load += Kiosk_Load;
            btnCourtRental.Click += BtnCourtRental_Click;
            btnEquipment.Click += BtnEquipment_Click;
            btnMembership.Click += BtnMembership_Click;
        }

        private void Kiosk_Load(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_CourtRental());
            lblKioskTitle.Text = "Court Rental";
        }

        private void BtnCourtRental_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_CourtRental());
            lblKioskTitle.Text = "Court Rental";
        }

        private void BtnEquipment_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_Equipment());
            lblKioskTitle.Text = "Equipment";
        }

        private void BtnMembership_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_KioskMembership());
            lblKioskTitle.Text = "Membership";
        }

        private void ShowDynamicPanel(UserControl content)
        {
            pnlDynamic.Controls.Clear();
            content.Dock = DockStyle.Fill;
            pnlDynamic.Controls.Add(content);
        }
    }
}
