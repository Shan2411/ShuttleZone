using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ShuttleZone
{
    public partial class Kiosk : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private readonly List<CartItem> cartItems = new List<CartItem>();
        private readonly Timer inactivityTimer = new Timer();
        private decimal appliedDiscountPercent;
        public static string BannerHeaderText { get; private set; } = "Book a Court Today!";
        public static string PromoText { get; private set; } = "Avail Membership and get Discounts up to 20%!";
        public static bool AutoReturnHomeEnabled { get; private set; }
        public static int SessionTimeoutMinutes { get; private set; } = 1;
        private static readonly HashSet<string> ValidMemberCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "M#0001",
            "M#0002",
            "M#0003"
        };

        public Kiosk()
        {
            InitializeComponent();
            ApplyHeaderAndPromoTexts();
            ConfigureInactivityTimer();
            ApplyAutoReturnSettings();
            Load += Kiosk_Load;
            btnCourtRental.Click += BtnCourtRental_Click;
            btnEquipment.Click += BtnEquipment_Click;
            btnMembership.Click += BtnMembership_Click;
            btnCloseKiosk.Click += BtnCloseKiosk_Click;
            btnKioskApply.Click += BtnKioskApply_Click;
            btnKioskRemoveDiscount.Click += BtnKioskRemoveDiscount_Click;
            btnKioskCashPayment.Click += BtnKioskCashPayment_Click;
            btnKioskEcashPayment.Click += BtnKioskEcashPayment_Click;
        }

        public static void UpdateTexts(string bannerHeaderText, string promoText)
        {
            BannerHeaderText = bannerHeaderText;
            PromoText = promoText;

            foreach (var kiosk in Application.OpenForms.OfType<Kiosk>())
            {
                kiosk.ApplyHeaderAndPromoTexts();
            }
        }

        public static void UpdateAutoReturnSettings(bool enabled, int sessionTimeoutMinutes)
        {
            AutoReturnHomeEnabled = enabled;
            SessionTimeoutMinutes = sessionTimeoutMinutes < 1 ? 1 : sessionTimeoutMinutes;

            foreach (var kiosk in Application.OpenForms.OfType<Kiosk>())
            {
                kiosk.ApplyAutoReturnSettings();
            }
        }

        private void ApplyHeaderAndPromoTexts()
        {
            lblBannerHeaderText.Text = BannerHeaderText;
            lblPromoText.Text = PromoText;
        }

        private void ConfigureInactivityTimer()
        {
            inactivityTimer.Interval = 1000;
            inactivityTimer.Tick += InactivityTimer_Tick;
        }

        private void ApplyAutoReturnSettings()
        {
            if (AutoReturnHomeEnabled)
            {
                inactivityTimer.Start();
                return;
            }

            inactivityTimer.Stop();
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            if (!AutoReturnHomeEnabled)
            {
                return;
            }

            if (GetIdleTime() < TimeSpan.FromMinutes(SessionTimeoutMinutes))
            {
                return;
            }

            ReturnToHome();
        }

        private void ReturnToHome()
        {
            if (lblKioskTitle.Text != "Court Rental")
            {
                ShowDynamicPanel(new UC_CourtRental());
                lblKioskTitle.Text = "Court Rental";
            }

            ResetCartAfterInactivity();
        }

        private void ResetCartAfterInactivity()
        {
            var panelsToRemove = flowKioskCart.Controls
                .OfType<Guna2Panel>()
                .Where(panel => panel != pnlKioskCartItem)
                .ToList();

            foreach (var panel in panelsToRemove)
            {
                flowKioskCart.Controls.Remove(panel);
                panel.Dispose();
            }

            cartItems.Clear();
            appliedDiscountPercent = 0m;
            pnlKioskDiscountApplied.Visible = false;
            txtKioskMemberCode.Text = string.Empty;
            UpdateTotals();
        }

        private static TimeSpan GetIdleTime()
        {
            var info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);

            if (!GetLastInputInfo(ref info))
            {
                return TimeSpan.Zero;
            }

            uint elapsedMilliseconds = unchecked((uint)Environment.TickCount) - info.dwTime;
            return TimeSpan.FromMilliseconds(elapsedMilliseconds);
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
            decimal subtotal = GetSubtotal();
            decimal discountAmount = GetDiscountAmount(subtotal);
            decimal total = subtotal - discountAmount;

            lblKioskSubtotal.Text = $"₱{subtotal}";
            lblKioskDiscount.Text = $"₱{discountAmount}";
            lblKioskTotal.Text = $"₱{total}";
        }

        private decimal GetSubtotal()
        {
            return cartItems.Sum(item => item.Price * item.Qty);
        }

        private decimal GetDiscountAmount(decimal subtotal)
        {
            return subtotal * appliedDiscountPercent;
        }

        private void BtnKioskCashPayment_Click(object sender, EventArgs e)
        {
            decimal subtotal = GetSubtotal();
            decimal total = subtotal - GetDiscountAmount(subtotal);

            var stub = new Stub(new List<CartItem>(cartItems), subtotal, total, DateTime.Now);
            stub.ShowDialog(this);
        }

        private void BtnKioskEcashPayment_Click(object sender, EventArgs e)
        {
            decimal subtotal = GetSubtotal();
            decimal total = subtotal - GetDiscountAmount(subtotal);

            var ecash = new EcashQR(total);
            ecash.PaymentCompleted += (s, args) =>
            {
                string receiptNo = $"RCP-{DateTime.Now:yyyyMMdd-HHmmss}";

                TransactionRecorder.SaveFromCart(
                    receiptNo,
                    DateTime.Now,
                    cartItems,
                    "E-Cash", "Kiosk"
                );

                ShowReceipt(total);
            };
            ecash.ShowDialog(this);
        }

        private void ShowReceipt(decimal amountReceived)
        {
            int courtHours = cartItems.FirstOrDefault(c => c.Name.Contains("Court"))?.Qty ?? 0;
            var receiptForm = new ReceiptForm(
                new List<CartItem>(cartItems),
                amountReceived,
                "E-Cash",
                DateTime.Now,
                courtHours);
            receiptForm.Show();
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

        private void btnKioskEcashPayment_Click_1(object sender, EventArgs e)
        {

        }
    }
}
