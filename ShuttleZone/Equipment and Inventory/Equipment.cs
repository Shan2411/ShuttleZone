using System;
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

            LoadSampleData();
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

            ApplySearch(); // show all initially
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
                equipmentList.Add(addForm.NewEquipment);
                ApplySearch();
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

                    dgvTable.Refresh();
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
                    equipmentList.Remove(selectedItem);
                    ApplySearch();
                }
            }
        }

        private string GenerateNextId()
        {
            if (equipmentList.Count == 0)
                return "EQ001";

            int max = equipmentList
                .Select(x => int.Parse(x.Id.Substring(2)))
                .Max();

            return "EQ" + (max + 1).ToString("D3");
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
    }
}