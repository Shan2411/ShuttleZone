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

        private void EnsureTimer()
        {
            if (_countdownTimer != null) return;
            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000; // 1 second
            _countdownTimer.Tick += CountdownTimer_Tick;
            // add to components container so it gets disposed with the control (components is in designer partial)
            try { components?.Add(_countdownTimer); } catch { }
        }

        private void StartCountdown(TimeSpan duration)
        {
            EnsureTimer();
            _remainingTime = duration;
            UpdateCountdownLabel();
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
                // When time is up, switch to operational UI
                countDownStarter("operational");
                return;
            }

            _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));
            UpdateCountdownLabel();
        }

        private void UpdateCountdownLabel()
        {
            // show hh:mm:ss
            guna2HtmlLabel1.Text = _remainingTime.ToString("hh\\:mm\\:ss");
        }

        public CourtCard(string courtname, string status)
        {
            InitializeComponent();

            // apply passed values to the UI
            if (!string.IsNullOrEmpty(courtname))
                label1.Text = courtname;

            if (!string.IsNullOrEmpty(status))
            {
                // show the raw status on the small button
                guna2Button2.Text = status;
                // adjust colors / text according to status
                countDownStarter(status);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        public void countDownStarter(string statusForColor)
        {
            switch (statusForColor.ToLower())
            {
                case "operational":
                    guna2HtmlLabel2.Text = "Ready For Booking";

                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Operational";
                    guna2Button2.FillColor = Color.MediumSeaGreen;
                    guna2Panel1.FillColor = Color.FromArgb(202, 231, 192);
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Operational;

                    guna2VProgressBar1.Visible = false;
                    break;

                case "in use":
                    // start 1 hour countdown and update label every second
                    guna2HtmlLabel2.Text = "In Use";
                    StartCountdown(TimeSpan.FromHours(1));

                    // set button and colors
                    guna2Button2.Text = "In Use";

                    guna2HtmlLabel2.AutoSize = false;
                    //guna2HtmlLabel2.Height = 54;


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

                    guna2VProgressBar1.Visible = false;
                    break;

                case "out of service":
                    // stop any countdown when not in use
                    StopCountdown();
                    guna2HtmlLabel2.Text = "Out of Service";

                    guna2HtmlLabel1.Text = "";
                    guna2Button2.Text = "Out of Service";
                    guna2Button2.FillColor = Color.DarkRed;
                    guna2Panel1.FillColor = Color.Red;
                    guna2CirclePictureBox1.Image = global::ShuttleZone.Properties.Resources.Not;

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
    }
}
