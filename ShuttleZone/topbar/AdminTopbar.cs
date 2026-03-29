using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO; // ✅ ADDED
using ShuttleZone.UserManagement; // ✅ ADDED

namespace ShuttleZone.topbar
{
    public partial class AdminTopbar : UserControl
    {
        public event EventHandler AdminBtnClicked;
        public event EventHandler ManagerBtnClicked;
        public event EventHandler FrontDeskBtnClicked;
        public event EventHandler SettingsBtnClicked;
        public event EventHandler ProfileClicked; // ✅ ADDED

        public AdminTopbar()
        {
            InitializeComponent();

            ProfileBtn.Visible = true;

            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");

            LoadCurrentUser(); // ✅ ADDED

            // ✅ FIX: Make sure ONLY ONE handler is used
            ProfileBtn.Click += ProfileBtn_Click;
        }

        // ✅ ADDED (MAIN PROFILE CLICK EVENT)
        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            ProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LoadCurrentUser() // ✅ FIXED
        {
            var repo = new UserRepository();
            var user = repo.GetUserById(UserSession.UserId);

            if (user == null) return;

            // ✅ OPTIONAL (enable if you want username shown)
            // lblUsername.Text = user.Username;

            // ❌ BUG FIX: removed semicolon after if
            if (!string.IsNullOrEmpty(user.ProfileImagePath))
            {
                string path = Path.Combine(Application.StartupPath, user.ProfileImagePath);

                // ❌ BUG FIX: removed semicolon
                if (File.Exists(path))
                {
                    // ✅ ENABLE THIS if you want profile image
                    // profilePic.ImageLocation = path;
                }
            }
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AdminBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ManagerBtn_Click(object sender, EventArgs e)
        {
            ManagerBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void FrontDeskBtn_Click(object sender, EventArgs e)
        {
            FrontDeskBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ❌ REMOVE THIS (duplicate event, causes confusion)
        // private void ProfileBtn_Click_1(object sender, EventArgs e) { }
    }
}