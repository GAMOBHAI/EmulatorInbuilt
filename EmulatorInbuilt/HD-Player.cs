using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Threading;
using System.Management;
using System.Diagnostics;
using System.Net;
using EmulatorInbuilt;
using System.Speech.Synthesis;

namespace EmulatorInbuilt
{
    
    public partial class Form1 : Form
    {
      
        bool shift;
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
          
            SelectQuery Sq = new SelectQuery("Win32_VideoController");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();
        }
        public bool keyhide = true;
        public static bool IsAlreadyRunning = false;
        private WebClient webClient = new WebClient();
        private void Kh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = false;

        }

        private async void Kh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = true;
            if (e.KeyCode == Keys.Delete)
            {
                Environment.Exit(0);
            }
            if (e.KeyCode == Keys.Home)
            {
                if (keyhide == false)
                {
                    this.Hide();
                    keyhide = true;
                }
                else
                {
                    this.Show();
                    keyhide = false;
                }
            }
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = true;
            if (shift == true && e.KeyCode == Keys.Delete)
            {
                Environment.Exit(0);
            }
            
            if (e.KeyCode == Keys.CapsLock)
            {
                PSPS.Text = "Activating";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT1");
                await Task.Delay(400);
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT2");
            }
            if (e.KeyCode == Keys.Shift +3)
            {
                PSPS.Text = "Activating";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT1");
                await Task.Delay(400);
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT2");
            }

            if (e.KeyCode == Keys.Shift+2)
            {
                PSPS.Text = "Activating";
                PSPS.ForeColor = Color.Orange;
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("ANTIBAN");
                await Task.Delay(100);
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("ANTIBLACK");
                await Task.Delay(200);
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("ANTICHECK");
                await Task.Delay(400);
                DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT");


            }
        }
        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
        }
        private async Task<IntPtr> FUCK_IS_ALWAYS_REAL(string type)
        {
            string gameloop = "HD-Player";
            string Bluestack = "HD-Player.exe";


            var intPtr = IntPtr.Zero;
            uint num = 0U;
            var intPtr2 = CreateToolhelp32Snapshot(2U, 0U);
            if ((int)intPtr2 > 0)
            {
                ProcessEntry32 processEntry = default;
                processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                int num2 = Process32First(intPtr2, ref processEntry);
                while (num2 == 1)
                {
                    var intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                    Marshal.StructureToPtr(processEntry, intPtr3, true);
                    ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                    Marshal.FreeHGlobal(intPtr3);
                    if (processEntry2.szExeFile.Contains(gameloop) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                    }
                    num2 = Process32Next(intPtr2, ref processEntry);
                    if (processEntry2.szExeFile.Contains(Bluestack) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)(long)(ulong)processEntry2.th32ProcessID;
                    }
                    num2 = Process32Next(intPtr2, ref processEntry);
                }
                PID.Text = Convert.ToString(intPtr);
                PID.Text = Convert.ToString(intPtr);
                await PutTaskDelay(1000);
                if (type == "AIMBOT1")
                {
                    AIMBOT1();
                }
                if (type == "AIMBOT2")
                {
                    AIMBOT2();
                }
                if (type == "AIMBOTAWM")
                {
                    AIMBOTAWM();
                }
                if (type == "ANTIBAN")
                {
                    ANTIBAN();
                }
                if (type == "ANTIBlACK")
                {
                    ANTIBLACK();
                }
                if (type == "ANTICHECK")
                {
                    ANTICHECK();
                }

            }
            return intPtr;
        }
        private string sr;

        public async void AIMBOTAWM()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply AimbotAWM");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "80 37 8F 3C", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 D7 5B 00", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Applied Aimbot AWM");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply AimbotAWM");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply AimbotAWM");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void ANTIBLACK()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply Antiblack");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "49 44 48 48 42 47 42 4E 48 4D 44", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 00 00 00 00 00 00 00 00 00", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Applied Antiblacklist");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Antiblack");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Antiblack");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void ANTIBAN()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply Antiban");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 80 89 44", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Applied Antiban");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Antiban");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Antiban");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void ANTICHECK()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply Anticheck");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Activated Anticheck");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Anticheck");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply Anticheck");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void AIMBOT1()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply norecoil");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "62 6f 6e 65 5f 4e 65 63 6b", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "62 6f 6e 65 5f 4e 65 63 73", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Activated Norecoil");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply norecoil");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply norecoil");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void AIMBOT2() 
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 50;
                _SS.Speak("Failed to apply AIMBOT");
                PSPS.ForeColor = Color.Red;
                PSPS.Text = "Connects Games";
            }
            else
            {
                PID.ForeColor = Color.Green;
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "62 6f 6e 65 5f 48 69 70 73", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "62 6f 6e 65 5f 4e 65 63 6b", "", (Encoding)null);
                    k = true;
                }

                if (k == true)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Aimbot is activated !!");
                    PSPS.Text = "Successful";
                    PSPS.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 100;
                    _SS.Speak("Failed to connect aimbot");
                    PSPS.ForeColor = Color.Red;
                    PSPS.Text = "Error";
                    counter += 1;
                    await FUCK_IS_ALWAYS_REAL("2");
                }
                else
                {
                    SpeechSynthesizer _SS = new SpeechSynthesizer();
                    _SS.Volume = 50;
                    _SS.Speak("Failed to apply AIMBOT");
                    PSPS.Text = "No aplicado...";
                    PSPS.ForeColor = Color.Red;
                }
            }
        }
        public async void DRIERSSSS_LOAD_AUTO_IN_PROCESSS(string type)
        {
            x = 0;
            await FUCK_IS_ALWAYS_REAL(type);
        }
        public long enumerable = new long();

        private int x;
        public Mem MemLib = new Mem();
        private static string string_0;
        private IContainer icontainer_0;
       

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Emulaotr Done");
            this.KeyPreview = true;
           
            
            //  Process.Start("C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe");
            Process.Start("C:\\Program Files\\BlueStacks\\Bluestacks.exe");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 100)
            {

                this.Hide();
            }
            if (progressBar1.Value == 100)
            {

                this.Hide();
                timer1.Stop();

            }
        }
    }
    }

