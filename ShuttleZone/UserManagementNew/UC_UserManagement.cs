using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserManagement : UserControl
    {
        private readonly List<UserModel> _users = new List<UserModel>();

        // ✅ Prevent duplicate profile openings
        private bool isProfileOpen = false;

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
                "All",
                "Username",
                "Full Name",
                "Email",
                "Role",
                "Status"
            });

            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
        }

        private void UC_UserManagement_Load(object sender, EventArgs e)
        {
            SeedUsers();
            RenderUsers(_users);
        }

        private void SeedUsers()
        {
            if (_users.Count > 0) return;

            _users.Add(new UserModel
            {
                ID = "1",
                Username = "admin",
                FullName = "System Administrator",
                Email = "admin@shuttlezone.local",
                Role = "Admin",
                Status = "Active",
                Password = "admin"
            });

            _users.Add(new UserModel
            {
                ID = "2",
                Username = "manager",
                FullName = "Branch Manager",
                Email = "manager@shuttlezone.local",
                Role = "Manager",
                Status = "Active",
                Password = "manager"
            });
        }

        private void Searchbox_TextChanged(object sender, EventArgs e) => ApplySearch();
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) => ApplySearch();

        private void ApplySearch()
        {
            string query = Searchbox.Text.Trim().ToLower();
            string column = guna2ComboBox1.SelectedItem?.ToString();

            var filtered = _users.Where(u =>
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
                    case "Status":
                        return (u.Status ?? "").ToLower().Contains(query);
                    default:
                        return (u.Username ?? "").ToLower().Contains(query)
                            || (u.FullName ?? "").ToLower().Contains(query)
                            || (u.Email ?? "").ToLower().Contains(query)
                            || (u.Role ?? "").ToLower().Contains(query)
                            || (u.Status ?? "").ToLower().Contains(query);
                }
            }).ToList();

            RenderUsers(filtered);
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

                // ✅ EDIT CLICK
                row.EditClicked += (s, e) =>
                {
                    if (isProfileOpen) return; // 🚫 prevent duplicate open

                    isProfileOpen = true;
                    row.Enabled = false; // optional safety

                    var profile = new ShuttleZone.UserManagementNew.UC_UserProfile();
                    profile.SetUser(user);

                    Form profileModal = new Form
                    {
                        FormBorderStyle = FormBorderStyle.None,
                        StartPosition = FormStartPosition.CenterParent,
                        ClientSize = profile.Size
                    };

                    profile.Dock = DockStyle.Fill;
                    profileModal.Controls.Add(profile);

                    // ✅ Reset state when closed
                    profileModal.FormClosed += (s2, e2) =>
                    {
                        isProfileOpen = false;
                        row.Enabled = true;
                    };

                    // ✅ OPEN EDIT
                    profile.EditProfileClicked += (s2, e2) =>
                    {
                        profileModal.Close();

                        var edit = new ShuttleZone.UserManagementNew.UC_EditProfileMain(user);

                        Form editModal = new Form
                        {
                            FormBorderStyle = FormBorderStyle.None,
                            StartPosition = FormStartPosition.CenterParent,
                            ClientSize = edit.Size
                        };

                        edit.Dock = DockStyle.Fill;
                        editModal.Controls.Add(edit);

                        // ✅ CHANGE PASSWORD
                        edit.ChangePasswordClicked += (s3, e3) =>
                        {
                            var change = new ShuttleZone.UserManagementNew.UC_ChangePassword();
                            change.SetUser(user);

                            Form changeModal = new Form
                            {
                                FormBorderStyle = FormBorderStyle.None,
                                StartPosition = FormStartPosition.CenterParent,
                                ClientSize = change.Size
                            };

                            change.Dock = DockStyle.Fill;
                            changeModal.Controls.Add(change);

                            changeModal.ShowDialog();
                        };

                        // ✅ Refresh AFTER edit closes
                        edit.FormClosed += (s4, e4) =>
                        {
                            RenderUsers(_users);
                        };

                        editModal.ShowDialog();
                    };

                    profileModal.ShowDialog();
                };

                // ✅ DELETE
                row.DeleteClicked += (s, e) =>
                {
                    var confirm = MessageBox.Show(
                        $"Delete {user.Username}?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        _users.Remove(user);
                        RenderUsers(_users);
                    }
                };

                flpMemberRowContainer.Controls.Add(row);
            }

            flpMemberRowContainer.ResumeLayout();
        }

        private void FlpMemberRowContainer_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpMemberRowContainer.Controls)
                ctrl.Width = flpMemberRowContainer.ClientSize.Width;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var addControl = new UC_NewAddUser
            {
                ExistingUsernames = _users.Select(u => u.Username).ToList()
            };

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
                newUser.ID = (_users.Count + 1).ToString();
                _users.Add(newUser);
                RenderUsers(_users);
                modal.Close();
            };

            modal.ShowDialog();
        }

        private void flpMemberRowContainer_Paint(object sender, PaintEventArgs e) { }
        private void ArchivedLbl_Click(object sender, EventArgs e) { }
        private void ArchivedBtn_Click(object sender, EventArgs e) { }
    }
}