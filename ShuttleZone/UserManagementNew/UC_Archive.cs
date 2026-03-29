using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShuttleZone.UserManagement;

namespace ShuttleZone.UserManagementNew
{
    public partial class UC_Archive : UserControl
    {
        // ✅ Repository
        private UserRepository repo = new UserRepository();

        // ✅ Cached archived users
        private List<UserModel> archivedUsers = new List<UserModel>();

        // ✅ Optional role control
        private string CurrentRole = "admin";

        public UC_Archive()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            Load += UC_Archive_Load;

            // ✅ Setup FlowLayoutPanel
            flpMemberRowContainer.FlowDirection = FlowDirection.TopDown;
            flpMemberRowContainer.WrapContents = false;
            flpMemberRowContainer.AutoScroll = true;

            flpMemberRowContainer.SizeChanged += (s, e) =>
            {
                foreach (Control ctrl in flpMemberRowContainer.Controls)
                    ctrl.Width = flpMemberRowContainer.ClientSize.Width;
            };

            // ✅ Search + Filter
            Searchbox.TextChanged += (s, e) => ApplySearch();

            guna2ComboBox1.Items.AddRange(new string[]
            {
                "All",
                "Username",
                "Full Name",
                "Email",
                "Role"
            });

            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndexChanged += (s, e) => ApplySearch();
        }

        private void UC_Archive_Load(object sender, EventArgs e)
        {
            LoadArchivedUsers();
        }

        // 🔥 LOAD ONLY ARCHIVED USERS
        private void LoadArchivedUsers()
        {
            archivedUsers.Clear();

            var allUsers = repo.GetAllUsers();

            archivedUsers.AddRange(
                allUsers.Where(u => u.Status == "Inactive")
            );

            RenderUsers(archivedUsers);
        }

        // 🔥 RENDER USERS
        private void RenderUsers(List<UserModel> users)
        {
            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            foreach (var user in users)
            {
                var row = new UC_UserRow
                {
                    User = user,
                    Role = CurrentRole,
                    Margin = new Padding(0),
                    Width = flpMemberRowContainer.ClientSize.Width
                };

                row.UpdateDisplay();

                // ❌ NO DELETE IN ARCHIVE

                // ✅ RESTORE
                row.RestoreClicked += (s, e) =>
                {
                    if (CurrentRole != "admin") return;

                    var confirm = MessageBox.Show(
                        $"Restore {user.Username}?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        repo.RestoreUser(user.ID);
                        LoadArchivedUsers();
                    }
                };

                // ❌ OPTIONAL: DISABLE EDIT
                row.EditClicked += (s, e) =>
                {
                    MessageBox.Show("Cannot edit archived user.");
                };

                flpMemberRowContainer.Controls.Add(row);
            }

            flpMemberRowContainer.ResumeLayout();
        }

        // 🔥 SEARCH
        private void ApplySearch()
        {
            string query = Searchbox.Text.Trim().ToLower();
            string column = guna2ComboBox1.SelectedItem?.ToString();

            var filtered = archivedUsers.Where(u =>
            {
                if (string.IsNullOrEmpty(query))
                    return true;

                switch (column)
                {
                    case "Username":
                        return (u.Username ?? "").ToLower().Contains(query);
                    case "Full Name":
                        return (u.FullName ?? "").ToLower().Contains(query);
                    case "Email":
                        return (u.Email ?? "").ToLower().Contains(query);
                    case "Role":
                        return (u.Role ?? "").ToLower().Contains(query);
                    default:
                        return (u.Username ?? "").ToLower().Contains(query)
                            || (u.FullName ?? "").ToLower().Contains(query)
                            || (u.Email ?? "").ToLower().Contains(query)
                            || (u.Role ?? "").ToLower().Contains(query);
                }
            }).ToList();

            RenderUsers(filtered);
        }
    }
}