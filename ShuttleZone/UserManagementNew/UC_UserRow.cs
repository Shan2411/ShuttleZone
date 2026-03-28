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

            // Wire local buttons to events
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            // Populate status combo box (designer must have guna2ComboBox1)
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
            {
                guna2ComboBox1.SelectedItem = User.Status;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (User == null) return;

            string selectedStatus = guna2ComboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                User.Status = selectedStatus;
            }
        }
    }
}