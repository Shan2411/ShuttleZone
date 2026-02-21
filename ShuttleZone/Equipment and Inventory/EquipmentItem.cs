using System;

namespace ShuttleZone.Equipment_and_Inventory
{
    public class EquipmentItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public int Total { get; set; }
        public int Available { get; set; }
        public int Rented { get; set; }

        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}