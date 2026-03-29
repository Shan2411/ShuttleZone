using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using User = ShuttleZone.UserManagement.UserModel;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_UserProfile : UserControl
    {
        public event EventHandler EditProfileClicked;

        private User currentUser;

        private bool isLoading = false; // ✅ used to prevent auto DB updates

        public UC_UserProfile()
        {
            InitializeComponent();
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            guna2ComboBox1.Items.AddRange(new object[]
            {
                "Active",
                "Inactive"
            });

            // ❌ REMOVED SelectedIndex = 0 (causes auto update)

            guna2ComboBox1.SelectedIndexChanged += (s, e) =>
            {
                if (isLoading) return;
                if (currentUser == null) return;

                string status = guna2ComboBox1.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(status))
                {
                    SetStatusComboStyle(status);

                    // ✅ ONLY update UI, NOT database
                    currentUser.Status = status;
                }
            };
        }

        public void SetUser(User user)
        {
            currentUser = user;

            isLoading = true;     // ✅ prevent event firing
            LoadProfile();
            isLoading = false;    // ✅ re-enable after load
        }

        private void SetStatusComboStyle(string status)
        {
            if (status == "Active")
            {
                guna2ComboBox1.FillColor = Color.FromArgb(198, 239, 206);
                guna2ComboBox1.ForeColor = Color.FromArgb(0, 97, 0);
                guna2ComboBox1.BorderColor = Color.FromArgb(0, 97, 0);
            }
            else
            {
                guna2ComboBox1.FillColor = Color.FromArgb(255, 199, 206);
                guna2ComboBox1.ForeColor = Color.FromArgb(156, 0, 6);
                guna2ComboBox1.BorderColor = Color.FromArgb(156, 0, 6);
            }
        }

        private void LoadProfile()
        {
            if (currentUser == null) return;

            lblFullName.Text = string.IsNullOrWhiteSpace(currentUser.FullName)
                ? "No Name"
                : currentUser.FullName;

            lblUsername.Text = string.IsNullOrWhiteSpace(currentUser.Username)
                ? "No Username"
                : currentUser.Username;

            lblEmail.Text = string.IsNullOrWhiteSpace(currentUser.Email)
                ? "No Email"
                : currentUser.Email;

            lblPhone.Text = string.IsNullOrWhiteSpace(currentUser.PhoneNumber)
                ? "No Phone Number"
                : currentUser.PhoneNumber;

            lblRole.Text = string.IsNullOrWhiteSpace(currentUser.Role)
                ? "No Role"
                : currentUser.Role;

            // ✅ SAFE STATUS SET (no auto-trigger)
            if (!string.IsNullOrEmpty(currentUser.Status))
            {
                guna2ComboBox1.SelectedItem = currentUser.Status;
                SetStatusComboStyle(currentUser.Status);
            }

            // ✅ IMAGE LOADING (unchanged)
            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath))
            {
                string fullPath = Path.Combine(Application.StartupPath, currentUser.ProfileImagePath);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        guna2CirclePictureBox1.ImageLocation = fullPath;
                    }
                    catch
                    {
                        guna2CirclePictureBox1.Image = Properties.Resources.DefaultAvatar;
                    }
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

        // ✅ Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // intentionally empty
        }

        // ✅ CLOSE BUTTON (no issue here)
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void guna2Panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BodytableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("No user loaded.");
                return;
            }

            try
            {
                // ✅ Get latest values from UI (if editable)
                currentUser.Status = guna2ComboBox1.SelectedItem?.ToString();

                // 👉 If you have textboxes for editing, include them like this:
                // currentUser.FullName = txtFullName.Text;
                // currentUser.Email = txtEmail.Text;
                // currentUser.PhoneNumber = txtPhone.Text;

                var repo = new ShuttleZone.UserManagement.UserRepository();

                // ✅ Save ALL user data (make sure this method exists)
                repo.UpdateUser(currentUser);

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
            }
        }
    }
}