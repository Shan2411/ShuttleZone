using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class EditMember : Form
    {
        public EditMember()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            cbMembershipType.Items.AddRange(new object[] {
                "1 month (Php 500)",
                "2 months (Php 955)",
                "3 months (Php 1,410)",
                "4 months (Php 1,865)",
                "5 months (Php 2,320)",
                "6 months (Php 2,775)",
                "7 months (Php 3,230)",
                "8 months (Php 3,685)",
                "9 months (Php 4,140)",
                "10 months (Php 4,350)",
                "11 months (Php 4,425)",
                "12 months (Php 4,500)"
            });

            cbJoinDate.BackColor = Color.White;

            tbMemberPhone.MaxLength = 11;
            tbMemberPhone.KeyPress += TbMemberPhone_KeyPress;
            tbMemberPhone.Leave += TbMemberPhone_Leave;

            cbMembershipType.SelectedIndexChanged += cbMembershipType_SelectedIndexChanged;
            cbJoinDate.ValueChanged += cbJoinDate_ValueChanged;

            this.Load += (s, e) => UpdateExpiryDate();
        }

        public string MemberIDValue { get; set; }
        public string MemberNameValue { get => tbMemberName.Text; set => tbMemberName.Text = value; }
        public string MemberEmailValue { get => tbMemberEmail.Text; set => tbMemberEmail.Text = value; }
        public string MemberPhoneValue { get => tbMemberPhone.Text; set => tbMemberPhone.Text = value; }
        public string MembershipTypeValue
        {
            get => cbMembershipType.SelectedItem?.ToString() ?? "";
            set
            {
                if (!string.IsNullOrEmpty(value) && cbMembershipType.Items.Contains(value))
                {
                    cbMembershipType.SelectedItem = value;
                    UpdateExpiryDate();
                }
            }
        }
        public DateTime JoinDateValue
        {
            get => cbJoinDate.Value;
            set
            {
                cbJoinDate.Value = value; // ✅ use original join date
                UpdateExpiryDate();
            }
        }
        public string ExpiryDateValue { get => ExpiryDateLbl.Text; set => ExpiryDateLbl.Text = value; }

        private void UpdateExpiryDate()
        {
            DateTime joinDate = cbJoinDate.Value;
            string membershipType = cbMembershipType.SelectedItem?.ToString() ?? "";

            int months = 0;
            if (!string.IsNullOrEmpty(membershipType))
            {
                string[] parts = membershipType.Split(' ');
                if (int.TryParse(parts[0], out int parsedMonths))
                    months = parsedMonths;
            }

            DateTime expiryDate = joinDate.AddMonths(months);
            ExpiryDateLbl.Text = expiryDate.ToString("MM/dd/yyyy");
        }

        private void cbMembershipType_SelectedIndexChanged(object sender, EventArgs e) => UpdateExpiryDate();
        private void cbJoinDate_ValueChanged(object sender, EventArgs e) => UpdateExpiryDate();

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMemberName.Text) ||
                string.IsNullOrWhiteSpace(tbMemberEmail.Text) ||
                string.IsNullOrWhiteSpace(tbMemberPhone.Text) ||
                string.IsNullOrWhiteSpace(cbMembershipType.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(tbMemberPhone.Text.Length == 11 && tbMemberPhone.Text.StartsWith("09")))
            {
                MessageBox.Show("Contact number must be 11 digits and start with '09'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!tbMemberEmail.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email must end with '@gmail.com'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateExpiryDate();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TbMemberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (tb.Text.Length >= 11 && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TbMemberPhone_Leave(object sender, EventArgs e)
        {
            if (!(tbMemberPhone.Text.StartsWith("09") && tbMemberPhone.Text.Length == 11))
            {
                MessageBox.Show("Contact number must be 11 digits and start with '09'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMemberPhone.Focus();
            }
        }
    }
}