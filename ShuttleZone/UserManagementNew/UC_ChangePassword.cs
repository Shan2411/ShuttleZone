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

            // Wire buttons
            ConfirmEdit.Click += ConfirmEdit_Click;
            CancelButton.Click += CancelButton_Click;
            CloseButton.Click += CloseButton_Click;

            //ShowPassword1Btn.Click += ShowPassword1Btn_Click;
           // ShowPassword2Btn.Click += ShowPassword2Btn_Click;

            // Default hidden passwords
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        public void SetUser(UserModel user)
        {
            CurrentUser = user;
        }

        // =========================
        // ✅ MAIN ACTION
        // =========================
        private void ConfirmEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            MessageBox.Show("Password changed successfully!");
        }

        // =========================
        // ✅ VALIDATION (LIKE YOUR STYLE)
        // =========================
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            return true;
        }

        // =========================
        // 🧹 CLEAR
        // =========================
        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        // =========================
        // ❌ CLOSE
        // =========================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        // =========================
        // 👁 SHOW / HIDE
        // =========================

        private void ShowPassword1Btn_Click(object sender, EventArgs e)
        {
            bool isHidden = txtCurrentPassword.UseSystemPasswordChar;

            txtCurrentPassword.UseSystemPasswordChar = !isHidden;
            txtCurrentPassword.PasswordChar = isHidden ? '\0' : '●';

            ShowPassword1Btn.Text =
                isHidden ? "Hide Password" : "Show Password";
        }

        private void ShowPassword2Btn_Click(object sender, EventArgs e)
        {
            bool isHidden = txtNewPassword.UseSystemPasswordChar;

            txtNewPassword.UseSystemPasswordChar = !isHidden;
            txtConfirmPassword.UseSystemPasswordChar = !isHidden;

            txtNewPassword.PasswordChar = isHidden ? '\0' : '●';
            txtConfirmPassword.PasswordChar = isHidden ? '\0' : '●';

            ShowPassword2Btn.Text =
                isHidden ? "Hide Password" : "Show Password";
        }

        // =========================
        // OPTIONAL EMPTY HANDLERS
        // =========================
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}