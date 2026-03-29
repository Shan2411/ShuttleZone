using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using ShuttleZone.database;

namespace ShuttleZone.SystemSettings
{
    public partial class UC_FacilityInfo : UserControl
    {
        public UC_FacilityInfo()
        {
            InitializeComponent();
            LoadFacilityInfo();
        }

        public void Save()
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = @"UPDATE facility_info SET
                    business_name = @name,
                    phone = @phone,
                    address = @address,
                    email = @email,
                    opening_time = @open,
                    closing_time = @close
                    WHERE id = 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", BusinessNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", PhoneNumberTextBox.Text);
                    cmd.Parameters.AddWithValue("@address", AddressTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@open", OpeningTimeTextBox.Text);
                    cmd.Parameters.AddWithValue("@close", ClosingTimeTextBox.Text);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadFacilityInfo()
        {
            using (var conn = DBconnection.GetConnection())
            {
                string query = "SELECT * FROM facility_info LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        BusinessNameTextBox.Text = reader["business_name"].ToString();
                        PhoneNumberTextBox.Text = reader["phone"].ToString();
                        AddressTextBox.Text = reader["address"].ToString();
                        EmailTextBox.Text = reader["email"].ToString();
                        OpeningTimeTextBox.Text = reader["opening_time"].ToString();
                        ClosingTimeTextBox.Text = reader["closing_time"].ToString();
                    }
                }
            }
        }

        private void UC_FacilityInfo_DockChanged(object sender, EventArgs e) { }
        private void guna2Panel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel6_Paint(object sender, PaintEventArgs e) { }
        private void BusinessNameTextBox_TextChanged(object sender, EventArgs e) { }
        private void EmailTextBox_TextChanged(object sender, EventArgs e) { }
    }
}