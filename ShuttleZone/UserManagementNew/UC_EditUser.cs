using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_EditUser : UserControl
    {
        private UserModel _user;
        private UserModel _originalUser;

        public event EventHandler<UserModel> UserUpdated;

        public UC_EditUser()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            txtPhone.KeyPress += TxtPhone_KeyPress;

            btnShowPassword.Text = "Show";

            LoadRoles();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("FrontDesk");
        }

        public void LoadUser(UserModel user)
        {
            _user = user;

            _originalUser = new UserModel
            {
                ID = user.ID,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status
            };

            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            txtPassword.Text = user.Password;
            txtConfirmPassword.Text = user.Password;

            cmbRole.Text = user.Role;
            cmbStatus.Text = user.Status;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

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

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            return true;
        }

        private void ConfirmEdit_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            if (!ValidateFields()) return;

            var confirm = MessageBox.Show(
                "Are you sure you want to update this user?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Discard changes?",
                "Cancel Edit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            if (_originalUser == null) return;

            txtUsername.Text = _originalUser.Username;
            txtFullName.Text = _originalUser.FullName;
            txtEmail.Text = _originalUser.Email;
            txtPhone.Text = _originalUser.Phone;
            txtPassword.Text = _originalUser.Password;
            txtConfirmPassword.Text = _originalUser.Password;

            cmbRole.Text = _originalUser.Role;
            cmbStatus.Text = _originalUser.Status;
        }

        private void btnShowPassword_Click_1(object sender, EventArgs e)
        {
            bool isHidden = txtPassword.UseSystemPasswordChar;

            txtPassword.UseSystemPasswordChar = !isHidden;
            txtConfirmPassword.UseSystemPasswordChar = !isHidden;

            btnShowPassword.Text = isHidden ? "Hide" : "Show";
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (txtPhone.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
        }
        private void UC_EditUser_Load(object sender, EventArgs e)
        {
        }
    }
}