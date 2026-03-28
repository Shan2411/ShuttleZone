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
            this.pnlPendingPayment.BorderRadius = 10;
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
            this.pnlPendingPayment.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPendingPayment.Name = "pnlPendingPayment";
            this.pnlPendingPayment.Size = new System.Drawing.Size(446, 413);
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
            this.btnRemove.Location = new System.Drawing.Point(316, 337);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(103, 57);
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
            this.btnPaymentCleared.Location = new System.Drawing.Point(27, 338);
            this.btnPaymentCleared.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaymentCleared.Name = "btnPaymentCleared";
            this.btnPaymentCleared.Size = new System.Drawing.Size(279, 55);
            this.btnPaymentCleared.TabIndex = 39;
            this.btnPaymentCleared.Text = "Payment Cleared";
            this.btnPaymentCleared.Click += new System.EventHandler(this.btnPaymentCleared_Click);
            // 
            // lblPendingTotalAmount
            // 
            this.lblPendingTotalAmount.AutoSize = true;
            this.lblPendingTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTotalAmount.Location = new System.Drawing.Point(340, 299);
            this.lblPendingTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPendingTotalAmount.Name = "lblPendingTotalAmount";
            this.lblPendingTotalAmount.Size = new System.Drawing.Size(57, 25);
            this.lblPendingTotalAmount.TabIndex = 38;
            this.lblPendingTotalAmount.Text = "₱250";
            // 
            // lblPendingTotalText
            // 
            this.lblPendingTotalText.AutoSize = true;
            this.lblPendingTotalText.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTotalText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTotalText.Location = new System.Drawing.Point(44, 299);
            this.lblPendingTotalText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPendingTotalText.Name = "lblPendingTotalText";
            this.lblPendingTotalText.Size = new System.Drawing.Size(60, 25);
            this.lblPendingTotalText.TabIndex = 37;
            this.lblPendingTotalText.Text = "Total:";
            // 
            // lblPendingDate
            // 
            this.lblPendingDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingDate.Location = new System.Drawing.Point(239, 53);
            this.lblPendingDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblPendingDate.Name = "lblPendingDate";
            this.lblPendingDate.Size = new System.Drawing.Size(67, 18);
            this.lblPendingDate.TabIndex = 36;
            this.lblPendingDate.Text = "03-23-2026";
            // 
            // flowPendingItemsContainer
            // 
            this.flowPendingItemsContainer.Controls.Add(this.pnlPendingItemRowTemplate);
            this.flowPendingItemsContainer.Location = new System.Drawing.Point(16, 86);
            this.flowPendingItemsContainer.Margin = new System.Windows.Forms.Padding(4);
            this.flowPendingItemsContainer.Name = "flowPendingItemsContainer";
            this.flowPendingItemsContainer.Size = new System.Drawing.Size(413, 204);
            this.flowPendingItemsContainer.TabIndex = 35;
            // 
            // pnlPendingItemRowTemplate
            // 
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemQty);
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemPrice);
            this.pnlPendingItemRowTemplate.Controls.Add(this.lblItemName);
            this.pnlPendingItemRowTemplate.Location = new System.Drawing.Point(4, 4);
            this.pnlPendingItemRowTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPendingItemRowTemplate.Name = "pnlPendingItemRowTemplate";
            this.pnlPendingItemRowTemplate.Size = new System.Drawing.Size(405, 46);
            this.pnlPendingItemRowTemplate.TabIndex = 14;
            // 
            // lblItemQty
            // 
            this.lblItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemQty.AutoSize = true;
            this.lblItemQty.BackColor = System.Drawing.Color.Transparent;
            this.lblItemQty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemQty.Location = new System.Drawing.Point(17, 23);
            this.lblItemQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemQty.Name = "lblItemQty";
            this.lblItemQty.Size = new System.Drawing.Size(96, 19);
            this.lblItemQty.TabIndex = 13;
            this.lblItemQty.Text = "₱250 x 1 hour";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(329, 5);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(42, 20);
            this.lblItemPrice.TabIndex = 12;
            this.lblItemPrice.Text = "₱250";
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(17, 5);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 20);
            this.lblItemName.TabIndex = 11;
            this.lblItemName.Text = "Court A";
            // 
            // lblPendingTime
            // 
            this.lblPendingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTime.Location = new System.Drawing.Point(75, 54);
            this.lblPendingTime.Margin = new System.Windows.Forms.Padding(4);
            this.lblPendingTime.Name = "lblPendingTime";
            this.lblPendingTime.Size = new System.Drawing.Size(57, 18);
            this.lblPendingTime.TabIndex = 1;
            this.lblPendingTime.Text = "08:00 PM";
            // 
            // lblPendingStubNo
            // 
            this.lblPendingStubNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingStubNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingStubNo.Location = new System.Drawing.Point(169, 18);
            this.lblPendingStubNo.Margin = new System.Windows.Forms.Padding(4);
            this.lblPendingStubNo.Name = "lblPendingStubNo";
            this.lblPendingStubNo.Size = new System.Drawing.Size(95, 27);
            this.lblPendingStubNo.TabIndex = 0;
            this.lblPendingStubNo.Text = "STUB0001";
            // 
            // UC_PendingCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPendingPayment);
            this.Name = "UC_PendingCard";
            this.Size = new System.Drawing.Size(446, 413);
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
