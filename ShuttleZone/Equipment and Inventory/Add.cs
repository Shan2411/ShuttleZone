using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        public EquipmentItem NewEquipment { get; private set; }

        private string equipmentId; // ✅ store ID
        private bool isEditMode = false; // ✅ track edit mode

        // ✅ DEFAULT constructor (still needed)
        public Add()
        {
            InitializeComponent();
        }

        // ✅ FIX 1: Constructor with ID (solves CS1729)
        public Add(string id)
        {
            InitializeComponent();
            equipmentId = id;
        }

        // ✅ FIX 2: LoadExistingData method (solves CS1061)
        public void LoadExistingData(EquipmentItem item)
        {
            if (item == null) return;

            isEditMode = true;
            equipmentId = item.Id;

            txtEquipmentName.Text = item.Name;
            txtCategory.Text = item.Category;
            txtStock.Text = item.Total.ToString();
            txtRentalPrice.Text = item.Price.ToString();
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEquipmentName.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtRentalPrice.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) ||
                !decimal.TryParse(txtRentalPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid number input.");
                return;
            }

            // ✅ FIX 3: Preserve ID + handle edit properly
            NewEquipment = new EquipmentItem
            {
                Id = equipmentId, // IMPORTANT
                Name = txtEquipmentName.Text,
                Category = txtCategory.Text,
                Total = stock,
                Available = isEditMode ? stock : stock, // you can improve later
                Rented = 0,
                Price = price,
                Status = "Available"
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}