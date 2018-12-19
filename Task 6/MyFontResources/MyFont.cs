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
        public void ToOnePT(float coef)
        {
            foreach (Symbol s in symbols)
                s.ToOnePT(coef);
        }
        public void DrawSymbol(Graphics g, char c, float x, float y)
        {
            foreach(Symbol s in symbols)
            {
                if (s.symbol == c)
                    s.Draw(g, x, y);
            }
        }
        public void DrawSymbol(Graphics g, char c)
        {
            foreach (Symbol s in symbols)
            {
                if (s.symbol == c)
                    s.Draw(g);
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
