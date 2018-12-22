using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public class Contour
    {
        public List<ILine> lines;
        public List<MyPoint> myPoints;
        public Contour(List<ILine> l)
        {
            lines = l;
            myPoints = new List<MyPoint>();
        }
        public bool Current;
        public Contour()
        {
            lines = new List<ILine>();
            myPoints = new List<MyPoint>();
            Current = false;
        }
        public List<MyPoint> GetPoints()
        {
            List<MyPoint> myPoints = new List<MyPoint>();
            foreach (ILine l in lines)
                foreach (MyPoint p in l.GetPoints())
                    myPoints.Add(p);
            for (int i = 0; i < myPoints.Count; i++)
            {
                for (int j = i + 1; j < myPoints.Count;)
                {
                    if (myPoints[i].X == myPoints[j].X && myPoints[i].Y == myPoints[j].Y)
                        myPoints.RemoveAt(j);
                    else
                        j++;
                }
            }
            return myPoints;
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y, ScreenConverter sc)
        {
            foreach (ILine l in lines)
                l.Draw(g, allix, pt, x, y, sc);
        }
        public void Draw(Graphics g, bool allix, bool coord, ScreenConverter sc)
        {
            foreach (MyPoint p in myPoints)
                p.Draw(g, Current, allix, coord, sc);
            foreach (ILine l in lines)
                l.Draw(g, Current, Color.Black, allix, sc);
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y)
        {
            
            /*foreach (MyPoint p in myPoints)
                p.Draw(g, allix, pt, x, y);*/
            foreach (ILine l in lines)
                l.Draw(g, allix, pt, x, y);
        }
        public override string ToString()
        {
            string result = "";
            foreach (ILine l in lines)
                result += "ln:" + l.ToString();
            return result;
        }
    }
}
