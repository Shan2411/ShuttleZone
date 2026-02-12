using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class AddNewMember : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public AddNewMember()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
            AddDragEventsToControls(this.Controls);

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
            cbJoinDate.Value = DateTime.Now;

            tbMemberPhone.MaxLength = 11;
            tbMemberPhone.KeyPress += TbMemberPhone_KeyPress;
            tbMemberPhone.Leave += TbMemberPhone_Leave;
        }

        private void AddDragEventsToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseDown += Form_MouseDown;
                control.MouseMove += Form_MouseMove;
                control.MouseUp += Form_MouseUp;

                if (control.HasChildren)
                    AddDragEventsToControls(control.Controls);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e) => this.Close();
        private void CloseBtn_Click(object sender, EventArgs e) => this.Close();

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            string MemberName = tbMemberName.Text;
            string MemberEmail = tbMemberEmail.Text;
            string MemberContactString = tbMemberPhone.Text;
            string MembershipType = cbMembershipType.SelectedItem?.ToString() ?? "";
            DateTime JoinDate = cbJoinDate.Value;

            if (string.IsNullOrWhiteSpace(MemberName) ||
                string.IsNullOrWhiteSpace(MemberEmail) ||
                string.IsNullOrWhiteSpace(MemberContactString) ||
                string.IsNullOrWhiteSpace(MembershipType))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(MemberContactString.Length == 11 && MemberContactString.StartsWith("09")))
            {
                MessageBox.Show("Contact number must be 11 digits and start with '09'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!MemberEmail.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email must end with '@gmail.com'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int months = 0;
            string[] parts = MembershipType.Split(' ');
            if (int.TryParse(parts[0], out int parsedMonths))
                months = parsedMonths;

            DateTime expiryDate = JoinDate.AddMonths(months);
            ExpiryDateLbl.Text = expiryDate.ToString("yyyy-MM-dd");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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

        private void TbMemberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return; // safety guard

            // Allow control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block non-digit input
            }

            // Prevent typing beyond 11 digits
            if (tb.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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

        // Expose values for UC_Membership
        public string MemberNameValue => tbMemberName.Text;
        public string MemberEmailValue => tbMemberEmail.Text;
        public string MemberPhoneValue => tbMemberPhone.Text;
        public string MembershipTypeValue => cbMembershipType.SelectedItem?.ToString() ?? "";
        public string ExpiryDateValue => ExpiryDateLbl.Text;
    }
}