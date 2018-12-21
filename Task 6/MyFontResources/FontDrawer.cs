using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    class FontDrawer
    {
        public void DrawString(Graphics g, MyFont font, int ptx, string s, float x, float y)
        {
            font.DrawString(g, s, ptx, x, y);
        }
    }
}
