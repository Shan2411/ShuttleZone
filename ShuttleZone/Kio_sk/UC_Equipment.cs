using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShuttleZone.database;
using ShuttleZone.Kio_sk;

namespace ShuttleZone
{
    public partial class UC_Equipment : UserControl
    {
        public event EventHandler<KioskItemSelectedEventArgs> ItemSelected;

        public UC_Equipment()
        {
            InitializeComponent();
            SetupFlowLayoutPanel();
            LoadEquipmentFromDatabase();
        }

        public void RefreshEquipment()
        {
            LoadEquipmentFromDatabase();
        }

        private void SetupFlowLayoutPanel()
        {
            tlpEquipmentRoot.FlowDirection = FlowDirection.TopDown;
            tlpEquipmentRoot.WrapContents = false;
            tlpEquipmentRoot.AutoScroll = true;
            tlpEquipmentRoot.Padding = new Padding(10);
        }

        private void LoadEquipmentFromDatabase()
        {
            tlpEquipmentRoot.Controls.Clear();

            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    using (var cmd = new MySqlCommand(
                        "SELECT * FROM equipment WHERE Category IN ('Rackets', 'Shuttlecocks', 'Grip Tape', 'Towel') AND Available > 0", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int available = Convert.ToInt32(reader["Available"]);
                                string category = reader["Category"].ToString();

                                // Skip items with 0 stock
                                if (available <= 0) continue;

                                UC_EquipmentRow row = new UC_EquipmentRow
                                {
                                    EquipmentNameText = name,
                                    PriceText = $"₱{price:0.00}",
                                    CategoryText = category,
                                    AvailableStock = available,
                                    StockText = $"Stock: {available}"
                                };

                                row.InitializeRowEvents();

                                row.RowClicked += (s, e) =>
                                {
                                    ItemSelected?.Invoke(this, new KioskItemSelectedEventArgs(name, price));
                                };

                                tlpEquipmentRoot.Controls.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading equipment: " + ex.Message);
            }
        }
    }
}