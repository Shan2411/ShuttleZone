using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        // This will be read by Equipment.cs
        public EquipmentItem NewEquipment { get; private set; }

        public Add()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Rackets");
            cmbCategory.Items.Add("Shuttlecocks");
            cmbCategory.Items.Add("Shoes");
            cmbCategory.Items.Add("Accessories");

            cmbCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be a number.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a number.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            NewEquipment = new EquipmentItem
            {
                Id = "EQ" + DateTime.Now.Ticks.ToString().Substring(10),
                Name = txtName.Text,
                Category = cmbCategory.Text,
                Total = quantity,
                Available = quantity,
                Rented = 0,
                Price = price,
                Status = "Available"
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            // Leave empty if not used
        }
    }
}