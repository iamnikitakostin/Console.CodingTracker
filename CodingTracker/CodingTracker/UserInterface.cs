using CodingTracker.Controllers;
using CodingTracker.Data;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserInterface : ConsoleController
    {
        //private readonly SessionsController _booksController = new();

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
                        CodingController.ViewSessions();
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
