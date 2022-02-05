using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satistics_Final_Project.Objects.Homework2
{
    class Student
    {
        public int Gender { get; set; }
        public List<int> Grades;
        public Student(int Gender, List<int> Grades)
        {
            this.Gender = Gender;
            this.Grades = Grades;
        }

        public double ComputeAverageGrade()
        {
            return Utils.ComputeOfflineMean(this.Grades);
        }
    }
}
