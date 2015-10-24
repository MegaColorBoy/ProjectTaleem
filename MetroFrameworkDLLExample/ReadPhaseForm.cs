using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;

namespace MetroFrameworkDLLExample
{
    public partial class ReadPhaseForm : MetroFramework.Forms.MetroForm
    {
        private static String database = "class" + LoginForm.classSec + "_db";
        String connStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
        public String isCB;
        bool isColorBlind = false;
        public MetroTile[] letterTiles;
        VoiceAssistant vAssist;

        public ReadPhaseForm()
        {
            InitializeComponent();

            String[] letterArr = getLevels(connStr);
            int numOfTiles = letterArr.Length-1;
            if (MainForm2.isCB == "Y")
            {
                generateGreyScale(numOfTiles, letterArr);
            }
            else
            {
                generateTiles(numOfTiles, letterArr);
            }

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Hey, Time to learn some phonics !");
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

        public void generateGreyScale(int numOfTiles, String[] letters)
        {
            letterTiles = new MetroTile[numOfTiles];
            int counter = 0;
            int posX = 50;
            int posY = 0;
            //Generate tiles
            for (int i = 0; i < letterTiles.Length; i++)
            {
                letterTiles[i] = new MetroTile();
            }

            while (counter < numOfTiles)
            {
                letterTiles[counter].Tag = counter + 1;
                letterTiles[counter].Height = 80;
                letterTiles[counter].Width = 80;

                if (counter % 5 == 0)
                {
                    posX = 50;
                    posY += 100;
                }

                letterTiles[counter].Left = posX;
                letterTiles[counter].Top = posY;

                tilePanel.Controls.Add(letterTiles[counter]);
                posX = posX + letterTiles[counter].Width + 50;
                letterTiles[counter].TileTextFontSize = MetroTileTextSize.Tall;
                letterTiles[counter].TileTextFontWeight = MetroTileTextWeight.Bold;
                letterTiles[counter].Name = letters[counter];
                letterTiles[counter].Text = letters[counter];
                if (updateLevelTile(MainForm2.kidName, letterTiles[counter].Text))
                {
                    letterTiles[counter].Text += "\nDONE!";
                }

                letterTiles[counter].TextAlign = ContentAlignment.MiddleCenter;
                letterTiles[counter].Style = MetroColorStyle.Silver;
                letterTiles[counter].Click += new System.EventHandler(ButtonEventHandler);
                counter++;
            }
        }

        public void generateTiles(int numOfTiles, String[] letters)
        {
            letterTiles = new MetroTile[numOfTiles];
            int counter = 0;
            int posX = 50;
            int posY = 0;
            //Generate tiles
            for (int i = 0; i < letterTiles.Length; i++)
            {
                letterTiles[i] = new MetroTile();
            }

            int colorCount = 0;
            while (counter < numOfTiles)
            {
                letterTiles[counter].Tag = counter + 1;
                letterTiles[counter].Height = 80;
                letterTiles[counter].Width = 80;

                if (counter % 5 == 0)
                {
                    posX = 50;
                    posY += 100;
                }
                
                letterTiles[counter].Left = posX;
                letterTiles[counter].Top = posY;

                tilePanel.Controls.Add(letterTiles[counter]);
                posX = posX + letterTiles[counter].Width + 50;
                letterTiles[counter].TileTextFontSize = MetroTileTextSize.Tall;
                letterTiles[counter].TileTextFontWeight = MetroTileTextWeight.Bold;
                letterTiles[counter].Name = letters[counter];
                letterTiles[counter].Text = letters[counter];
                if (updateLevelTile(MainForm2.kidName, letterTiles[counter].Text))
                {
                    letterTiles[counter].Text += "\nDONE!";
                }

                letterTiles[counter].TextAlign = ContentAlignment.MiddleCenter;

                if (colorCount == 0)
                {
                    letterTiles[counter].Style = MetroColorStyle.Red;
                    colorCount++;
                }
                else if (colorCount == 1)
                {
                    letterTiles[counter].Style = MetroColorStyle.Yellow;
                    colorCount++;
                }
                else if (colorCount == 2)
                {
                    letterTiles[counter].Style = MetroColorStyle.Orange;
                    colorCount++;
                }
                else if (colorCount == 3)
                {
                    letterTiles[counter].Style = MetroColorStyle.Green;
                    colorCount++;
                }
                else if (colorCount == 4)
                {
                    colorCount = 0;
                }

                letterTiles[counter].Click += new System.EventHandler(ButtonEventHandler);
                counter++;
            }
        }

        //Update tiles
        bool updateLevelTile(String kidName, String letterTile)
        {
            //Access kid file
            String[] lines = System.IO.File.ReadAllLines("Class" + LoginForm.classSec + "_kidLevelDB/" + MainForm2.kidName + "-readlvlprog.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == letterTile)
                {
                    return true;
                }
            }
            return false;
        }

        //Events that occur when you click the button
        void ButtonEventHandler(object sender, EventArgs e)
        {
            string buttonStr = ((Button)sender).Name;
            string current = buttonStr;
            callReadAudioForm(current);
            //ReadLetter_Test readTest = new ReadLetter_Test(current);
            //readTest.Show();
        }

        private void callReadAudioForm(string currentLevel)
        {
            this.Hide();
            ReadAudioForm3 read = new ReadAudioForm3(this,currentLevel);
            read.setColorBlind(isColorBlind);
            read.ShowDialog();
        }

        //Changes theme if color blind
        public void setColorBlind(bool colorSetting)
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;
            if (colorSetting == true)
            {
                isColorBlind = true;
                isCB = "YES";
                metroStyleManager.Theme = MetroThemeStyle.Dark;
                tilePanel.Theme = MetroThemeStyle.Dark;
            }
            else if(colorSetting == false)
            {
                isColorBlind = false;
                isCB = "NO";
                metroStyleManager.Theme = MetroThemeStyle.Light;
                tilePanel.Theme = MetroThemeStyle.Light;
            }
           // metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm2 m = new MainForm2("Class" + LoginForm.classSec + "_kidLoginImages/" + MainForm2.kidName + ".jpg");
            m.ShowDialog();
        }

        private void ReadPhaseForm_Load(object sender, EventArgs e)
        {
            //this.FormClosing += ReadPhaseForm_FormClosing;
            //this.FormClosed += ReadPhaseForm_FormClosed;
        }

        private void ReadPhaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void ReadPhaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}