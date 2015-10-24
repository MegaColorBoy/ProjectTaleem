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
using Microsoft.Ink;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

//The writing phase
namespace MetroFrameworkDLLExample
{
    public partial class WriteLetter_Test : MetroFramework.Forms.MetroForm
    {
        private WritePhaseForm writePhase;
        private String letters = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
        private String[] letterArr;

        bool isColorBlind = false;
        private InkOverlay inkOverlay;
        RecognizerContext context = new RecognizerContext();
        bool drawMode = true;
        String levelStr;

        public WriteLetter_Test(WritePhaseForm writePhase, String str)
        {
            this.writePhase = writePhase;
            levelStr = str;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            letterArr = generateAlphabets(letters);

            LetterLabel.Text = str;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.inkOverlay = new InkOverlay(this);
            this.inkOverlay.Enabled = true;
            this.FormClosing += new FormClosingEventHandler(WriteLetter_Test_FormClosing);
        }

        public String[] generateAlphabets(String alphaStr)
        {
            String[] letterArr = alphaStr.Split(' ');
            return letterArr;
        }

        void WriteLetter_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.inkOverlay.Dispose();
        }

        //Prototype function to go to the next level
        String updateLevel(String lvl)
        {
            char c = lvl[0];
            c++;
            String x = c.ToString();
            return x;
        }

        //Checks if it's correct or not
        private void recogBtn_Click(object sender, EventArgs e) 
        {
            context.Strokes = this.inkOverlay.Ink.Strokes;

            try
            {
                RecognitionStatus status;
                RecognitionResult result = context.Recognize(out status);

                if (result.TopString == levelStr)
                {
                    MessageBox.Show("Correct");
                    DialogResult diagRes = MessageBox.Show("Do you want to proceed or try again?", "important", MessageBoxButtons.YesNo);

                    //Change theme, if colorblind and progress to new level
                    if (diagRes == DialogResult.Yes)
                    {
                        this.Hide();
                        //Create a method that says "solved" after each level on the button
                        //xxxxxxxx
                        
                        if (isColorBlind == true)
                        {
                            updateLevelProgress();
                            newLevel(isColorBlind);
                            saveLevelProgress(levelStr);
                        }
                        else
                        {
                            updateLevelProgress();
                            newLevel(isColorBlind);
                            saveLevelProgress(levelStr);
                        }
                    }
                    //Otherwise, repeat the level
                    else if (diagRes == DialogResult.No)
                    {
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
                    MessageBox.Show("Wrong");
                }
            }
            catch (Exception)
            {
                //For the lulz -- just change it later lol !
                MessageBox.Show("No input has been detected!");
                //MessageBox.Show(ex.ToString());
            }
            //MessageBox.Show(result.TopString);
            //context.Dispose();
        }

        //Eraser/Pen
        private void eraseBtn_Click(object sender, EventArgs e)
        {
            if (drawMode)
            {
                eraseBtn.Text = "Draw";
                inkOverlay.EditingMode = InkOverlayEditingMode.Delete;
                drawMode = false;
            }
            else
            {
                eraseBtn.Text = "Eraser";
                inkOverlay.EditingMode = InkOverlayEditingMode.Ink;
                drawMode = true;
            }
        }
        //If it's a new level
        private void newLevel(bool colorSetting)
        {
            var nextForm = new WriteLetter_Test(writePhase, updateLevel(levelStr));
            nextForm.FormClosed += (s, args) => this.Close();
            nextForm.setColorBlind(isColorBlind);
            nextForm.Show();
        }

        //Repeat the level
        private void repeatLevel(bool colorSetting)
        {
            var nextForm = new WriteLetter_Test(writePhase, levelStr);
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
                //Change ink color as well
                this.inkOverlay.DefaultDrawingAttributes.Color = Color.White;
            }
            else if (colorSetting == false)
            {
                isColorBlind = false;
                metroStyleManager.Theme = MetroThemeStyle.Light;
                //Change ink color as well
                this.inkOverlay.DefaultDrawingAttributes.Color = Color.Black;
            }
        }

        //prototype for saving level progress
        private void changeBtn_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < letterArr.Length; i++)
            //{
            //    if (levelStr.Equals(letterArr[i]))
            //    {
            //        writePhase.letterTiles[i].Text += "\nDONE!";
            //    }
            //}
        }

        //Updates level progress in ReadPhaseForm
        private void updateLevelProgress()
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
        private void saveLevelProgress(String level)
        {
            String kidname = MainForm.kidName;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"kidLevelDB\" + kidname + "-writelvlprog.txt", true))
            {
                file.WriteLine("\n" + level);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            WritePhaseForm write = new WritePhaseForm();
            write.setColorBlind(isColorBlind);
            write.ShowDialog();
        }

    }//End class
}
