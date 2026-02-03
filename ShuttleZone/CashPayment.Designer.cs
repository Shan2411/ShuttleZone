namespace ShuttleZone
{
    partial class CashPayment
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
            this.pnlCard = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlAmount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDueText = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.tlpMid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCash = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCashText = new System.Windows.Forms.Label();
            this.txtCash = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPesoSign = new System.Windows.Forms.Label();
            this.pnlChange = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChangeText = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.flowQuick = new System.Windows.Forms.FlowLayoutPanel();
            this.btn100 = new Guna.UI2.WinForms.Guna2Button();
            this.btn200 = new Guna.UI2.WinForms.Guna2Button();
            this.btn500 = new Guna.UI2.WinForms.Guna2Button();
            this.btn1000 = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQuickSelect = new System.Windows.Forms.Label();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnComplete = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCard.SuspendLayout();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlAmount.SuspendLayout();
            this.tlpMid.SuspendLayout();
            this.pnlCash.SuspendLayout();
            this.pnlChange.SuspendLayout();
            this.flowQuick.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.BorderRadius = 22;
            this.pnlCard.BorderThickness = 4;
            this.pnlCard.Controls.Add(this.tlpRoot);
            this.pnlCard.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.FillColor = System.Drawing.Color.White;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCard.ShadowDecoration.Enabled = true;
            this.pnlCard.Size = new System.Drawing.Size(520, 600);
            this.pnlCard.TabIndex = 0;
            // 
            // tlpRoot
            // 
            this.tlpRoot.BackColor = System.Drawing.Color.Transparent;
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlAmount, 0, 1);
            this.tlpRoot.Controls.Add(this.tlpMid, 0, 2);
            this.tlpRoot.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tlpRoot.Controls.Add(this.tlpFooter, 0, 4);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(20, 20);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 5;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(480, 560);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 16;
            this.pnlHeader.Controls.Add(this.lblSub);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(474, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(62, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cash Payment";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSub.Location = new System.Drawing.Point(64, 41);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(136, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Process cash transaction";
            // 
            // pnlAmount
            // 
            this.pnlAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.pnlAmount.BorderRadius = 16;
            this.pnlAmount.BorderThickness = 4;
            this.pnlAmount.Controls.Add(this.lblAmountDue);
            this.pnlAmount.Controls.Add(this.lblDueText);
            this.pnlAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAmount.FillColor = System.Drawing.Color.White;
            this.pnlAmount.ForeColor = System.Drawing.Color.Cornsilk;
            this.pnlAmount.Location = new System.Drawing.Point(3, 83);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Size = new System.Drawing.Size(474, 124);
            this.pnlAmount.TabIndex = 1;
            // 
            // lblDueText
            // 
            this.lblDueText.AutoSize = true;
            this.lblDueText.BackColor = System.Drawing.Color.Transparent;
            this.lblDueText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueText.ForeColor = System.Drawing.Color.DimGray;
            this.lblDueText.Location = new System.Drawing.Point(64, 25);
            this.lblDueText.Name = "lblDueText";
            this.lblDueText.Size = new System.Drawing.Size(85, 15);
            this.lblDueText.TabIndex = 0;
            this.lblDueText.Text = "AMOUNT DUE";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountDue.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.lblAmountDue.Location = new System.Drawing.Point(58, 40);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(140, 50);
            this.lblAmountDue.TabIndex = 1;
            this.lblAmountDue.Text = "₱00.00";
            // 
            // tlpMid
            // 
            this.tlpMid.ColumnCount = 2;
            this.tlpMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMid.Controls.Add(this.pnlCash, 0, 0);
            this.tlpMid.Controls.Add(this.pnlChange, 1, 0);
            this.tlpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMid.Location = new System.Drawing.Point(3, 213);
            this.tlpMid.Name = "tlpMid";
            this.tlpMid.RowCount = 1;
            this.tlpMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMid.Size = new System.Drawing.Size(474, 154);
            this.tlpMid.TabIndex = 2;
            // 
            // pnlCash
            // 
            this.pnlCash.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.pnlCash.BorderRadius = 16;
            this.pnlCash.BorderThickness = 4;
            this.pnlCash.Controls.Add(this.txtPesoSign);
            this.pnlCash.Controls.Add(this.txtCash);
            this.pnlCash.Controls.Add(this.lblCashText);
            this.pnlCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCash.Location = new System.Drawing.Point(3, 3);
            this.pnlCash.Name = "pnlCash";
            this.pnlCash.Size = new System.Drawing.Size(231, 148);
            this.pnlCash.TabIndex = 0;
            // 
            // lblCashText
            // 
            this.lblCashText.AutoSize = true;
            this.lblCashText.BackColor = System.Drawing.Color.Transparent;
            this.lblCashText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashText.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCashText.Location = new System.Drawing.Point(25, 22);
            this.lblCashText.Name = "lblCashText";
            this.lblCashText.Size = new System.Drawing.Size(95, 15);
            this.lblCashText.TabIndex = 0;
            this.lblCashText.Text = "CASH RECEIVED";
            // 
            // txtCash
            // 
            this.txtCash.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCash.DefaultText = "";
            this.txtCash.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCash.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCash.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCash.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCash.Location = new System.Drawing.Point(64, 57);
            this.txtCash.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCash.Name = "txtCash";
            this.txtCash.PlaceholderText = "";
            this.txtCash.SelectedText = "";
            this.txtCash.Size = new System.Drawing.Size(145, 42);
            this.txtCash.TabIndex = 1;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            // 
            // txtPesoSign
            // 
            this.txtPesoSign.AutoSize = true;
            this.txtPesoSign.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoSign.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtPesoSign.Location = new System.Drawing.Point(23, 63);
            this.txtPesoSign.Name = "txtPesoSign";
            this.txtPesoSign.Size = new System.Drawing.Size(26, 30);
            this.txtPesoSign.TabIndex = 2;
            this.txtPesoSign.Text = "₱";
            // 
            // pnlChange
            // 
            this.pnlChange.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.pnlChange.BorderRadius = 16;
            this.pnlChange.BorderThickness = 4;
            this.pnlChange.Controls.Add(this.lblChange);
            this.pnlChange.Controls.Add(this.lblChangeText);
            this.pnlChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChange.Location = new System.Drawing.Point(240, 3);
            this.pnlChange.Name = "pnlChange";
            this.pnlChange.Size = new System.Drawing.Size(231, 148);
            this.pnlChange.TabIndex = 1;
            // 
            // lblChangeText
            // 
            this.lblChangeText.AutoSize = true;
            this.lblChangeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.lblChangeText.Location = new System.Drawing.Point(29, 22);
            this.lblChangeText.Name = "lblChangeText";
            this.lblChangeText.Size = new System.Drawing.Size(85, 15);
            this.lblChangeText.TabIndex = 0;
            this.lblChangeText.Text = "INSUFFICIENT";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.lblChange.Location = new System.Drawing.Point(14, 61);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(21, 32);
            this.lblChange.TabIndex = 1;
            this.lblChange.Text = ".";
            // 
            // flowQuick
            // 
            this.flowQuick.Controls.Add(this.btn100);
            this.flowQuick.Controls.Add(this.btn200);
            this.flowQuick.Controls.Add(this.btn500);
            this.flowQuick.Controls.Add(this.btn1000);
            this.flowQuick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowQuick.Location = new System.Drawing.Point(3, 23);
            this.flowQuick.Name = "flowQuick";
            this.flowQuick.Size = new System.Drawing.Size(468, 88);
            this.flowQuick.TabIndex = 3;
            // 
            // btn100
            // 
            this.btn100.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn100.BorderRadius = 12;
            this.btn100.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn100.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn100.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn100.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn100.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btn100.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100.ForeColor = System.Drawing.Color.White;
            this.btn100.Location = new System.Drawing.Point(3, 3);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(110, 80);
            this.btn100.TabIndex = 0;
            this.btn100.Text = "₱100";
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // btn200
            // 
            this.btn200.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn200.BorderRadius = 12;
            this.btn200.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn200.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn200.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn200.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn200.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btn200.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn200.ForeColor = System.Drawing.Color.White;
            this.btn200.Location = new System.Drawing.Point(119, 3);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(110, 80);
            this.btn200.TabIndex = 1;
            this.btn200.Text = "₱200";
            this.btn200.Click += new System.EventHandler(this.btn200_Click);
            // 
            // btn500
            // 
            this.btn500.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn500.BorderRadius = 12;
            this.btn500.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn500.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn500.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn500.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn500.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btn500.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn500.ForeColor = System.Drawing.Color.White;
            this.btn500.Location = new System.Drawing.Point(235, 3);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(110, 80);
            this.btn500.TabIndex = 2;
            this.btn500.Text = "₱500";
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btn1000
            // 
            this.btn1000.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn1000.BorderRadius = 12;
            this.btn1000.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn1000.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn1000.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn1000.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn1000.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btn1000.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1000.ForeColor = System.Drawing.Color.White;
            this.btn1000.Location = new System.Drawing.Point(351, 3);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(110, 80);
            this.btn1000.TabIndex = 3;
            this.btn1000.Text = "₱1000";
            this.btn1000.Click += new System.EventHandler(this.btn1000_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowQuick, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblQuickSelect, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 373);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 114);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblQuickSelect
            // 
            this.lblQuickSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuickSelect.AutoSize = true;
            this.lblQuickSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.lblQuickSelect.Location = new System.Drawing.Point(3, 2);
            this.lblQuickSelect.Name = "lblQuickSelect";
            this.lblQuickSelect.Size = new System.Drawing.Size(77, 15);
            this.lblQuickSelect.TabIndex = 4;
            this.lblQuickSelect.Text = "Quick Select";
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 2;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.Controls.Add(this.btnCancel, 0, 0);
            this.tlpFooter.Controls.Add(this.btnComplete, 1, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(3, 493);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFooter.Size = new System.Drawing.Size(474, 64);
            this.tlpFooter.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 14;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(231, 58);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BorderRadius = 14;
            this.btnComplete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnComplete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnComplete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnComplete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnComplete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(240, 3);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(231, 58);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Complete";
            // 
            // CashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 600);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashPayment";
            this.pnlCard.ResumeLayout(false);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
            this.tlpMid.ResumeLayout(false);
            this.pnlCash.ResumeLayout(false);
            this.pnlCash.PerformLayout();
            this.pnlChange.ResumeLayout(false);
            this.pnlChange.PerformLayout();
            this.flowQuick.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlCard;
        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlAmount;
        private System.Windows.Forms.Label lblDueText;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.TableLayoutPanel tlpMid;
        private Guna.UI2.WinForms.Guna2Panel pnlCash;
        private System.Windows.Forms.Label lblCashText;
        private Guna.UI2.WinForms.Guna2TextBox txtCash;
        private System.Windows.Forms.Label txtPesoSign;
        private Guna.UI2.WinForms.Guna2Panel pnlChange;
        private System.Windows.Forms.Label lblChangeText;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.FlowLayoutPanel flowQuick;
        private Guna.UI2.WinForms.Guna2Button btn100;
        private Guna.UI2.WinForms.Guna2Button btn200;
        private Guna.UI2.WinForms.Guna2Button btn500;
        private Guna.UI2.WinForms.Guna2Button btn1000;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblQuickSelect;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnComplete;
    }
}