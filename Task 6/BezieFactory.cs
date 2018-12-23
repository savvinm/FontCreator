using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class BezieFactory :ILIneFactory
    {
        public ILine Create(MyPoint p1, MyPoint p2, List<MyPoint> points)
        {
            double dx = Math.Abs(p1.X - p2.X)/4;
            double dy = Math.Abs(p1.Y - p2.Y)/4;
            double x = 0, y = 0;
            x = (p1.X + p2.X * (1f / 3f)) / (1 + (1f / 3f));
            y = (p1.Y + p2.Y * (1f / 3f)) / (1 + (1f / 3f));
            MyPoint p3 = new MyPoint(x, y);
            x = (p1.X + p2.X * 3) / (1 + 3);
            y = (p1.Y + p2.Y * 3) / (1 + 3);
            MyPoint p4 = new MyPoint(x, y);
            points.Add(p3);
            points.Add(p4);
            return new Bezie(p1, p3, p4, p2);
        }
    }
}
