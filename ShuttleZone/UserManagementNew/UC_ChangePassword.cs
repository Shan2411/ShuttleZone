using System;
using System.Windows.Forms;
using ShuttleZone.UserManagement;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_ChangePassword : UserControl
    {
        public UserModel CurrentUser;

        public UC_ChangePassword()
        {
            InitializeComponent();
        }

        public void SetUser(UserModel user)
        {
            CurrentUser = user;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Designer must have txtCurrentPassword, txtNewPassword, txtConfirmPassword
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(current) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Demo validation: check current password matches CurrentUser.Password
            if (CurrentUser != null && CurrentUser.Password != null)
            {
                if (current != CurrentUser.Password)
                {
                    MessageBox.Show("Current password is incorrect.");
                    return;
                }

                // Update password (demo only)
                CurrentUser.Password = newPass;
                MessageBox.Show("Password changed successfully!");
                this.FindForm()?.Close();
            }
            else
            {
                // If no user or no stored password, just accept change for demo
                if (CurrentUser != null) CurrentUser.Password = newPass;
                MessageBox.Show("Password changed successfully!");
                this.FindForm()?.Close();
            }
        }

        // Placeholder handlers if wired in designer
        private void ShowPassword2Btn_Click(object sender, EventArgs e) { /* toggle visibility */ }
        private void txtPassword_TextChanged(object sender, EventArgs e) { /* optional */ }
        private void guna2Panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // intentionally empty - satisfies designer wiring
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            // intentionally empty - satisfies designer wiring
        }

        private void ShowPassword1Btn_Click(object sender, EventArgs e)
        {

        }
    }
}