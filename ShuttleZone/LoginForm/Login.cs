using System;
using System.Windows.Forms;
using ShuttleZone.sidebars;

namespace ShuttleZone.LoginForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = guna2TextBoxEnterUsername.Text.Trim();
            string password = guna2TextBoxEnterPassword.Text.Trim();

            Form1 mainForm = new Form1();

            if (username == "admin" && password == "admin123")
            {
                mainForm.LoadSidebar(new AdminSidebar());
            }
            else if (username == "manager" && password == "manager123")
            {
                mainForm.LoadSidebar(new ManagerSidebar());
            }
            else if (username == "frontdesk" && password == "front123")
            {
                mainForm.LoadSidebar(new FrontDeskSidebar());
            }
            else
            {
                lblError.Text = "ERROR: Incorrect Username or Password";
                lblError.Visible = true;
                guna2TextBoxEnterPassword.Clear();
                guna2TextBoxEnterUsername.Focus();
                return;
            }

            mainForm.Show();
            this.Hide();
        }

        private void guna2TextBoxEnterUsername_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void guna2TextBoxEnterPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void lblError_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
