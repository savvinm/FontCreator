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
            MyPoint p3 = new MyPoint(p1.X + dx, p1.Y + dy);
            MyPoint p4 = new MyPoint(p2.X - dx, p2.Y - dy);
            points.Add(p3);
            points.Add(p4);
            return new Bezie(p1, p3, p4, p2);
        }
    }
}
