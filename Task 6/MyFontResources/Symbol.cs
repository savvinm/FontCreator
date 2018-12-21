using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public class Symbol
    {
        public char symbol;
        public List<Contour> contours;
        public Symbol(char s, List<Contour> c)
        {
            symbol = s;
            contours = c;
        }
        public Symbol(char s)
        {
            symbol = s;
            contours = new List<Contour>();
        }
        public Symbol()
        {
            contours = new List<Contour>();
        }
        public void Draw(Graphics g, int pt, float x, float y, ScreenConverter sc)
        {
            foreach (Contour c in contours)
                c.Draw(g, false, pt, x, y, sc);
        }
        public void Draw(Graphics g, bool allix, bool coord, ScreenConverter sc)
        {
            foreach (Contour c in contours)
                c.Draw(g, allix, coord, sc);
        }
        public void Draw(Graphics g, int pt, float x, float y)
        {
            foreach (Contour c in contours)
                c.Draw(g, false, pt, x, y);
        }
        public override string ToString()
        {
            string result = symbol.ToString() + " ";
            foreach (Contour c in contours)
                result += "cnt:" + c.ToString();
            return result;
        }
    }
}
