using ShuttleZone.Maintenance_Logs;
using ShuttleZone.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuttleZone.Membership;

namespace ShuttleZone.Dashboard1
{
    public partial class FrontDeskDashboard : UserControl
    {
        public FrontDeskDashboard()
        {
            InitializeComponent();

            //int initiateClass = Globals.GetTodaysTransaction();
            Globals.getThisMonthStats();
            Globals.GetCourtStatusFromDB("Court A");   //
            Globals.GetCourtStatusFromDB("Court B");
            Globals.GetCourtStatusFromDB("Court C");
            Globals.GetCourtStatusFromDB("Court D");
            Globals.transactions = Globals.GetRecentTransactions();

            this.DoubleBuffered = true;

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.WrapContents = false;

            flowLayoutPanel1.Controls.Clear();

            var table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 4;
            table.RowCount = 1;
            table.AutoScroll = false; // no scrollbars

            // Percent columns = they compress when parent shrinks
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));

            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            var buttons = new[]
            {
                new CourtCard("Court A", Globals.statusFromDB),
                new CourtCard("Court B", Globals.statusFromDB1),
                new CourtCard("Court C", Globals.statusFromDB2),
                new CourtCard("Court D", Globals.statusFromDB3)
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // Row 1 / Columns 1,3,5,7 with Dock = Fill
            var c1 = new Card_Dashboard("Today's Transactions") { Dock = DockStyle.Fill };
            var c3 = new Card_Dashboard("Active Rentals") { Dock = DockStyle.Fill };
            var c5 = new Card_Dashboard("Active Members") { Dock = DockStyle.Fill };
            var c7 = new Card_Dashboard("Pending Payments") { Dock = DockStyle.Fill };

            tableLayoutPanel2.Controls.Add(c1, 1, 1);
            tableLayoutPanel2.Controls.Add(c3, 3, 1);
            tableLayoutPanel2.Controls.Add(c5, 5, 1);
            tableLayoutPanel2.Controls.Add(c7, 7, 1);

            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();


            // ADD Recent payments 

            //flowLayoutPanel2.Controls.Add(new HeaderColumn());

            /*flowLayoutPanel2.Resize += (s, e) =>
            {
                foreach (Control c in flowLayoutPanel2.Controls)
                {
                    c.Width = flowLayoutPanel2.ClientSize.Width - flowLayoutPanel2.Padding.Horizontal;
                }
            };
            */
            Globals.transactions = Globals.GetRecentTransactions();


            timer1.Interval = 3000; // 5 seconds
            timer1.Tick += timer1_Tick;
            timer1.Start();

                       
        }

        // One method, defined once

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        public void RefreshPanel()
        {
            // Re-fetch latest data from DB
            Globals.getThisMonthStats();
            Globals.statusFromDB = Globals.GetCourtStatusFromDB("Court A");
            Globals.statusFromDB1 = Globals.GetCourtStatusFromDB("Court B");
            Globals.statusFromDB2 = Globals.GetCourtStatusFromDB("Court C");
            Globals.statusFromDB3 = Globals.GetCourtStatusFromDB("Court D");
            Globals.transactions = Globals.GetRecentTransactions();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is CourtCard card)
                {
                    string latestStatus = Globals.GetCourtStatusFromDB(card.CourtName);

                    if (latestStatus?.ToLower() == "in use")
                    {
                        // ✅ Timer is still running — don't recreate, just ensure timer is ticking
                        if (card.CurrentStatus?.ToLower() != "in use")
                        {
                            // Status just changed TO "in use" — start the countdown
                            card.CurrentStatus = latestStatus;
                            card.countDownStarter(latestStatus);
                        }
                        // else: already "in use" with running timer — leave it alone
                    }
                    else
                    {
                        // ✅ Not "in use" — always redraw so DB changes reflect on card
                        card.CurrentStatus = latestStatus;
                        card.countDownStarter(latestStatus);
                    }
                }
            }

            // ✅ Refresh Card_Dashboards
            tableLayoutPanel2.SuspendLayout();

            var toRemove = tableLayoutPanel2.Controls
                .OfType<Card_Dashboard>()
                .ToList();

            foreach (var card in toRemove)
            {
                tableLayoutPanel2.Controls.Remove(card);
                card.Dispose();
            }

            tableLayoutPanel2.Controls.Add(new Card_Dashboard("Today's Transactions") { Dock = DockStyle.Fill }, 1, 1);
            tableLayoutPanel2.Controls.Add(new Card_Dashboard("Active Rentals") { Dock = DockStyle.Fill }, 3, 1);
            tableLayoutPanel2.Controls.Add(new Card_Dashboard("Active Members") { Dock = DockStyle.Fill }, 5, 1);
            tableLayoutPanel2.Controls.Add(new Card_Dashboard("Pending Payments") { Dock = DockStyle.Fill }, 7, 1);

            tableLayoutPanel2.ResumeLayout(true);
            tableLayoutPanel2.PerformLayout();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void addMemberbtn_Click(object sender, EventArgs e)
        {
            var form = new AddNewMember();

            if (form.ShowDialog() == DialogResult.OK)
            {
                var model = new MemberModel
                {
                    Name = form.MemberNameValue,
                    Email = form.MemberEmailValue,
                    Phone = form.MemberPhoneValue,
                    MembershipType = form.MembershipTypeValue,
                    ExpiryDate = DateTime.TryParse(form.ExpiryDateValue, out DateTime exp) ? exp : (DateTime?)null,
                    JoinDate = form.JoinDateValue
                };

                int newId = DataAccess.AddMember(model);
                /*
                if (newId > 0)
                    UC_Membership.LoadMembers();
                else
                    MessageBox.Show("Failed to add member");*/
            }
        }


        public event EventHandler QuickActionPOSClicked;
        public event EventHandler QuickActionPendingClicked;

        private void pendingPaymentsbtn_Click(object sender, EventArgs e)
        {
            QuickActionPendingClicked?.Invoke(this, EventArgs.Empty);
        }

        private void openPOSbtn_Click_1(object sender, EventArgs e)
        {
            QuickActionPOSClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
