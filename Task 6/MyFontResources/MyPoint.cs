using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public class MyPoint
    {
        public double X;
        public double Y;
        public bool Current;
        public MyPoint(PointF p)
        {
            X = p.X;
            Y = p.Y;
            Current = false;
        }
        public MyPoint(double x, double y)
        {
            X = x;
            Y = y;
            Current = false;
        }
        public MyPoint()
        {
            X = 0;
            Y = 0;
            Current = false;
        }
        public void Draw(Graphics g, bool allix, bool coord, ScreenConverter sc)
        {
            if (!allix)
                return;
            if (coord)
            {
                string s = "(" + sc.II(X) + ";" + sc.JJ(Y) + ")";
                Brush b = new SolidBrush(Color.FromArgb(60, Color.Black));
                g.DrawString(s, new Font("Courier", 8), b, sc.II(X) + 4, sc.JJ(Y) - 1);
            }
            if (Current)
                g.DrawEllipse(Pens.Red, sc.II(X) - 3, sc.JJ(Y) - 3, 6, 6);
            else
                g.DrawEllipse(Pens.Black, sc.II(X) - 3, sc.JJ(Y) - 3, 6, 6);
        }
        /*public void Draw(Graphics g, bool allix, int pt, float x, float y)
        {
            if (!allix)
                return;
            string s = "(" + X + ";" + Y + ")";
            //Font f = new Font("Arial", 10);
            Brush b = new SolidBrush(Color.FromArgb(60, Color.Black));
            //f.
            g.DrawString(s, new Font("Courier", 8), b, (float)(X * pt + 4), (float)(Y * pt - 1));
            if (Current)
                g.DrawEllipse(Pens.Red, x + 3 - 3, y + Y - 3, 6, 6);
            else
                g.DrawEllipse(Pens.Black, sc.II(x + X) - 3, sc.JJ(y + Y) - 3, 6, 6);
        }*/
    }
}

