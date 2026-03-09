using ShuttleZone.Membership;
using System;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_Membership : UserControl
    {
        private int memberCounter = 1;
        private bool showingArchived = false; // toggle state

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
                    MemberJoinDate = addNewMemberForm.JoinDateValue,
                    Width = flpMemberRowContainer.ClientSize.Width,
                    IsArchived = false
                };

                row.UpdateStatus();

                // ARCHIVE instead of delete
                row.DeleteClicked += (s, args) =>
                {
                    row.IsArchived = true;
                    RefreshView();
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
                        JoinDateValue = row.MemberJoinDate
                    };

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        row.MemberNameText = editForm.MemberNameValue;
                        row.MemberEmailText = editForm.MemberEmailValue;
                        row.MemberPhoneText = editForm.MemberPhoneValue;
                        row.MemberTypeText = editForm.MembershipTypeValue;
                        row.MemberExpiryDateText = editForm.ExpiryDateValue;
                        row.MemberJoinDate = editForm.JoinDateValue;

                        row.UpdateStatus();
                        RefreshView();
                    }
                };

                flpMemberRowContainer.Controls.Add(row);
                memberCounter++;
            }
        }

      
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

    
        private void ArchivedBtn_Click(object sender, EventArgs e)
        {
            showingArchived = !showingArchived;

            ArchivedBtn.Text = showingArchived ? "Hide Archived" : "Show Archived";
            AddMemberBtn.Enabled = !showingArchived; // disable adding new members when viewing archived
            AddMemberBtn.FillColor = showingArchived ? System.Drawing.Color.Gray : System.Drawing.Color.FromArgb(152, 16, 250); // gray out when disabled
            AddMemberBtn.ForeColor = showingArchived ? System.Drawing.Color.LightGray : System.Drawing.Color.White; // adjust text color for contrast
            AddMemberBtn.Text = showingArchived ? "Archived Mode" : "Add New Member"; // update button text to reflect state

            RefreshView();
        }


        private void RefreshView()
        {
            string searchText = Searchbox.Text.Trim().ToLower();

            foreach (UC_MemberRow row in flpMemberRowContainer.Controls)
            {
                // Check across multiple fields
                bool matchesSearch =
                    row.MemberIDText.ToLower().Contains(searchText) ||
                    row.MemberNameText.ToLower().Contains(searchText) ||
                    row.MemberEmailText.ToLower().Contains(searchText) ||
                    row.MemberPhoneText.ToLower().Contains(searchText) ||
                    row.MemberTypeText.ToLower().Contains(searchText) ||
                    row.MemberExpiryDateText.ToLower().Contains(searchText) ||
                    row.MemberJoinDate.ToString("yyyy-MM-dd").ToLower().Contains(searchText);

                bool matchesArchiveState = showingArchived
                    ? row.IsArchived
                    : !row.IsArchived;

                row.Visible = matchesSearch && matchesArchiveState;
            }
        }
    }
}