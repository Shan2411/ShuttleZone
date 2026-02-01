namespace ShuttleZone
{
    partial class Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt));
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlItemsContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlItemRowTemplate = new Guna.UI2.WinForms.Guna2Panel();
            this.lblItemQty = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblFooterMessage2 = new System.Windows.Forms.Label();
            this.lblFooterMessage1 = new System.Windows.Forms.Label();
            this.lblTerm1 = new System.Windows.Forms.Label();
            this.lblTermsText = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblDueTime = new System.Windows.Forms.Label();
            this.lblDueTimeText = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeText = new System.Windows.Forms.Label();
            this.lblAmountReceived = new System.Windows.Forms.Label();
            this.lblAmountReceivedText = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPaymentMethodText = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.sepItems = new Guna.UI2.WinForms.Guna2Separator();
            this.lblItemsText = new System.Windows.Forms.Label();
            this.sepInfo = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTimeIssued = new System.Windows.Forms.Label();
            this.lblTimeText = new System.Windows.Forms.Label();
            this.lblDateIssued = new System.Windows.Forms.Label();
            this.lblDateText = new System.Windows.Forms.Label();
            this.sepHeader = new Guna.UI2.WinForms.Guna2Separator();
            this.lblSZInfo = new System.Windows.Forms.Label();
            this.lblSZ = new System.Windows.Forms.Label();
            this.lblReceiptNoTitle = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.pnlItemsContainer.SuspendLayout();
            this.pnlItemRowTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblReceiptNo);
            this.pnlContainer.Controls.Add(this.lblReceiptNoTitle);
            this.pnlContainer.Controls.Add(this.pnlItemsContainer);
            this.pnlContainer.Controls.Add(this.lblFooterMessage2);
            this.pnlContainer.Controls.Add(this.lblFooterMessage1);
            this.pnlContainer.Controls.Add(this.lblTerm1);
            this.pnlContainer.Controls.Add(this.lblTermsText);
            this.pnlContainer.Controls.Add(this.guna2Separator1);
            this.pnlContainer.Controls.Add(this.lblDueTime);
            this.pnlContainer.Controls.Add(this.lblDueTimeText);
            this.pnlContainer.Controls.Add(this.lblChange);
            this.pnlContainer.Controls.Add(this.lblChangeText);
            this.pnlContainer.Controls.Add(this.lblAmountReceived);
            this.pnlContainer.Controls.Add(this.lblAmountReceivedText);
            this.pnlContainer.Controls.Add(this.lblPaymentMethod);
            this.pnlContainer.Controls.Add(this.lblPaymentMethodText);
            this.pnlContainer.Controls.Add(this.lblTotalAmount);
            this.pnlContainer.Controls.Add(this.lblTotalText);
            this.pnlContainer.Controls.Add(this.sepItems);
            this.pnlContainer.Controls.Add(this.lblItemsText);
            this.pnlContainer.Controls.Add(this.sepInfo);
            this.pnlContainer.Controls.Add(this.lblTimeIssued);
            this.pnlContainer.Controls.Add(this.lblTimeText);
            this.pnlContainer.Controls.Add(this.lblDateIssued);
            this.pnlContainer.Controls.Add(this.lblDateText);
            this.pnlContainer.Controls.Add(this.sepHeader);
            this.pnlContainer.Controls.Add(this.lblSZInfo);
            this.pnlContainer.Controls.Add(this.lblSZ);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContainer.Size = new System.Drawing.Size(350, 788);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlItemsContainer
            // 
            this.pnlItemsContainer.AutoScroll = true;
            this.pnlItemsContainer.Controls.Add(this.pnlItemRowTemplate);
            this.pnlItemsContainer.Location = new System.Drawing.Point(23, 271);
            this.pnlItemsContainer.Name = "pnlItemsContainer";
            this.pnlItemsContainer.Size = new System.Drawing.Size(304, 166);
            this.pnlItemsContainer.TabIndex = 31;
            // 
            // pnlItemRowTemplate
            // 
            this.pnlItemRowTemplate.Controls.Add(this.lblItemQty);
            this.pnlItemRowTemplate.Controls.Add(this.lblItemPrice);
            this.pnlItemRowTemplate.Controls.Add(this.lblItemName);
            this.pnlItemRowTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItemRowTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnlItemRowTemplate.Name = "pnlItemRowTemplate";
            this.pnlItemRowTemplate.Size = new System.Drawing.Size(304, 37);
            this.pnlItemRowTemplate.TabIndex = 14;
            // 
            // lblItemQty
            // 
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
            this.lblItemPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(252, 4);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(35, 15);
            this.lblItemPrice.TabIndex = 12;
            this.lblItemPrice.Text = "₱250";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(13, 4);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(47, 15);
            this.lblItemName.TabIndex = 11;
            this.lblItemName.Text = "Court A";
            // 
            // lblFooterMessage2
            // 
            this.lblFooterMessage2.AutoSize = true;
            this.lblFooterMessage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterMessage2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFooterMessage2.Location = new System.Drawing.Point(121, 743);
            this.lblFooterMessage2.Name = "lblFooterMessage2";
            this.lblFooterMessage2.Size = new System.Drawing.Size(117, 17);
            this.lblFooterMessage2.TabIndex = 30;
            this.lblFooterMessage2.Text = "Please come again";
            this.lblFooterMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFooterMessage1
            // 
            this.lblFooterMessage1.AutoSize = true;
            this.lblFooterMessage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterMessage1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFooterMessage1.Location = new System.Drawing.Point(64, 717);
            this.lblFooterMessage1.Name = "lblFooterMessage1";
            this.lblFooterMessage1.Size = new System.Drawing.Size(229, 21);
            this.lblFooterMessage1.TabIndex = 29;
            this.lblFooterMessage1.Text = "Thank you for your business!";
            this.lblFooterMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTerm1
            // 
            this.lblTerm1.AutoSize = true;
            this.lblTerm1.BackColor = System.Drawing.Color.Transparent;
            this.lblTerm1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm1.Location = new System.Drawing.Point(39, 629);
            this.lblTerm1.Name = "lblTerm1";
            this.lblTerm1.Size = new System.Drawing.Size(280, 65);
            this.lblTerm1.TabIndex = 28;
            this.lblTerm1.Text = resources.GetString("lblTerm1.Text");
            // 
            // lblTermsText
            // 
            this.lblTermsText.AutoSize = true;
            this.lblTermsText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTermsText.Location = new System.Drawing.Point(39, 609);
            this.lblTermsText.Name = "lblTermsText";
            this.lblTermsText.Size = new System.Drawing.Size(152, 15);
            this.lblTermsText.TabIndex = 27;
            this.lblTermsText.Text = "TERMS AND CONDITIONS";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(42, 588);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(265, 10);
            this.guna2Separator1.TabIndex = 26;
            // 
            // lblDueTime
            // 
            this.lblDueTime.AutoSize = true;
            this.lblDueTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTime.Location = new System.Drawing.Point(242, 559);
            this.lblDueTime.Name = "lblDueTime";
            this.lblDueTime.Size = new System.Drawing.Size(64, 15);
            this.lblDueTime.TabIndex = 25;
            this.lblDueTime.Text = "9:05:27 PM";
            // 
            // lblDueTimeText
            // 
            this.lblDueTimeText.AutoSize = true;
            this.lblDueTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTimeText.Location = new System.Drawing.Point(40, 559);
            this.lblDueTimeText.Name = "lblDueTimeText";
            this.lblDueTimeText.Size = new System.Drawing.Size(96, 15);
            this.lblDueTimeText.TabIndex = 23;
            this.lblDueTimeText.Text = "Rental Due Time:";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(275, 539);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(32, 15);
            this.lblChange.TabIndex = 22;
            this.lblChange.Text = "₱250";
            // 
            // lblChangeText
            // 
            this.lblChangeText.AutoSize = true;
            this.lblChangeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeText.Location = new System.Drawing.Point(40, 539);
            this.lblChangeText.Name = "lblChangeText";
            this.lblChangeText.Size = new System.Drawing.Size(51, 15);
            this.lblChangeText.TabIndex = 21;
            this.lblChangeText.Text = "Change:";
            // 
            // lblAmountReceived
            // 
            this.lblAmountReceived.AutoSize = true;
            this.lblAmountReceived.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReceived.Location = new System.Drawing.Point(275, 519);
            this.lblAmountReceived.Name = "lblAmountReceived";
            this.lblAmountReceived.Size = new System.Drawing.Size(32, 15);
            this.lblAmountReceived.TabIndex = 20;
            this.lblAmountReceived.Text = "₱500";
            // 
            // lblAmountReceivedText
            // 
            this.lblAmountReceivedText.AutoSize = true;
            this.lblAmountReceivedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReceivedText.Location = new System.Drawing.Point(40, 519);
            this.lblAmountReceivedText.Name = "lblAmountReceivedText";
            this.lblAmountReceivedText.Size = new System.Drawing.Size(104, 15);
            this.lblAmountReceivedText.TabIndex = 19;
            this.lblAmountReceivedText.Text = "Amount Received:";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(262, 499);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(44, 15);
            this.lblPaymentMethod.TabIndex = 18;
            this.lblPaymentMethod.Text = "E-Cash";
            // 
            // lblPaymentMethodText
            // 
            this.lblPaymentMethodText.AutoSize = true;
            this.lblPaymentMethodText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodText.Location = new System.Drawing.Point(40, 499);
            this.lblPaymentMethodText.Name = "lblPaymentMethodText";
            this.lblPaymentMethodText.Size = new System.Drawing.Size(102, 15);
            this.lblPaymentMethodText.TabIndex = 17;
            this.lblPaymentMethodText.Text = "Payment Method:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(261, 470);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(46, 20);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "₱250";
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(39, 470);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(48, 20);
            this.lblTotalText.TabIndex = 15;
            this.lblTotalText.Text = "Total:";
            // 
            // sepItems
            // 
            this.sepItems.Location = new System.Drawing.Point(42, 443);
            this.sepItems.Name = "sepItems";
            this.sepItems.Size = new System.Drawing.Size(265, 10);
            this.sepItems.TabIndex = 14;
            // 
            // lblItemsText
            // 
            this.lblItemsText.AutoSize = true;
            this.lblItemsText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsText.Location = new System.Drawing.Point(39, 248);
            this.lblItemsText.Name = "lblItemsText";
            this.lblItemsText.Size = new System.Drawing.Size(46, 17);
            this.lblItemsText.TabIndex = 10;
            this.lblItemsText.Text = "Items:";
            // 
            // sepInfo
            // 
            this.sepInfo.Location = new System.Drawing.Point(42, 228);
            this.sepInfo.Name = "sepInfo";
            this.sepInfo.Size = new System.Drawing.Size(265, 10);
            this.sepInfo.TabIndex = 9;
            // 
            // lblTimeIssued
            // 
            this.lblTimeIssued.AutoSize = true;
            this.lblTimeIssued.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeIssued.Location = new System.Drawing.Point(243, 201);
            this.lblTimeIssued.Name = "lblTimeIssued";
            this.lblTimeIssued.Size = new System.Drawing.Size(64, 15);
            this.lblTimeIssued.TabIndex = 8;
            this.lblTimeIssued.Text = "8:05:27 PM";
            // 
            // lblTimeText
            // 
            this.lblTimeText.AutoSize = true;
            this.lblTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeText.Location = new System.Drawing.Point(42, 201);
            this.lblTimeText.Name = "lblTimeText";
            this.lblTimeText.Size = new System.Drawing.Size(72, 15);
            this.lblTimeText.TabIndex = 7;
            this.lblTimeText.Text = "Time Issued:";
            // 
            // lblDateIssued
            // 
            this.lblDateIssued.AutoSize = true;
            this.lblDateIssued.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateIssued.Location = new System.Drawing.Point(242, 177);
            this.lblDateIssued.Name = "lblDateIssued";
            this.lblDateIssued.Size = new System.Drawing.Size(65, 15);
            this.lblDateIssued.TabIndex = 6;
            this.lblDateIssued.Text = "Feb 1, 2026";
            // 
            // lblDateText
            // 
            this.lblDateText.AutoSize = true;
            this.lblDateText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateText.Location = new System.Drawing.Point(42, 177);
            this.lblDateText.Name = "lblDateText";
            this.lblDateText.Size = new System.Drawing.Size(70, 15);
            this.lblDateText.TabIndex = 5;
            this.lblDateText.Text = "Date Issued:";
            // 
            // sepHeader
            // 
            this.sepHeader.Location = new System.Drawing.Point(42, 124);
            this.sepHeader.Name = "sepHeader";
            this.sepHeader.Size = new System.Drawing.Size(265, 10);
            this.sepHeader.TabIndex = 2;
            // 
            // lblSZInfo
            // 
            this.lblSZInfo.AutoSize = true;
            this.lblSZInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSZInfo.Location = new System.Drawing.Point(93, 52);
            this.lblSZInfo.Name = "lblSZInfo";
            this.lblSZInfo.Size = new System.Drawing.Size(172, 68);
            this.lblSZInfo.TabIndex = 1;
            this.lblSZInfo.Text = "Badminton Facility\r\n\r\n123 Sports Complex, Manila\r\nTel: (02) 1234-5678";
            this.lblSZInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSZ
            // 
            this.lblSZ.AutoSize = true;
            this.lblSZ.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSZ.Location = new System.Drawing.Point(109, 24);
            this.lblSZ.Name = "lblSZ";
            this.lblSZ.Size = new System.Drawing.Size(133, 28);
            this.lblSZ.TabIndex = 0;
            this.lblSZ.Text = "Shuttle Zone";
            this.lblSZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptNoTitle
            // 
            this.lblReceiptNoTitle.AutoSize = true;
            this.lblReceiptNoTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNoTitle.Location = new System.Drawing.Point(42, 152);
            this.lblReceiptNoTitle.Name = "lblReceiptNoTitle";
            this.lblReceiptNoTitle.Size = new System.Drawing.Size(68, 15);
            this.lblReceiptNoTitle.TabIndex = 32;
            this.lblReceiptNoTitle.Text = "Receipt No:";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNo.Location = new System.Drawing.Point(262, 152);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(45, 15);
            this.lblReceiptNo.TabIndex = 33;
            this.lblReceiptNo.Text = "R#0001";
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 788);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receipt";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlItemsContainer.ResumeLayout(false);
            this.pnlItemRowTemplate.ResumeLayout(false);
            this.pnlItemRowTemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private System.Windows.Forms.Label lblSZ;
        private System.Windows.Forms.Label lblSZInfo;
        private Guna.UI2.WinForms.Guna2Separator sepHeader;
        private System.Windows.Forms.Label lblDateText;
        private System.Windows.Forms.Label lblReceiptNoText;
        private System.Windows.Forms.Label lblDateIssued;
        private System.Windows.Forms.Label lblTimeIssued;
        private System.Windows.Forms.Label lblTimeText;
        private System.Windows.Forms.Label lblItemsText;
        private Guna.UI2.WinForms.Guna2Separator sepInfo;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private Guna.UI2.WinForms.Guna2Separator sepItems;
        private System.Windows.Forms.Label lblItemQty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblChangeText;
        private System.Windows.Forms.Label lblAmountReceived;
        private System.Windows.Forms.Label lblAmountReceivedText;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethodText;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblDueTime;
        private System.Windows.Forms.Label lblDueTimeText;
        private System.Windows.Forms.Label lblTermsText;
        private System.Windows.Forms.Label lblTerm1;
        private System.Windows.Forms.Label lblFooterMessage2;
        private System.Windows.Forms.Label lblFooterMessage1;
        private Guna.UI2.WinForms.Guna2Panel pnlItemsContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlItemRowTemplate;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Label lblReceiptNoTitle;
    }
}