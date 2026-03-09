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

            if (!string.IsNullOrEmpty(courtname))
                label1.Text = courtname;

            if (!string.IsNullOrEmpty(status))
            {
                guna2Button2.Text = status;
                countDownStarter(status);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        public void countDownStarter(string statusForColor)
        {
            // Fix label layout first
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.Height = 20;  // fixed height

            switch (statusForColor.ToLower())
            {

                case "operational":
                    guna2HtmlLabel2.Text = "Ready For Booking";

                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Operational";
                    guna2Button2.FillColor = Color.MediumSeaGreen;
                    guna2Panel1.FillColor = Color.FromArgb(202, 231, 192);
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Operational;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.available;

                    guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                case "in use":
                    guna2HtmlLabel2.Text = "In Use";

                    // PROGRESS BAR ENABLED HERE
                    guna2VProgressBar1.Visible = true;
                    guna2VProgressBar1.Maximum = 100;
                    guna2VProgressBar1.Value = 100;

                    // START COUNTDOWN
                    StartCountdown(TimeSpan.FromHours(1));

                    guna2Button2.Text = "In Use";
                    guna2HtmlLabel2.AutoSize = false;

                    guna2CirclePictureBox2.Visible = false;

                    guna2Button2.FillColor = Color.DarkBlue;
                    guna2Panel1.FillColor = Color.LightBlue;
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Operational;
                    break;

                case "under maintenance":
                    guna2HtmlLabel2.Text = "Under Maintenance";

                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Under Maintenance";
                    guna2Button2.FillColor = Color.DarkOrange;
                    guna2Panel1.FillColor = Color.Orange;
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Maintenance1;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.mechanic;

                    guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                case "out of service":
                    StopCountdown();
                    guna2HtmlLabel2.Text = "Out of Service";


                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Out of Service";
                    guna2Button2.FillColor = Color.DarkRed;
                    guna2Panel1.FillColor = Color.Red;
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Not;
                    guna2CirclePictureBox2.Image = global::ShuttleZone.Properties.Resources.unavailable;

                    guna2Panel2.Visible = false;
                    guna2VProgressBar1.Visible = false;
                    break;

                default:
                    StopCountdown();
                    guna2HtmlLabel1.Text = statusForColor;
                    guna2Panel1.FillColor = Color.Black;
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