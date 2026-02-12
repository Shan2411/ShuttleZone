using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        // This will be read by Equipment.cs
        public EquipmentItem AddedItem { get; private set; }

        public Add()
        {
            InitializeComponent();
            LoadCategories();
            HookEvents();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new object[]
            {
                "Rackets",
                "Shuttlecocks",
                "Shoes",
                "Accessories",
                "Consumables"
            });

            cmbCategory.SelectedIndex = 0;
        }

        private void HookEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbCategory.SelectedIndex < 0 ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show(
                    "Please enter valid values for all fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AddedItem = new EquipmentItem
            {
                Id = Guid.NewGuid().ToString().Substring(0, 8),
                Name = txtName.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Total = quantity,
                Available = quantity,
                Rented = 0,
                Price = price,
                Status = "Available"
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    // Shared model
    public class EquipmentItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Total { get; set; }
        public int Available { get; set; }
        public int Rented { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
