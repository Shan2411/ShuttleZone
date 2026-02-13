using System;

namespace ShuttleZone
{
    public class KioskItemSelectedEventArgs : EventArgs
    {
        public KioskItemSelectedEventArgs(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}
