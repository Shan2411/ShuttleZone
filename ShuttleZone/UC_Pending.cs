using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    public class PendingStub
    {
        public string StubNo { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime TimeIssued { get; set; }
        public List<PendingStubItem> Items { get; set; }
    }

    public class PendingStubItem
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public partial class UC_Pending : UserControl
    {
        public UC_Pending()
        {
            InitializeComponent();
        }

    }
}
