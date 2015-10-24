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

//New main user interface !!
namespace MetroFrameworkDLLExample
{
    public partial class MainForm2 : MetroForm
    {
        String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";

        bool isColorBlind = false;
        public static string isCB = "";
        public static String kidName = "";
        VoiceAssistant vAssist;

        static String[] buttonNames = { "readBtn", "writeBtn", "wordBankBtn", "mathGameBtn", "spellGameBtn", "guessGameBtn" };
        Button[] buttons;

        public MainForm2(String filename)
        {
            InitializeComponent();
            getData(connStr, "spelltable_db");
            getData(connStr, "image_db");
            getData(connStr, "audio_db");
            getData(connStr, "flash_db");
            getData(connStr, "wordbank_image");
            getData(connStr, "wordbank_audio");

            viewProgressBtn.TileTextFontSize = MetroTileTextSize.Tall;
            viewProgressBtn.TileTextFontWeight = MetroTileTextWeight.Bold;
            exitTile.TileTextFontSize = MetroTileTextSize.Tall;
            exitTile.TileTextFontWeight = MetroTileTextWeight.Bold;

            loginPic.ImageLocation = filename;
            this.loginPic.SizeMode = PictureBoxSizeMode.Zoom;

            accessChildDatabaseV2(filename);

            if(isCB == "Y")
            {
                colorTest();
                convertIconsToGrayScale();
                exitTile.Style = MetroColorStyle.Silver;
                viewProgressBtn.Style = MetroColorStyle.Silver;
            }
            else
            {
                exitTile.Style = MetroFramework.MetroColorStyle.Red;
                viewProgressBtn.Style = MetroColorStyle.Green;
            }

            generateButtons();

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Welcome, Please select an option !");
        }

        //This method downloads all the AV files and images required for the applicatiion
        private void getData(String connectionStr, String db)
        {
            String command = "";
            String dir = "";
            String format = "";

            if (db.Equals("image_db"))
            {
                command = "SELECT PhonicsName, Image FROM image_db";
                dir = "Class" + LoginForm.classSec + "_kidImages";
                format = ".jpg";
            }
            else if (db.Equals("audio_db"))
            {
                command = "SELECT PhonicsName, Audio FROM audio_db";
                dir = "Class" + LoginForm.classSec + "_kidAudio";
                format = ".wav";
            }
            else if (db.Equals("flash_db"))
            {
                command = "SELECT Letters, Flash FROM flash_db";
                dir = "Class" + LoginForm.classSec + "_kidFlash";
                format = ".swf";
            }
            else if (db.Equals("spelltable_db"))
            {
                command = "SELECT Word, Image FROM spelltable_db";
                dir = "Class" + LoginForm.classSec + "_kidSpellImages";
                format = ".jpg";
            }
            else if (db.Equals("wordbank_image"))
            {
                command = "SELECT Word, Image FROM wordbank_db";
                dir = "Class" + LoginForm.classSec + "_kidWordImages";
                format = ".jpg";
            }
            else if (db.Equals("wordbank_audio"))
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

        //Converts the main menu icons to Grayscale.
        //Just manipulated the colors ! ;)
        private void convertIconsToGrayScale()
        {
            if (!Directory.Exists("menuGrayScaleIcons"))
            {
                String[] files = Directory.GetFiles(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\menuIcons", "*.jpg");
                Directory.CreateDirectory("menuGrayScaleIcons");

                for (int i = 0; i < files.Length; i++)
                {
                    Bitmap bmp = new Bitmap(files[i]);
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color c = bmp.GetPixel(x, y);

                            int r = c.R;
                            int g = c.G;
                            int b = c.B;
                            int average = (r + g + b) / 3;
                            bmp.SetPixel(x, y, Color.FromArgb(average, average, average));
                        }
                    }
                    bmp.Save(@"menuGrayScaleIcons\" + (i+1).ToString() + ".jpg");
                }
            }
        }

        //Generates main menu buttons with images !
        private void generateButtons()
        {
            buttons = new Button[buttonNames.Length];
            for(int i=0; i<buttonNames.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = buttonNames[i];
                buttons[i].Size = new Size(240,220);
                if (isCB == "Y")
                {
                    buttons[i].BackgroundImage = Image.FromFile(@"menuGrayScaleIcons\" + (i + 1).ToString() + ".jpg");

                }
                else
                {
                    buttons[i].BackgroundImage = Image.FromFile(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\menuIcons\" + (i + 1).ToString() + ".jpg");
                }
                buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[i].FlatStyle = FlatStyle.Standard;
                flowLayoutPanel1.Controls.Add(buttons[i]);
                buttons[i].Click += ButtonEventHandler;
            }
        }

        private void ButtonEventHandler(object sender, EventArgs e)
        {
            String buttonName = ((Button)sender).Name;
            if(buttonName == "readBtn")
            {
                callReadPhaseForm(isColorBlind);
            }
            else if(buttonName == "writeBtn")
            {
                callWritePhaseForm(isColorBlind);
            }
            else if (buttonName == "wordBankBtn")
            {
                WordBank wordBank = new WordBank();
                wordBank.Show();
            }
            else if (buttonName == "mathGameBtn")
            {
                MathGame math = new MathGame();
                math.ShowDialog();
            }
            else if (buttonName == "spellGameBtn")
            {
                SpellingGame spell = new SpellingGame();
                spell.Show();
            }
            else if (buttonName == "guessGameBtn")
            {
                GuessGame guess = new GuessGame();
                guess.Show();
            }
        }

        private void createFile(String kidName)
        {
            if (!Directory.Exists("Class" + LoginForm.classSec + "_kidLevelDB"))
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

        private void viewProgressBtn_Click(object sender, EventArgs e)
        {
            ViewProgress view = new ViewProgress();
            view.Show();
        }

        private void exitTile_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

    }
}
