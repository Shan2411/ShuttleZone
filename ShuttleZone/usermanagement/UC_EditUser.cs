using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_EditUser : UserControl
    {
        private UserModel _user;

        public event EventHandler<UserModel> UserUpdated;

        public UC_EditUser()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            txtPhone.KeyPress += TxtPhone_KeyPress;

            btnShowPassword.Text = "Show";
        }

        public void LoadUser(UserModel user)
        {
            _user = user;

            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            txtPassword.Text = user.Password;

            cmbRole.Text = user.Role;
            cmbStatus.Text = user.Status;
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            if (!ValidateFields()) return;

            _user.Username = txtUsername.Text.Trim();
            _user.FullName = txtFullName.Text.Trim();
            _user.Email = txtEmail.Text.Trim();
            _user.Phone = txtPhone.Text.Trim();
            _user.Password = txtPassword.Text;
            _user.Role = cmbRole.Text;
            _user.Status = cmbStatus.Text;

            MessageBox.Show("User updated successfully!");

            UserUpdated?.Invoke(this, _user);

            this.FindForm()?.Close();
        }

        private bool ValidateFields()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            if (txtPhone.Text.Length != 11)
            {
                MessageBox.Show("Phone must be 11 digits.");
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return false;
            }

            return true;
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (txtPhone.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnShowPassword_Click_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            btnShowPassword.Text =
                txtPassword.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void UC_EditUser_Load(object sender, EventArgs e)
        {
        }
    }
}