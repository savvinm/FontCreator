using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Line: ILine
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
        public override string ToString()
        {
            return "ln:" + P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + " "; 
        }
    }
}
