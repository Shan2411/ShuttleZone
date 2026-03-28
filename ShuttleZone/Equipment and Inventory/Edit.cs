using ShuttleZone.database;
using System;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Edit : Form
    {
        private EquipmentItem currentItem; // the item being edited

        public Edit()
        {
            InitializeComponent();
        }

        public Edit(EquipmentItem item)
        {
            InitializeComponent();
            LoadExistingData(item);
        }

        // Load the item data into the form
        public void LoadExistingData(EquipmentItem item)
        {
            if (item == null) return;

            currentItem = item;

            txtEquipmentName.Text = item.Name;

            // Keep category as read-only textbox
            txtCategory.Text = item.Category;
            txtCategory.ReadOnly = true;

            txtStock.Text = item.Total.ToString();
            txtRentalPrice.Text = item.Price.ToString();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
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

            int rented = currentItem.Rented;
            int available = stock - rented;

            if (available < 0)
            {
                MessageBox.Show("Stock cannot be less than rented items.");
                return;
            }

            // Auto status logic
            string status;
            if (available == 0)
                status = "Out of Stock";
            else if (rented > 0)
                status = "In Use";
            else
                status = "Available";

            // Update currentItem object
            currentItem.Name = txtEquipmentName.Text;
            currentItem.Category = txtCategory.Text; // still read-only
            currentItem.Total = stock;
            currentItem.Available = available;
            currentItem.Rented = rented;
            currentItem.Price = price;
            currentItem.Status = status;

            // Update database
            UpdateEquipmentInDatabase(currentItem);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEquipmentInDatabase(EquipmentItem item)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE equipment SET
                            Name = @Name,
                            Category = @Category,
                            Total = @Total,
                            Available = @Available,
                            Rented = @Rented,
                            Price = @Price,
                            Status = @Status
                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Category", item.Category);
                    cmd.Parameters.AddWithValue("@Total", item.Total);
                    cmd.Parameters.AddWithValue("@Available", item.Available);
                    cmd.Parameters.AddWithValue("@Rented", item.Rented);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@Status", item.Status);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Equipment updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }
    }
}