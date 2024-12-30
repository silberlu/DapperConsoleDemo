using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DapperConsoleDemo.Data;

// using DapperConsoleDemo.Data;

namespace DapperConsoleDemo.Menus
{
  public class PromptServices
  {
    public static void PrintLabel(string[] label, string[] fields)
    {
      Console.Clear();
      foreach (var item in label)
      {
        Console.WriteLine(item);
      }

      if (!fields.Any())
      {
        Console.SetCursorPosition(label[label.Count() - 1].Length, label.Count() - 1);
      }

      else
      {
        for (int i = 0; i < fields.Length; i++)
        {
          Console.SetCursorPosition(label[i + 1].Length, i + 1);
          Console.WriteLine(fields[i]);
        }
      }
    }

    public static List<ProductCategory> ListCategories(bool showCategories)
    {
      var categories = Read.ListAllCategories(Program.connectionString);
      if (showCategories == true)
      {
        Console.WriteLine("Categories:");
        foreach (var item in categories)
        {
          Console.WriteLine($"[{item.ProductCategoryID}] - {item.ProductCategoryName}");
        }
      }
      return categories;
    }

    public static void DisplayErrorMessage(string message, int cursorLeft, int cursorTop)
    {
      var currentCursorTop = Console.CursorTop;
      var currentCursorLeft = Console.CursorLeft;

      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.Write(message.PadRight(Console.WindowWidth - cursorLeft));
      Thread.Sleep(500);

      Console.SetCursorPosition(cursorLeft, cursorTop);
      Console.Write(new string(' ', Console.WindowWidth - cursorLeft));

      Console.SetCursorPosition(currentCursorLeft, currentCursorTop);
    }
  }
}
