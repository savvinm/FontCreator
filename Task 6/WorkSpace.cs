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
            font = new MyFont(filename);
            curContour = null;
            currpoints.Clear();
            curSymbol = null;
            myPoints = null;
            font.SortSymbols();
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
        private void DrawLines(Graphics g)
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
            font.SortSymbols();
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
        public void UpdatePoint(float dx, float dy, ScreenConverter sc)
        {
            if (lastPoint != null)
            {
                if (!(sc.II(lastPoint.X) + dx > Width - 4) && sc.II(lastPoint.X) + dx > 0)
                    lastPoint.X += sc.LR((int)dx);
                if (!(sc.JJ(lastPoint.Y) + dy > Height - 4) && sc.JJ(lastPoint.Y) + dy > 0)
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
        public void DeleteSymbol(int n)
        {
            if (n!= -1 && n < font.symbols.Count)
            {
                font.symbols.RemoveAt(n);
                curSymbol = null;
            }
        }
        public void DeleteContour(int n)
        {
            if (n!= -1 && n < curSymbol.contours.Count)
            {
                curSymbol.contours.RemoveAt(n);
                curContour = null;       
            }
        }
        public void DeletePoints()
        {
            currpoints.Clear();
            for (int i = 0; i < myPoints.Count; i++)
            {
                if (myPoints[i].Current)
                {
                    for (int j = 0; j < lines.Count; j++)
                    {
                        foreach (MyPoint p in lines[j].GetPoints())
                        {
                            if (p == myPoints[i])
                            {
                                lines.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    myPoints.RemoveAt(i);
                    i--;
                }
            }
           // CheckPoints();
            /*foreach(ILine l in lines)
            {
                if (l.Check())
                {
                    lines.Remove(l);
                }
            }*/
        }
        private void AddILine(MyPoint p1, MyPoint p2)
        {
            lines.Add(new Line(p1, p2));
        }
        private int SearchMyPoint(PointF p, ScreenConverter sc)
        {
            for (int i = 0; i < myPoints.Count; i++)
            {
                MyPoint P = myPoints[i];
                if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
                    return i;
            }
            return -1;
        }
        private void AddILine(MyPoint p1, MyPoint p2, MyPoint p3, MyPoint p4)
        {
            lines.Add(new Bezie(p1, p2, p3, p4));
        }
        public void AddLine()
        {
            if (currpoints.Count == 2)
            {
                AddILine(currpoints[0], currpoints[1]);
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
        public void AddCurve()
        {
            if (currpoints.Count == 4)
            {
                AddILine(currpoints[0], currpoints[1], currpoints[2], currpoints[3]);
            }
            foreach (MyPoint p in myPoints)
                p.Current = false;
            currpoints.Clear();
        }
        private void DrawContour(Graphics g, Contour c, ScreenConverter sc)
        {
            c.Draw(g, allix, coord, sc);
        }
        private void DrawContours(Graphics g, List<Contour> c, ScreenConverter sc)
        {
            foreach (Contour co in c)
                co.Draw(g, allix, coord, sc);
        }
        private void DrawSymbol(Graphics g, ScreenConverter sc)
        {
            if (curSymbol != null && curSymbol.contours != null)
            {
                foreach (Contour c in curSymbol.contours)
                    c.Draw(g, allix, coord, sc);
            }
        }
        private void DrawCurContour(Graphics g, ScreenConverter sc)
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
