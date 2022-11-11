using System;
using System.Windows.Forms;
using System.Media;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace PanOSMain
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PanOSMain());
        }
    }
}
