using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTestProject;

namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Triangle triangle = new Triangle();
            Rectangle rectangle = new Rectangle();  

            Console.WriteLine(circle.Area(5.0));
            Console.WriteLine(circle.Perimeter(5.0));
            Console.WriteLine(triangle.Perimeter(5.0, 5.0, 5.0));
            Console.WriteLine(triangle.Area(5.0, 5.0, 5.0));
            Console.WriteLine(rectangle.Perimeter(5.0, 10.0));
            Console.WriteLine(rectangle.Area(5.0, 10.0));







            Console.ReadLine();

        }
    }
}
