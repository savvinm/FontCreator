using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6
{
    public class ScreenConverter
    {
        private double xr, yr, wr, hr;
        private int ws, hs;

        //public Size Size { get { return size; } set { size = value; } }
        //public RectangleF Rectangle { get { return rectangle; } set { rectangle = value; } }
        public int SWidth
        {
            get { return ws; }
            set { ws = value; }
        }
        public int SHeight
        {
            get { return hs; }
            set { hs = value; }
        }
        public double RWidth
        {
            get { return wr; }
            set { wr = value; }
        }
        public double RHeight
        {
            get { return hr; }
            set { hr = value; }
        }
        public double RX
        {
            get { return xr; }
            set { xr = value; }
        }
        public double RY
        {
            get { return yr; }
            set { yr = value; }
        }
        public ScreenConverter(double xr, double yr, double wr, double hr, int ws, int hs)
        {
            this.xr = xr;
            this.yr = yr;
            this.wr = wr;
            this.hr = hr;
            this.ws = ws;
            this.hs = hs;
        }
        public int HS()
        {
            return hs;
        }
        public int WS()
        {
            return ws;
        }
        public int II(double x)
        {
            return (int)((x - xr) * ws / wr);
        }

        public int JJ(double y)
        {
            return (int)(hs - (y - yr) * hs / hr);
        }

        public double XX(int I)
        {
            return wr * I / ws + xr;
        }

        public double YY(int J)
        {
            return hr * (hs - J) / hs + yr;
        }
        public int LS(int lr)
        {
            return (int)Math.Round(((lr / hr) * hs));
        }
        public double LR(float ls)
        {
            return ls / hs * hr;
        }

        public double DistX(int I)
        {
            return I * wr / ws;
        }

        public double DistY(int J)
        {
            return -J * hr / hs;
        }
    }
}
