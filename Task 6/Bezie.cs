using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Bezie: ILine
    {
        PointF P1;
        PointF P2;
        PointF P3;
        PointF P4;
        public Bezie(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }
        private PointF B(float t)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            float x = c0 * P1.X + c1 * P2.X + c2 * P3.X + c3 * P4.X;
            float y = c0 * P1.Y + c1 * P2.Y + c2 * P3.Y + c3 * P4.Y;
            return new PointF(x, y);
        }
        public void Draw(Graphics g)
        {
            float t = 0f;
            float dt = 0.01f;
            PointF[] result = new PointF[101];
            for (int i = 0; i <= 100; i++)
            {
                //x = (1 - t) * (1 - t) * (1 - 3) * P1.X + 3 * (1 - t) * (1 - t) * t * P2.X + 3 * (1 - t) * t * t * P3.X + t * t * t * P4.X;
                //y = (1 - t) * (1 - t) * (1 - 3) * P1.Y + 3 * (1 - t) * (1 - t) * t * P2.Y + 3 * (1 - t) * t * t * P3.Y + t * t * t * P4.Y;
                //result[(int)(t * 100)] = new PointF(x, y);
                result[i] = B(t);
                t += dt;
                
            }
            g.DrawLines(Pens.Black, result);
        }
        public override string ToString()
        {
            return "bz:" + P1.X.ToString() + "," + P1.Y.ToString() + "," + P2.X.ToString() + "," + P2.Y.ToString() + "," + P3.X.ToString() + "," + P3.Y.ToString() + "," + P4.X.ToString() + "," + P4.Y.ToString() + " ";
        }
    }
}
