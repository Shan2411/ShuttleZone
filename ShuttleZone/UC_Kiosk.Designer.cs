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
            this.pnlRunKiosk = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSaveChanges = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeaderText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlKioskSettings = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblLaunchKioskMode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tlpRootKiosk.SuspendLayout();
            this.tlpHeaderKiosk.SuspendLayout();
            this.pnlRunKiosk.SuspendLayout();
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
            this.btnRunKiosk.Location = new System.Drawing.Point(53, 72);
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
            this.tlpRootKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpRootKiosk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
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
            this.pnlRunKiosk.Size = new System.Drawing.Size(926, 152);
            this.pnlRunKiosk.TabIndex = 2;
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
            // pnlKioskSettings
            // 
            this.pnlKioskSettings.BorderRadius = 15;
            this.pnlKioskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskSettings.FillColor = System.Drawing.Color.White;
            this.pnlKioskSettings.FillColor2 = System.Drawing.Color.White;
            this.pnlKioskSettings.Location = new System.Drawing.Point(3, 221);
            this.pnlKioskSettings.Name = "pnlKioskSettings";
            this.pnlKioskSettings.Size = new System.Drawing.Size(926, 363);
            this.pnlKioskSettings.TabIndex = 3;
            // 
            // lblLaunchKioskMode
            // 
            this.lblLaunchKioskMode.BackColor = System.Drawing.Color.Transparent;
            this.lblLaunchKioskMode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaunchKioskMode.Location = new System.Drawing.Point(53, 25);
            this.lblLaunchKioskMode.Name = "lblLaunchKioskMode";
            this.lblLaunchKioskMode.Size = new System.Drawing.Size(145, 23);
            this.lblLaunchKioskMode.TabIndex = 1;
            this.lblLaunchKioskMode.Text = "Launch Kiosk Mode";
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
    }
}
