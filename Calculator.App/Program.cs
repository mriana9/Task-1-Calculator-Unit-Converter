using System;
using Calculator.Core;

class Program
{
    static void Main(string[] args)
    {
        int number = 0;
        do
        {
            Console.WriteLine("Welcome to the Calculator App!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1 - Calculator");
            Console.WriteLine("2 - Unit Converter");
            Console.WriteLine("3 - Currency Converter");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter a number to choose option:");

            number = int.TryParse(Console.ReadLine(), out int input) ? input : -1;

            if (number >= 0 && number <= 3)
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Calculator selected.");
                        Calculator.Core.Calculator calculator = new Calculator.Core.Calculator();

                        Console.WriteLine("Enter First Number: ");
                        decimal num1 = 0;
                        while (!decimal.TryParse(Console.ReadLine(), out num1))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }

                        Console.WriteLine("Enter Second Number: ");
                        decimal num2 = 0;
                        while (!decimal.TryParse(Console.ReadLine(), out num2))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }

                        Console.WriteLine("Enter operation symbol (+, -, *, /, %, ^): ");
                        string? op = Console.ReadLine();

                        try
                        {
                            decimal result = calculator.Calculate(op ?? "+", num1, num2);
                            Console.WriteLine($" Result: {num1} {op} {num2} = {result}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Unit Converter selected.");
                        break;

                    case 3:
                        Console.WriteLine("Currency Converter selected.");
                        break;

                    case 0:
                        Console.WriteLine("Exiting the application.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 0 and 3.");
            }

            Console.WriteLine("\n--------------------------------\n");
        } while (number != 0);
    }
}