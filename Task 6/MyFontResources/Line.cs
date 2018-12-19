using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Line: ILine
    {
        MyPoint P1;
        MyPoint P2;
        bool Current;
        public Line(MyPoint p1, MyPoint p2)
        {
            P1 = p1;
            P2 = p2;
            Current = false;
        }
        public bool Check()
        {
            return (P1 == null || P2 == null);
        }
        public void ToOnePT(float coef)
        {
            P1.X = P1.X * coef;
            P1.Y = P1.Y * coef;
            P2.X = P2.X * coef;
            P2.Y = P2.Y * coef;
        }
        public void Draw(Graphics g, bool allix)
        {
            if (Current)
                g.DrawLine(Pens.Red, P1.X, P1.Y, P2.X, P2.Y);
            else
                g.DrawLine(Pens.Black, P1.X, P1.Y, P2.X, P2.Y);
        }
        public void Draw(Graphics g, bool allix, float x, float y)
        {
            if (Current)
                g.DrawLine(Pens.Red, P1.X + x, P1.Y + y, P2.X + x, P2.Y + y);
            else
                g.DrawLine(Pens.Black, P1.X + x, P1.Y + y, P2.X + x, P2.Y + y);
        }
        public override string ToString()
        {
            return  P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + " "; 
        }
    }
}
