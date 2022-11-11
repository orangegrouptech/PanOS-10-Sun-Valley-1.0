using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Forms;

namespace phase3
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
            Application.Run(new Form1());
        }
    }
}
