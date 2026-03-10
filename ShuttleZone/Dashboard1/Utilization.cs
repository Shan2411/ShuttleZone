using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone.Dashboard1
{
    public partial class Utilization : UserControl
    {
        // Win32 API to prevent flickering during mass control addition
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public Utilization()
        {
            InitializeComponent();

            // Enable Double Buffering on this control and the FlowPanel
            this.DoubleBuffered = true;
            EnableDoubleBuffer(flowLayoutPanel1);

            // Freeze drawing while we add the labels
            SendMessage(flowLayoutPanel1.Handle, WM_SETREDRAW, false, 0);

            try
            {
                flowLayoutPanel1.SuspendLayout();
                flowLayoutPanel1.Controls.Clear();

                // Usage with +1 Font sizes (11pt for Title, 10pt for Subtitle)
                AddCourtLabel("Court A", "3.11hr", Color.FromArgb(94, 148, 255));
                AddCourtLabel("Court B", "3.11hr", Color.FromArgb(46, 204, 113));
                AddCourtLabel("Court C", "3.11hr", Color.FromArgb(155, 89, 182));
                AddCourtLabel("Court D", "3.11hr", Color.FromArgb(230, 126, 34));
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(true);
                SendMessage(flowLayoutPanel1.Handle, WM_SETREDRAW, true, 0);
                flowLayoutPanel1.Refresh();
            }
        }

        private void AddCourtLabel(string courtName, string duration, Color accentColor)
        {
            // Converting to HTML Hex for the styling string
            string hexColor = ColorTranslator.ToHtml(accentColor);

            var label = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                // Updated sizes: Title 11pt, Duration 10pt (Increased by +1)
                Text = $"<b style='color:{hexColor}; font-size:11pt;'>{courtName}</b><br/>" +
                       $"<span style='color:#7f8c8d; font-size:10pt;'>{duration} booking</span>",

                // Base control font increased to 12
                Font = new Font("Segoe UI", 12),
                Margin = new Padding(0, 0, 0, 12),
                AutoSize = true
            };

            flowLayoutPanel1.Controls.Add(label);
        }

        private static void EnableDoubleBuffer(Control c)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);
            pi?.SetValue(c, true, null);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Event handler remains for designer compatibility
        }
    }
}
