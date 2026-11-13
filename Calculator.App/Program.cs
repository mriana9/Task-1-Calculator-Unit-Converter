using System;
using Calculator.Core;

class Program
{

    static bool TryReadNumber(string prompt, out decimal value)
    {
        Console.Write(prompt);

        while (!decimal.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write(prompt);
        }

        return true;
    }

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

                        // Console.WriteLine("Enter First Number: ");
                        // decimal num1 = 0;
                        // while (!decimal.TryParse(Console.ReadLine(), out num1))
                        // {
                        //     Console.WriteLine("Invalid input. Please enter a valid number.");
                        // }

                        // Console.WriteLine("Enter Second Number: ");
                        // decimal num2 = 0;
                        // while (!decimal.TryParse(Console.ReadLine(), out num2))
                        // {
                        //     Console.WriteLine("Invalid input. Please enter a valid number.");
                        // }
                        TryReadNumber("Enter First Number: ", out decimal num1);


                        TryReadNumber("Enter Second Number: ", out decimal num2);

                        Console.WriteLine("Enter operation symbol (+, -, *, /, %, ^): ");
                        string? op = Console.ReadLine();

                        try
                        {
                            decimal result = calculator.Calculate(op ?? "+", num1, num2);
                            decimal roundedResult = calculator.Round(
                                value: result);
                            Console.WriteLine($" Result: {num1} {op} {num2} = {roundedResult}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Unit Converter selected.");

                        UnitConverter unitConverter = new UnitConverter();

                        Console.WriteLine("Choose a conversion:");
                        Console.WriteLine("1 - Kilometers to Miles");
                        Console.WriteLine("2 - Miles to Kilometers");
                        Console.WriteLine("3 - Celsius to Fahrenheit");
                        Console.WriteLine("4 - Fahrenheit to Celsius");
                        Console.WriteLine("5 - Kilograms to Pounds");
                        Console.WriteLine("6 - Pounds to Kilograms");
                        Console.WriteLine("0 - Back to Main Menu");

                        Console.Write("Enter your choice: ");

                        int conversionChoice = int.TryParse(
                            Console.ReadLine(), out int choice) ? choice : -1;

                        if (conversionChoice == 0)
                        {
                            break;
                        }

                        string conversionType = conversionChoice switch
                        {
                            1 => "KMToMiles",
                            2 => "MilesToKM",
                            3 => "CelsiusToFahrenheit",
                            4 => "FahrenheitToCelsius",
                            5 => "KGToLB",
                            6 => "LBToKG",
                            _ => ""
                        };

                        if (conversionType == "")
                        {
                            Console.WriteLine("Invalid conversion choice.");
                            break;
                        }

                        TryReadNumber("Enter the value to convert: ", out decimal value);

                        decimal convertedValue = unitConverter.Convert(
                            conversionType, value);

                        Console.WriteLine($"Result: {convertedValue}");

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