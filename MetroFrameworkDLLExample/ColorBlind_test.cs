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
    public partial class ColorBlind_test : MetroForm
    {
        public ColorBlind_test()
        {
            InitializeComponent();
        }

        //Changes color of the form and the style
        private void changeBtn_Click(object sender, EventArgs e)
        {
            this.StyleManager = this.metroStyleManager;
            metroStyleManager.Style = MetroColorStyle.White;
            metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            //testBtn.UseCustomBackColor = true;
            //testBtn.BackColor = Color.Crimson;
        }
    }
}
