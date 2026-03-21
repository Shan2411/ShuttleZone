using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ShuttleZone.database;


namespace ShuttleZone.Maintenance_Logs
{
    public static class Globals
    {
        public static string CurrentCourtStatus;
        public static string CurrentCourtName;
        public static string statusFromDB = " YOU NEED DATABASE OPENED";
        public static string statusFromDB1 = "Operational";
        public static string statusFromDB2 = "out of service";
        public static string statusFromDB3 = "under maintenance";

        public static string courtPrice = "250";
        public static string vat = "2";
        //600, 4500
        public static string membershipPrice1Month = "600";
        public static string membershipPrice1Year = "4500";
        public static string mambershipDiscount = "20";

        //dashbord
        public static decimal thisMonthsRevenue = 0;

        public static string GetCourtStatusFromDB(string court)
        {
            try
            {

                using (MySqlConnection connection = DBconnection.GetConnection())
                {
               
                    // ✅ Use @court parameter instead of string interpolation
                    string query = "SELECT status FROM courts WHERE court_name = @court";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@court", court);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString("status");
                            }
                            else
                            {
                                return "Unknown";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching court status: {ex.Message}");
                return "Error";
            }
        }
    }

}
