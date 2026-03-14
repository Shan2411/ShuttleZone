using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserManagement : UserControl
    {
        private readonly List<UserModel> _users = new List<UserModel>();

        public UC_UserManagement()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            Load += UC_UserManagement_Load;
            Searchbox.TextChanged += Searchbox_TextChanged;

            // FlowLayoutPanel configuration
            flpMemberRowContainer.FlowDirection = FlowDirection.TopDown;
            flpMemberRowContainer.WrapContents = false;
            flpMemberRowContainer.AutoScroll = true;

            // Resize rows when container resizes
            flpMemberRowContainer.SizeChanged += FlpMemberRowContainer_SizeChanged;
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
                Status = "Active"
            });

            _users.Add(new UserModel
            {
                ID = "2",
                Username = "manager",
                FullName = "Branch Manager",
                Email = "manager@shuttlezone.local",
                Role = "Manager",
                Status = "Active"
            });
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            string query = Searchbox.Text.Trim().ToLower();

            var filtered = string.IsNullOrEmpty(query)
                ? _users
                : _users.Where(u =>
                        u.Username.ToLower().Contains(query) ||
                        u.FullName.ToLower().Contains(query) ||
                        u.Email.ToLower().Contains(query))
                    .ToList();

            RenderUsers(filtered);
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
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

        private void RenderUsers(List<UserModel> users)
        {
            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            foreach (var user in users)
            {
                var row = new UC_UserRow
                {
                    User = user,
                    Margin = new Padding(0)
                };

                row.Width = flpMemberRowContainer.ClientSize.Width;
                row.UpdateDisplay();

                row.EditClicked += (s, e) =>
                {
                    MessageBox.Show($"Edit {user.Username} (feature coming soon).");
                };

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
            {
                ctrl.Width = flpMemberRowContainer.ClientSize.Width;
            }
        }

        private void btnAddUser_Click_2(object sender, EventArgs e)
        {
            BtnAddUser_Click(sender, e);
        }

        private void flpMemberRowContainer_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
