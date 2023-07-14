using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle();
            Circle circle = new Circle();
            double a = 10;
            double b = 20;
            double c = 1.0;
            double area = 0.0;
            double perimeter = 0;
            rec.height = a; 
            rec.width = b;
            area = rec.Area();
            Console.WriteLine($"Area of a rectangle is: {area:F}");

            perimeter = rec.perimeter();
            Console.WriteLine($"The perimeter of the rectangle is: {perimeter:F}");

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Circle area and perimeter");
            circle.radius = c;
            area = circle.Area();
            Console.WriteLine($"Area of circle is : {area:F}");
            perimeter = circle.perimeter();
            Console.WriteLine($"Perimeter of circle is : {perimeter:F}");


            Console.WriteLine("---------------");
            Console.WriteLine("Area and Perimeter of a triangle");
            double x = 3;
            double y = 4;
            double z = 5;


            Triangle triangle = new Triangle();
            triangle.edge1 = x;
            triangle.edge2 = y;
            triangle.edge3 = z;
            area = triangle.Area();
            perimeter = triangle.perimeter();
            Console.WriteLine($"The area of the triangle is: {area:F}");
            Console.WriteLine($"The perimeter of the triangle is: {perimeter:F}");


            Console.ReadLine();

        }
    }
}
