using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project
{
    class BivariateInterval
    {
        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }
        public int Count { get; set; }

        public BivariateInterval(double MinX, double MaxX, double MinY, double MaxY)
        {
            this.MinX = MinX;
            this.MaxX = MaxX;
            this.MinY = MinY;
            this.MaxY = MaxY;

            this.Count = 0;
        }

        public bool ContainsValue(int X, int Y)
        {
            return (X >= this.MinX && X < this.MaxX) && (Y >= this.MinY && Y < this.MaxY);
        }
    }
}
