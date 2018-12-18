using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_6
{
    class MyFont
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
        public void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (Symbol s in symbols)
                sw.WriteLine(s.ToString());
            sw.Close();
        }
        public void Load(string filename)
        {
            string line = "";
            StreamReader sr = new StreamReader(filename);
            while (true)
            {
                line = sr.ReadLine();
                if (line == "")
                    break;
            }
        }
    }
}
