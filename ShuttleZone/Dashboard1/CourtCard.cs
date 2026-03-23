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

        // NEW: store total duration so progress bar can calculate percentage
        private TimeSpan _totalDuration;

        private void EnsureTimer()
        {
            if (_countdownTimer != null) return;
            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000; // 1 second
            _countdownTimer.Tick += CountdownTimer_Tick;
            try { components?.Add(_countdownTimer); } catch { }
        }

        private void StartCountdown(TimeSpan duration)
        {
            EnsureTimer();

            _totalDuration = duration;
            _remainingTime = duration;

            UpdateCountdownLabel();
            UpdateProgressBar();  // NEW

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
                countDownStarter("operational");
                return;
            }

            _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));

            UpdateCountdownLabel();
            UpdateProgressBar();  // NEW
        }

        private void UpdateCountdownLabel()
        {
            guna2HtmlLabel1.Text = _remainingTime.ToString("hh\\:mm\\:ss");
        }

        // NEW: updates the vertical progress bar (0–100%)
        private void UpdateProgressBar()
        {
            if (_totalDuration.TotalSeconds == 0) return;

            double percent = (_remainingTime.TotalSeconds / _totalDuration.TotalSeconds) * 100.0;

            guna2VProgressBar1.Value = (int)Math.Max(0, Math.Min(100, percent));
        }

        public CourtCard(string courtname, string status)
        {
            InitializeComponent();

            string statusFromDB = Globals.GetCourtStatusFromDB(courtname);

            if (!string.IsNullOrEmpty(courtname))
                label1.Text = courtname;

            if (!string.IsNullOrEmpty(statusFromDB))
            {
                guna2Button2.Text = statusFromDB;
                countDownStarter(statusFromDB);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        public void countDownStarter(string statusForColor)
        {
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.Height = 20;

            switch (statusForColor.ToLower())
            {
                case "operational":
                    guna2HtmlLabel2.Text = "Ready For Booking";
                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Operational";

                    guna2Button2.FillColor = Color.FromArgb(75, 120, 60);      // dark green button
                    guna2Button2.BorderColor = Color.FromArgb(45, 80, 35);       // even darker border
                    guna2Panel1.FillColor = Color.FromArgb(150, 205, 135);    // light green panel
                    guna2Panel1.BorderColor = Color.FromArgb(75, 120, 60);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Operational;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.available;
                    //guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                case "in use":
                    guna2HtmlLabel2.Text = "Time Remaining:";
                    guna2HtmlLabel2.AutoSize = false;
                    guna2VProgressBar1.Visible = true;
                    guna2VProgressBar1.Maximum = 100;
                    guna2VProgressBar1.Value = 100;
                    StartCountdown(TimeSpan.FromHours(1));

                    guna2Button2.Text = "In Use";
                    guna2Button2.FillColor = Color.FromArgb(40, 90, 175);      // dark blue button
                    guna2Button2.BorderColor = Color.FromArgb(20, 55, 130);      // even darker border
                    guna2Panel1.FillColor = Color.FromArgb(100, 160, 255);    // light blue panel
                    guna2Panel1.BorderColor = Color.FromArgb(40, 90, 175);

                    guna2CirclePictureBox2.Visible = true;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.inuse;
                    break;

                case "under maintenance":
                    guna2HtmlLabel2.Text = "Reason: Cleaning";
                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Maintenance";

                    guna2Button2.FillColor = Color.FromArgb(175, 130, 20);     // dark yellow button
                    guna2Button2.BorderColor = Color.FromArgb(130, 90, 10);      // even darker border
                    guna2Panel1.FillColor = Color.FromArgb(255, 210, 80);     // light yellow panel
                    guna2Panel1.BorderColor = Color.FromArgb(175, 130, 20);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Maintenance1;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.mechanic;
                    //guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                case "out of service":
                    StopCountdown();
                    guna2HtmlLabel2.Text = "Reason: Wrecked Floors";
                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Out of Service";

                    guna2Button2.FillColor = Color.FromArgb(175, 50, 50);      // dark red button
                    guna2Button2.BorderColor = Color.FromArgb(130, 25, 25);      // even darker border
                    guna2Panel1.FillColor = Color.FromArgb(255, 120, 120);    // light red panel
                    guna2Panel1.BorderColor = Color.FromArgb(175, 50, 50);

                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Not;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.unavailable;
                    //guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                default:
                    StopCountdown();
                    guna2HtmlLabel1.Text = statusForColor;
                    guna2Panel1.FillColor = Color.FromArgb(40, 40, 40);
                    guna2Panel1.BorderColor = Color.FromArgb(20, 20, 20);
                    break;
            }
        }


        private void guna2VProgressBar1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}