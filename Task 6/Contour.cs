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
        public Contour(List<ILine> l)
        {
            lines = l;
        }
        public void Draw(Graphics g, bool allix)
        {
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
