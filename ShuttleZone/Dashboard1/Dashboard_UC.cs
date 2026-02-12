using Guna.UI2.WinForms;
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

namespace ShuttleZone.Dashboard1
{
    public partial class Dashboard_UC : UserControl
    {
        public Dashboard_UC()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();

            int cardCount = 4;

            // Add cards 
            string[] titles = { "Daily Sales", "Active Rentals", "Available Equipments", "Available Courts" };

            foreach (var title in titles)
            {
                var card = new Card_Dashboard(title);
                card.Height = flowLayoutPanel1.ClientSize.Height;             
                card.Width = flowLayoutPanel1.ClientSize.Width / cardCount;  // divide width equally
                card.Margin = new Padding(0);                                 // no margin to prevent overflow
                flowLayoutPanel1.Controls.Add(card);
            }

            // so cards stay equal width
            flowLayoutPanel1.Resize += (s, ev) =>
            {
                int count = flowLayoutPanel1.Controls.Count;
                if (count == 0) return;
                int width = flowLayoutPanel1.ClientSize.Width / count;
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    ctrl.Width = width;
                    ctrl.Height = 160; 
                }
            };

            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }




        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void equipmentAlerts1_Load(object sender, EventArgs e)
        {

        }
    }
}
