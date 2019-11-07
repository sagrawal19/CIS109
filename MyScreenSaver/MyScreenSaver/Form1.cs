using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenSaver
{
    public partial class FromScSaver : Form
    {
        List<Image> BGImages = new List<Image>(); // variable holding Array of pictures
        List<BritPic> BritPics = new List<BritPic>(); // Array of Britpic objects
        Random rand = new Random(); //Random object to generate random numbers


        class BritPic
        {
            public int PicNum;
            public float x;
            public float y;
            public float speed;
        }
        public FromScSaver()
        {
            InitializeComponent();
        }

        private void FromScSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void FromScSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");// put all the file names in pics dir into the images variable, pick all the images from pics and dump it in images variable

            foreach (string image in images)// looking for each text image in images
            {
                BGImages.Add(new Bitmap(image));
            }
            for (int i = 0; i < 50; ++i)
            {
                BritPic mp = new BritPic();
                mp.PicNum = i % BGImages.Count;
                mp.x = rand.Next(0, Width);
                mp.y = rand.Next(0, Height);

          
                BritPics.Add(mp);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void FromScSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach(BritPic bp in BritPics)
            {
                e.Graphics.DrawImage(BGImages[bp.PicNum], bp.x, bp.y); //positioning on x and y axis
                bp.x -= 2;

                if(bp.x < -250)  // if moving left -> move it back to right
                {
                    bp.x = Width + rand.Next(20, 100);
                }
            }
        }
    }
}
