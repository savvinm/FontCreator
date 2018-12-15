using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Task_6
{
    public partial class MainForm : Form
    {
        List<PointF> points;
        WorkSpace workSpace;
        Point last;
        public MainForm()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null, WorkPanel, new object[] { true });
            points = new List<PointF>();
            workSpace = new WorkSpace(WorkPanel.Width, WorkPanel.Height, 'A');
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }
        private void Draw(Graphics g)
        {
            /*foreach (PointF p in points)
                g.DrawEllipse(Pens.Black, p.X, p.Y, 2, 2);
            if (points.Count == 4)
            {
                Bezie b = new Bezie(points[0], points[1], points[2], points[3]);
                b.Draw(g);
            }*/
            workSpace.DrawAll(g);
            g.Dispose();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (workSpace.SearchPoint(e.Location) != -1)
            {
                workSpace.currpoints.Add(e.Location);
            }
            workSpace.AddPoint(e.Location);
            //points.Add(e.Location);
            Invalidate();*/
        }

        private void AddLineButton_Click(object sender, EventArgs e)
        {
            workSpace.AddILine();
            WorkPanel.Invalidate();
        }

        private void WorkPanel_Paint(object sender, PaintEventArgs e)
        {
            // Draw(e.Graphics);
            Bitmap bmp = new Bitmap(WorkPanel.Width, WorkPanel.Height);
            Graphics g = Graphics.FromImage(bmp);
            workSpace.DrawAll(g);
            e.Graphics.DrawImage(bmp, 0, 0);
            g.Dispose();
            bmp.Dispose();
        }

        private void WorkPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                last = e.Location;
            }
            workSpace.PointIn(e.Location);
            /*if (workSpace.SearchPoint(e.Location) != -1)
            {
                workSpace.currpoints.Add(e.Location);
            }
            workSpace.AddPoint(e.Location);*/
            //points.Add(e.Location);
            WorkPanel.Invalidate();
        }

        private void AddCurveButton_Click(object sender, EventArgs e)
        {
            workSpace.AddILine();
            WorkPanel.Invalidate();
        }

        private void WorkPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !last.IsEmpty)
            {
                float dx = e.Location.X - last.X;
                float dy = e.Location.Y - last.Y;
                workSpace.UpdatePoint(e.Location, dx, dy);
                WorkPanel.Invalidate();
                last = e.Location;
            }
            last = e.Location;
        }

        private void WorkPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = new Point();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            workSpace.DeletePoints();
            WorkPanel.Invalidate();
        }
    }
}
