using LibraryManagementSystem.Models;
using Spectre.Console;

namespace LibraryManagementSystem.Controllers;

internal class BooksController : BaseController, IBaseController
{
  public void ViewItems()
  {
    var table = new Table();
    table.Border(TableBorder.Rounded);

    table.AddColumn("[yellow]ID[/]");
    table.AddColumn("[yellow]Title[/]");
    table.AddColumn("[yellow]Author[/]");
    table.AddColumn("[yellow]Category[/]");
    table.AddColumn("[yellow]Location[/]");
    table.AddColumn("[yellow]Pages[/]");

    AnsiConsole.MarkupLine("[yellow]List of books:[/]");
    var books = MockDatabase.LibraryItems.OfType<Book>();

    foreach (var book in books)
    {
      table.AddRow(
        book.Id.ToString(),
        $"[cyan]{book.Name}[/]",
            $"[cyan]{book.Author}[/]",
            $"[green]{book.Category}[/]",
            $"[blue]{book.Location}[/]",
            book.Pages.ToString()
      );
    }
    AnsiConsole.Write(table);
    PressToContinuePrompt();
  }

  public void AddItem()
  {
    var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
    var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
    var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
    var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
    var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

    if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
    {
      DisplayMessage("This book already exists.", "red");
    }
    else
    {
      var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
      MockDatabase.LibraryItems.Add(newBook);
      DisplayMessage("Book added successfully!", "green");
    }
    PressToContinuePrompt();
  }

  public void DeleteItem()
  {
    if (MockDatabase.LibraryItems.OfType<Book>().Count() == 0)
    {
      DisplayMessage("No books to delete.");
    }
    else
    {
      var deletedBook = AnsiConsole.Prompt(
        new SelectionPrompt<Book>()
          .Title("Select a book to be [red]deleted[/]")
          .UseConverter(book => book.Name)
          .AddChoices(MockDatabase.LibraryItems.OfType<Book>())
      );
      if (MockDatabase.LibraryItems.Remove(deletedBook))
      {
        DisplayMessage($"Book {deletedBook.Name} deleted successfully!", "green");
      }
      else
      {
        DisplayMessage($"Book {deletedBook.Name} was not deleted!", "red");
      }
    }
    PressToContinuePrompt();
  }
}
