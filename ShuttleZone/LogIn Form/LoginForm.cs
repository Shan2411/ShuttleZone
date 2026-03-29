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

        private bool isPasswordVisible = false;
        private bool isProgrammaticChange = false;

        public LoginForm()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            toggleVisibilityBtn.Image = global::ShuttleZone.Properties.Resources.Visible;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetupTextBoxWithIcon(txtUsername, "Enter your username", "👤");
            SetupTextBoxWithIcon(txtPassword, "Enter your password", "🔒");

            // 🔥 SET DEFAULT ICON HERE (IMPORTANT)
            toggleVisibilityBtn.Image = global::ShuttleZone.Properties.Resources.Visible;

            HideError();
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

        private void toggleVisibilityBtn_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                toggleVisibilityBtn.Image = global::ShuttleZone.Properties.Resources.Invisible;
            }
            else
            {
                txtPassword.PasswordChar = '●';
                toggleVisibilityBtn.Image = global::ShuttleZone.Properties.Resources.Visible;
            }
        }

        // ================= LOGIN =================

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

        // ================= ERROR =================

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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}