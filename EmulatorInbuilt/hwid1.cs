using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace EmulatorInbuilt
{
    public partial class hwid1 : Form
    {
        public hwid1()
        {
            InitializeComponent();
        }
        string hwid;

        private async void hwid_Load(object sender, EventArgs e)
        {
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            textBox1.Text = hwid;
            textBox1.ReadOnly = true;

            Clipboard.SetText(hwid);

            await Task.Delay(1);
          
           if (textBox1.Text == "S-1-5-21-516816393-3508869100-2656348922-1000")
            {
               Form1 main = new Form1();
                main.Show();
                
           }
           else 
            {
                SpeechSynthesizer _SS = new SpeechSynthesizer();
                _SS.Volume = 100;
                _SS.Speak("H W I D Miss Match");
            }

           
        }
        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
