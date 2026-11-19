
using Calculator.Core.Constants;

namespace Calculator.Core.Services;

public class UnitConverter
{
    // Creates a single shared instance
    public static UnitConverter Instance { get; } = new UnitConverter();

    // Prevents creating objects from outside
    private UnitConverter()
    {
    }

    // Converts kilometers to miles
    public decimal KmToMiles(decimal km)
    {
        return km * UnitConversionConstants.KilometersToMilesRate;
    }

    // Converts miles to kilometers
    public decimal MilesToKm(decimal miles)
    {
        return miles / UnitConversionConstants.KilometersToMilesRate;
    }

    // Converts Celsius to Fahrenheit
    public decimal CelsiusToFahrenheit(decimal c)
    {
        return (c * UnitConversionConstants.TemperatureScaleNumerator /
                UnitConversionConstants.TemperatureScaleDenominator)
               + UnitConversionConstants.FahrenheitOffset;
    }

    // Converts Fahrenheit to Celsius
    public decimal FahrenheitToCelsius(decimal f)
    {
        return (f - UnitConversionConstants.FahrenheitOffset) *
               UnitConversionConstants.TemperatureScaleDenominator /
               UnitConversionConstants.TemperatureScaleNumerator;
    }

    // Converts kilograms to pounds
    public decimal KgToLb(decimal kg)
    {
        return kg * UnitConversionConstants.KilogramsToPoundsRate;
    }

    // Converts pounds to kilograms
    public decimal LbToKg(decimal lb)
    {
        return lb / UnitConversionConstants.KilogramsToPoundsRate;
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
