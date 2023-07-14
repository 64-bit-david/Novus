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
    public partial class RectangleForm : Form
    {
        public RectangleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double width, height;

            //Check there are valid values in the textbox
            if (double.TryParse(textBox1.Text, out width) &&
                double.TryParse(textBox2.Text, out height))
            {
                double area = height * width;
                area = Math.Round(area, 2);

                //return output to user
                MessageBox.Show($"The area of the rectangle is:  {area}");
            }
            //if not valid provide error message
            else
            {
                MessageBox.Show("Invalid Input: Please ensure you have given a number value for the height and width.");
            }
        }
    }
}
