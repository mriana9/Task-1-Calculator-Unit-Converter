
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

        CalculatorService calculator = CalculatorService.GetInstance();

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
            UnitConverterService.GetInstance();

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
            CurrencyConverterService.GetInstance();

        Console.WriteLine(
            AppMessagesConstants.CurrencyConversionMenu);

        int choice = InputHelper.TryReadChoice(
            AppMessagesConstants.ConversionChoicePrompt,
            AppConstants.BackToMainMenu,
            6);

        if (choice == AppConstants.BackToMainMenu)
            return;

        CurrencyConversionOption conversionOption =
            (CurrencyConversionOption)choice;

        var currencies = conversionOption switch
        {
            CurrencyConversionOption.UsdToIls =>
                (CurrencyConstants.USD, CurrencyConstants.ILS),

            CurrencyConversionOption.IlsToUsd =>
                (CurrencyConstants.ILS, CurrencyConstants.USD),

            CurrencyConversionOption.UsdToEur =>
                (CurrencyConstants.USD, CurrencyConstants.EUR),

            CurrencyConversionOption.EurToUsd =>
                (CurrencyConstants.EUR, CurrencyConstants.USD),

            CurrencyConversionOption.IlsToEur =>
                (CurrencyConstants.ILS, CurrencyConstants.EUR),

            CurrencyConversionOption.EurToIls =>
                (CurrencyConstants.EUR, CurrencyConstants.ILS),

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
        MainMenuOption choice;

        do
        {
            Console.WriteLine(
                AppMessagesConstants.MainMenu);

            choice = (MainMenuOption)InputHelper.TryReadChoice(
                AppMessagesConstants.MainMenuPrompt,
                (int)MainMenuOption.Exit,
                (int)MainMenuOption.CurrencyConverter);

            switch (choice)
            {
                case MainMenuOption.Calculator:
                    RunCalculator();
                    break;

                case MainMenuOption.UnitConverter:
                    RunUnitConverter();
                    break;

                case MainMenuOption.CurrencyConverter:
                    RunCurrencyConverter();
                    break;

                case MainMenuOption.Exit:
                    Console.WriteLine(
                        AppMessagesConstants.ExitMessage);
                    break;
            }

            if (choice != MainMenuOption.Exit)
            {
                Console.WriteLine(
                    AppMessagesConstants.EndSeparator);
            }

        } while (choice != MainMenuOption.Exit);
    }
}
