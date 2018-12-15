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
        public void Draw(Graphics g)
        {
            if (Current)
                g.DrawEllipse(Pens.Red, X - 2, Y - 2, 4, 4);
            else
                g.DrawEllipse(Pens.Black, X - 2, Y - 2, 4, 4);
        }
    }
}
