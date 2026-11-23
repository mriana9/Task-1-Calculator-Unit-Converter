
using Calculator.App.Helpers;
using Calculator.Core.Constants;
using Calculator.Core.Services;

namespace Calculator.App.Strategies;

public class UnitConverterStrategy : IMenuStrategy
{
    public void Execute()
    {
        Console.WriteLine(
            AppMessagesConstants.UnitConverterSelected);

        UnitConverter unitConverter =
            UnitConverter.GetInstance();

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
}
