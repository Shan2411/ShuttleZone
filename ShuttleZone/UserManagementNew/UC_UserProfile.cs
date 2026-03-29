using System;
using System.IO;
using System.Windows.Forms;
using User = ShuttleZone.UserManagement.UserModel;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_UserProfile : UserControl
    {
        public event EventHandler EditProfileClicked;

        private User currentUser;


        public UC_UserProfile()
        {
            InitializeComponent();
            guna2ComboBox1.Items.AddRange(new object[]
    {
        "Active",
        "Inactive"
    });

            guna2ComboBox1.SelectedIndex = 0; // 

            guna2ComboBox1.SelectedIndexChanged += (s, e) =>
            {
                if (currentUser == null) return;

                string status = guna2ComboBox1.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(status))
                {
                    currentUser.Status = status;

                    var repo = new ShuttleZone.UserManagement.UserRepository();
                    repo.UpdateUserStatus(currentUser.ID, status);
                }
            };
        }

        //public UC_UserProfile(User user) : this()
        //{
         //   SetUser(user);
       // }

        public void SetUser(User user)
        {
            currentUser = user;
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (currentUser == null) return;

            // ✅ Show fallback text if empty
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

            // ✅ Safe image loading with relative path fix
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
                        guna2CirclePictureBox1.Image = null;
                    }
                }
                else
                {
                    guna2CirclePictureBox1.Image = null; // fallback
                }
            }
            else
            {
                guna2CirclePictureBox1.Image = null; // fallback
            }
        }

        /*private void LoadProfile()
        {
            if (currentUser == null) return;

            // ✅ Show fallback text if empty
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

            // ✅ Safe image loading
            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath) &&
                File.Exists(currentUser.ProfileImagePath))
            {
                try
                {
                    guna2CirclePictureBox1.ImageLocation = currentUser.ProfileImagePath;
                }
                catch
                {
                    guna2CirclePictureBox1.Image = null;
                }
            }
        }*/

        // ✅ Edit button (make sure Designer is linked to this)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // intentionally empty
        }

        // ✅ FIXED CLOSE BUTTON
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

        /*private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.Add("Active");
            guna2ComboBox1.Items.Add("Inactive");
        }*/


    }
}