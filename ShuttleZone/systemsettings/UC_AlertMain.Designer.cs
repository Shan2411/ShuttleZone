namespace ShuttleZone.SystemSettings
{
    partial class UC_AlertMain
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
            this.BackPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LowStocksThresholdsTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.EquipmentOutofStockButton = new Guna.UI2.WinForms.Guna2Button();
            this.EquipmentLowStockButton = new Guna.UI2.WinForms.Guna2Button();
            this.CourtAvailabilityChangeButton = new Guna.UI2.WinForms.Guna2Button();
            this.CourtOvertimeAlertButton = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EventNotificationslbl = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.EnableSystemNotificationsButton = new Guna.UI2.WinForms.Guna2Button();
            this.Linelbl = new System.Windows.Forms.Label();
            this.NotificationSettingslbl = new System.Windows.Forms.Label();
            this.BackPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.White;
            this.BackPanel.Controls.Add(this.tableLayoutPanel1);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 0);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(1169, 524);
            this.BackPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1169, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.label4);
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.Controls.Add(this.guna2TextBox2);
            this.guna2Panel3.Controls.Add(this.label2);
            this.guna2Panel3.Controls.Add(this.LowStocksThresholdsTextBox);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(3, 323);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1163, 198);
            this.guna2Panel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Overtime Grace Period (minutes)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Low Stocks Thresholds";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2TextBox2.BorderRadius = 8;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Location = new System.Drawing.Point(18, 144);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PlaceholderText = "";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(229, 44);
            this.guna2TextBox2.TabIndex = 22;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Thresholds";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LowStocksThresholdsTextBox
            // 
            this.LowStocksThresholdsTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LowStocksThresholdsTextBox.BorderRadius = 8;
            this.LowStocksThresholdsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LowStocksThresholdsTextBox.DefaultText = "";
            this.LowStocksThresholdsTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.LowStocksThresholdsTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.LowStocksThresholdsTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LowStocksThresholdsTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LowStocksThresholdsTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LowStocksThresholdsTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LowStocksThresholdsTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LowStocksThresholdsTextBox.Location = new System.Drawing.Point(18, 72);
            this.LowStocksThresholdsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LowStocksThresholdsTextBox.Name = "LowStocksThresholdsTextBox";
            this.LowStocksThresholdsTextBox.PlaceholderText = "";
            this.LowStocksThresholdsTextBox.SelectedText = "";
            this.LowStocksThresholdsTextBox.Size = new System.Drawing.Size(229, 44);
            this.LowStocksThresholdsTextBox.TabIndex = 20;
            this.LowStocksThresholdsTextBox.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.EquipmentOutofStockButton);
            this.guna2Panel2.Controls.Add(this.EquipmentLowStockButton);
            this.guna2Panel2.Controls.Add(this.CourtAvailabilityChangeButton);
            this.guna2Panel2.Controls.Add(this.CourtOvertimeAlertButton);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.EventNotificationslbl);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(3, 103);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1163, 214);
            this.guna2Panel2.TabIndex = 1;
            // 
            // EquipmentOutofStockButton
            // 
            this.EquipmentOutofStockButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EquipmentOutofStockButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EquipmentOutofStockButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EquipmentOutofStockButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EquipmentOutofStockButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EquipmentOutofStockButton.FillColor = System.Drawing.Color.White;
            this.EquipmentOutofStockButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentOutofStockButton.ForeColor = System.Drawing.Color.Black;
            this.EquipmentOutofStockButton.Location = new System.Drawing.Point(43, 151);
            this.EquipmentOutofStockButton.Name = "EquipmentOutofStockButton";
            this.EquipmentOutofStockButton.Size = new System.Drawing.Size(204, 29);
            this.EquipmentOutofStockButton.TabIndex = 21;
            this.EquipmentOutofStockButton.Text = "Equipment Out of Stock";
            this.EquipmentOutofStockButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // EquipmentLowStockButton
            // 
            this.EquipmentLowStockButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EquipmentLowStockButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EquipmentLowStockButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EquipmentLowStockButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EquipmentLowStockButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EquipmentLowStockButton.FillColor = System.Drawing.Color.White;
            this.EquipmentLowStockButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipmentLowStockButton.ForeColor = System.Drawing.Color.Black;
            this.EquipmentLowStockButton.Location = new System.Drawing.Point(43, 116);
            this.EquipmentLowStockButton.Name = "EquipmentLowStockButton";
            this.EquipmentLowStockButton.Size = new System.Drawing.Size(204, 29);
            this.EquipmentLowStockButton.TabIndex = 20;
            this.EquipmentLowStockButton.Text = "Equipment Low Stock";
            this.EquipmentLowStockButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CourtAvailabilityChangeButton
            // 
            this.CourtAvailabilityChangeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CourtAvailabilityChangeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CourtAvailabilityChangeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CourtAvailabilityChangeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CourtAvailabilityChangeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CourtAvailabilityChangeButton.FillColor = System.Drawing.Color.White;
            this.CourtAvailabilityChangeButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourtAvailabilityChangeButton.ForeColor = System.Drawing.Color.Black;
            this.CourtAvailabilityChangeButton.Location = new System.Drawing.Point(43, 81);
            this.CourtAvailabilityChangeButton.Name = "CourtAvailabilityChangeButton";
            this.CourtAvailabilityChangeButton.Size = new System.Drawing.Size(204, 29);
            this.CourtAvailabilityChangeButton.TabIndex = 19;
            this.CourtAvailabilityChangeButton.Text = "Court Availability Change";
            this.CourtAvailabilityChangeButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CourtOvertimeAlertButton
            // 
            this.CourtOvertimeAlertButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CourtOvertimeAlertButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CourtOvertimeAlertButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CourtOvertimeAlertButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CourtOvertimeAlertButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CourtOvertimeAlertButton.FillColor = System.Drawing.Color.White;
            this.CourtOvertimeAlertButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourtOvertimeAlertButton.ForeColor = System.Drawing.Color.Black;
            this.CourtOvertimeAlertButton.Location = new System.Drawing.Point(43, 46);
            this.CourtOvertimeAlertButton.Name = "CourtOvertimeAlertButton";
            this.CourtOvertimeAlertButton.Size = new System.Drawing.Size(204, 29);
            this.CourtOvertimeAlertButton.TabIndex = 18;
            this.CourtOvertimeAlertButton.Text = "Court Overtime Alert";
            this.CourtOvertimeAlertButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(0, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1135, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "_________________________________________________________________________________" +
    "____________________________________________________________";
            // 
            // EventNotificationslbl
            // 
            this.EventNotificationslbl.AutoSize = true;
            this.EventNotificationslbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventNotificationslbl.Location = new System.Drawing.Point(13, 18);
            this.EventNotificationslbl.Name = "EventNotificationslbl";
            this.EventNotificationslbl.Size = new System.Drawing.Size(175, 25);
            this.EventNotificationslbl.TabIndex = 16;
            this.EventNotificationslbl.Text = "Event Notifications";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.EnableSystemNotificationsButton);
            this.guna2Panel1.Controls.Add(this.Linelbl);
            this.guna2Panel1.Controls.Add(this.NotificationSettingslbl);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1163, 94);
            this.guna2Panel1.TabIndex = 0;
            // 
            // EnableSystemNotificationsButton
            // 
            this.EnableSystemNotificationsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EnableSystemNotificationsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EnableSystemNotificationsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EnableSystemNotificationsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EnableSystemNotificationsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EnableSystemNotificationsButton.FillColor = System.Drawing.Color.White;
            this.EnableSystemNotificationsButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableSystemNotificationsButton.ForeColor = System.Drawing.Color.Black;
            this.EnableSystemNotificationsButton.Location = new System.Drawing.Point(54, 37);
            this.EnableSystemNotificationsButton.Name = "EnableSystemNotificationsButton";
            this.EnableSystemNotificationsButton.Size = new System.Drawing.Size(307, 29);
            this.EnableSystemNotificationsButton.TabIndex = 13;
            this.EnableSystemNotificationsButton.Text = "Enable System Notifications";
            this.EnableSystemNotificationsButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Linelbl
            // 
            this.Linelbl.AutoSize = true;
            this.Linelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linelbl.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Linelbl.Location = new System.Drawing.Point(15, 69);
            this.Linelbl.Name = "Linelbl";
            this.Linelbl.Size = new System.Drawing.Size(1135, 16);
            this.Linelbl.TabIndex = 12;
            this.Linelbl.Text = "_________________________________________________________________________________" +
    "____________________________________________________________";
            // 
            // NotificationSettingslbl
            // 
            this.NotificationSettingslbl.AutoSize = true;
            this.NotificationSettingslbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotificationSettingslbl.Location = new System.Drawing.Point(13, 9);
            this.NotificationSettingslbl.Name = "NotificationSettingslbl";
            this.NotificationSettingslbl.Size = new System.Drawing.Size(188, 25);
            this.NotificationSettingslbl.TabIndex = 11;
            this.NotificationSettingslbl.Text = "Notification Settings";
            this.NotificationSettingslbl.Click += new System.EventHandler(this.NotificationSettingslbl_Click);
            // 
            // UC_AlertMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackPanel);
            this.Name = "UC_AlertMain";
            this.Size = new System.Drawing.Size(1169, 524);
            this.BackPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel BackPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button EquipmentOutofStockButton;
        private Guna.UI2.WinForms.Guna2Button EquipmentLowStockButton;
        private Guna.UI2.WinForms.Guna2Button CourtAvailabilityChangeButton;
        private Guna.UI2.WinForms.Guna2Button CourtOvertimeAlertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EventNotificationslbl;
        private Guna.UI2.WinForms.Guna2Button EnableSystemNotificationsButton;
        private System.Windows.Forms.Label Linelbl;
        private System.Windows.Forms.Label NotificationSettingslbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox LowStocksThresholdsTextBox;
    }
}
