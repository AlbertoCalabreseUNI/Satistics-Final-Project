using Satistics_Final_Project.GraphicsItems.Objects;
using Satistics_Final_Project.Objects.Homework2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project.Homeork_Forms
{
    public partial class Form3 : Form
    {
        public int StudentsToGenerate = 0;
        public int NumberOfGradesToGenerate = 20;
        List<Student> Students = new List<Student>();
        List<Viewport> viewports;
        public Form3()
        {
            InitializeComponent();
            this.viewports = new List<Viewport>();
            
            this.trackBar1.ValueChanged += TrackBar1_ValueChanged;
            //Creating functions to move/resize viewports
            this.pictureBox1.MouseDown += this.PictureBox1_MouseDown;
            this.pictureBox1.MouseUp += this.PictureBox1_MouseUp;
            this.pictureBox1.MouseMove += this.PictureBox1_MouseMove;

            this.StudentsToGenerate = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Students.Count > 0) Students.Clear();
            for (int i = 0; i < StudentsToGenerate; i++)
            {
                int Gender = RandomNumbersGenerator.GenerateRandomGender();
                List<int> Grades = RandomNumbersGenerator.GenerateRandomGrades(NumberOfGradesToGenerate);
                Students.Add(new Student(Gender, Grades));
            }
            this.viewports.Add(new Viewport(this.pictureBox1));
            this.viewports.ForEach(x => x.Draw());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RadomGrade = RandomNumbersGenerator.GenerateRandomGrade();
            double CurrentMean = RadomGrade;
            this.richTextBox1.AppendText("Random Grade Generated: " + RadomGrade + "\n");
            this.richTextBox1.AppendText("Current Mean is: " + CurrentMean + "\n");
            for (int i = 1; i < NumberOfGradesToGenerate; i++)
            {
                RadomGrade = RandomNumbersGenerator.GenerateRandomGrade();
                CurrentMean = Utils.ComputeOnlineMean(CurrentMean, RadomGrade, i);
                this.richTextBox1.AppendText("Random Grade Generated: " + RadomGrade + "\n");
                this.richTextBox1.AppendText("Current Mean is: " + CurrentMean + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            List<double> AverageOfEachStudent = new List<double>();
            foreach(Student student in Students)
                AverageOfEachStudent.Add(student.ComputeAverageGrade());
            richTextBox2.AppendText("The average grade is: " + Utils.ComputeOfflineMean(AverageOfEachStudent) + "\n");

            //Let's initialize the dictionary containing all grades
            SortedDictionary<int, int> GradesDictionary = new SortedDictionary<int, int>();
            for(int i = 18; i < 31; i++)
                GradesDictionary.Add(i, 0);

            foreach(Student student in Students)
                foreach(int grade in student.Grades)
                    if (GradesDictionary.ContainsKey(grade))
                        GradesDictionary[grade] += 1;
            richTextBox2.AppendText("Grade\tCount\tFreq\tPerc" + "\n");
            foreach (int grade in GradesDictionary.Keys)
                richTextBox2.AppendText(grade + "\t" + GradesDictionary[grade] + "\t" + (GradesDictionary[grade] * 1.0) / (NumberOfGradesToGenerate * Students.Count) + "\t" + ((GradesDictionary[grade] * 1.0) / (NumberOfGradesToGenerate * Students.Count)) * 100 + "%\n");
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.StudentsToGenerate = this.trackBar1.Value;
        }

        #region Viewport Controller
        //We handle picturebox mouse in Form1 as it makes more sense since it's an instanced object inside the Form1 instance.
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Viewport vp in this.viewports)
            {
                if (vp.Area.Contains(e.Location))
                {
                    vp.AreaOnMouseDown = vp.Area; //We temporary save the original area
                    vp.MouseClickLocation = e.Location;

                    if (e.Button == MouseButtons.Left) vp.dragMode = true;
                    else if (e.Button == MouseButtons.Right) vp.resizeMode = true;
                }
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Viewport vp in this.viewports)
            {
                vp.dragMode = false;
                vp.resizeMode = false;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Viewport vp in this.viewports)
            {
                //We calculate how much to move the viewport
                int deltaX = e.X - vp.MouseClickLocation.X;
                int deltaY = e.Y - vp.MouseClickLocation.Y;

                if (vp.dragMode)
                    vp.MoveArea(deltaX, deltaY);
                else if (vp.resizeMode)
                    vp.ResizeArea(deltaX, deltaY);
            }
        }

        #endregion
    }
}

