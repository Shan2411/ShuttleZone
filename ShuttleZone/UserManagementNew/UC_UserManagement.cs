using ShuttleZone.UserManagementNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserManagement : UserControl
    {
        private readonly List<UserModel> _users = new List<UserModel>();
        private UserRepository repo = new UserRepository();
        private bool isProfileOpen = false;
        private bool showingArchived = false;

        private string CurrentRole => UserSession.Role?.ToLower().Trim();

        public UC_UserManagement()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            Load += UC_UserManagement_Load;
            Searchbox.TextChanged += Searchbox_TextChanged;

            flpMemberRowContainer.FlowDirection = FlowDirection.TopDown;
            flpMemberRowContainer.WrapContents = false;
            flpMemberRowContainer.AutoScroll = true;
            flpMemberRowContainer.SizeChanged += FlpMemberRowContainer_SizeChanged;

            guna2ComboBox1.Items.AddRange(new string[]
            {
                "All", "Username", "Full Name", "Email", "Role", "Status"
            });

            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
        }

        private void UC_UserManagement_Load(object sender, EventArgs e)
        {
            ApplyRoleRestrictions();
            LoadUsersFromDatabase();
        }

        private void ApplyRoleRestrictions()
        {
            bool isManager = CurrentRole == "manager";
            bool isFrontDesk = CurrentRole == "front desk"
                             || CurrentRole == "frontdesk"
                             || CurrentRole == "front_desk";

            // Front Desk: cannot add or archive
            if (isFrontDesk)
            {
                btnAddUser.Visible = false;
                ArchivedBtn.Visible = false;
            }

            // Manager: cannot archive
            if (isManager)
            {
                ArchivedBtn.Visible = false;
            }
        }

        private void LoadUsersFromDatabase()
        {
            _users.Clear();

            var allUsers = repo.GetAllUsers();

            IEnumerable<UserModel> filtered = showingArchived
                ? allUsers.Where(u => u.Status == "Inactive")
                : allUsers.Where(u => u.Status != "Inactive");

            // 🔥 Role visibility filter
            filtered = FilterByRoleVisibility(filtered);

            _users.AddRange(filtered);
            RenderUsers(_users);
        }

        private IEnumerable<UserModel> FilterByRoleVisibility(IEnumerable<UserModel> users)
        {
            switch (CurrentRole)
            {
                case "admin":
                    // Admin sees Admin + Manager
                    return users.Where(u =>
                        u.Role?.ToLower() == "admin" ||
                        u.Role?.ToLower() == "manager");

                case "manager":
                    // Manager sees Front Desk only
                    return users.Where(u =>
                        u.Role?.ToLower() == "front desk" ||
                        u.Role?.ToLower() == "frontdesk" ||
                        u.Role?.ToLower() == "front_desk");

                default:
                    // Front Desk sees nobody
                    return Enumerable.Empty<UserModel>();
            }
        }

        private void Searchbox_TextChanged(object sender, EventArgs e) => ApplySearch();
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) => ApplySearch();

        private void ApplySearch()
        {
            string query = Searchbox.Text.Trim().ToLower();
            string column = guna2ComboBox1.SelectedItem?.ToString();

            var result = _users.Where(u =>
            {
                if (string.IsNullOrEmpty(query)) return true;

                switch (column)
                {
                    case "Username": return (u.Username ?? "").ToLower().Contains(query);
                    case "Full Name": return (u.FullName ?? "").ToLower().Contains(query);
                    case "Email": return (u.Email ?? "").ToLower().Contains(query);
                    case "Role": return (u.Role ?? "").ToLower().Contains(query);
                    case "Status": return (u.Status ?? "").ToLower().Contains(query);
                    default:
                        return (u.Username ?? "").ToLower().Contains(query)
                            || (u.FullName ?? "").ToLower().Contains(query)
                            || (u.Email ?? "").ToLower().Contains(query)
                            || (u.Role ?? "").ToLower().Contains(query)
                            || (u.Status ?? "").ToLower().Contains(query);
                }
            }).ToList();

            RenderUsers(result);
        }

        private void RenderUsers(List<UserModel> users)
        {
            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            foreach (var user in users)
            {
                var row = new UC_UserRow
                {
                    User = user,
                    Margin = new Padding(0),
                    Width = flpMemberRowContainer.ClientSize.Width
                };

                row.UpdateDisplay();

                if (showingArchived)
                {
                    // Archive mode: edit blocked, delete = permanent, restore available
                    row.EditClicked += (s, e) =>
                    {
                        MessageBox.Show("Cannot edit archived user.");
                    };

                    row.DeleteClicked += (s, e) =>
                    {
                        var confirm = MessageBox.Show(
                            $"Permanently delete {user.Username}?",
                            "Confirm Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            repo.DeleteUserPermanently(user.ID);
                            LoadUsersFromDatabase();
                        }
                    };

                    row.RestoreClicked += (s, e) =>
                    {
                        var confirm = MessageBox.Show(
                            $"Restore {user.Username}?",
                            "Confirm",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {
                            repo.RestoreUser(user.ID);
                            showingArchived = false;
                            ArchivedBtn.Text = "Show Archived";
                            LoadUsersFromDatabase();
                        }
                    };
                }
                else
                {
                    // 🔥 NORMAL MODE: Edit opens read-only UC_ProfileView
                    row.EditClicked += (s, e) =>
                    {
                        if (isProfileOpen) return;

                        isProfileOpen = true;
                        row.Enabled = false;

                        // 🔥 Open read-only profile view
                        var profileView = new UC_ProfileView();
                        profileView.SetUser(user);

                        Form profileModal = new Form
                        {
                            FormBorderStyle = FormBorderStyle.None,
                            StartPosition = FormStartPosition.CenterParent,
                            ClientSize = profileView.Size
                        };

                        profileView.Dock = DockStyle.Fill;
                        profileModal.Controls.Add(profileView);

                        profileModal.FormClosed += (s2, e2) =>
                        {
                            isProfileOpen = false;
                            row.Enabled = true;
                        };

                        profileModal.ShowDialog();
                    };

                    // Delete = Archive
                    row.DeleteClicked += (s, e) =>
                    {
                        var confirm = MessageBox.Show(
                            $"Archive {user.Username}?",
                            "Confirm",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            repo.DeleteUser(user.ID);
                            LoadUsersFromDatabase();
                        }
                    };
                }

                flpMemberRowContainer.Controls.Add(row);
            }

            flpMemberRowContainer.ResumeLayout();
        }

        private void FlpMemberRowContainer_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpMemberRowContainer.Controls)
                ctrl.Width = flpMemberRowContainer.ClientSize.Width;
        }

        // 🔥 ADD USER WITH ROLE RESTRICTION
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            List<string> allowedRoles;

            switch (CurrentRole)
            {
                case "admin":
                    allowedRoles = new List<string> { "Manager" };
                    break;
                case "manager":
                    allowedRoles = new List<string> { "Front Desk" };
                    break;
                default:
                    MessageBox.Show("You don't have permission to create accounts.");
                    return;
            }

            var addControl = new UC_NewAddUser
            {
                ExistingUsernames = _users.Select(u => u.Username).ToList(),
                AllowedRoles = allowedRoles
            };

            addControl.RefreshRoles();

            Form modal = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = addControl.Size
            };

            addControl.Dock = DockStyle.Fill;
            modal.Controls.Add(addControl);

            addControl.UserCreated += (s, newUser) =>
            {
                LoadUsersFromDatabase();
                modal.Close();
            };

            modal.ShowDialog();
        }

        private void ArchivedBtn_Click(object sender, EventArgs e)
        {
            showingArchived = !showingArchived;

            ArchivedBtn.Text = showingArchived ? "Hide Archived" : "Show Archived";

            btnAddUser.Enabled = !showingArchived;
            btnAddUser.FillColor = showingArchived
                ? System.Drawing.Color.Gray
                : System.Drawing.Color.FromArgb(152, 16, 250);
            btnAddUser.ForeColor = showingArchived
                ? System.Drawing.Color.LightGray
                : System.Drawing.Color.White;

            LoadUsersFromDatabase();
        }

        private void flpMemberRowContainer_Paint(object sender, PaintEventArgs e) { }
        private void ArchivedLbl_Click(object sender, EventArgs e) { }
    }
}