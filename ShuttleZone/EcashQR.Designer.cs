namespace ShuttleZone
{
    partial class EcashQR
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
            this.lblScanToPayText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblScanYap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAmountToPayText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPaymentComplete = new Guna.UI2.WinForms.Guna2Button();
            this.pnlAmountToPay = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancelEcashPayment = new Guna.UI2.WinForms.Guna2Button();
            this.pnlAmountToPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScanToPayText
            // 
            this.lblScanToPayText.BackColor = System.Drawing.Color.Transparent;
            this.lblScanToPayText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanToPayText.Location = new System.Drawing.Point(24, 27);
            this.lblScanToPayText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblScanToPayText.Name = "lblScanToPayText";
            this.lblScanToPayText.Size = new System.Drawing.Size(91, 23);
            this.lblScanToPayText.TabIndex = 0;
            this.lblScanToPayText.Text = "Scan to Pay";
            // 
            // lblScanYap
            // 
            this.lblScanYap.BackColor = System.Drawing.Color.Transparent;
            this.lblScanYap.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanYap.Location = new System.Drawing.Point(43, 65);
            this.lblScanYap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblScanYap.Name = "lblScanYap";
            this.lblScanYap.Size = new System.Drawing.Size(314, 19);
            this.lblScanYap.TabIndex = 1;
            this.lblScanYap.Text = "Scan this QR code with your GCash or E-Wallet app";
            // 
            // lblAmountToPayText
            // 
            this.lblAmountToPayText.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountToPayText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountToPayText.Location = new System.Drawing.Point(112, 13);
            this.lblAmountToPayText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblAmountToPayText.Name = "lblAmountToPayText";
            this.lblAmountToPayText.Size = new System.Drawing.Size(83, 17);
            this.lblAmountToPayText.TabIndex = 2;
            this.lblAmountToPayText.Text = "Amount to Pay";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(134, 28);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(40, 23);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "₱250";
            // 
            // btnPaymentComplete
            // 
            this.btnPaymentComplete.BorderRadius = 10;
            this.btnPaymentComplete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPaymentComplete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPaymentComplete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPaymentComplete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPaymentComplete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnPaymentComplete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentComplete.ForeColor = System.Drawing.Color.White;
            this.btnPaymentComplete.Location = new System.Drawing.Point(203, 421);
            this.btnPaymentComplete.Name = "btnPaymentComplete";
            this.btnPaymentComplete.Size = new System.Drawing.Size(148, 45);
            this.btnPaymentComplete.TabIndex = 5;
            this.btnPaymentComplete.Text = "Payment Complete";
            // 
            // pnlAmountToPay
            // 
            this.pnlAmountToPay.BackColor = System.Drawing.Color.Honeydew;
            this.pnlAmountToPay.BorderRadius = 10;
            this.pnlAmountToPay.Controls.Add(this.lblTotalAmount);
            this.pnlAmountToPay.Controls.Add(this.lblAmountToPayText);
            this.pnlAmountToPay.Location = new System.Drawing.Point(47, 337);
            this.pnlAmountToPay.Name = "pnlAmountToPay";
            this.pnlAmountToPay.Size = new System.Drawing.Size(304, 67);
            this.pnlAmountToPay.TabIndex = 6;
            // 
            // btnCancelEcashPayment
            // 
            this.btnCancelEcashPayment.BorderRadius = 10;
            this.btnCancelEcashPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelEcashPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelEcashPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelEcashPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelEcashPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnCancelEcashPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEcashPayment.ForeColor = System.Drawing.Color.White;
            this.btnCancelEcashPayment.Location = new System.Drawing.Point(47, 421);
            this.btnCancelEcashPayment.Name = "btnCancelEcashPayment";
            this.btnCancelEcashPayment.Size = new System.Drawing.Size(148, 45);
            this.btnCancelEcashPayment.TabIndex = 7;
            this.btnCancelEcashPayment.Text = "Cancel";
            // 
            // EcashQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.btnCancelEcashPayment);
            this.Controls.Add(this.pnlAmountToPay);
            this.Controls.Add(this.btnPaymentComplete);
            this.Controls.Add(this.lblScanYap);
            this.Controls.Add(this.lblScanToPayText);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EcashQR";
            this.Text = "EcashQR";
            this.pnlAmountToPay.ResumeLayout(false);
            this.pnlAmountToPay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblScanToPayText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScanYap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAmountToPayText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalAmount;
        private Guna.UI2.WinForms.Guna2Button btnPaymentComplete;
        private Guna.UI2.WinForms.Guna2Panel pnlAmountToPay;
        private Guna.UI2.WinForms.Guna2Button btnCancelEcashPayment;
    }
}