using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms; 

namespace ShuttleZone.LogIn_Form
{
    public partial class LoginForm : Form
    {
   
        Color placeholderColor = Color.FromArgb(180, 180, 180);
        Color textColor = Color.FromArgb(50, 50, 50);

        public LoginForm()
        {
            InitializeComponent();

            this.ControlBox = false;


            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            ApplyShadowToPanel(pnlLogin);


            SetupTextBoxWithIcon(
                txtUsername,
                "Enter your username",
                "👤"
            );
            SetupTextBoxWithIcon(
                txtPassword,
                "Enter your password",
                "🔒"
            );


            lblError.Visible = false;
        }

        private void SetupTextBoxWithIcon(Guna2TextBox txt, string placeholder, string icon)
        {
      
            txt.PlaceholderText = placeholder;
            txt.PlaceholderForeColor = placeholderColor;
            txt.ForeColor = textColor;

            if (icon == "👤")
            {
              
                txt.PlaceholderText = "  👤  " + placeholder;
            }
            else if (icon == "🔒")
            {
                txt.PlaceholderText = "  🔒  " + placeholder;
                txt.PasswordChar = '●'; 
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "⚠️ Please enter your username and password.";
                lblError.Visible = true;
                return;
            }

            if (username == "admin" && password == "1234")
            {
                lblError.Visible = false;

                MessageBox.Show(
                    "Welcome back, " + username + "!",
                    "Shuttle Zone",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            else
            {
                lblError.Text = "❌ Error: Incorrect Username or Password.";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

  
        private void ApplyShadowToPanel(Panel panel)
        {
            int shadowSize = 6;

            for (int i = shadowSize; i >= 1; i--)
            {
                Panel shadowLayer = new Panel();
                shadowLayer.BackColor = Color.FromArgb(18 - (i * 2), 0, 0, 0);
                shadowLayer.Size = new Size(panel.Width + (i * 2), panel.Height + (i * 2));
                shadowLayer.Location = new Point(
                    panel.Left - i + 5,
                    panel.Top - i + 5
                );
                shadowLayer.BorderStyle = BorderStyle.None;

                this.Controls.Add(shadowLayer);
                shadowLayer.SendToBack();
            }

            panel.BringToFront();
        }

        private void lblError_Click(object sender, EventArgs e)
        {
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}