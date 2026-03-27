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

            timer1.Interval = 3100;
            timer1.Tick += new System.EventHandler(timer1_Tick); // force wire it here
            timer1.Start();
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            LoadPendingCards();
        }

        private void LoadPendingCards()
        {
            // Properly dispose old cards before clearing
            for (int i = flpPendingRoot.Controls.Count - 1; i >= 0; i--)
            {
                flpPendingRoot.Controls[i].Dispose();
            }
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

            guna2HtmlLabel2.Text = stubs.Count.ToString();
        }
    }
}