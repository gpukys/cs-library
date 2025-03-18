using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using Spectre.Console;

namespace LibraryManagementSystem.Controllers
{
  internal interface IBaseController
  {
    void ViewItems();
    void AddItem();
    void DeleteItem();
  }
}