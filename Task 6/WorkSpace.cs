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
        public MyFont font;
        Symbol curSymbol;
        Contour curContour;
        List<ILine> lines;
        List<MyPoint> currpoints;
        MyPoint lastPoint;
        List<MyPoint> myPoints;
        bool allix;
        bool AllSymbol;
        public WorkSpace(int w, int h)
        {
            Height = h;
            Width = w;
            currpoints = new List<MyPoint>();
            myPoints = new List<MyPoint>();
            font = new MyFont();
            allix = true;
            AllSymbol = false;
        }
        public void SaveFont(string filename)
        {
            font.Save(filename);
        }
        public void LoadFont(string filename)
        {
            font = font.Load(filename);
            curContour = null;
            currpoints.Clear();
            curSymbol = null;
            myPoints = null;
        }
        public List<object> SymbolList()
        {
            List<object> list = new List<object>();
            foreach(Symbol s in font.symbols)
            {
                list.Add("Symbol " + s.symbol);
            }
            return list;
        }
        public List<object> ContourList(int n)
        {
            Symbol s = font.symbols[n];
            int m = 1;
            List<object> list = new List<object>();
            foreach(Contour c in s.contours)
            {
                list.Add("Contour " + m);
                m++;
            }
            return list;
        }
        public void DrawLines(Graphics g)
        {
            Pen p = new Pen(Color.Silver);
            p.Color = Color.FromArgb(50, Color.Black);
            float dx = Width / 25;
            float dy = Height / 25;
            for (int i = 0; i <= 25; i++)
            {
                g.DrawLine(p, dx * i, 0, dx * i, Height);
                g.DrawLine(p, 0, dy * i, Width, dy * i);
            }
        }
        public void ChooseSymbol(int n)
        {
            if (n == -1)
            {
                curSymbol = null;
                return;
            }
            if (n < font.symbols.Count)
            {
                curSymbol = font.symbols[n];
            }
        }
        public void ChooseContour(int n)
        {
            if (n == -1)
            {
                curContour = null;
                return;
            }
            if (n < curSymbol.contours.Count)
            {
                lines = curSymbol.contours[n].lines;
                curContour = curSymbol.contours[n];
                myPoints = curContour.myPoints;
            }
        }
        public void AddSymbol(char s)
        {
            font.symbols.Add(new Symbol(s));
        }
        public void AddContour()
        {
            curSymbol.contours.Add(new Contour());
        }
        public void CheckAllix(bool all)
        {
            allix = all;
        }
        public void CheckAllSymbol(bool all)
        {
            AllSymbol = all;
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
            if (lastPoint != null)
            {
                lastPoint.X += dx;
                lastPoint.Y += dy;
                lastPoint.Current = false;
                currpoints.Clear();
            }
        }
        public void PointIn(PointF p)
        {
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
                {
                    myPoints.RemoveAt(i);
                    i--;
                }
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
        public int SearchMyPoint(PointF p)
        {
            for (int i = 0; i < myPoints.Count; i++)
            {
                MyPoint P = myPoints[i];
                if (p.X <= P.X + 4 && p.X >= P.X - 4 && p.Y >= P.Y - 4 && p.Y <= P.Y + 4)
                    return i;
            }
            return -1;
        }
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
        public void DrawSymbol(Graphics g)
        {
            if (curSymbol != null && curSymbol.contours != null)
            {
                foreach (Contour c in curSymbol.contours)
                    c.Draw(g, allix);
            }
        }
        public void DrawCurContour(Graphics g)
        {
            if (curContour != null)
            {
                curContour.Draw(g, allix);
            }
        }
        public void DrawAll(Graphics g)
        {
            DrawLines(g);
            if (AllSymbol)
                DrawSymbol(g);
            else
                DrawCurContour(g);
        }
    }
}
