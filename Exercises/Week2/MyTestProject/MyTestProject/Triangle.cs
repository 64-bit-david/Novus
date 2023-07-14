using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject
{
     /*
        A Class for calculating the area and perimeter of a triangle
     */
    public class Triangle
    {

        /*
         A method for calculating the Area
        */
        public double Area(double length1, double length2, double length3)
        {

            


            //Calculate Perimeter using Triangle class Perimeter method
            double perimeter = Perimeter(length1, length2, length3);

            //if one side of the triangle is longer than sum of the other two sides, not valid so throw arg. exception
            if (length1 > length2 + length3 || length2 > length1 + length3 || length3 > length1 + length2)
            {
                throw new ArgumentException("Invalid input. The sum of any two sides of a triangle must be greater than the third side.");

            }

            // area is calculated with heron's formula -> Area = √s(s−side1)(s−side2)(s−side3), where s = perimeter/2

            double s = perimeter / 2;

            double area = Math.Sqrt(s * (s - length1) * (s - length2) * (s - length3));
            area = Math.Round(area, 2);
            return area;
        }

        /*
        A method for calculating the Perimeter
       */
        public double Perimeter(double length1, double length2, double length3)
        {

            
            // perimeter of a triangle is simple all the sides added together
            double perimeter = length1 + length2 + length3;
            perimeter = Math.Round(perimeter, 2); 
            return perimeter;    
        }



       

    }
}
