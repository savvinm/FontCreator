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
    public partial class DrawingForm : Form
    {
        MainForm mainForm;
        FontDrawer fontDrawer;
        bool draw;
        ScreenConverter sc;
        public DrawingForm(MainForm f)
        {
            InitializeComponent();
            mainForm = f;
            fontDrawer = new FontDrawer();
            draw = false;
            sc = new ScreenConverter(0, 0, 1, 1, Width, Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw = true;
            Invalidate();
        }

        private void DrawingForm_Paint(object sender, PaintEventArgs e)
        {
            if (draw)
                fontDrawer.DrawString(e.Graphics, mainForm.workSpace.font, (int)(numericUpDown1.Value), textBox1.Text, 100, 100);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
