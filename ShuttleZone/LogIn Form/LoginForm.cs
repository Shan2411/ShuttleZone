using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using ShuttleZone.database;

namespace ShuttleZone.LogIn_Form
{
    public partial class LoginForm : Form
    {
        Color placeholderColor = Color.FromArgb(180, 180, 180);
        Color textColor = Color.FromArgb(50, 50, 50);

        // ✅ FLAG TO PREVENT AUTO-HIDE DURING CODE CHANGES
        private bool isProgrammaticChange = false;

        public LoginForm()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetupTextBoxWithIcon(txtUsername, "Enter your username", "👤");
            SetupTextBoxWithIcon(txtPassword, "Enter your password", "🔒");

            HideError();
        }

        // ✅ CENTRALIZED ERROR CONTROL
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            pnlError.Visible = true;
        }

        private void HideError()
        {
            lblError.Visible = false;
            pnlError.Visible = false;
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

            HideError();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("⚠️ Please enter your username and password.");
                return;
            }

            string role;
            string fullName;

            if (TryAuthenticate(username, password, out role, out fullName))
            {
                HideError();

                UserSession.Username = username;
                UserSession.Role = role;

                var main = new Form1(username);
                main.SetRole(role);
                main.Show();

                this.Hide();
            }
            else
            {
                ShowError("❌ Error: Incorrect Username or Password.");

                // ✅ PREVENT TEXTCHANGED FROM HIDING ERROR
                isProgrammaticChange = true;
                txtPassword.Clear();
                isProgrammaticChange = false;

                txtPassword.Focus();
            }
        }

        private bool TryAuthenticate(string username, string password, out string role, out string fullName)
        {
            role = null;
            fullName = null;

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT `role`, `full_name`, `status`
                        FROM `users`
                        WHERE `username` = @username
                          AND `password` = @password
                        LIMIT 1;
                    ";

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        var status = reader["status"] as string;
                        if (!string.IsNullOrEmpty(status) && status.ToLower() != "active")
                            return false;

                        role = reader["role"] as string;
                        fullName = reader["full_name"] as string;
                        return true;
                    }
                }
            }
            catch (MySqlException)
            {
                ShowError("❌ Database error. Check connection.");
                return false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!isProgrammaticChange)
                HideError();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!isProgrammaticChange)
                HideError();
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

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}