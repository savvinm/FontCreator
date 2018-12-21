using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Task_6
{
    public class MyFont
    {
        public List<Symbol> symbols;
        public MyFont(int sCount)
        {
            symbols = new List<Symbol>(sCount);
        }
        public MyFont()
        {
            symbols = new List<Symbol>();
        }
        public void DrawString(Graphics g, string s, int pt, float x, float y)
        {
            foreach (Char c in s)
                foreach (Symbol sym in symbols)
                {
                    if (sym.symbol == c)
                    {
                        sym.Draw(g, pt, x, y);
                        break;
                    }
                }
        }
        public void DrawSymbol(Graphics g, char c, bool allix, bool coord, ScreenConverter sc)
        {
            foreach (Symbol s in symbols)
            {
                if (s.symbol == c)
                    s.Draw(g, allix, coord, sc);
            }
        }
        public void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (Symbol s in symbols)
                sw.WriteLine(s.ToString());
            sw.Close();
        }
        public MyFont Load(string filename)
        {
            MyFont font = new MyFont();
            FontInterpretator fi = new FontInterpretator();
            string line = "";
            StreamReader sr = new StreamReader(filename);
            while (true)
            {
                line = sr.ReadLine();
                if (line == null)
                    break;
                font.symbols.Add(fi.SymbolFromString(line));
            }
            sr.Close();
            return font;
        }
    }
}
