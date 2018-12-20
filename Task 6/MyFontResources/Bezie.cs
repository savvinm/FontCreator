using System;
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
        bool Current;
        public Bezie(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            Current = false;
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
        public List<MyPoint> GetPoints()
        {
            List<MyPoint> points = new List<MyPoint>();
            points.Add(P1);
            points.Add(P2);
            points.Add(P3);
            points.Add(P4);
            return points;
        }
        private PointF B(float t)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            float x = c0 * P1.X + c1 * P2.X + c2 * P3.X + c3 * P4.X;
            float y = c0 * P1.Y + c1 * P2.Y + c2 * P3.Y + c3 * P4.Y;
            return new PointF(x, y);
        }
        private PointF B(float t, float x, float y)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            float X = c0 * (P1.X + x) + c1 * (P2.X + x) + c2 * (P3.X + x) + c3 * (P4.X + x);
            float Y = c0 * (P1.Y + y) + c1 * (P2.Y + y) + c2 * (P3.Y + y) + c3 * (P4.Y + y);
            return new PointF(X, Y);
        }
        public void ToOnePT(float coef)
        {
            P2.X = P2.X *coef;
            P2.Y = P2.Y * coef;

            P1.X = P1.X * coef;
            P1.Y = P1.Y * coef;

            P3.X = P3.X * coef;
            P3.Y = P3.Y * coef;

            P4.X = P4.X * coef;
            P4.Y = P4.Y * coef;
        }
        public bool Check()
        {
            return (P2 == null || P1 == null || P3 == null || P4 == null);
        }
        public void Draw(Graphics g, bool allix)
        {
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                //x = (1 - t) * (1 - t) * (1 - 3) * P1.X + 3 * (1 - t) * (1 - t) * t * P2.X + 3 * (1 - t) * t * t * P3.X + t * t * t * P4.X;
                //y = (1 - t) * (1 - t) * (1 - 3) * P1.Y + 3 * (1 - t) * (1 - t) * t * P2.Y + 3 * (1 - t) * t * t * P3.Y + t * t * t * P4.Y;
                //result[(int)(t * 100)] = new PointF(x, y);
                result[i] = B(t);
                t += dt;

            }
            if (allix)
            {
                g.DrawLine(Pens.Silver, P1.X, P1.Y, P2.X, P2.Y);
                g.DrawLine(Pens.Silver, P3.X, P3.Y, P4.X, P4.Y);
            }
            if (Current)
                g.DrawLines(Pens.Red, result);
            else
                g.DrawLines(Pens.Black, result);
            
        }
        public void Draw(Graphics g, bool allix, float x, float y)
        {
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                //x = (1 - t) * (1 - t) * (1 - 3) * P1.X + 3 * (1 - t) * (1 - t) * t * P2.X + 3 * (1 - t) * t * t * P3.X + t * t * t * P4.X;
                //y = (1 - t) * (1 - t) * (1 - 3) * P1.Y + 3 * (1 - t) * (1 - t) * t * P2.Y + 3 * (1 - t) * t * t * P3.Y + t * t * t * P4.Y;
                //result[(int)(t * 100)] = new PointF(x, y);
                result[i] = B(t, x, y);
                t += dt;

            }
            if (allix)
            {
                g.DrawLine(Pens.Silver, P1.X + x, P1.Y + y, P2.X + x, P2.Y + y);
                g.DrawLine(Pens.Silver, P3.X + x, P3.Y + y, P4.X + x, P4.Y + y);
            }
            if (Current)
                g.DrawLines(Pens.Red, result);
            else
                g.DrawLines(Pens.Black, result);

        }
        public override string ToString()
        {
            return P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + "," + P3.X.ToString() + "," + P3.Y.ToString() + "," + P4.X.ToString() + "," + P4.Y.ToString() + " ";
        }
    }
}
