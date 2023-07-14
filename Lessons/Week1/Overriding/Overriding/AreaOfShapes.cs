using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding
{
    class AreaOfShapes: AreaOfSquare
    {
        public double Rectangle(double a, double b)
        {
            //return area of rectangle
            return a * b;
        }

        public override double Square(double a, double b)
        {
            //return area of square using different implementation
            return a * b;
        }
    }
}
