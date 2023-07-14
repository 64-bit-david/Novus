using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateShapAreaWF
{
    public partial class CircleForm : Form
    {
        public CircleForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double radius;

            //check we have an input and it is a number
            if (double.TryParse(textBox1.Text, out radius))
            {
                //calculate area of circle using πR2
                double circleArea = Math.PI * radius * radius;
                circleArea = Math.Round(circleArea, 2);

                string output = $"The area of the circle is {circleArea}";

                //return output to user
                MessageBox.Show(output);
            }
            else
            //provide error message if input not valid
            {
                MessageBox.Show("Invalid input: Please ensure you have entered a number for the radius");
            }

        }
    }
}
