using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuttleZone.database
{
    public static class DBconnection
    {

        private static readonly string connectionString = "Server=localhost;Port=3306;Database=Shuttlezone;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
