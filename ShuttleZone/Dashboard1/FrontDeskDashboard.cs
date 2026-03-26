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
    public partial class FrontDeskDashboard : UserControl
    {
        public FrontDeskDashboard()
        {
            InitializeComponent();

            //int initiateClass = Globals.GetTodaysTransaction();
            Globals.getThisMonthStats();
            Globals.GetActiveRentals();
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

            flowLayoutPanel2.Controls.Add(new HeaderColumn());

            flowLayoutPanel2.Resize += (s, e) =>
            {
                foreach (Control c in flowLayoutPanel2.Controls)
                {
                    c.Width = flowLayoutPanel2.ClientSize.Width - flowLayoutPanel2.Padding.Horizontal;
                }
            };

            Globals.transactions = Globals.GetRecentTransactions();

            foreach (var t in Globals.transactions)
            {
                flowLayoutPanel2.Controls.Add(new H_Row(
                    t.ReceiptId,
                    t.PaymentMethod,
                    t.TotalAmount.ToString(),
                    t.TransactionTime));  // DateTime ✅
            }


            timer1.Interval = 5000; // 5 seconds
            timer1.Tick += timer1_Tick;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        public void RefreshPanel()
        {
            // 🔥 Re-fetch latest data from DB
            Globals.GetCourtStatusFromDB("Court A");   //
            Globals.GetCourtStatusFromDB("Court B");
            Globals.GetCourtStatusFromDB("Court C");
            Globals.GetCourtStatusFromDB("Court D");
            Globals.transactions = Globals.GetRecentTransactions();

            // Refresh courts UI
            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.Controls.Add(new CourtCard("Court A", Globals.statusFromDB));
            flowLayoutPanel1.Controls.Add(new CourtCard("Court B", Globals.statusFromDB1));
            flowLayoutPanel1.Controls.Add(new CourtCard("Court C", Globals.statusFromDB2));
            flowLayoutPanel1.Controls.Add(new CourtCard("Court D", Globals.statusFromDB3));

            // Refresh recent transactions
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(new HeaderColumn());

            foreach (var t in Globals.transactions)
            {
                flowLayoutPanel2.Controls.Add(new H_Row(
                    t.ReceiptId,
                    t.PaymentMethod,
                    t.TotalAmount.ToString(),
                    t.TransactionTime));
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
