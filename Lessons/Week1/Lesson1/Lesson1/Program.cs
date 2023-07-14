using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Size of int: {0}", sizeof(int));
            //Console.WriteLine("Size of long: {0}", sizeof(long));
            //Console.WriteLine("Size of float: {0}", sizeof(float));
            //Console.WriteLine("Size of double: {0}", sizeof(double));
            //Console.WriteLine("Size of decimal: {0}", sizeof(decimal));
            //Console.WriteLine("Size of bool: {0}", sizeof(bool));
            //Console.WriteLine("Size of char: {0}", sizeof(char));
            //Console.WriteLine("Size of byte: {0}", sizeof(byte));
            //Console.ReadLine();



            int firstNumber = 0;
            int secondNumber = 0;
            Console.Write("Enter first number: ");
            firstNumber = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter second number: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            if(firstNumber > secondNumber)
            {
                Console.WriteLine("first number is larger than second number");
            }
            else if(firstNumber < secondNumber)
            {
                Console.WriteLine("First number is smaller than second number");
            }
            else
            {
                Console.WriteLine("Numbers are equal");
            }
            Console.ReadLine();



        }
    }
}
