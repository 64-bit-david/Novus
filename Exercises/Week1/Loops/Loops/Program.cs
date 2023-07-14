using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomObj = new Random();
            int lower_bound = 1;
            int upper_bound = 101;
            int num_of_tries = 6;
            int randomNum = randomObj.Next(lower_bound, upper_bound);
            Console.WriteLine("Hello! Enter a number between 1 and 100 to guess the random number!\n" +
                "You get a hint after each try telling you if your guess is greater or lower than the target.");

            bool continueGame = true;
            while (continueGame)
            {
                if (num_of_tries > 0)
                {
                    Console.WriteLine($"You have {num_of_tries} tries remaining.");
                    Console.Write("Enter your number: ");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == randomNum)
                    {
                        Console.WriteLine($"Congrats! Your guess of {userInput} is correct!");
                        break;
                    }
                    else if (userInput > upper_bound || userInput < lower_bound)
                    {
                        Console.WriteLine("Your number is out of range. Please enter a number between 1 and 100");
                    }
                    else if (userInput > randomNum)
                    {
                        Console.WriteLine("Your guess is too high!");
                        num_of_tries--;
                        if(num_of_tries > 0)
                        {
                            Console.WriteLine("Pick a lower number.");
                        }

                    }
                    else
                    {

                        Console.WriteLine("Your guess is too low!");
                        num_of_tries--;
                        if (num_of_tries > 0)
                        {
                            Console.WriteLine("Pick a higher number.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Game Over! You ran out of tries. The correct number was {randomNum}");
                    continueGame = false;
                }
            }
            Console.ReadLine();
        }
    }
}
