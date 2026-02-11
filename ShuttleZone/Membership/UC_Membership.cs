using ShuttleZone.Membership;
using System;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_Membership : UserControl
    {
        private int memberCounter = 1;

        public UC_Membership()
        {
            InitializeComponent();

            // FlowLayoutPanel settings
            flpMemberRowContainer.WrapContents = false;
            flpMemberRowContainer.AutoScroll = true;
            flpMemberRowContainer.FlowDirection = FlowDirection.TopDown;
        }

        private void AddMemberBtn_Click(object sender, EventArgs e)
        {
            AddNewMember addNewMemberForm = new AddNewMember();

            if (addNewMemberForm.ShowDialog() == DialogResult.OK)
            {
                UC_MemberRow row = new UC_MemberRow
                {
                    MemberIDText = $"M{memberCounter:D3}",
                    MemberNameText = addNewMemberForm.MemberNameValue,
                    MemberEmailText = addNewMemberForm.MemberEmailValue,
                    MemberPhoneText = addNewMemberForm.MemberPhoneValue,
                    MemberTypeText = addNewMemberForm.MembershipTypeValue,
                    MemberExpiryDateText = addNewMemberForm.ExpiryDateValue,
                    Width = flpMemberRowContainer.ClientSize.Width
                };

                row.UpdateStatus();

                // Subscribe to delete event
                row.DeleteClicked += (s, args) =>
                {
                    flpMemberRowContainer.Controls.Remove(row);
                    row.Dispose();
                };

                flpMemberRowContainer.Controls.Add(row);
                memberCounter++;
            }
        }
    }
}