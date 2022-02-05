using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project.GraphicsItems.Objects
{
    class Viewport
    {
        //Booleans to decide which operation to do
        public bool dragMode;
        public bool resizeMode;

        //This gets set ONLY when we click on the viewport instance. It's used to calculate deltas
        public Point MouseClickLocation { get; set; }
        //Temporary rectangle used for dragMode
        public Rectangle AreaOnMouseDown { get; set; }


        public PictureBox PictureBox;
        public Rectangle Area;
        Graphics G;
        public Viewport(PictureBox PictureBox)
        {
            this.PictureBox = PictureBox;
            this.G = this.PictureBox.CreateGraphics();

            this.Area = new Rectangle(0, 0, this.PictureBox.Width / 2, this.PictureBox.Height / 2);

            this.dragMode = false;
            this.resizeMode = false;
        }

        public void Draw()
        {
            this.G.Clear(Color.White);
            this.G.DrawRectangle(Pens.Black, this.Area.X, this.Area.Y, this.Area.Width, this.Area.Height);
        }

        #region Viewport Move/Resize Region
        public void MoveArea(int DeltaX, int DeltaY)
        {
            //Let's avoid null pointer exceptions
            if (this.AreaOnMouseDown == null) return;
            this.Area = new Rectangle(this.AreaOnMouseDown.X + DeltaX, this.AreaOnMouseDown.Y + DeltaY, this.AreaOnMouseDown.Width, this.AreaOnMouseDown.Height);

            //Let's redraw everything after moving the viewport
            this.Draw();
        }

        public void ResizeArea(int DeltaX, int DeltaY)
        {
            if (this.AreaOnMouseDown == null) return;
            this.Area = new Rectangle(this.AreaOnMouseDown.X, this.AreaOnMouseDown.Y, this.AreaOnMouseDown.Width + DeltaX, this.AreaOnMouseDown.Height + DeltaY);

            this.Draw();
        }
        #endregion
    }
}
