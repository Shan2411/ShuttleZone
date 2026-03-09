using System;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_AddUserMain : UserControl
    {
        public UserModel NewUser { get; private set; }
        public event EventHandler<UserModel> UserCreated;
        public event EventHandler CloseRequested;

        public UC_AddUserMain()
        {
            InitializeComponent();

            InitializeComboBoxes();
            InitializeControlState();

            // Wire up text changed events for validation
            UsernameTextBox.TextChanged += UsernameTextBox_TextChanged;
            FullNameTextBox.TextChanged += FullNameTextBox_TextChanged;
        }

        #region Initialization

        private void InitializeComboBoxes()
        {
            RoleComboBox.Items.Clear();
            RoleComboBox.Items.AddRange(new string[] { "Admin", "Manager", "Staff" });
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.SelectedIndex = -1;

            StatusComboBox.Items.Clear();
            StatusComboBox.Items.Add("Active");
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.SelectedIndex = 0;
        }

        private void InitializeControlState()
        {
            CreateButton.Enabled = false;

            RoleComboBox.SelectedIndexChanged += (s, e) =>
            {
                ValidateForm();
            };
        }

        #endregion

        #region Validation

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Remove digits from username
            if (UsernameTextBox.Text.Any(char.IsDigit))
            {
                UsernameTextBox.Text = new string(UsernameTextBox.Text.Where(c => !char.IsDigit(c)).ToArray());
                UsernameTextBox.SelectionStart = UsernameTextBox.Text.Length; // keep cursor at end
            }

            ValidateForm();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Remove digits from full name
            if (FullNameTextBox.Text.Any(char.IsDigit))
            {
                FullNameTextBox.Text = new string(FullNameTextBox.Text.Where(c => !char.IsDigit(c)).ToArray());
                FullNameTextBox.SelectionStart = FullNameTextBox.Text.Length;
            }

            ValidateForm();
        }

        private void ValidateForm()
        {
            // Enable Create only if all required fields filled + role selected
            CreateButton.Enabled =
                !string.IsNullOrWhiteSpace(UsernameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(FullNameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(EmailTextBox.Text) &&
                RoleComboBox.SelectedIndex != -1;
        }

        #endregion

        #region Create User

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string fullname = FullNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(email))
            {
                ShowValidation("Please fill in all required fields.");
                return;
            }

            if (RoleComboBox.SelectedIndex == -1)
            {
                ShowValidation("Please select a role.");
                return;
            }

            // Email validation
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                ShowValidation("Please enter a valid email address.");
                return;
            }

            // Create user
            NewUser = new UserModel
            {
                ID = "U" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper(),
                Username = username,
                FullName = fullname,
                Email = email,
                Role = RoleComboBox.SelectedItem.ToString(),
                Status = "Active",
                LastLogin = DateTime.Now
            };

            UserCreated?.Invoke(this, NewUser);
            ClearForm();
        }

        #endregion

        #region Clear Form

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            UsernameTextBox.Clear();
            FullNameTextBox.Clear();
            EmailTextBox.Clear();
            RoleComboBox.SelectedIndex = -1;
            StatusComboBox.SelectedIndex = 0;
            CreateButton.Enabled = false;
            UsernameTextBox.Focus();
        }

        #endregion

        #region Close

        // Close for "X" button in designer
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion                                                                                                              

        #region Helpers

        private void ShowValidation(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }
}
