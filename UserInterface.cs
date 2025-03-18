using LibraryManagementSystem.Controllers;
using Spectre.Console;
using static LibraryManagementSystem.Enums;

namespace LibraryManagementSystem
{
  internal class UserInterface
  {
    internal void MainMenu()
    {
      while (true)
      {
        Console.Clear();

        var actionChoice = AnsiConsole.Prompt(
          new SelectionPrompt<ItemType>()
            .Title("What do you want to use?")
            .AddChoices(Enum.GetValues<ItemType>())
        );

        var choice = AnsiConsole.Prompt(
          new SelectionPrompt<MenuOption>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption>())
        );

        IBaseController controller;

        switch (actionChoice)
        {
          case ItemType.Book:
            controller = new BooksController();
            break;
          case ItemType.Magazine:
            controller = new MagazinesController();
            break;
          case ItemType.Newspaper:
            controller = new NewspapersController();
            break;
          default:
            throw new InvalidOperationException();
        }


        switch (choice)
        {
          case MenuOption.ViewItems:
            controller.ViewItems();
            break;
          case MenuOption.AddItem:
            controller.AddItem();
            break;
          case MenuOption.DeleteItem:
            controller.DeleteItem();
            break;
          case MenuOption.Quit:
            Console.WriteLine("See you!");
            Environment.Exit(0);
            break;
        }
      }
    }
  }
}