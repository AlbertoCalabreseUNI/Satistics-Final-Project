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
    }
}
