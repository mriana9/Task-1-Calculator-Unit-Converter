
using System;
using Calculator.Core.Constants;
using Calculator.App.Helpers;

using CalculatorService = Calculator.Core.Services.Calculator;
using UnitConverterService = Calculator.Core.Services.UnitConverter;
using CurrencyConverterService = Calculator.Core.Services.CurrencyConverter;

class Program
{
    static void RunCalculator()
    {
        Console.WriteLine(AppMessagesConstants.CalculatorSelected);

        CalculatorService calculator = CalculatorService.Instance;

        string operation = InputHelper.TryReadOperation();

        try
        {
            if (operation.Equals(
                CalculatorConstants.Sum,
                StringComparison.OrdinalIgnoreCase))
            {
                int count = InputHelper.TryReadChoice(
                    AppMessagesConstants.SumCountPrompt, 1);

                decimal[] numbers = new decimal[count];

                for (int i = 0; i < count; i++)
                {
                    InputHelper.TryReadNumber(
                        string.Format(
                            AppMessagesConstants.NumberPrompt, i + 1),
                        out numbers[i]);
                }

                decimal sumResult = calculator.Sum(numbers);

                Console.WriteLine(
                    string.Format(
                        AppMessagesConstants.SumResult, sumResult));
            }
            else
            {
                InputHelper.TryReadNumber(
                    AppMessagesConstants.FirstNumberPrompt,
                    out decimal num1);

                InputHelper.TryReadNumber(
                    AppMessagesConstants.SecondNumberPrompt,
                    out decimal num2);

                decimal result = calculator.Calculate(
                    operation, num1, num2);

                Console.WriteLine(
                    string.Format(
                        AppMessagesConstants.CalculationResult,
                        num1,
                        operation,
                        num2,
                        calculator.Round(result)));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                AppMessagesConstants.Error + ex.Message);
        }
    }

    static void RunUnitConverter()
    {
        Console.WriteLine(
            AppMessagesConstants.UnitConverterSelected);

        UnitConverterService unitConverter =
            UnitConverterService.Instance;

        Console.WriteLine(
            AppMessagesConstants.UnitConversionMenu);

        int choice = InputHelper.TryReadChoice(
            AppMessagesConstants.ConversionChoicePrompt,
            AppConstants.BackToMainMenu,
            6);

        if (choice == AppConstants.BackToMainMenu)
            return;

        UnitConversionOption conversionOption =
            (UnitConversionOption)choice;

        string conversionType = conversionOption switch
        {
            UnitConversionOption.KmToMiles =>
                UnitConversionConstants.KmToMiles,

            UnitConversionOption.MilesToKm =>
                UnitConversionConstants.MilesToKm,

            UnitConversionOption.CelsiusToFahrenheit =>
                UnitConversionConstants.CelsiusToFahrenheit,

            UnitConversionOption.FahrenheitToCelsius =>
                UnitConversionConstants.FahrenheitToCelsius,

            UnitConversionOption.KgToLb =>
                UnitConversionConstants.KgToLb,

            UnitConversionOption.LbToKg =>
                UnitConversionConstants.LbToKg,

            _ => ""
        };

        InputHelper.TryReadNumber(
            AppMessagesConstants.ConversionValuePrompt,
            out decimal value);

        decimal result = unitConverter.Convert(
            conversionType, value);

        Console.WriteLine(
            string.Format(
                AppMessagesConstants.ConversionResult, result));
    }

    static void RunCurrencyConverter()
    {
        Console.WriteLine(
            AppMessagesConstants.CurrencyConverterSelected);

        CurrencyConverterService currencyConverter =
            CurrencyConverterService.Instance;

        Console.WriteLine(
            AppMessagesConstants.CurrencyConversionMenu);

        int choice = InputHelper.TryReadChoice(
            AppMessagesConstants.ConversionChoicePrompt,
            AppConstants.BackToMainMenu,
            6);

        if (choice == AppConstants.BackToMainMenu)
            return;

        var currencies = choice switch
        {
            1 => (CurrencyConstants.USD, CurrencyConstants.ILS),
            2 => (CurrencyConstants.ILS, CurrencyConstants.USD),
            3 => (CurrencyConstants.USD, CurrencyConstants.EUR),
            4 => (CurrencyConstants.EUR, CurrencyConstants.USD),
            5 => (CurrencyConstants.ILS, CurrencyConstants.EUR),
            6 => (CurrencyConstants.EUR, CurrencyConstants.ILS),
            _ => ("", "")
        };

        InputHelper.TryReadNumber(
            AppMessagesConstants.AmountPrompt,
            out decimal amount);

        decimal result = currencyConverter.Convert(
            currencies.Item1,
            currencies.Item2,
            amount);

        Console.WriteLine(
            string.Format(
                AppMessagesConstants.CurrencyResult,
                amount,
                currencies.Item1,
                result,
                currencies.Item2));
    }

    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine(
                AppMessagesConstants.MainMenu);

            choice = InputHelper.TryReadChoice(
                AppMessagesConstants.MainMenuPrompt, 0, 3);

            switch (choice)
            {
                case 1:
                    RunCalculator();
                    break;

                case 2:
                    RunUnitConverter();
                    break;

                case 3:
                    RunCurrencyConverter();
                    break;

                case 0:
                    Console.WriteLine(
                        AppMessagesConstants.ExitMessage);
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine(
                    AppMessagesConstants.EndSeparator);
            }

        } while (choice != 0);
    }
}
