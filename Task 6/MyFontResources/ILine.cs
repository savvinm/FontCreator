using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public interface ILine
    {
        void Draw(Graphics g, bool allix);
        void Draw(Graphics g, bool allix, float x, float y);
        string ToString();
        bool Check();
        void ToOnePT(float coef);
        List<MyPoint> GetPoints();
        void PointByIndex(int n, MyPoint p);
    }
}
