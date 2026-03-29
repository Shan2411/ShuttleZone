using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO; // ✅ ADDED
using ShuttleZone.UserManagement; // ✅ ADDED

namespace ShuttleZone.topbar
{
    public partial class MFTopbar : UserControl
    {
        public event EventHandler AdminBtnClicked;
        public event EventHandler ManagerBtnClicked;
        public event EventHandler FrontDeskBtnClicked;
        public event EventHandler ProfileClicked; // ✅ ADDED

        public MFTopbar()
        {
            InitializeComponent();

            var date = DateTime.Now;
            DateLbl.Text = date.ToString("dddd, MMMM dd, yyyy");

            LoadCurrentUser(); // ✅ ADDED

            // ✅ FIX: Proper click hookup
            ProfileBtn.Click += ProfileBtn_Click;
        }

        // ✅ ADDED
        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            ProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LoadCurrentUser() // ✅ FIXED
        {
            var repo = new UserRepository();
            var user = repo.GetUserById(UserSession.UserId);

            if (user == null) return;

            // OPTIONAL
            // lblUsername.Text = user.Username;

            // ❌ BUG FIX: removed semicolon
            if (!string.IsNullOrEmpty(user.ProfileImagePath))
            {
                string path = Path.Combine(Application.StartupPath, user.ProfileImagePath);

                if (File.Exists(path)) // ❌ FIXED
                {
                    // profilePic.ImageLocation = path;
                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void DateLbl_Click(object sender, EventArgs e)
        {

        }

        // ❌ REMOVE THIS
        // private void ProfileBtn_Click_1(object sender, EventArgs e) { }
    }
}