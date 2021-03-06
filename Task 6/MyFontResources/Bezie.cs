﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Bezie: ILine
    {
        MyPoint P1;
        MyPoint P2;
        MyPoint P3;
        MyPoint P4;
        public Bezie(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }
        public void PointByIndex(int n, MyPoint p)
        {
            if (n == 0)
                P1 = p;
            if (n == 1)
                P2 = p;
            if (n == 2)
                P3 = p;
            if (n == 3)
                P4 = p;
        }
        public bool TypeEqualTo(ILine l)
        {
            return (l.GetSecondPoints().Count == 2);
        }
        public bool EqualTo(ILine l)
        {
            if (l.GetSecondPoints().Count != 2)
                return false;
            List<MyPoint> p = l.GetPoints();
            if (p.Count != 4)
                return false;
            if (p[0].X == P1.X && p[0].Y == P1.Y && l.GetSecondPoints()[0].X == P2.X && l.GetSecondPoints()[0].Y == P2.Y
                && l.GetSecondPoints()[1].X == P3.X && l.GetSecondPoints()[1].Y == P3.Y && p[2].X == P4.X && p[2].Y == P4.Y)
                return true;
            return false;
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y, ScreenConverter sc)
        {
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                result[i] = B(t, pt, x, y, sc);
                t += dt;
            }
            if (allix)
            {
                g.DrawLine(Pens.Silver, sc.II(P1.X) * pt + x, sc.JJ(P1.Y) * pt + y, sc.II(P2.X) * pt + x, sc.JJ(P2.Y) * pt + y);
                g.DrawLine(Pens.Silver, sc.II(P3.X) * pt + x, sc.JJ(P3.Y) * pt + y, sc.II(P4.X) * pt + x, sc.JJ(P4.Y) * pt + y);
            }
                g.DrawLines(Pens.Black, result);
        }
        public List<MyPoint> GetPoints()
        {
            List<MyPoint> points = new List<MyPoint>();
            points.Add(P1);
            points.Add(P4);
            return points;
        }
        public List<MyPoint> GetSecondPoints()
        {
            List<MyPoint> points = new List<MyPoint>();
            points.Add(P2);
            points.Add(P3);
            return points;
        }
        private PointF B(float t, ScreenConverter sc)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            double x = c0 * sc.II(P1.X) + c1 * sc.II(P2.X) + c2 * sc.II(P3.X) + c3 * sc.II(P4.X);
            double y = c0 * sc.JJ(P1.Y) + c1 * sc.JJ(P2.Y) + c2 * sc.JJ(P3.Y) + c3 * sc.JJ(P4.Y);
            return new PointF((float)x, (float)y);
        }
        private PointF B(float t, int pt, float x, float y, ScreenConverter sc)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            double X = c0 * (sc.II(P1.X) * pt + x) + c1 * (sc.II(P2.X) * pt + x) + c2 * (sc.II(P3.X) * pt + x) + c3 * (sc.II(P4.X) * pt + x);
            double Y = c0 * (sc.JJ(P1.Y) * pt + y) + c1 * (sc.JJ(P2.Y) * pt + y) + c2 * (sc.JJ(P3.Y) * pt + y) + c3 * (sc.JJ(P4.Y) * pt + y);
            return new PointF((float)X, (float)Y);
        }
        private PointF B(float t, int pt, float x, float y)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            double X = c0 * (P1.X * pt + x) + c1 * (P2.X * pt + x) + c2 * (P3.X * pt + x) + c3 * (P4.X * pt + x);
            double Y = c0 * (-P1.Y * pt + y) + c1 * (-P2.Y * pt + y) + c2 * (-P3.Y * pt + y) + c3 * (-P4.Y * pt + y);
            return new PointF((float)X, (float)Y);
        }
        public void Draw(Graphics g, bool current, Color color, bool allix, bool coord, ScreenConverter sc)
        {
            Pen p = new Pen(color);
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                result[i] = B(t, sc);
                t += dt;
            }
            if (allix && current)
            {
                g.DrawLine(Pens.Silver, sc.II(P1.X), sc.JJ(P1.Y), sc.II(P2.X), sc.JJ(P2.Y));
                g.DrawLine(Pens.Silver, sc.II(P3.X), sc.JJ(P3.Y), sc.II(P4.X), sc.JJ(P4.Y));
                P2.Draw(g, current, allix, coord, sc);
                P3.Draw(g, current, allix, coord, sc);
            }
            if (current)
            {
                p.Color = Color.Black;
                g.DrawLines(p, result);
            }
            else
            {
                p.Color = Color.FromArgb(220, Color.DarkSlateGray);
                g.DrawLines(p, result);
            }
            
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y)
        {
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                result[i] = B(t, pt, x, y);
                t += dt;

            }
            if (allix)
            {
                g.DrawLine(Pens.Silver, (float)(P1.X * pt + x), (float)(P1.Y * pt + y), (float)(P2.X * pt + x), (float)(P2.Y * pt + y));
                g.DrawLine(Pens.Silver, (float)(P3.X * pt + x), (float)(P3.Y * pt + y), (float)(P4.X * pt + x), (float)(P4.Y * pt + y));
            }
                g.DrawLines(Pens.Black, result);

        }
        public override string ToString()
        {
            return P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + "," + P3.X.ToString() + "," + P3.Y.ToString() + "," + P4.X.ToString() + "," + P4.Y.ToString() + " ";
        }
    }
}
