using Spectre.Console;
using STUDY.OOP.LibraryManagement.Controllers;
using TCSA.OOP.LibraryManagementSystem.Controllers;

namespace TCSA.OOP.LibraryManagementSystem
{
    internal class UserInterface
    {
        private readonly BooksController _booksController = new();
        private readonly MagazineController _magazinesController = new();
        private readonly NewspaperController _newspapersController = new();


        internal void MainMenu()
        {
            while (true)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<MenuOption>()
                        .Title("What do you want to do next?")
                        .AddChoices(Enum.GetValues<MenuOption>()));

                var itemTypeChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<ItemType>()
                    .Title("Select the type of item:")
                    .AddChoices(Enum.GetValues<ItemType>()));

                switch (choice)
                {
                    case MenuOption.ViewBooks:
                        ViewItems(itemTypeChoice);
                        break;
                    case MenuOption.AddBook:
                        AddItem(itemTypeChoice);
                        break;
                    case MenuOption.DeleteBook:
                        DeleteItem(itemTypeChoice);
                        break;
                }
            }
        }

        private void ViewItems(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.ViewItems();
                    break;
                case ItemType.Magazine:
                    _magazinesController.ViewItems();
                    break;
                case ItemType.Newspaper:
                    _newspapersController.ViewItems();
                    break;
            }
        }

        private void AddItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.AddItem();
                    break;
                case ItemType.Magazine:
                    _magazinesController.AddItem();
                    break;
                case ItemType.Newspaper:
                    _newspapersController.AddItem();
                    break;
            }
        }

        private void DeleteItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    _booksController.DeleteItem();
                    break;
                case ItemType.Magazine:
                    _magazinesController.DeleteItem();
                    break;
                case ItemType.Newspaper:
                    _newspapersController.DeleteItem();
                    break;
            }
        }
    }
}
