using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;
using NAudio;
using NAudio.Wave;
using java.io;
using com.musicg.wave;
using com.musicg.fingerprint;

namespace MetroFrameworkDLLExample
{
    public partial class WordBank : MetroForm
    {
        static String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";
        static List<String> list = new List<String>();
        static String[] levels;
        static ImageList images;

        NAudio.Wave.WaveIn wavSource = null;
        NAudio.Wave.WaveFileWriter wavFile = null;
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;

        int curPos = 0;
        bool setMode = true;

        public WordBank()
        {
            InitializeComponent();
            levels = getLevels(connStr);
            images = getImages("Class" + LoginForm.classSec + "_kidWordImages");

            repeatBtn.ImageAlign = ContentAlignment.MiddleCenter;
            repeatBtn.ImageList = images;
            repeatBtn.ImageIndex = curPos;
        }

        //Retrieves the levels according to it's phases
        private static String[] getLevels(String connStr)
        {
            String levels = "";

            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                String cmdString = "SELECT Word from wordbank_db";
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

        private static ImageList getImages(String directory)
        {
            ImageList images = new ImageList();
            images.ImageSize = new Size(240,200);
            foreach (String file in System.IO.Directory.GetFiles(directory))
            {
                try
                {
                    //Store the filenames
                    list.Add(file);
                    Image img = Image.FromFile(file);
                    images.Images.Add(img);
                }
                catch
                {
                    //You can fill whatever you want 
                }
            }
            return images;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            curPos = curPos - 1;
            if (curPos < 0)
            {
                curPos = levels.Length - 3;
            }
            //repeatBtn.Text = levels[curPos];
            //repeatBtn.Image = Image.FromFile(list[curPos]);
            repeatBtn.ImageAlign = ContentAlignment.MiddleCenter;
            repeatBtn.ImageList = images;
            repeatBtn.ImageIndex = curPos;
            repeatBtn_Click(sender, e);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            curPos = curPos + 1;
            if (curPos > levels.Length - 3)
            {
                curPos = 0;
            }
            //repeatBtn.Text = levels[curPos];
            //repeatBtn.Image = Image.FromFile(list[curPos]);
            repeatBtn.ImageAlign = ContentAlignment.MiddleCenter;
            repeatBtn.ImageList = images;
            repeatBtn.ImageIndex = curPos;
            repeatBtn_Click(sender, e);
        }

        private void repeatBtn_Click(object sender, EventArgs e)
        {
            String filename = "Class" + LoginForm.classSec + "_kidWordAudio/" + levels[curPos] + ";.wav";
            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(filename);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
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
            e.Cancel = true;
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (setMode)
            {
                try
                {
                    String filename = "Class" + LoginForm.classSec + "_kidWordAudio/test.wav";
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

                String recordWAV_file = "Class" + LoginForm.classSec + "_kidWordAudio/test.wav";
                String refWAV_file = "Class" + LoginForm.classSec + "_kidWordAudio/" + levels[curPos] + ";.wav";

                java.io.File f1 = new java.io.File(recordWAV_file);
                java.io.File f2 = new java.io.File(refWAV_file);

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

            return (float)(sim.getScore() * 100.0f);
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

    }
}
