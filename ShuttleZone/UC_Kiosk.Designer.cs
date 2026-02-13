namespace ShuttleZone
{
    partial class UC_Kiosk
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
            this.btnRunKiosk = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnRunKiosk
            // 
            this.btnRunKiosk.BorderRadius = 10;
            this.btnRunKiosk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRunKiosk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRunKiosk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRunKiosk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRunKiosk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(35)))), ((int)(((byte)(191)))));
            this.btnRunKiosk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunKiosk.ForeColor = System.Drawing.Color.White;
            this.btnRunKiosk.Location = new System.Drawing.Point(58, 41);
            this.btnRunKiosk.Name = "btnRunKiosk";
            this.btnRunKiosk.Size = new System.Drawing.Size(113, 50);
            this.btnRunKiosk.TabIndex = 0;
            this.btnRunKiosk.Text = "Run Kiosk";
            // 
            // UC_Kiosk
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnRunKiosk);
            this.Name = "UC_Kiosk";
            this.Size = new System.Drawing.Size(932, 587);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRunKiosk;
    }
}
