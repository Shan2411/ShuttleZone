using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        private string generatedId;

        public EquipmentItem NewEquipment { get; private set; }

        public Add(string id)
        {
            InitializeComponent();
            generatedId = id;
            InitializeCategory();

          
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            txtPrice.KeyPress += txtPrice_KeyPress;
        }
        public void LoadExistingData(EquipmentItem item)
        {
            txtName.Text = item.Name;
            cmbCategory.SelectedItem = item.Category;
            txtQuantity.Text = item.Total.ToString();
            txtPrice.Text = item.Price.ToString();
        }


        private void InitializeCategory()
        {
            if (cmbCategory.Items.Count == 0)
            {
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity (numbers only).");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price (numbers only).");
                return;
            }

            NewEquipment = new EquipmentItem
            {
                Id = generatedId,
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            e.Handled = true;
        }
    }
}

