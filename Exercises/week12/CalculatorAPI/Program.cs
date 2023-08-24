using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace CalculatorAPI
{
    public class Program
    {
            private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App.");
            Console.WriteLine("Press x to quit the application.");

            //Configure IoC container
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IDiagnostics, DbDiagnostics>()
                    .AddSingleton<ICalculator, Calculator>()
                    .AddScoped<CalculatorAPI.CalcDiagnosticsEntities1>()
                    .BuildServiceProvider();



            var calc = serviceProvider.GetRequiredService<ICalculator>();
            var logger = serviceProvider.GetRequiredService<IDiagnostics>();
            bool continueCalculations = true;

            while (continueCalculations)
            {
                int num1 = GetNumberFromUser("Enter the first number: ");
                int num2 = GetNumberFromUser("Enter the second number: ");

                Console.WriteLine("Select Operation: ");
                Console.WriteLine("+ - Add");
                Console.WriteLine("- - Subtract");
                Console.WriteLine("* - Multiply");
                Console.WriteLine("/ - Divide");

                string operation = Console.ReadLine();

                int result;
                switch (operation)
                {
                    case "+":
                        result = calc.Add(num1, num2);
                        logger.Log($"User performed addition: {num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = calc.Subtract(num1, num2);
                        logger.Log($"User performed subtraction: {num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = calc.Multiply(num1, num2);
                        logger.Log($"User performed multiplication: {num1} * {num2} = {result}");

                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero.");
                            logger.Log($"User Performed Calculation Error: Cannot Divide by 0");

                            continue;
                        }
                        result = calc.Divide(num1, num2);
                        logger.Log($"User performed division: {num1} / {num2} = {result}");

                        break;
                    default:
                        Console.WriteLine("Invalid Operation, please try again.");
                        continue;
                }

                Console.WriteLine($"The result is: {result}");

                Console.Write("Do you want to perform another calculation? (y/n) ");
                continueCalculations = Console.ReadLine().Trim().Equals("y", StringComparison.OrdinalIgnoreCase);
            }

            Console.WriteLine("Application Closed.");
        }

        private static int GetNumberFromUser(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer number.");
            }
        }
    }
}
