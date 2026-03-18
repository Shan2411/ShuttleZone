using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Add : Form
    {
        public string EquipmentId;
        public EquipmentItem NewEquipment { get; private set; }

        public Add(string id)
        {
            InitializeComponent();
            EquipmentId = id;
            txtId.Text = id;
        }

        public void LoadExistingData(EquipmentItem item)
        {
            txtId.Text = item.Id;
            txtName.Text = item.Name;
            cmbCategory.Text = item.Category;
            txtTotal.Text = item.Total.ToString();
            txtAvailable.Text = item.Available.ToString();
            txtRented.Text = item.Rented.ToString();
            txtPrice.Text = item.Price.ToString();
            cmbStatus.Text = item.Status;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtTotal.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            if (!int.TryParse(txtTotal.Text, out int total) ||
                !int.TryParse(txtAvailable.Text, out int available) ||
                !int.TryParse(txtRented.Text, out int rented) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid number input.");
                return;
            }

            NewEquipment = new EquipmentItem
            {
                Id = txtId.Text,
                Name = txtName.Text,
                Category = cmbCategory.Text,
                Total = total,
                Available = available,
                Rented = rented,
                Price = price,
                Status = cmbStatus.Text
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