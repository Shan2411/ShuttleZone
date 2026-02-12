using System;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class UC_MemberRow : UserControl
    {
        public UC_MemberRow()
        {
            InitializeComponent();
            //this.AutoSize = false;
            //this.Dock = DockStyle.Top;
        }

        // Properties for binding values
        public string MemberIDText { get => MemberID.Text; set => MemberID.Text = value; }
        public string MemberNameText { get => MemberName.Text; set => MemberName.Text = value; }
        public string MemberEmailText { get => MemberEmail.Text; set => MemberEmail.Text = value; }
        public string MemberPhoneText { get => MemberPhone.Text; set => MemberPhone.Text = value; }
        public string MemberTypeText { get => MemberType.Text; set => MemberType.Text = value; }
        public string MemberExpiryDateText { get => MemberExpiryDate.Text; set => MemberExpiryDate.Text = value; }

        // Event to notify parent when delete is clicked
        public event EventHandler DeleteClicked;

        public void UpdateStatus()
        {
            //if (DateTime.TryParse(MemberExpiryDate.Text, out DateTime expiry))
            //{
            //    if (expiry < DateTime.Now)
            //    {
            //        // expired icon
            //        MemberStatus.Image = Properties.Resources.expired_icon;
            //    }
            //    else
            //    {
            //        // active icon
            //        MemberStatus.Image = Properties.Resources.active_icon;
            //    }
            //}
        }

        private void MemberDelete_Click(object sender, EventArgs e)
        {
            // Raise event so parent can handle deletion
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}