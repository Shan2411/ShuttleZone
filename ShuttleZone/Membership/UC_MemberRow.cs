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
            this.Dock = DockStyle.Top;
        }

        // DB id to associate this row with backend
        public int MemberDbId { get; set; }

        public string MemberIDText { get => MemberID.Text; set => MemberID.Text = value; }
        public string MemberNameText { get => MemberName.Text; set => MemberName.Text = value; }
        public string MemberEmailText { get => MemberEmail.Text; set => MemberEmail.Text = value; }
        public string MemberPhoneText { get => MemberPhone.Text; set => MemberPhone.Text = value; }
        public string MemberTypeText { get => MemberType.Text; set => MemberType.Text = value; }
        public string MemberExpiryDateText { get => MemberExpiryDate.Text; set => MemberExpiryDate.Text = value; }

        // ✅ Store the join date
        public DateTime MemberJoinDate { get; set; }

        public event EventHandler DeleteClicked;
        public event EventHandler EditClicked;
        public bool IsArchived { get; set; } = false;

        public void UpdateStatus()
        {
            // Always set SizeMode so icons render consistently
            MemberStatus.SizeMode = PictureBoxSizeMode.StretchImage;

            // Hide edit/delete when the row represents an archived member
            // (button control names assumed present in designer: MemberDelete, MemberEdit)
            if (MemberDelete != null) MemberDelete.Visible = !IsArchived;
            if (MemberEdit != null) MemberEdit.Visible = !IsArchived;

            // Show appropriate status icon when not archived; if archived, clear or set an archived icon if available
            if (IsArchived)
            {
                MemberStatus.Image = null;
                return;
            }

            if (DateTime.TryParse(MemberExpiryDate.Text, out DateTime expiry))
            {
                if (expiry < DateTime.Now)
                    MemberStatus.Image = global::ShuttleZone.Properties.Resources.ExpiredStatus;
                else
                    MemberStatus.Image = global::ShuttleZone.Properties.Resources.ActiveStatus;
            }
            else
            {
                MemberStatus.Image = global::ShuttleZone.Properties.Resources.ActiveStatus;
            }
        }

        private void MemberDelete_Click(object sender, EventArgs e)
        {
            // Confirm archive action with the user before raising the event
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
            // Edit should not be reachable if IsArchived is true because the button will be hidden,
            // but protect defensively.
            if (IsArchived)
                return;

            EditClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}