using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using NAudio;

//This is a simple, basic-arthimetic mini-game
namespace MetroFrameworkDLLExample
{
    public partial class MathGame : MetroForm
    {
        SpeechRecognitionEngine speak;
        Choices numList;
        Grammar gr;
        int a, b, result, points = 0;
        String sign;
        static Random rnd1 = new Random();
        private static NAudio.Wave.WaveFileReader wave = null;
        private static NAudio.Wave.DirectSoundOut output = null;
        int seconds = 60;
        int numOfCheat = 3;
        VoiceAssistant vAssist;

        public MathGame()
        {
            InitializeComponent();
            //Amount of time to take voice input
            //startRecord(sender, e);
            timerLabel.Visible = true;
            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();

            startGame();
        }

        private void startGame()
        {
            pointsLabel.Text = points.ToString();
            numList = new Choices();
            numList.Add(new String[]{"0","1","2","3","4","5","6","7","8","9","10","CHEAT"});
            gr = new Grammar(new GrammarBuilder(numList));
            speak = new SpeechRecognitionEngine();
            Random rnd2 = new Random();

            a = rnd2.Next(1, 5);
            b = rnd2.Next(1, 5);

            sign = randomSign();
            inputAnswer(a, b, sign);
        }

        private static String randomSign()
        {
            if (rnd1.Next() % 2 == 0)
            {
                return "+";
            }
            else
            {
                return "-";
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

        private static String questionBuilder(int a, int b, String sign)
        {
            String question;
            if (b > a)
            {
                int temp = b;
                b = a;
                a = temp;
            }
            question = a + " " + sign + " " + b + " = ?";
            return question;
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

        private void askQuestion(int a, int b, String sign)
        {
            String signWord="";
            if(sign == "+")
            {
                signWord = "plus";
            }
            if(sign == "-")
            {
                signWord = "minus";
            }

            if (b > a)
            {
                int temp = b;
                b = a;
                a = temp;
            }

            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("What is " + a.ToString() + " " + signWord + " " + b.ToString() + " ?");
        }

        private void inputAnswer(int a, int b, String sign)
        {
            String question = questionBuilder(a, b, sign);
            questLabel.Text = question;

            askQuestion(a, b, sign);

            try
            {
                speak.RequestRecognizerUpdate();
                speak.LoadGrammar(gr);
                //Calling the event handler to recognize voice input
                speak.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speak_SpeechRecognized);
                speak.SetInputToDefaultAudioDevice();
                speak.RecognizeAsync(RecognizeMode.Single);
            }
            catch
            {
                return;
            }
        }

        private int checkResult(int a, int b, String sign)
        {
            if (b > a)
            {
                int temp = b;
                b = a;
                a = temp;
            }

            if (sign == "-")
            {
                return a - b;
            }
            else
            {
                return a + b;
            }
        }

        private void speak_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            result = checkResult(a, b, sign);

            //Just setting the minimum confidence level to get inputs.
            if (e.Result.Confidence > -10f)
            {
                if (e.Result.Text.Equals(result.ToString()))
                {
                    playSound("WON");
                    MessageBox.Show("Result: " + a + " " + sign + " " + b + " = " + result.ToString());
                    //MessageBox.Show(e.Result.Confidence.ToString());
                    statusLabel.Text = "GOOD";
                    points++;
                    pointsLabel.Text = points.ToString();
                }
                else if (e.Result.Text.Equals("CHEAT") && numOfCheat > 0)
                {
                    MessageBox.Show("CHEAT USED\nOnly " + numOfCheat + " remaining !");
                    MessageBox.Show("Result: " + a + " " + sign + " " + b + " = " + result.ToString());
                    points++;
                    numOfCheat--;
                }
                else if (e.Result.Text.Equals("CHEAT") && numOfCheat == 0)
                {
                    MessageBox.Show("CHEAT OVER !");
                }
                else if (!e.Result.Text.Equals(result.ToString()))
                {
                    playSound("LOSE");
                    MessageBox.Show("Result: " + a + " " + sign + " " + b + " = " + result.ToString());
                    statusLabel.Text = "BAD";
                    //MessageBox.Show("Wrong!");
                }
                if (seconds > 0)
                {
                    startGame();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds = seconds - 1;
            if(seconds == 0)
            {
                stopProcess();
                questLabel.Text = "GAME OVER !";
                statusLabel.Text = "PRESS RESTART\nTO TRY AGAIN !";

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

        private void backBtn_Click(object sender, EventArgs e)
        {
            stopProcess();
            this.Hide();
            MainForm2 m = new MainForm2("Class" + LoginForm.classSec + "_kidLoginImages/" + MainForm2.kidName + ".jpg");
            m.ShowDialog();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            seconds = 60;
            points = 0;
            timerLabel.Visible = true;
            timerLabel.Text = Convert.ToString(seconds);
            timer1.Start();

            startGame();
        }

        private void stopProcess()
        {
            timer1.Stop();
            DisposeWave();
            speak.RecognizeAsyncStop();
        }

        private void MathGame_Load(object sender, EventArgs e)
        {
            this.FormClosed += MathGame_FormClosed;
            this.FormClosing += MathGame_FormClosing;
        }

        void MathGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopProcess();
        }

        void MathGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopProcess();
        }

    }
}