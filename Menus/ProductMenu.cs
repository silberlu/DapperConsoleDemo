using System;
using DapperConsoleDemo.Data;
using DapperConsoleDemo.Models;

namespace DapperConsoleDemo.Menus
{
  public static class ProductMenu
  {
    public static void AddProduct()
    {
      string[] label =
      {
        "ADD PRODUCT",
        "Product Name: ",
        "Brand: ",
        "Price: ",
        "Stock Quantity: ",
        "Category: ",
      };
      string[] fields = new string[5];

      var newProduct = new Product();

      Console.Clear();
      PromptServices.PrintLabel(label, fields);

      for (int i = 0; i < fields.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(fields[i]))
        {
          fields[i] = GetValidatedFieldFormat(label[i + 1].Length, i + 1, i + 1);
        }
      }

      newProduct.ProductName = fields[0];
      newProduct.BrandName = fields[1];
      newProduct.Price = float.Parse(fields[2]);
      newProduct.StockQuantity = int.Parse(fields[3]);
      newProduct.ProductCategoryID = int.Parse(fields[4]);

      Console.Clear();
      PromptServices.PrintLabel(label, fields);

      Console.Write("Confirm product registration? [Y/n] ");
      string userInput = Console.ReadLine().ToLower();

      if (userInput == "y")
      {
        Create.NewProduct
          (
           Program.connectionString,
           newProduct.ProductName,
           newProduct.BrandName,
           newProduct.ProductCategoryID,
           newProduct.Price,
           newProduct.StockQuantity
           );
        Console.WriteLine("Product registered successfully.! Press any key to return...");
        Console.ReadKey();
        MainMenu.Home();
      }

      else if (userInput == "n")
      {
        Console.WriteLine("Operation Cancelled! Press any key to return...");
        Console.ReadKey();
        MainMenu.Home();
      }
    }

    private static string GetValidatedFieldFormat(int cursorLeft, int cursorTop, int index)
    {
      string field = string.Empty;
      var categories = PromptServices.ListCategories(false);
      while (true)
      {
        if (index == 5)
        {
          Console.SetCursorPosition(0, index + 2);
          categories = PromptServices.ListCategories(true);
        }

        Console.SetCursorPosition(cursorLeft, cursorTop);
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        if (index == 5 && (!int.TryParse(input, out int output) || output < 1 || output > categories.Count))
        {
          PromptServices.DisplayErrorMessage("Category unavailable!", cursorLeft, cursorTop);
          continue;
        }

        if (string.IsNullOrWhiteSpace(input))
        {
          PromptServices.DisplayErrorMessage("Input cannot be empty.", cursorLeft, cursorTop);
          continue;
        }

        if ((index == 3 && !float.TryParse(input, out _)) || (index == 4 && !int.TryParse(input, out _)))
        {
          PromptServices.DisplayErrorMessage("Invalid input. Please enter a valid number.", cursorLeft, cursorTop);
          continue;
        }
        else
        {
          field = input;
          break;
        }
      }
      return field;
    }
  }
}
