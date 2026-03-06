using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.LogIn_Form
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // ❌ Tanggalin ang X button at title bar
            this.ControlBox = false;

            // 🖥️ Full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // 🌑 Shadow effect sa pnlLogin
            ApplyShadowToPanel(pnlLogin);

            // 🔒 I-hide ang error label sa simula
            lblError.Visible = false;
        }

        // =============================================
        // ✅ LOGIN LOGIC
        // =============================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // ⚠️ Check kung blank ang fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "⚠️ Please enter your username and password.";
                lblError.Visible = true;
                return;
            }

            // ✅ Check credentials
            // TODO: Palitan ng database logic (SQL) pag ready na
            if (username == "admin" && password == "1234")
            {
                lblError.Visible = false;

                MessageBox.Show(
                    "Welcome back, " + username + "!",
                    "Shuttle Zone",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // 👉 TODO: Buksan ang Dashboard form
                // DashboardForm dashboard = new DashboardForm();
                // dashboard.Show();
                // this.Hide();
            }
            else
            {
                // ❌ Wrong credentials
                lblError.Text = "❌ Error: Incorrect Username or Password.";
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // =============================================
        // ⌨️ ENTER KEY = trigger login
        // =============================================
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        // =============================================
        // 🧹 I-clear ang error kapag nag-type ulit
        // =============================================
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        // =============================================
        // 🌑 SHADOW METHOD
        // =============================================
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