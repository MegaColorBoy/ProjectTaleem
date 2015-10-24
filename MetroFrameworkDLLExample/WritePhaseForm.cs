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
    public partial class WritePhaseForm : MetroFramework.Forms.MetroForm
    {
        bool isColorBlind = false;
        private static readonly Random Random = new Random();
        public MetroTile[] letterTiles;
        public String kidName;
        VoiceAssistant vAssist;
        public WritePhaseForm()
        {
            InitializeComponent();
            String alphaStr = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            String[] letterArr = generateAlphabets(alphaStr);
            int numOfTiles = letterArr.Length;
            if (MainForm2.isCB == "Y")
            {
                generateGreyScale(numOfTiles, letterArr);
            }
            else
            {
                generateTiles(numOfTiles, letterArr);
            }
            kidName = MainForm2.kidName;

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Pick a letter and let's learn to write !");
        }

        //Generates 26 alphabets
        public String[] generateAlphabets(String alphaStr)
        {
            String[] letterArr = alphaStr.Split(' ');
            return letterArr;
        }

        public void generateGreyScale(int numOfTiles, String[] letters)
        {
            letterTiles = new MetroTile[numOfTiles];
            int counter = 0;
            int posX = 30;
            int posY = 0;
            //Generate tiles
            for (int i = 0; i < letterTiles.Length; i++)
            {
                letterTiles[i] = new MetroTile();
            }

            while (counter < numOfTiles)
            {
                letterTiles[counter].Tag = counter + 1;
                letterTiles[counter].Height = 90;
                letterTiles[counter].Width = 90;

                if (counter % 6 == 0)
                {
                    posX = 30;
                    posY += 120;
                }

                letterTiles[counter].Left = posX;
                letterTiles[counter].Top = posY;

                tilePanel.Controls.Add(letterTiles[counter]);
                posX = posX + letterTiles[counter].Width + 30;
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

        //generates tiles
        public void generateTiles(int numOfTiles, String[] letters)
        {
            letterTiles = new MetroTile[numOfTiles];
            int counter = 0;
            int posX = 30;
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
                letterTiles[counter].Height = 90; 
                letterTiles[counter].Width = 90;

                if (counter % 6 == 0)
                {
                    posX = 30;
                    posY += 120;
                }


                letterTiles[counter].Left = posX;
                letterTiles[counter].Top = posY;

                
                tilePanel.Controls.Add(letterTiles[counter]);
                posX = posX + letterTiles[counter].Width + 30;
                letterTiles[counter].TileTextFontSize = MetroTileTextSize.Tall;
                letterTiles[counter].TileTextFontWeight = MetroTileTextWeight.Bold;
                letterTiles[counter].Name = letters[counter];
                letterTiles[counter].Text = letters[counter];
                if (updateLevelTile(kidName, letterTiles[counter].Text))
                {
                    letterTiles[counter].Text += "\nDONE!";
                }
                letterTiles[counter].TextAlign = ContentAlignment.MiddleCenter;

                //int next = Random.Next(10, 12);
                //letterTiles[counter].Style = (MetroColorStyle)next;

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
            String[] lines = System.IO.File.ReadAllLines("Class" + LoginForm.classSec + "_kidLevelDB/" + MainForm2.kidName + "-writelvlprog.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == letterTile)
                {
                    return true;
                }
            }
            return false;
        }

        void ButtonEventHandler(object sender, EventArgs e)
        {
            string buttonStr = ((Button)sender).Name;
            string current = buttonStr;
            callWriteLetterForm(current);
        }

        //Calls the WriteLetter_Test form i.e. you get to play this new level
        private void callWriteLetterForm(string currentLevel)
        {
            this.Hide();
            WriteForm write = new WriteForm(this, currentLevel);
            write.setColorBlind(isColorBlind);
            write.ShowDialog();
            //WriteLetter_Test writeTest = new WriteLetter_Test(this, currentLevel);
            //writeTest.setColorBlind(isColorBlind);
            //writeTest.Show();
        }

        //Changes theme if color blind
        public void setColorBlind(bool colorSetting)
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;
            if (colorSetting == true)
            {
                isColorBlind = true;
                metroStyleManager.Theme = MetroThemeStyle.Dark;
                tilePanel.Theme = MetroThemeStyle.Dark;
            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
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

        private void WritePhaseForm_Load(object sender, EventArgs e)
        {
            //this.FormClosing += WritePhaseForm_FormClosing;
            //this.FormClosed += WritePhaseForm_FormClosed;
        }

        private void WritePhaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void WritePhaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

    }
}
