using System;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_UserRow : UserControl
    {
        public UserModel User { get; set; }

        // ✅ FIX 1: ADD THIS
        public string Role { get; set; } = "admin";

        // ✅ EVENTS
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        // ✅ FIX 2: ADD THIS
        public event EventHandler RestoreClicked;

        public UC_UserRow()
        {
            InitializeComponent();

            // ✅ BUTTON EVENTS
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
            btnRestore.Click += (s, e) => RestoreClicked?.Invoke(this, EventArgs.Empty);

            // ✅ STATUS DROPDOWN
            guna2ComboBox1.Items.Add("Active");
            guna2ComboBox1.Items.Add("Inactive");
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
        }

        public void UpdateDisplay()
        {
            if (User == null) return;

            lblID.Text = User.ID ?? "";
            lblUsername.Text = User.Username ?? "";
            lblFullName.Text = User.FullName ?? "";
            lblEmail.Text = User.Email ?? "";
            lblRole.Text = User.Role ?? "";

            if (!string.IsNullOrEmpty(User.Status))
                guna2ComboBox1.SelectedItem = User.Status;

            // ✅ UI LOGIC
            // 🔥 DEFAULT VISIBILITY (can be overridden outside)
            btnRestore.Visible = User.Status == "Inactive";
            btnDelete.Visible = true;

            if (Role != "admin")
            {
                btnDelete.Visible = false;
                btnRestore.Visible = false;
                btnEdit.Enabled = false;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (User == null) return;

            string selectedStatus = guna2ComboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedStatus))
            {
                User.Status = selectedStatus;

                var repo = new UserRepository();
                repo.UpdateUserStatus(User.ID, selectedStatus);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}