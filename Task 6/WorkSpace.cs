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
        bool coord;
        public WorkSpace(int w, int h)
        {
            Height = h;
            Width = w;
            currpoints = new List<MyPoint>();
            myPoints = new List<MyPoint>();
            font = new MyFont();
            allix = true;
            AllSymbol = false;
            coord = true;
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
        public void CheckCoord(bool all)
        {
            coord = all;
        }
        public void AddPoint(PointF p)
        {
            //points.Add(p);
        }
        public void UpdatePoint(PointF p, float dx, float dy, ScreenConverter sc)
        {
            /*int n = SearchMyPoint(p);
            if (n != -1)
            {
                myPoints[n].X += dx;
                myPoints[n].Y += dy;
            }*/
            if (lastPoint != null)
            {
                lastPoint.X += sc.LR((int)dx);
                lastPoint.Y -= sc.LR((int)dy);
                lastPoint.Current = false;
                currpoints.Clear();
            }
        }
        public void PointIn(PointF p, ScreenConverter sc)
        {
            int n = SearchMyPoint(p, sc);
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
                myPoints.Add(new MyPoint(sc.XX((int)p.X), sc.YY((int)p.Y)));
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
        public int SearchMyPoint(PointF p, ScreenConverter sc)
        {
            for (int i = 0; i < myPoints.Count; i++)
            {
                MyPoint P = myPoints[i];
                if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
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
            if (currpoints.Count == 2)
            {
                AddILine(currpoints[0], currpoints[1]);
            }
            if (currpoints.Count == 4)
            {
                AddILine(currpoints[0], currpoints[1], currpoints[2], currpoints[3]);
            }
            else
            {
                for(int i = 0; i < currpoints.Count -1; i++)
                {
                    AddILine(currpoints[i], currpoints[i + 1]);
                }
            }
            foreach (MyPoint p in myPoints)
                p.Current = false;
            currpoints.Clear();
        }
        public void DrawContour(Graphics g, Contour c, ScreenConverter sc)
        {
            c.Draw(g, allix, coord, sc);
        }
        public void DrawContours(Graphics g, List<Contour> c, ScreenConverter sc)
        {
            foreach (Contour co in c)
                co.Draw(g, allix, coord, sc);
        }
        public void DrawSymbol(Graphics g, ScreenConverter sc)
        {
            if (curSymbol != null && curSymbol.contours != null)
            {
                foreach (Contour c in curSymbol.contours)
                    c.Draw(g, allix, coord, sc);
            }
        }
        public void DrawCurContour(Graphics g, ScreenConverter sc)
        {
            if (curContour != null)
            {
                curContour.Draw(g, allix, coord, sc);
            }
        }
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            DrawLines(g);
            if (AllSymbol)
                DrawSymbol(g, sc);
            else
                DrawCurContour(g, sc);
        }
    }
}
