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

        public void UpdateStatus()
        {
            MemberStatus.SizeMode = PictureBoxSizeMode.StretchImage; // or Zoom if you want aspect ratio preserved

            if (DateTime.TryParse(MemberExpiryDate.Text, out DateTime expiry))
            {
                if (expiry < DateTime.Now)
                    MemberStatus.Image = Properties.Resources.ExpiredStatus;
                else
                    MemberStatus.Image = Properties.Resources.ActiveStatus;
            }
        }

        private void MemberDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void MemberEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}