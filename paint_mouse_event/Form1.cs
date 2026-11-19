using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace paint_mouse_event
{
    public partial class Form1 : Form
    {
        Graphics g;     // зурах цаас
        Pen p;          // үзэг
        Pen eraser;     // баллуур
        bool draw;      // хулганы товч дарагдсан эсэх
        bool isErasing; // арилгаж байгаа эсэх
        int x, y;       // өмнөх цэгийн координат

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Paint - Зурах програм";
            g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            p = new Pen(Color.Black, 2);
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;

            eraser = new Pen(this.BackColor, 15);
            eraser.StartCap = LineCap.Round;
            eraser.EndCap = LineCap.Round;

            draw = false;
            isErasing = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                isErasing = false;
                x = e.X;
                y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                draw = true;
                isErasing = true;
                x = e.X;
                y = e.Y;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"Paint - Координат: ({e.X}, {e.Y}) | Өнгө: {p.Color.Name}";
            if (draw)
            {
                Pen activePen = isErasing ? eraser : p;
                g.DrawLine(activePen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            isErasing = false;
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            p.Width = (float)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p?.Dispose();
            eraser?.Dispose();
            g?.Dispose();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }
        private void label1_Click(object sender, EventArgs e) { }
    }
}