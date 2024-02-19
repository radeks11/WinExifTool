using System;
using System.Threading;
using System.Windows.Forms;

namespace WinExifTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
       {
            setLang();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(args));
        }

        private static void setLang()
        {
            
            if (Properties.Settings.Default.lang != string.Empty)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Properties.Settings.Default.lang);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.lang);
            }
            else
            {
                string lang = Application.CurrentCulture.Name;
                switch (lang)
                {
                    case "pl-PL":
                    case "pl":
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
                        break;
                    default:
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                        break;
                }
            }
        }
    }
}
