using ShuttleZone.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class UC_NewAddUser : UserControl
    {
        public UserModel CreatedUser { get; private set; }
        public FormStartPosition StartPosition { get; internal set; }

        private readonly List<string> existingUsernames = new List<string>();

        public string LoggedInRole = "Admin";

        private bool _passwordsVisible = false;

        public UC_NewAddUser()
        {
            InitializeComponent(); // must exist
            this.Load += UC_NewAddUser_Load;

            // Ensure the header close button closes the host form (if any)
            this.CloseButton.Click += (s, e) =>
            {
                var f = this.FindForm();
                if (f != null)
                {
                    f.Close();
                }
            };
        }

        private void UC_NewAddUser_Load(object sender, EventArgs e)
        {
            SetupRoles();
            SetupStatus();

            // Default: passwords hidden
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            _passwordsVisible = false;
            try { btnShowPassword.Text = "Show Passwords"; } catch { }

            // Wire Clear to the Clear (bottom) button so Clear button actually clears
            try { CancelButton.Click += (s, ev) => ClearForm(); } catch { }

            // Ensure designer assigned IconRight images are preserved (we removed direct usage) and the cursor is set
            try
            {
                var resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_NewAddUser));
                var pwdImg = resources.GetObject("txtPassword.IconRight") as System.Drawing.Image;
                var confImg = resources.GetObject("txtConfirmPassword.IconRight") as System.Drawing.Image;

                if (pwdImg != null) txtPassword.IconRight = pwdImg;
                if (confImg != null) txtConfirmPassword.IconRight = confImg;

                txtPassword.IconRightCursor = Cursors.Hand;
                txtConfirmPassword.IconRightCursor = Cursors.Hand;
            }
            catch { }

            // Restrict phone input to digits only
            txtPhone.KeyPress += txtPhone_KeyPress;
            txtPhone.TextChanged += txtPhone_TextChanged;

            // connect show button explicitly to password textboxes
            try
            {
                btnShowPassword.Click -= btnShowPassword_Click; // remove duplicate
            }
            catch { }
            btnShowPassword.Click += btnShowPassword_Click;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            // toggle visibility for both password fields only (single handler)
            _passwordsVisible = !_passwordsVisible;
            if (_passwordsVisible)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
                try { btnShowPassword.Text = "Hide Passwords"; } catch { }
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
                try { btnShowPassword.Text = "Show Passwords"; } catch { }
            }
        }

        #region Setup Methods

        private void SetupRoles()
        {
            cmbRole.Items.Clear();

            // role creation restrictions: Admin -> can create Manager; Manager -> can create Front Desk
            if (LoggedInRole == "Admin")
            {
                cmbRole.Items.Add("Manager");
            }
            else if (LoggedInRole == "Manager")
            {
                cmbRole.Items.Add("Front Desk");
            }

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }

        private void SetupStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            cmbStatus.SelectedIndex = 0;
        }

        #endregion

        #region Event Handlers

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e) { }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            // kept for legacy but not used when show button is present
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            try
            {
                txtPassword.IconRight = txtPassword.UseSystemPasswordChar ? Properties.Resources.eye_closed : Properties.Resources.eye_open;
                txtPassword.IconRightCursor = Cursors.Hand;
            }
            catch { }
        }

        private void txtConfirmPassword_IconRightClick(object sender, EventArgs e)
        {
            // kept for legacy but not used when show button is present
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            try
            {
                txtConfirmPassword.IconRight = txtConfirmPassword.UseSystemPasswordChar ? Properties.Resources.eye_closed : Properties.Resources.eye_open;
                txtConfirmPassword.IconRightCursor = Cursors.Hand;
            }
            catch { }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace), and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as Guna.UI2.WinForms.Guna2TextBox;
            if (tb == null) return;

            var digits = new string(tb.Text.Where(char.IsDigit).ToArray());
            if (tb.Text != digits)
            {
                var sel = tb.SelectionStart;
                tb.Text = digits;
                tb.SelectionStart = Math.Min(sel, tb.Text.Length);
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            if (!ValidateEmail()) return;
            if (!ValidatePhone()) return;
            if (!ValidatePasswordStrength()) return;
            if (!CheckPasswordMatch()) return;
            if (!CheckUsernameDuplicate()) return;
            if (!ValidateRoleRestriction()) return;

            CreatedUser = new UserModel
            {
                Username = txtUsername.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text,
                Role = cmbRole.Text,
                Status = cmbStatus.Text
            };

            existingUsernames.Add(txtUsername.Text);

            MessageBox.Show("User created successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            // Close the host dialog with OK so callers can read CreatedUser
            var hostForm = this.FindForm();
            try
            {
                if (hostForm != null)
                {
                    // leave CreatedUser set so caller can consume it
                    hostForm.DialogResult = DialogResult.OK;
                    hostForm.Close();
                    return;
                }
            }
            catch { }

            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Designer wires this button click to CreateButton_Click; forward to implementation
        private void CreateButton_Click(object sender, EventArgs e)
        {
            btnCreateUser_Click(sender, e);
        }

        #endregion

        #region Validation Methods

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool ValidateEmail()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text, pattern))
            {
                MessageBox.Show("Invalid email format.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool ValidatePhone()
        {
            if (!txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain numbers only.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (txtPhone.Text.Length < 10)
            {
                MessageBox.Show("Phone number is too short.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool ValidatePasswordStrength()
        {
            string password = txtPassword.Text;

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain at least 1 uppercase letter and 1 number.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool CheckPasswordMatch()
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool CheckUsernameDuplicate()
        {
            if (existingUsernames.Contains(txtUsername.Text))
            {
                MessageBox.Show("Username already exists.",
                    "Duplicate Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool ValidateRoleRestriction()
        {
            if (LoggedInRole == "Admin" && cmbRole.Text != "Manager")
            {
                MessageBox.Show("Admin can only create Manager accounts.", "Role Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (LoggedInRole == "Manager" && cmbRole.Text != "Front Desk")
            {
                MessageBox.Show("Manager can only create Front Desk accounts.", "Role Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region Utility Methods

        private void ClearForm()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            cmbStatus.SelectedIndex = 0;

            // reset visibility state
            _passwordsVisible = false;
            btnShowPassword.Text = "Show";
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        internal DialogResult ShowDialog()
        {
            // Display this UserControl inside a temporary modal Form without a title bar
            var previousParent = this.Parent;
            var previousDock = this.Dock;
            var previousLocation = this.Location;

            var host = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = this.StartPosition,
                ShowInTaskbar = false,
                MinimizeBox = false,
                MaximizeBox = false,
                ClientSize = this.Size,
                BackColor = System.Drawing.Color.White
            };

            try
            {
                // Re-parent control into the form and show modal
                this.Dock = DockStyle.Fill;
                host.Controls.Add(this);
                // Ensure right-icons are set after reparenting (resource lookups may depend on runtime context)
                try
                {
                    var rm = Properties.Resources.ResourceManager;
                    var pwdImg = rm.GetObject("txtPassword.IconRight", Properties.Resources.Culture) as System.Drawing.Image
                                 ?? rm.GetObject("eye_closed", Properties.Resources.Culture) as System.Drawing.Image;
                    var confImg = rm.GetObject("txtConfirmPassword.IconRight", Properties.Resources.Culture) as System.Drawing.Image
                                  ?? rm.GetObject("eye_closed", Properties.Resources.Culture) as System.Drawing.Image;

                    if (pwdImg != null) txtPassword.IconRight = pwdImg;
                    if (confImg != null) txtConfirmPassword.IconRight = confImg;

                    txtPassword.IconRightCursor = Cursors.Hand;
                    txtConfirmPassword.IconRightCursor = Cursors.Hand;
                }
                catch { }
                return host.ShowDialog();
            }
            finally
            {
                // Remove from host and restore previous parent
                if (host.Controls.Contains(this))
                    host.Controls.Remove(this);

                if (previousParent != null)
                {
                    previousParent.Controls.Add(this);
                    this.Dock = previousDock;
                    this.Location = previousLocation;
                }

                host.Dispose();
            }
        }

        #endregion
    }
}