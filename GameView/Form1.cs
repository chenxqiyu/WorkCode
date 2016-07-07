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
using Delegate;

using System.Runtime.InteropServices;
using System.Diagnostics;
namespace GameView
{
    public partial class Form1 : Form
    {
        Graphics g;
        Image MainImage = null;
        public Thread UiTrhead;
        List<Bitmap> bitmaps = new List<Bitmap>();
        Bitmap newbg = null;
        List<Image> images = new List<Image>();



        public Form1()
        {
            InitializeComponent();
        }
        private int height = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Father f = new Father();
            Son ss = new Son();
            Son s = new Son();
            f.inf = s;
            f.x=6;
            f.s = s;
            string test = f.Home;
            test = s.Home;

            f.OK();
            
            Width = 500;
            Height = 500;

            //   this.WindowState = FormWindowState.Maximized;
            g = this.CreateGraphics();

            Image bg = Image.FromFile(@"F:\迅雷下载\2016062803434215da97_com.fighter.activity\assets\gfx\main\back.png");

            //   Bitmap v = new Bitmap(my, new Size(my.Width / 4, my.Height));
            //GraphicsUnit.Display
            //g.DrawImage()


            //     Bitmap 
            MainImage = new Bitmap(Width, Height, g);
            bitmaps.Add((Bitmap)bg);
            //       bitmaps.Add(getBitmap(bg));
            // bitmaps.Add(new Bitmap(my));
            //v = new Bitmap(my, new Size((my.Width / 4) * 1, my.Height));
            //bitmaps.Add(v);
            //v = new Bitmap(my, new Size((my.Width / 4) * 2, my.Height));
            //bitmaps.Add(v);
            //v = new Bitmap(my, new Size((my.Width / 4) * 3, my.Height));
            //bitmaps.Add(v);



            //(my, 0, 0, my.getWidth() / 4,
            //    my.getHeight())
            //bitmaps.add(Bitmap.createBitmap(my, (my.getWidth() / 4) * 1, 0,
            //        my.getWidth() / 4, my.getHeight()));
            //bitmaps.add(Bitmap.createBitmap(my, (my.getWidth() / 4) * 2, 0,
            //        my.getWidth() / 4, my.getHeight()));
            //bitmaps.add(Bitmap.createBitmap(my, (my.getWidth() / 4) * 3, 0,
            //        my.getWidth() / 4, my.getHeight()));


            //for (int i = 1; i <= 4; i++)
            //{


            //}
            UiTrhead = new Thread(new ThreadStart(Run));
            UiTrhead.Start();
        }


        public Bitmap getBitmap(Image bg)
        {

            try
            {
                int display_w = 500;
                int display_h = 500;
                newbg = new Bitmap(display_w, display_w, g);



                Graphics sg = Graphics.FromImage(newbg);
                sg.DrawImage(bg, new RectangleF(0, 0, bg.Width, bg.Height),
                new RectangleF(0, height, display_w, display_h + height), GraphicsUnit.Display);

                sg.DrawImage(bg, new RectangleF(0, 0, bg.Width, bg.Height),
                        new RectangleF(0, -display_h + height, display_w, height), GraphicsUnit.Display);


                height++;
                if (height == display_h)
                {
                    height = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return newbg;
        }
        public void Run()
        {
            try
            {
                while (true)
                {
                    Pen p = new Pen(Color.Blue, 2);
                    Point pt = new Point(0, 0);

                    //  Point pt2 = new Point(100, 100);
                    Random r = new Random();

                    Graphics gg = Graphics.FromImage(MainImage);


                    p.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));


                    gg.DrawLine(p, r.Next(1000), r.Next(1000), r.Next(1000), r.Next(1000));

                    // random.nextInt(1000), random.nextInt(1000), p);

                    //foreach (Bitmap item in bitmaps)
                    //{
                    //    gg.DrawImage(item, pt);
                    //}

                    g.DrawImage(MainImage, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

                    Thread.Sleep(50);
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    g = e.Graphics; //创建画板,

        //}
    }
}
