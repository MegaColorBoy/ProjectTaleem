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
using Microsoft.Ink;
using System.Threading;
using System.Windows.Ink;
using System.IO;

//Improved write function
namespace MetroFrameworkDLLExample
{
    public partial class WriteCanvas : UserControl
    {
        public static String resultStr;
        String levelStr;
        RecognizerContext context;
        public static System.Windows.Ink.DrawingAttributes inkDA;
        private WriteForm write;
        bool isColorBlind;
        ResultSplashScreen resultSplash;

        public WriteCanvas(WriteForm write, String str)
        {
            InitializeComponent();
            this.write = write;
            isColorBlind = write.isColorBlind;
            this.levelStr = str;
            inkDA = new System.Windows.Ink.DrawingAttributes();
            inkDA.Color = Colors.Black;
            inkDA.Height = 10;
            inkDA.Width = 10;
            inkDA.FitToCurve = false;
            inkCanvas.DefaultDrawingAttributes = inkDA;
        }

        //Recognizes the stroke
        private void recogClick(object sender, EventArgs e)
        {
            if (inkCanvas.Strokes.Count > 0)
            {
                StrokeCollection strokeList = inkCanvas.Strokes;
                //save the strokes
                MemoryStream ms = new MemoryStream();

                inkCanvas.Strokes.Save(ms);

                InkCollector collector = new InkCollector();
                Ink ink = new Ink();
                ink.Load(ms.ToArray());

                try
                {
                    context = new RecognizerContext();
                    RecognitionStatus status;
                    RecognitionResult result;
                    context.Strokes = ink.Strokes;
                    result = context.Recognize(out status);
                    if (result.TopString == levelStr)
                    {
                        resultStr = "WON";
                        resultSplash = new ResultSplashScreen();
                        resultSplash.Show();
                        Thread.Sleep(1000);
                        resultSplash.Close();

                        MessageBoxResult diagRes = MessageBox.Show("Do you want to proceed?\nYes to Proceed\nNo to Try Again", "important", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        //Change theme, if colorblind and progress to new level
                        if (diagRes == MessageBoxResult.Yes)
                        {
                            write.Hide();
                            //Create a method that says "solved" after each level on the button
                            //xxxxxxxx

                            if (isColorBlind == true)
                            {
                                write.updateLevelProgress();
                                write.newLevel(isColorBlind);
                                write.saveLevelProgress(levelStr);
                            }
                            else
                            {
                                write.updateLevelProgress();
                                write.newLevel(isColorBlind);
                                write.saveLevelProgress(levelStr);
                            }
                        }
                        //Otherwise, repeat the level
                        else if (diagRes == MessageBoxResult.No)
                        {
                            if (isColorBlind == true)
                            {
                                write.repeatLevel(isColorBlind);
                            }
                            else
                            {
                                write.repeatLevel(isColorBlind);
                            }
                        }
                    }
                    else
                    {
                        resultStr = "LOSE";
                        resultSplash = new ResultSplashScreen();
                        resultSplash.Show();
                        Thread.Sleep(1000);
                        resultSplash.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //Clear strokes after every try
                inkCanvas.Strokes.Clear();
            }
            else
            {
                MessageBox.Show("Nothing");
            }
        }

    }
}
