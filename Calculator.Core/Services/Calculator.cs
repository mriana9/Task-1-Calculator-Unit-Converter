
using Calculator.Core.Constants;

namespace Calculator.Core.Services;

public class Calculator
{

    // Creates a single shared instance
    public static Calculator Instance { get; } = new Calculator();

    // Prevents creating objects from outside
    private Calculator()
    {
    }
    // Adds two decimal numbers
    public decimal Add(decimal num1, decimal num2)
    {
        return num1 + num2;
    }

    // Adds two integer numbers
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    // Subtracts two decimal numbers
    public decimal Subtract(decimal num1, decimal num2)
    {
        return num1 - num2;
    }

    // Subtracts two integer numbers
    public int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    // Multiplies two decimal numbers
    public decimal Multiply(decimal num1, decimal num2)
    {
        return num1 * num2;
    }

    // Multiplies two integer numbers
    public int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    // Divides two decimal numbers
    public decimal Divide(decimal num1, decimal num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return num1 / num2;
    }

    // Divides two integer numbers
    public int Divide(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return num1 / num2;
    }

    // Calculates the remainder of two decimal numbers
    public decimal Modulus(decimal num1, decimal num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return num1 % num2;
    }

    // Calculates the remainder of two integer numbers
    public int Modulus(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return num1 % num2;
    }

    // Calculates the power of a decimal number
    public decimal Power(decimal baseNum, decimal exponent)
    {
        return (decimal)Math.Pow((double)baseNum, (double)exponent);
    }

    // Calculates the power of an integer number
    public int Power(int baseNum, int exponent)
    {
        return (int)Math.Pow(baseNum, exponent);
    }

    // Performs a calculation based on the operation symbol
    public decimal Calculate(string op, decimal a, decimal b) => op switch
    {
        CalculatorConstants.Add => Add(a, b),
        CalculatorConstants.Subtract => Subtract(a, b),
        CalculatorConstants.Multiply => Multiply(a, b),
        CalculatorConstants.Divide => Divide(a, b),
        CalculatorConstants.Modulus => Modulus(a, b),
        CalculatorConstants.Power => Power(a, b),

        _ => throw new InvalidOperationException("Invalid operation.")
    };

    // Rounds a decimal number
    public decimal Round(decimal value, int decimals = 2)
    {
        return Math.Round(value, decimals);
    }

    // Calculates the sum of multiple decimal numbers
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
