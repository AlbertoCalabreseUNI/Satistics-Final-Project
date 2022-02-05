using Satistics_Final_Project.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project
{
    public partial class Form2 : Form
    {
        List<Ball> BallsToAnimate = new List<Ball>();
        Random random = new Random();
        Graphics G;
        public Form2()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            this.UpdateStyles();

            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

            this.G = this.pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "Hello!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < this.trackBar1.Value; i++)
            {
                //Let's create random sized balls. w = h for the constructor.
                var w = random.Next(20, 200);
                var x = random.Next(0, this.pictureBox1.Width / 2);
                var y = random.Next(0, this.pictureBox1.Height / 2);
                var sX = random.Next(1, 10);
                var sY = random.Next(1, 10);
                var RandomColor = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));

                BallsToAnimate.Add(new Ball(w, w, x, y, sX, sY, RandomColor, this.pictureBox1));

                this.timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Ball ball in BallsToAnimate)
            {
                ball.Update();
                ball.Draw(g);
            }
        }
    }
}
