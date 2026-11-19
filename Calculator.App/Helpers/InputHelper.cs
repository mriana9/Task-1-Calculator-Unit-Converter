
using System;
using Calculator.Core.Constants;

namespace Calculator.App.Helpers;

public static class InputHelper
{
    // Reads a decimal number and repeats until the input is valid
    public static bool TryReadNumber(string prompt, out decimal value)
    {
        Console.Write(prompt);

        while (!decimal.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine(AppMessagesConstants.InvalidNumber);
            Console.Write(prompt);
        }

        return true;
    }

    // Reads an integer within the specified range
    public static int TryReadChoice(
        string prompt,
        int min = int.MinValue,
        int max = int.MaxValue)
    {
        Console.Write(prompt);
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) ||
               choice < min || choice > max)
        {
            Console.WriteLine(
                string.Format(AppMessagesConstants.InvalidChoice, min, max));

            Console.Write(prompt);
        }

        return choice;
    }

    // Reads an operation and checks whether it is supported
    public static string TryReadOperation(string[] operations)
    {
        Console.Write(AppMessagesConstants.OperationPrompt);

        string operation = Console.ReadLine() ?? "";

        while (!Array.Exists(
                   operations,
                   item => item.Equals(operation, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine(AppMessagesConstants.InvalidOperation);
            Console.Write(AppMessagesConstants.OperationPrompt);
            operation = Console.ReadLine() ?? "";
        }

        return operation;
    }
}
