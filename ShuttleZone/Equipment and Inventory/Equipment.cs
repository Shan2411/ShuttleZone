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

        // ===============================
        // INITIALIZE UI
        // ===============================
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

            // Availability filter
            cmbFilter.Items.AddRange(new object[] { "All", "Available", "Rented" });
            cmbFilter.SelectedIndex = 0;

            // Category filter
            if (cmbCategory.Items.Count == 0)
            {
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
        }

        private void HookEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbCategory.SelectedIndexChanged += (s, e) => ApplyFilters();
        }

        // ===============================
        // AUTO ID GENERATOR
        // ===============================
        private string GenerateNextId()
        {
            if (equipmentList.Count == 0)
                return "EQ001";

            int maxNumber = equipmentList
                .Select(x => int.Parse(x.Id.Substring(2)))
                .Max();

            return "EQ" + (maxNumber + 1).ToString("D3");
        }

        // ===============================
        // ADD BUTTON
        // ===============================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newId = GenerateNextId();

            Add addForm = new Add(newId);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                equipmentList.Add(addForm.NewEquipment);
                RefreshGrid();
            }
        }


        // ===============================
        // GRID REFRESH
        // ===============================
        private void RefreshGrid()
        {
            dgvTable.DataSource = null;
            dgvTable.DataSource = equipmentList;
        }

        // ===============================
        // FILTER LOGIC
        // ===============================
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
                    !name.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    visible = false;
                }

                // Availability
                if (cmbFilter.SelectedItem.ToString() != "All" &&
                    status != cmbFilter.SelectedItem.ToString())
                {
                    visible = false;
                }

                // Category
                if (cmbCategory.SelectedItem.ToString() != "All" &&
                    category != cmbCategory.SelectedItem.ToString())
                {
                    visible = false;
                }

                row.Visible = visible;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}