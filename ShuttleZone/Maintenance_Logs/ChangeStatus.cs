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

namespace ShuttleZone.Maintenance_Logs
{
    public partial class ChangeStatus : Form
    {
        private C_StatusButton _selectedButton;
        public static string tempStatuschange;
        private MaintenanceWindow _maintenanceWindow;

        public ChangeStatus(string courtName, MaintenanceWindow maintenanceWindow)
        {
            InitializeComponent();
            _maintenanceWindow = maintenanceWindow;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;


            C_StatusButton status1_button = new C_StatusButton("Operational");
            C_StatusButton status2_button = new C_StatusButton("Under Maintenance");
            C_StatusButton status3_button = new C_StatusButton("Out of Service");


            flowLayoutPanel1.Controls.Add(status1_button);
            flowLayoutPanel1.Controls.Add(status2_button);
            flowLayoutPanel1.Controls.Add(status3_button);


            status1_button.Click += CourtButton_Click;
            status2_button.Click += CourtButton_Click;
            status3_button.Click += CourtButton_Click;


            AttachClickHandlers(status1_button);
            AttachClickHandlers(status2_button);
            AttachClickHandlers(status3_button);

            // Select the button by default based on current status
            C_StatusButton[] buttons = { status1_button, status2_button, status3_button };

            foreach (var btn in buttons)
            {
                if (btn.statusType.Equals(Globals.statusFromDB, StringComparison.OrdinalIgnoreCase))
                {
                    btn.SelectButton();       // fill color + image
                    _selectedButton = btn;    // track selected
                    break;
                }
            }



            // Make the form draggable
            MakeDraggable(this);

            label1.Text = "Change " + courtName + " Status";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MakeDraggable(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                //guna2BorderlessForm1.SetDragForm(c, true); // ✅ make this control draggable
                if (c.HasChildren)
                    MakeDraggable(c); // recursively add children
            }
        }

        private void CourtButton_Click(object sender, EventArgs e)
        {
            C_StatusButton clicked = sender as C_StatusButton;
            if (clicked == null) return;
            tempStatuschange = _selectedButton?.statusType;

            if (_selectedButton != null && _selectedButton != clicked)
            {
                _selectedButton.DeselectButton();
            }

            clicked.SelectButton();
            _selectedButton = clicked;
        }

        private void AttachClickHandlers(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += (s, e) => this.OnClick(e);
                if (c.HasChildren)
                    AttachClickHandlers(c);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void guna2Button2_Click(object sender, EventArgs e)
        {
            //if (tempStatuschange == null) {MessageBox.Show("Please Select a Proper Input"); return; }
            Globals.statusFromDB = _selectedButton?.statusType;
            try {
                MessageBox.Show("Status changed to " + Globals.statusFromDB);
                this.Close();
                _maintenanceWindow?.RefreshPanel();
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
            
        }
    }
}
