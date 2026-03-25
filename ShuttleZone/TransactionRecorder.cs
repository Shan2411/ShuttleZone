using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ShuttleZone
{
    public static class TransactionRecorder
    {
        // Uses central DatabaseConfig — change IP there, applies everywhere
        private static string ConnStr => DatabaseConfig.ConnStr;

        public static void SaveFromCart(
            string receiptNo,
            DateTime date,
            List<CartItem> cartItems,
            string paymentMethod,
            string transactionSource)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();

                    foreach (CartItem item in cartItems)
                    {
                        string incomeType = DetermineIncomeType(item.Name);
                        int?   courtId    = GetCourtId(item.Name, conn);

                        string sql = @"
                            INSERT INTO transactions
                                (receipt_no, transaction_date, transaction_time,
                                 income_type, item_name, quantity,
                                 unit_price, total_amount, payment_method, court_id, transaction_source)
                            VALUES
                                (@ReceiptNo, @Date, @Time,
                                 @IncomeType, @ItemName, @Qty,
                                 @UnitPrice, @Total, @Payment, @CourtId, @Source)";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ReceiptNo",  receiptNo);
                            cmd.Parameters.AddWithValue("@Date",       date.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Time",       date.ToString("HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@IncomeType", incomeType);
                            cmd.Parameters.AddWithValue("@ItemName",   item.Name);
                            cmd.Parameters.AddWithValue("@Qty",        item.Qty);
                            cmd.Parameters.AddWithValue("@UnitPrice",  item.Price);
                            cmd.Parameters.AddWithValue("@Total",      item.Price * item.Qty);
                            cmd.Parameters.AddWithValue("@Payment",    paymentMethod);
                            cmd.Parameters.AddWithValue("@CourtId",    (object)courtId ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Source", transactionSource); // NEW
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Warning: Transaction saved to receipt but failed to record in database.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private static string DetermineIncomeType(string itemName)
        {
            if (itemName == null) return "Other";
            string lower = itemName.ToLower();

            if (lower.Contains("court"))      return "Court";
            if (lower.Contains("racket")   ||
                lower.Contains("shuttle")  ||
                lower.Contains("shoes")    ||
                lower.Contains("equipment")||
                lower.Contains("accessor")) return "Equipment";
            if (lower.Contains("membership")||
                lower.Contains("member")   ||
                lower.Contains("plan")     ||
                lower.Contains("subscription")) return "Membership";

            return "Other";
        }

        private static int? GetCourtId(string itemName, MySqlConnection conn)
        {
            if (itemName == null || !itemName.ToLower().Contains("court"))
                return null;

            string sql = "SELECT court_id FROM courts WHERE LOCATE(court_name, @ItemName) > 0 LIMIT 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }
            return null;
        }
    }
}
