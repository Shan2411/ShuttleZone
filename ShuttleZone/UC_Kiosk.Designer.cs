namespace ShuttleZone
{
    partial class UC_Kiosk
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
            this.btnRunKiosk = new Guna.UI2.WinForms.Guna2Button();
            this.tlpRootKiosk = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeaderKiosk = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveChanges = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeaderText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlRunKiosk = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblLaunchKioskMode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlKioskSettings = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.tlpKioskSettings = new System.Windows.Forms.TableLayoutPanel();
            this.lblKioskSettingsText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlAutoReturn = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSessionTimeout = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeaderText = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPromoText = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAutoReturnHome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSessionTimeout = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPanelHeaderText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPromoCardText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tlpRootKiosk.SuspendLayout();
            this.tlpHeaderKiosk.SuspendLayout();
            this.pnlRunKiosk.SuspendLayout();
            this.pnlKioskSettings.SuspendLayout();
            this.tlpKioskSettings.SuspendLayout();
            this.pnlAutoReturn.SuspendLayout();
            this.pnlSessionTimeout.SuspendLayout();
            this.pnlHeaderText.SuspendLayout();
            this.pnlPromoText.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunKiosk
            // 
            this.btnRunKiosk.BorderRadius = 10;
            this.btnRunKiosk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRunKiosk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRunKiosk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRunKiosk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRunKiosk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnRunKiosk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunKiosk.ForeColor = System.Drawing.Color.White;
            this.btnRunKiosk.Location = new System.Drawing.Point(53, 47);
            this.btnRunKiosk.Name = "btnRunKiosk";
            this.btnRunKiosk.Size = new System.Drawing.Size(151, 61);
            this.btnRunKiosk.TabIndex = 0;
            this.btnRunKiosk.Text = "Run Kiosk";
            // 
            // tlpRootKiosk
            // 
            this.tlpRootKiosk.ColumnCount = 1;
            this.tlpRootKiosk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRootKiosk.Controls.Add(this.tlpHeaderKiosk, 0, 0);
            this.tlpRootKiosk.Controls.Add(this.pnlRunKiosk, 0, 1);
            this.tlpRootKiosk.Controls.Add(this.pnlKioskSettings, 0, 2);
            this.tlpRootKiosk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRootKiosk.Location = new System.Drawing.Point(0, 0);
            this.tlpRootKiosk.Name = "tlpRootKiosk";
            this.tlpRootKiosk.RowCount = 3;
            this.tlpRootKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRootKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRootKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpRootKiosk.Size = new System.Drawing.Size(932, 587);
            this.tlpRootKiosk.TabIndex = 1;
            // 
            // tlpHeaderKiosk
            // 
            this.tlpHeaderKiosk.ColumnCount = 3;
            this.tlpHeaderKiosk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpHeaderKiosk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpHeaderKiosk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeaderKiosk.Controls.Add(this.btnSaveChanges, 2, 0);
            this.tlpHeaderKiosk.Controls.Add(this.lblHeaderText, 1, 0);
            this.tlpHeaderKiosk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeaderKiosk.Location = new System.Drawing.Point(3, 3);
            this.tlpHeaderKiosk.Name = "tlpHeaderKiosk";
            this.tlpHeaderKiosk.RowCount = 1;
            this.tlpHeaderKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeaderKiosk.Size = new System.Drawing.Size(926, 54);
            this.tlpHeaderKiosk.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BorderRadius = 10;
            this.btnSaveChanges.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveChanges.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveChanges.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveChanges.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveChanges.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(753, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(170, 45);
            this.btnSaveChanges.TabIndex = 0;
            this.btnSaveChanges.Text = "Save Changes";
            // 
            // lblHeaderText
            // 
            this.lblHeaderText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderText.Location = new System.Drawing.Point(53, 13);
            this.lblHeaderText.Name = "lblHeaderText";
            this.lblHeaderText.Size = new System.Drawing.Size(174, 27);
            this.lblHeaderText.TabIndex = 1;
            this.lblHeaderText.Text = "Kiosk Management";
            // 
            // pnlRunKiosk
            // 
            this.pnlRunKiosk.BorderRadius = 15;
            this.pnlRunKiosk.Controls.Add(this.lblLaunchKioskMode);
            this.pnlRunKiosk.Controls.Add(this.btnRunKiosk);
            this.pnlRunKiosk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRunKiosk.FillColor = System.Drawing.Color.White;
            this.pnlRunKiosk.FillColor2 = System.Drawing.Color.White;
            this.pnlRunKiosk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRunKiosk.Location = new System.Drawing.Point(3, 63);
            this.pnlRunKiosk.Name = "pnlRunKiosk";
            this.pnlRunKiosk.Size = new System.Drawing.Size(926, 125);
            this.pnlRunKiosk.TabIndex = 2;
            // 
            // lblLaunchKioskMode
            // 
            this.lblLaunchKioskMode.BackColor = System.Drawing.Color.Transparent;
            this.lblLaunchKioskMode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaunchKioskMode.Location = new System.Drawing.Point(53, 18);
            this.lblLaunchKioskMode.Name = "lblLaunchKioskMode";
            this.lblLaunchKioskMode.Size = new System.Drawing.Size(145, 23);
            this.lblLaunchKioskMode.TabIndex = 1;
            this.lblLaunchKioskMode.Text = "Launch Kiosk Mode";
            // 
            // pnlKioskSettings
            // 
            this.pnlKioskSettings.BorderRadius = 15;
            this.pnlKioskSettings.Controls.Add(this.tlpKioskSettings);
            this.pnlKioskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskSettings.FillColor = System.Drawing.Color.White;
            this.pnlKioskSettings.FillColor2 = System.Drawing.Color.White;
            this.pnlKioskSettings.Location = new System.Drawing.Point(3, 194);
            this.pnlKioskSettings.Name = "pnlKioskSettings";
            this.pnlKioskSettings.Size = new System.Drawing.Size(926, 390);
            this.pnlKioskSettings.TabIndex = 3;
            // 
            // tlpKioskSettings
            // 
            this.tlpKioskSettings.BackColor = System.Drawing.Color.Transparent;
            this.tlpKioskSettings.ColumnCount = 1;
            this.tlpKioskSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKioskSettings.Controls.Add(this.lblKioskSettingsText, 0, 0);
            this.tlpKioskSettings.Controls.Add(this.pnlAutoReturn, 0, 1);
            this.tlpKioskSettings.Controls.Add(this.pnlSessionTimeout, 0, 2);
            this.tlpKioskSettings.Controls.Add(this.pnlHeaderText, 0, 3);
            this.tlpKioskSettings.Controls.Add(this.pnlPromoText, 0, 4);
            this.tlpKioskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKioskSettings.Location = new System.Drawing.Point(0, 0);
            this.tlpKioskSettings.Name = "tlpKioskSettings";
            this.tlpKioskSettings.Padding = new System.Windows.Forms.Padding(5);
            this.tlpKioskSettings.RowCount = 5;
            this.tlpKioskSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpKioskSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKioskSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKioskSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKioskSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKioskSettings.Size = new System.Drawing.Size(926, 390);
            this.tlpKioskSettings.TabIndex = 0;
            // 
            // lblKioskSettingsText
            // 
            this.lblKioskSettingsText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKioskSettingsText.BackColor = System.Drawing.Color.Transparent;
            this.lblKioskSettingsText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKioskSettingsText.Location = new System.Drawing.Point(8, 13);
            this.lblKioskSettingsText.Name = "lblKioskSettingsText";
            this.lblKioskSettingsText.Size = new System.Drawing.Size(110, 23);
            this.lblKioskSettingsText.TabIndex = 0;
            this.lblKioskSettingsText.Text = "Kiosk Settings";
            // 
            // pnlAutoReturn
            // 
            this.pnlAutoReturn.BorderRadius = 10;
            this.pnlAutoReturn.Controls.Add(this.lblAutoReturnHome);
            this.pnlAutoReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAutoReturn.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAutoReturn.Location = new System.Drawing.Point(8, 48);
            this.pnlAutoReturn.Name = "pnlAutoReturn";
            this.pnlAutoReturn.Size = new System.Drawing.Size(910, 79);
            this.pnlAutoReturn.TabIndex = 1;
            this.pnlAutoReturn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAutoReturn_Paint);
            // 
            // pnlSessionTimeout
            // 
            this.pnlSessionTimeout.BorderRadius = 10;
            this.pnlSessionTimeout.Controls.Add(this.lblSessionTimeout);
            this.pnlSessionTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSessionTimeout.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSessionTimeout.Location = new System.Drawing.Point(8, 133);
            this.pnlSessionTimeout.Name = "pnlSessionTimeout";
            this.pnlSessionTimeout.Size = new System.Drawing.Size(910, 79);
            this.pnlSessionTimeout.TabIndex = 2;
            // 
            // pnlHeaderText
            // 
            this.pnlHeaderText.BorderRadius = 10;
            this.pnlHeaderText.Controls.Add(this.lblPanelHeaderText);
            this.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderText.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeaderText.Location = new System.Drawing.Point(8, 218);
            this.pnlHeaderText.Name = "pnlHeaderText";
            this.pnlHeaderText.Size = new System.Drawing.Size(910, 79);
            this.pnlHeaderText.TabIndex = 3;
            this.pnlHeaderText.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // pnlPromoText
            // 
            this.pnlPromoText.BorderRadius = 10;
            this.pnlPromoText.Controls.Add(this.lblPromoCardText);
            this.pnlPromoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPromoText.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPromoText.Location = new System.Drawing.Point(8, 303);
            this.pnlPromoText.Name = "pnlPromoText";
            this.pnlPromoText.Size = new System.Drawing.Size(910, 79);
            this.pnlPromoText.TabIndex = 4;
            // 
            // lblAutoReturnHome
            // 
            this.lblAutoReturnHome.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoReturnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoReturnHome.Location = new System.Drawing.Point(48, 22);
            this.lblAutoReturnHome.Name = "lblAutoReturnHome";
            this.lblAutoReturnHome.Size = new System.Drawing.Size(136, 19);
            this.lblAutoReturnHome.TabIndex = 0;
            this.lblAutoReturnHome.Text = "Auto Return to Home";
            // 
            // lblSessionTimeout
            // 
            this.lblSessionTimeout.BackColor = System.Drawing.Color.Transparent;
            this.lblSessionTimeout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSessionTimeout.Location = new System.Drawing.Point(45, 20);
            this.lblSessionTimeout.Name = "lblSessionTimeout";
            this.lblSessionTimeout.Size = new System.Drawing.Size(102, 19);
            this.lblSessionTimeout.TabIndex = 0;
            this.lblSessionTimeout.Text = "Session Timeout";
            // 
            // lblPanelHeaderText
            // 
            this.lblPanelHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.lblPanelHeaderText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPanelHeaderText.Location = new System.Drawing.Point(48, 19);
            this.lblPanelHeaderText.Name = "lblPanelHeaderText";
            this.lblPanelHeaderText.Size = new System.Drawing.Size(114, 19);
            this.lblPanelHeaderText.TabIndex = 0;
            this.lblPanelHeaderText.Text = "Panel Header Text";
            // 
            // lblPromoCardText
            // 
            this.lblPromoCardText.BackColor = System.Drawing.Color.Transparent;
            this.lblPromoCardText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPromoCardText.Location = new System.Drawing.Point(48, 22);
            this.lblPromoCardText.Name = "lblPromoCardText";
            this.lblPromoCardText.Size = new System.Drawing.Size(106, 19);
            this.lblPromoCardText.TabIndex = 0;
            this.lblPromoCardText.Text = "Promo Card Text";
            // 
            // UC_Kiosk
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpRootKiosk);
            this.Name = "UC_Kiosk";
            this.Size = new System.Drawing.Size(932, 587);
            this.tlpRootKiosk.ResumeLayout(false);
            this.tlpHeaderKiosk.ResumeLayout(false);
            this.tlpHeaderKiosk.PerformLayout();
            this.pnlRunKiosk.ResumeLayout(false);
            this.pnlRunKiosk.PerformLayout();
            this.pnlKioskSettings.ResumeLayout(false);
            this.tlpKioskSettings.ResumeLayout(false);
            this.tlpKioskSettings.PerformLayout();
            this.pnlAutoReturn.ResumeLayout(false);
            this.pnlAutoReturn.PerformLayout();
            this.pnlSessionTimeout.ResumeLayout(false);
            this.pnlSessionTimeout.PerformLayout();
            this.pnlHeaderText.ResumeLayout(false);
            this.pnlHeaderText.PerformLayout();
            this.pnlPromoText.ResumeLayout(false);
            this.pnlPromoText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRunKiosk;
        private System.Windows.Forms.TableLayoutPanel tlpRootKiosk;
        private System.Windows.Forms.TableLayoutPanel tlpHeaderKiosk;
        private Guna.UI2.WinForms.Guna2Button btnSaveChanges;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHeaderText;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlRunKiosk;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlKioskSettings;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLaunchKioskMode;
        private System.Windows.Forms.TableLayoutPanel tlpKioskSettings;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKioskSettingsText;
        private Guna.UI2.WinForms.Guna2Panel pnlAutoReturn;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAutoReturnHome;
        private Guna.UI2.WinForms.Guna2Panel pnlSessionTimeout;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSessionTimeout;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPanelHeaderText;
        private Guna.UI2.WinForms.Guna2Panel pnlPromoText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPromoCardText;
    }
}
