using Satistics_Final_Project.Homeork_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satistics_Final_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Homework1Form = new Form2();
            Homework1Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Homework2Form = new Form3();
            Homework2Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Homework3Form = new Form4();
            Homework3Form.Show();
        }
    }
}
