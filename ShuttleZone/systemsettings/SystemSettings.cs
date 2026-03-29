using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;

namespace ShuttleZone.SystemSettings
{
    public static class SettingsService
    {
        public static SettingsModel Load()
        {
            SettingsModel settings = new SettingsModel();

            using (MySqlConnection conn = DBconnection.GetConnection())
            {
                string query = "SELECT * FROM system_settings LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        settings.BusinessName = reader["business_name"]?.ToString();
                        settings.Address = reader["address"]?.ToString();
                        settings.Phone = reader["phone"]?.ToString();
                        settings.Email = reader["email"]?.ToString();
                        settings.CurrencySymbol = reader["currency_symbol"]?.ToString() ?? "₱";

                        settings.LowStockThreshold =
                            reader["low_stock_threshold"] != DBNull.Value
                            ? Convert.ToInt32(reader["low_stock_threshold"])
                            : 10;
                    }
                }
            }

            return settings;
        }

        public static void Save(SettingsModel settings)
        {
            using (MySqlConnection conn = DBconnection.GetConnection())
            {
                string query = @"UPDATE system_settings SET
                                business_name=@name,
                                address=@address,
                                phone=@phone,
                                email=@email,
                                currency_symbol=@currency,
                                low_stock_threshold=@threshold
                                WHERE id = 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", settings.BusinessName);
                    cmd.Parameters.AddWithValue("@address", settings.Address);
                    cmd.Parameters.AddWithValue("@phone", settings.Phone);
                    cmd.Parameters.AddWithValue("@email", settings.Email);
                    cmd.Parameters.AddWithValue("@currency", settings.CurrencySymbol);
                    cmd.Parameters.AddWithValue("@threshold", settings.LowStockThreshold);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}