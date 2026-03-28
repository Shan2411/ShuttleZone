using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using User = ShuttleZone.UserManagement.UserModel;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_EditProfileMain : UserControl
    {
        private User currentUser;

        public event EventHandler ChangePasswordClicked;
        public event EventHandler FormClosed;

        public UC_EditProfileMain()
        {
            InitializeComponent();
            WireEvents();
        }

        public UC_EditProfileMain(User user) : this()
        {
            currentUser = user;
            LoadUserData();
        }

        private void WireEvents()
        {
            if (ConfirmEdit != null)
                ConfirmEdit.Click += ConfirmEdit_Click;

            if (ResetButton != null)
                ResetButton.Click += ResetButton_Click;

            if (guna2Button2 != null)
                guna2Button2.Click += (s, e) =>
                    ChangePasswordClicked?.Invoke(this, EventArgs.Empty);

            if (guna2Button1 != null)
                guna2Button1.Click += SelectImage_Click;

            if (CloseButton != null)
                CloseButton.Click += CloseButton_Click;

            if (FullNameTextBox != null)
                FullNameTextBox.TextChanged += FullNameTextBox_TextChanged;

            if (guna2TextBox1 != null)
            {
                guna2TextBox1.KeyPress += Phone_KeyPress;
                guna2TextBox1.TextChanged += Phone_TextChanged;
            }


        }

        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.Length > 11)
            {
                guna2TextBox1.Text = guna2TextBox1.Text.Substring(0, 11);
                guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
            }
        }

        private void LoadUserData()
        {
            if (currentUser == null) return;

            FullNameTextBox.Text = currentUser.FullName ?? "";
            UserNameTextBox.Text = currentUser.Username ?? "";
            EmailTextBox.Text = currentUser.Email ?? "";

            // ✅ SAME LOGIC: show "No phone" if empty
            guna2TextBox1.Text = string.IsNullOrWhiteSpace(currentUser.PhoneNumber)
                ? "No phone"
                : currentUser.PhoneNumber;

            lblRole.Text = (currentUser.Role ?? "");

            //"Role: " +

            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath) &&
                File.Exists(currentUser.ProfileImagePath))
            {
                guna2CirclePictureBox1.ImageLocation = currentUser.ProfileImagePath;
            }
        }

        private void ConfirmEdit_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            if (!ValidateFields()) return;

            // ✅ Update user (same style as AddUser)
            currentUser.FullName = FullNameTextBox.Text.Trim();
            currentUser.Username = UserNameTextBox.Text.Trim();
            currentUser.Email = EmailTextBox.Text.Trim();

            // ✅ Save phone properly
            currentUser.PhoneNumber =
                guna2TextBox1.Text == "No phone" ? "" : guna2TextBox1.Text.Trim();

            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormClosed?.Invoke(this, EventArgs.Empty);
            this.FindForm()?.Close();
        }

        private bool ValidateFields()
        {
            // ✅ SAME AS ADD USER
            if (string.IsNullOrWhiteSpace(UserNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(EmailTextBox.Text, pattern))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            // Optional phone validation (only if user typed real number)
            if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text) &&
                guna2TextBox1.Text != "No phone" &&
                guna2TextBox1.Text.Length != 11)
            {
                MessageBox.Show("Phone must be 11 digits.");
                return false;
            }

            return true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            // 🔹 Reset text fields
            FullNameTextBox.Text = currentUser.FullName ?? "";
            UserNameTextBox.Text = currentUser.Username ?? "";
            EmailTextBox.Text = currentUser.Email ?? "";

            // 🔹 Reset phone
            guna2TextBox1.Text = string.IsNullOrWhiteSpace(currentUser.PhoneNumber)
                ? "No phone"
                : currentUser.PhoneNumber;

            // 🔹 Reset role label
            lblRole.Text = currentUser.Role ?? "";

            // 🔹 Reset image
            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath) &&
                File.Exists(currentUser.ProfileImagePath))
            {
                guna2CirclePictureBox1.ImageLocation = currentUser.ProfileImagePath;
            }
            else
            {
                guna2CirclePictureBox1.Image = null;
            }

            // 🔹 Reset button state (important)
            if (ConfirmEdit != null)
                ConfirmEdit.Enabled = true;

            // 🔹 Reset cursor positions (UX polish)
            FullNameTextBox.SelectionStart = FullNameTextBox.Text.Length;
            UserNameTextBox.SelectionStart = UserNameTextBox.Text.Length;
            EmailTextBox.SelectionStart = EmailTextBox.Text.Length;
            guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
        }

        private void SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        guna2CirclePictureBox1.ImageLocation = ofd.FileName;

                        if (currentUser != null)
                            currentUser.ProfileImagePath = ofd.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load image.");
                    }
                }
            }
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ConfirmEdit != null)
                ConfirmEdit.Enabled =
                    !string.IsNullOrWhiteSpace(FullNameTextBox.Text);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            FormClosed?.Invoke(this, EventArgs.Empty);
            this.FindForm()?.Close();
        }

        private void lblRole_Click(object sender, EventArgs e)
        {
            // optional
        }
    }
}