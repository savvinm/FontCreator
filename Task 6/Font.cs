using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_6
{
    class Font
    {
        List<Symbol> symbols;
        public Font(int sCount)
        {
            symbols = new List<Symbol>(sCount);
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

        }
    }
}
