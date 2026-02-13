using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ShuttleZone
{
    public partial class UC_Equipment : UserControl
    {
        public event EventHandler<KioskItemSelectedEventArgs> ItemSelected;

        public UC_Equipment()
        {
            InitializeComponent();
            RegisterEquipmentPanel(pnlKioskEquip1, lblKioskEquip1, lblKioskEquip1Price, lblEquip1Availability);
            RegisterEquipmentPanel(pnlKioskEquip2, lblKioskEquip2, lblKioskEquip2Price, lblKioskEquip2Availability);
            RegisterEquipmentPanel(pnlKioskEquip3, lblKioskEquip3, lblKioskEquip3Price, lblKioskEquip3Availability);
            RegisterEquipmentPanel(pnlKioskEquip4, lblKioskEquip4, lblKioskEquip4Price, lblKioskEquip4Availability);
        }

        private void RegisterEquipmentPanel(Guna.UI2.WinForms.Guna2Panel panel, Guna.UI2.WinForms.Guna2HtmlLabel nameLabel, Guna.UI2.WinForms.Guna2HtmlLabel priceLabel, Guna.UI2.WinForms.Guna2HtmlLabel availabilityLabel)
        {
            EventHandler handler = (s, e) =>
            {
                ItemSelected?.Invoke(this, new KioskItemSelectedEventArgs(nameLabel.Text, ParsePrice(priceLabel.Text)));
            };

            panel.Click += handler;
            nameLabel.Click += handler;
            priceLabel.Click += handler;
            availabilityLabel.Click += handler;
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
