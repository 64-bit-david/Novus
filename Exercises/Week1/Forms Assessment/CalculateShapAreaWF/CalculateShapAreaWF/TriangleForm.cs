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
    public partial class TriangleForm : Form
    {
        public TriangleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double length1, length2, length3;

            //check we have valid values in all the textboxes
            if (double.TryParse(textBox1.Text, out length1) &&
                double.TryParse(textBox2.Text, out length2) &&
                double.TryParse(textBox3.Text, out length3))
            {
                //All text boxes have values so we can continue with calculation
                double perimeter = length1 + length2 + length3;
                double s = perimeter / 2;


                //This checks if we have a valid input to create a triangle

                //if true ask user to update input
                if (length1 > length2 + length3 || length2 > length1 + length3 || length3 > length1 + length2)
                {
                    MessageBox.Show("Invalid Input: Not a valid triangle! No one side can be greater than" +
                        " the sum of the other two sides. Please change your input");
                }
                //otherwise we can calculate the area and generate a msgbox
                else
                {
                    // area is calculated with heron's formula -> A = √s(s−a)(s−b)(s−c)
                    double area = Math.Sqrt(s * (s - length1) * (s - length2) * (s - length3));
                    area = Math.Round(area, 2);

                    //return output to user
                    MessageBox.Show($"The area of the triangle is:  {area}");
                }
            }
            //Let user know they have given invalid input
            else
            {
                MessageBox.Show("Invalid Input: Please ensure you have given a number value for all 3 sides of the triangle");
            }

        }
    }
}
