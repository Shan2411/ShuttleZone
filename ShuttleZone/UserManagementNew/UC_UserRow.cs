using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserRow : UserControl
    {
        public UserModel User { get; set; }

        public string Role { get; set; } = "admin";

        // ✅ EVENTS
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler RestoreClicked;

        public UC_UserRow()
        {
            InitializeComponent();

            // ✅ BUTTON EVENTS
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
            btnRestore.Click += (s, e) => RestoreClicked?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateDisplay()
        {
            if (User == null) return;

            lblID.Text = User.ID ?? "";
            lblUsername.Text = User.Username ?? "";
            lblFullName.Text = User.FullName ?? "";
            lblEmail.Text = User.Email ?? "";
            lblRole.Text = User.Role ?? "";

            // ✅ THIS is where label reads DB value
            SetStatusLabel(User.Status);

            btnRestore.Visible = User.Status == "Inactive";
            btnDelete.Visible = true;

            if (Role != "admin")
            {
                btnDelete.Visible = false;
                btnRestore.Visible = false;
                btnEdit.Enabled = false;
            }
        }

        // ✅ HANDLE STATUS DISPLAY + STYLE
        private void SetStatusLabel(string status)
        {
            string text = string.IsNullOrEmpty(status) ? "UNKNOWN" : status.ToUpper();

            // ✅ Center using HTML (required for Guna2HtmlLabel)
            Statuslbl.Text = $"<div align='center'>{text}</div>";

            // ✅ Match your exact size
            Statuslbl.AutoSize = false;
            Statuslbl.Size = new Size(83, 21);

            // ✅ REMOVE padding (important)
            Statuslbl.Padding = new Padding(0);

            // ✅ Colors (tuned for small height)
            if (status == "Active")
            {
                Statuslbl.BackColor = Color.FromArgb(198, 239, 206); // softer green
                Statuslbl.ForeColor = Color.FromArgb(0, 97, 0);      // darker text
            }
            else if (status == "Inactive")
            {
                Statuslbl.BackColor = Color.FromArgb(255, 199, 206); // softer red
                Statuslbl.ForeColor = Color.FromArgb(156, 0, 6);
            }
            else
            {
                Statuslbl.BackColor = Color.LightGray;
                Statuslbl.ForeColor = Color.DimGray;
            }
        }
    }
}