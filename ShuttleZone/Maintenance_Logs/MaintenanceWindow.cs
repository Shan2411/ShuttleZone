using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShuttleZone.Maintenance_Logs
{

    public partial class MaintenanceWindow : UserControl
    {
        // Form1

        public MaintenanceWindow()
        {
            // Enable double buffering BEFORE InitializeComponent
            this.DoubleBuffered = true;

            InitializeComponent();

            // SUSPEND LAYOUT - CRITICAL for performance
            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            // Configure panel once
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false; // If horizontal layout

            // Clear once
            flowLayoutPanel1.Controls.Clear();

            // Add all controls at once
            var buttons = new[]
            {
                new MButton("Court A", Globals.statusFromDB),
                new MButton("Court B", Globals.statusFromDB1),
                new MButton("Court C", Globals.statusFromDB2),
                new MButton("Court D", Globals.statusFromDB3)
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // Set textboxes
            textBox1.Text = Globals.courtPrice;
            textBox2.Text = Globals.vat;
            textBox3.Text = Globals.membershipPrice1Month;
            textBox4.Text = Globals.membershipPrice1Year;
            textBox6.Text = Globals.mambershipDiscount;

            // RESUME LAYOUT
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout(); // Force final layout

        }


        public void RefreshPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            // Add new controls as needed
            flowLayoutPanel1.Controls.Add(new MButton("Court A", Globals.statusFromDB));
            flowLayoutPanel1.Controls.Add(new MButton("Court B", Globals.statusFromDB1));
            flowLayoutPanel1.Controls.Add(new MButton("Court C", Globals.statusFromDB2));
            flowLayoutPanel1.Controls.Add(new MButton("Court D",  Globals.statusFromDB3));
            flowLayoutPanel1.Refresh();
        }

        private void MaintenanceWindow_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved!");
            Globals.courtPrice = textBox1.Text;
            Globals.vat = textBox2.Text;
            Globals.membershipPrice1Month = textBox3.Text;
            Globals.membershipPrice1Year = textBox4.Text;
            Globals.mambershipDiscount = textBox6.Text;
    }
    }
}
