using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO;
using java.io;
using com.musicg.fingerprint;
using com.musicg.wave;
using NAudio;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;

//This is the prototype version of the Blind Mode
namespace MetroFrameworkDLLExample
{
    public partial class BlindModeForm : MetroForm
    {
        private static String database = "class" + LoginForm.classSec + "_db";
        private static String connStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
        //Sample strings
        private static String[] letters = getLevels(connStr);
        //private static String[] letters = {"S","A","T","I","P","N"};
        //Tracks the current position in the array
        int curPos=0;
        bool setMode = true;

        NAudio.Wave.WaveIn wavSource = null;
        NAudio.Wave.WaveFileWriter wavFile = null;
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;

        VoiceAssistant vAssist;

        public BlindModeForm()
        {
            InitializeComponent();
            this.Text = "Blind Mode";

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Blind Mode, Activated !");

            moveLeftBtn.Font = new Font("Serif", 25, FontStyle.Bold);
            //moveLeftBtn.Dock = DockStyle.Left;

            moveRightBtn.Font = new Font("Serif", 25, FontStyle.Bold);
            //moveRightBtn.Dock = DockStyle.Right;

            repeatBtn.Text = letters[curPos];
            repeatBtn.Font = new Font("Serif", 25, FontStyle.Bold);
            //repeatBtn.Dock = DockStyle.Top;

            recordBtn.Font = new Font("Serif", 25, FontStyle.Bold);
            //recordBtn.Dock = DockStyle.Bottom;
        }

        //Retrieves the levels according to it's phases
        private static String[] getLevels(String connStr)
        {
            String levels = "";

            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                String cmdString = "SELECT Levels from levelmngr where isSet='Y' ;";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                MySqlDataReader reader;
                connection.Open();

                reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count++;
                    levels += reader.GetString(0);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            String[] levelArr = levels.Split(';');
            return levelArr;
        }

        //Moves to the previous letter
        private void moveLeftBtn_Click(object sender, EventArgs e)
        {
            curPos = curPos - 1;
            if (curPos < 0)
            {
                curPos = letters.Length - 2;
            }
            repeatBtn.Text = letters[curPos];
            //reusing the same function to play the sound as it moves to the prev. letter
            repeatBtn_Click(sender, e);
        }

        //Move to the next letter
        private void moveRightBtn_Click(object sender, EventArgs e)
        {
            curPos = curPos + 1;
            if (curPos > letters.Length-2)
            {
                curPos = 0;
            }

            repeatBtn.Text = letters[curPos];
            //reusing the same function to play the sound as it moves to the next letter
            repeatBtn_Click(sender, e);
        }

        //Plays/Repeats the audio of the letter
        private void repeatBtn_Click(object sender, EventArgs e)
        {
            String filename = "Class" + LoginForm.classSec + "_kidAudio/" + letters[curPos] + ".wav";
            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(filename);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
        }

        //Record voice
        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (setMode)
            {
                try
                {
                    String filename = @"C:\Pres_Proto\MetroFrameworkDLLExample\RecordWAV\" + letters[curPos] + ".wav";
                    recordBtn.Text = "STOP";
                    wavSource = new NAudio.Wave.WaveIn();
                    wavSource.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);

                    wavSource.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(wavSource_DataAvail);
                    wavSource.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(wavSource_RecordingStop);

                    wavFile = new NAudio.Wave.WaveFileWriter(filename, wavSource.WaveFormat);
                    wavSource.StartRecording();
                    setMode = false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //When you press "STOP", it automatically compares
                wavSource.StopRecording();

                String recordWAV_file = @"C:\Pres_Proto\MetroFrameworkDLLExample\RecordWAV\" + letters[curPos] + ".wav";
                String refWAV_file = "Class" + LoginForm.classSec + "_kidAudio/" + letters[curPos] + ".wav";

                File f1 = new File(recordWAV_file);
                File f2 = new File(refWAV_file);

                if (!f1.exists() || !f2.exists())
                {
                    MessageBox.Show("WARNING: One of the files might be missing!");
                }
                else
                {
                    float compute_Result = compareAudio(recordWAV_file, refWAV_file);
                    if (compute_Result >= 10.0)
                    {
                        MessageBox.Show("Matched: " + compute_Result.ToString() + "\n You Win !");
                    }
                    else
                    {
                        MessageBox.Show("Matched: " + compute_Result.ToString() + "\n Try Again !");
                    }
                }
                recordBtn.Text = "RECORD";
                setMode = true;
            }
        }

        //Compares the audio files
        private static float compareAudio(String recordWAV, String refWAV)
        {
            InputStream fileA = new FileInputStream(recordWAV);
            InputStream fileB = new FileInputStream(refWAV);

            Wave wavFile1 = new Wave(fileA);
            Wave wavFile2 = new Wave(fileB);

            Byte[] sus = wavFile1.getFingerprint();
            Byte[] samp = wavFile2.getFingerprint();

            FingerprintSimilarityComputer fpc = new FingerprintSimilarityComputer(samp, sus);
            FingerprintSimilarity sim = fpc.getFingerprintsSimilarity();

            //FingerprintSimilarity sim;
            //sim = wavFile1.getFingerprintSimilarity(wavFile2);

            //result = (sim.getSimilarity() * 100) + 0;
            return (float)(sim.getScore()*100.0f);
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

        //Dispose the wave
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeWave();
        }

        //Event args to stop recording events
        private void wavSource_RecordingStop(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            if (wavSource != null)
            {
                wavSource.Dispose();
                wavSource = null;
            }

            if (wavFile != null)
            {
                wavFile.Dispose();
                wavFile = null;
            }
            //recBtn.Enabled = true;
        }

        //Event args to check if Data is available
        private void wavSource_DataAvail(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (wavFile != null)
            {
                wavFile.Write(e.Buffer, 0, e.BytesRecorded);
                wavFile.Flush();
            }
        }

        private void askMeBtn_Click(object sender, EventArgs e)
        {
            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Top left to Repeat");
            vAssist.SpeakMessage("Top right to Record");
            vAssist.SpeakMessage("Bottom left for previous letter");
            vAssist.SpeakMessage("Bottom right for next letter");
        }

    }
}