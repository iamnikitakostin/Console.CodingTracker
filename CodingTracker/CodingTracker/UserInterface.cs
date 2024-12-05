using CodingTracker.Controllers;
using CodingTracker.Data;
using Spectre.Console;

namespace CodingTracker
{
    internal class UserInterface : ConsoleController
    {
        internal static void MainMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<MenuOption>()
                        .Title("What do you want to do next?")
                        .AddChoices(Enum.GetValues<MenuOption>()));
                switch (choice)
                {
                    case MenuOption.ViewSessions:
                        var periodChoice = AnsiConsole.Prompt(
                                new SelectionPrompt<RecordsFilterPeriodMenu>()
                                .Title("Please, choose the period filter: ")
                                .AddChoices(Enum.GetValues<RecordsFilterPeriodMenu>()));
                        var orderChoice = AnsiConsole.Prompt(
                                new SelectionPrompt<RecordsFilterOrderMenu>()
                                .Title("Please, choose how you would like to display the records: ")
                                .AddChoices(Enum.GetValues<RecordsFilterOrderMenu>()));
                        var orderFieldChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<RecordsFilterFieldMenu>()
                            .Title("Please, choose the field you would like to sort with: ")
                            .AddChoices(Enum.GetValues<RecordsFilterFieldMenu>()));
                        CodingController.ViewSessions(periodChoice, orderChoice, orderFieldChoice);
                        break;
                    case MenuOption.ViewGoals:
                        GoalController.GetAll();
                        break;
                    case MenuOption.CurrentCodingSession:
                        var currentCodingSessionChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<CurrentCodingSessionChoice>()
                            .Title("Select the type of item:")
                            .AddChoices(Enum.GetValues<CurrentCodingSessionChoice>()));
                        switch (currentCodingSessionChoice)
                        {
                            case CurrentCodingSessionChoice.StartSession:
                                CodingController.StartSession();
                                break;
                            case CurrentCodingSessionChoice.EndSession:
                                CodingController.EndSession();
                                break;
                            case CurrentCodingSessionChoice.EditSession:
                                CodingController.EditSession(true);
                                break;
                            case CurrentCodingSessionChoice.GoBack:
                                break;
                        }
                        break;
                    case MenuOption.AddGoal:
                        GoalController.Add();
                        break;
                    case MenuOption.EditSession:
                        CodingController.EditSession();
                        break;
                    case MenuOption.DeleteRecord:
                        CodingController.DeleteSession();
                        break;
                    case MenuOption.DeleteGoal:
                        GoalController.Delete();
                        break;
                    case MenuOption.GenerateReport:
                        GenerateReport.ByWeeks();
                        GenerateReport.ByMonths();
                        GenerateReport.ByYears();
                        AnsiConsole.Console.Input.ReadKey(false);
                        break;
                    case MenuOption.Quit:
                        return;
                }
            }
        }

        internal static bool CheckIfQuit(string input)
        {
            if (input == "q")
            {
                if (DbConnection.CheckIfCurrentSessionExists())
                {
                    CodingController.EndSession();
                }
                return true;
            }
            return false;
        }
    }
}
