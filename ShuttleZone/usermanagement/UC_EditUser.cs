using System;
using System.Windows.Forms;
using ShuttleZone.UserManagement;

namespace ShuttleZone.UserManagement

{
    public partial class UC_EditUser : UserControl
    {
        private UserModel _user;

        public Action<object, object> UserUpdated { get; internal set; }
        public UserModel User { get; internal set; }

        public UC_EditUser()
        {
            InitializeComponent();
        }

        // Designer event stubs
        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void UC_EditUser_Load(object sender, EventArgs e) { }

        public void LoadUser(UserModel user)
        {
            _user = user;

            try { txtUsername.Text = user.Username; } catch { }
            try { txtFullName.Text = user.FullName; } catch { }
            try { txtEmail.Text = user.Email; } catch { }
            try { txtPhone.Text = user.Phone; } catch { }

            try { cmbRole.Text = user.Role; } catch { }
            try { cmbStatus.Text = user.Status; } catch { }
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            try { _user.Username = txtUsername.Text; } catch { }
            try { _user.FullName = txtFullName.Text; } catch { }
            try { _user.Email = txtEmail.Text; } catch { }
            try { _user.Phone = txtPhone.Text; } catch { }

            try { _user.Role = cmbRole.Text; } catch { }
            try { _user.Status = cmbStatus.Text; } catch { }

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var host = this.FindForm();
            if (host != null)
            {
                host.DialogResult = DialogResult.OK;
                host.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

        }
    }
}
