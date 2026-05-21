using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 500;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen sunPen = new Pen(Color.Yellow, 5);
            g.DrawEllipse(sunPen, 50, 50, 80, 80);

            Pen rayPen = new Pen(Color.Orange, 2);
            g.DrawLine(rayPen, 90, 40, 90, 10);
            g.DrawLine(rayPen, 140, 90, 170, 90);

            Pen housePen = new Pen(Color.Brown, 4);
            g.DrawRectangle(housePen, 150, 250, 200, 150);

            Point[] roofPoints = {
                new Point(140, 250),
                new Point(250, 150),
                new Point(360, 250)
            };
            g.DrawPolygon(new Pen(Color.Red, 5), roofPoints);

            g.DrawLine(new Pen(Color.Green, 3), 0, 400, 600, 400);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
