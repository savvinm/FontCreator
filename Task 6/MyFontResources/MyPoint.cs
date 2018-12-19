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
        public float X;
        public float Y;
        public bool Current;
        public MyPoint(PointF p)
        {
            X = p.X;
            Y = p.Y;
            Current = false;
        }
        public MyPoint()
        {
            X = 0;
            Y = 0;
            Current = false;
        }
        public void ToOnePT(float coef)
        {
            X = X * coef;
            Y = Y * coef;
        }
        public void Draw(Graphics g, bool allix)
        {
            if (!allix)
                return;
            string s = "(" + X + ";" + Y + ")";
            //Font f = new Font("Arial", 10);
            Brush b = new SolidBrush(Color.FromArgb(60, Color.Black));
            //f.
            g.DrawString(s, new Font("Courier", 8), b, X + 4, Y - 1);
            if (Current)
                g.DrawEllipse(Pens.Red, X - 3, Y - 3, 6, 6);
            else
                g.DrawEllipse(Pens.Black, X - 3, Y - 3, 6, 6);
        }
        public void Draw(Graphics g, bool allix, float x, float y)
        {
            if (!allix)
                return;
            string s = "(" + X + ";" + Y + ")";
            //Font f = new Font("Arial", 10);
            Brush b = new SolidBrush(Color.FromArgb(60, Color.Black));
            //f.
            g.DrawString(s, new Font("Courier", 8), b, X + 4, Y - 1);
            if (Current)
                g.DrawEllipse(Pens.Red, x + X - 3, y + Y - 3, 6, 6);
            else
                g.DrawEllipse(Pens.Black, x + X - 3, y + Y - 3, 6, 6);
        }
    }
}

