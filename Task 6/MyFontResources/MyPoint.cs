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
        public bool First;
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
        public bool EqualTo(MyPoint p)
        {
            return (p.X == X && p.Y == Y); 
        }
        public void Draw(Graphics g, bool curCont, bool allix, bool coord, ScreenConverter sc)
        {
            Pen p = new Pen(Brushes.Black);
            if (!allix)
                return;
            if (coord)
            {
                string s = "(" + sc.II(X) + ";" + sc.JJ(Y) + ")";
                Brush b = new SolidBrush(Color.White);
                if (curCont)
                {
                    b = new SolidBrush(Color.FromArgb(60, Color.Black));
                }
                else

                    b = new SolidBrush(Color.FromArgb(60, Color.Silver));
                if (curCont)
                    g.DrawString(s, new Font("Courier", 8), b, sc.II(X) + 4, sc.JJ(Y) - 1);
            }
            if (curCont)
                p.Color = Color.Black;
            if (Current)
                p.Color = Color.Red;
            if (!curCont && !Current)
                p.Color = Color.FromArgb(180, Color.DarkSlateGray);
            if (First)
                p.Color = Color.Blue;
            g.DrawEllipse(p, sc.II(X) - 3, sc.JJ(Y) - 3, 6, 6);
        }
    }
}

