using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        long timeSinceBoot;
        const string textFile = "textfile.rtf";

        public Form1()
        {
            InitializeComponent();

            richTextBox1.LoadFile(textFile);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black);

            // 'Happy' Face
            gfx.DrawEllipse(p, 250, 125, 45, 45);
            gfx.DrawEllipse(p, 260, 135, 10, 10);
            gfx.DrawEllipse(p, 275, 135, 10, 10);
            gfx.DrawLine(p, 260, 160, 285, 160);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            label4.Text = String.Format("Mouse at ({0}, {1})", e.X, e.Y);

            pictureBox1.Location = new Point(e.X, e.Y);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            int movement = 10;

            // For some reason this is not actually working. Both the `Point.Add` and `+=`
            // are not actually moving the picture box.
            switch (e.KeyCode)
            {
                case Keys.W:
                    pictureBox1.Location = Point.Add(pictureBox1.Location, new Size(0, -movement));
                    break;
                case Keys.A:
                    pictureBox1.Location += new Size(-movement, 0);
                    break;
                case Keys.S:
                    pictureBox1.Location += new Size(0, movement);
                    break;
                case Keys.D:
                    pictureBox1.Location += new Size(-movement, 0);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem) + " is the One True OS";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "My value is: " + trackBar1.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "Time: " + timeSinceBoot++;

            this.Refresh();
        }

        private void handleNumericUpDowns()
        {
            var result =  numericUpDown1.Value + numericUpDown2.Value;
            label6.Text = String.Format("= {0}", result);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            handleNumericUpDowns();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            handleNumericUpDowns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(textFile);
        }
    }
}
