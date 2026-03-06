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




            // Revenue data
            decimal courtRentals = 12400;
            decimal equipmentRentals = 2567;
            decimal memberships = 6436;

            Globals.thisMonthsRevenue = courtRentals + equipmentRentals + memberships;

            // Calculate percentages
            int courtPercent = (int)((courtRentals / Globals.thisMonthsRevenue) * 100);
            int equipmentPercent = (int)((equipmentRentals / Globals.thisMonthsRevenue) * 100);
            int membershipPercent = (int)((memberships / Globals.thisMonthsRevenue) * 100);

            // Common width for the full bar
            int fullBarWidth = flowLayoutPanel1.ClientSize.Width - 2;
            int barHeight = 23;

            Label header = new Label
            {
                Text = "This Month's Revenue",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 15)
            };
            flowLayoutPanel1.Controls.Add(header);

            // ---------------- COURT RENTALS ----------------
            Label courtLabel = new Label
            {
                Text = $"Court Rentals ({courtPercent}%)",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(courtLabel);

            Label courtAmount = new Label
            {
                Text = $"₱{courtRentals:N0}",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(courtAmount);

            Panel courtBarContainer = new Panel
            {
                Width = fullBarWidth,
                Height = barHeight,
                BackColor = Color.LightGray,
                Margin = new Padding(20, 0, 0, 15)
            };

            Panel courtFill = new Panel
            {
                Width = (int)(fullBarWidth * courtPercent / 100.0),
                Height = barHeight,
                BackColor = Color.FromArgb(0, 120, 215) // blue
            };

            courtBarContainer.Controls.Add(courtFill);
            flowLayoutPanel1.Controls.Add(courtBarContainer);

            // ---------------- EQUIPMENT RENTALS ----------------
            Label equipmentLabel = new Label
            {
                Text = $"Equipment Rentals ({equipmentPercent}%)",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(equipmentLabel);

            Label equipmentAmount = new Label
            {
                Text = $"₱{equipmentRentals:N0}",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(equipmentAmount);

            Panel equipmentBarContainer = new Panel
            {
                Width = fullBarWidth,
                Height = barHeight,
                BackColor = Color.LightGray,
                Margin = new Padding(20, 0, 0, 15)
            };

            Panel equipmentFill = new Panel
            {
                Width = (int)(fullBarWidth * equipmentPercent / 100.0),
                Height = barHeight,
                BackColor = Color.Orange
            };

            // Add the fill **before** adding the container to flowLayoutPanel
            equipmentBarContainer.Controls.Add(equipmentFill);
            flowLayoutPanel1.Controls.Add(equipmentBarContainer);

            // ---------------- MEMBERSHIPS ----------------
            Label membershipLabel = new Label
            {
                Text = $"Memberships ({membershipPercent}%)",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(membershipLabel);

            Label membershipAmount = new Label
            {
                Text = $"₱{memberships:N0}",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(20, 0, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(membershipAmount);

            Panel membershipBarContainer = new Panel
            {
                Width = fullBarWidth,
                Height = barHeight,
                BackColor = Color.LightGray,
                Margin = new Padding(20, 0, 0, 15)
            };

            Panel membershipFill = new Panel
            {
                Width = (int)(fullBarWidth * membershipPercent / 100.0),
                Height = barHeight,
                BackColor = Color.Green
            };

            membershipBarContainer.Controls.Add(membershipFill);
            flowLayoutPanel1.Controls.Add(membershipBarContainer);

            // ---------- STACKED HORIZONTAL "PIE" BAR ----------
            Label stackedLabel = new Label
            {
                Text = $"Revenue Distribution: Rentals {courtPercent}%, Equipment {equipmentPercent}%, Membership {membershipPercent}%",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 20, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(stackedLabel);

            Panel stackedContainer = new Panel
            {
                Width = fullBarWidth,
                Height = barHeight,
                BackColor = Color.LightGray,
                Margin = new Padding(20, 0, 0, 15)
            };

            // Add rectangles in order (court → equipment → membership)
            Panel stackedCourt = new Panel
            {
                Width = (int)(fullBarWidth * courtPercent / 100.0),
                Height = barHeight,
                BackColor = Color.FromArgb(0, 120, 215),
                Dock = DockStyle.Left
            };
            stackedContainer.Controls.Add(stackedCourt);

            Panel stackedEquipment = new Panel
            {
                Width = (int)(fullBarWidth * equipmentPercent / 100.0),
                Height = barHeight,
                BackColor = Color.Orange,
                Dock = DockStyle.Left
            };
            stackedContainer.Controls.Add(stackedEquipment);

            Panel stackedMembership = new Panel
            {
                Width = (int)(fullBarWidth * membershipPercent / 100.0),
                Height = barHeight,
                BackColor = Color.Green,
                Dock = DockStyle.Left
            };
            stackedContainer.Controls.Add(stackedMembership);

            flowLayoutPanel1.Controls.Add(stackedContainer);

            // ---------- TOTAL REVENUE BAR ----------
            Label totalLabel = new Label
            {
                Text = $"Total Revenue: ₱{Globals.thisMonthsRevenue:N0}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(totalLabel);

            Panel totalContainer = new Panel
            {
                Width = fullBarWidth,
                Height = barHeight,
                BackColor = Color.DarkGray,
                Margin = new Padding(20, 0, 0, 20)
            };
            flowLayoutPanel1.Controls.Add(totalContainer);




            //LEFT SIDE :)

            flowLayoutPanel2.SuspendLayout();

            flowLayoutPanel2.HorizontalScroll.Enabled = false;
            flowLayoutPanel2.HorizontalScroll.Visible = false;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Padding = new Padding(20);  

            flowLayoutPanel2.Controls.Clear();

            Label header2 = new Label
            {
                Text = "System Activity",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(10, 6, 0, 15)  
            };
            flowLayoutPanel2.Controls.Add(header2);

            // ---------------- Peak Hours ----------------
            Label peakLabel = new Label
            {
                Text = "Peak Hours:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            flowLayoutPanel2.Controls.Add(peakLabel);

            PeakHours peakHoursControl = new PeakHours
            {
                Margin = new Padding(0, 5, 0, 10)
            };

            flowLayoutPanel2.Controls.Add(peakHoursControl);

            // Insight Title
            Label avgTitle = new Label
            {
                Text = "Average Revenue per Transaction",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 0)
            };

            flowLayoutPanel2.Controls.Add(avgTitle);

            // Insight Value
            Label avgValue = new Label
            {
                Text = "₱508.32",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 20)
            };

            flowLayoutPanel2.Controls.Add(avgValue);





            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);

            // Row 1 / Columns 1,3,5,7 with Dock = Fill
            var c1 = new Card_Dashboard("Today's Revenue") { Dock = DockStyle.Fill };
            var c3 = new Card_Dashboard("Average Monthly Revenue") { Dock = DockStyle.Fill };
            var c5 = new Card_Dashboard("Total Transactions") { Dock = DockStyle.Fill };
            var c7 = new Card_Dashboard("Active Members") { Dock = DockStyle.Fill };

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
