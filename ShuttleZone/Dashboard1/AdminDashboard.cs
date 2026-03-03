using ShuttleZone.Maintenance_Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class AdminDashboard : UserControl
    {
        public AdminDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Padding = new Padding(20);

            flowLayoutPanel1.Controls.Clear();

            // Revenue Overview Header
            Label headerLabel = new Label
            {
                Text = "Revenue Overview",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 15)
            };
            flowLayoutPanel1.Controls.Add(headerLabel);

            // Court Rentals
            Label courtRentalsLabel = new Label
            {
                Text = "Court Rentals",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(courtRentalsLabel);

            Label courtRentalsAmount = new Label
            {
                Text = "₱128,400",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(courtRentalsAmount);

            // Progress bar for Court Rentals
            Panel barContainer = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 60,
                Height = 30,
                Margin = new Padding(20, 0, 0, 15)
            };

            ProgressBar progress1 = new ProgressBar("x")
            {
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            barContainer.Controls.Add(progress1);
            flowLayoutPanel1.Controls.Add(barContainer);

            // Equipment Rentals
            Label equipmentRentalsLabel = new Label
            {
                Text = "Equipment Rentals",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(equipmentRentalsLabel);

            Label equipmentRentalsAmount = new Label
            {
                Text = "₱84,200",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(equipmentRentalsAmount);

            // Progress bar for Equipment Rentals
            Panel barContainer2 = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 60,
                Height = 30,
                Margin = new Padding(20, 0, 0, 15)
            };

            ProgressBar progress2 = new ProgressBar("x")
            {
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            barContainer2.Controls.Add(progress2);
            flowLayoutPanel1.Controls.Add(barContainer2);

            // Memberships
            Label membershipsLabel = new Label
            {
                Text = "Memberships",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(membershipsLabel);

            Label membershipsAmount = new Label
            {
                Text = "₱130,200",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(membershipsAmount);

            // Progress bar for Memberships
            Panel barContainer3 = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 60,
                Height = 30,
                Margin = new Padding(20, 0, 0, 15)
            };

            ProgressBar progress3 = new ProgressBar("x")
            {
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            barContainer3.Controls.Add(progress3);
            flowLayoutPanel1.Controls.Add(barContainer3);

            flowLayoutPanel1.ResumeLayout(false);

            // Row 1 / Columns 1,3,5,7 with Dock = Fill
            var c1 = new Card_Dashboard("Today's Transactions") { Dock = DockStyle.Fill };
            var c3 = new Card_Dashboard("Active Rentals") { Dock = DockStyle.Fill };
            var c5 = new Card_Dashboard("New Memberships") { Dock = DockStyle.Fill };
            var c7 = new Card_Dashboard("Pending Payments") { Dock = DockStyle.Fill };

            tableLayoutPanel2.Controls.Add(c1, 0, 1);
            tableLayoutPanel2.Controls.Add(c3, 2, 1);
            tableLayoutPanel2.Controls.Add(c5, 4, 1);
            tableLayoutPanel2.Controls.Add(c7, 6, 1);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2VProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
