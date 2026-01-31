namespace ShuttleZone
{
    partial class UC_Pos
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbCourtRental = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tlpCourts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCourtA = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCourtB = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCourtC = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCourtD = new Guna.UI2.WinForms.Guna2Panel();
            this.gbEquipmentRental = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tlpEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEquipment1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlEquipment3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlEquipment2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlEquipment4 = new Guna.UI2.WinForms.Guna2Panel();
            this.gbMembership = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tlpMembership = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMembership1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMembership2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCart = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblMemberDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.txtMemberCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnProceedPayment = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblSubtotalText = new System.Windows.Forms.Label();
            this.flowCart = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCartItem = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlus = new Guna.UI2.WinForms.Guna2Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.btnMinus = new Guna.UI2.WinForms.Guna2Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.gbCourtRental.SuspendLayout();
            this.tlpCourts.SuspendLayout();
            this.gbEquipmentRental.SuspendLayout();
            this.tlpEquipment.SuspendLayout();
            this.gbMembership.SuspendLayout();
            this.tlpMembership.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.flowCart.SuspendLayout();
            this.pnlCartItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.pnlCart, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(932, 587);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpLeft.Controls.Add(this.gbCourtRental, 0, 1);
            this.tlpLeft.Controls.Add(this.gbEquipmentRental, 0, 2);
            this.tlpLeft.Controls.Add(this.gbMembership, 0, 3);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 4;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpLeft.Size = new System.Drawing.Size(646, 581);
            this.tlpLeft.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.FillColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(640, 34);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(197, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "POS & Rental Checkout";
            // 
            // gbCourtRental
            // 
            this.gbCourtRental.BorderRadius = 10;
            this.gbCourtRental.Controls.Add(this.tlpCourts);
            this.gbCourtRental.CustomBorderColor = System.Drawing.Color.MediumSeaGreen;
            this.gbCourtRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCourtRental.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCourtRental.ForeColor = System.Drawing.Color.Black;
            this.gbCourtRental.Location = new System.Drawing.Point(3, 43);
            this.gbCourtRental.Name = "gbCourtRental";
            this.gbCourtRental.Size = new System.Drawing.Size(640, 199);
            this.gbCourtRental.TabIndex = 1;
            this.gbCourtRental.Text = "Court Rental";
            // 
            // tlpCourts
            // 
            this.tlpCourts.ColumnCount = 2;
            this.tlpCourts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCourts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCourts.Controls.Add(this.pnlCourtA, 0, 0);
            this.tlpCourts.Controls.Add(this.pnlCourtB, 1, 0);
            this.tlpCourts.Controls.Add(this.pnlCourtC, 0, 1);
            this.tlpCourts.Controls.Add(this.pnlCourtD, 1, 1);
            this.tlpCourts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCourts.Location = new System.Drawing.Point(0, 40);
            this.tlpCourts.Name = "tlpCourts";
            this.tlpCourts.Padding = new System.Windows.Forms.Padding(8);
            this.tlpCourts.RowCount = 2;
            this.tlpCourts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCourts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCourts.Size = new System.Drawing.Size(640, 159);
            this.tlpCourts.TabIndex = 0;
            // 
            // pnlCourtA
            // 
            this.pnlCourtA.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.pnlCourtA.BorderRadius = 8;
            this.pnlCourtA.BorderThickness = 1;
            this.pnlCourtA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCourtA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCourtA.FillColor = System.Drawing.Color.Honeydew;
            this.pnlCourtA.Location = new System.Drawing.Point(11, 11);
            this.pnlCourtA.Name = "pnlCourtA";
            this.pnlCourtA.Size = new System.Drawing.Size(306, 65);
            this.pnlCourtA.TabIndex = 0;
            // 
            // pnlCourtB
            // 
            this.pnlCourtB.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.pnlCourtB.BorderRadius = 8;
            this.pnlCourtB.BorderThickness = 1;
            this.pnlCourtB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCourtB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCourtB.FillColor = System.Drawing.Color.Honeydew;
            this.pnlCourtB.Location = new System.Drawing.Point(323, 11);
            this.pnlCourtB.Name = "pnlCourtB";
            this.pnlCourtB.Size = new System.Drawing.Size(306, 65);
            this.pnlCourtB.TabIndex = 1;
            // 
            // pnlCourtC
            // 
            this.pnlCourtC.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.pnlCourtC.BorderRadius = 8;
            this.pnlCourtC.BorderThickness = 1;
            this.pnlCourtC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCourtC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCourtC.FillColor = System.Drawing.Color.Honeydew;
            this.pnlCourtC.Location = new System.Drawing.Point(11, 82);
            this.pnlCourtC.Name = "pnlCourtC";
            this.pnlCourtC.Size = new System.Drawing.Size(306, 66);
            this.pnlCourtC.TabIndex = 2;
            // 
            // pnlCourtD
            // 
            this.pnlCourtD.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.pnlCourtD.BorderRadius = 8;
            this.pnlCourtD.BorderThickness = 1;
            this.pnlCourtD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCourtD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCourtD.FillColor = System.Drawing.Color.Honeydew;
            this.pnlCourtD.Location = new System.Drawing.Point(323, 82);
            this.pnlCourtD.Name = "pnlCourtD";
            this.pnlCourtD.Size = new System.Drawing.Size(306, 66);
            this.pnlCourtD.TabIndex = 3;
            // 
            // gbEquipmentRental
            // 
            this.gbEquipmentRental.BorderRadius = 10;
            this.gbEquipmentRental.Controls.Add(this.tlpEquipment);
            this.gbEquipmentRental.CustomBorderColor = System.Drawing.Color.MediumPurple;
            this.gbEquipmentRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEquipmentRental.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEquipmentRental.ForeColor = System.Drawing.Color.Black;
            this.gbEquipmentRental.Location = new System.Drawing.Point(3, 248);
            this.gbEquipmentRental.Name = "gbEquipmentRental";
            this.gbEquipmentRental.Size = new System.Drawing.Size(640, 177);
            this.gbEquipmentRental.TabIndex = 2;
            this.gbEquipmentRental.Text = "Equipment Rental";
            // 
            // tlpEquipment
            // 
            this.tlpEquipment.ColumnCount = 2;
            this.tlpEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEquipment.Controls.Add(this.pnlEquipment1, 0, 0);
            this.tlpEquipment.Controls.Add(this.pnlEquipment3, 0, 1);
            this.tlpEquipment.Controls.Add(this.pnlEquipment2, 1, 0);
            this.tlpEquipment.Controls.Add(this.pnlEquipment4, 1, 1);
            this.tlpEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEquipment.Location = new System.Drawing.Point(0, 40);
            this.tlpEquipment.Name = "tlpEquipment";
            this.tlpEquipment.Padding = new System.Windows.Forms.Padding(8);
            this.tlpEquipment.RowCount = 2;
            this.tlpEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEquipment.Size = new System.Drawing.Size(640, 137);
            this.tlpEquipment.TabIndex = 0;
            // 
            // pnlEquipment1
            // 
            this.pnlEquipment1.BorderColor = System.Drawing.Color.MediumPurple;
            this.pnlEquipment1.BorderRadius = 8;
            this.pnlEquipment1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEquipment1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.pnlEquipment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquipment1.FillColor = System.Drawing.Color.Lavender;
            this.pnlEquipment1.Location = new System.Drawing.Point(11, 11);
            this.pnlEquipment1.Name = "pnlEquipment1";
            this.pnlEquipment1.Size = new System.Drawing.Size(306, 54);
            this.pnlEquipment1.TabIndex = 0;
            // 
            // pnlEquipment3
            // 
            this.pnlEquipment3.BorderColor = System.Drawing.Color.MediumPurple;
            this.pnlEquipment3.BorderRadius = 8;
            this.pnlEquipment3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEquipment3.CustomBorderColor = System.Drawing.Color.Transparent;
            this.pnlEquipment3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquipment3.FillColor = System.Drawing.Color.Lavender;
            this.pnlEquipment3.Location = new System.Drawing.Point(11, 71);
            this.pnlEquipment3.Name = "pnlEquipment3";
            this.pnlEquipment3.Size = new System.Drawing.Size(306, 55);
            this.pnlEquipment3.TabIndex = 1;
            // 
            // pnlEquipment2
            // 
            this.pnlEquipment2.BorderColor = System.Drawing.Color.MediumPurple;
            this.pnlEquipment2.BorderRadius = 8;
            this.pnlEquipment2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEquipment2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquipment2.FillColor = System.Drawing.Color.Lavender;
            this.pnlEquipment2.Location = new System.Drawing.Point(323, 11);
            this.pnlEquipment2.Name = "pnlEquipment2";
            this.pnlEquipment2.Size = new System.Drawing.Size(306, 54);
            this.pnlEquipment2.TabIndex = 2;
            // 
            // pnlEquipment4
            // 
            this.pnlEquipment4.BorderColor = System.Drawing.Color.MediumPurple;
            this.pnlEquipment4.BorderRadius = 8;
            this.pnlEquipment4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEquipment4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquipment4.FillColor = System.Drawing.Color.Lavender;
            this.pnlEquipment4.Location = new System.Drawing.Point(323, 71);
            this.pnlEquipment4.Name = "pnlEquipment4";
            this.pnlEquipment4.Size = new System.Drawing.Size(306, 55);
            this.pnlEquipment4.TabIndex = 3;
            // 
            // gbMembership
            // 
            this.gbMembership.BorderRadius = 10;
            this.gbMembership.Controls.Add(this.tlpMembership);
            this.gbMembership.CustomBorderColor = System.Drawing.Color.DodgerBlue;
            this.gbMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMembership.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMembership.ForeColor = System.Drawing.Color.Black;
            this.gbMembership.Location = new System.Drawing.Point(3, 431);
            this.gbMembership.Name = "gbMembership";
            this.gbMembership.Size = new System.Drawing.Size(640, 147);
            this.gbMembership.TabIndex = 3;
            this.gbMembership.Text = "Membership Packages";
            // 
            // tlpMembership
            // 
            this.tlpMembership.ColumnCount = 2;
            this.tlpMembership.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMembership.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMembership.Controls.Add(this.pnlMembership1, 0, 0);
            this.tlpMembership.Controls.Add(this.pnlMembership2, 1, 0);
            this.tlpMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMembership.Location = new System.Drawing.Point(0, 40);
            this.tlpMembership.Name = "tlpMembership";
            this.tlpMembership.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMembership.RowCount = 1;
            this.tlpMembership.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMembership.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMembership.Size = new System.Drawing.Size(640, 107);
            this.tlpMembership.TabIndex = 0;
            // 
            // pnlMembership1
            // 
            this.pnlMembership1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.pnlMembership1.BorderRadius = 8;
            this.pnlMembership1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMembership1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMembership1.FillColor = System.Drawing.Color.AliceBlue;
            this.pnlMembership1.Location = new System.Drawing.Point(13, 13);
            this.pnlMembership1.Name = "pnlMembership1";
            this.pnlMembership1.Size = new System.Drawing.Size(304, 81);
            this.pnlMembership1.TabIndex = 0;
            // 
            // pnlMembership2
            // 
            this.pnlMembership2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.pnlMembership2.BorderRadius = 8;
            this.pnlMembership2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMembership2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMembership2.FillColor = System.Drawing.Color.AliceBlue;
            this.pnlMembership2.Location = new System.Drawing.Point(323, 13);
            this.pnlMembership2.Name = "pnlMembership2";
            this.pnlMembership2.Size = new System.Drawing.Size(304, 81);
            this.pnlMembership2.TabIndex = 1;
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.Color.Transparent;
            this.pnlCart.BorderRadius = 12;
            this.pnlCart.Controls.Add(this.lblDiscount);
            this.pnlCart.Controls.Add(this.lblMemberDiscount);
            this.pnlCart.Controls.Add(this.lblTotal);
            this.pnlCart.Controls.Add(this.lblSubtotal);
            this.pnlCart.Controls.Add(this.btnApply);
            this.pnlCart.Controls.Add(this.txtMemberCode);
            this.pnlCart.Controls.Add(this.btnProceedPayment);
            this.pnlCart.Controls.Add(this.lblTotalText);
            this.pnlCart.Controls.Add(this.lblSubtotalText);
            this.pnlCart.Controls.Add(this.flowCart);
            this.pnlCart.Controls.Add(this.lblCart);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCart.FillColor = System.Drawing.Color.White;
            this.pnlCart.Location = new System.Drawing.Point(655, 3);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.ShadowDecoration.Enabled = true;
            this.pnlCart.Size = new System.Drawing.Size(274, 581);
            this.pnlCart.TabIndex = 1;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(196, 429);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(54, 15);
            this.lblDiscount.TabIndex = 10;
            this.lblDiscount.Text = "Discount";
            // 
            // lblMemberDiscount
            // 
            this.lblMemberDiscount.AutoSize = true;
            this.lblMemberDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberDiscount.Location = new System.Drawing.Point(24, 429);
            this.lblMemberDiscount.Name = "lblMemberDiscount";
            this.lblMemberDiscount.Size = new System.Drawing.Size(102, 15);
            this.lblMemberDiscount.TabIndex = 9;
            this.lblMemberDiscount.Text = "Member Discount";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(215, 455);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(32, 15);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(196, 404);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(51, 15);
            this.lblSubtotal.TabIndex = 7;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // btnApply
            // 
            this.btnApply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApply.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(181, 530);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(66, 35);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            // 
            // txtMemberCode
            // 
            this.txtMemberCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemberCode.DefaultText = "Enter member code";
            this.txtMemberCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMemberCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMemberCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMemberCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMemberCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMemberCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMemberCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMemberCode.Location = new System.Drawing.Point(29, 530);
            this.txtMemberCode.Name = "txtMemberCode";
            this.txtMemberCode.PlaceholderText = "";
            this.txtMemberCode.SelectedText = "";
            this.txtMemberCode.Size = new System.Drawing.Size(141, 37);
            this.txtMemberCode.TabIndex = 5;
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProceedPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProceedPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProceedPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProceedPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceedPayment.ForeColor = System.Drawing.Color.White;
            this.btnProceedPayment.Location = new System.Drawing.Point(29, 480);
            this.btnProceedPayment.Name = "btnProceedPayment";
            this.btnProceedPayment.Size = new System.Drawing.Size(218, 35);
            this.btnProceedPayment.TabIndex = 4;
            this.btnProceedPayment.Text = "Proceed to Payment";
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(26, 455);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(32, 15);
            this.lblTotalText.TabIndex = 3;
            this.lblTotalText.Text = "Total";
            // 
            // lblSubtotalText
            // 
            this.lblSubtotalText.AutoSize = true;
            this.lblSubtotalText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalText.Location = new System.Drawing.Point(24, 404);
            this.lblSubtotalText.Name = "lblSubtotalText";
            this.lblSubtotalText.Size = new System.Drawing.Size(51, 15);
            this.lblSubtotalText.TabIndex = 2;
            this.lblSubtotalText.Text = "Subtotal";
            // 
            // flowCart
            // 
            this.flowCart.AutoScroll = true;
            this.flowCart.Controls.Add(this.pnlCartItem);
            this.flowCart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowCart.Location = new System.Drawing.Point(29, 35);
            this.flowCart.Name = "flowCart";
            this.flowCart.Size = new System.Drawing.Size(218, 359);
            this.flowCart.TabIndex = 1;
            this.flowCart.WrapContents = false;
            // 
            // pnlCartItem
            // 
            this.pnlCartItem.BackColor = System.Drawing.Color.Transparent;
            this.pnlCartItem.BorderRadius = 10;
            this.pnlCartItem.Controls.Add(this.btnRemove);
            this.pnlCartItem.Controls.Add(this.btnPlus);
            this.pnlCartItem.Controls.Add(this.lblQty);
            this.pnlCartItem.Controls.Add(this.btnMinus);
            this.pnlCartItem.Controls.Add(this.lblItemName);
            this.pnlCartItem.FillColor = System.Drawing.Color.White;
            this.pnlCartItem.Location = new System.Drawing.Point(5, 5);
            this.pnlCartItem.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCartItem.Name = "pnlCartItem";
            this.pnlCartItem.ShadowDecoration.Enabled = true;
            this.pnlCartItem.Size = new System.Drawing.Size(208, 50);
            this.pnlCartItem.TabIndex = 0;
            this.pnlCartItem.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BorderRadius = 6;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.IndianRed;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(175, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 28);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "X";
            // 
            // btnPlus
            // 
            this.btnPlus.BorderRadius = 6;
            this.btnPlus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.Location = new System.Drawing.Point(141, 11);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(28, 28);
            this.btnPlus.TabIndex = 13;
            this.btnPlus.Text = "+";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(118, 18);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(13, 15);
            this.lblQty.TabIndex = 11;
            this.lblQty.Text = "1";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinus
            // 
            this.btnMinus.BorderRadius = 6;
            this.btnMinus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.Color.White;
            this.btnMinus.Location = new System.Drawing.Point(81, 11);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(28, 28);
            this.btnMinus.TabIndex = 12;
            this.btnMinus.Text = "-";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(6, 18);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(70, 15);
            this.lblItemName.TabIndex = 11;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(21, 12);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(40, 21);
            this.lblCart.TabIndex = 0;
            this.lblCart.Text = "Cart";
            // 
            // UC_Pos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tlpMain);
            this.Name = "UC_Pos";
            this.Size = new System.Drawing.Size(932, 587);
            this.Load += new System.EventHandler(this.UC_Pos_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.gbCourtRental.ResumeLayout(false);
            this.tlpCourts.ResumeLayout(false);
            this.gbEquipmentRental.ResumeLayout(false);
            this.tlpEquipment.ResumeLayout(false);
            this.gbMembership.ResumeLayout(false);
            this.tlpMembership.ResumeLayout(false);
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            this.flowCart.ResumeLayout(false);
            this.pnlCartItem.ResumeLayout(false);
            this.pnlCartItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox gbCourtRental;
        private System.Windows.Forms.TableLayoutPanel tlpCourts;
        private Guna.UI2.WinForms.Guna2Panel pnlCourtA;
        private Guna.UI2.WinForms.Guna2Panel pnlCourtB;
        private Guna.UI2.WinForms.Guna2Panel pnlCourtC;
        private Guna.UI2.WinForms.Guna2Panel pnlCourtD;
        private Guna.UI2.WinForms.Guna2GroupBox gbEquipmentRental;
        private System.Windows.Forms.TableLayoutPanel tlpEquipment;
        private Guna.UI2.WinForms.Guna2Panel pnlEquipment1;
        private Guna.UI2.WinForms.Guna2Panel pnlEquipment3;
        private Guna.UI2.WinForms.Guna2Panel pnlEquipment2;
        private Guna.UI2.WinForms.Guna2Panel pnlEquipment4;
        private Guna.UI2.WinForms.Guna2GroupBox gbMembership;
        private System.Windows.Forms.TableLayoutPanel tlpMembership;
        private Guna.UI2.WinForms.Guna2Panel pnlMembership1;
        private Guna.UI2.WinForms.Guna2Panel pnlMembership2;
        private Guna.UI2.WinForms.Guna2Panel pnlCart;
        private System.Windows.Forms.FlowLayoutPanel flowCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblSubtotalText;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2TextBox txtMemberCode;
        private Guna.UI2.WinForms.Guna2Button btnProceedPayment;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblMemberDiscount;
        private Guna.UI2.WinForms.Guna2Panel pnlCartItem;
        private System.Windows.Forms.Label lblItemName;
        private Guna.UI2.WinForms.Guna2Button btnMinus;
        private System.Windows.Forms.Label lblQty;
        private Guna.UI2.WinForms.Guna2Button btnPlus;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
    }
}
