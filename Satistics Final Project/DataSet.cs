using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project
{
    class DataSet
    {
        public List<DataPoint> DataPoints;
        public DataSet()
        {
            this.DataPoints = new List<DataPoint>();
        }
        public DataSet(List<DataPoint> Points)
        {
            this.DataPoints = Points;
        }

        public List<double> GetAllXs()
        {
            List<double> AllXs = new List<double>();
            foreach (DataPoint point in this.DataPoints)
                AllXs.Add(point.X);
            return AllXs;
        }
        public List<double> GetAllYs()
        {
            List<double> AllYs = new List<double>();
            foreach (DataPoint point in this.DataPoints)
                AllYs.Add(point.Y);
            return AllYs;
        }

        //X = 0, Y = 1
        public double MeanOfDataSet(int Variable = 0)
        {
            if(Variable == 0)
                return Utils.ComputeOfflineMean(this.GetAllXs());
            return Utils.ComputeOfflineMean(this.GetAllYs());
        }
    }
}
