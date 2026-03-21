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
            btnSaveChanges.Click += BtnSaveChanges_Click;

            txtPanelHeader.Text = Kiosk.BannerHeaderText;
            txtPromoCard.Text = Kiosk.PromoText;
            switchAutoReturnHome.Checked = Kiosk.AutoReturnHomeEnabled;
            txtSessionTimeout.Text = Kiosk.SessionTimeoutMinutes.ToString();
        }

        private void BtnRunKiosk_Click(object sender, EventArgs e)
        {
            var kiosk = new Kiosk();
            kiosk.Show();
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            int sessionTimeoutMinutes = Kiosk.SessionTimeoutMinutes;
            string timeoutText = txtSessionTimeout.Text.Trim();

            if (switchAutoReturnHome.Checked)
            {
                if (!int.TryParse(timeoutText, out sessionTimeoutMinutes) || sessionTimeoutMinutes < 1)
                {
                    MessageBox.Show("Please enter a valid session timeout in minutes (1 or higher).");
                    return;
                }
            }
            else
            {
                int parsedMinutes;
                if (int.TryParse(timeoutText, out parsedMinutes) && parsedMinutes > 0)
                {
                    sessionTimeoutMinutes = parsedMinutes;
                }
            }

            Kiosk.UpdateAutoReturnSettings(switchAutoReturnHome.Checked, sessionTimeoutMinutes);
            Kiosk.UpdateTexts(txtPanelHeader.Text, txtPromoCard.Text);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlAutoReturn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
