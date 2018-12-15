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
        void Draw(Graphics g, bool allix);
        string ToString();
        bool Check();
    }
}
