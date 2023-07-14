using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{

    /*
     A Class for calculating the area and perimeter of a circle
    */
    class Circle
       
    {

        /*
         A method for calculating the Area
        */
        public double Area(double radius)
        {
           
            double circleArea = Math.PI * radius * radius;
            circleArea = Math.Round(circleArea, 2);
            return circleArea;
        }

        /*
        A method for calculating the Perimeter
       */
        public double Perimeter(double radius)
        {
            double circlePerimeter = 2 * Math.PI * radius;
            circlePerimeter = Math.Round(circlePerimeter, 2);

            return circlePerimeter;
        }

    }
}
