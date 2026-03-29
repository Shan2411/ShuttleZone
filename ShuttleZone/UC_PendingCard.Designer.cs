namespace ShuttleZone
{
    partial class UC_PendingCard
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
            this.pnlPendingPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnPaymentCleared = new Guna.UI2.WinForms.Guna2Button();
            this.lblPendingTotalAmount = new System.Windows.Forms.Label();
            this.lblPendingTotalText = new System.Windows.Forms.Label();
            this.lblPendingDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowPendingItemsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPendingItemRowTemplate = new Guna.UI2.WinForms.Guna2Panel();
            this.lblItemQty = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblPendingTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPendingStubNo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlPendingPayment.SuspendLayout();
            this.flowPendingItemsContainer.SuspendLayout();
            this.pnlPendingItemRowTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPendingPayment
            // 
            this.pnlPendingPayment.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPendingPayment.BorderRadius = 14;
            this.pnlPendingPayment.BorderThickness = 1;
            this.pnlPendingPayment.Controls.Add(this.btnRemove);
            this.pnlPendingPayment.Controls.Add(this.btnPaymentCleared);
            this.pnlPendingPayment.Controls.Add(this.lblPendingTotalAmount);
            this.pnlPendingPayment.Controls.Add(this.lblPendingTotalText);
            this.pnlPendingPayment.Controls.Add(this.lblPendingDate);
            this.pnlPendingPayment.Controls.Add(this.flowPendingItemsContainer);
            this.pnlPendingPayment.Controls.Add(this.lblPendingTime);
            this.pnlPendingPayment.Controls.Add(this.lblPendingStubNo);
            this.pnlPendingPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendingPayment.FillColor = System.Drawing.Color.White;
            this.pnlPendingPayment.Location = new System.Drawing.Point(0, 0);
            this.pnlPendingPayment.Name = "pnlPendingPayment";
            this.pnlPendingPayment.ShadowDecoration.Enabled = true;
            this.pnlPendingPayment.Size = new System.Drawing.Size(334, 336);
            this.pnlPendingPayment.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.BorderRadius = 10;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(237, 274);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(77, 46);
            this.btnRemove.TabIndex = 40;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnPaymentCleared
            // 
            this.btnPaymentCleared.BorderRadius = 10;
            this.btnPaymentCleared.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPaymentCleared.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPaymentCleared.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPaymentCleared.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPaymentCleared.FillColor = System.Drawing.Color.Green;
            this.btnPaymentCleared.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentCleared.ForeColor = System.Drawing.Color.White;
            this.btnPaymentCleared.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.btnPaymentCleared.Location = new System.Drawing.Point(20, 275);
            this.btnPaymentCleared.Name = "btnPaymentCleared";
            this.btnPaymentCleared.Size = new System.Drawing.Size(209, 45);
            this.btnPaymentCleared.TabIndex = 39;
            this.btnPaymentCleared.Text = "Payment Cleared";
            this.btnPaymentCleared.Click += new System.EventHandler(this.btnPaymentCleared_Click);
            // 
            // lblPendingTotalAmount
            // 
            this.lblPendingTotalAmount.AutoSize = true;
            this.lblPendingTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTotalAmount.Location = new System.Drawing.Point(255, 243);
            this.lblPendingTotalAmount.Name = "lblPendingTotalAmount";
            this.lblPendingTotalAmount.Size = new System.Drawing.Size(46, 20);
            this.lblPendingTotalAmount.TabIndex = 38;
            this.lblPendingTotalAmount.Text = "₱250";
            // 
            // lblPendingTotalText
            // 
            this.lblPendingTotalText.AutoSize = true;
            this.lblPendingTotalText.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTotalText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTotalText.Location = new System.Drawing.Point(33, 243);
            this.lblPendingTotalText.Name = "lblPendingTotalText";
            this.lblPendingTotalText.Size = new System.Drawing.Size(48, 20);
            this.lblPendingTotalText.TabIndex = 37;
            this.lblPendingTotalText.Text = "Total:";
            // 
            // lblPendingDate
            // 
            this.lblPendingDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingDate.Location = new System.Drawing.Point(179, 43);
            this.lblPendingDate.Name = "lblPendingDate";
            this.lblPendingDate.Size = new System.Drawing.Size(57, 15);
            this.lblPendingDate.TabIndex = 36;
            this.lblPendingDate.Text = "03-23-2026";
            // 
            // flowPendingItemsContainer
            // 
            this.flowPendingItemsContainer.AutoScroll = true;
            this.flowPendingItemsContainer.Controls.Add(this.pnlPendingItemRowTemplate);
            this.flowPendingItemsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPendingItemsContainer.Location = new System.Drawing.Point(12, 70);
            this.flowPendingItemsContainer.Name = "flowPendingItemsContainer";
            this.flowPendingItemsContainer.Padding = new System.Windows.Forms.Padding(4);
            this.flowPendingItemsContainer.Size = new System.Drawing.Size(310, 166);
            this.flowPendingItemsContainer.TabIndex = 35;
            this.flowPendingItemsContainer.WrapContents = false;
            // 
            // pnlPendingItemRowTemplate
            // 
            this.pnlPendingItemRowTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPendingItemRowTemplate.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPendingItemRowTemplate.BorderRadius = 8;
            this.pnlPendingItemRowTemplate.BorderThickness = 1;
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemQty);
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemPrice);
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemName);
            this.pnlPendingItemRowTemplate.Location = new System.Drawing.Point(3, 3);
            this.pnlPendingItemRowTemplate.Name = "pnlPendingItemRowTemplate";
            this.pnlPendingItemRowTemplate.Size = new System.Drawing.Size(304, 37);
            this.pnlPendingItemRowTemplate.TabIndex = 14;
            // 
            // lblItemQty
            // 
            this.lblItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemQty.AutoSize = true;
            this.lblItemQty.BackColor = System.Drawing.Color.Transparent;
            this.lblItemQty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemQty.Location = new System.Drawing.Point(13, 19);
            this.lblItemQty.Name = "lblItemQty";
            this.lblItemQty.Size = new System.Drawing.Size(76, 13);
            this.lblItemQty.TabIndex = 13;
            this.lblItemQty.Text = "₱250 x 1 hour";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(247, 4);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(35, 15);
            this.lblItemPrice.TabIndex = 12;
            this.lblItemPrice.Text = "₱250";
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(13, 4);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(47, 15);
            this.lblItemName.TabIndex = 11;
            this.lblItemName.Text = "Court A";
            // 
            // lblPendingTime
            // 
            this.lblPendingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTime.Location = new System.Drawing.Point(56, 44);
            this.lblPendingTime.Name = "lblPendingTime";
            this.lblPendingTime.Size = new System.Drawing.Size(49, 15);
            this.lblPendingTime.TabIndex = 1;
            this.lblPendingTime.Text = "08:00 PM";
            // 
            // lblPendingStubNo
            // 
            this.lblPendingStubNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingStubNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingStubNo.Location = new System.Drawing.Point(127, 15);
            this.lblPendingStubNo.Name = "lblPendingStubNo";
            this.lblPendingStubNo.Size = new System.Drawing.Size(77, 22);
            this.lblPendingStubNo.TabIndex = 0;
            this.lblPendingStubNo.Text = "STUB0001";
            // 
            // UC_PendingCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPendingPayment);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_PendingCard";
            this.Size = new System.Drawing.Size(334, 336);
            this.pnlPendingPayment.ResumeLayout(false);
            this.pnlPendingPayment.PerformLayout();
            this.flowPendingItemsContainer.ResumeLayout(false);
            this.pnlPendingItemRowTemplate.ResumeLayout(false);
            this.pnlPendingItemRowTemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlPendingPayment;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnPaymentCleared;
        private System.Windows.Forms.Label lblPendingTotalAmount;
        private System.Windows.Forms.Label lblPendingTotalText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPendingDate;
        private System.Windows.Forms.FlowLayoutPanel flowPendingItemsContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlPendingItemRowTemplate;
        private System.Windows.Forms.Label lblItemQty;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblItemName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPendingTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPendingStubNo;
    }
}
