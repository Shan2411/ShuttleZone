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

        public Equipment()
        {
            InitializeComponent();
            InitializeUI();
            HookEvents();

            dgvTable.DataSource = equipmentList;

            LoadSampleData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoadSampleData()
        {
            equipmentList.Add(new EquipmentItem
            {
                Id = "EQ001",
                Name = "Yonex Racket",
                Category = "Rackets",
                Total = 10,
                Available = 8,
                Rented = 2,
                Price = 150,
                Status = "Available"
            });

            equipmentList.Add(new EquipmentItem
            {
                Id = "EQ002",
                Name = "Shuttlecock",
                Category = "Shuttlecocks",
                Total = 50,
                Available = 50,
                Rented = 0,
                Price = 25,
                Status = "Available"
            });
        }

        private void InitializeUI()
        {
            dgvTable.AutoGenerateColumns = false;
            dgvTable.AllowUserToResizeRows = false;
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

            cmbFilter.Items.AddRange(new object[] { "All", "Available", "Rented" });
            cmbFilter.SelectedIndex = 0;

            cmbCategory.Items.AddRange(new object[]
            {
                "All",
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
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbCategory.SelectedIndexChanged += (s, e) => ApplyFilters();
            dgvTable.CellContentClick += dgvTable_CellContentClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newId = GenerateNextId();
            Add addForm = new Add(newId);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                equipmentList.Add(addForm.NewEquipment);
            }
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            EquipmentItem selectedItem = equipmentList[e.RowIndex];

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

                    dgvTable.Refresh();
                }
            }

            if (dgvTable.Columns[e.ColumnIndex].Name == "colDelete")
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    equipmentList.Remove(selectedItem);
                }
            }
        }

        private string GenerateNextId()
        {
            if (equipmentList.Count == 0)
                return "EQ001";

            int maxNumber = equipmentList
                .Select(x => int.Parse(x.Id.Substring(2)))
                .Max();

            return "EQ" + (maxNumber + 1).ToString("D3");
        }

        private void ApplyFilters()
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                bool visible = true;

                string name = row.Cells["colName"].Value.ToString();
                string category = row.Cells["colCategory"].Value.ToString();
                string status = row.Cells["colStatus"].Value.ToString();

                if (!string.IsNullOrWhiteSpace(txtSearch.Text) &&
                    !name.ToLower().Contains(txtSearch.Text.ToLower()))
                    visible = false;

                if (cmbFilter.SelectedItem.ToString() != "All" &&
                    status != cmbFilter.SelectedItem.ToString())
                    visible = false;

                if (cmbCategory.SelectedItem.ToString() != "All" &&
                    category != cmbCategory.SelectedItem.ToString())
                    visible = false;

                row.Visible = visible;
            }
        }
    }
}
