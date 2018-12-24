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
        MyPoint lastPoint;
        MyPoint curPoint;
        MyPoint firstPoint;
        bool allix;
        bool AllSymbol;
        bool coord;
        public WorkSpace(int w, int h)
        {
            Height = h;
            Width = w;
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
            curSymbol = null;
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
                curContour = curSymbol.contours[n];
                curContour.Current = true;
                curSymbol.contours[n].Current = true;
                firstPoint = null;
                curPoint = null;
                lastPoint = null;
                if (curContour.GetPoints().Count > 0)
                {
                    foreach (MyPoint p in curContour.GetPoints())
                        if (p.First)
                            firstPoint = p;
                    GetLastPoint();
                }
            }
        }
        private void GetLastPoint()
        {
            foreach(ILine l in curContour.lines)
            {
                if (l.GetPoints()[1] == firstPoint)
                    lastPoint = l.GetPoints()[0];
                if (l.GetPoints()[0] == firstPoint)
                    lastPoint = l.GetPoints()[1];
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
            RemoveLines();

            if (curContour.myPoints.Count < 2)
                curContour.lines.Clear();
            if (curContour.myPoints.Count == 2)
            {
                if (curContour.lines.Count > 1)
                    RemoveLastLine();
                curContour.lines.Add(factory.Create(lastPoint, firstPoint));
            }
            if (curContour.myPoints.Count > 2)
            {
                /*if (factory.Create(lastPoint, firstPoint).TypeEqualTo(curContour.lines.Last()))
                return;*/
                RemoveLastLine();
                curContour.lines.Add(factory.Create(lastPoint, firstPoint));
            }
            RemoveLines();
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
                curPoint.Current = false;
            }
        }
        public void PointIn(PointF p, ILIneFactory factory, ILIneFactory fact, ScreenConverter sc)
        {
            if (curContour != null)
            {
                int n = SearchMyPoint(p, sc);
                if (n != -1)
                {
                    curPoint = curContour.myPoints[n];
                    if (curContour.myPoints[n].Current)
                        curContour.myPoints[n].Current = false;
                    else
                        curContour.myPoints[n].Current = true;
                    return;
                }
                if(SearchPoint(p, sc) != null)
                {
                    curPoint = SearchPoint(p, sc);
                    return;
                }
                else
                {
                    if (lastPoint == null)
                    {
                        curContour.myPoints.Add(new MyPoint(sc.XX((int)p.X), sc.YY((int)p.Y)));
                        if (curContour.myPoints.Count == 1)
                        {
                            curContour.myPoints[0].First = true;
                            firstPoint = curContour.myPoints[0];
                        }
                        lastPoint = curContour.myPoints.Last();
                    }
                    else
                    {
                        if (curContour.myPoints.Count >= 2)
                            RemoveLastLine();
                        MyPoint curP = new MyPoint(sc.XX((int)p.X), sc.YY((int)p.Y));
                        curContour.lines.Add(factory.Create(lastPoint, curP));
                        curContour.myPoints.Add(curP);
                        lastPoint = curContour.myPoints.Last();
                    }
                    if (curContour.myPoints.Count >= 2)
                        CloseContour(fact);
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
        private void UpdatePointList()
        {
            MyPoint cur = new MyPoint();
            List<MyPoint> points = new List<MyPoint>();
            /*foreach(ILine l in lines)
            {
                List<MyPoint> po = l.GetPoints()
                foreach (MyPoint p in po)
                {
                    if(po.Count == 2)
                    {
                        if ()
                    }
                }
            }*/
        }
        private void RemoveLastLine()
        {
            for (int j = 0; j < curContour.lines.Count; j++)
            {
                List<MyPoint> p = curContour.lines[j].GetPoints();
                if (p[0].EqualTo(lastPoint) && p[1].EqualTo(firstPoint))
                {
                    curContour.lines.RemoveAt(j);
                    j--;
                }
            }
        }
        private void RemoveLines()
        {
            for (int i = 0; i < curContour.lines.Count; i++)
            {
                for (int j = i+1; j < curContour.lines.Count; j++)
                {
                    if (curContour.lines[i].EqualTo(curContour.lines[j]))
                    {
                        curContour.lines.RemoveAt(j);
                        j--;
                    }
                }
              /*  if (curContour.lines[i].GetPoints()[0].EqualTo(curContour.lines[i].GetPoints()[1]))
                { 
                   curContour.lines.RemoveAt(i);
                    i--;
                }*/
            }
        }
        public void DeletePoints(ILIneFactory factory, ILIneFactory fact)
        {
            for (int i = 0; i < curContour.myPoints.Count; i++)
            {
                if (curContour.myPoints[i].Current)
                {
                    if (curContour.myPoints[i].First)
                    {
                        firstPoint = curContour.myPoints[curContour.myPoints.Count > i + 1 ? i + 1 : 0];
                        curContour.myPoints[curContour.myPoints.Count > i + 1 ? i + 1 : 0].First = true;
                    }
                    DeletePoint(factory, i);
                    /*if (i == curContour.myPoints.Count)
                        CloseContour(fact);*/
                    //curContour.myPoints.RemoveAt(i);
                    i--;
                }
            }
            RemoveLastLine();
            if (curContour.myPoints.Count > 1)
            {
                lastPoint = curContour.myPoints.Last();
                if (!lastPoint.EqualTo(curContour.myPoints.Last()))
                    CloseContour(fact);
                return;
              // lastPoint = curContour.myPoints.Last();
            }
            if(curContour.myPoints.Count == 1)
            {
                lastPoint = firstPoint;
                return;
            }
            else
            {
                lastPoint = null;
                firstPoint = null;
            }
            //CloseContour(fact);
            //RemoveLastLine();
        }
        private void DeletePoint(ILIneFactory factory, int n)
        {
            /*for (int i = 0; i < curContour.lines.Count; i++)
            {
                foreach(MyPoint p in curContour.lines[i].GetPoints())
                {
                    if (p.EqualTo(curContour.myPoints[n]))
                    {
                        curContour.lines[i] = factory.Create(curContour.myPoints[n - 1 >= 0 ? n - 1: curContour.myPoints.Count - n - 1], 
                            curContour.myPoints[curContour.myPoints.Count > n + 1 ? n + 1 : n + 1 - curContour.myPoints.Count]);
                        break;
                    }
                }
            }*/
            //int i = n / 2;

            if (curContour.lines.Count > n)
                 curContour.lines.RemoveAt(n);
            if (curContour.lines.Count == 1)
            {
                curContour.myPoints.RemoveAt(n);
                return;
            }
               int i = n - 1 >= 0 ? n - 1 : curContour.lines.Count - 1;
            // curContour.lines.RemoveAt(i);
            curContour.lines[i] = factory.Create(curContour.myPoints[n - 1 >= 0 ? n - 1 : curContour.myPoints.Count - n - 1],
                            curContour.myPoints[curContour.myPoints.Count > n + 1 ? n + 1 : n + 1 - curContour.myPoints.Count]);
            curContour.myPoints.RemoveAt(n);
            //lastPoint = curContour.myPoints.Last();*/
        }
        private int SearchMyPoint(PointF p, ScreenConverter sc)
        {
            if (p != null)
            {
                for (int i = 0; i < curContour.myPoints.Count; i++)
                {
                    MyPoint P = curContour.myPoints[i];
                    if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
                        return i;
                }
            }
            return -1;
        }
        private MyPoint SearchPoint(PointF p, ScreenConverter sc)
        {
            /*foreach (MyPoint P in curContour.myPoints)
                if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
                    return P;*/
            foreach (ILine l in curContour.lines)
                foreach (MyPoint P in l.GetSecondPoints())
                    if (p.X <= sc.II(P.X) + 4 && p.X >= sc.II(P.X) - 4 && p.Y >= sc.JJ(P.Y) - 4 && p.Y <= sc.JJ(P.Y) + 4)
                        return P;
            return null;
        }
        public void ChangeWidth(int percent)
        {
            font.symbolWidth = percent; 
        }
        public void DrawBorder(Graphics g, ScreenConverter sc)
        {
            PointF p1 = new PointF(sc.II(0), sc.JJ(0));
            PointF p2 = new PointF(sc.II(0), sc.JJ(1));
            PointF p3 = new PointF(sc.II(1 *font.symbolWidth / 100f), sc.JJ(0));
            PointF p4 = new PointF(sc.II(1 * font.symbolWidth / 100f), sc.JJ(1));
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p1, p3);
            g.DrawLine(Pens.Black, p4, p3);
            g.DrawLine(Pens.Black, p2, p4);
            //g.DrawRectangle(Pens.Black, sc.II(sc.RX), sc.JJ(sc.RY), sc.LS(1), sc.LS(1));
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
            DrawBorder(g, sc);
            if (AllSymbol)
                DrawSymbol(g, sc);
            else
                DrawCurContour(g, sc);
        }
    }
}
