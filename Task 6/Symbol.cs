using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class Symbol
    {
        List<Bezie> bezies;
        List<Line> lines;
        public Symbol(List<Bezie> b, List<Line> l)
        {
            bezies = b;
            lines = l;
        }
        public void Draw(Graphics g)
        {
            foreach (Bezie b in bezies)
                b.Draw(g);
            foreach (Line l in lines)
                l.Draw(g);
        }
    }
}
