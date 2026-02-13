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
using Guna.UI2.WinForms;

namespace ShuttleZone
{
    public partial class Kiosk : Form
    {
        private readonly List<CartItem> cartItems = new List<CartItem>();
        private decimal appliedDiscountPercent;
        private static readonly HashSet<string> ValidMemberCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "M#0001",
            "M#0002",
            "M#0003"
        };

        public Kiosk()
        {
            InitializeComponent();
            Load += Kiosk_Load;
            btnCourtRental.Click += BtnCourtRental_Click;
            btnEquipment.Click += BtnEquipment_Click;
            btnMembership.Click += BtnMembership_Click;
            btnCloseKiosk.Click += BtnCloseKiosk_Click;
            btnKioskApply.Click += BtnKioskApply_Click;
            btnKioskRemoveDiscount.Click += BtnKioskRemoveDiscount_Click;
        }

        private void Kiosk_Load(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_CourtRental());
            lblKioskTitle.Text = "Court Rental";
            UpdateTotals();
        }

        private void BtnCourtRental_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_CourtRental());
            lblKioskTitle.Text = "Court Rental";
        }

        private void BtnEquipment_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_Equipment());
            lblKioskTitle.Text = "Equipment";
        }

        private void BtnMembership_Click(object sender, EventArgs e)
        {
            ShowDynamicPanel(new UC_KioskMembership());
            lblKioskTitle.Text = "Membership";
        }

        private void ShowDynamicPanel(UserControl content)
        {
            pnlDynamic.Controls.Clear();
            content.Dock = DockStyle.Fill;
            pnlDynamic.Controls.Add(content);

            if (content is UC_CourtRental courtRental)
            {
                courtRental.ItemSelected += HandleItemSelected;
            }
            else if (content is UC_Equipment equipment)
            {
                equipment.ItemSelected += HandleItemSelected;
            }
            else if (content is UC_KioskMembership membership)
            {
                membership.ItemSelected += HandleItemSelected;
            }
        }

        private void BtnCloseKiosk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HandleItemSelected(object sender, KioskItemSelectedEventArgs e)
        {
            if (sender is UC_KioskMembership)
            {
                RemoveMembershipItems();
            }

            AddOrUpdateCartItem(e.Name, e.Price);
        }

        private void AddOrUpdateCartItem(string itemName, decimal price)
        {
            var existingPanel = FindCartPanel(itemName);
            if (existingPanel != null)
            {
                UpdateQty(existingPanel, 1);
                return;
            }

            flowKioskCart.Controls.Add(CloneCartItemPanel(itemName, price));
            UpdateTotals();
        }

        private void RemoveMembershipItems()
        {
            var memberships = flowKioskCart.Controls
                .OfType<Guna2Panel>()
                .Where(p => p.Controls["lblKioskItemName"]?.Text.Contains("Month") == true)
                .ToList();

            foreach (var panel in memberships)
            {
                var itemName = panel.Controls["lblKioskItemName"]?.Text;
                if (!string.IsNullOrEmpty(itemName))
                {
                    cartItems.RemoveAll(c => c.Name == itemName);
                }

                flowKioskCart.Controls.Remove(panel);
                panel.Dispose();
            }

            UpdateTotals();
        }

        private Guna2Panel FindCartPanel(string itemName)
        {
            return flowKioskCart.Controls
                .OfType<Guna2Panel>()
                .FirstOrDefault(p => p.Controls["lblKioskItemName"]?.Text == itemName);
        }

        private Guna2Panel CloneCartItemPanel(string itemName, decimal price)
        {
            cartItems.Add(new CartItem
            {
                Name = itemName,
                Qty = 1,
                Price = price
            });

            var clone = new Guna2Panel
            {
                Size = pnlKioskCartItem.Size,
                BorderRadius = pnlKioskCartItem.BorderRadius,
                FillColor = pnlKioskCartItem.FillColor,
                Margin = pnlKioskCartItem.Margin,
                ShadowDecoration = { Enabled = true },
                Visible = true
            };

            foreach (Control c in pnlKioskCartItem.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(c.GetType());
                newCtrl.Size = c.Size;
                newCtrl.Location = c.Location;
                newCtrl.Font = c.Font;
                newCtrl.Text = c.Text;
                newCtrl.Name = c.Name;
                clone.Controls.Add(newCtrl);
            }

            clone.Controls["lblKioskItemName"].Text = itemName;
            clone.Controls["lblKioskQty"].Text = "1";
            clone.Controls["lblKioskPrice"].Text = $"₱{price}";
            clone.Controls["lblKioskRowTotal"].Text = $"₱{price}";

            var btnPlus = clone.Controls["btnKioskPlus"] as Guna2Button;
            var btnMinus = clone.Controls["btnKioskMinus"] as Guna2Button;
            var btnRemove = clone.Controls["btnKioskRemove"] as Guna2Button;

            if (btnPlus != null)
            {
                btnPlus.Click += (s, e) => UpdateQty(clone, 1);
            }

            if (btnMinus != null)
            {
                btnMinus.Click += (s, e) => UpdateQty(clone, -1);
            }

            if (btnRemove != null)
            {
                btnRemove.Click += (s, e) => RemoveCartItem(clone, itemName);
            }

            return clone;
        }

        private void UpdateQty(Guna2Panel panel, int change)
        {
            var lblQty = panel.Controls["lblKioskQty"] as Guna2HtmlLabel;
            var lblPrice = panel.Controls["lblKioskPrice"] as Guna2HtmlLabel;
            var lblRowTotal = panel.Controls["lblKioskRowTotal"] as Guna2HtmlLabel;
            var lblName = panel.Controls["lblKioskItemName"] as Guna2HtmlLabel;

            if (lblQty == null || lblPrice == null || lblRowTotal == null || lblName == null)
            {
                return;
            }

            int qty = int.Parse(lblQty.Text);
            qty += change;
            if (qty < 1)
            {
                qty = 1;
            }

            lblQty.Text = qty.ToString();

            decimal price = ParsePrice(lblPrice.Text);
            lblRowTotal.Text = $"₱{qty * price}";

            var item = cartItems.FirstOrDefault(c => c.Name == lblName.Text);
            if (item != null)
            {
                item.Qty = qty;
            }

            UpdateTotals();
        }

        private void RemoveCartItem(Guna2Panel panel, string itemName)
        {
            cartItems.RemoveAll(c => c.Name == itemName);
            flowKioskCart.Controls.Remove(panel);
            panel.Dispose();
            UpdateTotals();
        }

        private void BtnKioskApply_Click(object sender, EventArgs e)
        {
            string code = txtKioskMemberCode.Text.Trim().ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a member code.");
                return;
            }

            if (!ValidMemberCodes.Contains(code))
            {
                MessageBox.Show("Invalid member code.");
                return;
            }

            appliedDiscountPercent = 0.20m;
            pnlKioskDiscountApplied.Visible = true;
            lblKioskDiscountApplied.Text = $"Member Code {code} Applied";
            txtKioskMemberCode.Text = string.Empty;
            UpdateTotals();
        }

        private void BtnKioskRemoveDiscount_Click(object sender, EventArgs e)
        {
            appliedDiscountPercent = 0m;
            pnlKioskDiscountApplied.Visible = false;
            lblKioskDiscount.Text = "₱0";
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal subtotal = cartItems.Sum(item => item.Price * item.Qty);
            decimal discountAmount = subtotal * appliedDiscountPercent;
            decimal total = subtotal - discountAmount;

            lblKioskSubtotal.Text = $"₱{subtotal}";
            lblKioskDiscount.Text = $"₱{discountAmount}";
            lblKioskTotal.Text = $"₱{total}";
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
