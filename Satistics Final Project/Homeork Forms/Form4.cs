using Satistics_Final_Project.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project.Homeork_Forms
{
    public partial class Form4 : Form
    {
        DataSet DataSet = new DataSet();
        List<Interval<int>> IntervalsX = new List<Interval<int>>();
        List<Interval<int>> IntervalsY = new List<Interval<int>>();

        List<BivariateInterval> IntervalsXY = new List<BivariateInterval>();

        List<String> StopWordsList = new List<String>();
        Dictionary<String, int> WordsInTxT = new Dictionary<String,int>();
        Font font = new Font("Times New Roman", 10.0f);
        public Form4()
        {
            InitializeComponent();
            this.richTextBox2.AllowDrop = true;
            this.richTextBox2.DragDrop += RichTextBox2_DragDrop;
        }
        //Relative Frequency Calculation
        private void button1_Click(object sender, EventArgs e)
        {
            if (DataSet.DataPoints.Count > 0) DataSet.DataPoints.Clear();
            using (var reader = new StreamReader(richTextBox2.Text))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    DataSet.DataPoints.Add(new DataPoint(Double.Parse(values[2]), Double.Parse(values[1])));
                }
            }

            /*
            foreach (DataPoint point in DataSet.DataPoints)
                richTextBox1.AppendText("X: " + point.X + "\tY: " + point.Y + "\n");
            */

            //Intervals for X are MANUALLY coded from 40 to 100 with steps of 10.
            //Intervals for Y are MANUALLY coded from 140 to 200 with steps of 10.
            for (int i = 40; i < 100; i += 10)
                IntervalsX.Add(new Interval<int>(i, i + 10));
            for (int i = 140; i < 200; i += 10)
                IntervalsY.Add(new Interval<int>(i, i + 10));

            //Bivariate Intervals are all the possible interval cases
            for (int i = 40; i < 100; i += 10)
                for (int j = 140; j < 200; j += 10)
                    IntervalsXY.Add(new BivariateInterval(i, i + 10, j, j + 10));

            richTextBox1.AppendText("Mean of X: " + DataSet.MeanOfDataSet(0) + "\n");
            richTextBox1.AppendText("Mean of Y: " + DataSet.MeanOfDataSet(1) + "\n");

            foreach (Interval<int> interval in IntervalsX)
                foreach (DataPoint point in DataSet.DataPoints)
                    if (interval.ContainsValue(Convert.ToInt32(point.X)))
                        interval.Count += 1;

            foreach (Interval<int> interval in IntervalsY)
                foreach (DataPoint point in DataSet.DataPoints)
                    if (interval.ContainsValue(Convert.ToInt32(point.Y)))
                        interval.Count += 1;
            
            foreach (DataPoint point in DataSet.DataPoints)
                foreach (BivariateInterval interval in IntervalsXY)
                    if (interval.ContainsValue(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)))
                        interval.Count += 1;

            richTextBox1.AppendText("X Interval\tFrequency\n");
            foreach(Interval<int> interval in IntervalsX)
            {
                richTextBox1.AppendText(interval.Minimum + "-" + interval.Maximum + ":\t" + Utils.ComputeRelativeFrequency(interval.Count, DataSet.DataPoints.Count) +"\n");
            }

            richTextBox1.AppendText("Y Interval\tFrequency\n");
            foreach (Interval<int> interval in IntervalsY)
            {
                richTextBox1.AppendText(interval.Minimum + "-" + interval.Maximum + ":\t" + Utils.ComputeRelativeFrequency(interval.Count, DataSet.DataPoints.Count) + "\n");
            }

            richTextBox1.AppendText("Bivariate Interval\tFrequency\n");
            foreach(BivariateInterval interval in IntervalsXY)
            {
                richTextBox1.AppendText(interval.MinX + "-" + interval.MaxX + " && " + interval.MinY + "-" + interval.MaxY + ":\t" + Utils.ComputeRelativeFrequency(interval.Count, DataSet.DataPoints.Count) + "\n");
            }


            richTextBox1.AppendText("X Standard Deviation: \t" + Utils.ComputeStandardDeviation(DataSet.GetAllXs()) + "\n");
            richTextBox1.AppendText("Y Standard Deviation: \t" + Utils.ComputeStandardDeviation(DataSet.GetAllYs()) + "\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(@".\Objects\Homework3\stopwords.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    StopWordsList.Add(line);
                    //DataSet.DataPoints.Add(new DataPoint(Double.Parse(values[2]), Double.Parse(values[1])));
                }
            }

            using (var reader = new StreamReader(@".\Objects\Homework3\itrecani.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(' ');
                    foreach (String word in values)
                    {
                        if (StopWordsList.Contains(word)) continue;
                        if (!WordsInTxT.ContainsKey(word)) WordsInTxT.Add(word, 1);
                        else WordsInTxT[word] += 1;


                    }
                    //DataSet.DataPoints.Add(new DataPoint(Double.Parse(values[2]), Double.Parse(values[1])));
                }
            }

            //Now that we've loaded all the words, let's draw the first five most common words
            int NUM_OF_WORDS = 5;
            //Let's sort the SortedDictionary by value
            var MostCommonWords = (from kvp in WordsInTxT orderby kvp.Value descending select kvp).Take(NUM_OF_WORDS).ToArray();

            //Let's draw the balls
            Graphics G = this.pictureBox1.CreateGraphics();
            for(int i = 0; i < NUM_OF_WORDS; i++)
            {
                Ball ball = new Ball(50 + MostCommonWords[i].Value, 50 + MostCommonWords[i].Value, 0, i * 90, 0, 0, Brushes.Green, this.pictureBox1);
                ball.DrawWithText(G, font, MostCommonWords[i].Key + ": " + MostCommonWords[i].Value);
            }

        }


        private void RichTextBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string s = "";

            foreach (string File in FileList)
                s = s + " " + File;

            richTextBox2.Text = s;
        }
    }
}
