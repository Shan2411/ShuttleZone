using ShuttleZone.Membership;
using System;
using System.Linq;
using System.Reflection;
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

            // hook resize so rows always match width
            flpMemberRowContainer.Resize += FlpMemberRowContainer_Resize;

            LoadMembers();
        }

        private void LoadMembers()
        {
            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            var members = DataAccess.GetMembers(showingArchived);
            int index = 0;


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
                    IsArchived = model.IsArchived
                };

                // ✅ Zebra striping
                if (index % 2 == 0)
                {
                    row.panelBG.FillColor = System.Drawing.Color.White;
                    row.panelBG.FillColor2 = System.Drawing.Color.White;
                }
                else
                {
                    row.panelBG.FillColor = System.Drawing.Color.FromArgb(237, 209, 255);
                    row.panelBG.FillColor2 = System.Drawing.Color.FromArgb(237, 209, 255);
                }

                index++;

                row.Width = flpMemberRowContainer.ClientSize.Width;
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
            flpMemberRowContainer.PerformLayout(); // force layout
            ApplySearchFilter();
            UpdateMemberTotals(); // ✅ update totals after loading
        }

        private void FlpMemberRowContainer_Resize(object sender, EventArgs e)
        {
            foreach (UC_MemberRow row in flpMemberRowContainer.Controls.OfType<UC_MemberRow>())
            {
                row.Width = flpMemberRowContainer.ClientSize.Width;
            }
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

                row.Visible = (!row.IsArchived || showingArchived) && match;
            }
        }

        private void UpdateMemberTotals()
        {
            var members = DataAccess.GetMembers(showingArchived);

            int totalMembersC = members.Count;
            int totalActiveC = members.Count(m => !m.IsArchived && (!m.ExpiryDate.HasValue || m.ExpiryDate.Value >= DateTime.Now));
            int totalExpiredC = members.Count(m => m.ExpiryDate.HasValue && m.ExpiryDate.Value < DateTime.Now);

            totalMembers.Text = totalMembersC.ToString();
            totalActive.Text = totalActiveC.ToString();
            totalExpired.Text = totalExpiredC.ToString();
        }

        private void totalMembers_Click(object sender, EventArgs e)
        {

        }

        private void totalMembers_Click_1(object sender, EventArgs e)
        {

        }

        private void totalActive_Click(object sender, EventArgs e)
        {

        }

        private void totalExpired_Click(object sender, EventArgs e)
        {

        }
    }
}