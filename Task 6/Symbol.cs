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
        char symbol;
        List<Bezie> bezies;
        List<Line> lines;
        public Symbol(char c, List<Bezie> b, List<Line> l)
        {
            symbol = c; 
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
        public override string ToString()
        {
            string result = symbol.ToString() + " ";
            foreach (Line l in lines)
                result += l.ToString();
            foreach (Bezie b in bezies)
                result += b.ToString();
            return result;
        }
    }
}
