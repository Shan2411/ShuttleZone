using Mysqlx.Connection;
using ShuttleZone.Maintenance_Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuttleZone.database;
using MySql.Data.MySqlClient;

namespace ShuttleZone.Dashboard1
{
    public partial class CourtInUse : UserControl
    {
        public CourtInUse()
        {
            // Enable double buffering BEFORE InitializeComponent
            this.DoubleBuffered = true;

            InitializeComponent();

            // SUSPEND LAYOUT - CRITICAL for performance
            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            // Configure panel once
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false; // If horizontal layout

            // Clear once
            flowLayoutPanel1.Controls.Clear();

            // Add all controls at once
            var buttons = new[]
            {
                new CourtCardInUse("Court A", Globals.statusFromDB),
                new CourtCardInUse("Court B", Globals.statusFromDB1),
                new CourtCardInUse("Court C", Globals.statusFromDB2),
                new CourtCardInUse("Court D", Globals.statusFromDB3)
            };

            flowLayoutPanel1.Controls.AddRange(buttons);

            // RESUME LAYOUT
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout(); // Force final layout

            //Text for how much of the court is currently used

            // TOBE CONTINUED..
            /*
            using (MySqlConnection connection = DBconnection.GetConnection())
            {
                // Your query: count rows with a specific status
                string query = "SELECT COUNT(*) FROM courts WHERE status = @status";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Set the parameter value
                    cmd.Parameters.AddWithValue("@status", "Operational");

                    // Open connection
                    connection.Open();

                    // Execute the query and get the count
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    Console.WriteLine($"Number of courts with status 'Operational': {count}");
                }
            }
            */

        }
    }
}
