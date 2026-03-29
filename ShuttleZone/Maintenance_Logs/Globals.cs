using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;


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

        // Get multiple court status
        public static void getCourtStatuses()
        {
            using (MySqlConnection connection = DBconnection.GetConnection())
            {
 

                string query = "SELECT court_id, status FROM courts";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("court_id");
                        string status = reader.GetString("status");

                        if (id == 1) statusFromDB = status;
                        else if (id == 2) statusFromDB1 = status;
                        else if (id == 3) statusFromDB2 = status;
                        else if (id == 4) statusFromDB3 = status;
                    }
                }
            }
        }

        // Front desk dashboard 
        // transac id payment amount time   

        public static int todaysTransactions = GetTodaysTransaction();
        public static int activeRentals;
        public static string courtsInUse;

        public static int GetTodaysTransaction()
        {
            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = @"SELECT COUNT(DISTINCT receipt_no) 
                             FROM transactions 
                             WHERE DATE(transaction_time) = CURDATE();";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return 0;
            }
        }

        //this function also get sthe name of the court in use
        public static void GetActiveRentals()
        {
            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = @"SELECT 
                        COUNT(*) AS total_in_use,
                        GROUP_CONCAT(court_name SEPARATOR ', ') AS court_names
                        FROM courts
                        WHERE status = 'In Use';";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read())
                            {
                                activeRentals = reader.IsDBNull(reader.GetOrdinal("total_in_use"))
                                            ? 0
                                            : reader.GetInt32("total_in_use");

                                string names = reader.IsDBNull(reader.GetOrdinal("court_names"))
                                               ? "None"
                                               : reader.GetString("court_names");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                //return 0;
            }
        }

        public class Transaction
        {
            public string ReceiptId { get; set; }
            public string PaymentMethod { get; set; }
            public decimal TotalAmount { get; set; }
            public DateTime TransactionTime { get; set; }
        }

        public static List<Transaction> GetRecentTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    //connection.Open();

                    string query = @"SELECT receipt_no, payment_method, total_amount, transaction_time 
                             FROM transactions
                             ORDER BY transaction_time DESC
                             LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction t = new Transaction
                            {
                                ReceiptId = reader["receipt_no"].ToString(),
                                PaymentMethod = reader["payment_method"].ToString(),
                                TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                TransactionTime = reader["transaction_time"] is TimeSpan ts
                                    ? DateTime.Today.Add(ts)
                                    : Convert.ToDateTime(reader["transaction_time"])
                            };

                            transactions.Add(t);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return transactions;

        }
        public static List<Transaction> transactions = new List<Transaction>();

        // Front desk dashboard End


        // Admin Dashboard

        public static decimal courtRentals = 0;
        public static decimal equipmentRentals = 0;
        public static decimal memberships = 0;
        public static decimal thisMonthsRevenue = 0;

        public static decimal otherRevenue = 0; // add this too

        public static void getThisMonthRevenue()
        {
            using (MySqlConnection connection = DBconnection.GetConnection())
            {
                string query = @"SELECT income_type, SUM(total_amount) AS total
                         FROM transactions
                         WHERE MONTH(transaction_time) = MONTH(CURRENT_DATE())
                         AND YEAR(transaction_time) = YEAR(CURRENT_DATE())
                         GROUP BY income_type;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string incomeType = reader["income_type"].ToString();
                        decimal amount = reader["total"] != DBNull.Value
                            ? Convert.ToDecimal(reader["total"])
                            : 0;

                        switch (incomeType)
                        {
                            case "Court": courtRentals = amount; break;
                            case "Equipment": equipmentRentals = amount; break;
                            case "Membership": memberships = amount; break;
                            case "Other": otherRevenue = amount; break;
                        }
                    }
                }
            }

            thisMonthsRevenue = courtRentals + equipmentRentals + memberships + otherRevenue;
        }

        // Admin Cards 

        public static int totalTransactions = 0;
        public static decimal avgRevenue = 0;
        public static decimal todaysRevenue = 0;
        public static int activeMemberships = 0;

        public static void getThisMonthStats()
        {
            using (MySqlConnection connection = DBconnection.GetConnection())
            {
                string query = @"
            SELECT
                (SELECT COUNT(DISTINCT receipt_no) 
                 FROM transactions 
                 WHERE MONTH(transaction_time) = MONTH(CURRENT_DATE()) 
                 AND YEAR(transaction_time) = YEAR(CURRENT_DATE())) AS total_transactions,

                (SELECT AVG(total_amount) 
                 FROM transactions 
                 WHERE MONTH(transaction_time) = MONTH(CURRENT_DATE()) 
                 AND YEAR(transaction_time) = YEAR(CURRENT_DATE())) AS avg_revenue,

                (SELECT SUM(total_amount) 
                 FROM transactions 
                 WHERE DATE(transaction_time) = CURRENT_DATE()) AS todays_revenue,

                (SELECT COUNT(*) 
                 FROM members 
                 WHERE expiry_date >= CURRENT_DATE() 
                 AND is_archived = 0) AS active_memberships;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalTransactions = Convert.ToInt32(reader["total_transactions"]);
                        avgRevenue = reader["avg_revenue"] != DBNull.Value
                            ? Convert.ToDecimal(reader["avg_revenue"])
                            : 0;
                        todaysRevenue = reader["todays_revenue"] != DBNull.Value
                            ? Convert.ToDecimal(reader["todays_revenue"])
                            : 0;
                        activeMemberships = Convert.ToInt32(reader["active_memberships"]);
                    }
                }
            }
        }

        public static string peakHourTodayFormatted;

        public static void GetPeakHourToday()
        {
            using (MySqlConnection connection = DBconnection.GetConnection())
            {
                string query = @"
            SELECT HOUR(transaction_time) AS peak_hour
            FROM transactions
            WHERE DATE(transaction_time) = CURDATE()
            GROUP BY HOUR(transaction_time)
            ORDER BY COUNT(*) DESC
            LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int hour = Convert.ToInt32(result);

                        DateTime time = DateTime.Today.AddHours(hour);
                        peakHourTodayFormatted = time.ToString("h tt"); // e.g. "2 PM"
                    }
                    else
                    {
                        peakHourTodayFormatted = "No data";
                    }
                }
            }
        }

        public static int kioskTransactions() {

            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = @"SELECT COUNT(*) FROM transactions 
                             WHERE transaction_source = 'Kiosk';";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result); // Safe conversion
                    }
                }

            }

            catch (Exception ex) { 
                
                return 0; 
            
            }
        }

        //get average hours per session

        public static decimal GetAverageRentHours()
        {
            try
            {
                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = @"SELECT AVG(quantity) AS avg_hours
                             FROM transactions
                             WHERE income_type = 'Court';";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return 0;
            }
        }

        // COURT TIMERS
        public static void StartCourtTimer(int transactionId, int courtId, int quantity)
        {
            int durationMinutes = quantity * 60;

            using (var conn = DBconnection.GetConnection())
            {
                // Insert timer
                string insertQuery = @"
            INSERT INTO court_timers 
                (court_id, transaction_id, start_time, duration_minutes, end_time, time_remaining_minutes, status)
            VALUES 
                (@court_id, @transaction_id, NOW(), @duration, 
                 DATE_ADD(NOW(), INTERVAL @duration MINUTE), 
                 @duration, 'active')";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@court_id", courtId);
                    cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                    cmd.Parameters.AddWithValue("@duration", durationMinutes);
                    cmd.ExecuteNonQuery();
                }

                // Sync courts.status to 'In Use'
                string updateCourtQuery = "UPDATE courts SET status = 'In Use' WHERE court_id = @court_id";
                using (var cmd = new MySqlCommand(updateCourtQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@court_id", courtId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateAllCourtTimers()
        {
            string query = @"
        UPDATE court_timers ct
        JOIN courts c ON ct.court_id = c.court_id
        SET 
            ct.time_remaining_minutes = GREATEST(0, TIMESTAMPDIFF(MINUTE, NOW(), ct.end_time)),
            ct.status = CASE 
                            WHEN NOW() >= ct.end_time THEN 'expired' 
                            ELSE 'active' 
                         END,
            c.status = CASE 
                            WHEN NOW() >= ct.end_time THEN 'Available' 
                            ELSE 'In Use' 
                        END
        WHERE ct.status = 'active'";

            using (var conn = DBconnection.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static int GetTimeRemainingMinutes(string courtId)
        {
            string query = @"
        SELECT 
            GREATEST(0, TIMESTAMPDIFF(MINUTE, NOW(), end_time)) AS time_remaining
        FROM court_timers
        WHERE court_id = @court_id AND status = 'active'
        ORDER BY end_time DESC
        LIMIT 1";

            using (var conn = DBconnection.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@court_id", courtId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }


        // gets the price of the courts, vat, and discount from the database to use in the maintenance logs form

        public static void LoadSettingsFromDB()
        {
            try
            {
                using (MySqlConnection conn = DBconnection.GetConnection())
                {
                    // Load court price and discount
                    string courtQuery = @"
                SELECT price_per_hour, member_discount 
                FROM courts 
                LIMIT 1";

                    using (var cmd = new MySqlCommand(courtQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            courtPrice = reader["price_per_hour"].ToString();
                            mambershipDiscount = reader["member_discount"].ToString();
                        }
                    }

                    // Load membership prices
                    string membershipQuery = @"
                SELECT plan_name, price, discount_percent 
                FROM membership_prices";

                    using (var cmd = new MySqlCommand(membershipQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string plan = reader["plan_name"].ToString();

                            if (plan == "1 Month Membership")
                            {
                                membershipPrice1Month = reader["price"].ToString();
                                mambershipDiscount = reader["discount_percent"].ToString();
                            }
                            else if (plan == "12 Months Membership")
                            {
                                membershipPrice1Year = reader["price"].ToString();
                                mambershipDiscount = reader["discount_percent"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings from database:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
