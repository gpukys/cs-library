using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
  internal class Enums
  {
    internal enum MenuOption
    {
      ViewItems,
      AddItem,
      DeleteItem,
      Quit
    }

    internal enum ItemType
    {
      Book,
      Magazine,
      Newspaper
    }
  }
}