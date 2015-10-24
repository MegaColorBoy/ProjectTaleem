using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using MySql.Data.MySqlClient;
//Using NAudio API for record, play and stop audio
using NAudio;
using NAudio.Wave;
//Using musicg-api for FFT, Audio fingerprinting and similarity checks
using com.musicg.fingerprint;
using com.musicg.wave;
//using Java library for FileStream (to read the .wav files)
using java.io;

namespace MetroFrameworkDLLExample
{
    /// <summary>
    /// Interaction logic for WaveForm.xaml
    /// </summary>
    public partial class WaveForm : UserControl
    {
        public static int time = 10;
        private DispatcherTimer dispatcherTimer;

        private static NAudio.Wave.WaveIn wavSource = null;
        private static NAudio.Wave.WaveFileWriter wavFile = null;
        
        //This is for plotting the graph
        private Polyline polyLine;
        double canvasHeight = 0;
        double canvasWidth = 0;
        double polyHeight = 0;
        double polyWidth = 0;
        List<byte> totalBytes;
        Queue<Point> dispPoints;
        Queue<Int32> dispShots;
        long counter;
        int numToDisp = 2205;

        private ReadAudioForm3 read;
        String lvlStr;
        bool isColorBlind;

        public WaveForm(ReadAudioForm3 read, String lvlStr)
        {
            InitializeComponent();
            this.read = read;
            this.lvlStr = lvlStr;
            isColorBlind = read.isColorBlind;
            CountDownBlk.Text = string.Format("0{0}:{1}", time / 60, time % 60);
            startTimer();
            startRecording();
        }

        //Starts the timer
        private void startTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        //Starts recording
        private void startRecording()
        {
            ReadAudioForm3.backButton.Enabled = false;
            ReadAudioForm3.submitButton.Enabled = false;
            wavSource = new WaveIn();
            wavSource.DataAvailable += new EventHandler<WaveInEventArgs>(wavSource_DataAvailable);
            wavSource.RecordingStopped += new EventHandler<StoppedEventArgs>(wavSource_RecordingStopped);
            //wavSource.WaveFormat = new WaveFormat(44100, 1);
            wavSource.WaveFormat = new WaveFormat(8000,16,1);

            String filename = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav";

            wavFile = new WaveFileWriter(filename, wavSource.WaveFormat);
            canvasHeight = waveCanvas.Height;
            canvasWidth = waveCanvas.Width;

            polyLine = new Polyline();
            polyLine.Stroke = Brushes.Black;
            polyLine.StrokeThickness = 1;
            polyLine.Name = "waveform";
            polyLine.MaxHeight = canvasHeight - 4;
            polyLine.MaxWidth = canvasWidth - 4;

            polyHeight = polyLine.MaxHeight;
            polyWidth = polyLine.MaxWidth;

            counter = 0;

            dispPoints = new Queue<Point>();
            totalBytes = new List<byte>();
            dispShots = new Queue<Int32>();

            wavSource.StartRecording();
        }

        //Event arguments to stop recording
        private void wavSource_RecordingStopped(object sender, EventArgs e)
        {
            wavSource.Dispose();
            wavSource = null;
            wavFile.Close();
            wavFile.Dispose();
            wavFile = null;
        }

        //Event arguments to write data
        private void wavSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            wavFile.Write(e.Buffer, 0, e.BytesRecorded);
            totalBytes.AddRange(e.Buffer);
            wavFile.Flush();

            byte[] shots = new byte[4];

            for (int i = 0; i < e.BytesRecorded-1; i+=100)
            {
                shots[0] = e.Buffer[i];
                shots[1] = e.Buffer[i+1];
                shots[2] = e.Buffer[i+2];
                shots[3] = e.Buffer[i+3];
                if (counter < numToDisp)
                {
                    dispShots.Enqueue(BitConverter.ToInt32(shots, 0));
                    counter++;
                }
                else
                {
                    dispShots.Dequeue();
                    dispShots.Enqueue(BitConverter.ToInt32(shots, 0));
                }
            }

            this.waveCanvas.Children.Clear();
            polyLine.Points.Clear();

            Int32[] shots2 = dispShots.ToArray();
            for (Int32 i = 0; i < shots2.Length; i++)
            {
                polyLine.Points.Add(Normalize(i, shots2[i]));
            }

            this.waveCanvas.Children.Add(polyLine);
        }

        Point Normalize(Int32 px, Int32 py)
        {
            Point p = new Point();
            p.X = 1.0 * px / numToDisp * polyWidth;
            p.Y = polyHeight / 2.0 - py / (Int32.MaxValue * 1.0) * (polyHeight / 2.0);
            return p;
        }

        //Timer event
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            time--;
            CountDownBlk.Text = string.Format("0{0}:{1}", time / 60, time % 60);
            if (time < 5)
            {
                if (time % 2 == 0)
                {
                    CountDownBlk.Foreground = Brushes.Red;
                }
                else
                {
                    CountDownBlk.Foreground = Brushes.DarkRed;
                }
            }

            if(time == 0)
            {
                dispatcherTimer.Stop();
                wavSource.StopRecording();
                polyLine.Points.Clear();
                ReadAudioForm3.backButton.Enabled = true;
                ReadAudioForm3.submitButton.Enabled = true;
                ReadAudioForm3.ActiveForm.Size = new System.Drawing.Size(322, 400);

                //The recorded voice of the student
                String recordWAV_file = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\RecordWAV\" + lvlStr + ".wav";
                //The reference sample of the teacher
                String refWAV_file = "Class" + LoginForm.classSec + "_kidAudio/" + lvlStr.ToLower() + ".wav";

                java.io.File f1 = new java.io.File(recordWAV_file);
                java.io.File f2 = new java.io.File(refWAV_file);

                //compare
                if (!f1.exists() || !f2.exists())
                {
                    MessageBox.Show("WARNING: One of the files might be missing!");
                }
                else
                {
                    CallCompareAudio(recordWAV_file, refWAV_file);
                }


                //MessageBox.Show("DONE");
                time = 10;
            }
        }

        private void CallCompareAudio(String recordWAV_file, String refWAV_file)
        {
            float compute_Result = compareAudio(recordWAV_file, refWAV_file);
            if (compute_Result > 0)
            {
                MessageBox.Show("Matched: " + compute_Result.ToString() + "\n You Win !");
                //If user wins, update level and display choice
                MessageBoxResult diagRes = MessageBox.Show("Do you want to proceed?\nYes to Proceed\nNo to Try Again", "important", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (diagRes == MessageBoxResult.Yes)
                {
                    read.Hide();

                    //If colorblind, change theme and go to new level
                    if (isColorBlind == true)
                    {
                        read.updateLevelProgress();
                        read.newLevel(isColorBlind);
                        read.saveLevelProgress(lvlStr);
                    }
                    //otherwise, revert old theme and go to new level
                    else
                    {
                        read.updateLevelProgress();
                        read.newLevel(isColorBlind);
                        read.saveLevelProgress(lvlStr);
                    }
                }
                //Otherwise, you can try again!!
                else if (diagRes == MessageBoxResult.No)
                {
                    read.Hide();
                    if (isColorBlind == true)
                    {
                        read.repeatLevel(isColorBlind);
                    }
                    else
                    {
                        read.repeatLevel(isColorBlind);
                    }
                }
            }
            else
            {
                MessageBox.Show("Matched: " + compute_Result.ToString() + "\n Try Again !");
            }
        }

        //Compares both audio files
        private static float compareAudio(String recordWAV, String refWAV)
        {
            InputStream fileA = new FileInputStream(recordWAV);
            InputStream fileB = new FileInputStream(refWAV);

            Wave wavFile1 = new Wave(fileA);
            Wave wavFile2 = new Wave(fileB);

            Byte[] sus = wavFile1.getFingerprint();
            Byte[] samp = wavFile2.getFingerprint();

            FingerprintSimilarityComputer fpc = new FingerprintSimilarityComputer(samp, sus);
            FingerprintSimilarity sim = fpc.getFingerprintsSimilarity();

            return (float)(sim.getScore() * 100.0f);
        }
    }
}
