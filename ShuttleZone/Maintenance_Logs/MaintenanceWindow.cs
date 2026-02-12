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
            InitializeComponent();


            MButton court1_button = new MButton();
            MButton court2_button = new MButton();
            MButton court3_button = new MButton();
            MButton court4_button = new MButton();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.HorizontalScroll.Enabled = false;           
            flowLayoutPanel1.HorizontalScroll.Visible = false;          

            
            flowLayoutPanel1.Controls.Add(new MButton("Court A", Globals.statusFromDB)); 
            flowLayoutPanel1.Controls.Add(new MButton("Court B", Globals.statusFromDB1)); 
            flowLayoutPanel1.Controls.Add(new MButton("Court C", Globals.statusFromDB2));
            flowLayoutPanel1.Controls.Add(new MButton("Court D", Globals.statusFromDB3));


            // Bottom Half

            textBox1.Text = Globals.courtPrice;
            textBox2.Text = Globals.vat;
            textBox3.Text = Globals.membershipPrice1Month;
            textBox4.Text = Globals.membershipPrice1Year;
            textBox6.Text = Globals.mambershipDiscount;

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
