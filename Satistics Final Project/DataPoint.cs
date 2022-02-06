using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project
{
    class DataPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public DataPoint(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
