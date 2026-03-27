using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class EditMember : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public EditMember()
        {
            InitializeComponent();

            // Borderless, white background
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Drag functionality
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
            AddDragEventsToControls(this.Controls);

            // Membership options
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

            // Join date picker UX
            cbJoinDate.BackColor = Color.White;
            cbJoinDate.ValueChanged += cbJoinDate_ValueChanged;

            // Phone input UX
            tbMemberPhone.MaxLength = 11;
            tbMemberPhone.KeyPress += TbMemberPhone_KeyPress;
            tbMemberPhone.Leave += TbMemberPhone_Leave;

            // Membership selection change
            cbMembershipType.SelectedIndexChanged += cbMembershipType_SelectedIndexChanged;

            // Initialize expiry date on load
            this.Load += (s, e) => UpdateExpiryDate();
        }

        #region Dragging
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

        private void Form_MouseUp(object sender, MouseEventArgs e) => dragging = false;
        #endregion

        #region Properties
        public string MemberIDValue { get; set; }

        public string MemberNameValue
        {
            get => tbMemberName.Text;
            set => tbMemberName.Text = value;
        }

        public string MemberEmailValue
        {
            get => tbMemberEmail.Text;
            set => tbMemberEmail.Text = value;
        }

        public string MemberPhoneValue
        {
            get => tbMemberPhone.Text;
            set => tbMemberPhone.Text = value;
        }

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
                cbJoinDate.Value = value;
                UpdateExpiryDate();
            }
        }

        public string ExpiryDateValue
        {
            get => ExpiryDateLbl.Text;
            set => ExpiryDateLbl.Text = value;
        }
        #endregion

        #region Expiry Calculation
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
        #endregion

        #region Validation
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
        #endregion

        #region Buttons
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MemberNameValue) ||
                string.IsNullOrWhiteSpace(MemberEmailValue) ||
                string.IsNullOrWhiteSpace(MemberPhoneValue) ||
                string.IsNullOrWhiteSpace(MembershipTypeValue))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(MemberPhoneValue.Length == 11 && MemberPhoneValue.StartsWith("09")))
            {
                MessageBox.Show("Contact number must be 11 digits and start with '09'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!MemberEmailValue.Contains("@") || !MemberEmailValue.Contains("."))
            {
                MessageBox.Show("Enter a valid email address.",
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
        #endregion
    }
}