using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6
{
    public partial class MainForm : Form
    {
        List<PointF> points;
        public MainForm()
        {
            InitializeComponent();
            points = new List<PointF>();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }
        private void Draw(Graphics g)
        {
            foreach (PointF p in points)
                g.DrawEllipse(Pens.Black, p.X, p.Y, 2, 2);
            if (points.Count == 4)
            {
                Bezie b = new Bezie(points[0], points[1], points[2], points[3]);
                b.Draw(g);
            }
            g.Dispose();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            Invalidate();
        }
    }
}
