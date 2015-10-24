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
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;

//Views the current progress for each module/function/game in the application
namespace MetroFrameworkDLLExample
{
    public partial class ViewProgress : MetroForm
    {
        static String database = "class" + LoginForm.classSec + "_db";
        String connStr = "Server=localhost; Port=3306; Database=" + database + "; Uid=root; Pwd=admin;";
        String[] currentPhonics;
        public ViewProgress()
        {
            this.Text = MainForm2.kidName + "'s Progress Card";
            InitializeComponent();
            currentPhonics = getCurrentPhonics(connStr);
            String readProgress = constructString(retrieveLevelProgress("READ"));
            String writeProgress = constructString(retrieveLevelProgress("WRITE"));
            showProgressBars(readProgress, writeProgress);
        }

        //Shows the progress of each module, for now it's just Read and Write
        //Later, it can be used for the extra features as well
        private void showProgressBars(String readProgress, String writeProgress)
        {
            readProgressBar.Minimum = 0;
            readProgressBar.Maximum = currentPhonics.Length-1;
            writeProgressBar.Minimum = 0;
            writeProgressBar.Maximum = 26;

            readProgressBar.Value = readProgress.Length;
            writeProgressBar.Value = writeProgress.Length;
        }

        //Retrives level progress of both read and write from the .txt files
        private String[] retrieveLevelProgress(String type)
        {
            String filePath="";
            if(type == "READ")
            {
                filePath= "Class" + LoginForm.classSec + "_kidLevelDB/" + MainForm2.kidName + "-readlvlprog.txt"; 
            }
            else if(type == "WRITE")
            {
                filePath = "Class" + LoginForm.classSec + "_kidLevelDB/" + MainForm2.kidName + "-writelvlprog.txt"; 
            }
            String[] lines = File.ReadAllLines(filePath);
            return lines;
        }

        //Gets the current levels set by the teacher from the DB
        private static String[] getCurrentPhonics(String connStr)
        {
            String levels = "";

            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                String cmdString = "SELECT Levels from levelmngr where isSet='Y' ;";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                MySqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    levels += reader.GetString(0);
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
            String[] levelArr = levels.Split(';');
            return levelArr;
        }

        //Constructs a string 
        private String constructString(String[] arr)
        {
            arr = removeDuplicates(arr);
            String str = "";
            foreach(String s in arr)
            {
                str += s;
            }
            return str;
        }

        //Eliminating duplicates(if it contains in the file)
        private String[] removeDuplicates(String[] arr)
        {
            List<String> list = arr.ToList();
            list = list.Distinct().ToList();
            return list.ToArray();
        }

    }
}
