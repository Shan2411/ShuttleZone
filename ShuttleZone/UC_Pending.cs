using MySql.Data.MySqlClient;
using ShuttleZone.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_Pending : UserControl
    {
        public UC_Pending()
        {
            InitializeComponent();
            LoadPendingCards();
        }

        private void LoadPendingCards()
        {
            flpPendingRoot.Controls.Clear();

            var stubs = new List<string>();

            using (var conn = DBconnection.GetConnection())
            {
                string query = @"SELECT stub_no 
                                 FROM kiosk_pending_payments 
                                 GROUP BY stub_no 
                                 ORDER BY MIN(id)";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        stubs.Add(reader.GetString("stub_no"));
                }
            }

            foreach (string stub in stubs)
            {
                var card = new UC_PendingCard(stub);
                flpPendingRoot.Controls.Add(card);
            }
        }
    }
}
