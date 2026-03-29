using ShuttleZone.Maintenance_Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    public partial class UC_CourtRental : UserControl
    {
        public event EventHandler<KioskItemSelectedEventArgs> ItemSelected;

        public UC_CourtRental()
        {

            Globals.LoadSettingsFromDB();

            InitializeComponent();
            btnKioskStartRental.Click += BtnKioskStartRental_Click;

            // Pull court price from Globals into the label
            if (decimal.TryParse(Globals.courtPrice, out decimal price))
                lblKioskCourtPrice.Text = $"₱{price}";
        }

        private void BtnKioskStartRental_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, new KioskItemSelectedEventArgs(lblBadmintonCourt.Text, ParsePrice(lblKioskCourtPrice.Text)));
        }

        private decimal ParsePrice(string value)
        {
            decimal price;
            if (decimal.TryParse(value.Replace("₱", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
            {
                return price;
            }

            return 0;
        }
    }
}
