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
            this.lblSZ = new System.Windows.Forms.Label();
            this.lblSZInfo = new System.Windows.Forms.Label();
            this.sepHeader = new Guna.UI2.WinForms.Guna2Separator();
            this.lblReceiptNoText = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.lblDateText = new System.Windows.Forms.Label();
            this.lblDateIssued = new System.Windows.Forms.Label();
            this.lblTimeText = new System.Windows.Forms.Label();
            this.lblTimeIssued = new System.Windows.Forms.Label();
            this.sepInfo = new Guna.UI2.WinForms.Guna2Separator();
            this.lblItemsText = new System.Windows.Forms.Label();
            this.lblItem1Name = new System.Windows.Forms.Label();
            this.lblItem1Price = new System.Windows.Forms.Label();
            this.lblItem1Qty = new System.Windows.Forms.Label();
            this.sepItems = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPaymentMethodText = new System.Windows.Forms.Label();
            this.lblAmountReceived = new System.Windows.Forms.Label();
            this.lblAmountReceivedText = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDueTimeText = new System.Windows.Forms.Label();
            this.lblDueTime = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTermsText = new System.Windows.Forms.Label();
            this.lblTerm1 = new System.Windows.Forms.Label();
            this.lblFooterMessage1 = new System.Windows.Forms.Label();
            this.lblFooterMessage2 = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.lblFooterMessage2);
            this.pnlContainer.Controls.Add(this.lblFooterMessage1);
            this.pnlContainer.Controls.Add(this.lblTerm1);
            this.pnlContainer.Controls.Add(this.lblTermsText);
            this.pnlContainer.Controls.Add(this.guna2Separator1);
            this.pnlContainer.Controls.Add(this.lblDueTime);
            this.pnlContainer.Controls.Add(this.label1);
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
            this.pnlContainer.Controls.Add(this.lblItem1Qty);
            this.pnlContainer.Controls.Add(this.lblItem1Price);
            this.pnlContainer.Controls.Add(this.lblItem1Name);
            this.pnlContainer.Controls.Add(this.lblItemsText);
            this.pnlContainer.Controls.Add(this.sepInfo);
            this.pnlContainer.Controls.Add(this.lblTimeIssued);
            this.pnlContainer.Controls.Add(this.lblTimeText);
            this.pnlContainer.Controls.Add(this.lblDateIssued);
            this.pnlContainer.Controls.Add(this.lblDateText);
            this.pnlContainer.Controls.Add(this.lblReceiptNo);
            this.pnlContainer.Controls.Add(this.lblReceiptNoText);
            this.pnlContainer.Controls.Add(this.sepHeader);
            this.pnlContainer.Controls.Add(this.lblSZInfo);
            this.pnlContainer.Controls.Add(this.lblSZ);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContainer.Size = new System.Drawing.Size(350, 700);
            this.pnlContainer.TabIndex = 0;
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
            // sepHeader
            // 
            this.sepHeader.Location = new System.Drawing.Point(42, 124);
            this.sepHeader.Name = "sepHeader";
            this.sepHeader.Size = new System.Drawing.Size(265, 10);
            this.sepHeader.TabIndex = 2;
            // 
            // lblReceiptNoText
            // 
            this.lblReceiptNoText.AutoSize = true;
            this.lblReceiptNoText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNoText.Location = new System.Drawing.Point(42, 154);
            this.lblReceiptNoText.Name = "lblReceiptNoText";
            this.lblReceiptNoText.Size = new System.Drawing.Size(68, 15);
            this.lblReceiptNoText.TabIndex = 3;
            this.lblReceiptNoText.Text = "Receipt No:";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNo.Location = new System.Drawing.Point(262, 154);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(45, 15);
            this.lblReceiptNo.TabIndex = 4;
            this.lblReceiptNo.Text = "R#0001";
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
            // sepInfo
            // 
            this.sepInfo.Location = new System.Drawing.Point(42, 228);
            this.sepInfo.Name = "sepInfo";
            this.sepInfo.Size = new System.Drawing.Size(265, 10);
            this.sepInfo.TabIndex = 9;
            // 
            // lblItemsText
            // 
            this.lblItemsText.AutoSize = true;
            this.lblItemsText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsText.Location = new System.Drawing.Point(39, 253);
            this.lblItemsText.Name = "lblItemsText";
            this.lblItemsText.Size = new System.Drawing.Size(46, 17);
            this.lblItemsText.TabIndex = 10;
            this.lblItemsText.Text = "Items:";
            // 
            // lblItem1Name
            // 
            this.lblItem1Name.AutoSize = true;
            this.lblItem1Name.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem1Name.Location = new System.Drawing.Point(39, 281);
            this.lblItem1Name.Name = "lblItem1Name";
            this.lblItem1Name.Size = new System.Drawing.Size(47, 15);
            this.lblItem1Name.TabIndex = 11;
            this.lblItem1Name.Text = "Court A";
            // 
            // lblItem1Price
            // 
            this.lblItem1Price.AutoSize = true;
            this.lblItem1Price.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem1Price.Location = new System.Drawing.Point(272, 281);
            this.lblItem1Price.Name = "lblItem1Price";
            this.lblItem1Price.Size = new System.Drawing.Size(35, 15);
            this.lblItem1Price.TabIndex = 12;
            this.lblItem1Price.Text = "₱250";
            // 
            // lblItem1Qty
            // 
            this.lblItem1Qty.AutoSize = true;
            this.lblItem1Qty.BackColor = System.Drawing.Color.Transparent;
            this.lblItem1Qty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem1Qty.Location = new System.Drawing.Point(39, 296);
            this.lblItem1Qty.Name = "lblItem1Qty";
            this.lblItem1Qty.Size = new System.Drawing.Size(76, 13);
            this.lblItem1Qty.TabIndex = 13;
            this.lblItem1Qty.Text = "₱250 x 1 hour";
            // 
            // sepItems
            // 
            this.sepItems.Location = new System.Drawing.Point(42, 324);
            this.sepItems.Name = "sepItems";
            this.sepItems.Size = new System.Drawing.Size(265, 10);
            this.sepItems.TabIndex = 14;
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(39, 351);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(48, 20);
            this.lblTotalText.TabIndex = 15;
            this.lblTotalText.Text = "Total:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(261, 351);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(46, 20);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "₱250";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(262, 380);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(44, 15);
            this.lblPaymentMethod.TabIndex = 18;
            this.lblPaymentMethod.Text = "E-Cash";
            // 
            // lblPaymentMethodText
            // 
            this.lblPaymentMethodText.AutoSize = true;
            this.lblPaymentMethodText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodText.Location = new System.Drawing.Point(40, 380);
            this.lblPaymentMethodText.Name = "lblPaymentMethodText";
            this.lblPaymentMethodText.Size = new System.Drawing.Size(102, 15);
            this.lblPaymentMethodText.TabIndex = 17;
            this.lblPaymentMethodText.Text = "Payment Method:";
            // 
            // lblAmountReceived
            // 
            this.lblAmountReceived.AutoSize = true;
            this.lblAmountReceived.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReceived.Location = new System.Drawing.Point(275, 400);
            this.lblAmountReceived.Name = "lblAmountReceived";
            this.lblAmountReceived.Size = new System.Drawing.Size(32, 15);
            this.lblAmountReceived.TabIndex = 20;
            this.lblAmountReceived.Text = "₱500";
            // 
            // lblAmountReceivedText
            // 
            this.lblAmountReceivedText.AutoSize = true;
            this.lblAmountReceivedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountReceivedText.Location = new System.Drawing.Point(40, 400);
            this.lblAmountReceivedText.Name = "lblAmountReceivedText";
            this.lblAmountReceivedText.Size = new System.Drawing.Size(104, 15);
            this.lblAmountReceivedText.TabIndex = 19;
            this.lblAmountReceivedText.Text = "Amount Received:";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(275, 420);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(32, 15);
            this.lblChange.TabIndex = 22;
            this.lblChange.Text = "₱250";
            // 
            // lblChangeText
            // 
            this.lblChangeText.AutoSize = true;
            this.lblChangeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeText.Location = new System.Drawing.Point(40, 420);
            this.lblChangeText.Name = "lblChangeText";
            this.lblChangeText.Size = new System.Drawing.Size(51, 15);
            this.lblChangeText.TabIndex = 21;
            this.lblChangeText.Text = "Change:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 24;
            // 
            // lblDueTimeText
            // 
            this.lblDueTimeText.AutoSize = true;
            this.lblDueTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTimeText.Location = new System.Drawing.Point(40, 440);
            this.lblDueTimeText.Name = "lblDueTimeText";
            this.lblDueTimeText.Size = new System.Drawing.Size(96, 15);
            this.lblDueTimeText.TabIndex = 23;
            this.lblDueTimeText.Text = "Rental Due Time:";
            // 
            // lblDueTime
            // 
            this.lblDueTime.AutoSize = true;
            this.lblDueTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTime.Location = new System.Drawing.Point(242, 440);
            this.lblDueTime.Name = "lblDueTime";
            this.lblDueTime.Size = new System.Drawing.Size(64, 15);
            this.lblDueTime.TabIndex = 25;
            this.lblDueTime.Text = "9:05:27 PM";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(42, 469);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(265, 10);
            this.guna2Separator1.TabIndex = 26;
            // 
            // lblTermsText
            // 
            this.lblTermsText.AutoSize = true;
            this.lblTermsText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTermsText.Location = new System.Drawing.Point(39, 490);
            this.lblTermsText.Name = "lblTermsText";
            this.lblTermsText.Size = new System.Drawing.Size(152, 15);
            this.lblTermsText.TabIndex = 27;
            this.lblTermsText.Text = "TERMS AND CONDITIONS";
            // 
            // lblTerm1
            // 
            this.lblTerm1.AutoSize = true;
            this.lblTerm1.BackColor = System.Drawing.Color.Transparent;
            this.lblTerm1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm1.Location = new System.Drawing.Point(39, 510);
            this.lblTerm1.Name = "lblTerm1";
            this.lblTerm1.Size = new System.Drawing.Size(280, 65);
            this.lblTerm1.TabIndex = 28;
            this.lblTerm1.Text = resources.GetString("lblTerm1.Text");
            // 
            // lblFooterMessage1
            // 
            this.lblFooterMessage1.AutoSize = true;
            this.lblFooterMessage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterMessage1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFooterMessage1.Location = new System.Drawing.Point(64, 602);
            this.lblFooterMessage1.Name = "lblFooterMessage1";
            this.lblFooterMessage1.Size = new System.Drawing.Size(229, 21);
            this.lblFooterMessage1.TabIndex = 29;
            this.lblFooterMessage1.Text = "Thank you for your business!";
            this.lblFooterMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFooterMessage2
            // 
            this.lblFooterMessage2.AutoSize = true;
            this.lblFooterMessage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterMessage2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblFooterMessage2.Location = new System.Drawing.Point(121, 633);
            this.lblFooterMessage2.Name = "lblFooterMessage2";
            this.lblFooterMessage2.Size = new System.Drawing.Size(117, 17);
            this.lblFooterMessage2.TabIndex = 30;
            this.lblFooterMessage2.Text = "Please come again";
            this.lblFooterMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 700);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receipt";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
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
        private System.Windows.Forms.Label lblItem1Name;
        private System.Windows.Forms.Label lblItem1Price;
        private Guna.UI2.WinForms.Guna2Separator sepItems;
        private System.Windows.Forms.Label lblItem1Qty;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDueTimeText;
        private System.Windows.Forms.Label lblTermsText;
        private System.Windows.Forms.Label lblTerm1;
        private System.Windows.Forms.Label lblFooterMessage2;
        private System.Windows.Forms.Label lblFooterMessage1;
        private System.Windows.Forms.Label lblReceiptNoText;
    }
}