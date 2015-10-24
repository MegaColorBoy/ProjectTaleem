using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;

namespace MetroFrameworkDLLExample
{
    public partial class ResultSplashScreen : Form
    {
        private static NAudio.Wave.WaveFileReader wave = null;
        private static NAudio.Wave.DirectSoundOut output = null;
        public String result;

        public ResultSplashScreen()
        {
            InitializeComponent();
            this.result = WriteCanvas.resultStr;
            displayResult(result);
        }

        public void displayResult(String result)
        {
            if (result.Equals("WON"))
            {
                playTune("WON");
                displayPicture("WON");
            }
            else
            {
                playTune("LOSE");
                displayPicture("LOSE");
            }
        }

        //Dispose the wave
        private void DisposeWave()
        {
            if (output != null)
            {
                //If it's still playing, stop
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    output.Stop();
                }
                output.Dispose();
                output = null;
            }
            if (wave != null)
            {
                wave.Dispose();
                wave = null;
            }
        }

        public void playTune(String result)
        {
            string file;
            if (result.Equals("WON"))
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\happy.wav";
            }
            else
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\sad.wav";
            }

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
        }

        public void displayPicture(String result)
        {
            string file;
            if (result.Equals("WON"))
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\happy.jpg";
            }
            else
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\sad.jpg";
            }
            this.BackgroundImage = Image.FromFile(file);
            this.BackgroundImageLayout = ImageLayout.Zoom;
            //resultPicBox.ImageLocation = file;
            //this.resultPicBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
