﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionblock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 4;
            int sum = 0;

            sum = Add(a, b);

            Console.WriteLine($"Sum is: {sum}");

            int squared_a = Squared(a);
            Console.WriteLine($"The number {a} squareed is {squared_a}");
            Console.ReadLine();



        }


        public static int Add(int a, int b) 
        {
            return a + b;
        }


        public static int Squared(int a)
        {
            return a * a;
        }
    }
}
