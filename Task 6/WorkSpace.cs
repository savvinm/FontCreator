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
        MyPoint curPoint;
        bool allix;
        bool AllSymbol;
        bool coord;
        bool closed;
        public WorkSpace(int w, int h)
        {
            Height = h;
            Width = w;
            currpoints = new List<MyPoint>();
            myPoints = new List<MyPoint>();
            curPoint = new MyPoint();
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
            myPoints = new List<MyPoint>();
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
                if (curSymbol != null)
                    foreach (Contour c in curSymbol.contours)
                        c.Current = false;
                curSymbol = font.symbols[n];
                closed = false;
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
                foreach (Contour c in curSymbol.contours)
                    c.Current = false;
                lines = curSymbol.contours[n].lines;
                curContour = curSymbol.contours[n];
                curContour.Current = true;
                myPoints = curContour.myPoints;
                curSymbol.contours[n].Current = true;
                closed = false;
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
        public void CloseContour(ILIneFactory factory)
        {
            if (myPoints.Count >=3)
            lines.Add(factory.Create(lastPoint, myPoints[0], myPoints));
            closed = true;
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
            if (curPoint != null)
            {
                    MyPoint cur = curPoint;
                    if (!(sc.II(cur.X) + dx > Width - 4) && sc.II(cur.X) + dx > 0)
                        cur.X += sc.LR((int)dx);
                    if (!(sc.JJ(cur.Y) + dy > Height - 4) && sc.JJ(cur.Y) + dy > 0)
                        cur.Y -= sc.LR((int)dy);
                    lastPoint.Current = false;
                   // lastPoint = myPoints.Last();
                    currpoints.Clear();
                    foreach (MyPoint P in myPoints)
                        P.Current = false;
                //}
                /*if (!(sc.II(lastPoint.X) + dx > Width - 4) && sc.II(lastPoint.X) + dx > 0)
                    lastPoint.X += sc.LR((int)dx);
                if (!(sc.JJ(lastPoint.Y) + dy > Height - 4) && sc.JJ(lastPoint.Y) + dy > 0)
                    lastPoint.Y -= sc.LR((int)dy);
                lastPoint.Current = false;
                lastPoint = myPoints.Last();
                currpoints.Clear();*/
            }
        }
        public void PointIn(PointF p, ScreenConverter sc)
        {
            if (curContour != null)
            {
                int n = SearchMyPoint(p, sc);
                if (n != -1)
                {
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
        }
        public void PointIn(PointF p, ILIneFactory factory, ILIneFactory fact, ScreenConverter sc)
        {
            if (curContour != null)
            {
                int n = SearchMyPoint(p, sc);
                if (n != -1)
                {
                    curPoint = myPoints[n];
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
                    if (lastPoint == null)
                    {
                        myPoints.Add(new MyPoint(sc.XX((int)p.X), sc.YY((int)p.Y)));
                        if (myPoints.Count == 1)
                            myPoints[0].First = true;
                        lastPoint = myPoints.Last();
                    }
                    else
                    {
                        if (closed)
                            lines.RemoveAt(lines.Count - 1);
                        MyPoint curP = new MyPoint(sc.XX((int)p.X), sc.YY((int)p.Y));
                        lines.Add(factory.Create(lastPoint, curP, myPoints));
                        myPoints.Add(curP);
                        lastPoint = myPoints.Last();
                    }
                    if (myPoints.Count >= 3)
                    {
                        CloseContour(fact);
                        closed = true;
                    }
                }
            }
        }
        public void DeleteSymbol(int n)
        {
            if (n!= -1 && n < font.symbols.Count)
            {
                font.symbols.RemoveAt(n);
                curSymbol = null;
                lastPoint = null;
            }
        }
        public void DeleteContour(int n)
        {
            if (n!= -1 && n < curSymbol.contours.Count)
            {
                curSymbol.contours.RemoveAt(n);
                curContour = null;
                lastPoint = null;
            }
        }
        public void DeletePoints(ILIneFactory factory)
        {
            currpoints.Clear();
            int i = 0;
            while (i < myPoints.Count)
            {
                if (myPoints[i].Current)
                {
                    while (myPoints[i].Current && i < myPoints.Count)
                    {
                        int n = 0;
                        for (int j = 0; j < lines.Count; i++)
                        {
                            foreach(MyPoint p in lines[j].GetPoints())
                            {
                                if (p.X == myPoints[i].X && p.Y == myPoints[i].Y)
                                {
                                    lines.RemoveAt(j);
                                    n = j;
                                }
                            }
                        }
                        myPoints.RemoveAt(i);
                        i--;
                    }
                    lines.Add(factory.Create(myPoints[i-1], myPoints[i], myPoints));
                }
                i++;
            }
            /*for (int i = 0; i < myPoints.Count; i++)
            {
                int n = 0;
                if (myPoints[i].Current)
                {
                    for (int j = 0; j < lines.Count; j++)
                    {
                        foreach (MyPoint p in lines[j].GetPoints())
                        {
                            if (p.X == myPoints[i].X && p.Y == myPoints[i].Y)
                            {
                                lines.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    n++;
                    myPoints.RemoveAt(i);
                    lines.Add(factory.Create(myPoints[i - 1], myPoints[i - 1 + n], myPoints));
                    i--;
                }
            }*/
            lastPoint = myPoints.Last();
            CloseContour(factory);
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
            if (p != null)
            {
                for (int i = 0; i < myPoints.Count; i++)
                {
                    MyPoint P = myPoints[i];
                    if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
                        return i;
                }
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
