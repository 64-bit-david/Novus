using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            Console.Write("Enter a positive number");
            x = Convert.ToInt32(Console.ReadLine());
            if(x>0)
            {
                switch (x)
                {
                    case 0:
                        Console.WriteLine("The value is 0");
                        break;
                    case 1:
                        Console.WriteLine("The value is 1");
                        break;
                    case 2:
                        Console.WriteLine("The value is 2");
                        break;
                    case 3:
                        Console.WriteLine("The value is 3");
                        break;
                    case 4:
                        Console.WriteLine("The value is 4");
                        break;
                    case 5:
                        Console.WriteLine("The value is 5");
                        break;
                    default:
                        Console.WriteLine("The value is greater than 5");
                        break;
                
                }
            }
            else
            {
                Console.Write("The value must be a positive number");
            }
            Console.ReadLine();
        }
    }
}
