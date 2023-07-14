using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Triangle
    {
        public double edge1 { get; set; }
        public double edge2 { get; set; }
        public double edge3 { get; set; }

        public double Area()
        {
            double s = (edge1 + edge2 + edge3) / 2;  
            return Math.Sqrt(s * (s - edge1) * (s - edge2) * (s- edge3));
        }

        public double perimeter()
        {
            return edge1 + edge2 + edge3;   
        }
    }
}
