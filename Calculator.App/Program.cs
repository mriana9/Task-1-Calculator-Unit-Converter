
using System;
using Calculator.Core.Constants;
using CalculatorService = Calculator.Core.Services.Calculator;
using UnitConverterService = Calculator.Core.Services.UnitConverter;
using CurrencyConverterService = Calculator.Core.Services.CurrencyConverter;

class Program
{
    // Reads a valid decimal number
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

    // Reads a valid menu choice within a range
    static int TryReadChoice(string prompt, int min, int max)
    {
        Console.Write(prompt);

        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice)
               || choice < min || choice > max)
        {
            Console.WriteLine(
                $"Invalid input. Please enter a number between {min} and {max}.");

            Console.Write(prompt);
        }

        return choice;
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

            number = TryReadChoice(
                "Enter a number to choose option: ", 0, 3);

            switch (number)
            {
                case 1:
                    Console.WriteLine("Calculator selected.");

                    CalculatorService calculator = new CalculatorService();

                    string[] operations =
                    {
                        CalculatorConstants.Add,
                        CalculatorConstants.Subtract,
                        CalculatorConstants.Multiply,
                        CalculatorConstants.Divide,
                        CalculatorConstants.Modulus,
                        CalculatorConstants.Power,
                        CalculatorConstants.Sum
                    };

                    Console.Write(
                        "Enter operation (+, -, *, /, %, ^, sum): ");

                    string? op = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(op) ||
                           !Array.Exists(operations, x => x == op))
                    {
                        Console.WriteLine("Invalid operation.");

                        Console.Write(
                            "Enter operation (+, -, *, /, %, ^, sum): ");

                        op = Console.ReadLine();
                    }

                    try
                    {
                        if (op == CalculatorConstants.Sum)
                        {
                            int count = TryReadChoice(
                                "How many numbers do you want to sum? ",
                                1,
                                100);

                            decimal[] numbers = new decimal[count];

                            for (int i = 0; i < count; i++)
                            {
                                TryReadNumber(
                                    $"Enter number {i + 1}: ",
                                    out numbers[i]);
                            }

                            decimal result = calculator.Sum(numbers);

                            Console.WriteLine(
                                $"Sum Result: {result:F2}");
                        }
                        else
                        {
                            TryReadNumber(
                                "Enter First Number: ", out decimal num1);

                            TryReadNumber(
                                "Enter Second Number: ", out decimal num2);

                            decimal result = calculator.Calculate(
                                op, num1, num2);

                            decimal roundedResult = calculator.Round(
                                value: result);

                            Console.WriteLine(
                                $"Result: {num1} {op} {num2} = {roundedResult:F2}");
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    break;

                case 2:
                    Console.WriteLine("Unit Converter selected.");

                    UnitConverterService unitConverter =
                        new UnitConverterService();

                    Console.WriteLine("Choose a conversion:");
                    Console.WriteLine("1 - Kilometers to Miles");
                    Console.WriteLine("2 - Miles to Kilometers");
                    Console.WriteLine("3 - Celsius to Fahrenheit");
                    Console.WriteLine("4 - Fahrenheit to Celsius");
                    Console.WriteLine("5 - Kilograms to Pounds");
                    Console.WriteLine("6 - Pounds to Kilograms");
                    Console.WriteLine("0 - Back to Main Menu");

                    int conversionChoice = TryReadChoice(
                        "Enter your choice: ", 0, 6);

                    if (conversionChoice == 0)
                    {
                        break;
                    }

                    string conversionType = conversionChoice switch
                    {
                        1 => UnitConversionConstants.KmToMiles,
                        2 => UnitConversionConstants.MilesToKm,
                        3 => UnitConversionConstants.CelsiusToFahrenheit,
                        4 => UnitConversionConstants.FahrenheitToCelsius,
                        5 => UnitConversionConstants.KgToLb,
                        6 => UnitConversionConstants.LbToKg,
                        _ => ""
                    };

                    TryReadNumber(
                        "Enter the value to convert: ", out decimal value);

                    decimal convertedValue = unitConverter.Convert(
                        conversionType, value);

                    Console.WriteLine($"Result: {convertedValue:F2}");

                    break;

                case 3:
                    Console.WriteLine("Currency Converter selected.");

                    CurrencyConverterService currencyConverter =
                        new CurrencyConverterService();

                    Console.WriteLine("Choose a conversion:");
                    Console.WriteLine("1 - USD to ILS");
                    Console.WriteLine("2 - ILS to USD");
                    Console.WriteLine("3 - USD to EUR");
                    Console.WriteLine("4 - EUR to USD");
                    Console.WriteLine("5 - ILS to EUR");
                    Console.WriteLine("6 - EUR to ILS");
                    Console.WriteLine("0 - Back to Main Menu");

                    int currencyChoice = TryReadChoice(
                        "Enter your choice: ", 0, 6);

                    if (currencyChoice == 0)
                    {
                        break;
                    }

                    string fromCurrency = currencyChoice switch
                    {
                        1 => CurrencyConstants.USD,
                        2 => CurrencyConstants.ILS,
                        3 => CurrencyConstants.USD,
                        4 => CurrencyConstants.EUR,
                        5 => CurrencyConstants.ILS,
                        6 => CurrencyConstants.EUR,
                        _ => ""
                    };

                    string toCurrency = currencyChoice switch
                    {
                        1 => CurrencyConstants.ILS,
                        2 => CurrencyConstants.USD,
                        3 => CurrencyConstants.EUR,
                        4 => CurrencyConstants.USD,
                        5 => CurrencyConstants.EUR,
                        6 => CurrencyConstants.ILS,
                        _ => ""
                    };

                    TryReadNumber(
                        "Enter the amount to convert: ", out decimal amount);

                    decimal convertedAmount = currencyConverter.Convert(
                        fromCurrency,
                        toCurrency,
                        amount);

                    Console.WriteLine(
                        $"Result: {amount:F2} {fromCurrency} = {convertedAmount:F2} {toCurrency}");

                    break;

                case 0:
                    Console.WriteLine("Exiting the application.");
                    break;
            }

            Console.WriteLine("\n--------------------------------\n");

        } while (number != 0);
    }
}
