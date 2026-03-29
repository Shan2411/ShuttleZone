using ShuttleZone.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_ProfileView : UserControl
    {
        public UC_ProfileView()
        {
            InitializeComponent();
        }

        private UserModel currentUser;

        public void SetUser(UserModel user)
        {
            currentUser = user;
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (currentUser == null) return;

            lblFullName.Text = currentUser.FullName ?? "No Name";
            lblUsername.Text = currentUser.Username ?? "No Username";
            lblEmail.Text = currentUser.Email ?? "No Email";
            lblPhone.Text = currentUser.PhoneNumber ?? "No Phone";
            lblRole.Text = currentUser.Role ?? "No Role";

            //guna2ComboBox1.SelectedItem = currentUser.Status;
            //
            // Disable editing
            //guna2ComboBox1.Enabled = false;

            // Load image
            if (!string.IsNullOrEmpty(currentUser.ProfileImagePath))
            {
                string fullPath = Path.Combine(Application.StartupPath, currentUser.ProfileImagePath);
                if (File.Exists(fullPath))
                    guna2CirclePictureBox1.ImageLocation = fullPath;
            }
        }
        /*private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }*/

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }
    }
}
