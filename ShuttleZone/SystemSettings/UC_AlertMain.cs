using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.SystemSettings
{
    public partial class UC_AlertMain : UserControl, ISaveable
    {
        private bool systemNotificationsEnabled = false;
        private bool courtAvailabilityEnabled = false;
        private bool courtOvertimeEnabled = false;
        private bool equipmentLowStockEnabled = false;
        private bool equipmentOutOfStockEnabled = false;

        public UC_AlertMain()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        // ============================================
        // INITIAL STATE
        // ============================================
        private void InitializeDefaults()
        {
            SetToggle(EnableSystemNotificationsButton, false);
            SetToggle(CourtAvailabilityChangeButton, false);
            SetToggle(CourtOvertimeAlertButton, false);
            SetToggle(EquipmentLowStockButton, false);
            SetToggle(EquipmentOutofStockButton, false);

            LowStocksThresholdsTextBox.Text = "10"; // Default threshold
        }

        // ============================================
        // TOGGLE HELPER
        // ============================================
        private void SetToggle(Control btn, bool state)
        {
            btn.BackColor = state ? Color.MediumSeaGreen : Color.Gray;
        }

        private bool Toggle(ref bool field, Control btn)
        {
            field = !field;
            SetToggle(btn, field);
            return field;
        }

        // ============================================
        // BUTTON CLICK EVENTS
        // ============================================

        private void EnableSystemNotificationsButton_Click(object sender, EventArgs e)
        {
            Toggle(ref systemNotificationsEnabled, EnableSystemNotificationsButton);
        }

        private void CourtAvailabilityChangeButton_Click(object sender, EventArgs e)
        {
            Toggle(ref courtAvailabilityEnabled, CourtAvailabilityChangeButton);
        }

        private void CourtOvertimeAlertButton_Click(object sender, EventArgs e)
        {
            Toggle(ref courtOvertimeEnabled, CourtOvertimeAlertButton);
        }

        private void EquipmentLowStockButton_Click(object sender, EventArgs e)
        {
            Toggle(ref equipmentLowStockEnabled, EquipmentLowStockButton);
        }

        private void EquipmentOutofStockButton_Click(object sender, EventArgs e)
        {
            Toggle(ref equipmentOutOfStockEnabled, EquipmentOutofStockButton);
        }

        // ============================================
        // SAVE METHOD (Called from Parent)
        // ============================================
        public void Save()
        {
            if (!int.TryParse(LowStocksThresholdsTextBox.Text, out int threshold))
                throw new Exception("Low stock threshold must be a valid number.");

            if (threshold < 0)
                throw new Exception("Threshold cannot be negative.");

            // TODO: Replace with real database save logic

            /*
             Example:
             
             AlertSettings settings = new AlertSettings
             {
                 SystemNotifications = systemNotificationsEnabled,
                 CourtAvailability = courtAvailabilityEnabled,
                 CourtOvertime = courtOvertimeEnabled,
                 EquipmentLowStock = equipmentLowStockEnabled,
                 EquipmentOutOfStock = equipmentOutOfStockEnabled,
                 LowStockThreshold = threshold
             };

             AlertRepository.Save(settings);
            */
        }

        // ============================================
        // KEEPING ALL DESIGNER METHODS
        // ============================================

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void NotificationSettingslbl_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e) { }
    }

}
