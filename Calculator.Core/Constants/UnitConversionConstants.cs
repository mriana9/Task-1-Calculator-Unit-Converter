
namespace Calculator.Core.Constants;

public static class UnitConversionConstants
{
    // Unit conversion identifiers
    public const string KmToMiles = "KMToMiles";
    public const string MilesToKm = "MilesToKM";

    public const string CelsiusToFahrenheit = "CelsiusToFahrenheit";
    public const string FahrenheitToCelsius = "FahrenheitToCelsius";

    public const string KgToLb = "KGToLB";
    public const string LbToKg = "LBToKG";

    // Distance conversion rates
    public const decimal KilometersToMilesRate = 0.621371m;

    // Weight conversion rates
    public const decimal KilogramsToPoundsRate = 2.20462m;

    // Temperature conversion values
    public const decimal TemperatureScaleNumerator = 9m;
    public const decimal TemperatureScaleDenominator = 5m;
    public const decimal FahrenheitOffset = 32m;
}
