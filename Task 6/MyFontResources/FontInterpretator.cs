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
            int n = 0;
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
            foreach(ILine l in c.lines)
            {
                foreach (MyPoint p in l.GetPoints())
                    c.myPoints.Add(p);
            }
            /*for (int j = 0; j < c.lines.Count; j++)
            {
                List<MyPoint> list = c.lines[j].GetPoints();
                for (int i = 0; i < list.Count; i++)
                {
                    int n = PointInList(c.myPoints, list[i]);
                    if(n != -1)
                    {
                        c.lines[j].PointByIndex(i, c.myPoints[n]);
                        /*if(list.Count == 2)
                        {
                            if (i == 0)
                                c.lines[j] = new Line(c.myPoints[n], list[1]);
                            if (i == 1)
                                c.lines[j] = new Line(list[0], c.myPoints[n]);
                            c.myPoints.Add(list[0]);
                            c.myPoints.Add(list[1]);
                        }
                        if(list.Count == 4)
                        {
                            if (i == 0)
                                c.lines[j] = new Bezie(list[i], list[1], list[2], list[3]);
                            if (i == 1)
                                c.lines[j] = new Bezie(list[0], list[1], list[2], list[3]);
                        }
                        foreach (MyPoint p in c.lines[j].GetPoints())
                            c.myPoints.Add(p);
                        break;
                    }
                    foreach (MyPoint p in c.lines[j].GetPoints())
                        c.myPoints.Add(p);
                    //c.myPoints.Add(p);
                    //PointInList(c.myPoints, p);
                }
            }*/
            return c;
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
