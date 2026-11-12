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

    // Method to calculate the sum of an array of decimal numbers
    public decimal Sum(params decimal[] numbers)
    {
        decimal total = 0;
        foreach (var num in numbers)
        {
            total += num;
        }
        return total;
    }
}