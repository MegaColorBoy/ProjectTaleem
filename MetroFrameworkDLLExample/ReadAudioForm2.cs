using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
//Using NAudio API for record, play and stop audio
using NAudio;
//Using musicg-api for FFT, Audio fingerprinting and similarity checks
using com.musicg.fingerprint;
using com.musicg.wave;
//using Java library for FileStream (to read the .wav files)
using java.io;

namespace MetroFrameworkDLLExample
{
    public partial class ReadAudioForm2 : MetroForm
    {
        private ReadPhaseForm readPhase;
        private static String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";
        String[] phonics = getLevels(connStr);
        
        static NAudio.Wave.WaveIn wavSource = null;
        static NAudio.Wave.WaveFileWriter wavFile = null;
        static NAudio.Wave.WaveFileReader wave = null;
        static NAudio.Wave.DirectSoundOut output = null;
        String lvlStr;
        bool isColorBlind = false;
        public int seconds;

        public ReadAudioForm2(ReadPhaseForm readPhase, String lvl)
        {
            InitializeComponent();
            this.readPhase = readPhase;
            //Later, change the directory to kidLevelImagesDB i.e. once you make changes to the database
            jollyPicBox.ImageLocation = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\refwords\" + lvl + ".jpg";
            this.jollyPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            lvlStr = lvl;

            recBtn.Style = MetroColorStyle.Red;
            backBtn.Style = MetroColorStyle.Purple;

            timeLabel.Visible = false;
            secsLabel.Visible = false;
        }

        //Retrieves the levels according to it's phases
        private static String[] getLevels(String connStr)
        {
            String levels = "";

            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                String cmdString = "SELECT Levels from lvlmngr_test where isSet='Y' ;";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                MySqlDataReader reader;
                connection.Open();

                reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count++;
                }

                if (count == 1)
                {
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


        int check = 0;
        //Built a slider to reveal the timer, it'll slide down when the timer is on
        //and slides up when the timer is off
        private void slideDown(object sender, EventArgs e)
        {
            if (check == 0)
            {
                for (int i = 280; i <= 360; i++)
                {
                    this.Size = new Size(380, i);
                    Thread.Sleep(5);
                }
                check = 1;
            }
        }
        
        private void slideUp(object sender, EventArgs e)
        {
            if (check == 1)
            {
                for (int i = 360; i >= 280; i--)
                {
                    this.Size = new Size(380, i);
                    Thread.Sleep(5);
                }
                check = 0;
            }
        }

        //Now, when you click record, it's going to start a timer 
        //and the user can give as many repetitions in one input
        //this is to enhance the audio input percentage
        private void recBtn_Click(object sender, EventArgs e)
        {
            try
            {
                backBtn.Enabled = false;
                String filename = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav";
                //recordBtn.Text = "STOP";
                wavSource = new NAudio.Wave.WaveIn();
                wavSource.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);

                wavSource.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(wavSource_DataAvail);
                wavSource.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(wavSource_RecordingStop);

                wavFile = new NAudio.Wave.WaveFileWriter(filename, wavSource.WaveFormat);
                wavSource.StartRecording();

                slideDown(sender, e);
                //Amount of time to take voice input
                seconds = 5;
                //startRecord(sender, e);
                timeLabel.Visible = true;
                secsLabel.Visible = true;
                secsLabel.Text = Convert.ToString(seconds);
                countTimer.Start();
                //setMode = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //The timer function
        //Once the timer is over, it'll display the result that was recorded during this period
        private void countTimer_Tick(object sender, EventArgs e)
        {
            //startRecord();
            seconds = seconds - 1;
            
            if (seconds == 0)
            {
                //When you press "STOP"
                //The recording and the counter are stopped
                //It then compares with the recorded audio and compares
                wavSource.StopRecording();
                countTimer.Stop();
                backBtn.Enabled = true;
                slideUp(sender, e);

                //The recorded voice of the student
                String recordWAV_file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav";
                //The reference sample of the teacher
                String refWAV_file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + lvlStr.ToLower() + ".wav";

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
                        //If user wins, update level and display choice
                        DialogResult diagRes = MessageBox.Show("Do you want to proceed or try again?", "important", MessageBoxButtons.YesNo);
                        if (diagRes == DialogResult.Yes)
                        {
                            this.Hide();

                            //If colorblind, change theme and go to new level
                            if (isColorBlind == true)
                            {
                                updateLevelProgress();
                                newLevel(isColorBlind);
                                saveLevelProgress(lvlStr);
                            }
                            //otherwise, revert old theme and go to new level
                            else
                            {
                                updateLevelProgress();
                                newLevel(isColorBlind);
                                saveLevelProgress(lvlStr);
                            }
                        }
                        //Otherwise, you can try again!!
                        else if (diagRes == DialogResult.No)
                        {
                            this.Hide();
                            if (isColorBlind == true)
                            {
                                repeatLevel(isColorBlind);
                            }
                            else
                            {
                                repeatLevel(isColorBlind);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Matched: " + compute_Result.ToString() + "\n Try Again !");
                    }
                }
                
                //MessageBox.Show("DONE!");
                timeLabel.Visible = false;
                secsLabel.Visible = false;
            }
            secsLabel.Text = Convert.ToString(seconds);
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

        //Compares both audio files
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

            return (float)(sim.getScore() * 100.0f) + 25;
        }

        //Progress to new level
        String updateLevel(String lvl)
        {
            String newLevel = "";
            for (int i = 0; i < phonics.Length; i++)
            {
                if (lvl.Equals(phonics[i]))
                {
                    newLevel += phonics[i + 1];
                }
            }
            return newLevel;
        }

        //If it's a new level
        private void newLevel(bool colorSetting)
        {
            //---save progress of the current level by marking, solved
            var nextForm = new ReadAudioForm2(readPhase, updateLevel(lvlStr));
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(isColorBlind);
            nextForm.Show();
        }

        //Repeat the level
        private void repeatLevel(bool colorSetting)
        {
            var nextForm = new ReadAudioForm2(readPhase, lvlStr);
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(colorSetting);
            nextForm.Show();
        }

        //changes color theme
        public void setColorBlind(bool colorSetting)
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;
            if (colorSetting == true)
            {
                isColorBlind = true;
                metroStyleManager.Theme = MetroThemeStyle.Dark;
                recBtn.Style = MetroColorStyle.Silver;
                backBtn.Style = MetroColorStyle.Silver;
                timeLabel.ForeColor = System.Drawing.Color.White;
                secsLabel.ForeColor = System.Drawing.Color.White;

            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
                recBtn.Style = MetroColorStyle.Red;
                backBtn.Style = MetroColorStyle.Purple;
                timeLabel.ForeColor = System.Drawing.Color.Black;
                secsLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        //Updates level progress in ReadPhaseForm
        private void updateLevelProgress()
        {
            for (int i = 0; i < phonics.Length; i++)
            {
                if (lvlStr.Equals(phonics[i]))
                {
                    readPhase.letterTiles[i].Text += "\nDONE!";
                }
            }
        }

        //Save as "kidname"+lvlprog.txt
        private void saveLevelProgress(String level)
        {
            String kidname = MainForm.kidName;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"kidLevelDB\" + kidname + "-readlvlprog.txt", true))
            {
                file.WriteLine("\n" + level);
            }
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ReadPhaseForm read = new ReadPhaseForm();
            read.setColorBlind(isColorBlind);
            read.ShowDialog();
        }

        private void jollyPicBox_Click_1(object sender, EventArgs e)
        {
            string file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + lvlStr.ToLower() + ".wav";

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
        }
    }
}
