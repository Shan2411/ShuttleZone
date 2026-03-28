using System;
using System.Windows.Forms;
using User = ShuttleZone.UserManagement.UserModel;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_UserProfile : UserControl
    {
        public event EventHandler EditProfileClicked;

        private User currentUser;

        // Parameterless constructor for designer and for UC_UserManagement to instantiate
        public UC_UserProfile()
        {
            InitializeComponent();
        }

        // Optional convenience constructor
        public UC_UserProfile(User user) : this()
        {
            SetUser(user);
        }

        public void SetUser(User user)
        {
            currentUser = user;
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (currentUser == null) return;

            // Designer must have these controls
            lblFullName.Text = currentUser.FullName ?? "";
            lblUsername.Text = currentUser.Username ?? "";
            lblEmail.Text = currentUser.Email ?? "";
            lblPhone.Text = currentUser.PhoneNumber ?? "";
            lblRole.Text = currentUser.Role ?? "";

            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath) && guna2CirclePictureBox1 != null)
            {
                guna2CirclePictureBox1.ImageLocation = currentUser.ProfileImagePath;
            }
        }

        // Raise event so parent can open edit modal
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProfileClicked?.Invoke(this, EventArgs.Empty);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // intentionally empty
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

        }
    }
}