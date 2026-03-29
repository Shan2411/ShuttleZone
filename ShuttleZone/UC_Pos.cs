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
using MySql.Data.MySqlClient;
using ShuttleZone.Maintenance_Logs;
using ShuttleZone.database;


namespace ShuttleZone
{
    public partial class UC_Pos : UserControl
    {
        private sealed class PosEquipmentDisplay
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int Available { get; set; }
            public decimal Price { get; set; }
        }

        private decimal appliedDiscountPercent = 0;
        private readonly Dictionary<string, int> equipmentStockByName = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private List<CartItem> CartItems = new List<CartItem>();
        public event EventHandler PaymentCompleted;

        public UC_Pos()
        {
            InitializeComponent();
        }

        private static string BuildEquipmentKey(string name, string category)
        {
            return string.Format("{0} ({1})", name, category);
        }

        private static string BuildEquipmentKey(PosEquipmentDisplay item)
        {
            return BuildEquipmentKey(item.Name, item.Category);
        }

        private void UC_Pos_Load(object sender, EventArgs e)
        {
            // FlowPanel setup for full-width cart items
            flowCart.AutoScroll = true;
            flowCart.WrapContents = false;           // stack items vertically
            flowCart.FlowDirection = FlowDirection.TopDown;

            LoadEquipmentFromInventory();

            // Membership panels
            pnlMembership1.Click += Membership_Click;
            pnlMembership2.Click += Membership_Click;

            // Set membership names
            pnlMembership1.Tag = "1 Month Membership";
            pnlMembership2.Tag = "12 Months Membership";

            btnEcashPayment.Click += BtnEcashPayment_Click;

            LabelChangeAndDBLoad();
        }

        private bool CanCheckoutCourt(string courtName, out string warningMessage)
        {
            warningMessage = null;

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT status FROM courts WHERE court_name = @courtName LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@courtName", courtName);
                    var result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        warningMessage = string.Format("{0} status is unavailable. Please try again later.", courtName);
                        return false;
                    }

                    var status = result.ToString();
                    if (status.Equals("Out of Service", StringComparison.OrdinalIgnoreCase) ||
                        status.Equals("Under Maintenance", StringComparison.OrdinalIgnoreCase) ||
                        status.Equals("In Use", StringComparison.OrdinalIgnoreCase))
                    {
                        warningMessage = string.Format("{0} cannot be checked out because it is currently '{1}'.", courtName, status);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                warningMessage = "Unable to check court status: " + ex.Message;
                return false;
            }

            return true;
        }

        private void TryAddCourtRental(string courtName)
        {
            string warningMessage;
            if (!CanCheckoutCourt(courtName, out warningMessage))
            {
                MessageBox.Show(
                    warningMessage,
                    "Court Not Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal price = decimal.TryParse(Globals.courtPrice, out decimal p) ? p : 250;

            RemoveExistingCourt();
            flowCart.Controls.Add(CloneCartItemPanel(courtName, price));
            UpdateCartTotals();
        }

        private void LoadEquipmentFromInventory()
        {
            var items = new List<PosEquipmentDisplay>();
            equipmentStockByName.Clear();

            try
            {
                using (var conn = DBconnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT Name, Category, Available, Price FROM equipment WHERE Available > 0 ORDER BY Name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var equipment = new PosEquipmentDisplay
                        {
                            Name = reader["Name"].ToString(),
                            Category = reader["Category"].ToString(),
                            Available = Convert.ToInt32(reader["Available"]),
                            Price = Convert.ToDecimal(reader["Price"])
                        };

                        items.Add(equipment);
                        equipmentStockByName[BuildEquipmentKey(equipment)] = equipment.Available;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading equipment: " + ex.Message);
                return;
            }

            tlpEquipment.SuspendLayout();
            tlpEquipment.AutoScroll = true;
            tlpEquipment.Controls.Clear();
            tlpEquipment.ColumnCount = 1;
            tlpEquipment.ColumnStyles.Clear();
            tlpEquipment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpEquipment.RowStyles.Clear();
            tlpEquipment.RowCount = items.Count;

            int row = 0;
            foreach (var item in items)
            {
                var panel = CreateEquipmentPanel(item);
                tlpEquipment.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
                tlpEquipment.Controls.Add(panel, 0, row);
                row++;
            }

            tlpEquipment.ResumeLayout();
            RefreshEquipmentStockLabels();
        }

        private int GetCartQtyForEquipment(string equipmentName)
        {
            var item = CartItems.FirstOrDefault(c => c.Name.Equals(equipmentName, StringComparison.OrdinalIgnoreCase));
            return item != null ? item.Qty : 0;
        }

        private void RefreshEquipmentStockLabels()
        {
            foreach (var panel in tlpEquipment.Controls.OfType<Guna2Panel>())
            {
                var equipment = panel.Tag as PosEquipmentDisplay;
                if (equipment == null)
                {
                    continue;
                }

                var stockLabel = panel.Controls["lblStock"] as Label;
                if (stockLabel == null)
                {
                    continue;
                }

                int inCartQty = GetCartQtyForEquipment(BuildEquipmentKey(equipment));
                int currentStock = Math.Max(0, equipment.Available - inCartQty);
                stockLabel.Text = $"Stock: {currentStock}";
            }
        }

        private Guna2Panel CreateEquipmentPanel(PosEquipmentDisplay item)
        {
            var panel = new Guna2Panel
            {
                BorderColor = pnlEquipmentRow.BorderColor,
                BorderRadius = pnlEquipmentRow.BorderRadius,
                BorderThickness = pnlEquipmentRow.BorderThickness,
                Cursor = Cursors.Hand,
                CustomBorderColor = pnlEquipmentRow.CustomBorderColor,
                Dock = DockStyle.Fill,
                FillColor = pnlEquipmentRow.FillColor,
                Margin = pnlEquipmentRow.Margin,
                Padding = pnlEquipmentRow.Padding,
                Tag = item
            };

            foreach (Control c in pnlEquipmentRow.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(c.GetType());
                newCtrl.Size = c.Size;
                newCtrl.Location = c.Location;
                newCtrl.Font = c.Font;
                newCtrl.Text = c.Text;
                newCtrl.Name = c.Name;
                newCtrl.BackColor = c.BackColor;
                newCtrl.ForeColor = c.ForeColor;
                newCtrl.AutoSize = c.AutoSize;
                newCtrl.Anchor = c.Anchor;
                newCtrl.Dock = c.Dock;
                newCtrl.Margin = c.Margin;
                newCtrl.Padding = c.Padding;

                if (newCtrl.Name == "lblEquipment")
                {
                    newCtrl.Text = item.Name;
                }
                else if (newCtrl.Name == "lblCategory")
                {
                    newCtrl.Text = item.Category;
                }
                else if (newCtrl.Name == "lblEquipment1Price")
                {
                    newCtrl.Text = $"₱{item.Price:0.##}";
                }
                else if (newCtrl.Name == "lblStock")
                {
                    newCtrl.Text = $"Stock: {item.Available}";
                }

                newCtrl.Click += Equipment_Click;
                panel.Controls.Add(newCtrl);
            }

            panel.Click += Equipment_Click;
            return panel;
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
                AutoSize = true,
                BorderRadius = pnlCartItem.BorderRadius,
                FillColor = pnlCartItem.FillColor,
                Margin = new Padding(0, 0, 0, 5),
                ShadowDecoration = { Enabled = true },
                Visible = true
            };

            // Set width to fill the FlowLayoutPanel
            clone.Width = flowCart.ClientSize.Width - flowCart.Padding.Horizontal;

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

            // Wire buttons
            var btnPlus = clone.Controls["btnPlus"] as Guna2Button;
            var btnMinus = clone.Controls["btnMinus"] as Guna2Button;
            var btnRemove = clone.Controls["btnRemove"] as Guna2Button;

            btnPlus.Click += (s, e) => UpdateQty(clone, +1);
            btnMinus.Click += (s, e) => UpdateQty(clone, -1);
            btnRemove.Click += (s, e) =>
            {
                CartItems.RemoveAll(c => c.Name == itemName);
                flowCart.Controls.Remove(clone);
                clone.Dispose();
                RefreshEquipmentStockLabels();
                UpdateCartTotals();
            };

            // Optional: adjust width dynamically if FlowLayoutPanel resizes
            flowCart.SizeChanged += (s, e) =>
            {
                clone.Width = flowCart.ClientSize.Width - flowCart.Padding.Horizontal;
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

            if (lblQty == null || lblPrice == null || lblRowTotal == null || lblName == null)
            {
                return;
            }

            int qty = int.Parse(lblQty.Text);
            int updatedQty = qty + change;
            if (updatedQty < 1) updatedQty = 1;

            int availableStock;
            if (change > 0 && equipmentStockByName.TryGetValue(lblName.Text, out availableStock) && updatedQty > availableStock)
            {
                MessageBox.Show(
                    $"Only {availableStock} stock available for {lblName.Text}.",
                    "Insufficient Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                updatedQty = availableStock;
            }

            lblQty.Text = updatedQty.ToString();

            decimal price = decimal.Parse(lblPrice.Text.Replace("₱", ""));
            lblRowTotal.Text = $"₱{updatedQty * price}";

            // 👉 SYNC WITH DATA MODEL
            var item = CartItems.FirstOrDefault(c => c.Name == lblName.Text);
            if (item != null)
            {
                item.Qty = updatedQty;
            }

            RefreshEquipmentStockLabels();
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
            if (panel == null && sender is Control control)
            {
                panel = control.Parent as Guna2Panel;
            }

            var item = panel != null ? panel.Tag as PosEquipmentDisplay : null;

            if (item != null)
            {
                string itemName = BuildEquipmentKey(item);

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

                flowCart.Controls.Add(CloneCartItemPanel(itemName, item.Price));
                RefreshEquipmentStockLabels();
                UpdateCartTotals(); // 👉 after add
            }
        }


        private void Membership_Click(object sender, EventArgs e)
        {
            var panel = sender as Guna2Panel;
            string itemName = panel.Tag.ToString();

            RemoveExistingMembership();

            decimal price = 0;
            if (itemName == "1 Month Membership")
                decimal.TryParse(Globals.membershipPrice1Month, out price);
            else
                decimal.TryParse(Globals.membershipPrice1Year, out price);

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

            // Validate code against DB — single discount % for all valid members
            bool isValid = ValidateMemberCode(code);

            if (!isValid)
            {
                MessageBox.Show("Invalid member code.");
                return;
            }

            // Pull discount % from Globals (loaded from DB)
            decimal.TryParse(Globals.mambershipDiscount, out appliedDiscountPercent);

            ApplyDiscount();

            lblDiscountApplied.Text = $"Member Code {code} Applied ({appliedDiscountPercent}% OFF)";
            pnlDiscountApplied.Visible = true;

            txtMemberCode.Text = "";
        }

        private bool ValidateMemberCode(string code)
        {
            try
            {
                using (MySqlConnection conn = DBconnection.GetConnection())
                {


                    string query = "SELECT COUNT(*) FROM members WHERE member_code = @code";

                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", code);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to validate member code:\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            TryAddCourtRental("Court A");
        }

        private void btnCourtB_Click(object sender, EventArgs e)
        {
            TryAddCourtRental("Court B");
        }

        private void btnCourtC_Click(object sender, EventArgs e)
        {
            TryAddCourtRental("Court C");
        }

        private void btnCourtD_Click(object sender, EventArgs e)
        {
            TryAddCourtRental("Court D");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnCashPayment_Click(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(lblTotal.Text.Replace("₱", "").Trim());

            // Save transaction to history
            SaveTransactionToHistory("Cash", "Frontdesk");

            // Trigger event to notify RentHistory
            PaymentCompleted?.Invoke(this, EventArgs.Empty);

            // Open cash payment dialog
            CashPayment cp = new CashPayment(total, CartItems);
            cp.ShowDialog();
        }

        private void BtnEcashPayment_Click(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(lblTotal.Text.Replace("₱", "").Trim());

            // Save transaction to history
            SaveTransactionToHistory("E-Cash");

            // Trigger event to notify RentHistory
            PaymentCompleted?.Invoke(this, EventArgs.Empty);

            // Open e-cash dialog
            var ecash = new EcashQR(total);
            ecash.PaymentCompleted += (s, args) => ShowReceipt(total);
            ecash.ShowDialog();
        }

        private void ShowReceipt(decimal amountReceived)
        {
            int courtHours = CartItems.FirstOrDefault(c => c.Name.StartsWith("Court"))?.Qty ?? 0;
            var receiptForm = new ReceiptForm(
                new List<CartItem>(CartItems),
                amountReceived,
                "E-Cash",
                DateTime.Now,
                courtHours);
            receiptForm.Show();
        }
               
        private void lblCourtAAvailability_Click(object sender, EventArgs e)
        {

        }

        private void SaveTransactionToHistory(string paymentMethod, string transactionSource = "Frontdesk")
        {
            if (CartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty. Cannot process transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    // 1. Generate unique receipt number
                    string receiptNo = "FD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    // 2. Insert each cart item
                    string insertQuery = @"
                INSERT INTO transactions 
                    (receipt_no, transaction_date, transaction_time, income_type, 
                     item_name, quantity, unit_price, total_amount, payment_method, 
                     created_at, transaction_source)
                VALUES 
                    (@receipt_no, CURDATE(), CURTIME(), 'Sales',
                     @item_name, @quantity, @unit_price, @total_amount, @payment_method,
                     NOW(), @transaction_source)";

                    foreach (var item in CartItems)
                    {
                        using (var cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_no", receiptNo);
                            cmd.Parameters.AddWithValue("@item_name", item.Name);
                            cmd.Parameters.AddWithValue("@quantity", item.Qty);
                            cmd.Parameters.AddWithValue("@unit_price", item.Price);
                            cmd.Parameters.AddWithValue("@total_amount", item.Price * item.Qty);
                            cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                            cmd.Parameters.AddWithValue("@transaction_source", transactionSource);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Clear cart
                    CartItems.Clear();
                    flowCart.Controls.Clear();
                    UpdateCartTotals();

                    //MessageBox.Show("Transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LabelChangeAndDBLoad() {

            // load court prices from db
            Globals.LoadSettingsFromDB();
            
            //update labels
            lblCourtAPrice.Text = $"₱{Globals.courtPrice}/hour";
            lblCourtBPrice.Text = $"₱{Globals.courtPrice}/hour";
            lblCourtCPrice.Text = $"₱{Globals.courtPrice}/hour";
            lblCourtDPrice.Text = $"₱{Globals.courtPrice}/hour";

            lblMembership2Price.Text = $"₱{Globals.membershipPrice1Year}";
            lblMembership1Price.Text = $"₱{Globals.membershipPrice1Month}";

        }

    }
}

