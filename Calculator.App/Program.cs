
using System;
using Calculator.Core.Constants;
using Calculator.App.Helpers;
using Calculator.App.Strategies;
using Calculator.App.Factories;

class Program
{
    static void Main(string[] args)
    {
        MainMenuOption choice;

        do
        {
            Console.WriteLine(
                AppMessagesConstants.MainMenu);

            choice = (MainMenuOption)InputHelper.TryReadChoice(
                AppMessagesConstants.MainMenuPrompt,
                (int)MainMenuOption.Exit,
                (int)MainMenuOption.CurrencyConverter);

            if (choice != MainMenuOption.Exit)
            {
                IMenuStrategy strategy =
                    MenuStrategyFactory.GetStrategy(choice);

                strategy.Execute();
            }
            else
            {
                Console.WriteLine(
                    AppMessagesConstants.ExitMessage);
            }

            if (choice != MainMenuOption.Exit)
            {
                Console.WriteLine(
                    AppMessagesConstants.EndSeparator);
            }

        } while (choice != MainMenuOption.Exit);
    }
}
