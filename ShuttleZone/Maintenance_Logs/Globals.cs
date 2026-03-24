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

        // Front desk dashboard 
        // transac id payment amount time
        public class Transaction
        {
            public int TransactionId { get; set; }
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

                    string query = @"SELECT transaction_id, payment_method, total_amount, transaction_time 
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
                                TransactionId = Convert.ToInt32(reader["transaction_id"]),
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

        public static void getThisMonthRevenue() {

            using (MySqlConnection connection = DBconnection.GetConnection()) {
            
                string query = @"SELECT total_amount, income_type
                                FROM transactions
                                WHERE MONTH(transaction_time) = MONTH(CURRENT_DATE())
                                AND YEAR(transaction_time) = YEAR(CURRENT_DATE());";
    
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            thisMonthsRevenue = reader["MonthlyRevenue"] != DBNull.Value
                                ? Convert.ToDecimal(reader["MonthlyRevenue"])
                                : 0;
                        }
                }
            }
        
        }


    }




}
