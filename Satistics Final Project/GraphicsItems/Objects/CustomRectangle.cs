using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project.GraphicsItems.Objects
{
    class CustomRectangle
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public Viewport Viewport;

        public CustomRectangle(float X, float Y, float Width, float Height, Viewport Viewport)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Viewport = Viewport;
        }

        public void Draw()
        {

        }
    }
}
