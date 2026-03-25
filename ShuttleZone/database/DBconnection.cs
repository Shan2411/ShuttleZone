using MySql.Data.MySqlClient;

namespace ShuttleZone.database
{
    public static class DBconnection
    {
        private static readonly string connectionString = "Server=localhost;Port=3306;Database=shuttlezone;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}