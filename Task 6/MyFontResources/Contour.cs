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
        public Contour()
        {
            lines = new List<ILine>();
            myPoints = new List<MyPoint>();
        }
        public void Draw(Graphics g, bool allix, int pt, float x, float y, ScreenConverter sc)
        {
            foreach (ILine l in lines)
                l.Draw(g, allix, pt, x, y, sc);
        }
        public void Draw(Graphics g, bool allix, bool coord, ScreenConverter sc)
        {
            foreach (MyPoint p in myPoints)
                p.Draw(g, allix, coord, sc);
            foreach (ILine l in lines)
                l.Draw(g, allix, sc);
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
