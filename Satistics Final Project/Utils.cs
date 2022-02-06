using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project
{
    class Utils
    {
        #region MEAN_ALGORITHMS
        public static double ComputeOfflineMean(List<double> Data)
        {
            //We initialize the mean as the first value of the list of doubles
            double mean = Data[0];
            double sum = 0;
            
            foreach(double d in Data)
                sum += d;
            
            mean = sum / Data.Count;
            return mean;
        }

        public static double ComputeOfflineMean(List<int> Data)
        {
            //We initialize the mean as the first value of the list of ints
            double mean = Data[0] * 1.0;
            double sum = 0;

            foreach (double d in Data)
                sum += d;

            mean = sum / Data.Count;
            return mean;
        }

        public static double ComputeOnlineMean(double PreviousMean, double NextValue, double n)
        {
            double mean = PreviousMean + ((1.0d / n) * (NextValue - PreviousMean));
            return mean;
        }
        #endregion



        #region FREQUENCY STANDARD_DEVIATION AND VARIANCE
        public static double ComputeRelativeFrequency(double Count, double Total)
        {
            return Count / Total;
        }

        public static double ComputeVariance(List<double> Points)
        {
            double temp = 0;
            double Mean = ComputeOfflineMean(Points);
            foreach (double value in Points)
                temp += (value - Mean) * (value - Mean);
            double Variance = (1.0/Points.Count) * temp;

            return Variance;
        }

        public static double ComputeStandardDeviation(List<double> Points)
        {
            return Math.Sqrt(ComputeVariance(Points));
        }

        #endregion

        #region GET_MIN AND GET_MAX
        public static double GetMin(List<double> DataSet)
        {
            double min = DataSet[0];
            foreach(double value in DataSet)
                if (value < min) min = value;

            return min;
        }

        public static double GetMax(List<double> DataSet)
        {
            double max = DataSet[0];
            foreach (double value in DataSet)
                if (value > max) max = value;

            return max;
        }
        #endregion
    }
}
