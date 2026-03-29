using ShuttleZone.Membership;
using ShuttleZone.LogIn_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuttleZone
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FacilityInfoCache.Load(); // 🔥 Load facility info once at startup

            Application.Run(new ShuttleZone.LogIn_Form.LoginForm());
        }
    }
}