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
        public WorkSpace workSpace;
        Point last;
        List<List<object>> list;
        public MainForm()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null, WorkPanel, new object[] { true });
            workSpace = new WorkSpace(WorkPanel.Width, WorkPanel.Height);
            list = new List<List<object>>();
        }
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            workSpace.AddILine();
            WorkPanel.Invalidate();
        }

        private void WorkPanel_Paint(object sender, PaintEventArgs e)
        {
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

        private void AddSymbolButton_Click(object sender, EventArgs e)
        {
            SYmbolList.Items.Add("Symbol " + SymbolTextBox.Text[0]);
            workSpace.AddSymbol(SymbolTextBox.Text[0]);
            list.Add(new List<object>());
            //ContourList.Items.Clear();
            List<object> ob = new List<object>();
           /* foreach (object o in ContourList.Items)
               ob.Add(o);
            list[SYmbolList.SelectedIndex] = s;
            foreach (string s in list.Last())
                ContourList.Items.Add(s);*/
        }

        private void AddContourButton_Click(object sender, EventArgs e)
        {
            ContourList.Items.Add("Contour " + (ContourList.Items.Count + 1));
            list[SYmbolList.SelectedIndex].Add("Contour " + (ContourList.Items.Count));
            workSpace.AddContour();
        }

        private void ContourList_SelectedIndexChanged(object sender, EventArgs e)
        {
            workSpace.ChooseContour(ContourList.SelectedIndex);
            WorkPanel.Invalidate();
        }
        private void LoadSymbolList()
        {
            SYmbolList.Items.Clear();
        }
        private void SYmbolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            workSpace.ChooseSymbol(SYmbolList.SelectedIndex);
            LoadContourList(SYmbolList.SelectedIndex);
            ContourList.ClearSelected();
            workSpace.ChooseContour(-1);
            WorkPanel.Invalidate(); 
        }
        private void LoadContourList(int n)
        {
            if (n != -1)
            {
                /*ContourList.Items.Clear();
                foreach (object ob in list[n])
                    ContourList.Items.Add(ob);*/
                ContourList.Items.Clear();
                foreach (object ob in workSpace.ContourList(n))
                    ContourList.Items.Add(ob);
            }
        }

        private void AllixCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            workSpace.CheckAllix(AllixCheckBox.Checked);
            WorkPanel.Invalidate();
        }

        private void AllSymbolCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            workSpace.CheckAllSymbol(AllSymbolCheckBox.Checked);
            WorkPanel.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workSpace = new WorkSpace(WorkPanel.Width, WorkPanel.Height);
            list.Clear();
            SYmbolList.Items.Clear();
            ContourList.Items.Clear();
            WorkPanel.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawingForm f2 = new DrawingForm(this);
            f2.Show();
        }

        private void saveFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                workSpace.SaveFont(saveFileDialog1.FileName);
        }

        private void loadFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<object> l = new List<object>();
                int n = 0;
                workSpace.LoadFont(openFileDialog1.FileName);
                SYmbolList.Items.Clear();
                l = workSpace.SymbolList();
                foreach (object o in l)
                {
                    list.Add(new List<object>());
                    SYmbolList.Items.Add(o);
                }
                for (int i = 0; i < SYmbolList.Items.Count; i++)
                {
                    LoadContourList(i);
                }
                /*List<object> li = new List<object>();
                foreach (object o in l)
                {
                    list[n] = new List<object>();
                    li = workSpace.ContourList(n);
                    foreach (object ob in li)
                        list[n].Add(ob);
                    n++;
                }*/
            }
            Invalidate();
        }
    }
}
