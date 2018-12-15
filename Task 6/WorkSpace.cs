using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class WorkSpace
    {
        int Height { get; set; }
        int Width { get; set; }
        List<Contour> contours;
        char symbol;
        public List<ILine> lines;
        public List<PointF> points;
        public WorkSpace(int h, int w, char c)
        {
            Height = h;
            Width = w;
            points = new List<PointF>();
            contours = new List<Contour>();
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
            points.Add(p);
        }
        public void DeletePoint(PointF p)
        {
            points.Remove(p);
        }
        public void AddILine(PointF p1, PointF p2)
        {
            lines.Add(new Line(p1, p2));
        }
        public int SearchPoint(PointF p)
        {
            for (int i = 0; i < points.Count; i++)
            {
                PointF P = points[i];
                if (p.X <= P.X + 1 && p.X >= P.X - 1 && p.Y >= P.Y - 1 && p.Y <= P.Y + 1)
                    return i;
            }
            return -1;
        }
        public void AddILine(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            lines.Add(new Bezie(p1, p2, p3, p4));
        }
        public void DrawContour(Graphics g, Contour c)
        {
            c.Draw(g);
        }
        public void DrawContours(Graphics g, List<Contour> c)
        {
            foreach (Contour co in c)
                co.Draw(g);
        }
        public void DrawAll(Graphics g)
        {
            foreach (Contour c in contours)
                c.Draw(g);
        }
    }
}
