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
        public int symbolWidth;
        public MyFont(int sCount)
        {
            symbols = new List<Symbol>(sCount);
            symbolWidth = 100;
        }
        public MyFont()
        {
            symbols = new List<Symbol>();
            symbolWidth = 100;
        }
        public MyFont(string filename)
        {
            FontInterpretator fi = new FontInterpretator();
            string line = "";
            symbols = new List<Symbol>();
            symbolWidth = 100;
            StreamReader sr = new StreamReader(filename);
            line = sr.ReadLine();
            if (line == null)
                return;
            symbolWidth = Convert.ToInt32(line);
            while (true)
            {
                line = sr.ReadLine();
                if (line == null)
                    break;
                symbols.Add(fi.SymbolFromString(line));
            }
            sr.Close();
        }
        public void DrawString(Graphics g, string s, int pt, float x, float y)
        {
            foreach (Char c in s)
            {
                foreach (Symbol sym in symbols)
                {
                    if (sym.symbol == c)
                    {
                        sym.Draw(g, pt, x, y);
                        break;
                    }
                }
                x += symbolWidth / 100f * pt * 1.05f;
            }
        }
        public void SortSymbols()
        {
            for (int i = 1; i < symbols.Count; i++)
            {
                Symbol cur = symbols[i];
                int j = i;
                while (j > 0 && cur.symbol < symbols[j - 1].symbol)
                {
                    symbols[j] = symbols[j - 1];
                    j--;
                }
                symbols[j] = cur;
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
            sw.WriteLine(symbolWidth.ToString());
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
            line = sr.ReadLine();
            if (line == null)
                return font;
            
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
