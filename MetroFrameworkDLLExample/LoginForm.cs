using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace MetroFrameworkDLLExample
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        Button[] buttons;
        public static String classSec = "1A";
        public static String database = "class" + classSec + "_db";
        private static String connStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
        private static int size = 4;
        private static List<String> list = new List<String>();
        private static String dir = "Class" + classSec + "_kidLoginImages";
        VoiceAssistant vAssist;

        public LoginForm()
        {
            //Thread t = new Thread(new ThreadStart(SplashLoadScreen));
            //t.Start();
            //Thread.Sleep(5000);
            //t.Abort();
            InitializeComponent();

            buttonPanel.Visible = false;
            loginPicBox.ImageLocation = @"C:\Pres_Proto\V2\MetroFrameworkDLLExample\logo2.png";
            this.loginPicBox.SizeMode = PictureBoxSizeMode.Zoom;

            retriveLoginImgFrmDB(connStr);
            ImageList imageList = kidImgList;
            imageList = getImages(dir);
            generateLoginButtons(size, imageList);
            //AddKidLoginButtons(size, imageList);
            this.BackColor = Color.FromArgb(255, 78, 32);
            vAssist = new VoiceAssistant();
            vAssist.SpeakMessage("Hey there, Which one is you ?");
        }

        //public static void SplashLoadScreen()
        //{
        //    Application.Run(new AppSplashScreen());
        //}

        private static void retriveLoginImgFrmDB(String connStr)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlDataReader reader;
            String cmdString = "SELECT FirstName, LastName, Image FROM studentinfo";
            MySqlCommand cmd = new MySqlCommand(cmdString, connection);
            FileStream fs;
            String firstName, lastName;
            BinaryWriter bw;
            int bufferSize = 1024;
            byte[] ImageData = new byte[bufferSize];
            long nBytesReturned, startIndex = 0;

            connection.Open();
            reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            if (!Directory.Exists("Class" + classSec + "_kidLoginImages"))
            {
                Directory.CreateDirectory("Class" + classSec + "_kidLoginImages");
            }

            while (reader.Read())
            {
                firstName = reader.GetString(0);
                lastName = reader.GetString(1);
                fs = new FileStream("Class" + classSec + "_kidLoginImages/" + firstName.ToString() + " " + lastName.ToString() + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                bw = new BinaryWriter(fs);
                startIndex = 0;
                nBytesReturned = reader.GetBytes(
                2,
                startIndex,
                ImageData,
                0,
                bufferSize
                );

                while (nBytesReturned == bufferSize)
                {
                    bw.Write(ImageData);
                    bw.Flush();
                    startIndex += bufferSize;
                    nBytesReturned = reader.GetBytes(2, startIndex, ImageData, 0, bufferSize);
                }

                bw.Write(ImageData, 0, (int)nBytesReturned - 1);
                bw.Close();
                fs.Close();
            }
            reader.Close();
            connection.Close();
        }

        private static ImageList getImages(String directory)
        {
            ImageList images = new ImageList();
            images.ImageSize = new Size(137, 130);
            foreach (String file in System.IO.Directory.GetFiles(directory))
            {
                try
                {
                    //Store the filenames
                    list.Add(file);
                    Image img = Image.FromFile(file);
                    images.Images.Add(img);
                }
                catch
                {
                    //You can fill whatever you want 
                }
            }
            return images;
        }

        //Newer function to generate login buttons
        private void generateLoginButtons(int numBtn, ImageList imgList)
        {
            String[] fileArr = list.ToArray();
            buttons = new Button[numBtn];
   
            for(int i=0; i<numBtn; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = splitDir(fileArr[i]);
                buttons[i].Size = new Size(100, 100);
                buttons[i].ImageList = imgList;
                buttons[i].ImageIndex = i;
                flowLayoutPanel1.Controls.Add(buttons[i]);
                buttons[i].Click += new System.EventHandler(clickButton);
            }
        }

        private void AddKidLoginButtons(int numBtn, ImageList imgList)
        {
            String[] fileArr = list.ToArray();

            int posX = 50;
            int posY = 180;
            int counter = 0;
            System.Windows.Forms.Button[] btnArr = new System.Windows.Forms.Button[numBtn];

            for (int i = 0; i < numBtn; i++)
            {
                btnArr[i] = new System.Windows.Forms.Button();
            }

            while (counter < numBtn)
            {
                btnArr[counter].Tag = counter + 1;
                btnArr[counter].Height = 80;
                btnArr[counter].Width = 80;

                if (counter % 6 == 0)
                {
                    posX = 50;
                    posY += 80;
                }

                btnArr[counter].Left = posX;
                btnArr[counter].Top = posY;
                this.Controls.Add(btnArr[counter]);
                posX = posX + btnArr[counter].Width + 10;
                //*******************************************************
                btnArr[counter].ImageList = imgList;
                btnArr[counter].ImageIndex = counter;
                btnArr[counter].Name = splitDir(fileArr[counter]);
                //btnArr[counter].Text = splitDir(fileArr[counter]);
                btnArr[counter].Click += new System.EventHandler(clickButton);
                //*******************************************************
                counter++;
            }
        }

        private static String splitDir(String str)
        {
            String[] strSplit = str.Split('\\');
            String[] splitJPG = strSplit[strSplit.Length - 1].Split('.');
            return splitJPG[0];
        }

        public void clickButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            kidPicBox.ImageLocation = "Class" + classSec + "_kidLoginImages/" + btn.Name + ".jpg";
            this.kidPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            kidNameLabel.Text = btn.Name;
        }

        private void kidPicBox_Click(object sender, EventArgs e)
        {
            String filename = "Class" + classSec + @"_kidLoginImages\" + kidNameLabel.Text.ToString() + ".jpg";
            if (checkIsBlind(filename) == true)
            {
                BlindModeForm blindMode = new BlindModeForm();
                blindMode.Show();
            }
            else
            {
                this.Hide();
                MainForm2 main = new MainForm2("Class" + classSec + "_kidLoginImages/" + kidNameLabel.Text.ToString() + ".jpg");
                main.ShowDialog();
            }
        }


        //If the student is blind
        private static bool checkIsBlind(String fileName)
        {
            String isBlind = "";
            String[]names = splitDir(fileName).Split(' ');
            String fname = names[0], lname = names[1];

            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                //MessageBox.Show(fname + " " + lname);
                String cmdString = "SELECT isBlind from studentinfo where FirstName='" + fname + "' and LastName='" + lname + "' ;";
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
                    isBlind = reader.GetString(0);
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

            if (isBlind == "Y")
            {
                return true;
            }
            return false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
