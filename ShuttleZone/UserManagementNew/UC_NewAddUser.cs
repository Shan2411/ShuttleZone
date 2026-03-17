using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_NewAddUser : UserControl
    {
        public event EventHandler<UserModel> UserCreated;

        public IList<string> ExistingUsernames { get; set; } = new List<string>();
        public UserModel CreatedUser { get; internal set; }
        public string LoggedInRole { get; internal set; }
        public FormStartPosition StartPosition { get; internal set; }

        public UC_NewAddUser()
        {
            InitializeComponent();

            txtPhone.KeyPress += TxtPhone_KeyPress;

            // Hide password by default
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            btnShowPassword.Text = "Show";
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            if (ExistingUsernames.Any(u =>
                u.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            var user = new UserModel
            {
                Username = txtUsername.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text,
                Role = cmbRole.Text,
                Status = cmbStatus.Text
            };

            UserCreated?.Invoke(this, user);

            MessageBox.Show("User created successfully!");

            ClearFields();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            cmbRole.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
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

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (txtPhone.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;

            btnShowPassword.Text =
                txtPassword.UseSystemPasswordChar ? "Show" : "Hide";
        }

        internal DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }
        /* // Optional empty handlers (safe if designer created them)
private void cmbRole_SelectedIndexChanged(object sender, EventArgs e) { }

private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }

private void txtPassword_TextChanged(object sender, EventArgs e) { }

private void txtConfirmPassword_TextChanged(object sender, EventArgs e) { }

private void txtPassword_IconRightClick(object sender, EventArgs e) { }

private void txtConfirmPassword_IconRightClick(object sender, EventArgs e) { }

private void CloseButton_Click(object sender, EventArgs e)
{
    this.FindForm()?.Close();
}*/
    }
}