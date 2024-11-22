using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;
using TCSA.OOP.LibraryManagementSystem;
using TCSA.OOP.LibraryManagementSystem.Controllers;

namespace STUDY.OOP.LibraryManagement.Controllers;

internal class NewspaperController : BaseController, IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Location[/]");

        var newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

        foreach (var newspaper in newspapers)
        {
            table.AddRow(
                newspaper.Id.ToString(),
                $"[cyan]{newspaper.Name}[/]",
                $"[cyan]{newspaper.Publisher}[/]",
                $"[cyan]{newspaper.PublishDate:yyyy-MM-dd}[/]",
                $"[blue]{newspaper.Location}[/]"
            );
        }

        AnsiConsole.Write(table);
        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the newspaper to add:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the newspaper:");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the newspaper (yyyy-MM-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the newspaper:");

        if (MockDatabase.LibraryItems.OfType<Newspaper>().Any(n => n.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayMessage("This newspaper already exists.", "red");
        }
        else
        {
            var newNewspaper = new Newspaper(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location);
            MockDatabase.LibraryItems.Add(newNewspaper);
            DisplayMessage("Newspaper added successfully!", "green");
        }

        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDatabase.LibraryItems.OfType<Newspaper>().Count() == 0)
        {
            DisplayMessage("No newspapers available to delete.", "red");
            Console.ReadKey();
            return;
        }

        var newspaperToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Newspaper>()
                .Title("Select a [red]newspaper[/] to delete:")
                .UseConverter(n => $"{n.Name} (Published on {n.PublishDate:yyyy-MM-dd})")
                .AddChoices(MockDatabase.LibraryItems.OfType<Newspaper>()));

        if (MockDatabase.LibraryItems.Remove(newspaperToDelete))
        {
            DisplayMessage("Newspaper deleted successfully!", "green");
        }
        else
        {
            DisplayMessage("Newspaper not found.", "red");
        }

        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();
    }
}