using System;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_AddUserMain : UserControl
    {
        // Expose created user to parent
        public UserModel NewUser { get; private set; }

        // Event for parent form when user is created
        public event EventHandler<UserModel> UserCreated;

        // Event for parent form when close button is clicked
        public event EventHandler CloseRequested;

        public UC_AddUserMain()
        {
            InitializeComponent();

            InitializeComboBoxes();
            InitializeControlState();
        }

        #region Initialization

        private void InitializeComboBoxes()
        {
            // ROLE OPTIONS
            RoleComboBox.Items.Clear();
            RoleComboBox.Items.AddRange(new string[]
            {
                "Admin",
                "Manager",
                "Staff"
            });

            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.SelectedIndex = -1;

            // STATUS (FORCED ACTIVE ONLY)
            StatusComboBox.Items.Clear();
            StatusComboBox.Items.Add("Active");

            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.SelectedIndex = 0;
        }

        private void InitializeControlState()
        {
            // Disable create until role selected
            CreateButton.Enabled = false;

            RoleComboBox.SelectedIndexChanged += (s, e) =>
            {
                CreateButton.Enabled = RoleComboBox.SelectedIndex != -1;
            };
        }

        #endregion

        #region Create User

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string fullname = FullNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();

            // Required validation
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
                Status = "Active", // Always active
                LastLogin = DateTime.Now
            };

            // Notify parent
            UserCreated?.Invoke(this, NewUser);

            // Clear form after creation
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Helpers

        private void ShowValidation(string message)
        {
            MessageBox.Show(
                message,
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        #endregion
    }
}
