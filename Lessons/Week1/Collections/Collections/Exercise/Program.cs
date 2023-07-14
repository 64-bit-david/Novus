using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var objs = new List<object>();

            objs.Add(2.5d);
            objs.Add(2.0d);
            objs.Add(3);
            objs.Add(2);
            objs.Add("Hello ");
            objs.Add("world");


            int sumOfInts = 0;
            double sumOfDoubles = 0.00;
            string sumOfStrings = "";

            Console.WriteLine("----Print out type----");

            foreach(var obj in objs)
            {
                Console.WriteLine(obj.GetType());
                if(obj is int)
                {
                    sumOfInts+=(int)obj;
                }
                if (obj is double) 
                {
                    sumOfDoubles += (double)obj;
                }
                if (obj is string)
                {
                    sumOfStrings+=(string)obj + " ";
                }
            }

            Console.WriteLine("----Print out sums----");
            Console.WriteLine(sumOfInts);
            Console.WriteLine(sumOfDoubles);
            Console.WriteLine(sumOfStrings);


            Console.ReadLine();
        }
    }
}
