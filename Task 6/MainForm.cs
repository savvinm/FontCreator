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
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            Invalidate();
        }
    }
}
