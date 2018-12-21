using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class FontInterpretator
    {
        public Symbol SymbolFromString(string str)
        {
            Symbol s = new Symbol();
            int pos = 0;
            while (str[pos] == ' ')
                pos++;
            s.symbol = str[pos];
            pos++;
            if (pos == str.Length - 1)
                return s;
            while (str[pos] == ' ')
                pos++;
            while (str[pos] == 'c' && str[pos + 1] == 'n' && str[pos + 2] == 't' && str[pos + 3] == ':')
            {
                pos += 4;
                s.contours.Add(ContourFromString(str, ref pos));
                if (pos >= str.Length)
                    break;
                while (str[pos] == ' ')
                    pos++;
            }
            return s;
        }
        private Contour ContourFromString(string str, ref int pos)
        {
            Contour c = new Contour();
            while (str[pos] == ' ')
                pos++;
            while (str[pos] == 'l' && str[pos + 1] == 'n' && str[pos + 2] == ':')
            {
                pos += 3;
                c.lines.Add(LineFromString(str, ref pos));
                if (pos >= str.Length)
                    break;
                while (str[pos] == ' ')
                    pos++;
            }
            List<MyPoint> points = c.GetPoints();
            List<ILine> L = c.lines;
            List<ILine> ln = new List<ILine>();
            foreach (ILine l in L)
                ln.Add(LineOnPoints(l, points));
            c.myPoints = points;
            c.lines = ln;
            return c;
        }
        private ILine LineOnPoints(ILine l, List<MyPoint> points)
        {
            List<MyPoint> pnt = l.GetPoints();
            List<MyPoint> myPoints = new List<MyPoint>();
            for (int i = 0; i < pnt.Count; i++)
            {
                foreach (MyPoint p in points)
                    if (pnt[i].X == p.X && pnt[i].Y == p.Y)
                        myPoints.Add(p);
            }
            if (pnt.Count == 2)
                return new Line(myPoints[0], myPoints[1]);
            if (pnt.Count == 4)
                return new Bezie(myPoints[0], myPoints[1], myPoints[2], myPoints[3]);
            else
                throw new Exception("");
        }
        private List<MyPoint> PointsFromString(string str, ref int pos)
        {
            List<MyPoint> myPoints = new List<MyPoint>();
            while (str[pos] == ' ')
                pos++;
            while (str[pos] != 'l' && str[pos] != 'c')
            {
                if (pos == str.Length)
                    break;
                myPoints.Add(PointFromString(str, ref pos));
                pos++;
                if (pos >= str.Length)
                    break;
                while (str[pos] == ' ' && pos < str.Length - 1)
                    pos++;
            }
            /*if (myPoints.Count == 2)
                return new Line(myPoints[0], myPoints[1]);
            if (myPoints.Count == 4)
                return new Bezie(myPoints[0], myPoints[1], myPoints[2], myPoints[3]);
            else
                throw new Exception("");*/
            return myPoints;
        }
        private ILine LineFromString(string str, ref int pos)
        {
            List<MyPoint> myPoints = new List<MyPoint>();
            while (str[pos] == ' ')
                pos++;
            while (str[pos] != 'l' && str[pos] != 'c')
            {
                if (pos == str.Length)
                    break;
                myPoints.Add(PointFromString(str, ref pos));
                pos++;
                if (pos >= str.Length)
                    break;
                while (str[pos] == ' ' && pos < str.Length - 1)
                    pos++;
            }
            if (myPoints.Count == 2)
                return new Line(myPoints[0], myPoints[1]);
            if (myPoints.Count == 4)
                return new Bezie(myPoints[0], myPoints[1], myPoints[2], myPoints[3]);
            else
                throw new Exception("");
        }
        private MyPoint PointFromString(string str, ref int pos)
        {
            MyPoint p = new MyPoint();
            string s = "";
            while (str[pos] == ' ')
                pos++;
            if (pos == str.Length - 1)
                return null;
            while(str[pos] != ',' && str[pos] != ' ')
            {
                s += str[pos];
                pos++;
            }
            p.X = Convert.ToSingle(s);
            s = "";
            pos++;
            while (str[pos] == ' ')
                pos++;
            if (pos == str.Length - 1)
                return null;
            while (str[pos] != ',' && str[pos] != ' ')
            {
                
                s += str[pos];
                pos++;
                if (pos == str.Length)
                    break;
            }
            p.Y = Convert.ToDouble(s);
            return p;
        }
        private int PointInList(List<MyPoint> l, MyPoint p)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].X == p.X && l[i].Y == p.Y)
                    return i;
            }
            return -1;
        }
    }
}
