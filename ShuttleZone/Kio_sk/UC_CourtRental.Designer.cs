namespace ShuttleZone
{
    partial class UC_CourtRental
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
            this.pnlKioskCourtRental = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.shpOblong = new Guna.UI2.WinForms.Guna2Shapes();
            this.lblKioskCourtRentalAvailability = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBadmintonCourt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblKioskCourtPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPerHour = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnKioskStartRental = new Guna.UI2.WinForms.Guna2Button();
            this.pnlKioskCourtRental.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKioskCourtRental
            // 
            this.pnlKioskCourtRental.BorderRadius = 10;
            this.pnlKioskCourtRental.Controls.Add(this.btnKioskStartRental);
            this.pnlKioskCourtRental.Controls.Add(this.lblPerHour);
            this.pnlKioskCourtRental.Controls.Add(this.lblKioskCourtPrice);
            this.pnlKioskCourtRental.Controls.Add(this.lblBadmintonCourt);
            this.pnlKioskCourtRental.Controls.Add(this.lblKioskCourtRentalAvailability);
            this.pnlKioskCourtRental.Controls.Add(this.shpOblong);
            this.pnlKioskCourtRental.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskCourtRental.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlKioskCourtRental.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlKioskCourtRental.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlKioskCourtRental.Location = new System.Drawing.Point(0, 0);
            this.pnlKioskCourtRental.Name = "pnlKioskCourtRental";
            this.pnlKioskCourtRental.Size = new System.Drawing.Size(377, 221);
            this.pnlKioskCourtRental.TabIndex = 0;
            // 
            // shpOblong
            // 
            this.shpOblong.BorderColor = System.Drawing.Color.Transparent;
            this.shpOblong.FillColor = System.Drawing.Color.Green;
            this.shpOblong.Location = new System.Drawing.Point(114, 18);
            this.shpOblong.Name = "shpOblong";
            this.shpOblong.PolygonSkip = 1;
            this.shpOblong.Rotate = 0F;
            this.shpOblong.RoundedRadius = 15;
            this.shpOblong.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.shpOblong.Size = new System.Drawing.Size(149, 34);
            this.shpOblong.TabIndex = 0;
            this.shpOblong.Zoom = 80;
            // 
            // lblKioskCourtRentalAvailability
            // 
            this.lblKioskCourtRentalAvailability.BackColor = System.Drawing.Color.Green;
            this.lblKioskCourtRentalAvailability.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKioskCourtRentalAvailability.ForeColor = System.Drawing.Color.White;
            this.lblKioskCourtRentalAvailability.Location = new System.Drawing.Point(144, 26);
            this.lblKioskCourtRentalAvailability.Name = "lblKioskCourtRentalAvailability";
            this.lblKioskCourtRentalAvailability.Size = new System.Drawing.Size(89, 19);
            this.lblKioskCourtRentalAvailability.TabIndex = 1;
            this.lblKioskCourtRentalAvailability.Text = "Available Now";
            // 
            // lblBadmintonCourt
            // 
            this.lblBadmintonCourt.BackColor = System.Drawing.Color.Transparent;
            this.lblBadmintonCourt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadmintonCourt.Location = new System.Drawing.Point(107, 58);
            this.lblBadmintonCourt.Name = "lblBadmintonCourt";
            this.lblBadmintonCourt.Size = new System.Drawing.Size(158, 27);
            this.lblBadmintonCourt.TabIndex = 2;
            this.lblBadmintonCourt.Text = "Badminton Court";
            // 
            // lblKioskCourtPrice
            // 
            this.lblKioskCourtPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblKioskCourtPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKioskCourtPrice.ForeColor = System.Drawing.Color.Green;
            this.lblKioskCourtPrice.Location = new System.Drawing.Point(134, 110);
            this.lblKioskCourtPrice.Name = "lblKioskCourtPrice";
            this.lblKioskCourtPrice.Size = new System.Drawing.Size(44, 27);
            this.lblKioskCourtPrice.TabIndex = 3;
            this.lblKioskCourtPrice.Text = "₱250";
            // 
            // lblPerHour
            // 
            this.lblPerHour.BackColor = System.Drawing.Color.Transparent;
            this.lblPerHour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPerHour.Location = new System.Drawing.Point(194, 116);
            this.lblPerHour.Name = "lblPerHour";
            this.lblPerHour.Size = new System.Drawing.Size(38, 19);
            this.lblPerHour.TabIndex = 4;
            this.lblPerHour.Text = "/hour";
            // 
            // btnKioskStartRental
            // 
            this.btnKioskStartRental.BorderRadius = 10;
            this.btnKioskStartRental.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKioskStartRental.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKioskStartRental.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKioskStartRental.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKioskStartRental.FillColor = System.Drawing.Color.Green;
            this.btnKioskStartRental.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKioskStartRental.ForeColor = System.Drawing.Color.White;
            this.btnKioskStartRental.Location = new System.Drawing.Point(96, 156);
            this.btnKioskStartRental.Name = "btnKioskStartRental";
            this.btnKioskStartRental.Size = new System.Drawing.Size(180, 45);
            this.btnKioskStartRental.TabIndex = 5;
            this.btnKioskStartRental.Text = "Start Court Rental";
            // 
            // UC_CourtRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlKioskCourtRental);
            this.Name = "UC_CourtRental";
            this.Size = new System.Drawing.Size(377, 221);
            this.pnlKioskCourtRental.ResumeLayout(false);
            this.pnlKioskCourtRental.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlKioskCourtRental;
        private Guna.UI2.WinForms.Guna2Shapes shpOblong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKioskCourtRentalAvailability;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBadmintonCourt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKioskCourtPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPerHour;
        private Guna.UI2.WinForms.Guna2Button btnKioskStartRental;
    }
}
