using System;
using DapperConsoleDemo.Data;

namespace DapperConsoleDemo.UI
{
    public static partial class Menu
    {
        public static void Home()
        {
            string menuText = "DAPPER CONSOLE DEMO\n[1] - List All Products\n[2] - Search\n[3] - Add New Product\n[0] - Exit\nOption: ";
            string errorText = "Invalid Option!";
            switch (ReadDigit.Check(menuText, errorText, 3, 600, 8, 4))
            {
                case 1: ListAllProducts(); break;
                case 2: break;
                case 3: AddProduct(); break;
                default: break;
            }
        }

        public static void ListAllProducts()
        {
            var products = Read.ListAll(Program.connectionString);
            foreach (var item in products)
            {
                Console.WriteLine($"     Id #{item.ProductID} - Name: {item.ProductName} - Price: {item.Price}");
            }
        }
    }
}
