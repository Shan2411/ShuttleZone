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
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        // ================= PHONE INPUT =================
        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.Length > 11)
            {
                guna2TextBox1.Text = guna2TextBox1.Text.Substring(0, 11);
                guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
            }
        }

        // ================= LOAD USER =================
        private void LoadUserData()
        {
            if (currentUser == null) return;

            FullNameTextBox.Text = currentUser.FullName ?? "";
            UserNameTextBox.Text = currentUser.Username ?? "";
            EmailTextBox.Text = currentUser.Email ?? "";

            // ✅ FIX: placeholder instead of actual text
            if (string.IsNullOrWhiteSpace(currentUser.PhoneNumber))
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.PlaceholderText = "No phone";
            }
            else
            {
                guna2TextBox1.Text = currentUser.PhoneNumber;
                guna2TextBox1.PlaceholderText = "";
            }

            lblRole.Text = currentUser.Role ?? "";

            string path = currentUser.ProfileImagePath;

            if (!string.IsNullOrWhiteSpace(path))
            {
                string fullPath = Path.Combine(Application.StartupPath, path);

                if (File.Exists(fullPath))
                {
                    guna2CirclePictureBox1.ImageLocation = fullPath;
                }
                else
                {
                    guna2CirclePictureBox1.Image = Properties.Resources.DefaultAvatar;
                }
            }
            else
            {
                guna2CirclePictureBox1.Image = Properties.Resources.DefaultAvatar;
            }
        }

        // ================= SAVE =================
        private void ConfirmEdit_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            if (!ValidateFields()) return;

            currentUser.FullName = FullNameTextBox.Text.Trim();
            currentUser.Username = UserNameTextBox.Text.Trim();
            currentUser.Email = EmailTextBox.Text.Trim();

            // ✅ Save properly
            currentUser.PhoneNumber = string.IsNullOrWhiteSpace(guna2TextBox1.Text)
                ? ""
                : guna2TextBox1.Text.Trim();

            // ❌ OLD
            // MessageBox.Show("Profile updated successfully!", "Success",
            //     MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ✅ NEW
            var repo = new ShuttleZone.UserManagement.UserRepository();
            repo.UpdateUser(currentUser);

            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormClosed?.Invoke(this, EventArgs.Empty);
            this.FindForm()?.Close();
        }

        // ================= VALIDATION =================
        private bool ValidateFields()
        {
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

            // ✅ Only validate if user typed something
            if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text) &&
                guna2TextBox1.Text.Length != 11)
            {
                MessageBox.Show("Phone must be 11 digits.");
                return false;
            }

            return true;
        }

        // ================= RESET =================
        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            LoadUserData(); // ✅ reuse instead of duplicating logic

            if (ConfirmEdit != null)
                ConfirmEdit.Enabled = true;
        }

        // ================= IMAGE =================

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
                        if (currentUser == null) return;

                        // ✅ Create folder
                        string folder = Path.Combine(Application.StartupPath, "ProfileImages");

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        // ✅ Get file extension
                        string ext = Path.GetExtension(ofd.FileName);

                        // ✅ Create filename based on user ID
                        string newFileName = currentUser.ID + ext;

                        // ✅ Full destination path
                        string newPath = Path.Combine(folder, newFileName);

                        // ✅ Copy file into app folder
                        File.Copy(ofd.FileName, newPath, true);

                        // ✅ Save RELATIVE path to DB
                        currentUser.ProfileImagePath = "ProfileImages/" + newFileName;

                        // ✅ Display image
                        guna2CirclePictureBox1.ImageLocation = newPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load image: " + ex.Message);
                    }
                }
            }
        }
        /*private void SelectImage_Click(object sender, EventArgs e)
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
                            currentUser.ProfileImagePath = "ProfileImages/" + newFileName;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load image.");
                    }
                }
            }
        }*/

        // ================= UI EVENTS =================
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

        // ✅ KEPT (DO NOT REMOVE - DESIGNER SAFE)
        private void ConfirmEdit_Click_1(object sender, EventArgs e) { }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }

        private void ConfirmEdit_Click_2(object sender, EventArgs e) { }
    }
}