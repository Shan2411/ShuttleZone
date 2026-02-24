namespace ShuttleZone
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DynamicContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.TopbarBG = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.Topbar = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ToggleModeBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ExitBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.DevTestMode = new System.Windows.Forms.TableLayoutPanel();
            this.FrontDeskBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ManagerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.AdminBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SidebarDynamicPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SidebarBackground = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TopbarBG.SuspendLayout();
            this.Topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToggleModeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).BeginInit();
            this.DevTestMode.SuspendLayout();
            this.SidebarDynamicPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.71429F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SidebarDynamicPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 617);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.DynamicContentPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TopbarBG, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(156, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(939, 617);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // DynamicContentPanel
            // 
            this.DynamicContentPanel.BackColor = System.Drawing.Color.Lavender;
            this.DynamicContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DynamicContentPanel.Location = new System.Drawing.Point(0, 30);
            this.DynamicContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DynamicContentPanel.Name = "DynamicContentPanel";
            this.DynamicContentPanel.Size = new System.Drawing.Size(939, 587);
            this.DynamicContentPanel.TabIndex = 1;
            this.DynamicContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DynamicContentPanel_Paint);
            // 
            // TopbarBG
            // 
            this.TopbarBG.BackColor = System.Drawing.Color.Transparent;
            this.TopbarBG.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.TopbarBG.BorderThickness = 1;
            this.TopbarBG.Controls.Add(this.Topbar);
            this.TopbarBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopbarBG.Location = new System.Drawing.Point(0, 0);
            this.TopbarBG.Margin = new System.Windows.Forms.Padding(0);
            this.TopbarBG.Name = "TopbarBG";
            this.TopbarBG.Size = new System.Drawing.Size(939, 30);
            this.TopbarBG.TabIndex = 0;
            // 
            // Topbar
            // 
            this.Topbar.BackColor = System.Drawing.Color.Transparent;
            this.Topbar.ColumnCount = 4;
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Topbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Topbar.Controls.Add(this.guna2HtmlLabel3, 2, 0);
            this.Topbar.Controls.Add(this.ToggleModeBtn, 3, 0);
            this.Topbar.Controls.Add(this.ExitBtn, 0, 0);
            this.Topbar.Controls.Add(this.DevTestMode, 1, 0);
            this.Topbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Topbar.Location = new System.Drawing.Point(0, 0);
            this.Topbar.Margin = new System.Windows.Forms.Padding(0);
            this.Topbar.Name = "Topbar";
            this.Topbar.RowCount = 1;
            this.Topbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Topbar.Size = new System.Drawing.Size(939, 30);
            this.Topbar.TabIndex = 0;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(749, 6);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(11, 4, 4, 4);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(137, 18);
            this.guna2HtmlLabel3.TabIndex = 5;
            this.guna2HtmlLabel3.Text = "Thursday, Jan 22, 2026";
            this.guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToggleModeBtn
            // 
            this.ToggleModeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToggleModeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleModeBtn.BackgroundImage")));
            this.ToggleModeBtn.FillColor = System.Drawing.Color.Transparent;
            this.ToggleModeBtn.ImageRotate = 0F;
            this.ToggleModeBtn.Location = new System.Drawing.Point(907, 7);
            this.ToggleModeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ToggleModeBtn.Name = "ToggleModeBtn";
            this.ToggleModeBtn.Size = new System.Drawing.Size(15, 16);
            this.ToggleModeBtn.TabIndex = 3;
            this.ToggleModeBtn.TabStop = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitBtn.BackgroundImage")));
            this.ExitBtn.FillColor = System.Drawing.Color.Transparent;
            this.ExitBtn.ImageRotate = 0F;
            this.ExitBtn.Location = new System.Drawing.Point(15, 7);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(15, 16);
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
            this.DevTestMode.Location = new System.Drawing.Point(49, 3);
            this.DevTestMode.Name = "DevTestMode";
            this.DevTestMode.RowCount = 1;
            this.DevTestMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DevTestMode.Size = new System.Drawing.Size(651, 24);
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
            this.FrontDeskBtn.Location = new System.Drawing.Point(437, 3);
            this.FrontDeskBtn.Name = "FrontDeskBtn";
            this.FrontDeskBtn.Size = new System.Drawing.Size(211, 18);
            this.FrontDeskBtn.TabIndex = 2;
            this.FrontDeskBtn.Text = "Front-Desk";
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
            this.ManagerBtn.Location = new System.Drawing.Point(220, 3);
            this.ManagerBtn.Name = "ManagerBtn";
            this.ManagerBtn.Size = new System.Drawing.Size(211, 18);
            this.ManagerBtn.TabIndex = 1;
            this.ManagerBtn.Text = "Manager";
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
            this.AdminBtn.Location = new System.Drawing.Point(3, 3);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(211, 18);
            this.AdminBtn.TabIndex = 0;
            this.AdminBtn.Text = "Admin";
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // SidebarDynamicPanel
            // 
            this.SidebarDynamicPanel.Controls.Add(this.SidebarBackground);
            this.SidebarDynamicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidebarDynamicPanel.Location = new System.Drawing.Point(0, 0);
            this.SidebarDynamicPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SidebarDynamicPanel.Name = "SidebarDynamicPanel";
            this.SidebarDynamicPanel.Size = new System.Drawing.Size(156, 617);
            this.SidebarDynamicPanel.TabIndex = 5;
            // 
            // SidebarBackground
            // 
            this.SidebarBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidebarBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.SidebarBackground.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
            this.SidebarBackground.Location = new System.Drawing.Point(0, 0);
            this.SidebarBackground.Margin = new System.Windows.Forms.Padding(0);
            this.SidebarBackground.Name = "SidebarBackground";
            this.SidebarBackground.Size = new System.Drawing.Size(156, 617);
            this.SidebarBackground.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.TopbarBG.ResumeLayout(false);
            this.Topbar.ResumeLayout(false);
            this.Topbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToggleModeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).EndInit();
            this.DevTestMode.ResumeLayout(false);
            this.SidebarDynamicPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel Topbar;
        private Guna.UI2.WinForms.Guna2PictureBox ExitBtn;
        private Guna.UI2.WinForms.Guna2PictureBox ToggleModeBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Panel DynamicContentPanel;
        private System.Windows.Forms.TableLayoutPanel DevTestMode;
        private Guna.UI2.WinForms.Guna2Button FrontDeskBtn;
        private Guna.UI2.WinForms.Guna2Button ManagerBtn;
        private Guna.UI2.WinForms.Guna2Button AdminBtn;
        private Guna.UI2.WinForms.Guna2Panel SidebarDynamicPanel;
        private Guna.UI2.WinForms.Guna2GradientPanel SidebarBackground;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel TopbarBG;
    }
}

/*

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel Sidebar;
        private System.Windows.Forms.TableLayoutPanel SidebarContainer;
        private System.Windows.Forms.TableLayoutPanel NavLinkGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel NavLinkContainer;
        private System.Windows.Forms.TableLayoutPanel UserManagementBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private System.Windows.Forms.TableLayoutPanel ReportsBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox7;
        private System.Windows.Forms.TableLayoutPanel MaintenanceBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private System.Windows.Forms.TableLayoutPanel EquipmentManagementBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private System.Windows.Forms.TableLayoutPanel RentalHistoryBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private System.Windows.Forms.TableLayoutPanel PosButtonContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private System.Windows.Forms.TableLayoutPanel MembershipBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel MembershipBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel UserBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel ReportsBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel MaintenanceBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel EquipmentBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel RentalBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel PosBtn;
        private System.Windows.Forms.TableLayoutPanel SidebarHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel DashboardBtnContainer;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.TableLayoutPanel UserContainer;
        private Guna.UI2.WinForms.Guna2HtmlLabel UserLocation;
        private Guna.UI2.WinForms.Guna2HtmlLabel Username;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private Guna.UI2.WinForms.Guna2PictureBox CloseBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel DateLbl;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox9;
        private System.Windows.Forms.TableLayoutPanel SystemSettingsBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel SysSettingsBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2Panel MainContentPanel;
        private Guna.UI2.WinForms.Guna2Button LogoutBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}

*/