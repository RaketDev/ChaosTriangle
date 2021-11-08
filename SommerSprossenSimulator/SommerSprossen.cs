using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SommerSprossenSimulator
{
    //prediction. das Drei Eck wird Dunkel
    public partial class count : Form
    {
        private PointF pStart;
        private PointF pCur;

        private PointF p1;
        private PointF p2;
        private PointF p3;

        private int pointCount = 0;
        public count()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(500, 500);
            pictureBox1.Image = btm;
            numericUpDown1.Maximum = 100000;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(pictureBox1.Image);
            Random rnd = new Random();
            pStart = new PointF(rnd.Next(1, 500), rnd.Next(1, 500));
            btm.SetPixel((int)pStart.X, (int)pStart.Y, Color.Black);

            pCur = pStart;

            List<PointF> plist = new List<PointF>();
            plist.Add(p1);
            plist.Add(p2);
            plist.Add(p3);

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                int rndPoint = rnd.Next(0, 3);

                PointF pnew = ClacPoint(btm, plist[rndPoint], pCur);
                DrawPoint(btm, pnew);
                pCur = pnew;


            }
            pictureBox1.Image = btm;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Image img = pictureBox1.Image;
            Bitmap btm = new Bitmap(img);
            if (pointCount != 3)
            {
                if (pointCount == 2)
                {
                    var x3 = e.X;
                    var y3 = e.Y;
                    p3 = new Point(x3, y3);
                    DrawPoint(btm, p3);
                    pointCount++;
                    countPoints.Text = pointCount.ToString();
                }
                if (pointCount == 1)
                {
                    var x2 = e.X;
                    var y2 = e.Y;
                    p2 = new Point(x2, y2);
                    DrawPoint(btm, p2);
                    pointCount++;
                    countPoints.Text = pointCount.ToString();
                }
                if (pointCount == 0)
                {
                    var x1 = e.X;
                    var y1 = e.Y;
                    p1 = new Point(x1, y1);
                    DrawPoint(btm, p1);
                    pointCount++;
                    countPoints.Text = pointCount.ToString();
                }
            }
            pictureBox1.Image = btm;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(500, 500);
            pictureBox1.Image = bmp;
            p1 = new PointF(0, 0);
            p2 = new PointF(0, 0);
            p3 = new PointF(0, 0);
            pCur = new PointF(0, 0);
            pStart = new PointF(0, 0);
            pointCount = 0;
            countPoints.Text = pointCount.ToString();
        }
        private void DrawPoint(Bitmap btm, PointF p)
        {
            if (p.X > btm.Width - 1) p.X = btm.Width - 1;
            if (p.Y > btm.Height - 1) p.Y = btm.Height - 1;
            btm.SetPixel((int)p.X, (int)p.Y, Color.HotPink);

        }
        private PointF ClacPoint(Bitmap btm, PointF pTo, PointF pCur)
        {
            PointF pbetween = new PointF(pTo.X, pCur.Y);
            float Xnew = ((pTo.X + pCur.X) / 2);
            float Ynew = ((pTo.Y + pCur.Y) / 2);
            return new PointF(Xnew, Ynew);
        }
    }
}
