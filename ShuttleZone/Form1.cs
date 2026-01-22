using System;
using System.Windows.Forms;
using ShuttleZone.Maintenance_Logs;
namespace ShuttleZone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            Maintenance_Logs.MaintenanceWindow maintenanceWindow = new Maintenance_Logs.MaintenanceWindow();
            MainContentPanel.Controls.Add(maintenanceWindow);
            maintenanceWindow.Dock = DockStyle.Fill;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set current date to label
            DateLbl.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");


        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DateLbl_Click(object sender, EventArgs e)
        {
            // Optional: leave empty or remove
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void MainContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
           
        }


        private void DashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("membership clicked");
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dashboard clicked");
        }

        private void PosBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("pos clicked");
        }

        private void RentalBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("rental clicked");
        }

        private void EquipmentBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("equipment clicked");
        }

        private void SysSettingsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("settings clicked");
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("user clicked");
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("reports clicked");
        }

        private void MaintenanceBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("maintenance clicked");
        }
    }
}
