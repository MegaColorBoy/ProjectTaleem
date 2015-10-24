using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;
using NAudio;

namespace MetroFrameworkDLLExample
{
    public partial class ReadAudioForm3 : MetroForm
    {
        private ReadPhaseForm readPhase;
        public static MetroTile backButton, submitButton;
        private static String database = "class" + LoginForm.classSec + "_db";
        private static String connStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
        String[] phonics = getLevels(connStr);

        String lvlStr;
        public bool isColorBlind = false;
        private static NAudio.Wave.WaveFileReader wave = null;
        private static NAudio.Wave.DirectSoundOut output = null;

        VoiceAssistant vAssist;

        public ReadAudioForm3(ReadPhaseForm readPhase, String lvl)
        {
            InitializeComponent();

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Say the Jolly phonic !");

            backButton = this.backBtn;
            submitButton = this.startBtn;
            this.readPhase = readPhase;
            jollyPicBox.ImageLocation = "Class" + LoginForm.classSec + "_kidImages/" + lvl + ".jpg";
            this.jollyPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            lvlStr = lvl;

            startBtn.Style = MetroColorStyle.Red;
            backBtn.Style = MetroColorStyle.Purple;
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

                while (reader.Read())
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


        private void CallWaveForm(ReadAudioForm3 raf, String lvlStr)
        {
            WaveForm wf = new WaveForm(raf, lvlStr);
            elementHost1.Child = wf;
            this.Controls.Add(elementHost1);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(700, 400);
            CallWaveForm(this, lvlStr);
        }

        //Progress to new level
        public String updateLevel(String lvl)
        {
            String newLevel = "";
            if (lvl.Equals(phonics[phonics.Length - 2]))
            {
                newLevel += phonics[0];
            }
            else
            {
                for (int i = 0; i < phonics.Length-1; i++)
                {
                    if (lvl.Equals(phonics[i]))
                    {
                        newLevel += phonics[i + 1];
                    }
                }
            }
            return newLevel;
        }

        //If it's a new level
        public void newLevel(bool colorSetting)
        {
            //---save progress of the current level by marking, solved
            var nextForm = new ReadAudioForm3(readPhase, updateLevel(lvlStr));
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(isColorBlind);
            nextForm.Show();
        }

        //Repeat the level
        public void repeatLevel(bool colorSetting)
        {
            var nextForm = new ReadAudioForm3(readPhase, lvlStr);
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
                startBtn.Style = MetroColorStyle.Silver;
                backBtn.Style = MetroColorStyle.Silver;

            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
                startBtn.Style = MetroColorStyle.Red;
                backBtn.Style = MetroColorStyle.Purple;
            }
        }

        //Updates level progress in ReadPhaseForm
        public void updateLevelProgress()
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
        public void saveLevelProgress(String level)
        {
            String kidname = MainForm2.kidName;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Class" + LoginForm.classSec + "_kidLevelDB/" + kidname + "-readlvlprog.txt", true))
            {
                file.WriteLine("\n" + level);
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

        private void jollyPicBox_Click(object sender, EventArgs e)
        {
            string file = "Class" + LoginForm.classSec + "_kidAudio/" + lvlStr.ToLower() + ".wav";

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReadPhaseForm read = new ReadPhaseForm();
            read.setColorBlind(isColorBlind);
            read.ShowDialog();
        }

        private void ReadAudioForm3_Load(object sender, EventArgs e)
        {
            //this.FormClosing += ReadAudioForm3_FormClosing;
            //this.FormClosed += ReadAudioForm3_FormClosed;
        }

        private void ReadAudioForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void ReadAudioForm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

    }
}
