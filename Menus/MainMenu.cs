using System;
using System.Linq;

namespace DapperConsoleDemo.Menus
{
  public class MainMenu
  {
    public static void Home()
    {
      string[] label =
      {
        "DAPPER CONSOLE DEMO",
        "[1] - Add New Product",
        "[2] - List All",
        "[3] - Search",
        "[0] - Exit",
        "Option: "
      };

      while (true)
      {
        Console.Clear();
        PromptServices.PrintLabel(label, new string[0]);
        if (!int.TryParse(Console.ReadLine(), out int output) || output > label.Count() - 1 || output < 0)
        {
          PromptServices.DisplayErrorMessage("Invalid Option!", label.Last().Length, label.Count() - 1);
          continue;
        }
        else
          switch (output)
          {
            case 1: ProductMenu.AddProduct(); break;
            default: break;
          }
        break;
      }
    }
  }
}
