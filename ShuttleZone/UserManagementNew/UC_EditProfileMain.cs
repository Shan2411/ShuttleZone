using System;
using System.Windows.Forms;
using User = ShuttleZone.UserManagement.UserModel;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_EditProfileMain : UserControl
    {
        private User currentUser;

        // Event: open change password modal
        public event EventHandler ChangePasswordClicked;

        // Event: notify parent when form closes (optional but useful)
        public event EventHandler FormClosed;

        public UC_EditProfileMain()
        {
            InitializeComponent();
            WireEvents(); // IMPORTANT: always wire events
        }

        public UC_EditProfileMain(User user) : this()
        {
            currentUser = user;
            LoadUserData();
        }

        private void WireEvents()
        {
            // Make sure these controls EXIST in Designer
            if (ConfirmEdit != null)
                ConfirmEdit.Click += ConfirmEdit_Click;

            if (ResetButton != null)
                ResetButton.Click += ResetButton_Click;

            if (guna2Button2 != null)
                guna2Button2.Click += (s, e) => ChangePasswordClicked?.Invoke(this, EventArgs.Empty);

            if (guna2Button1 != null)
                guna2Button1.Click += SelectImage_Click;

            if (CloseButton != null)
                CloseButton.Click += (s, e) =>
                {
                    FormClosed?.Invoke(this, EventArgs.Empty); // notify parent
                    this.FindForm()?.Close();
                };
        }

        private void LoadUserData()
        {
            if (currentUser == null) return;

            if (FullNameTextBox != null)
                FullNameTextBox.Text = currentUser.FullName ?? "";

            if (UserNameTextBox != null)
                UserNameTextBox.Text = currentUser.Username ?? "";

            if (EmailTextBox != null)
                EmailTextBox.Text = currentUser.Email ?? "";

            if (guna2TextBox1 != null)
                guna2TextBox1.Text = currentUser.PhoneNumber ?? "";

            if (lblRole != null)
                lblRole.Text = "Role: " + (currentUser.Role ?? "");

            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath) && guna2CirclePictureBox1 != null)
            {
                guna2CirclePictureBox1.ImageLocation = currentUser.ProfileImagePath;
            }
        }

        private void ConfirmEdit_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            // Update user data
            currentUser.FullName = FullNameTextBox?.Text;
            currentUser.Username = UserNameTextBox?.Text;
            currentUser.Email = EmailTextBox?.Text;
            currentUser.PhoneNumber = guna2TextBox1?.Text;

            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Notify parent before closing
            FormClosed?.Invoke(this, EventArgs.Empty);

            // Close popup
            this.FindForm()?.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (guna2CirclePictureBox1 != null)
                        guna2CirclePictureBox1.ImageLocation = ofd.FileName;

                    if (currentUser != null)
                        currentUser.ProfileImagePath = ofd.FileName;
                }
            }
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ConfirmEdit != null)
                ConfirmEdit.Enabled = !string.IsNullOrWhiteSpace(FullNameTextBox.Text);
        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

        }
    }
}