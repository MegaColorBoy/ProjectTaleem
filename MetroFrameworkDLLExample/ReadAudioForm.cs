using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using MetroFramework.Forms;
using MetroFramework;
using MySql.Data.MySqlClient;
//Using NAudio API for record, play and stop audio
using NAudio;
//Using musicg-api for FFT, Audio fingerprinting and similarity checks
using com.musicg.fingerprint;
using com.musicg.wave;
//using Java library for FileStream (to read the .wav files)
using java.io;


//This code works...using NAudio API, it is much more accurate than the previous code that I had developed !
namespace MetroFrameworkDLLExample
{
    public partial class ReadAudioForm : MetroFramework.Forms.MetroForm
    {
        private ReadPhaseForm readPhase;

        private static String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";

        //Four letters for now !
        String[] phonics = getLevels(connStr); 
        NAudio.Wave.WaveIn wavSource = null;
        NAudio.Wave.WaveFileWriter wavFile = null;
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;
        String lvlStr;
        bool mode = true;
        bool isColorBlind = false;

        //Need to insert a string, so it can save .wav file in that name
        public ReadAudioForm(ReadPhaseForm readPhase, String lvl)
        {
            InitializeComponent();

            recBtn.Visible = false;
            playBtn.Visible = false;
            pauseButton.Visible = false;
            stopBtn.Visible = false;
            
            this.readPhase = readPhase;
            
            //Later, change the directory to kidLevelImagesDB i.e. once you make changes to the database
            jollyPicBox.ImageLocation = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\refwords\" + lvl + ".jpg";

            this.jollyPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            lvlStr = lvl;
            jollyLabel.Text = lvl;
            jollyLabel.Font = new Font(jollyLabel.Font.FontFamily, 50);
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

        //Record/Stop, user can record with many tries as possible
        private void recStpBtn_Click(object sender, EventArgs e)
        {
            //When pressed first, start recording
            if (mode)
            {
                try
                {
                    recStpBtn.Text = "Stop";
                    wavSource = new NAudio.Wave.WaveIn();
                    wavSource.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);

                    wavSource.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(wavSource_DataAvail);
                    wavSource.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(wavSource_RecordingStop);

                    wavFile = new NAudio.Wave.WaveFileWriter(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav", wavSource.WaveFormat);
                    wavSource.StartRecording();
                    mode = false;
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //Else stop recording
            else
            {
                recStpBtn.Text = "Record";
                wavSource.StopRecording();
                mode = true;
            }
        }

        //For debugging purposes only. Otherwise use the function above
        private void recBtn_Click(object sender, EventArgs e)
        {
            //recBtn.Enabled = false;
            //stopBtn.Enabled = true;

            //wavSource = new NAudio.Wave.WaveIn();
            //wavSource.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);

            //wavSource.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(wavSource_DataAvail);
            //wavSource.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(wavSource_RecordingStop);

            //wavFile = new NAudio.Wave.WaveFileWriter(@"D:\" + s + ".wav", wavSource.WaveFormat);
            //wavSource.StartRecording();
        }

        //For debugging purposes only. Otherwise use the function "recStpBtn"
        private void stopBtn_Click(object sender, EventArgs e)
        {
            //stopBtn.Enabled = false;
            //wavSource.StopRecording();
        }

        //This is for the picture....will make changes in the final one !
        //For now it's for the button
        private void playBtn_Click(object sender, EventArgs e)
        {
            string file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + lvlStr.ToLower() + ".wav";
            
            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();

            //pauseButton.Enabled = true;
        }

        //For Debugging purposes only, not required to use
        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
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
            //Note: for this part, I had intentionally made it like this for now, so that I could test the functions
            //I'm already working on a better version for cancelling noise.
            result = (sim.getSimilarity() * 100) + 0;
            return result;
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

        //Compare 
        private void compareBtn_Click(object sender, EventArgs e)
        {
            //string file1 = @"C:\Users\Abdush Shakoor\Desktop\S.wav";
            //This is the user's input
            string file1 = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav";
            //This is the reference voice used to compare
            string file2 = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + lvlStr.ToLower() + ".wav";

            java.io.File f1 = new java.io.File(file1);
            java.io.File f2 = new java.io.File(file2);

            //If the files are missing or if they don't exist, give a "file is missing" error
            if (file1 == null || file2 == null || !f1.exists() || !f2.exists())
            {
                MessageBox.Show("Warning: No audio files are detected!");
            }
            else
            {
                //Compare the audio files
                float compRes = compareAudio(file1, file2);
                compareLabel.Text = "Match: " + compRes.ToString();

                if (compRes >= 25.0)
                {
                    MessageBox.Show("You win ! :D !");

                    //If user wins, update level and display choice
                    DialogResult diagRes = MessageBox.Show("Do you want to proceed or try again?", "important", MessageBoxButtons.YesNo);
                    if (diagRes == DialogResult.Yes)
                    {
                        this.Hide();
                        //Create a method that says "solved" after each level on the button -- will update it soon !
                        //xxxxxxxx

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
                    MessageBox.Show("Try again ! :(");
                }
            }
        }

        //If it's a new level
        private void newLevel(bool colorSetting)
        {
            //---save progress of the current level by marking, solved
            var nextForm = new ReadAudioForm(readPhase, updateLevel(lvlStr));
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(isColorBlind);
            nextForm.Show();
        }

        //Repeat the level
        private void repeatLevel(bool colorSetting)
        {
            var nextForm = new ReadAudioForm(readPhase, lvlStr);
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
            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
            }
        }

        //Prototype version of saving level progress, for now it shows progress on the tiles only
        //Later version must be done on files and tiles at the same time !
        private void changeText_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < phonics.Length; i++)
            //{
            //    if (lvlStr.Equals(phonics[i]))
            //    {
            //        readPhase.letterTiles[i].Text += "\nDONE!";
            //    }
            //}
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"kidLevelDB\"+kidname+"-readlvlprog.txt", true))
            {
                file.WriteLine("\n"+level);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReadPhaseForm read = new ReadPhaseForm();
            read.setColorBlind(isColorBlind);
            read.ShowDialog();
        }

        private void jollyPicBox_Click(object sender, EventArgs e)
        {
            playBtn_Click(sender, e);
        }

    }//end class
}