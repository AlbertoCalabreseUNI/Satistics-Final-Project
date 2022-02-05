using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project
{
    class RandomNumbersGenerator
    {
        static Random Random = new Random();

        #region HOMEWORK_2
        //This function generates a List of Random Grades. Used in Homework 2.
        public static List<int> GenerateRandomGrades(int NumberOfGradesToGenerate)
        {
            List<int> GeneratedNumbers = new List<int>();
            for(int i = 0; i < NumberOfGradesToGenerate; i++)
            {
                GeneratedNumbers.Add(Random.Next(18,31));
            }
            return GeneratedNumbers;
        }
        //Same function as the one above this, but it just generates one grade. Used in Homework 2.
        public static int GenerateRandomGrade()
        {
            return Random.Next(18, 31);
        }

        //This generates either 0 or 1. Used in Homework 2.
        public static int GenerateRandomGender()
        {
            return Random.Next(2);
        }
        #endregion

    }
}
