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
        void Draw(Graphics g, bool allix, ScreenConverter sc);
        void Draw(Graphics g, bool allix, int pt, float x, float y);
        void Draw(Graphics g, bool allix, int pt, float x, float y, ScreenConverter sc);
        string ToString();
        bool Check();
        List<MyPoint> GetPoints();
        void PointByIndex(int n, MyPoint p);
    }
}
