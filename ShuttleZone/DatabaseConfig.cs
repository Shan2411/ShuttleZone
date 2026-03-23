namespace ShuttleZone
{
    // ============================================================
    //  DatabaseConfig.cs
    //
    //  ONE place to change the connection string for all laptops.
    //
    //  ADMIN LAPTOP (server):
    //      Server = localhost  (connects to its own MySQL)
    //
    //  OTHER LAPTOPS (Front Desk, Manager, Kiosk):
    //      Server = 192.168.1.9  (connects to Admin laptop)
    //
    //  HOW TO SWITCH:
    //      Comment/uncomment the correct ConnStr below.
    // ============================================================

    public static class DatabaseConfig
    {
        // ── ADMIN LAPTOP (server) ─────────────────────────────────────────────
        // Use this on the Admin laptop
        public const string ConnStr =
            "Server=localhost;Database=shuttlezone;Uid=root;Pwd=;CharSet=utf8mb4;";

        // ── OTHER LAPTOPS (Front Desk, Manager, Kiosk) ────────────────────────
        // Use this on the 3 other laptops — comment out the one above first
        // public const string ConnStr =
        //     "Server=192.168.1.9;Database=shuttlezone;Uid=shuttleuser;Pwd=shuttle2025;CharSet=utf8mb4;";
    }
}
