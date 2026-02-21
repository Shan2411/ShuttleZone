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
            HookEvents();
        }

        // =========================
        // EVENT HOOKING
        // =========================
        private void HookEvents()
        {
            btnAdd.Click += btnAdd_Click;
            txtSearch.TextChanged += (s, e) => ApplySearch();
            dgvTable.CellContentClick += dgvTable_CellContentClick;
        }

        // =========================
        // ADD BUTTON
        // =========================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (Add addForm = new Add())   // No parameter constructor
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    equipmentList.Add(addForm.NewEquipment);
                    RefreshGrid();
                }
            }
        }

        // =========================
        // REFRESH GRID
        // =========================
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

            ApplySearch();
        }

        // =========================
        // SMART SEARCH (ONLY FILTER)
        // =========================
        private void ApplySearch()
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                string id = row.Cells["colId"].Value?.ToString().ToLower() ?? "";
                string name = row.Cells["colName"].Value?.ToString().ToLower() ?? "";
                string category = row.Cells["colCategory"].Value?.ToString().ToLower() ?? "";

                if (!string.IsNullOrEmpty(searchText))
                {
                    if (!id.Contains(searchText) &&
                        !name.Contains(searchText) &&
                        !category.Contains(searchText))
                    {
                        visible = false;
                    }
                }

                row.Visible = visible;
            }
        }

        // =========================
        // EDIT / DELETE
        // =========================
        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvTable.Columns[e.ColumnIndex].Name;

            if (columnName == "colDelete")
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
            else if (columnName == "colEdit")
            {
                MessageBox.Show("Edit functionality coming next 👀");
            } 
        }
            private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Leave empty
        }
    }
    }
