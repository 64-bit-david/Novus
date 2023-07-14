using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject
{
     /*
        A Class for calculating the area and perimeter of a Rectangle
     */
    public class Rectangle
    {


        /*
         A method for calculating the Area
        */
        public double Area(double side1, double side2)
        {

            double rectangleArea =  side1 * side2;
            rectangleArea = Math.Round(rectangleArea, 2);
            return rectangleArea;
        }

        /*
        A method for calculating the Perimeter
       */
        public double Perimeter(double side1, double  side2)
        {
            double rectanglePerimeter = 2 * side1 + 2* side2;
            rectanglePerimeter = Math.Round(rectanglePerimeter, 2);

            return rectanglePerimeter;
        }
    }
}
