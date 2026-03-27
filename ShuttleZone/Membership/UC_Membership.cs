using ShuttleZone.Membership;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ShuttleZone
{
    public partial class UC_Membership : UserControl
    {
        private bool showingArchived = false;
        private List<MemberModel> cachedMembers = new List<MemberModel>();
        private string CurrentRole = "frontdesk"; // default role

        public UC_Membership()
        {
            this.DoubleBuffered = true; // reduce flicker
            InitializeComponent();

            // hook resize so rows always match width
            flpMemberRowContainer.Resize += FlpMemberRowContainer_Resize;

            LoadMembers();
           
        }

        /// <summary>
        /// Set the role of the logged-in user (Manager or Frontdesk)
        /// </summary>
        public void SetRole(string role)
        {
            CurrentRole = string.IsNullOrEmpty(role) ? "frontdesk" : role.Trim().ToLower();

            // Only manager can see/use Archived button
            ArchivedBtn.Visible = CurrentRole == "manager";
            ArchivedBtn.Enabled = CurrentRole == "manager";

            // reload members so row buttons respect role
            LoadMembers();
        }

        private void LoadMembers()
        {
            // Fetch members once
            cachedMembers = DataAccess.GetMembers(showingArchived);

            flpMemberRowContainer.SuspendLayout();
            flpMemberRowContainer.Controls.Clear();

            int index = 0;
            foreach (var model in cachedMembers)
            {
                var row = new UC_MemberRow
                {
                    Role = CurrentRole // assign role to row
                };

                SetRowData(row, model, index);

                // Add single event handlers
                row.DeleteClicked += Row_DeleteClicked;
                row.EditClicked += Row_EditClicked;

                row.Width = flpMemberRowContainer.ClientSize.Width;
                row.ApplyRolePermissions(); // make buttons respect role

                flpMemberRowContainer.Controls.Add(row);
                index++;
            }

            flpMemberRowContainer.ResumeLayout();
            UpdateMemberTotals();
        }

        private void SetRowData(UC_MemberRow row, MemberModel model, int index)
        {
            row.MemberDbId = model.Id;
            row.MemberIDText = string.IsNullOrWhiteSpace(model.MemberCode) ? $"M{model.Id:D3}" : model.MemberCode;
            row.MemberNameText = model.Name ?? "";
            row.MemberEmailText = model.Email ?? "";
            row.MemberPhoneText = model.Phone ?? "";
            row.MemberTypeText = model.MembershipType ?? "";
            row.MemberExpiryDateText = model.ExpiryDate?.ToString("yyyy-MM-dd") ?? "";
            row.MemberJoinDate = model.JoinDate ?? DateTime.Now;
            row.IsArchived = model.IsArchived;

            // Zebra striping
            var color = (index % 2 == 0) ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(237, 209, 255);
            row.panelBG.FillColor = color;
            row.panelBG.FillColor2 = color;

            row.UpdateStatus();
        }

        private void Row_DeleteClicked(object sender, EventArgs e)
        {
            if (sender is UC_MemberRow row && row.MemberDbId > 0)
            {
                // Only manager can delete/archive
                if (CurrentRole != "manager") return;

                bool archived = DataAccess.ArchiveMember(row.MemberDbId);
                if (archived)
                {
                    flpMemberRowContainer.Controls.Remove(row);
                    cachedMembers.RemoveAll(m => m.Id == row.MemberDbId);
                    UpdateMemberTotals();
                }
                else
                    MessageBox.Show("Archive failed");
            }
        }

        private void Row_EditClicked(object sender, EventArgs e)
        {
            if (sender is UC_MemberRow row)
            {
                var editForm = new EditMember
                {
                    MemberIDValue = row.MemberIDText,
                    MemberNameValue = row.MemberNameText,
                    MemberEmailValue = row.MemberEmailText,
                    MemberPhoneValue = row.MemberPhoneText,
                    MembershipTypeValue = row.MemberTypeText,
                    ExpiryDateValue = row.MemberExpiryDateText,
                    JoinDateValue = row.MemberJoinDate,
                    UserRole = CurrentRole // pass role to EditMember to optionally limit editable fields
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
                    {
                        // update row directly instead of full reload
                        row.MemberNameText = updatedModel.Name;
                        row.MemberEmailText = updatedModel.Email;
                        row.MemberPhoneText = updatedModel.Phone;
                        row.MemberTypeText = updatedModel.MembershipType;
                        row.MemberExpiryDateText = updatedModel.ExpiryDate?.ToString("yyyy-MM-dd") ?? "";
                        row.MemberJoinDate = updatedModel.JoinDate ?? DateTime.Now;
                        row.UpdateStatus();

                        // update cached list
                        int idx = cachedMembers.FindIndex(m => m.Id == updatedModel.Id);
                        if (idx >= 0) cachedMembers[idx] = updatedModel;
                        UpdateMemberTotals();
                    }
                    else
                        MessageBox.Show("Update failed");
                }
            }
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
                {
                    model.Id = newId;
                    cachedMembers.Add(model);

                    // add new row without full reload
                    var row = new UC_MemberRow { Role = CurrentRole };
                    SetRowData(row, model, flpMemberRowContainer.Controls.Count);
                    row.DeleteClicked += Row_DeleteClicked;
                    row.EditClicked += Row_EditClicked;
                    row.Width = flpMemberRowContainer.ClientSize.Width;
                    row.ApplyRolePermissions();
                    flpMemberRowContainer.Controls.Add(row);

                    UpdateMemberTotals();
                }
                else
                    MessageBox.Show("Failed to add member");
            }
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
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

        private void UpdateMemberTotals()
        {
            int totalMembersC = cachedMembers.Count;
            int totalActiveC = cachedMembers.Count(m => !m.IsArchived && (!m.ExpiryDate.HasValue || m.ExpiryDate.Value >= DateTime.Now));
            int totalExpiredC = cachedMembers.Count(m => m.ExpiryDate.HasValue && m.ExpiryDate.Value < DateTime.Now);

            totalMembers.Text = totalMembersC.ToString();
            totalActive.Text = totalActiveC.ToString();
            totalExpired.Text = totalExpiredC.ToString();
        }

        // Keep your existing click handlers for totals
        private void totalMembers_Click_1(object sender, EventArgs e) { }
        private void totalActive_Click(object sender, EventArgs e) { }
        private void totalExpired_Click(object sender, EventArgs e) { }
    }
}