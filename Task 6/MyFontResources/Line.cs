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
        public void PointByIndex(int n, MyPoint p)
        {
            if (n == 0)
                P1 = p;
            if (n == 1)
                P2 = p;
        }
        public List<MyPoint> GetPoints()
        {
            List<MyPoint> points = new List<MyPoint>();
            points.Add(P1);
            points.Add(P2);
            return points;
        }
        public List<MyPoint> GetSecondPoints()
        {
            return new List<MyPoint>();
        }
        public bool EqualTo(ILine l)
        {
            List<MyPoint> p = l.GetPoints();
            if (p.Count != 2 || p[0] == null || p[1] == null)
                return false;
            if (p[0].X == P1.X && p[0].Y == P1.Y && p[1].X == P2.X && p[1].Y == P2.Y)
                return true;
            return false;
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y, ScreenConverter sc)
        {
            if (Current)
                g.DrawLine(Pens.Red, sc.II(P1.X) * pt + x, sc.JJ(P1.Y) * pt + y, sc.II(P2.X) *pt + x, sc.JJ(P2.Y) * pt + y);
            else
                g.DrawLine(Pens.Black, sc.II(P1.X) * pt + x, sc.JJ(P1.Y) * pt + y, sc.II(P2.X) * pt + x, sc.JJ(P2.Y) * pt + y);
        }
        public void Draw(Graphics g, bool current, Color color, bool allix, bool coord, ScreenConverter sc)
        {
            Pen p = new Pen(color);
            if (current)
            {
                p.Color = Color.Black;
                g.DrawLine(p, sc.II(P1.X), sc.JJ(P1.Y), sc.II(P2.X), sc.JJ(P2.Y));
            }
            else
            {
                p.Color = Color.FromArgb(220, Color.DarkSlateGray);
                g.DrawLine(p, sc.II(P1.X), sc.JJ(P1.Y), sc.II(P2.X), sc.JJ(P2.Y));
            }
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y)
        {
            if (Current)
                g.DrawLine(Pens.Red, (float)(P1.X * pt + x), (float)(P1.Y * pt + y), (float)(P2.X * pt + x), (float)(P2.Y * pt + y));
            else
                g.DrawLine(Pens.Black, (float)(P1.X * pt + x), (float)(-P1.Y * pt + y), (float)(P2.X * pt + x), (float)(-P2.Y * pt + y));
        }
        public override string ToString()
        {
            return  P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + " "; 
        }
    }
}
