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
using ShuttleZone.Kio_sk;
using MySql.Data.MySqlClient;
using ShuttleZone.database;
using ShuttleZone.Maintenance_Logs;

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

        private bool IsValidMemberCode(string code)
        {
            using (var conn = new MySqlConnection("server=localhost;user id=root;password=;database=shuttlezone;"))
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*) 
                    FROM members 
                    WHERE member_code = @code 
                      AND is_archived = 0
                      AND (expiry_date IS NULL OR expiry_date >= CURDATE())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
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

            Globals.LoadSettingsFromDB(); //need ko -shan

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
                AddOrUpdateCartItem(e.Name, e.Price);
                return;
            }

            if (sender is UC_CourtRental)
            {
                string assignedCourt = GetFirstAvailableCourt();

                if (assignedCourt == null)
                {
                    MessageBox.Show(
                        "Sorry, there are no courts available at the moment.\nPlease try again later.",
                        "No Courts Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // e.g. "Court A - 1 Hour Rental"
                string cartName = $"{assignedCourt} - {e.Name}";
                AddOrUpdateCartItem(cartName, e.Price);
                return;
            }

            // Equipment — no court assignment needed
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
                return;

            int qty = int.Parse(lblQty.Text);
            qty += change;

            if (qty < 1) qty = 1;

            int stock;
            bool hasStockLimit = TryGetEquipmentStock(lblName.Text, out stock);
            if (change > 0 && hasStockLimit && qty > stock)
            {
                qty = stock;
                MessageBox.Show("Cannot exceed available stock.");
                if (qty < 1)
                {
                    qty = 1;
                }
            }

            lblQty.Text = qty.ToString();

            decimal price = ParsePrice(lblPrice.Text);
            lblRowTotal.Text = $"₱{qty * price}";

            var item = cartItems.FirstOrDefault(c => c.Name == lblName.Text);
            if (item != null)
                item.Qty = qty;

            UpdateTotals();
        }

        private bool TryGetEquipmentStock(string itemName, out int stock)
        {
            stock = 0;
            var equipmentControl = pnlDynamic.Controls.OfType<UC_Equipment>().FirstOrDefault();
            if (equipmentControl == null)
            {
                return false;
            }

            foreach (var itemRow in equipmentControl.tlpEquipmentRoot.Controls.OfType<UC_EquipmentRow>())
            {
                if (itemRow.EquipmentNameText == itemName)
                {
                    stock = itemRow.AvailableStock;
                    return true;
                }
            }

            return false;
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

            if (!IsValidMemberCode(code))
            {
                MessageBox.Show("Invalid or expired member code.");
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
            UpdateEquipmentInventory();

            if (pnlDynamic.Controls[0] is UC_Equipment equipmentPanel)
            {
                equipmentPanel.RefreshEquipment();
            }

            decimal subtotal = GetSubtotal();
            decimal total = subtotal - GetDiscountAmount(subtotal);

            // ✅ Only generate the stub, do NOT open any PendingCard form
            var stub = new Stub(
                new List<CartItem>(cartItems), // clone current cart
                subtotal,
                total,
                DateTime.Now,
                appliedDiscountPercent,
                saveToDB: true // save stub to pending payments table
            );

            stub.ShowDialog(this); // only show the stub

            // Now reset the cart; the actual transaction is created when payment is cleared
            ResetCartAfterPayment();
        }

        private void BtnKioskEcashPayment_Click(object sender, EventArgs e)
        {
            UpdateEquipmentInventory();
            var subtotal = GetSubtotal();
            var total = subtotal - GetDiscountAmount(subtotal);

            var ecash = new EcashQR(total);
            ecash.PaymentCompleted += (s, args) =>
            {
                // Generate receipt number
                string receiptNo = $"KIOSK-{DateTime.Now:yyyyMMddHHmmssfff}";

                // 🔥 Save to transactions DB before showing receipt
                SaveKioskTransactionToHistory("E-Cash", receiptNo);

                // Open receipt form WITHOUT saving (already saved above)
                var receiptForm = new ReceiptForm(
                    new List<CartItem>(cartItems),
                    total,
                    "E-Cash",
                    DateTime.Now,
                    courtRentalHours: cartItems.FirstOrDefault(c => c.Name.Contains("Court"))?.Qty ?? 0,
                    receiptNo: receiptNo,
                    shouldSave: false // 🔥 prevent double saving
                );
                receiptForm.ShowDialog(this);

                // Reset cart AFTER saving and showing receipt
                ResetCartAfterPayment();
            };

            ecash.ShowDialog(this);
        }

        private void SaveKioskTransactionToHistory(string paymentMethod, string receiptNo)
        {
            if (cartItems.Count == 0)
                return;

            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    string insertQuery = @"
                INSERT INTO transactions 
                    (receipt_no, transaction_date, transaction_time, income_type, 
                     item_name, quantity, unit_price, total_amount, payment_method, 
                     created_at, transaction_source)
                VALUES 
                    (@receipt_no, CURDATE(), CURTIME(), 'Sales',
                     @item_name, @quantity, @unit_price, @total_amount, @payment_method,
                     NOW(), 'Kiosk')";

                    foreach (var item in cartItems)
                    {
                        using (var cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_no", receiptNo);
                            cmd.Parameters.AddWithValue("@item_name", item.Name);
                            cmd.Parameters.AddWithValue("@quantity", item.Qty);
                            cmd.Parameters.AddWithValue("@unit_price", item.Price);
                            cmd.Parameters.AddWithValue("@total_amount", item.Price * item.Qty);
                            cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCartAfterPayment()
        {
            foreach (var panel in flowKioskCart.Controls.OfType<Guna2Panel>().ToList())
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

        private void UpdateEquipmentInventory()
        {
            using (var conn = new MySqlConnection("server=localhost;user id=root;password=;database=shuttlezone;"))
            {
                conn.Open();

                foreach (var item in cartItems)
                {
                    if (item.Name.Contains("Court") || item.Name.Contains("Month"))
                        continue;

                    using (var cmd = new MySqlCommand(
                        "UPDATE equipment SET Available = Available - @qty, Rented = Rented + @qty, Status = CASE WHEN Available - @qty = 0 THEN 'Out of Stock' ELSE 'Available' END WHERE Name = @name", conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", item.Qty);
                        cmd.Parameters.AddWithValue("@name", item.Name);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
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

        private string GetFirstAvailableCourt()
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT court_name, status FROM courts ORDER BY court_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var courtName = reader["court_name"].ToString();
                        var status = reader["status"].ToString();

                        if (status.Equals("Out of Service", StringComparison.OrdinalIgnoreCase) ||
                            status.Equals("Under Maintenance", StringComparison.OrdinalIgnoreCase) ||
                            status.Equals("In Use", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        return courtName;
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        // Empty placeholders
        private void btnKioskEcashPayment_Click_1(object sender, EventArgs e) { }
        private void btnKioskCashPayment_Click_1(object sender, EventArgs e) { }
        private void btnKioskApply_Click_1(object sender, EventArgs e) { }

        private void pnlBannerContainer_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}