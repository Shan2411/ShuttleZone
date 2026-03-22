using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.reports
{
    public partial class DetailedReportRows : UserControl
    {
        public DetailedReportRows()
        {
            InitializeComponent();
        }

        // ── Public Setter ─────────────────────────────────────────────────────
        //  Called by Reports_Dashboard_Page2 when populating the FlowLayoutPanel.
        //  Make sure your Designer labels are named exactly:
        //      lblDate, lblCourtIncome, lblEquipmentIncome, lblTotalIncome, lblTransaction

        public void SetData(string date, int courtIncome, int equipIncome, int totalIncome, int transactions)
        {
            lblDate.Text = date;
            lblCourtIncome.Text = "₱" + courtIncome.ToString("N0");
            lblEquipmentIncome.Text = "₱" + equipIncome.ToString("N0");
            lblTotalIncome.Text = "₱" + totalIncome.ToString("N0");
            lblTransaction.Text = transactions.ToString();
        }

        // ── Existing Event Handlers (unchanged) ───────────────────────────────

        private void lblDate_Click(object sender, EventArgs e) { }

        private void lblTransaction_Click(object sender, EventArgs e) { }

        private void lblCourtIncome_Click(object sender, EventArgs e) { }

        private void lblEquipmentIncome_Click(object sender, EventArgs e) { }

        private void lblTotalIncome_Click(object sender, EventArgs e) { }
    }
}