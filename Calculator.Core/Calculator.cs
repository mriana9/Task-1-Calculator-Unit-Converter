namespace Calculator.Core;

public class Calculator
{
    // Method to add two decimal numbers 
    public decimal Add(decimal num1, decimal num2)
    {
        return num1 + num2;
    }

    // Method to add two integer numbers
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    // Method to subtract two decimal numbers
    public decimal Subtract(decimal num1, decimal num2)
    {
        return num1 - num2;
    }
    // Method to subtract two integer numbers
    public int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    // Method to multiply two decimal numbers
    public decimal Multiply(decimal num1, decimal num2)
    {
        return num1 * num2;
    }

    // Method to multiply two integer numbers
    public int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    // Method to divide two decimal numbers
    public decimal Divide(decimal num1, decimal num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return num1 / num2;
    }

    // Method to divide two integer numbers
    public int Divide(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return num1 / num2;
    }

    // Method to calculate the modulus of two decimal numbers
    public decimal Modulus(decimal num1, decimal num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return num1 % num2;
    }

    // Method to calculate the modulus of two integer numbers
    public int Modulus(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return num1 % num2;
    }

    // Method to calculate the power of a decimal number
    public decimal Power(decimal baseNum, decimal exponent)
    {
        return (decimal)Math.Pow((double)baseNum, (double)exponent);
    }

    // Method to calculate the power of an integer number
    public int Power(int baseNum, int exponent)
    {
        return (int)Math.Pow(baseNum, exponent);
    }

    // Method to a calculation based on the operation provided
    public decimal Calculate(string op, decimal a, decimal b) => op switch
    {
        "+" => Add(a, b),
        "-" => Subtract(a, b),
        "*" => Multiply(a, b),
        "/" => Divide(a, b),
        "%" => Modulus(a, b),
        "^" => Power(a, b),
        _ => throw new InvalidOperationException("Invalid operation")
    };

    // Method to round a decimal number
    public decimal Round(decimal value, int decimals = 2)
    {
        return Math.Round(value, decimals);
    }

    // Method to sum an array of decimal numbers
    public decimal Sum(params decimal[] numbers)
    {
        decimal total = 0;

        foreach (decimal number in numbers)
        {
            total += number;
        }

        return total;
    }
}

public class UnitConverter
{
    // Kilometers <-> Miles
    public decimal KmToMiles(decimal km) => km * 0.621371m;
    public decimal MilesToKm(decimal miles) => miles / 0.621371m;

    // Celsius <-> Fahrenheit
    public decimal CelsiusToFahrenheit(decimal c) => (c * 9m / 5m) + 32m;
    public decimal FahrenheitToCelsius(decimal f) => (f - 32m) * 5m / 9m;

    // Kilograms <-> Pounds (KG <-> LB)
    public decimal KgToLb(decimal kg) => kg * 2.20462m;
    public decimal LbToKg(decimal lb) => lb / 2.20462m;

    public decimal Convert(string conversionType, decimal value) => conversionType switch
    {
        "KMToMiles" => KmToMiles(value),
        "MilesToKM" => MilesToKm(value),
        "CelsiusToFahrenheit" => CelsiusToFahrenheit(value),
        "FahrenheitToCelsius" => FahrenheitToCelsius(value),
        "KGToLB" => KgToLb(value),
        "LBToKG" => LbToKg(value),
        _ => throw new InvalidOperationException("Invalid conversion type")
    };
}

public class CurrencyConverter
{
    private const decimal USD_TO_ILS = 3.70m;
    private const decimal USD_TO_EUR = 0.92m;

    public decimal UsdToIls(decimal usd)
    {
        return usd * USD_TO_ILS;
    }

    public decimal IlsToUsd(decimal ils)
    {
        return ils / USD_TO_ILS;
    }

    public decimal UsdToEur(decimal usd)
    {
        return usd * USD_TO_EUR;
    }

    public decimal EurToUsd(decimal eur)
    {
        return eur / USD_TO_EUR;
    }

    public decimal IlsToEur(decimal ils)
    {
        return UsdToEur(IlsToUsd(ils));
    }

    public decimal EurToIls(decimal eur)
    {
        return UsdToIls(EurToUsd(eur));
    }

    public decimal Convert(string fromCurrency, string toCurrency, decimal amount)
    {
        return (fromCurrency, toCurrency) switch
        {
            ("USD", "ILS") => UsdToIls(amount),
            ("ILS", "USD") => IlsToUsd(amount),

            ("USD", "EUR") => UsdToEur(amount),
            ("EUR", "USD") => EurToUsd(amount),

            ("ILS", "EUR") => IlsToEur(amount),
            ("EUR", "ILS") => EurToIls(amount),

            ("USD", "USD") => amount,
            ("ILS", "ILS") => amount,
            ("EUR", "EUR") => amount,

            _ => throw new InvalidOperationException("Invalid currency conversion.")
        };
    }
}