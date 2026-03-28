using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuttleZone.Maintenance_Logs;
using ShuttleZone.database;
using MySql.Data.MySqlClient;

namespace ShuttleZone.Dashboard1
{

    public partial class CourtCard : UserControl
    {
        private System.Windows.Forms.Timer _countdownTimer;
        private TimeSpan _remainingTime;
        private TimeSpan _totalDuration;
        private string _courtName; // store court name for DB queries
        public string CourtName => _courtName;
        public string CurrentStatus { get; set; }

        private void EnsureTimer()
        {
            if (_countdownTimer != null) return;
            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000;
            _countdownTimer.Tick += CountdownTimer_Tick;
            try { components?.Add(_countdownTimer); } catch { }
        }

        private void StartCountdown(TimeSpan duration)
        {
            EnsureTimer();

            _totalDuration = duration;
            _remainingTime = duration;

            UpdateCountdownLabel();
            UpdateProgressBar();

            _countdownTimer.Start();
        }

        private void StopCountdown()
        {
            if (_countdownTimer == null) return;
            _countdownTimer.Stop();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (_remainingTime <= TimeSpan.Zero)
            {
                StopCountdown();
                ExpireCourtTimer();                  // sets court_timers.status = 'expired'
                UpdateCourtStatus("Operational");    // sets courts.status = 'Operational' in DB
                countDownStarter("operational");     // redraws card UI
                return;
            }

            _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));

            if ((int)_remainingTime.TotalSeconds % 60 == 0)
                SaveTimeRemainingToDB();

            UpdateCountdownLabel();
            UpdateProgressBar();
        }

        private void UpdateCountdownLabel()
        {
            guna2HtmlLabel1.Text = _remainingTime.ToString("hh\\:mm\\:ss");
        }

        private void UpdateProgressBar()
        {
            if (_totalDuration.TotalSeconds == 0) return;

            double percent = (_remainingTime.TotalSeconds / _totalDuration.TotalSeconds) * 100.0;
            guna2VProgressBar1.Value = (int)Math.Max(0, Math.Min(100, percent));
        }

        // ── DB HELPERS ────────────────────────────────────────────────────────

        /// <summary>
        /// Gets the active timer for this court from court_timers.
        /// Returns (totalDuration, remainingTime) or null if no active timer.
        /// </summary>
        private (TimeSpan total, TimeSpan remaining)? GetActiveTimerFromDB()
        {
            string query = @"
                SELECT 
                    duration_minutes,
                    GREATEST(0, TIMESTAMPDIFF(SECOND, NOW(), end_time)) AS seconds_left
                FROM court_timers
                WHERE court_id = (SELECT court_id FROM courts WHERE court_name = @court_name LIMIT 1)
                  AND status = 'active'
                ORDER BY start_time DESC
                LIMIT 1";

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_name", _courtName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int durationMinutes = reader.GetInt32("duration_minutes");
                            int secondsLeft = reader.GetInt32("seconds_left");

                            return (
                                TimeSpan.FromMinutes(durationMinutes),
                                TimeSpan.FromSeconds(secondsLeft)
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Timer load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        /// <summary>
        /// Saves current time_remaining_minutes to court_timers every minute.
        /// </summary>
        private void SaveTimeRemainingToDB()
        {
            string query = @"
                UPDATE court_timers
                SET time_remaining_minutes = @remaining
                WHERE court_id = (SELECT court_id FROM courts WHERE court_name = @court_name LIMIT 1)
                  AND status = 'active'
                ORDER BY start_time DESC
                LIMIT 1";

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@remaining", (int)_remainingTime.TotalMinutes);
                    cmd.Parameters.AddWithValue("@court_name", _courtName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { /* silent fail — non-critical */ }
        }

        /// <summary>
        /// Marks the active timer as expired when countdown hits 0.
        /// </summary>
        private void ExpireCourtTimer()
        {
            string query = @"
                UPDATE court_timers
                SET status = 'expired', time_remaining_minutes = 0
                WHERE court_id = (SELECT court_id FROM courts WHERE court_name = @court_name LIMIT 1)
                  AND status = 'active'";

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_name", _courtName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { /* silent fail */ }
        }

        /// <summary>
        /// Updates courts.status to keep it in sync with the timer.
        /// </summary>
        private void UpdateCourtStatus(string newStatus)
        {
            string query = "UPDATE courts SET status = @status WHERE court_name = @court_name";

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@court_name", _courtName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { /* silent fail */ }
        }

        // ── CONSTRUCTOR ───────────────────────────────────────────────────────

        public CourtCard(string courtname, string status)
        {
            InitializeComponent();

            _courtName = courtname; // store for DB queries

            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.Height = 20;


            string statusFromDB = Globals.GetCourtStatusFromDB(courtname);

            if (!string.IsNullOrEmpty(courtname))
                label1.Text = courtname;

            if (!string.IsNullOrEmpty(statusFromDB))
            {
                guna2Button2.Text = statusFromDB;
                countDownStarter(statusFromDB);
            }
        }

        // ── DB HELPER: Fetch status_reason from courts table ─────────────────────
        private string GetStatusReasonFromDB()
        {
            string query = "SELECT status_reason FROM courts WHERE court_name = @court_name LIMIT 1";
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_name", _courtName);
                    var result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value)
                        ? result.ToString()
                        : null;
                }
            }
            catch { return null; }
        }

        // ── STATUS SWITCH ─────────────────────────────────────────────────────────
        private string _lastStatus = "";
        public void countDownStarter(string statusForColor)
        {
            bool statusChanged = _lastStatus != statusForColor;

            // Always check if timer needs starting for "in use", regardless of _lastStatus
            if (statusForColor.ToLower() == "in use")
            {
                // Start timer if not already running — this must ALWAYS be checked
                if (_countdownTimer == null || !_countdownTimer.Enabled)
                {
                    guna2HtmlLabel1.Visible = true;
                    guna2VProgressBar1.Visible = true;
                    guna2VProgressBar1.Maximum = 100;

                    var timerData = GetActiveTimerFromDB();
                    if (timerData.HasValue)
                    {
                        _totalDuration = timerData.Value.total;
                        StartCountdown(timerData.Value.remaining);
                    }
                    else
                    {
                        StartCountdown(TimeSpan.FromHours(1));
                    }
                }

                // Only redraw UI colors/labels if status actually changed
                if (!statusChanged) return;

                _lastStatus = statusForColor;
                guna2HtmlLabel2.Text = "Time Remaining:";
                guna2HtmlLabel2.AutoSize = false;
                guna2HtmlLabel2.Visible = true;

                guna2Button2.Text = "In Use";
                guna2Button2.FillColor = Color.FromArgb(40, 90, 175);
                guna2Button2.BorderColor = Color.FromArgb(20, 55, 130);
                guna2Panel1.FillColor = Color.FromArgb(100, 160, 255);
                guna2Panel1.BorderColor = Color.FromArgb(40, 90, 175);

                guna2CirclePictureBox2.Visible = true;
                guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.inuse;
                return;
            }

            // For all other statuses — skip if unchanged
            if (!statusChanged) return;
            _lastStatus = statusForColor;

            switch (statusForColor.ToLower())
            {
                case "operational":
                    guna2HtmlLabel2.Text = "Ready For Booking";
                    guna2HtmlLabel1.Visible = false;
                    guna2Button2.Text = "Operational";

                    guna2Button2.FillColor = Color.FromArgb(75, 120, 60);
                    guna2Button2.BorderColor = Color.FromArgb(45, 80, 35);
                    guna2Panel1.FillColor = Color.FromArgb(150, 205, 135);
                    guna2Panel1.BorderColor = Color.FromArgb(75, 120, 60);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Operational;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.available;
                    guna2VProgressBar1.Visible = false;
                    break;

                case "under maintenance":
                    guna2HtmlLabel1.Visible = false;
                    guna2Button2.Text = "Maintenance";

                    guna2Button2.FillColor = Color.FromArgb(175, 130, 20);
                    guna2Button2.BorderColor = Color.FromArgb(130, 90, 10);
                    guna2Panel1.FillColor = Color.FromArgb(255, 210, 80);
                    guna2Panel1.BorderColor = Color.FromArgb(175, 130, 20);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Maintenance1;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.mechanic;
                    guna2VProgressBar1.Visible = false;

                    string maintReason = GetStatusReasonFromDB();
                    guna2HtmlLabel2.Text = !string.IsNullOrEmpty(maintReason)
                        ? $"Reason: {maintReason}"
                        : "Reason: N/A";
                    break;

                case "out of service":
                    StopCountdown();
                    guna2HtmlLabel1.Visible = false;
                    guna2Button2.Text = "Out of Service";

                    guna2Button2.FillColor = Color.FromArgb(175, 50, 50);
                    guna2Button2.BorderColor = Color.FromArgb(130, 25, 25);
                    guna2Panel1.FillColor = Color.FromArgb(255, 120, 120);
                    guna2Panel1.BorderColor = Color.FromArgb(175, 50, 50);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Not;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.unavailable;
                    guna2VProgressBar1.Visible = false;

                    string oosReason = GetStatusReasonFromDB();
                    guna2HtmlLabel2.Text = !string.IsNullOrEmpty(oosReason)
                        ? $"Reason: {oosReason}"
                        : "Reason: N/A";
                    break;

                default:
                    StopCountdown();
                    guna2HtmlLabel1.Text = statusForColor;
                    guna2Panel1.FillColor = Color.FromArgb(40, 40, 40);
                    guna2Panel1.BorderColor = Color.FromArgb(20, 20, 20);
                    break;
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void guna2VProgressBar1_ValueChanged(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}