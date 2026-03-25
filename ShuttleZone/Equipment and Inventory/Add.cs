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

            // 🔥 STORE ORIGINAL DATA (IMPORTANT)
            NewEquipment = item;

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

            int rented = 0;
            int available = stock;

            // 🔥 PRESERVE VALUES IF EDITING
            if (isEditMode && NewEquipment != null)
            {
                rented = NewEquipment.Rented;

                // Adjust available based on new stock
                available = stock - rented;

                if (available < 0)
                {
                    MessageBox.Show("Stock cannot be less than rented items.");
                    return;
                }
            }

            // 🔥 AUTO STATUS LOGIC
            string status;
            if (available == 0)
                status = "Out of Stock";
            else if (rented > 0)
                status = "In Use";
            else
                status = "Available";

            NewEquipment = new EquipmentItem
            {
                Id = equipmentId,
                Name = txtEquipmentName.Text,
                Category = txtCategory.Text,
                Total = stock,
                Available = available,
                Rented = rented,
                Price = price,
                Status = status
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