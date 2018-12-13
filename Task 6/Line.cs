using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Line
    {
        PointF P1;
        PointF P2;
        public Line(PointF p1, PointF p2)
        {
            P1 = p1;
            P2 = p2;
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(Pens.Black, P1, P2);
        }
    }
}
