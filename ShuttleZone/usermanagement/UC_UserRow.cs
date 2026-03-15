using System;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserRow : UserControl
    {
        public UserModel User { get; set; }

        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public UC_UserRow()
        {
            InitializeComponent();

            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateDisplay()
        {
            if (User == null) return;

            lblID.Text = User.ID ?? "";
            lblUsername.Text = User.Username ?? "";
            lblFullName.Text = User.FullName ?? "";
            lblEmail.Text = User.Email ?? "";
            lblRole.Text = User.Role ?? "";
            lblStatus.Text = User.Status ?? "";
        }
    }
}