using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            double count = 0;
           
            while(count != 10)
            {
                sum = sum + Math.Pow(count, 2.0);
                Console.WriteLine($"Count: {count}, sum: {sum}");
                count++;
            }
            Console.ReadLine();
        }
    }
}
