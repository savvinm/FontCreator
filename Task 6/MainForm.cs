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
        ScreenConverter con;
        ILIneFactory factory;
        ILIneFactory fact;
        double delta = 0.2;
        public MainForm()
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null, WorkPanel, new object[] { true });
            workSpace = new WorkSpace(WorkPanel.Width, WorkPanel.Height);
            con = new ScreenConverter(0, 0, 1, 1, WorkPanel.Width, WorkPanel.Height);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            LineRadioButton.Tag = new LineFactory();
            BezieRadioButton.Tag = new BezieFactory();
            factory = new LineFactory();
            fact = new LineFactory();
        }
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                con.RX += delta;
                con.RY += delta;
                con.RWidth -= delta *2;
                con.RHeight -= delta * 2;

            }
            else
            {
                con.RX -= delta;
                con.RY -= delta;
                con.RWidth += delta *2;
                con.RHeight += delta * 2;
            }
            WorkPanel.Invalidate();
        }
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            //workSpace.AddLine();
            WorkPanel.Invalidate();
        }

        private void WorkPanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(WorkPanel.Width, WorkPanel.Height);
            Graphics g = Graphics.FromImage(bmp);
            workSpace.DrawAll(g, con);
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
            workSpace.PointIn(e.Location, factory, fact, con);
            WorkPanel.Invalidate();
        }

        private void AddCurveButton_Click(object sender, EventArgs e)
        {
            //workSpace.AddCurve();
            WorkPanel.Invalidate();
        }

        private void WorkPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !last.IsEmpty)
            {
                float dx = e.Location.X - last.X;
                float dy = e.Location.Y - last.Y;
                workSpace.UpdatePoint(dx, dy,con);
                WorkPanel.Invalidate();
                last = e.Location;
            }
            last = e.Location;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Focus();
            if (e.KeyData == Keys.W)
                con.RY -= con.RHeight / 50;
            if (e.KeyData == Keys.S)
                con.RY += con.RHeight / 50;
            if (e.KeyData == Keys.A)
                con.RX -= con.RWidth / 50;
            if (e.KeyData == Keys.D)
                con.RX += con.RWidth / 50;
            WorkPanel.Invalidate();
        }
        private void WorkPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = new Point();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            workSpace.DeletePoints(factory, fact);
            WorkPanel.Invalidate();
        }

        private void AddSymbolButton_Click(object sender, EventArgs e)
        {
            if (SymbolTextBox.Text != "" && SymbolTextBox.Text != " ")
            {
                workSpace.AddSymbol(SymbolTextBox.Text[0]);
                LoadSymbolList();
                SymbolTextBox.Clear();
            }
        }

        private void AddContourButton_Click(object sender, EventArgs e)
        {
            if (SYmbolList.SelectedIndex != -1)
            {
                workSpace.AddContour();
                LoadContourList(SYmbolList.SelectedIndex);
            }
        }

        private void ContourList_SelectedIndexChanged(object sender, EventArgs e)
        {
            workSpace.ChooseContour(ContourList.SelectedIndex);
            WorkPanel.Invalidate();
        }
        private void SYmbolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            workSpace.ChooseSymbol(SYmbolList.SelectedIndex);
            LoadContourList(SYmbolList.SelectedIndex);
            ContourList.ClearSelected();
            workSpace.ChooseContour(-1);
            WorkPanel.Invalidate(); 
        }
        private void LoadSymbolList()
        {
            SYmbolList.Items.Clear();
            foreach (object ob in workSpace.SymbolList())
                SYmbolList.Items.Add(ob);
        }
        private void LoadContourList(int n)
        {
            if (n != -1)
            {
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
                workSpace.LoadFont(openFileDialog1.FileName);
                SYmbolList.Items.Clear();
                LoadSymbolList();
                SYmbolList.SelectedIndex = -1;
                ContourList.Items.Clear();
            }
            Invalidate();
        }

        private void CoordTextBox_CheckedChanged(object sender, EventArgs e)
        {
            workSpace.CheckCoord(CoordTextBox.Checked);
            WorkPanel.Invalidate();
        }

        private void DeleteSymbolButton_Click(object sender, EventArgs e)
        {
            if (SYmbolList.SelectedIndex != -1)
            {
                workSpace.DeleteSymbol(SYmbolList.SelectedIndex);
                LoadSymbolList();
                ContourList.Items.Clear();
                SYmbolList.SelectedIndex = -1;
            }
            Invalidate();
        }

        private void DeleteContourButton_Click(object sender, EventArgs e)
        {
            if (ContourList.SelectedIndex != -1)
            {
                workSpace.DeleteContour(ContourList.SelectedIndex);
                ContourList.SelectedIndex = -1;
                LoadContourList(SYmbolList.SelectedIndex);
            }
            Invalidate();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                factory = (ILIneFactory)(sender as RadioButton).Tag;
            Invalidate();
        }
        private void LastRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LastLineRadioButton.Checked)
                fact = new LineFactory();
            if (LastBezierRadioButton.Checked)
                fact = new BezieFactory();
            workSpace.CloseContour(fact);
            WorkPanel.Invalidate();
        }

        private void CloseContourButton_Click(object sender, EventArgs e)
        {
            workSpace.CloseContour(fact);
            WorkPanel.Invalidate();
        }
    }
}
