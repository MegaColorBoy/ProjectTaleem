using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace MetroFrameworkDLLExample
{
    public partial class WriteForm : MetroForm
    {
        private WritePhaseForm writePhase;
        private String letters = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
        private String[] letterArr;
        String levelStr;
        public bool isColorBlind = false;

        VoiceAssistant vAssist;

        public WriteForm(WritePhaseForm writePhase, String levelStr)
        {
            InitializeComponent();
            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Write the letter, " + levelStr);
            //axShockwaveFlash2.Movie = @"C:\Users\Abdush Shakoor\Desktop\CSCI321\Flash Files\a.swf";
            //axShockwaveFlash2.Play();
            backBtn.Style = MetroColorStyle.Purple;
            this.levelStr = levelStr;
            letterLabel.Text = levelStr;
            this.writePhase = writePhase;

            letterArr = generateAlphabets(letters);

            WriteCanvas write = new WriteCanvas(this, levelStr);
            elementHost1.Child = write;
            this.Controls.Add(elementHost1);

            playFlash(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\MetroFrameworkDLLExample\bin\Debug\" + "Class" + LoginForm.classSec + @"_kidFlash\" + levelStr + ".swf");
        }

        public void playFlash(String dir)
        {
            axShockwaveFlash2.Movie = dir;
            axShockwaveFlash2.Play();          
        }

        public String[] generateAlphabets(String alphaStr)
        {
            String[] letterArr = alphaStr.Split(' ');
            return letterArr;
        }

        //Increments/updates to next level
        public String updateLevel(String lvl)
        {
            char c = lvl[0];
            //If it reaches the end, start from 'A' again
            if (c == 'Z')
            {
                c = 'A';
            }
            else
            {
                c++;
            }
            String x = c.ToString();
            return x;
        }


        //Updates level progress in ReadPhaseForm
        public void updateLevelProgress()
        {
            for (int i = 0; i < letterArr.Length; i++)
            {
                if (levelStr.Equals(letterArr[i]))
                {
                    writePhase.letterTiles[i].Text += "\nDONE!";
                }
            }
        }

        //Save as "kidname"+lvlprog.txt
        public void saveLevelProgress(String level)
        {
            String kidname = MainForm2.kidName;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Class" + LoginForm.classSec + "_kidLevelDB/" + kidname + "-writelvlprog.txt", true))
            {
                file.WriteLine("\n" + level);
            }
        }

        //If it's a new level
        public void newLevel(bool colorSetting)
        {
            this.Hide();
            var nextForm = new WriteForm(writePhase, updateLevel(levelStr));
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(isColorBlind);
            nextForm.Show();
        }

        //Repeat the level
        public void repeatLevel(bool colorSetting)
        {
            this.Hide();
            var nextForm = new WriteForm(writePhase, levelStr);
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(colorSetting);
            nextForm.Show();
        }

        //Changes theme, if colorblind
        public void setColorBlind(bool colorSetting)
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;
            if (colorSetting == true)
            {
                isColorBlind = true;
                metroStyleManager.Theme = MetroThemeStyle.Dark;
                letterLabel.ForeColor = Color.White;
                backBtn.Style = MetroColorStyle.Silver;

                //Change ink color as well
                //this.inkOverlay.DefaultDrawingAttributes.Color = Color.White;
            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
                letterLabel.ForeColor = Color.Black;
                backBtn.Style = MetroColorStyle.Purple;

                //Change ink color as well
                //this.inkOverlay.DefaultDrawingAttributes.Color = Color.Black;
            }
        }

        public void playResultSplashScreen()
        {
            try
            {
                Application.Run(new ResultSplashScreen());
            }
            catch(Exception)
            {
                //Do nothing
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            WritePhaseForm write = new WritePhaseForm();
            write.setColorBlind(isColorBlind);
            write.ShowDialog();
        }

        private void WriteForm_Load(object sender, EventArgs e)
        {
            //this.FormClosing += WriteForm_FormClosing;
            //this.FormClosed += WriteForm_FormClosed;
        }

        private void WriteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void WriteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}
