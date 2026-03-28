using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        public EquipmentItem NewEquipment { get; private set; }

        private string equipmentId; // store ID
        private bool isEditMode = false; // track edit mode

        public Add()
        {
            InitializeComponent();
            SetupCategoryComboBox();
        }

        public Add(string id)
        {
            InitializeComponent();
            equipmentId = id;
            SetupCategoryComboBox();
        }

        // Populate cbCategory with fixed options
        private void SetupCategoryComboBox()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(new string[] { "Rackets", "Shuttlecocks", "Grip Tape", "Towel" });
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList; // user cannot type custom value
            cbCategory.SelectedIndex = 0; // default to first item
        }

        public void LoadExistingData(EquipmentItem item)
        {
            if (item == null) return;

            isEditMode = true;
            equipmentId = item.Id;
            NewEquipment = item;

            txtEquipmentName.Text = item.Name;
            cbCategory.SelectedItem = item.Category; // use ComboBox instead of txtCategory
            txtStock.Text = item.Total.ToString();
            txtRentalPrice.Text = item.Price.ToString();
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

            if (isEditMode && NewEquipment != null)
            {
                rented = NewEquipment.Rented;
                available = stock - rented;

                if (available < 0)
                {
                    MessageBox.Show("Stock cannot be less than rented items.");
                    return;
                }
            }

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
                Category = cbCategory.SelectedItem.ToString(), // get value from ComboBox
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