using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CalculatorAPI;
using Microsoft.Extensions.DependencyInjection;

namespace WebServiceCalculatorConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator Console App (Web Service Version).");
            Console.WriteLine("Press x to quit the application.");

            // Configure IoC container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDiagnostics, DbDiagnostics>()
                .AddSingleton<IDiagnostics>(provider => new StoredProcedureDiagnostics("Server=.\\SQLEXPRESS;Database=CalcDiagnostics;Integrated Security=True;"))
                .AddScoped<IWebServiceCalculator, WebServiceCalculator>() // Use the WebServiceCalculator implementation
                .AddScoped<CalculatorAPI.CalcDiagnosticsEntities1>()
                .BuildServiceProvider();

            var webServiceCalculator = serviceProvider.GetRequiredService<IWebServiceCalculator>();
            var logger = serviceProvider.GetRequiredService<IDiagnostics>();
            bool continueCalculations = true;

            while (continueCalculations)
            {
                int num1 = GetNumberFromUser("Enter the first number: ");
                int num2 = GetNumberFromUser("Enter the second number: ");

                Console.WriteLine("Select Operation: ");
                Console.WriteLine("+ --> Add");
                Console.WriteLine("- --> Subtract");
                Console.WriteLine("* --> Multiply");
                Console.WriteLine("/ --> Divide");

                string operation = Console.ReadLine();

                int result;
                switch (operation)
                {
                    case "+":
                        result = webServiceCalculator.Add(new HttpClient(), num1, num2).Result;
                        logger.Log($"User performed addition: {num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = webServiceCalculator.Subtract(new HttpClient(), num1, num2).Result;
                        logger.Log($"User performed subtraction: {num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = webServiceCalculator.Multiply(new HttpClient(), num1, num2).Result;
                        logger.Log($"User performed multiplication: {num1} * {num2} = {result}");
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero.");
                            logger.Log($"User Performed Calculation Error: Cannot Divide by 0");
                            continue;
                        }
                        result = webServiceCalculator.Divide(new HttpClient(), num1, num2).Result;
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

