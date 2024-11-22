using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSA.OOP.LibraryManagementSystem.Models
{
    internal class Book : LibraryItem
    {
        internal string Author { get; set; } = "Unknown";
        internal string Category { get; set; } = "Unknown";
        internal int Pages { get; set; } = 0;

        internal Book(int id, string name, string author, string category, string location, int pages)
            :base(id, name, location)
        {
            Author = author;
            Category = category;
            Pages = pages;
        }

        public override void DisplayDetails()
        {
            var panel = new Panel(new Markup($"[bold]Book:[/] [cyan]{Name}[/] by [cyan]{Author}[/]") +
                                  $"\n[bold]Pages:[/] {Pages}" +
                                  $"\n[bold]Category:[/] [green]{Category}[/]" +
                                  $"\n[bold]Location:[/] [blue]{Location}[/]")
            {
                Border = BoxBorder.Rounded
            };

            AnsiConsole.Write(panel);
        }
    }
}
