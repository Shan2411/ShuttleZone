using Guna.UI2.WinForms;
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

namespace ShuttleZone.Maintenance_Logs
{
    public partial class ChangeStatus : Form
    {
        private C_StatusButton _selectedButton;
        public static string tempStatuschange;
        private MaintenanceWindow _maintenanceWindow;
        private string courtName;

        public ChangeStatus(string courtName, MaintenanceWindow maintenanceWindow)
        {
            InitializeComponent();

            this.TopMost = true; // 🔥 keeps form always on top

            this.courtName = courtName;
            _maintenanceWindow = maintenanceWindow;

            this.courtName = courtName;
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

            // Set ComboBox state based on initial selected status
            if (_selectedButton != null &&
                _selectedButton.statusType.Equals("Operational", StringComparison.OrdinalIgnoreCase))
            {
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
            }


            // Make the form draggable
           // MakeDraggable(this);

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

            // Deselect previous button
            if (_selectedButton != null && _selectedButton != clicked)
            {
                _selectedButton.DeselectButton();
            }

            // Select new button
            clicked.SelectButton();
            _selectedButton = clicked;

            // 🔥 HANDLE COMBOBOX HERE (based on CURRENT selection)
            if (clicked.statusType.Equals("Operational", StringComparison.OrdinalIgnoreCase))
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedIndex = -1; // clear selection
                textBox1.Clear();
            }
            else
            {
                comboBox1.Enabled = true;
            }
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
        public void UpdateCourt(string newCourtName, MaintenanceWindow maintenanceWindow)
        {
            this.courtName = newCourtName;
            _maintenanceWindow = maintenanceWindow;

            label1.Text = "Change " + newCourtName + " Status";

            string status = Globals.GetCourtStatusFromDB(newCourtName);

            foreach (C_StatusButton btn in flowLayoutPanel1.Controls)
            {
                if (btn.statusType.Equals(status, StringComparison.OrdinalIgnoreCase))
                {
                    btn.SelectButton();
                    _selectedButton = btn;
                }
                else
                {
                    btn.DeselectButton();
                }
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
            string tempStatus = _selectedButton?.statusType;

            if (tempStatus != "Operational")
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    label4.Text = "Please enter a valid reason before proceeding.";
                    label4.ForeColor = Color.Red;
                    return;
                }
            }
            
            switch (courtName)
            {
                case "Court A":
                    // Update on the database function
                    //Globals.statusFromDB = _selectedButton?.statusType;

                    updateToDatabase(courtName, tempStatus);

                    try
                    {
                        MessageBox.Show("Status changed to " + Globals.statusFromDB);
                        this.Close();
                        _maintenanceWindow?.RefreshPanel();
                    }
                    catch (Exception error) { MessageBox.Show(error.Message); }
                    break;
                case "Court B":
                    updateToDatabase(courtName, tempStatus);
                    try
                    {
                        MessageBox.Show("Status changed to " + Globals.statusFromDB1);
                        this.Close();
                        _maintenanceWindow?.RefreshPanel();
                    }
                    catch (Exception error) { MessageBox.Show(error.Message); }
                    break;
                case "Court C":
                    updateToDatabase(courtName, tempStatus);
                    try
                    {
                        MessageBox.Show("Status changed to " + Globals.statusFromDB2);
                        this.Close();
                        _maintenanceWindow?.RefreshPanel();
                    }
                    catch (Exception error) { MessageBox.Show(error.Message); }
                    break;
                case "Court D":
                    updateToDatabase(courtName, tempStatus);
                    try
                    {
                        MessageBox.Show("Status changed to " + Globals.statusFromDB3);
                        this.Close();
                        _maintenanceWindow?.RefreshPanel();
                    }
                    catch (Exception error) { MessageBox.Show(error.Message); }
                    break;
                default: break;

            }
            
        }

        private void updateToDatabase(string court, string status)
        {

            try
            {

                using (MySqlConnection connection = DBconnection.GetConnection())
                {
                    string query = "UPDATE courts SET status = @status, status_reason = @reason WHERE court_name = @courtName";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@reason", comboBox1.Text + " - " + textBox1.Text);
                        cmd.Parameters.AddWithValue("@courtName", court);
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Database updated successfully.");
                    }
                }

                //This part changes the global varaible we have

                switch (court)
                {
                    case "Court A":
                        Globals.statusFromDB = status;
                        break;
                    case "Court B":
                        Globals.statusFromDB1 = status;
                        break;
                    case "Court C":
                        Globals.statusFromDB2 = status;
                        break;
                    case "Court D":
                        Globals.statusFromDB3 = status;
                        break;
                    default: break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message);

            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
