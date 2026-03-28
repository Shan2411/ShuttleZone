using System;
using System.Windows.Forms;
using System.Drawing;

namespace ShuttleZone.Kio_sk
{
    public partial class UC_EquipmentRow : UserControl
    {
        public int AvailableStock { get; set; } // Store actual stock

        public UC_EquipmentRow()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
            this.MouseEnter += UC_EquipmentRow_MouseEnter;
            this.MouseLeave += UC_EquipmentRow_MouseLeave;
        }

        private void UC_EquipmentRow_MouseEnter(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.FromArgb(230, 218, 255);
        }

        private void UC_EquipmentRow_MouseLeave(object sender, EventArgs e)
        {
            guna2GradientPanel1.FillColor = Color.Transparent;
        }

        public string EquipmentNameText
        {
            get => EquipmentName.Text;
            set => EquipmentName.Text = value;
        }

        public string PriceText
        {
            get => Price.Text;
            set => Price.Text = value;
        }

        public string CategoryText
        {
            get => Category.Text;
            set => Category.Text = value;
        }

        public string StockText
        {
            get => Stock.Text;
            set => Stock.Text = value;
        }

        // Event to propagate clicks
        public event EventHandler RowClicked;

        private void AnyControl_Click(object sender, EventArgs e)
        {
            RowClicked?.Invoke(this, EventArgs.Empty);
        }

        public void InitializeRowEvents()
        {
            AssignClickRecursive(this);
        }

        private void AssignClickRecursive(Control ctrl)
        {
            ctrl.Click += AnyControl_Click;
            foreach (Control child in ctrl.Controls)
                AssignClickRecursive(child);
        }
    }
}