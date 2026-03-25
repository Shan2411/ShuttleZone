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
        // ── Class-level fields ──────────────────────────────────────
        private bool _isFirstLoad = true;
        private Timer _refreshTimer = new Timer();

        // Label references
        private Label _courtLabel, _courtAmount;
        private Label _equipmentLabel, _equipmentAmount;
        private Label _membershipLabel, _membershipAmount;
        private Label _stackedLabel, _totalLabel;

        // Bar fill references
        private Panel _courtFill, _equipmentFill, _membershipFill;
        private Panel _stackedCourt, _stackedEquipment, _stackedMembership;

        // Card references
        private Card_Dashboard _c1, _c3, _c5, _c7;

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

            Globals.getThisMonthStats();
            Globals.getThisMonthRevenue();

            int courtPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.courtRentals / Globals.thisMonthsRevenue) * 100) : 0;
            int equipmentPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.equipmentRentals / Globals.thisMonthsRevenue) * 100) : 0;
            int membershipPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.memberships / Globals.thisMonthsRevenue) * 100) : 0;

            int fullBarWidth = flowLayoutPanel1.ClientSize.Width - 2;
            int barHeight = 23;

            flowLayoutPanel1.Controls.Add(new Label
            {
                Text = "This Month's Revenue",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 15)
            });

            // Court Rentals
            _courtLabel = new Label { Text = $"Court Rentals ({courtPercent}%)", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(0, 0, 0, 5) };
            _courtAmount = new Label { Text = $"₱{Globals.courtRentals:N0}", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(20, 0, 0, 5) };
            flowLayoutPanel1.Controls.Add(_courtLabel);
            flowLayoutPanel1.Controls.Add(_courtAmount);
            var courtBarContainer = new Panel { Width = fullBarWidth, Height = barHeight, BackColor = Color.LightGray, Margin = new Padding(20, 0, 0, 15) };
            _courtFill = new Panel { Width = (int)(fullBarWidth * courtPercent / 100.0), Height = barHeight, BackColor = Color.FromArgb(0, 120, 215) };
            courtBarContainer.Controls.Add(_courtFill);
            flowLayoutPanel1.Controls.Add(courtBarContainer);

            // Equipment Rentals
            _equipmentLabel = new Label { Text = $"Equipment Rentals ({equipmentPercent}%)", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(0, 0, 0, 5) };
            _equipmentAmount = new Label { Text = $"₱{Globals.equipmentRentals:N0}", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(20, 0, 0, 5) };
            flowLayoutPanel1.Controls.Add(_equipmentLabel);
            flowLayoutPanel1.Controls.Add(_equipmentAmount);
            var equipmentBarContainer = new Panel { Width = fullBarWidth, Height = barHeight, BackColor = Color.LightGray, Margin = new Padding(20, 0, 0, 15) };
            _equipmentFill = new Panel { Width = (int)(fullBarWidth * equipmentPercent / 100.0), Height = barHeight, BackColor = Color.Orange };
            equipmentBarContainer.Controls.Add(_equipmentFill);
            flowLayoutPanel1.Controls.Add(equipmentBarContainer);

            // Memberships
            _membershipLabel = new Label { Text = $"Memberships ({membershipPercent}%)", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(0, 0, 0, 5) };
            _membershipAmount = new Label { Text = $"₱{Globals.memberships:N0}", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(20, 0, 0, 5) };
            flowLayoutPanel1.Controls.Add(_membershipLabel);
            flowLayoutPanel1.Controls.Add(_membershipAmount);
            var membershipBarContainer = new Panel { Width = fullBarWidth, Height = barHeight, BackColor = Color.LightGray, Margin = new Padding(20, 0, 0, 15) };
            _membershipFill = new Panel { Width = (int)(fullBarWidth * membershipPercent / 100.0), Height = barHeight, BackColor = Color.Green };
            membershipBarContainer.Controls.Add(_membershipFill);
            flowLayoutPanel1.Controls.Add(membershipBarContainer);

            // Stacked bar
            _stackedLabel = new Label
            {
                Text = $"Revenue Distribution: Rentals {courtPercent}%, Equipment {equipmentPercent}%, Membership {membershipPercent}%",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 20, 0, 5)
            };
            flowLayoutPanel1.Controls.Add(_stackedLabel);
            var stackedContainer = new Panel { Width = fullBarWidth, Height = barHeight, BackColor = Color.LightGray, Margin = new Padding(20, 0, 0, 15) };
            _stackedCourt = new Panel { Width = (int)(fullBarWidth * courtPercent / 100.0), Height = barHeight, BackColor = Color.FromArgb(0, 120, 215), Dock = DockStyle.Left };
            _stackedEquipment = new Panel { Width = (int)(fullBarWidth * equipmentPercent / 100.0), Height = barHeight, BackColor = Color.Orange, Dock = DockStyle.Left };
            _stackedMembership = new Panel { Width = (int)(fullBarWidth * membershipPercent / 100.0), Height = barHeight, BackColor = Color.Green, Dock = DockStyle.Left };
            stackedContainer.Controls.Add(_stackedCourt);
            stackedContainer.Controls.Add(_stackedEquipment);
            stackedContainer.Controls.Add(_stackedMembership);
            flowLayoutPanel1.Controls.Add(stackedContainer);

            // Total
            _totalLabel = new Label { Text = $"Total Revenue: ₱{Globals.thisMonthsRevenue:N0}", Font = new Font("Segoe UI", 11, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 10, 0, 5) };
            flowLayoutPanel1.Controls.Add(_totalLabel);
            flowLayoutPanel1.Controls.Add(new Panel { Width = fullBarWidth, Height = barHeight, BackColor = Color.DarkGray, Margin = new Padding(20, 0, 0, 20) });

            // Left side
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.HorizontalScroll.Enabled = false;
            flowLayoutPanel2.HorizontalScroll.Visible = false;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Padding = new Padding(20);
            flowLayoutPanel2.Controls.Clear();

            flowLayoutPanel2.Controls.Add(new Label { Text = "System Activity", Font = new Font("Segoe UI", 13, FontStyle.Bold), AutoSize = true, Margin = new Padding(10, 6, 0, 15) });
            flowLayoutPanel2.Controls.Add(new Label { Text = "Peak Hours:", Font = new Font("Segoe UI", 11, FontStyle.Regular), AutoSize = true, Margin = new Padding(0, 0, 0, 5) });
            flowLayoutPanel2.Controls.Add(new PeakHours { Margin = new Padding(0, 5, 0, 10) });

            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);

            // Cards
            _c1 = new Card_Dashboard("Today's Revenue") { Dock = DockStyle.Fill };
            _c3 = new Card_Dashboard("Average Monthly Revenue") { Dock = DockStyle.Fill };
            _c5 = new Card_Dashboard("Total Transactions") { Dock = DockStyle.Fill };
            _c7 = new Card_Dashboard("Active Members") { Dock = DockStyle.Fill };
            tableLayoutPanel2.Controls.Add(_c1, 0, 1);
            tableLayoutPanel2.Controls.Add(_c3, 2, 1);
            tableLayoutPanel2.Controls.Add(_c5, 4, 1);
            tableLayoutPanel2.Controls.Add(_c7, 6, 1);

            this.ResumeLayout(false);
            this.PerformLayout();

            // ── Timer setup ONCE here, not in UpdateDashboardUI ──────
            _refreshTimer.Interval = 10000;
            _refreshTimer.Tick += (s, e) => RefreshDashboard();
            _refreshTimer.Start();
        }

        private void RefreshDashboard()
        {
            Globals.getThisMonthRevenue();
            Globals.getThisMonthStats();
            UpdateDashboardUI();
        }

        private void AdminDashboard_Activated(object sender, EventArgs e)
        {
            if (_isFirstLoad) { _isFirstLoad = false; return; }
            RefreshDashboard();
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _refreshTimer.Stop();
            _refreshTimer.Dispose();
        }

        public void UpdateDashboardUI()
        {
            int fullBarWidth = flowLayoutPanel1.ClientSize.Width - 2;

            int courtPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.courtRentals / Globals.thisMonthsRevenue) * 100) : 0;
            int equipmentPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.equipmentRentals / Globals.thisMonthsRevenue) * 100) : 0;
            int membershipPercent = Globals.thisMonthsRevenue > 0 ? (int)((Globals.memberships / Globals.thisMonthsRevenue) * 100) : 0;

            // Update labels only — no rebuilding
            _courtLabel.Text = $"Court Rentals ({courtPercent}%)";
            _courtAmount.Text = $"₱{Globals.courtRentals:N0}";
            _equipmentLabel.Text = $"Equipment Rentals ({equipmentPercent}%)";
            _equipmentAmount.Text = $"₱{Globals.equipmentRentals:N0}";
            _membershipLabel.Text = $"Memberships ({membershipPercent}%)";
            _membershipAmount.Text = $"₱{Globals.memberships:N0}";
            _stackedLabel.Text = $"Revenue Distribution: Rentals {courtPercent}%, Equipment {equipmentPercent}%, Membership {membershipPercent}%";
            _totalLabel.Text = $"Total Revenue: ₱{Globals.thisMonthsRevenue:N0}";

            // Update bar widths only
            _courtFill.Width = (int)(fullBarWidth * courtPercent / 100.0);
            _equipmentFill.Width = (int)(fullBarWidth * equipmentPercent / 100.0);
            _membershipFill.Width = (int)(fullBarWidth * membershipPercent / 100.0);
            _stackedCourt.Width = (int)(fullBarWidth * courtPercent / 100.0);
            _stackedEquipment.Width = (int)(fullBarWidth * equipmentPercent / 100.0);
            _stackedMembership.Width = (int)(fullBarWidth * membershipPercent / 100.0);

            // Update cards
            _c1.loadPictures("today's revenue");
            _c3.loadPictures("average monthly revenue");
            _c5.loadPictures("total transactions");
            _c7.loadPictures("active members");
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
