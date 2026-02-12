using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuttleZone.Maintenance_Logs
{
    public static class Globals
    {
        public static string CurrentCourtStatus;
        public static string CurrentCourtName;
        public static string statusFromDB = "Operational";
        public static string statusFromDB1 = "Operational";
        public static string statusFromDB2 = "out of service";
        public static string statusFromDB3 = "under maintenance";

        public static string courtPrice = "250";
        public static string vat = "2";
        //600, 4500
        public static string membershipPrice1Month = "600";
        public static string membershipPrice1Year = "4500";
        public static string mambershipDiscount = "20";
    }
}
