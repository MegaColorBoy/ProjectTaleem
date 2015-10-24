using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroFrameworkDLLExample
{
    public partial class greyScaleTest : Form
    {
        public greyScaleTest()
        {
            InitializeComponent();
            toolStrip1.AutoSize = false; toolStrip1.Height = 50;
            toolStripDropDownButton1.AutoSize = false; toolStripDropDownButton1.Width = 50;

            //resize the image of the button to the new size
            int sourceWidth = toolStripDropDownButton1.Image.Width;
            int sourceHeight = toolStripDropDownButton1.Image.Height;
            Bitmap b = new Bitmap(40, 40);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(toolStripDropDownButton1.Image, 0, 0, 40, 40);
            g.Dispose();
            Image myResizedImg = (Image)b;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripDropDownButton1.Image = myResizedImg;
            toolStrip1.ImageScalingSize = new Size(50,50);
            grayScale(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\read2.jpg");
        }

        private void grayScale(String filename)
        {
            Bitmap bmp = new Bitmap(filename);
            for(int y = 0; y<bmp.Height; y++)
            {
                for(int x=0; x<bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    int average = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            bmp.Save(@"C:\Pres_Proto\V2\MetroFrameworkDLLExample\out.jpg");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(":D !");
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton1.BackColor = Color.Bisque;
        }
    }
}
