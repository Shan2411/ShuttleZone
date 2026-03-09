using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ShuttleZone.SystemSettings
{
    public partial class UC_SystemSettings : UserControl
    {
        private UserControl _currentControl;

        // Colors
        private readonly Color ActivePurple = Color.FromArgb(139, 92, 246);
        private readonly Color InactiveGray = Color.FromArgb(107, 114, 128);

        public UC_SystemSettings()
        {
            InitializeComponent();
        }

        // THIS MATCHES YOUR DESIGNER
        private void SystemSettings_Load(object sender, EventArgs e)
        {
            // Make Facility Info active on start
            FacilityInfoButton.Checked = true;
            LoadUserControl(new UC_FacilityInfo());
        }

        // LOAD USER CONTROL
        private void LoadUserControl(UserControl control)
        {
            pnlContent.Controls.Clear();
            _currentControl = control;

            control.Dock = DockStyle.Top;

            // Set different heights per control type
            if (control is SystemPreferences)
            {
                control.Height = 450; 
            }
            else
            {
                control.Height = 600; 
            }

            pnlContent.Controls.Add(control);
        }


        // BUTTON EVENTS
        private void FacilityInfoButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_FacilityInfo());
        }

        private void AlertsButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_AlertMain());
        }

        private void SystemPreferenceButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new SystemPreferences());
        }

        // SAVE BUTTON (UNCHANGED)
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_currentControl is ISaveable saveable)
            {
                try
                {
                    saveable.Save();

                    MessageBox.Show("Changes saved successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes:\n" + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nothing to save in this section.",
                                "Notice",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }



        private void uC_FacilityInfo1_Load(object sender, EventArgs e) { }
        private void pnlContent_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e) { }
    }
}
