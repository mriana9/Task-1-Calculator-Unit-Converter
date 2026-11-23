
using Calculator.App.Helpers;
using Calculator.Core.Constants;
using CalculatorService = Calculator.Core.Services.Calculator;

namespace Calculator.App.Strategies;

public class CalculatorStrategy : IMenuStrategy
{
    private readonly CalculatorService _calculator;

    public CalculatorStrategy()
    {
        _calculator = CalculatorService.GetInstance();
    }

    public void Execute()
    {
        Console.WriteLine(AppMessagesConstants.CalculatorSelected);

        string operation = InputHelper.TryReadOperation();

        try
        {
            if (operation.Equals(
                CalculatorConstants.Sum,
                StringComparison.OrdinalIgnoreCase))
            {
                int count = InputHelper.TryReadChoice(
                    AppMessagesConstants.SumCountPrompt, 1);

                decimal[] numbers = new decimal[count];

                for (int i = 0; i < count; i++)
                {
                    InputHelper.TryReadNumber(
                        string.Format(
                            AppMessagesConstants.NumberPrompt, i + 1),
                        out numbers[i]);
                }

                decimal sumResult = _calculator.Sum(numbers);

                Console.WriteLine(
                    string.Format(
                        AppMessagesConstants.SumResult, sumResult));
            }
            else
            {
                InputHelper.TryReadNumber(
                    AppMessagesConstants.FirstNumberPrompt,
                    out decimal num1);

                InputHelper.TryReadNumber(
                    AppMessagesConstants.SecondNumberPrompt,
                    out decimal num2);

                decimal result = _calculator.Calculate(
                    operation, num1, num2);

                Console.WriteLine(
                    string.Format(
                        AppMessagesConstants.CalculationResult,
                        num1,
                        operation,
                        num2,
                        _calculator.Round(result)));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                AppMessagesConstants.Error + ex.Message);
        }
    }
}
