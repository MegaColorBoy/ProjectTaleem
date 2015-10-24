using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;

//this is the main form
namespace MetroFrameworkDLLExample
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";

        bool isColorBlind = false;
        public static string isCB = "";
        public static String kidName = "";
        public MetroTile r,w,e;
        VoiceAssistant vAssist;

        public MainForm(String filename)
        {
            InitializeComponent();

            getData(connStr, "spelltable_db");
            getData(connStr, "image_db");
            getData(connStr, "audio_db");
            getData(connStr, "flash_db");
            getData(connStr, "wordbank_image");
            getData(connStr, "wordbank_audio");

            r = readTile;
            w = writeTile;
            e = exitTile;

            //MetroTile "look and feel" settings
            //----------------------------------------------------------//
            r.TileTextFontSize = MetroTileTextSize.Tall;
            r.TileTextFontWeight = MetroTileTextWeight.Bold;

            w.TileTextFontSize = MetroTileTextSize.Tall;
            w.TileTextFontWeight = MetroTileTextWeight.Bold;

            e.TileTextFontSize = MetroTileTextSize.Tall;
            e.TileTextFontWeight = MetroTileTextWeight.Bold;

            mathTile.TileTextFontSize = MetroTileTextSize.Tall;
            mathTile.TileTextFontWeight = MetroTileTextWeight.Bold;

            wordBankBtn.TileTextFontSize = MetroTileTextSize.Tall;
            wordBankBtn.TileTextFontWeight = MetroTileTextWeight.Bold;

            spellTile.TileTextFontSize = MetroTileTextSize.Tall;
            spellTile.TileTextFontWeight = MetroTileTextWeight.Bold;

            guessGameTile.TileTextFontSize = MetroTileTextSize.Tall;
            guessGameTile.TileTextFontWeight = MetroTileTextWeight.Bold;

            viewProgressBtn.TileTextFontSize = MetroTileTextSize.Tall;
            viewProgressBtn.TileTextFontWeight = MetroTileTextWeight.Bold;
            //----------------------------------------------------------//
            loginPic.ImageLocation = filename;
            accessChildDatabaseV2(filename);

            //Goes grayscale
            if (isCB == "Y")
            {
                colorTest();
                r.Style = MetroFramework.MetroColorStyle.Silver;
                w.Style = MetroFramework.MetroColorStyle.Silver;
                e.Style = MetroFramework.MetroColorStyle.Silver;
                mathTile.Style = MetroColorStyle.Silver;
                spellTile.Style = MetroColorStyle.Silver;
                wordBankBtn.Style = MetroColorStyle.Silver;
                guessGameTile.Style = MetroColorStyle.Silver;
                viewProgressBtn.Style = MetroColorStyle.Silver;
            }

            else
            {
                r.Style = MetroFramework.MetroColorStyle.Orange;
                w.Style = MetroFramework.MetroColorStyle.Yellow;
                e.Style = MetroFramework.MetroColorStyle.Red;
                mathTile.Style = MetroColorStyle.Purple;
                spellTile.Style = MetroColorStyle.Lime;
                wordBankBtn.Style = MetroColorStyle.Teal;
                guessGameTile.Style = MetroColorStyle.Brown;
                viewProgressBtn.Style = MetroColorStyle.Green;
            }

            this.loginPic.SizeMode = PictureBoxSizeMode.Zoom;
            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Welcome, Please select an option !");

        }

        //This method downloads all the AV files and images required for the applicatiion
        private void getData(String connectionStr, String db)
        {
            String command ="";
            String dir = "";
            String format = "";

            if(db.Equals("image_db"))
            {
                command = "SELECT PhonicsName, Image FROM image_db";
                dir = "Class" + LoginForm.classSec + "_kidImages";
                format = ".jpg";
            }
            else if(db.Equals("audio_db"))
            {
                command = "SELECT PhonicsName, Audio FROM audio_db";
                dir = "Class" + LoginForm.classSec + "_kidAudio";
                format = ".wav";
            }
            else if(db.Equals("flash_db"))
            {
                command = "SELECT Letters, Flash FROM flash_db";
                dir = "Class" + LoginForm.classSec + "_kidFlash";
                format = ".swf";
            }
            else if(db.Equals("spelltable_db"))
            {
                command = "SELECT Word, Image FROM spelltable_db";
                dir = "Class" + LoginForm.classSec + "_kidSpellImages";
                format = ".jpg";
            }
            else if(db.Equals("wordbank_image"))
            {
                command = "SELECT Word, Image FROM wordbank_db";
                dir = "Class" + LoginForm.classSec + "_kidWordImages";
                format = ".jpg";
            }
            else if(db.Equals("wordbank_audio"))
            {
                command = "SELECT Word, Audio FROM wordbank_db";
                dir = "Class" + LoginForm.classSec + "_kidWordAudio";
                format = ".wav";
            }

            if (!Directory.Exists(dir))
            {
                MySqlConnection connection = new MySqlConnection(connectionStr);
                MySqlDataReader reader;
                String cmdString = command;
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                FileStream fs;
                String letter;
                BinaryWriter bw;
                int bufferSize = 1024;
                byte[] byteData = new byte[bufferSize];
                long nBytesReturned, startIndex = 0;

                connection.Open();
                reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                while (reader.Read())
                {
                    letter = reader.GetString(0);
                    fs = new FileStream(dir + "/" + letter.ToString() + format, FileMode.OpenOrCreate, FileAccess.Write);
                    bw = new BinaryWriter(fs);
                    startIndex = 0;
                    nBytesReturned = reader.GetBytes(
                    1,
                    startIndex,
                    byteData,
                    0,
                    bufferSize
                    );

                    while (nBytesReturned == bufferSize)
                    {
                        bw.Write(byteData);
                        bw.Flush();
                        startIndex += bufferSize;
                        nBytesReturned = reader.GetBytes(1, startIndex, byteData, 0, bufferSize);
                    }

                    bw.Write(byteData, 0, (int)nBytesReturned - 1);
                    bw.Close();
                    fs.Close();
                }
                reader.Close();
                connection.Close();
            }
        }

        //Splits the directory
        public String splitDir(String str)
        {
            String[] strSplit = str.Split('/');
            String[] splitJPG = strSplit[strSplit.Length - 1].Split('.');
            return splitJPG[0];
        }

        private void createFile(String kidName)
        {
            if(!Directory.Exists("Class" + LoginForm.classSec + "_kidLevelDB"))
            {
                Directory.CreateDirectory("Class" + LoginForm.classSec + "_kidLevelDB");
            }

            String rpath = "Class" + LoginForm.classSec + "_kidLevelDB/" + kidName + "-readlvlprog.txt";
            String wpath = "Class" + LoginForm.classSec + "_kidLevelDB/" + kidName + "-writelvlprog.txt";

            if (!File.Exists(rpath))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(rpath, true))
                {
                    file.WriteLine("\n");
                }
            }

            if (!File.Exists(wpath))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(wpath, true))
                {
                    file.WriteLine("\n");
                }
            }
        }

        //Integrated with the MySQL database
        private void accessChildDatabaseV2(String fileName)
        {
            String[] nameArr = splitDir(fileName).Split(' ');
            String fname = nameArr[0], lname = nameArr[1];
            String colorBlind = "";

            String database = "class" + LoginForm.classSec + "_db";
            String connectionStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            try
            {
                String cmdString = "SELECT FirstName, LastName, isColorBlind from studentinfo where FirstName='" + fname + "' and LastName='" + lname + "' ;";
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
                    kidName = reader.GetString(0) + " " + reader.GetString(1);
                    kidNameLabel.Text = kidName;
                    createFile(kidName);
                    classSectionLabel.Text = LoginForm.classSec;
                    colorBlind = reader.GetString(2);
                    isCB = colorBlind;
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
        }

        //Opens the read form
        private void readTile_Click(object sender, EventArgs e)
        {
            if (isColorBlind == true)
            {
                callReadPhaseForm(isColorBlind);
            }
            else
            {
                callReadPhaseForm(isColorBlind);
            }
        }

        //Opens the write form
        private void writeTile_Click(object sender, EventArgs e)
        {
            if (isColorBlind == true)
            {
                callWritePhaseForm(isColorBlind);
            }
            else
            {
                callWritePhaseForm(isColorBlind);
            }
        }

        //Exits application
        private void exitTile_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Calls the WritePhaseForm
        private void callWritePhaseForm(bool colorSetting)
        {
            this.Hide();
            WritePhaseForm write = new WritePhaseForm();
            write.setColorBlind(colorSetting);
            write.ShowDialog();
        }

        //Calls the ReadPhaseForm
        private void callReadPhaseForm(bool colorSetting)
        {
            this.Hide();
            ReadPhaseForm read = new ReadPhaseForm();
            read.setColorBlind(colorSetting);
            read.ShowDialog();
        }

        //Colorblind mode function
        private void colorTest()
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;

            if (metroStyleManager.Theme == MetroThemeStyle.Light)
            {
                isColorBlind = true;
                metroStyleManager.Theme = MetroThemeStyle.Dark;
            }
            else
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
            }
        }

        //Extra feature: Math mini-game
        private void mathTile_Click(object sender, EventArgs e)
        {
            MathGame math = new MathGame();
            math.ShowDialog();
        }

        //Extra feature: Word Bank (Concatenated phonic words) -- experimental yet advanced version of Read Module
        private void wordBankBtn_Click(object sender, EventArgs e)
        {
            WordBank wordBank = new WordBank();
            wordBank.Show();
        }

        //Extra feature: Spelling mini-game
        private void spellTile_Click(object sender, EventArgs e)
        {
            SpellingGame spell = new SpellingGame();
            spell.Show();
        }

        //Extra feature: Guess the Phonics game
        private void guessGameTile_Click(object sender, EventArgs e)
        {
            GuessGame guess = new GuessGame();
            guess.Show();
        }

        //View Progress 
        private void viewProgressBtn_Click(object sender, EventArgs e)
        {
            ViewProgress view = new ViewProgress();
            view.Show();
        }
    }
}