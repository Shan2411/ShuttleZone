using System;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement

{
    partial class UC_UserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_UserManagement));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.PanelTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.SearchbarBGPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Searchbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Roles = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.FullName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Email = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpMemberRowContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.SearchbarBGPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SearchbarBGPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1243, 722);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddUser, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.PanelTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2Panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1238, 72);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnAddUser.BorderRadius = 8;
            this.btnAddUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(1059, 25);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(7, 25, 27, 25);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(152, 22);
            this.btnAddUser.TabIndex = 35;
            this.btnAddUser.Text = "+ Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.Title);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTitle.Location = new System.Drawing.Point(3, 3);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelTitle.Size = new System.Drawing.Size(520, 66);
            this.PanelTitle.TabIndex = 36;
            // 
            // Title
            // 
            this.Title.AutoSize = false;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(10, 22);
            this.Title.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1828, 201);
            this.Title.TabIndex = 0;
            this.Title.Text = "User & Role Management";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(529, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(520, 66);
            this.guna2Panel2.TabIndex = 37;
            // 
            // SearchbarBGPanel
            // 
            this.SearchbarBGPanel.BackColor = System.Drawing.Color.Transparent;
            this.SearchbarBGPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.SearchbarBGPanel.BorderRadius = 5;
            this.SearchbarBGPanel.BorderThickness = 1;
            this.SearchbarBGPanel.Controls.Add(this.guna2ComboBox1);
            this.SearchbarBGPanel.Controls.Add(this.Searchbox);
            this.SearchbarBGPanel.CustomBorderColor = System.Drawing.Color.Gray;
            this.SearchbarBGPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchbarBGPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.SearchbarBGPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.SearchbarBGPanel.Location = new System.Drawing.Point(18, 76);
            this.SearchbarBGPanel.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.SearchbarBGPanel.Name = "SearchbarBGPanel";
            this.SearchbarBGPanel.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.SearchbarBGPanel.ShadowDecoration.Depth = 60;
            this.SearchbarBGPanel.Size = new System.Drawing.Size(1212, 42);
            this.SearchbarBGPanel.TabIndex = 1;
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 8;
            this.guna2ComboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 29;
            this.guna2ComboBox1.Location = new System.Drawing.Point(823, 10);
            this.guna2ComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 6);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(378, 35);
            this.guna2ComboBox1.TabIndex = 7;
            this.guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // Searchbox
            // 
            this.Searchbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.Searchbox.BorderRadius = 8;
            this.Searchbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Searchbox.DefaultText = "";
            this.Searchbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Searchbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Searchbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Searchbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Searchbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Searchbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Searchbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Searchbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Searchbox.IconLeft = ((System.Drawing.Image)(resources.GetObject("Searchbox.IconLeft")));
            this.Searchbox.Location = new System.Drawing.Point(11, 10);
            this.Searchbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.Padding = new System.Windows.Forms.Padding(4);
            this.Searchbox.PlaceholderText = "";
            this.Searchbox.SelectedText = "";
            this.Searchbox.Size = new System.Drawing.Size(1190, 22);
            this.Searchbox.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.guna2CustomGradientPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpMemberRowContainer, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(18, 126);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.89796F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1212, 592);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.guna2CustomGradientPanel1.BorderRadius = 10;
            this.guna2CustomGradientPanel1.BorderThickness = 1;
            this.guna2CustomGradientPanel1.Controls.Add(this.tableLayoutPanel3);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1212, 30);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.Controls.Add(this.guna2HtmlLabel9, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.guna2HtmlLabel7, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.Roles, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.UserName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ID, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.FullName, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.Email, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1212, 30);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.AutoSize = false;
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(1017, 15);
            this.guna2HtmlLabel9.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(195, 15);
            this.guna2HtmlLabel9.TabIndex = 8;
            this.guna2HtmlLabel9.Text = "ACTIONS";
            this.guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(982, 15);
            this.guna2HtmlLabel7.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(35, 15);
            this.guna2HtmlLabel7.TabIndex = 6;
            this.guna2HtmlLabel7.Text = "STATUS";
            // 
            // Roles
            // 
            this.Roles.AccessibleDescription = "Rolz";
            this.Roles.AutoSize = false;
            this.Roles.BackColor = System.Drawing.Color.Transparent;
            this.Roles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Roles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.Roles.Location = new System.Drawing.Point(774, 15);
            this.Roles.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.Roles.Name = "Roles";
            this.Roles.Size = new System.Drawing.Size(198, 15);
            this.Roles.TabIndex = 5;
            this.Roles.Text = "ROLE";
            // 
            // UserName
            // 
            this.UserName.AutoSize = false;
            this.UserName.BackColor = System.Drawing.Color.Transparent;
            this.UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.UserName.Location = new System.Drawing.Point(75, 15);
            this.UserName.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(183, 15);
            this.UserName.TabIndex = 2;
            this.UserName.Text = "USERNAME";
            // 
            // ID
            // 
            this.ID.AutoSize = false;
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.ID.Location = new System.Drawing.Point(15, 15);
            this.ID.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(50, 15);
            this.ID.TabIndex = 1;
            this.ID.Text = "ID";
            // 
            // FullName
            // 
            this.FullName.AutoSize = false;
            this.FullName.BackColor = System.Drawing.Color.Transparent;
            this.FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.FullName.Location = new System.Drawing.Point(268, 15);
            this.FullName.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(219, 15);
            this.FullName.TabIndex = 4;
            this.FullName.Text = "FULLNAME";
            // 
            // Email
            // 
            this.Email.AutoSize = false;
            this.Email.BackColor = System.Drawing.Color.Transparent;
            this.Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.Email.Location = new System.Drawing.Point(497, 15);
            this.Email.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(267, 15);
            this.Email.TabIndex = 3;
            this.Email.Text = "EMAIL";
            // 
            // flpMemberRowContainer
            // 
            this.flpMemberRowContainer.AutoScroll = true;
            this.flpMemberRowContainer.BackColor = System.Drawing.Color.Transparent;
            this.flpMemberRowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMemberRowContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMemberRowContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flpMemberRowContainer.Location = new System.Drawing.Point(0, 35);
            this.flpMemberRowContainer.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flpMemberRowContainer.Name = "flpMemberRowContainer";
            this.flpMemberRowContainer.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flpMemberRowContainer.Size = new System.Drawing.Size(1212, 552);
            this.flpMemberRowContainer.TabIndex = 1;
            this.flpMemberRowContainer.WrapContents = false;
            this.flpMemberRowContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMemberRowContainer_Paint);
            // 
            // UC_UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_UserManagement";
            this.Size = new System.Drawing.Size(1243, 722);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.SearchbarBGPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

       


       //private void btnAddUser_Click_1(object sender, EventArgs e)
       // {
            // Delegate to the implemented handler in the other partial class
           // BtnAddUser_Click(sender, e);
       // }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel Title;
        private Guna.UI2.WinForms.Guna2GradientPanel SearchbarBGPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel Roles;
        private Guna.UI2.WinForms.Guna2HtmlLabel FullName;
        private Guna.UI2.WinForms.Guna2HtmlLabel Email;
        private Guna.UI2.WinForms.Guna2HtmlLabel UserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel ID;
        private System.Windows.Forms.FlowLayoutPanel flpMemberRowContainer;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2TextBox Searchbox;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2Panel PanelTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        // placeholder row removed; rows are created dynamically at runtime
    }
}
