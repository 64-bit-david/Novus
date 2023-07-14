using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Names = new List<string>();
            Names.Add("Joe");
            Names.Add("Bob");
            Names.Add("Jack");
            Names.Add("Steve");

            foreach(var name in Names) 
            { 
                Console.WriteLine(name);
            }

            Console.WriteLine("------------------");

            var Numbers = new List<int>{1, 2, 3, 4, 5, 6};
            Numbers.Add(7);
            Numbers.Add(8);
            Numbers.Add(9);
            Numbers.Add(10);
            Numbers.Add(11);
            Numbers.Add(12);

            foreach(var number in Numbers) 
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();

        }
    }
}
