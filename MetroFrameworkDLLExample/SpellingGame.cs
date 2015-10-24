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
using MetroFramework.Controls;
using MetroFramework;
using MySql.Data.MySqlClient;
using System.Speech.Recognition;
using NAudio;

namespace MetroFrameworkDLLExample
{
    public partial class SpellingGame : MetroForm
    {

        SpeechRecognitionEngine sre;
        String connStr = "Server=localhost; Port=3306; Database=taleemdatabase; Uid=root; Pwd=admin;";
        String[] words;
        private static NAudio.Wave.WaveFileReader wave = null;
        private static NAudio.Wave.DirectSoundOut output = null;
        int seconds = 60;
        int pos = 1;
        int points = 0;
        int wordsLeft = 1;
        VoiceAssistant vAssist;

        public SpellingGame()
        {
            InitializeComponent();
            words = getWords();
            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();
            numOfWordsLabel.Text = "Words: " + wordsLeft.ToString() + "/" + words.Length.ToString(); 
            game(pos - 1);
        }

        //Download the words from the DB
        private String[] getWords()
        {
            List<String> list = new List<String>();
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlDataReader reader;
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Word FROM spelltable_db";
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list.ToArray();
        }

        private void askQuestion(String word)
        {
            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Okay, Spell " + word + "!");
        }

        private void game(int pos)
        {
            answerLabel.Text = null;
            pointsLabel.Text = points.ToString();
            sre = new SpeechRecognitionEngine();
            Choices sList = new Choices();

            String[] letters = getLetters(words[pos]);
            //label1.Text = words[pos];
            //label2.Text = pos.ToString();
            jumbledWordLabel.Text = scrambleLetters(words[pos]);
            wordPicBox.ImageLocation = "Class" + LoginForm.classSec + "_kidSpellImages/" + words[pos] + ".jpg";
            this.wordPicBox.SizeMode = PictureBoxSizeMode.Zoom;

            askQuestion(words[pos]);
            sList.Add(letters);

            Grammar gr = new Grammar(new GrammarBuilder(sList));

            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += rec_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Scrambles letters
        private String scrambleLetters(String str)
        {
            char[] charArr = str.ToCharArray();
            Random r = new Random();
            int x = r.Next(2, 6);
            Random rand = new Random(x);
            for (int i = 0; i < charArr.Length; i++)
            {
                int index = rand.Next(i, charArr.Length);
                char temp = charArr[index];
                charArr[index] = charArr[i];
                charArr[i] = temp;
            }
            return new String(charArr);
        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Confidence > -1f)
            {
                answerLabel.Text += e.Result.Text.ToString();

                if (answerLabel.Text.Length == 3 && answerLabel.Text == words[pos - 1])
                {
                    playSound("WON");
                   //MessageBox.Show("CORRECT! " + answerLabel.Text);
                    points++;
                    wordsLeft++;
                    numOfWordsLabel.Text = "Words: " + wordsLeft.ToString() + "/" + words.Length.ToString();
                    answerLabel.Text = null;
                    sre.RecognizeAsyncStop();
                    if (pos == words.Length)
                    {
                        pos = 1;
                        wordsLeft = 1;
                        seconds = 0;
                        stopGame();
                    }
                    else
                    {
                        pos = pos + 1;
                    }
                    if (seconds > 0)
                    {
                        game(pos - 1); 
                    }
                    //MessageBox.Show("result: " + e.Result.Text.ToString());
                }
                else if (answerLabel.Text.Length == 3 && answerLabel.Text != words[pos - 1])
                {
                    playSound("LOSE");
                    //MessageBox.Show("WRONG! " + answerLabel.Text);
                    wordsLeft++;
                    numOfWordsLabel.Text = "Words: " + wordsLeft.ToString() + "/" + words.Length.ToString();
                    answerLabel.Text = null;
                    sre.RecognizeAsyncStop();
                    if (pos == words.Length)
                    {
                        pos = 1;
                        wordsLeft = 1;
                        seconds = 0;
                        stopGame();
                    }
                    else
                    {
                        pos = pos + 1;
                    }

                    if (seconds > 0)
                    {
                        game(pos - 1);
                    }
                }
            }
        }

        private String[] getLetters(String str)
        {
            List<String> list = new List<String>();
            for (int i = 0; i < str.Length; i++)
            {
                list.Add(str[i].ToString());
            }
            return list.ToArray();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DisposeWave();
            sre.RecognizeAsyncStop();
            this.Hide();
            MainForm2 m = new MainForm2("Class" + LoginForm.classSec + "_kidLoginImages/" + MainForm2.kidName + ".jpg");
            m.ShowDialog();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            seconds = 60;
            points = 0;
            pos = 1;
            wordsLeft = 1;
            numOfWordsLabel.Text = "Words: " + wordsLeft.ToString() + "/" + words.Length.ToString();
            jumbledWordLabel.Text = null;
            answerLabel.Text = null;
            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();

            game(pos - 1);
        }

        private void stopGame()
        {
            stopProcess();
            jumbledWordLabel.Text = "GAME OVER !";
            answerLabel.Text = "PRESS RESTART\nTO TRY AGAIN !";

            String file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\airhorn.wav";
            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();

            MessageBox.Show("TIME'S UP !");
            MessageBox.Show("Total score: " + points);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds = seconds - 1;
            if (seconds == 0)
            {
                stopProcess();
                jumbledWordLabel.Text = "GAME OVER !";
                answerLabel.Text = "PRESS RESTART\nTO TRY AGAIN !";

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

        private void playSound(String res)
        {
            string file;
            if (res.Equals("WON"))
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\Mario Coin.wav";
            }
            else
            {
                file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\lose.wav";
            }

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(file);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();
        }

        private void stopProcess()
        {
            timer1.Stop();
            DisposeWave();
            sre.RecognizeAsyncStop();
        }

        private void SpellingGame_Load(object sender, EventArgs e)
        {
            this.FormClosing += SpellingGame_FormClosing;
            this.FormClosed += SpellingGame_FormClosed;
        }

        void SpellingGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopProcess();
        }

        void SpellingGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopProcess();
        }
    }
}
