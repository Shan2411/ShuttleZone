namespace ShuttleZone.topbar
{
    partial class AdminTopbar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTopbar));
            this.Topbar = new System.Windows.Forms.TableLayoutPanel();
            this.ExitBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.DevTestMode = new System.Windows.Forms.TableLayoutPanel();
            this.FrontDeskBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ManagerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.AdminBtn = new Guna.UI2.WinForms.Guna2Button();
            this.DateLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SettingsBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ToggleModeBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).BeginInit();
            this.DevTestMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToggleModeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // Topbar
            // 
            this.Topbar.BackColor = System.Drawing.Color.Transparent;
            this.Topbar.ColumnCount = 6;
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Topbar.Controls.Add(this.ExitBtn, 0, 0);
            this.Topbar.Controls.Add(this.DevTestMode, 1, 0);
            this.Topbar.Controls.Add(this.SettingsBtn, 5, 0);
            this.Topbar.Controls.Add(this.ToggleModeBtn, 4, 0);
            this.Topbar.Controls.Add(this.DateLbl, 2, 0);
            this.Topbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Topbar.Location = new System.Drawing.Point(0, 0);
            this.Topbar.Margin = new System.Windows.Forms.Padding(0);
            this.Topbar.Name = "Topbar";
            this.Topbar.RowCount = 1;
            this.Topbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Topbar.Size = new System.Drawing.Size(1252, 37);
            this.Topbar.TabIndex = 1;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitBtn.BackgroundImage")));
            this.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitBtn.FillColor = System.Drawing.Color.Transparent;
            this.ExitBtn.ImageRotate = 0F;
            this.ExitBtn.Location = new System.Drawing.Point(21, 8);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(20, 20);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.TabStop = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DevTestMode
            // 
            this.DevTestMode.ColumnCount = 3;
            this.DevTestMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DevTestMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DevTestMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DevTestMode.Controls.Add(this.FrontDeskBtn, 2, 0);
            this.DevTestMode.Controls.Add(this.ManagerBtn, 1, 0);
            this.DevTestMode.Controls.Add(this.AdminBtn, 0, 0);
            this.DevTestMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevTestMode.Location = new System.Drawing.Point(66, 4);
            this.DevTestMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DevTestMode.Name = "DevTestMode";
            this.DevTestMode.RowCount = 1;
            this.DevTestMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DevTestMode.Size = new System.Drawing.Size(618, 29);
            this.DevTestMode.TabIndex = 6;
            // 
            // FrontDeskBtn
            // 
            this.FrontDeskBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FrontDeskBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FrontDeskBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FrontDeskBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FrontDeskBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontDeskBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FrontDeskBtn.ForeColor = System.Drawing.Color.White;
            this.FrontDeskBtn.Location = new System.Drawing.Point(414, 4);
            this.FrontDeskBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FrontDeskBtn.Name = "FrontDeskBtn";
            this.FrontDeskBtn.Size = new System.Drawing.Size(200, 21);
            this.FrontDeskBtn.TabIndex = 2;
            this.FrontDeskBtn.Text = "Front-Desk";
            this.FrontDeskBtn.Visible = false;
            this.FrontDeskBtn.Click += new System.EventHandler(this.FrontDeskBtn_Click);
            // 
            // ManagerBtn
            // 
            this.ManagerBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ManagerBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ManagerBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ManagerBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ManagerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManagerBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ManagerBtn.ForeColor = System.Drawing.Color.White;
            this.ManagerBtn.Location = new System.Drawing.Point(209, 4);
            this.ManagerBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManagerBtn.Name = "ManagerBtn";
            this.ManagerBtn.Size = new System.Drawing.Size(197, 21);
            this.ManagerBtn.TabIndex = 1;
            this.ManagerBtn.Text = "Manager";
            this.ManagerBtn.Visible = false;
            this.ManagerBtn.Click += new System.EventHandler(this.ManagerBtn_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AdminBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AdminBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AdminBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AdminBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AdminBtn.ForeColor = System.Drawing.Color.White;
            this.AdminBtn.Location = new System.Drawing.Point(4, 4);
            this.AdminBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(197, 21);
            this.AdminBtn.TabIndex = 0;
            this.AdminBtn.Text = "Admin";
            this.AdminBtn.Visible = false;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // DateLbl
            // 
            this.DateLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DateLbl.BackColor = System.Drawing.Color.Transparent;
            this.DateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.ForeColor = System.Drawing.Color.Black;
            this.DateLbl.Location = new System.Drawing.Point(936, 8);
            this.DateLbl.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(172, 21);
            this.DateLbl.TabIndex = 5;
            this.DateLbl.Text = "Thursday, Jan 22, 2026";
            this.DateLbl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SettingsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.BackgroundImage")));
            this.SettingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsBtn.FillColor = System.Drawing.Color.Transparent;
            this.SettingsBtn.ImageRotate = 0F;
            this.SettingsBtn.Location = new System.Drawing.Point(1209, 8);
            this.SettingsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(20, 20);
            this.SettingsBtn.TabIndex = 7;
            this.SettingsBtn.TabStop = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // ToggleModeBtn
            // 
            this.ToggleModeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToggleModeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleModeBtn.BackgroundImage")));
            this.ToggleModeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToggleModeBtn.FillColor = System.Drawing.Color.Transparent;
            this.ToggleModeBtn.ImageRotate = 0F;
            this.ToggleModeBtn.Location = new System.Drawing.Point(1146, 8);
            this.ToggleModeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ToggleModeBtn.Name = "ToggleModeBtn";
            this.ToggleModeBtn.Size = new System.Drawing.Size(20, 20);
            this.ToggleModeBtn.TabIndex = 3;
            this.ToggleModeBtn.TabStop = false;
            // 
            // AdminTopbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Topbar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminTopbar";
            this.Size = new System.Drawing.Size(1252, 37);
            this.Topbar.ResumeLayout(false);
            this.Topbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).EndInit();
            this.DevTestMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToggleModeBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Topbar;
        private Guna.UI2.WinForms.Guna2PictureBox SettingsBtn;
        private Guna.UI2.WinForms.Guna2PictureBox ToggleModeBtn;
        private Guna.UI2.WinForms.Guna2PictureBox ExitBtn;
        private System.Windows.Forms.TableLayoutPanel DevTestMode;
        private Guna.UI2.WinForms.Guna2Button FrontDeskBtn;
        private Guna.UI2.WinForms.Guna2Button ManagerBtn;
        private Guna.UI2.WinForms.Guna2Button AdminBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel DateLbl;
    }
}
