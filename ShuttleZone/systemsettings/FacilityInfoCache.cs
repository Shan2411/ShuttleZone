using ShuttleZone.database;
using MySql.Data.MySqlClient;

namespace ShuttleZone
{
    public static class FacilityInfoCache
    {
        public static string BusinessName { get; private set; } = "Shuttle Zone";
        public static string Address { get; private set; } = "";
        public static string Phone { get; private set; } = "";
        public static string Email { get; private set; } = "";

        public static void Load()
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT * FROM facility_info LIMIT 1", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        BusinessName = reader["business_name"].ToString();
                        Address = reader["address"].ToString();
                        Phone = reader["phone"].ToString();
                        Email = reader["email"].ToString();
                    }
                }
            }
            catch { /* fallback to defaults */ }
        }

        // Call this after saving in UC_FacilityInfo so receipt stays in sync
        public static void Reload() => Load();
    }
}