namespace ShuttleZone.SystemSettings
{
    public class SettingsModel
    {
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CurrencySymbol { get; set; }
        public int LowStockThreshold { get; set; }
    }
}