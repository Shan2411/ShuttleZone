using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;


namespace ShuttleZone
{
    public partial class UC_Pos : UserControl
    {
        private decimal appliedDiscountPercent = 0;

        private List<CartItem> CartItems = new List<CartItem>();


        public UC_Pos()
        {
            InitializeComponent();
        }

        private void UC_Pos_Load(object sender, EventArgs e)
        {
            pnlEquipment1.Click += Equipment_Click;
            pnlEquipment2.Click += Equipment_Click;
            pnlEquipment3.Click += Equipment_Click;
            pnlEquipment4.Click += Equipment_Click;

            pnlEquipment1.Tag = "Racket";
            pnlEquipment2.Tag = "Shuttlecock Pack";
            pnlEquipment3.Tag = "Grip Tape";
            pnlEquipment4.Tag = "Towel";

            // Membership panels
            pnlMembership1.Click += Membership_Click;
            pnlMembership2.Click += Membership_Click;

            // Set membership names
            pnlMembership1.Tag = "1 Month Membership";
            pnlMembership2.Tag = "12 Months Membership";

        }

        private Guna2Panel CloneCartItemPanel(string itemName, decimal price)
        {
            CartItems.Add(new CartItem
            {
                Name = itemName,
                Qty = 1,
                Price = price
            });


            var clone = new Guna2Panel
            {
                Size = pnlCartItem.Size,
                BorderRadius = pnlCartItem.BorderRadius,
                FillColor = pnlCartItem.FillColor,
                Margin = pnlCartItem.Margin,
                ShadowDecoration = { Enabled = true },
                Visible = true
            };

            foreach (Control c in pnlCartItem.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(c.GetType());
                newCtrl.Size = c.Size;
                newCtrl.Location = c.Location;
                newCtrl.Font = c.Font;
                newCtrl.Text = c.Text;
                newCtrl.Name = c.Name;
                clone.Controls.Add(newCtrl);
            }

            clone.Controls["lblItemName"].Text = itemName;
            clone.Controls["lblQty"].Text = "1";
            clone.Controls["lblPrice"].Text = $"₱{price}";
            clone.Controls["lblRowTotal"].Text = $"₱{price}";

            // 👉 Wire buttons
            var btnPlus = clone.Controls["btnPlus"] as Guna2Button;
            var btnMinus = clone.Controls["btnMinus"] as Guna2Button;
            var btnRemove = clone.Controls["btnRemove"] as Guna2Button;

            btnPlus.Click += (s, e) => UpdateQty(clone, +1);
            btnMinus.Click += (s, e) => UpdateQty(clone, -1);
            btnRemove.Click += (s, e) =>
            {
                string itemToRemove = clone.Controls["lblItemName"].Text;

                // ✅ Remove from data model
                CartItems.RemoveAll(c => c.Name == itemName);

                // ✅ Remove from UI
                flowCart.Controls.Remove(clone);
                clone.Dispose();

                UpdateCartTotals();
            };


            return clone;
        }

        // 👉 ADD HERE (below CloneCartItemPanel)
        private void UpdateQty(Guna2Panel panel, int change)
        {
            var lblQty = panel.Controls["lblQty"] as Label;
            var lblPrice = panel.Controls["lblPrice"] as Label;
            var lblRowTotal = panel.Controls["lblRowTotal"] as Label;
            var lblName = panel.Controls["lblItemName"] as Label;

            int qty = int.Parse(lblQty.Text);
            qty += change;
            if (qty < 1) qty = 1;

            lblQty.Text = qty.ToString();

            decimal price = decimal.Parse(lblPrice.Text.Replace("₱", ""));
            lblRowTotal.Text = $"₱{qty * price}";

            // 👉 SYNC WITH DATA MODEL
            var item = CartItems.FirstOrDefault(c => c.Name == lblName.Text);
            if (item != null)
            {
                item.Qty = qty;
            }

            UpdateCartTotals();  // 👉 recalc subtotal
        }


        private void UpdateCartTotals()
        {
            GetSubtotalValue();
            ApplyDiscount();
        }


        private void ApplyDiscount()
        {
            decimal subtotal = GetSubtotalValue();
            decimal discountAmount = subtotal * (appliedDiscountPercent / 100m);

            lblDiscount.Text = $"₱{discountAmount}";
            lblTotal.Text = $"₱{subtotal - discountAmount}";
        }

        private decimal GetSubtotalValue()
        {
            decimal total = 0;

            foreach (Guna2Panel p in flowCart.Controls.OfType<Guna2Panel>())
            {
                var lblRowTotal = p.Controls["lblRowTotal"] as Label;
                total += decimal.Parse(lblRowTotal.Text.Replace("₱", ""));
            }

            lblSubtotal.Text = $"₱{total}";
            return total;
        }


        private bool EquipmentAlreadyInCart(string itemName)
        {
            return flowCart.Controls
                .OfType<Guna2Panel>()
                .Any(p => p.Controls["lblItemName"].Text == itemName);
        }


        private void Equipment_Click(object sender, EventArgs e)
        {
            var panel = sender as Guna2Panel;
            if (panel != null && panel.Tag != null)
            {
                string itemName = panel.Tag.ToString();

                // ❌ Block duplicate equipment
                if (EquipmentAlreadyInCart(itemName))
                {
                    MessageBox.Show(
                        "This item is already in your cart.\nUse the + button to increase the quantity instead.",
                        "Item Already Added",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                decimal price = 0;
                if (itemName == "Racket") price = 50;
                else if (itemName == "Shuttlecock Pack") price = 80;
                else if (itemName == "Grip Tape") price = 30;
                else if (itemName == "Towel") price = 20;

                flowCart.Controls.Add(CloneCartItemPanel(itemName, price));
                UpdateCartTotals(); // 👉 after add
            }
        }


        private void Membership_Click(object sender, EventArgs e)
        {
            var panel = sender as Guna2Panel;
            string itemName = panel.Tag.ToString();

            RemoveExistingMembership();   // 👈 single-select logic

            decimal price = itemName == "1 Month Membership" ? 500 : 4500;

            flowCart.Controls.Add(CloneCartItemPanel(itemName, price));
            UpdateCartTotals();
        }


        private void RemoveExistingCourt()
        {
            var courts = flowCart.Controls.OfType<Guna2Panel>()
                .Where(p => p.Controls["lblItemName"].Text.StartsWith("Court"))
                .ToList();

            foreach (var p in courts)
            {
                string itemName = p.Controls["lblItemName"].Text;

                // Remove from data list
                CartItems.RemoveAll(c => c.Name == itemName);

                flowCart.Controls.Remove(p);
                p.Dispose();
            }

        }

        private void RemoveExistingMembership()
        {
            var memberships = flowCart.Controls.OfType<Guna2Panel>()
                .Where(p => p.Controls["lblItemName"].Text.Contains("Membership"))
                .ToList();

            foreach (var p in memberships)
            {
                string itemName = p.Controls["lblItemName"].Text;

                // Remove from data list
                CartItems.RemoveAll(c => c.Name == itemName);

                flowCart.Controls.Remove(p);
                p.Dispose();
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            appliedDiscountPercent = 0;

            string code = txtMemberCode.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a member code.");
                return;
            }

            // 🎯 Your Member Codes
            if (code == "M#0001") appliedDiscountPercent = 10;
            else if (code == "M#0002") appliedDiscountPercent = 15;
            else if (code == "M#0003") appliedDiscountPercent = 20;
            else
            {
                MessageBox.Show("Invalid member code.");
                return;
            }

            // ✅ SUCCESS
            ApplyDiscount();

            lblDiscountApplied.Text = $"Member Code {code} Applied ({appliedDiscountPercent}% OFF)";
            pnlDiscountApplied.Visible = true;

            txtMemberCode.Text = "";
        }

        private void btnRemoveDiscount_Click(object sender, EventArgs e)
        {
            appliedDiscountPercent = 0;

            pnlDiscountApplied.Visible = false;
            lblDiscount.Text = "₱0";
            txtMemberCode.Text = "";

            UpdateCartTotals();
        }


        private void btnCourtA_Click(object sender, EventArgs e)
        {
            RemoveExistingCourt();
            flowCart.Controls.Add(CloneCartItemPanel("Court A", 250));
            UpdateCartTotals();
        }

        private void btnCourtB_Click(object sender, EventArgs e)
        {
            RemoveExistingCourt();
            flowCart.Controls.Add(CloneCartItemPanel("Court B", 250));
            UpdateCartTotals();
        }

        private void btnCourtC_Click(object sender, EventArgs e)
        {
            RemoveExistingCourt();
            flowCart.Controls.Add(CloneCartItemPanel("Court C", 250));
            UpdateCartTotals();
        }

        private void btnCourtD_Click(object sender, EventArgs e)
        {
            RemoveExistingCourt();
            flowCart.Controls.Add(CloneCartItemPanel("Court D", 250));
            UpdateCartTotals();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnCashPayment_Click(object sender, EventArgs e)
        {

            // Get total from POS label
            decimal total = decimal.Parse(lblTotal.Text.Replace("₱", "").Trim());

            // Open CashPayment and pass total
            CashPayment cp = new CashPayment(total, CartItems);
            cp.ShowDialog();

        }
    }
}

