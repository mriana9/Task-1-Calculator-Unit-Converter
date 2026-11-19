namespace Calculator.Core.Constants;

public static class AppMessagesConstants
{
    // Main menu
    public const string MainMenu =
        "Welcome to the Calculator App!\n" +
        "--------------------------------\n" +
        "1 - Calculator\n" +
        "2 - Unit Converter\n" +
        "3 - Currency Converter\n" +
        "0 - Exit\n" +
        "--------------------------------";

    public const string MainMenuPrompt = "Enter a number to choose option: ";

    // General messages
    public const string InvalidNumber = "Invalid input. Please enter a valid number.";
    public const string InvalidChoice = "Invalid input. Please enter a number between {0} and {1}.";
    public const string InvalidOperation = "Invalid operation.";
    public const string Error = "Error: ";
    public const string ExitMessage = "Exiting the application.";
    public const string EndSeparator = "\n--------------------------------\n";

    // Calculator messages
    public const string CalculatorSelected = "Calculator selected.";
    public const string OperationPrompt = "Enter operation (+, -, *, /, %, ^, sum): ";
    public const string SumCountPrompt = "How many numbers do you want to sum? ";
    public const string FirstNumberPrompt = "Enter First Number: ";
    public const string SecondNumberPrompt = "Enter Second Number: ";
    public const string NumberPrompt = "Enter number {0}: ";
    public const string SumResult = "Sum Result: {0:F2}";
    public const string CalculationResult = "Result: {0} {1} {2} = {3:F2}";

    // Unit converter messages
    public const string UnitConverterSelected = "Unit Converter selected.";

    public const string UnitConversionMenu =
        "Choose a conversion:\n" +
        "1 - Kilometers to Miles\n" +
        "2 - Miles to Kilometers\n" +
        "3 - Celsius to Fahrenheit\n" +
        "4 - Fahrenheit to Celsius\n" +
        "5 - Kilograms to Pounds\n" +
        "6 - Pounds to Kilograms\n" +
        "0 - Back to Main Menu";

    public const string ConversionChoicePrompt = "Enter your choice: ";
    public const string ConversionValuePrompt = "Enter the value to convert: ";
    public const string ConversionResult = "Result: {0:F2}";

    // Currency converter messages
    public const string CurrencyConverterSelected = "Currency Converter selected.";

    public const string CurrencyConversionMenu =
        "Choose a conversion:\n" +
        "1 - USD to ILS\n" +
        "2 - ILS to USD\n" +
        "3 - USD to EUR\n" +
        "4 - EUR to USD\n" +
        "5 - ILS to EUR\n" +
        "6 - EUR to ILS\n" +
        "0 - Back to Main Menu";

    public const string AmountPrompt = "Enter the amount to convert: ";
    public const string CurrencyResult = "Result: {0:F2} {1} = {2:F2} {3}";
}
