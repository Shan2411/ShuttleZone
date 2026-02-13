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

            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);

            NewEquipment = new EquipmentItem
            {
                Id = generatedId,
                Name = txtName.Text,
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
    }
}