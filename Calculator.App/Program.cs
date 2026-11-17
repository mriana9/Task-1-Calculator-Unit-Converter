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
            Console.WriteLine(AppMessagesConstants.InvalidNumber);
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
            Console.WriteLine(string.Format(
                AppMessagesConstants.InvalidChoice, min, max));

            Console.Write(prompt);
        }

        return choice;
    }

    static void Main(string[] args)
    {
        int number = 0;

        do
        {
            Console.WriteLine(AppMessagesConstants.MainMenu);

            number = TryReadChoice(
                AppMessagesConstants.MainMenuPrompt, 0, 3);

            switch (number)
            {
                case 1:
                    Console.WriteLine(
                        AppMessagesConstants.CalculatorSelected);

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

                    Console.Write(AppMessagesConstants.OperationPrompt);

                    string? op = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(op) ||
                           !Array.Exists(operations, x => x == op))
                    {
                        Console.WriteLine(
                            AppMessagesConstants.InvalidOperation);

                        Console.Write(
                            AppMessagesConstants.OperationPrompt);

                        op = Console.ReadLine();
                    }

                    try
                    {
                        if (op == CalculatorConstants.Sum)
                        {
                            int count = TryReadChoice(
                                AppMessagesConstants.SumCountPrompt,
                                1,
                                100);

                            decimal[] numbers = new decimal[count];

                            for (int i = 0; i < count; i++)
                            {
                                TryReadNumber(
                                    string.Format(
                                        AppMessagesConstants.NumberPrompt,
                                        i + 1),
                                    out numbers[i]);
                            }

                            decimal result = calculator.Sum(numbers);

                            Console.WriteLine(string.Format(
                                AppMessagesConstants.SumResult, result));
                        }
                        else
                        {
                            TryReadNumber(
                                AppMessagesConstants.FirstNumberPrompt,
                                out decimal num1);

                            TryReadNumber(
                                AppMessagesConstants.SecondNumberPrompt,
                                out decimal num2);

                            decimal result = calculator.Calculate(
                                op, num1, num2);

                            decimal roundedResult = calculator.Round(
                                value: result);

                            Console.WriteLine(string.Format(
                                AppMessagesConstants.CalculationResult,
                                num1, op, num2, roundedResult));
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(
                            AppMessagesConstants.Error + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            AppMessagesConstants.Error + ex.Message);
                    }

                    break;

                case 2:
                    Console.WriteLine(
                        AppMessagesConstants.UnitConverterSelected);

                    UnitConverterService unitConverter =
                        new UnitConverterService();

                    Console.WriteLine(
                        AppMessagesConstants.UnitConversionMenu);

                    int conversionChoice = TryReadChoice(
                        AppMessagesConstants.ConversionChoicePrompt,
                        0,
                        6);

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
                        AppMessagesConstants.ConversionValuePrompt,
                        out decimal value);

                    decimal convertedValue = unitConverter.Convert(
                        conversionType, value);

                    Console.WriteLine(string.Format(
                        AppMessagesConstants.ConversionResult,
                        convertedValue));

                    break;

                case 3:
                    Console.WriteLine(
                        AppMessagesConstants.CurrencyConverterSelected);

                    CurrencyConverterService currencyConverter =
                        new CurrencyConverterService();

                    Console.WriteLine(
                        AppMessagesConstants.CurrencyConversionMenu);

                    int currencyChoice = TryReadChoice(
                        AppMessagesConstants.ConversionChoicePrompt,
                        0,
                        6);

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
                        AppMessagesConstants.AmountPrompt,
                        out decimal amount);

                    decimal convertedAmount = currencyConverter.Convert(
                        fromCurrency,
                        toCurrency,
                        amount);

                    Console.WriteLine(string.Format(
                        AppMessagesConstants.CurrencyResult,
                        amount,
                        fromCurrency,
                        convertedAmount,
                        toCurrency));

                    break;

                case 0:
                    Console.WriteLine(
                        AppMessagesConstants.ExitMessage);

                    break;
            }

            Console.WriteLine(AppMessagesConstants.EndSeparator);

        } while (number != 0);
    }
}