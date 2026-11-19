
using Calculator.Core.Constants;
using Calculator.App.Strategies;

namespace Calculator.App.Factories;

public class MenuStrategyFactory
{
    public static IMenuStrategy GetStrategy(MainMenuOption option)
    {
        return option switch
        {
            MainMenuOption.Calculator =>
                new CalculatorStrategy(),

            MainMenuOption.UnitConverter =>
                new UnitConverterStrategy(),

            MainMenuOption.CurrencyConverter =>
                new CurrencyConverterStrategy(),

            _ => throw new ArgumentException(
                "Invalid menu option.")
        };
    }
}
