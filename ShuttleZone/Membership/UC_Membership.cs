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
                    MemberJoinDate = addNewMemberForm.JoinDateValue, // ✅ store join date
                    Width = flpMemberRowContainer.ClientSize.Width
                };

                row.UpdateStatus();

                // Delete
                row.DeleteClicked += (s, args) =>
                {
                    flpMemberRowContainer.Controls.Remove(row);
                    row.Dispose();
                };

                // Edit
                row.EditClicked += (s, args) =>
                {
                    EditMember editForm = new EditMember
                    {
                        MemberIDValue = row.MemberIDText,
                        MemberNameValue = row.MemberNameText,
                        MemberEmailValue = row.MemberEmailText,
                        MemberPhoneValue = row.MemberPhoneText,
                        MembershipTypeValue = row.MemberTypeText,
                        ExpiryDateValue = row.MemberExpiryDateText,
                        JoinDateValue = row.MemberJoinDate // ✅ use stored join date
                    };

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        row.MemberNameText = editForm.MemberNameValue;
                        row.MemberEmailText = editForm.MemberEmailValue;
                        row.MemberPhoneText = editForm.MemberPhoneValue;
                        row.MemberTypeText = editForm.MembershipTypeValue;
                        row.MemberExpiryDateText = editForm.ExpiryDateValue;
                        row.MemberJoinDate = editForm.JoinDateValue; // ✅ update join date if changed
                        row.UpdateStatus();
                    }
                };

                flpMemberRowContainer.Controls.Add(row);
                memberCounter++;
            }
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            string searchText = Searchbox.Text.Trim().ToLower();

            foreach (UC_MemberRow row in flpMemberRowContainer.Controls)
            {
                // Compare the start of the member's name with the search text
                if (row.MemberNameText.ToLower().StartsWith(searchText))
                {
                    row.Visible = true;  // show matching rows
                }
                else
                {
                    row.Visible = false; // hide non-matching rows
                }
            }
        }
    }
}