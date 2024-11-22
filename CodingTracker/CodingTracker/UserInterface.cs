using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviews.Console.CodingTracker
{
    internal class UserInterface
    {
        //private readonly SessionsController _booksController = new();

        internal void MainMenu() {
            while (true)
            {
                System.Console.Clear();

                var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<MenuOption>()
                        .Title("What do you want to do next?")
                        .AddChoices(Enum.GetValues<MenuOption>()));



                switch (choice)
                {
                    case MenuOption.ViewSessions:
                        break;
                    case MenuOption.CurrentCodingSession:
                        var currentCodingSessionChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<CurrentCodingSessionChoice>()
                            .Title("Select the type of item:")
                            .AddChoices(Enum.GetValues<CurrentCodingSessionChoice>()));
                        switch (currentCodingSessionChoice)
                        {
                            case CurrentCodingSessionChoice.StartCurrentSession:
                                break;
                            case CurrentCodingSessionChoice.EndCurrentSession:
                                break;
                            case CurrentCodingSessionChoice.EditCurrentSessionTime:
                                break;
                            default:
                                break;
                        }
                        break;
                    case MenuOption.DeleteRecord:
                        break;
                    case MenuOption.GenerateReport:
                        break;
                }
            }
        }
    }
}
