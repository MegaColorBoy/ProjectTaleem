using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Using java libraries
using com.musicg.fingerprint;
using com.musicg.wave;
using java.io;

//First iteration of the speech recognition prototype
namespace MetroFrameworkDLLExample
{
    public partial class ReadLetter_Test : MetroFramework.Forms.MetroForm
    {
        String file1, file2;

        public ReadLetter_Test(String str)
        {
            InitializeComponent();
        }

        //Takes the voice input from the user
        private void voiceIn_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFD = new OpenFileDialog();
            opFD.Title = "Select .wav file";
            opFD.Filter = ".wav files (*.wav)|*.wav|All files (*.*)|*.*";
            opFD.InitialDirectory = "C:\\Users\\Abdush Shakoor\\Desktop";
            DialogResult result = opFD.ShowDialog();
            file1 = opFD.FileName.ToString();
            voiceIn_Label.Text = file1.ToString();
        }

        //Takes the reference input that's needed to compare with the input
        private void reference_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFD = new OpenFileDialog();
            opFD.Title = "Select .wav file";
            opFD.Filter = ".wav files (*.wav)|*.wav|All files (*.*)|*.*";
            opFD.InitialDirectory = "C:\\Users\\Abdush Shakoor\\Desktop";
            DialogResult result = opFD.ShowDialog();
            file2 = opFD.FileName.ToString();
            refIn_Label.Text = file2.ToString();
        }

        //Go back
        private void goBack_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Compare audio files
        private static float compareAudio(string filename1, string filename2)
        {
            //string resStr = "";
            float result = 0;
            //float score = 0;

            InputStream isOne = new FileInputStream(filename1);
            InputStream isTwo = new FileInputStream(filename2);

            Wave wavFile1 = new Wave(isOne);
            Wave wavFile2 = new Wave(isTwo);

            FingerprintSimilarity sim;
            sim = wavFile1.getFingerprintSimilarity(wavFile2);
            result = sim.getSimilarity() * 100;
            return result;
        }

        //Comparison between both the inputs, displays the result
        private void compare_Btn_Click(object sender, EventArgs e)
        {
            //If the files are missing, give a "file is missing" error
            if (file1 == null || file2 == null)
            {
                MessageBox.Show("Warning: No audio files are detected!");
            }
            else
            {
                file1 = file1.Replace(@"\", "/");
                file2 = file2.Replace(@"\", "/");
                float compRes = compareAudio(file1, file2);
                compareLabel.Text = "Match: " + compRes.ToString();

                if (compRes > 25.0)
                {
                    MessageBox.Show("You win ! :D !");
                    //If user wins, update level and display choice
                }
                else
                {
                    MessageBox.Show("Try again ! :(");
                }
            }
        }
    }
}