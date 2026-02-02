namespace ShuttleZone.Membership
{
    partial class MemberRowControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberRowControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MembershipExpiryDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MembershipType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MemberContactNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MemberEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MemberName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DeleteBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.EditBtn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.MemberID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.MembershipExpiryDate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.MembershipType, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.MemberContactNumber, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.MemberEmail, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MemberName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeleteBtn, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.EditBtn, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.MemberID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2HtmlLabel1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(910, 48);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MembershipExpiryDate
            // 
            this.MembershipExpiryDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MembershipExpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.MembershipExpiryDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipExpiryDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MembershipExpiryDate.Location = new System.Drawing.Point(745, 15);
            this.MembershipExpiryDate.Name = "MembershipExpiryDate";
            this.MembershipExpiryDate.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MembershipExpiryDate.Size = new System.Drawing.Size(75, 18);
            this.MembershipExpiryDate.TabIndex = 16;
            this.MembershipExpiryDate.Text = "2025-01-15";
            // 
            // MembershipType
            // 
            this.MembershipType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MembershipType.BackColor = System.Drawing.Color.Transparent;
            this.MembershipType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipType.Location = new System.Drawing.Point(531, 15);
            this.MembershipType.Name = "MembershipType";
            this.MembershipType.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MembershipType.Size = new System.Drawing.Size(117, 18);
            this.MembershipType.TabIndex = 14;
            this.MembershipType.Text = "12 Months(P4,500)";
            // 
            // MemberContactNumber
            // 
            this.MemberContactNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberContactNumber.BackColor = System.Drawing.Color.Transparent;
            this.MemberContactNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberContactNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MemberContactNumber.Location = new System.Drawing.Point(408, 15);
            this.MemberContactNumber.Name = "MemberContactNumber";
            this.MemberContactNumber.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MemberContactNumber.Size = new System.Drawing.Size(86, 18);
            this.MemberContactNumber.TabIndex = 13;
            this.MemberContactNumber.Text = "09123456789";
            // 
            // MemberEmail
            // 
            this.MemberEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberEmail.BackColor = System.Drawing.Color.Transparent;
            this.MemberEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MemberEmail.Location = new System.Drawing.Point(223, 15);
            this.MemberEmail.Name = "MemberEmail";
            this.MemberEmail.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MemberEmail.Size = new System.Drawing.Size(105, 18);
            this.MemberEmail.TabIndex = 12;
            this.MemberEmail.Text = "john@gmail.com";
            // 
            // MemberName
            // 
            this.MemberName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberName.BackColor = System.Drawing.Color.Transparent;
            this.MemberName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberName.Location = new System.Drawing.Point(47, 15);
            this.MemberName.Name = "MemberName";
            this.MemberName.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MemberName.Size = new System.Drawing.Size(61, 18);
            this.MemberName.TabIndex = 11;
            this.MemberName.Text = "John Doe";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.BackgroundImage")));
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBtn.FillColor = System.Drawing.Color.Transparent;
            this.DeleteBtn.ImageRotate = 0F;
            this.DeleteBtn.Location = new System.Drawing.Point(882, 14);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(20, 20);
            this.DeleteBtn.TabIndex = 9;
            this.DeleteBtn.TabStop = false;
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBtn.BackgroundImage")));
            this.EditBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditBtn.FillColor = System.Drawing.Color.Transparent;
            this.EditBtn.ImageRotate = 0F;
            this.EditBtn.Location = new System.Drawing.Point(846, 14);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(20, 20);
            this.EditBtn.TabIndex = 8;
            this.EditBtn.TabStop = false;
            // 
            // MemberID
            // 
            this.MemberID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberID.BackColor = System.Drawing.Color.Transparent;
            this.MemberID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberID.Location = new System.Drawing.Point(3, 15);
            this.MemberID.Name = "MemberID";
            this.MemberID.Size = new System.Drawing.Size(38, 18);
            this.MemberID.TabIndex = 10;
            this.MemberID.Text = "M001";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.PaleGreen;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.ForestGreen;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(681, 15);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(43, 18);
            this.guna2HtmlLabel1.TabIndex = 17;
            this.guna2HtmlLabel1.Text = "Active";
            // 
            // MemberRowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MemberRowControl";
            this.Size = new System.Drawing.Size(910, 48);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox EditBtn;
        private Guna.UI2.WinForms.Guna2PictureBox DeleteBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel MembershipExpiryDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel MembershipType;
        private Guna.UI2.WinForms.Guna2HtmlLabel MemberContactNumber;
        private Guna.UI2.WinForms.Guna2HtmlLabel MemberEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel MemberName;
        private Guna.UI2.WinForms.Guna2HtmlLabel MemberID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
