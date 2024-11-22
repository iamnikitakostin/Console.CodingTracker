using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Controllers
{
    internal class BaseController
    {
        protected static void DisplayMessage(string message, string color = "yellow")
        {
            AnsiConsole.MarkupLine($"[{color}]{message}[/]");
        }

        protected static bool ConfirmDeletion(string itemName)
        {
            var confirm = AnsiConsole.Confirm($"Are you sure you want to delete [red]{itemName}[/]?");

            return confirm;
        }
    }
}
