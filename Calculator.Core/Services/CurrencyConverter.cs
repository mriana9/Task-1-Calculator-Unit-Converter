
using Calculator.Core.Constants;

namespace Calculator.Core.Services;

public class CurrencyConverter
{
    // Stores a single private shared instance
    private static readonly CurrencyConverter _instance =
        new CurrencyConverter();

    // Returns the shared instance
    public static CurrencyConverter GetInstance()
    {
        return _instance;
    }

    // Prevents creating objects from outside
    private CurrencyConverter()
    {
    }

    // Converts USD to ILS
    public decimal UsdToIls(decimal usd)
    {
        return usd * CurrencyConstants.UsdToIlsRate;
    }

    // Converts ILS to USD
    public decimal IlsToUsd(decimal ils)
    {
        return ils / CurrencyConstants.UsdToIlsRate;
    }

    // Converts USD to EUR
    public decimal UsdToEur(decimal usd)
    {
        return usd * CurrencyConstants.UsdToEurRate;
    }

    // Converts EUR to USD
    public decimal EurToUsd(decimal eur)
    {
        return eur / CurrencyConstants.UsdToEurRate;
    }

    // Converts ILS to EUR
    public decimal IlsToEur(decimal ils)
    {
        return UsdToEur(IlsToUsd(ils));
    }

    // Converts EUR to ILS
    public decimal EurToIls(decimal eur)
    {
        return UsdToIls(EurToUsd(eur));
    }

    // Converts an amount between two currencies
    public decimal Convert(
        string fromCurrency,
        string toCurrency,
        decimal amount)
    {
        return (fromCurrency, toCurrency) switch
        {
            (CurrencyConstants.USD, CurrencyConstants.ILS) =>
                UsdToIls(amount),

            (CurrencyConstants.ILS, CurrencyConstants.USD) =>
                IlsToUsd(amount),

            (CurrencyConstants.USD, CurrencyConstants.EUR) =>
                UsdToEur(amount),

            (CurrencyConstants.EUR, CurrencyConstants.USD) =>
                EurToUsd(amount),

            (CurrencyConstants.ILS, CurrencyConstants.EUR) =>
                IlsToEur(amount),

            (CurrencyConstants.EUR, CurrencyConstants.ILS) =>
                EurToIls(amount),

            (CurrencyConstants.USD, CurrencyConstants.USD) => amount,
            (CurrencyConstants.ILS, CurrencyConstants.ILS) => amount,
            (CurrencyConstants.EUR, CurrencyConstants.EUR) => amount,

            _ => throw new InvalidOperationException(
                "Invalid currency conversion.")
        };
    }
}
