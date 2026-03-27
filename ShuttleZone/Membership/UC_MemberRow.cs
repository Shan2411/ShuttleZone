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
            if (Role == "manager")
            {
                MemberDelete.Visible = true;
                MemberEdit.Enabled = true;
            }
            else // frontdesk
            {
                MemberDelete.Visible = false;   // cannot archive/delete
                MemberEdit.Enabled = true;      // can edit, optionally limited fields in Edit form
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

        public void UpdateStatus()
        {
            MemberStatus.SizeMode = PictureBoxSizeMode.StretchImage;

            if (MemberDelete != null) MemberDelete.Visible = !IsArchived && Role == "manager";
            if (MemberEdit != null) MemberEdit.Visible = !IsArchived;

            if (IsArchived)
            {
                MemberStatus.Image = null;
                return;
            }

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
    }
}