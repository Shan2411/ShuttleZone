namespace ShuttleZone
{
    partial class Kiosk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kiosk));
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSidebar = new System.Windows.Forms.TableLayoutPanel();
            this.btnCourtRental = new Guna.UI2.WinForms.Guna2Button();
            this.btnEquipment = new Guna.UI2.WinForms.Guna2Button();
            this.btnMembership = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpRoot.SuspendLayout();
            this.tlpSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 2;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.tlpSidebar, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlMainContent, 1, 0);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 1;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(464, 749);
            this.tlpRoot.TabIndex = 0;
            // 
            // tlpSidebar
            // 
            this.tlpSidebar.ColumnCount = 1;
            this.tlpSidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.Controls.Add(this.btnCourtRental, 0, 1);
            this.tlpSidebar.Controls.Add(this.btnEquipment, 0, 2);
            this.tlpSidebar.Controls.Add(this.btnMembership, 0, 3);
            this.tlpSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSidebar.Location = new System.Drawing.Point(3, 3);
            this.tlpSidebar.Name = "tlpSidebar";
            this.tlpSidebar.RowCount = 5;
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSidebar.Size = new System.Drawing.Size(69, 743);
            this.tlpSidebar.TabIndex = 0;
            // 
            // btnCourtRental
            // 
            this.btnCourtRental.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCourtRental.AutoRoundedCorners = true;
            this.btnCourtRental.BorderRadius = 26;
            this.btnCourtRental.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCourtRental.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCourtRental.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCourtRental.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCourtRental.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnCourtRental.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCourtRental.ForeColor = System.Drawing.Color.White;
            this.btnCourtRental.Image = ((System.Drawing.Image)(resources.GetObject("btnCourtRental.Image")));
            this.btnCourtRental.ImageSize = new System.Drawing.Size(63, 54);
            this.btnCourtRental.Location = new System.Drawing.Point(3, 23);
            this.btnCourtRental.Name = "btnCourtRental";
            this.btnCourtRental.Size = new System.Drawing.Size(63, 54);
            this.btnCourtRental.TabIndex = 0;
            // 
            // btnEquipment
            // 
            this.btnEquipment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEquipment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEquipment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEquipment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEquipment.FillColor = System.Drawing.Color.Transparent;
            this.btnEquipment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEquipment.ForeColor = System.Drawing.Color.White;
            this.btnEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipment.Image")));
            this.btnEquipment.ImageSize = new System.Drawing.Size(63, 54);
            this.btnEquipment.Location = new System.Drawing.Point(3, 83);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(63, 54);
            this.btnEquipment.TabIndex = 1;
            // 
            // btnMembership
            // 
            this.btnMembership.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMembership.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMembership.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMembership.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMembership.FillColor = System.Drawing.Color.Transparent;
            this.btnMembership.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMembership.ForeColor = System.Drawing.Color.White;
            this.btnMembership.Image = ((System.Drawing.Image)(resources.GetObject("btnMembership.Image")));
            this.btnMembership.ImageSize = new System.Drawing.Size(63, 54);
            this.btnMembership.Location = new System.Drawing.Point(3, 143);
            this.btnMembership.Name = "btnMembership";
            this.btnMembership.Size = new System.Drawing.Size(63, 54);
            this.btnMembership.TabIndex = 2;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(78, 3);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(383, 743);
            this.pnlMainContent.TabIndex = 1;
            // 
            // Kiosk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 749);
            this.ControlBox = false;
            this.Controls.Add(this.tlpRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kiosk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiosk";
            this.TopMost = true;
            this.tlpRoot.ResumeLayout(false);
            this.tlpSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.TableLayoutPanel tlpSidebar;
        private Guna.UI2.WinForms.Guna2Button btnEquipment;
        private Guna.UI2.WinForms.Guna2Button btnMembership;
        private Guna.UI2.WinForms.Guna2Button btnCourtRental;
        private Guna.UI2.WinForms.Guna2Panel pnlMainContent;
    }
}