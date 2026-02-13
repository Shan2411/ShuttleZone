using System;
using System.Windows.Forms;

namespace ShuttleZone.SystemSettings
{
    public partial class SystemPreferences : UserControl, ISaveable
    {
        public SystemPreferences()
        {
            InitializeComponent();
        }

        // Required by ISaveable (called from parent)
        public void Save()
        {
            // Nothing to save for now
        }

       
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void EnableAutoLogout_Click(object sender, EventArgs e) { }
        private void OpeningTimeTextBox_KeyPress(object sender, KeyPressEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void BusinessNameTextBox_TextChanged(object sender, EventArgs e) { }
    }
}
