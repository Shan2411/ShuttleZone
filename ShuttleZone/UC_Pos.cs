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

            pnlEquipment1.Tag = "Badminton Racket";
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

        private Guna.UI2.WinForms.Guna2Panel CloneCartItemPanel(string itemName)
        {
            var clone = new Guna.UI2.WinForms.Guna2Panel
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

            // Wire buttons
            var btnPlus = clone.Controls["btnPlus"] as Guna2Button;
            var btnMinus = clone.Controls["btnMinus"] as Guna2Button;
            var btnRemove = clone.Controls["btnRemove"] as Guna2Button;

            btnPlus.Click += (s, e) =>
            {
                var lblQty = clone.Controls["lblQty"] as Label;
                int qty = int.Parse(lblQty.Text);
                lblQty.Text = (qty + 1).ToString();
            };

            btnMinus.Click += (s, e) =>
            {
                var lblQty = clone.Controls["lblQty"] as Label;
                int qty = int.Parse(lblQty.Text);

                if (qty > 1)
                    lblQty.Text = (qty - 1).ToString();
            };

            btnRemove.Click += (s, e) =>
            {
                flowCart.Controls.Remove(clone);
                clone.Dispose();
            };
            return clone;
        }

        private void Equipment_Click(object sender, EventArgs e)
        {
            var panel = sender as Guna.UI2.WinForms.Guna2Panel;
            if (panel != null && panel.Tag != null)
            {
                string itemName = panel.Tag.ToString();
                flowCart.Controls.Add(CloneCartItemPanel(itemName));
            }
        }
        private void Membership_Click(object sender, EventArgs e)
        {
            var panel = sender as Guna2Panel;
            string itemName = panel.Tag.ToString();

            flowCart.Controls.Add(CloneCartItemPanel(itemName));
        }


        private void btnCourtA_Click(object sender, EventArgs e)
        {
            flowCart.Controls.Add(CloneCartItemPanel("Court A"));
        }

        private void btnCourtB_Click(object sender, EventArgs e)
        {
            flowCart.Controls.Add(CloneCartItemPanel("Court B"));
        }

        private void btnCourtC_Click(object sender, EventArgs e)
        {
            flowCart.Controls.Add(CloneCartItemPanel("Court C"));
        }

        private void btnCourtD_Click(object sender, EventArgs e)
        {
            flowCart.Controls.Add(CloneCartItemPanel("Court D"));
        }
    }
}
