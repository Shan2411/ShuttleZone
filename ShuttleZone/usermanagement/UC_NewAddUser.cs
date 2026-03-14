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

        public UC_NewAddUser()
        {
            InitializeComponent();

            CreateButton.Click += CreateButton_Click;
            CancelButton.Click += CancelButton_Click;
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

            // Fire event to parent control
            UserCreated?.Invoke(this, user);
        }

        private void CancelButton_Click(object sender, EventArgs e)
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

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return false;
            }

            return true;
        }
    }
}
