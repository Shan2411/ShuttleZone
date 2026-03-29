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

        private bool isProcessingClick = false;

        // ✅ EVENTS
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler RestoreClicked;

        public UC_UserRow()
        {
            InitializeComponent();

            Statuslbl.Cursor = Cursors.Hand;
                                //Statuslbl.Click += Statuslbl_Click; 

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

            SetStatusLabel(User.Status);

            // Restore button only shows in archive mode (handled by UC_UserManagement)
            btnRestore.Visible = User.Status == "Inactive";
            btnDelete.Visible = true;
        }

        // ✅ HANDLE STATUS DISPLAY + STYLE
        private void SetStatusLabel(string status)
        {
            string text = string.IsNullOrEmpty(status) ? "UNKNOWN" : status.ToUpper();

            Statuslbl.Text = $"<div align='center'>{text}</div>";

            Statuslbl.AutoSize = false;
            Statuslbl.Size = new Size(90, 24);

            Statuslbl.Padding = new Padding(0);

            // 🔥 Rounded effect workaround
            Statuslbl.BorderStyle = BorderStyle.FixedSingle;

            if (status == "Active")
            {
                Statuslbl.BackColor = Color.FromArgb(198, 239, 206);
                Statuslbl.ForeColor = Color.FromArgb(0, 97, 0);
            }
            else if (status == "Inactive")
            {
                Statuslbl.BackColor = Color.FromArgb(255, 199, 206);
                Statuslbl.ForeColor = Color.FromArgb(156, 0, 6);
            }
            else
            {
                Statuslbl.BackColor = Color.LightGray;
                Statuslbl.ForeColor = Color.DimGray;
            }
        }

        private void Statuslbl_Click(object sender, EventArgs e)
        {
            // 🚫 Prevent double trigger
            if (isProcessingClick) return;

            if (User == null) return;

            // Optional role restriction
            if (UserSession.Role.ToLower().Contains("front"))
            {
                MessageBox.Show("You don't have permission.");
                return;
            }

            try
            {
                isProcessingClick = true;

                string newStatus = User.Status == "Active" ? "Inactive" : "Active";

                var confirm = MessageBox.Show(
                    $"Set {User.Username} to {newStatus}?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var repo = new UserRepository();
                    repo.UpdateUserStatus(User.ID, newStatus);

                    User.Status = newStatus;

                    SetStatusLabel(newStatus);
                }
            }
            finally
            {
                // ✅ Allow clicks again AFTER everything finishes
                isProcessingClick = false;
            }
        }
    }
}