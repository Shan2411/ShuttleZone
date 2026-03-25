using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Equipment : UserControl
    {
        private BindingList<EquipmentItem> equipmentList = new BindingList<EquipmentItem>();
        private BindingList<EquipmentItem> filteredList = new BindingList<EquipmentItem>();

        public Equipment()
        {
            InitializeComponent();
            InitializeUI();
            HookEvents();

            dgvTable.DataSource = filteredList;

            LoadFromDatabase();
        }
        private void LoadFromDatabase()
        {
            equipmentList.Clear();

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM equipment";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipmentList.Add(new EquipmentItem
                            {
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                Total = Convert.ToInt32(reader["Total"]),
                                Available = Convert.ToInt32(reader["Available"]),
                                Rented = Convert.ToInt32(reader["Rented"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }

                ApplySearch();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

        }
        //summary updater
        private void UpdateSummary()
        {
            int totalItemsCount = equipmentList.Count;
            int totalAvailableCount = equipmentList.Sum(x => x.Available);
            int totalRentedCount = equipmentList.Sum(x => x.Rented);

            totalItems.Text = totalItemsCount.ToString();
            totalAvailable.Text = totalAvailableCount.ToString();
            totalRented.Text = totalRentedCount.ToString();
        }

        private void InitializeUI()
        {
            dgvTable.AutoGenerateColumns = false;
            dgvTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTable.MultiSelect = false;
            dgvTable.Columns.Clear();

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Name",
                DataPropertyName = "Name",
                Width = 180
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Category",
                DataPropertyName = "Category"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "Total"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAvailable",
                HeaderText = "Available",
                DataPropertyName = "Available"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRented",
                HeaderText = "Rented",
                DataPropertyName = "Rented"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Price",
                DataPropertyName = "Price"
            });

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvTable.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "Actions",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dgvTable.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }

        private void HookEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplySearch();
            dgvTable.CellContentClick += dgvTable_CellContentClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newId = GenerateNextId();
            Add addForm = new Add(newId);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                InsertEquipment(addForm.NewEquipment);
                LoadFromDatabase();
            }
        }
        //insert new equipment to database
        private void InsertEquipment(EquipmentItem item)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                INSERT INTO equipment 
                (Id, Name, Category, Total, Available, Rented, Price, Status)
                VALUES
                (@Id, @Name, @Category, @Total, @Available, @Rented, @Price, @Status)
            ";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert failed: " + ex.Message);
            }
        }

        //update existing equipment in database
        private void UpdateEquipment(EquipmentItem item)
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
                WHERE Id = @Id
            ";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        //delete equipment from database
        private void DeleteEquipment(string id)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM equipment WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EquipmentItem selectedItem = (EquipmentItem)dgvTable.Rows[e.RowIndex].DataBoundItem;

            if (dgvTable.Columns[e.ColumnIndex].Name == "colEdit")
            {
                Add editForm = new Add(selectedItem.Id);
                editForm.LoadExistingData(selectedItem);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    selectedItem.Name = editForm.NewEquipment.Name;
                    selectedItem.Category = editForm.NewEquipment.Category;
                    selectedItem.Total = editForm.NewEquipment.Total;
                    selectedItem.Available = editForm.NewEquipment.Available;
                    selectedItem.Rented = editForm.NewEquipment.Rented;
                    selectedItem.Price = editForm.NewEquipment.Price;
                    selectedItem.Status = editForm.NewEquipment.Status;

                    UpdateEquipment(editForm.NewEquipment);
                    LoadFromDatabase();
                }
            }

            if (dgvTable.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var result = MessageBox.Show(
                    "Delete this item?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEquipment(selectedItem.Id);
                    LoadFromDatabase();
                }
            }
        }

        private string GenerateNextId()
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id FROM equipment";

                    var ids = new List<int>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["Id"].ToString();
                            ids.Add(int.Parse(id.Substring(2)));
                        }
                    }

                    int max = ids.Count > 0 ? ids.Max() : 0;
                    return "EQ" + (max + 1).ToString("D3");
                }
            }
            catch
            {
                return "EQ001";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // do nothing
        }

        private void ApplySearch()
        {
            string search = txtSearch.Text.ToLower();

            var results = equipmentList.Where(item =>
                item.Name.ToLower().Contains(search) ||
                item.Category.ToLower().Contains(search) ||
                item.Id.ToLower().Contains(search) ||
                item.Status.ToLower().Contains(search)
            ).ToList();

            filteredList.Clear();

            foreach (var item in results)
            {
                filteredList.Add(item);
            }
        }

        private void pnlAvailable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void totalItems_Click(object sender, EventArgs e)
        {

        }

        private void totalAvailable_Click(object sender, EventArgs e)
        {

        }

        private void totalRented_Click(object sender, EventArgs e)
        {

        }
    }
}