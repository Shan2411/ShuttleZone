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
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

            lblPhone.Text = string.IsNullOrWhiteSpace(currentUser.PhoneNumber)
                ? "No Number"
                : currentUser.PhoneNumber;

            lblRole.Text = currentUser.Role ?? "No Role";

            // ✅ SIMPLE STATUS (NO DESIGN)
            Statuslbl.Text = string.IsNullOrWhiteSpace(currentUser.Status)
                ? "Inactive"
                : currentUser.Status;

            // IMAGE
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

        private void Statuslbl_Click(object sender, EventArgs e)
        {

        }


    }
}
