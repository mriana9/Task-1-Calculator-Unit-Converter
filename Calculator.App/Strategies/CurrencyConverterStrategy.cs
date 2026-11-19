
using Calculator.App.Helpers;
using Calculator.Core.Constants;
using Calculator.Core.Services;

namespace Calculator.App.Strategies;

public class CurrencyConverterStrategy : IMenuStrategy
{
    public void Execute()
    {
        Console.WriteLine(
            AppMessagesConstants.CurrencyConverterSelected);

        CurrencyConverter currencyConverter =
            CurrencyConverter.GetInstance();

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
}
