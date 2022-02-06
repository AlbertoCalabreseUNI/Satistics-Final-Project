using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project.Objects
{
    class Ball
    {
        public int width { get; set; }
        public int height { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }
        public Brush ballColor { get; set; }
        private Pen borderColor = Pens.Black;
        private PictureBox pictureBox;

        public Ball(int w, int h, int x, int y, int sX, int sY, Brush color, PictureBox pb)
        {
            this.width = w;
            this.height = h;
            this.posX = x;
            this.posY = y;
            this.speedX = sX;
            this.speedY = sY;
            this.ballColor = color;
            this.pictureBox = pb;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(this.ballColor, this.posX, this.posY, this.width, this.height);
            g.DrawEllipse(this.borderColor, this.posX, this.posY, this.width, this.height);
        }

        public void DrawWithText(Graphics g, Font font, String text)
        {
            g.FillEllipse(this.ballColor, this.posX, this.posY, this.width, this.height);
            g.DrawEllipse(this.borderColor, this.posX, this.posY, this.width, this.height);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString($"{text}", font, Brushes.Black, new RectangleF(this.posX, this.posY, this.width, this.height), sf);
            }
        }

        public void Update()
        {
            this.posX += this.speedX;
            this.posY += this.speedY;
            if (this.posX < 0 || this.posX + this.width > this.pictureBox.Width)
                this.speedX = -this.speedX;
            if (this.posY < 0 || this.posY + this.height > this.pictureBox.Height)
                this.speedY = -this.speedY;
        }
    }
}
