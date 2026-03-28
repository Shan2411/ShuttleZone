using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class UC_MemberRow : UserControl
    {
        public UC_MemberRow()
        {
            InitializeComponent();
            this.AutoSize = false;
        }

        // Role logic
        private string role = "frontdesk"; // default
        public string Role
        {
            get => role;
            set
            {
                role = value?.Trim().ToLower() ?? "frontdesk";
                ApplyRolePermissions(); // automatically enforce permissions
            }
        }

        public void ApplyRolePermissions()
        {
            // ARCHIVED STATE
            if (IsArchived)
            {
                MemberEdit.Visible = false;
                MemberDelete.Visible = false;

                // Only manager can restore
                MemberRestore.Visible = Role == "manager";
                return;
            }

            // ACTIVE STATE
            MemberRestore.Visible = false;
            MemberEdit.Visible = true;

            if (Role == "manager")
            {
                MemberDelete.Visible = true;
            }
            else
            {
                MemberDelete.Visible = false;
            }
        }

        public int MemberDbId { get; set; }
        public Guna2GradientPanel panelBG => PanelBG;

        public string MemberIDText { get => MemberID.Text; set => MemberID.Text = value; }
        public string MemberNameText { get => MemberName.Text; set => MemberName.Text = value; }
        public string MemberEmailText { get => MemberEmail.Text; set => MemberEmail.Text = value; }
        public string MemberPhoneText { get => MemberPhone.Text; set => MemberPhone.Text = value; }
        public string MemberTypeText { get => MemberType.Text; set => MemberType.Text = value; }
        public string MemberExpiryDateText { get => MemberExpiryDate.Text; set => MemberExpiryDate.Text = value; }
        public DateTime MemberJoinDate { get; set; }
        public bool IsArchived { get; set; } = false;

        public event EventHandler DeleteClicked;
        public event EventHandler EditClicked;
        public event EventHandler RestoreClicked;

        public void UpdateStatus()
        {
            MemberStatus.SizeMode = PictureBoxSizeMode.StretchImage;

            // 🔥 Archived members always hide Delete and Edit
            if (IsArchived)
            {
                MemberDelete.Visible = false;
                MemberEdit.Visible = false;
                MemberStatus.Image = global::ShuttleZone.Properties.Resources.archivedStatuss;
                return;
            }

            ApplyRolePermissions(); // Ensure permissions are applied based on current role

            // Status icon
            if (DateTime.TryParse(MemberExpiryDate.Text, out DateTime expiry))
            {
                MemberStatus.Image = expiry < DateTime.Now
                    ? global::ShuttleZone.Properties.Resources.ExpiredStatus
                    : global::ShuttleZone.Properties.Resources.ActiveStatus;
            }
            else
            {
                MemberStatus.Image = global::ShuttleZone.Properties.Resources.ActiveStatus;
            }
        }

        private void MemberDelete_Click(object sender, EventArgs e)
        {
            if (Role != "manager") return;

            var result = MessageBox.Show(
                "Are you sure you want to archive this member?",
                "Confirm Archive",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void MemberEdit_Click(object sender, EventArgs e)
        {
            if (IsArchived) return;
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void MemberRestore_Click(object sender, EventArgs e)
        {
            if (Role != "manager") return;

            var result = MessageBox.Show(
                "Restore this member?",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                RestoreClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}