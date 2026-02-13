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
    public partial class UC_KioskMembership : UserControl
    {
        public event EventHandler<KioskItemSelectedEventArgs> ItemSelected;

        public UC_KioskMembership()
        {
            InitializeComponent();
            RegisterMembershipPanel(pnlKioskMembership1, lblKioskMembership1, lblKioskMembership1Price, lblKioskMembership1Desc);
            RegisterMembershipPanel(pnlKioskMembership2, lblKioskMembership2, lblKioskMembership2Price, lblKioskMembership2Desc);
        }

        private void RegisterMembershipPanel(Guna.UI2.WinForms.Guna2Panel panel, Guna.UI2.WinForms.Guna2HtmlLabel nameLabel, Guna.UI2.WinForms.Guna2HtmlLabel priceLabel, Guna.UI2.WinForms.Guna2HtmlLabel descriptionLabel)
        {
            EventHandler handler = (s, e) =>
            {
                ItemSelected?.Invoke(this, new KioskItemSelectedEventArgs(nameLabel.Text, ParsePrice(priceLabel.Text)));
            };

            panel.Click += handler;
            nameLabel.Click += handler;
            priceLabel.Click += handler;
            descriptionLabel.Click += handler;
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
