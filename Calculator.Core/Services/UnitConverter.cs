
using Calculator.Core.Constants;

namespace Calculator.Core.Services;

public class UnitConverter
{
    // Converts kilometers to miles
    public decimal KmToMiles(decimal km)
    {
        return km * 0.621371m;
    }

    // Converts miles to kilometers
    public decimal MilesToKm(decimal miles)
    {
        return miles / 0.621371m;
    }

    // Converts Celsius to Fahrenheit
    public decimal CelsiusToFahrenheit(decimal c)
    {
        return (c * 9m / 5m) + 32m;
    }

    // Converts Fahrenheit to Celsius
    public decimal FahrenheitToCelsius(decimal f)
    {
        return (f - 32m) * 5m / 9m;
    }

    // Converts kilograms to pounds
    public decimal KgToLb(decimal kg)
    {
        return kg * 2.20462m;
    }

    // Converts pounds to kilograms
    public decimal LbToKg(decimal lb)
    {
        return lb / 2.20462m;
    }

    // Performs a unit conversion based on the conversion type
    public decimal Convert(string conversionType, decimal value)
        => conversionType switch
        {
            UnitConversionConstants.KmToMiles => KmToMiles(value),
            UnitConversionConstants.MilesToKm => MilesToKm(value),

            UnitConversionConstants.CelsiusToFahrenheit =>
                CelsiusToFahrenheit(value),

            UnitConversionConstants.FahrenheitToCelsius =>
                FahrenheitToCelsius(value),

            UnitConversionConstants.KgToLb => KgToLb(value),
            UnitConversionConstants.LbToKg => LbToKg(value),

            _ => throw new InvalidOperationException(
                "Invalid conversion type.")
        };
}
