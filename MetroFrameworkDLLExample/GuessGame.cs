using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;
using NAudio;
using NAudio.Wave;

//Guess the phonics game !
namespace MetroFrameworkDLLExample
{
    public partial class GuessGame : MetroForm
    {
        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;
        Button[] buttons;
        List<String> letters;
        String mainLetter;
        int points = 0;
        int seconds = 60;
        VoiceAssistant vAssist;

        public GuessGame()
        {
            InitializeComponent();
            letters = getLetters();

            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Time to guess the phonics !");
            Thread.Sleep(1000);
            game();
        }

        private void game()
        {
            gameOverLabel.Visible = false;
            restartLabel.Visible = false;
            pointsLabel.Text = points.ToString();
            //Original list
            List<String> list = letters.ToList();

            //Copy original list
            List<String> list2, list3, list4;
            list2 = list;
            Random rnd1 = new Random();

            //Select the random letter to be played with
            int index = rnd1.Next(0, list.Count);
            String letter = list2[index];
            mainLetter = letter;

            //remove the letter from the list
            list2.RemoveAt(index);
            list3 = list2;

            //pick 3 more random letters + add the letter that I have picked
            list4 = randomLetters(letter, list3);
            list4 = scrambleLetters(list4);
            //Now, generate buttons with the 4 randomly picked letters
            generateButtons(list4);

            playSound("LETTER", @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + mainLetter + ".wav");
        }


        //Gets letters based on the number of audio files are available
        private List<String> getLetters()
        {
            String dir = "Class" + LoginForm.classSec + "_kidAudio";
            String[] files = Directory.GetFiles(dir, "*.wav");
            List<String> list = new List<String>();
            foreach(String file in files)
            {
                list.Add(splitDir(file));
            }
            return list;
        }

        private String splitDir(String str)
        {
            String[] splitArr = str.Split('\\');
            String[] splitWAV = splitArr[splitArr.Length - 1].Split('.');
            return splitWAV[0];
        }

        private void generateButtons(List<String>list)
        {
            buttons = new Button[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = list[i];
                buttons[i].Size = new System.Drawing.Size(100, 100);
                buttons[i].BackColor = Color.BlanchedAlmond;
                buttons[i].Font = new Font(buttons[i].Font.FontFamily, 16, buttons[i].Font.Style | FontStyle.Bold);

                //Crashes sometimes due to not having enough pictures in the DB ! 
                //Otherwise, it works with the available ones !
                //buttons[i].Image = Image.FromFile("Class" + LoginForm.classSec + "_kidImages/" + list[i] + ".jpg");

                flowLayoutPanel1.Controls.Add(buttons[i]);
                buttons[i].Click += new System.EventHandler(ButtonEventHandler);
            }
        }

        private void ButtonEventHandler(object sender, EventArgs e)
        {
            String text = ((Button)sender).Text;
            checkResult(text);
        }

        private void checkResult(String text)
        {
            if (text.Equals(mainLetter) && seconds != 0)
            {
                playSound("WON", @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\Mario Coin.wav");
                points++;
                MessageBox.Show("correct!");

            }
            else if(!text.Equals(mainLetter) && seconds != 0)
            {
                playSound("LOSE", @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\lose.wav");
                MessageBox.Show("wrong!");
            }

            if (seconds > 0)
            {
                label1.Text = null;
                clearPanel();
                game();
            }
        }

        //Scrambles letters, just to challenge the user ;) !
        private List<String> scrambleLetters(List<String> list)
        {
            String[] strArr = list.ToArray();
            Random r = new Random();
            //int x = r.Next(0, list.Count);
            Random rand = new Random();
            for (int i = 0; i < strArr.Length; i++)
            {
                int index = rand.Next(i, strArr.Length);
                String temp = strArr[index];
                strArr[index] = strArr[i];
                strArr[i] = temp;
            }
            return strArr.ToList();
        }

        //Clear the button panel after every level
        private void clearPanel()
        {
            List<Control> controls = flowLayoutPanel1.Controls.Cast<Control>().ToList();
            foreach (Control control in controls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }
        }

        //Picks 3 letters
        private List<String> randomLetters(String myLetter, List<String> list)
        {
            int count = 0;
            int maxCount = 2;
            List<String> list2 = new List<String>();
            for (int i = 0; i < list.Count; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, list.Count);
                String letter = list[index];
                list2.Add(letter);
                list.RemoveAt(index);
                if (count == maxCount)
                {
                    break;
                }
                else
                {
                    count++;
                }
            }
            list2.Add(myLetter);
            return list2;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void soundPicBox_Click(object sender, EventArgs e)
        {
            String dir = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\TeacherWAV\" + mainLetter + ".wav";
            playSound("LETTER", dir);
        }

        private void playSound(String type, String dir)
        {
            DisposeWave();
            if (type.Equals("LETTER"))
            {
                wave = new NAudio.Wave.WaveFileReader(dir);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(new NAudio.Wave.WaveChannel32(wave));
                output.Play();
            }
            else if(type.Equals("WON"))
            {
                wave = new NAudio.Wave.WaveFileReader(dir);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(new NAudio.Wave.WaveChannel32(wave));
                output.Play();
            }
            else if(type.Equals("LOSE"))
            {
                wave = new NAudio.Wave.WaveFileReader(dir);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(new NAudio.Wave.WaveChannel32(wave));
                output.Play();
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

        private void restartBtn_Click(object sender, EventArgs e)
        {
            seconds = 60;
            points = 0;
            gameOverLabel.Visible = false;
            restartLabel.Visible = false;
            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();
            clearPanel();
            soundPicBox.Visible = true;
            game();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            stopProcess();
            this.Hide();
            MainForm2 m = new MainForm2("Class" + LoginForm.classSec + "_kidLoginImages/" + MainForm2.kidName + ".jpg");
            m.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds = seconds - 1;
            if (seconds == 0)
            {
                clearPanel();
                stopProcess();
                gameOverLabel.Visible = true;
                restartLabel.Visible = true;
                gameOverLabel.Text = "GAME OVER !";
                restartLabel.Text = "PRESS RESTART\nTO TRY AGAIN !";
                soundPicBox.Visible = false;

                String file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\airhorn.wav";
                wave = new NAudio.Wave.WaveFileReader(file);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(new NAudio.Wave.WaveChannel32(wave));
                output.Play();

                MessageBox.Show("TIME'S UP !");
                MessageBox.Show("Total score: " + points);
            }
            timerLabel.Text = Convert.ToString(seconds);
        }

        private void stopProcess()
        {
            timer1.Stop();
            DisposeWave();
        }

        private void GuessGame_Load(object sender, EventArgs e)
        {
            this.FormClosing += GuessGame_FormClosing;
            this.FormClosed += GuessGame_FormClosed;
        }

        void GuessGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopProcess();
        }

        void GuessGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopProcess();
        }



    }
}
