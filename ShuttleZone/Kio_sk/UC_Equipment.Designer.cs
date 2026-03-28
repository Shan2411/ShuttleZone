namespace ShuttleZone
{
    partial class UC_Equipment
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
            this.pnlKioskEquipment = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.tlpEquipmentRoot = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKioskEquipment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKioskEquipment
            // 
            this.pnlKioskEquipment.BorderRadius = 10;
            this.pnlKioskEquipment.Controls.Add(this.tlpEquipmentRoot);
            this.pnlKioskEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKioskEquipment.FillColor = System.Drawing.Color.White;
            this.pnlKioskEquipment.FillColor2 = System.Drawing.Color.White;
            this.pnlKioskEquipment.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlKioskEquipment.Location = new System.Drawing.Point(0, 0);
            this.pnlKioskEquipment.Name = "pnlKioskEquipment";
            this.pnlKioskEquipment.Size = new System.Drawing.Size(377, 221);
            this.pnlKioskEquipment.TabIndex = 0;
            // 
            // tlpEquipmentRoot
            // 
            this.tlpEquipmentRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEquipmentRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpEquipmentRoot.Name = "tlpEquipmentRoot";
            this.tlpEquipmentRoot.Size = new System.Drawing.Size(377, 221);
            this.tlpEquipmentRoot.TabIndex = 1;
            // 
            // UC_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlKioskEquipment);
            this.Name = "UC_Equipment";
            this.Size = new System.Drawing.Size(377, 221);
            this.pnlKioskEquipment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlKioskEquipment;
        private System.Windows.Forms.FlowLayoutPanel tlpEquipmentRoot;
    }
}
