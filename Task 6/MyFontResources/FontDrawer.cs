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
            MyFont myFont = new MyFont(font);
            myFont.ToOnePT(0.01f);
            myFont.ToOnePT(ptx);
            int dx = ptx;
            char[] st = s.ToArray();
            for (int i = 0; i < st.Length; i++)
            {
                myFont.DrawSymbol(g, st[i], x + dx * i, y);
            }
        }
    }
}
