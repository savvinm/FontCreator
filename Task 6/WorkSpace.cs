using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public class WorkSpace
    {
        int Height { get; set; }
        int Width { get; set; }
        List<Contour> contours;
        char symbol;
        public List<ILine> lines;
        public List<MyPoint> currpoints;
        MyPoint lastPoint;
        public List<MyPoint> myPoints;
        public WorkSpace(int w, int h, char c)
        {
            Height = h;
            Width = w;
            lines = new List<ILine>();
            contours = new List<Contour>();
            currpoints = new List<MyPoint>();
            myPoints = new List<MyPoint>();
            symbol = c;
        }
        public void ChooseContour(int n)
        {
            if (n < contours.Count)
            {
                lines = contours[n].lines;
            }
        }
        public void AddPoint(PointF p)
        {
            //points.Add(p);
        }
        public void UpdatePoint(PointF p, float dx, float dy)
        {
            /*int n = SearchMyPoint(p);
            if (n != -1)
            {
                myPoints[n].X += dx;
                myPoints[n].Y += dy;
            }*/
            lastPoint.X += dx;
            lastPoint.Y += dy;
            lastPoint.Current = false;
            currpoints.Clear();
        }
        public void PointIn(PointF p)
        {
            /*lastPoint = p;
            int n = SearchPoint(p);
            int m = SearchCurrPoint(p);
            if (n != -1)
            {
                currpoints.Add(points[n]);
                points.RemoveAt(n);
                return;
            }
            if (m != -1)
            {
                points.Add(currpoints[m]);
                currpoints.RemoveAt(m);
                return;
            }
            else
                points.Add(p);*/
            int n = SearchMyPoint(p);
            if (n != -1)
            {
                lastPoint = myPoints[n];
                if (myPoints[n].Current)
                {
                    myPoints[n].Current = false;
                    currpoints.Remove(myPoints[n]);
                }
                else
                {
                    myPoints[n].Current = true;
                    currpoints.Add(myPoints[n]);
                }
                return;
            }
            else
            {
                myPoints.Add(new MyPoint(p));
                lastPoint = myPoints.Last();
            }
            
        }
        public void DeletePoints()
        {
            currpoints.Clear();
            for (int i = 0; i < myPoints.Count; i++)
            {
                if (myPoints[i].Current)
                    myPoints.RemoveAt(i);
            }
            foreach(ILine l in lines)
            {
                if (l.Check())
                {
                    lines.Remove(l);
                }
            }
        }
        public void AddILine(MyPoint p1, MyPoint p2)
        {
            lines.Add(new Line(p1, p2));
        }
        /*public int SearchCurrPoint(PointF p)
        {
            for(int i = 0; i < currpoints.Count; i++)
            {
                PointF P = currpoints[i];
                if (p.X <= P.X + 3 && p.X >= P.X - 3 && p.Y >= P.Y - 3 && p.Y <= P.Y + 3)
                    return i;
            }
            return -1;
        }*/
        public int SearchMyPoint(PointF p)
        {
            for (int i = 0; i < myPoints.Count; i++)
            {
                MyPoint P = myPoints[i];
                if (p.X <= P.X + 3 && p.X >= P.X - 3 && p.Y >= P.Y - 3 && p.Y <= P.Y + 3)
                    return i;
            }
            return -1;
        }
        /*public int SearchPoint(PointF p)
        {
            for (int i = 0; i < points.Count; i++)
            {
                PointF P = points[i];
                if (p.X <= P.X + 3 && p.X >= P.X - 3 && p.Y >= P.Y - 3 && p.Y <= P.Y + 3)
                    return i;
            }
            return -1;
        }*/
        public void AddILine(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4)
        {
            lines.Add(new Bezie(p1, p2, p3, p4));
        }
        public void AddILine()
        {
            /*foreach(MyPoint p in myPoints)
            {
                if (p.Current)
                {
                    currpoints.Add(p);
                    p.Current = false;
                }
            }*/
            if (currpoints.Count == 2)
            {
                AddILine(currpoints[0], currpoints[1]);
            }
            if (currpoints.Count == 4)
            {
                AddILine(currpoints[0], currpoints[1], currpoints[2], currpoints[3]);
            }
            foreach (MyPoint p in myPoints)
                p.Current = false;
            /*foreach (MyPoint p in currpoints)
                points.Add(p);*/
            currpoints.Clear();
        }
        public void DrawContour(Graphics g, Contour c)
        {
            c.Draw(g, true);
        }
        public void DrawContours(Graphics g, List<Contour> c)
        {
            foreach (Contour co in c)
                co.Draw(g, true);
        }
        public void DrawAll(Graphics g)
        {
            /*foreach (PointF p in points)
                g.DrawEllipse(Pens.Black, p.X - 2, p.Y -2, 4, 4);
            foreach (PointF p in currpoints)
            g.DrawEllipse(Pens.Red, p.X - 2, p.Y -2 , 4, 4);*/
            foreach (MyPoint p in myPoints)
                p.Draw(g);
            foreach (ILine l in lines)
                l.Draw(g, true);
            foreach (Contour c in contours)
                c.Draw(g, true);
        }
    }
}
