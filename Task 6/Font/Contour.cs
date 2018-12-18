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
        public void Draw(Graphics g, bool allix)
        {
            foreach (MyPoint p in myPoints)
                p.Draw(g, allix);
            foreach (ILine l in lines)
                l.Draw(g, allix);
        }
        public override string ToString()
        {
            string result = "";
            foreach (ILine l in lines)
                result += l.ToString();
            return result;
        }
    }
}
