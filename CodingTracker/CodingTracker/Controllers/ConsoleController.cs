using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviews.Console.CodingTracker.Controllers
{
    public class ConsoleController
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

        protected static void SuccessMessage(string message)
        {
            AnsiConsole.MarkupLine($"[green]{message}[/]");
        }

        protected static void ErrorMessage(string message)
        {
            AnsiConsole.MarkupLine($"[red]{message}[/]");
        }
    }
}
}
