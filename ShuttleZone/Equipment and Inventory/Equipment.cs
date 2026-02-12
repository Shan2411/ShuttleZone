using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShuttleZone.Equipment_and_Inventory
{
    public partial class Equipment : UserControl
    {
        private List<EquipmentItem> equipmentList = new List<EquipmentItem>();

        public Equipment()
        {
            InitializeComponent();
            InitializeUI();
            HookEvents();
        }

        private void InitializeUI()
        {
            // Availability filter
            cmbFilter.Items.Clear();
            cmbFilter.Items.AddRange(new object[]
            {
                "All",
                "Available",
                "Rented"
            });
            cmbFilter.SelectedIndex = 0;

            // Category filter
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All");
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
            cmbFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbCategory.SelectedIndexChanged += (s, e) => ApplyFilters();
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            dgvTable.CellContentClick += dgvTable_CellContentClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Add addForm = new Add())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    equipmentList.Add(addForm.AddedItem);
                    RefreshGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            dgvTable.Rows.Clear();

            foreach (var item in equipmentList)
            {
                dgvTable.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Category,
                    item.Total,
                    item.Available,
                    item.Rented,
                    item.Price.ToString("₱0.00"),
                    item.Status,
                    "Edit",
                    "Delete"
                );
            }

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                bool visible = true;

                string name = row.Cells["colName"].Value.ToString();
                string category = row.Cells["colCategory"].Value.ToString();
                string status = row.Cells["colStatus"].Value.ToString();

                // Search
                if (!string.IsNullOrWhiteSpace(txtSearch.Text) &&
     name.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    visible = false;
                }


                // Availability filter
                if (cmbFilter.SelectedItem.ToString() != "All" &&
                    status != cmbFilter.SelectedItem.ToString())
                {
                    visible = false;
                }

                // Category filter
                if (cmbCategory.SelectedItem.ToString() != "All" &&
                    category != cmbCategory.SelectedItem.ToString())
                {
                    visible = false;
                }

                row.Visible = visible;
            }
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvTable.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    equipmentList.RemoveAt(e.RowIndex);
                    RefreshGrid();
                }
            }

            if (dgvTable.Columns[e.ColumnIndex].Name == "colEdit")
            {
                MessageBox.Show("Edit functionality coming next 👀");
            }
        }
    }
}
