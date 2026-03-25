using ShuttleZone.Membership;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_Membership : UserControl
    {
        private bool showingArchived = false;

        public UC_Membership()
        {
            this.DoubleBuffered = true; // reduce flicker
            InitializeComponent();
            LoadMembers();
        }

        private void LoadMembers()
        {
            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            // fetch members based on toggle
            var members = DataAccess.GetMembers(showingArchived);

            foreach (var model in members)
            {
                var row = new UC_MemberRow
                {
                    MemberDbId = model.Id,
                    MemberIDText = string.IsNullOrWhiteSpace(model.MemberCode) ? $"M{model.Id:D3}" : model.MemberCode,
                    MemberNameText = model.Name ?? "",
                    MemberEmailText = model.Email ?? "",
                    MemberPhoneText = model.Phone ?? "",
                    MemberTypeText = model.MembershipType ?? "",
                    MemberExpiryDateText = model.ExpiryDate?.ToString("yyyy-MM-dd") ?? "",
                    MemberJoinDate = model.JoinDate ?? DateTime.Now,
                    Width = flpMemberRowContainer.ClientSize.Width,
                    IsArchived = model.IsArchived
                };

                row.UpdateStatus();

                // ARCHIVE
                row.DeleteClicked += (s, args) =>
                {
                    if (row.MemberDbId > 0)
                    {
                        bool archived = DataAccess.ArchiveMember(row.MemberDbId);
                        if (archived)
                            LoadMembers();
                        else
                            MessageBox.Show("Archive failed");
                    }
                };

                // EDIT
                row.EditClicked += (s, args) =>
                {
                    var editForm = new EditMember
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
                        var updatedModel = new MemberModel
                        {
                            Id = row.MemberDbId,
                            MemberCode = row.MemberIDText,
                            Name = editForm.MemberNameValue,
                            Email = editForm.MemberEmailValue,
                            Phone = editForm.MemberPhoneValue,
                            MembershipType = editForm.MembershipTypeValue,
                            ExpiryDate = DateTime.TryParse(editForm.ExpiryDateValue, out DateTime exp) ? exp : (DateTime?)null,
                            JoinDate = editForm.JoinDateValue
                        };

                        bool success = DataAccess.UpdateMember(updatedModel);
                        if (success)
                            LoadMembers();
                        else
                            MessageBox.Show("Update failed");
                    }
                };

                flpMemberRowContainer.Controls.Add(row);
            }

            flpMemberRowContainer.ResumeLayout();
            ApplySearchFilter();
        }

        private void AddMemberBtn_Click(object sender, EventArgs e)
        {
            var form = new AddNewMember();

            if (form.ShowDialog() == DialogResult.OK)
            {
                var model = new MemberModel
                {
                    Name = form.MemberNameValue,
                    Email = form.MemberEmailValue,
                    Phone = form.MemberPhoneValue,
                    MembershipType = form.MembershipTypeValue,
                    ExpiryDate = DateTime.TryParse(form.ExpiryDateValue, out DateTime exp) ? exp : (DateTime?)null,
                    JoinDate = form.JoinDateValue
                };

                int newId = DataAccess.AddMember(model);
                if (newId > 0)
                    LoadMembers();
                else
                    MessageBox.Show("Failed to add member");
            }
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void ArchivedBtn_Click(object sender, EventArgs e)
        {
            showingArchived = !showingArchived;

            ArchivedBtn.Text = showingArchived ? "Hide Archived" : "Show Archived";
            AddMemberBtn.Enabled = !showingArchived;
            AddMemberBtn.FillColor = showingArchived ? System.Drawing.Color.Gray : System.Drawing.Color.FromArgb(152, 16, 250);
            AddMemberBtn.ForeColor = showingArchived ? System.Drawing.Color.LightGray : System.Drawing.Color.White;
            AddMemberBtn.Text = showingArchived ? "Archived Mode" : "Add New Member";

            LoadMembers();
        }

        private void ApplySearchFilter()
        {
            string search = Searchbox.Text.Trim().ToLower();

            foreach (UC_MemberRow row in flpMemberRowContainer.Controls.OfType<UC_MemberRow>())
            {
                bool match =
                    row.MemberIDText.ToLower().Contains(search) ||
                    row.MemberNameText.ToLower().Contains(search) ||
                    row.MemberEmailText.ToLower().Contains(search) ||
                    row.MemberPhoneText.ToLower().Contains(search) ||
                    row.MemberTypeText.ToLower().Contains(search) ||
                    row.MemberExpiryDateText.ToLower().Contains(search) ||
                    row.MemberJoinDate.ToString("yyyy-MM-dd").ToLower().Contains(search);

                // NEW: hide archived rows in active mode
                row.Visible = (!row.IsArchived || showingArchived) && match;
            }
        }
    }
}