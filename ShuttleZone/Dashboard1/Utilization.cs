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
    public partial class Utilization : UserControl
    {
        public Utilization()
        {
            InitializeComponent();

            // Helper function to keep your code clean and dry
            void AddCourtLabel(string courtName, string duration, Color accentColor)
            {
                var label = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    // Styling: Court name is Bold and Colored, time is Smaller and Grey
                    Text = $"<b style='color:{ColorTranslator.ToHtml(accentColor)}; font-size:10pt;'>{courtName}</b><br/>" +
                           $"<span style='color:#7f8c8d; font-size:9pt;'>{duration} booking</span>",

                    Font = new Font("Segoe UI", 11), // Base font reduced from 11
                    Margin = new Padding(0, 0, 0, 10),
                    AutoSize = true
                };

                flowLayoutPanel1.Controls.Add(label);
            }

            // Usage
            AddCourtLabel("Court A", "3.11hr", Color.FromArgb(94, 148, 255)); // Guna Blue
            AddCourtLabel("Court B", "3.11hr", Color.FromArgb(46, 204, 113)); // Emerald Green
            AddCourtLabel("Court C", "3.11hr", Color.FromArgb(155, 89, 182)); // Amethyst Purple
            AddCourtLabel("Court D", "3.11hr", Color.FromArgb(230, 126, 34)); // Pumpkin Orange
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
