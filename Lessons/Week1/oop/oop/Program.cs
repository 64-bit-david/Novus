using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            int x = 5;
            int y = 3;
            int sum = 0;

            sum = calc.Add(x, y);
            int resDiv = calc.Divide(x, y);
            int resMult = calc.Multiply(x, y);  
            int resSubtract = calc.Subtract(x, y);

            Console.WriteLine($"Sum of {x} + {y} = {sum}");
            Console.WriteLine($"Sum of {x} / {y} = {resDiv}");
            Console.WriteLine($"S of {x} - {y} = {resSubtract}");
            Console.WriteLine($"Sum of {x} * {y} = {resMult}");

            Console.ReadLine();
        }
    }
}
