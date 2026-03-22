using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.reports
{
    public partial class DetailedReportRows : UserControl
    {
        public DetailedReportRows()
        {
            InitializeComponent();
            StyleLabels();
        }

        // ── Style all labels to match the image ───────────────────────────────

        private void StyleLabels()
        {
            // Row background — white, alternating handled by Page2
            this.BackColor = Color.White;

            // Font for all data labels
            Font dataFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            Font totalFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            // Date — dark gray
            lblDate.Font = dataFont;
            lblDate.ForeColor = Color.FromArgb(50, 50, 60);

            // Court Income — dark gray
            lblCourtIncome.Font = dataFont;
            lblCourtIncome.ForeColor = Color.FromArgb(50, 50, 60);

            // Equipment Income — dark gray
            lblEquipmentIncome.Font = dataFont;
            lblEquipmentIncome.ForeColor = Color.FromArgb(50, 50, 60);

            // Total Income — purple/violet (like in the image)
            lblTotalIncome.Font = totalFont;
            lblTotalIncome.ForeColor = Color.BlueViolet;

            // Transactions — dark gray
            lblTransaction.Font = dataFont;
            lblTransaction.ForeColor = Color.FromArgb(50, 50, 60);
        }

        // ── Public Setter ─────────────────────────────────────────────────────

        public void SetData(string date, int courtIncome, int equipIncome,
                            int totalIncome, int transactions)
        {
            lblDate.Text = date;
            lblCourtIncome.Text = "₱" + courtIncome.ToString("N0");
            lblEquipmentIncome.Text = "₱" + equipIncome.ToString("N0");
            lblTotalIncome.Text = "₱" + totalIncome.ToString("N0");
            lblTransaction.Text = transactions.ToString();
        }

        // ── Alternating row color — called from Page2 ─────────────────────────
        public void SetAlternateColor(bool isEven)
        {
            this.BackColor = isEven
                ? Color.FromArgb(248, 248, 252)  // very light gray
                : Color.White;
            tableLayoutPanel1.BackColor = this.BackColor;
        }

        // ── Existing Event Handlers ───────────────────────────────────────────
        private void lblDate_Click(object sender, EventArgs e) { }
        private void lblTransaction_Click(object sender, EventArgs e) { }
        private void lblCourtIncome_Click(object sender, EventArgs e) { }
        private void lblEquipmentIncome_Click(object sender, EventArgs e) { }
        private void lblTotalIncome_Click(object sender, EventArgs e) { }
    }
}