using System;
using System.Threading;
using DapperConsoleDemo.Data;

namespace DapperConsoleDemo.UI
{
    public static partial class Menu
    {
        public static void AddProduct()
        {
            Console.Clear();
            string menuText = "ADD PRODUCT\nProduct Name: \nBrand: \nPrice: \nStock Quantity: \nCategory: ";
            Console.Write(menuText);
            Console.SetCursorPosition(14, 1);
            string productName = Console.ReadLine();

            Console.SetCursorPosition(7, 2);
            string brandName = Console.ReadLine();
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: \nStock Quantity: \nCategory:";

            var productPrice = SetValues(menuText, 7, 3);
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: {productPrice}\nStock Quantity: \nCategory: ";

            decimal stockQuantity = SetValues(menuText, 16, 4);
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: {productPrice}\nStock Quantity: {stockQuantity}\nCategory: ";

            var categoryId = SetCategory(Program.connectionString, menuText, 10, 5);
            string categoryName = Read.ListAllCategories(Program.connectionString)[categoryId - 1].ProductCategoryName;
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: {productPrice}\nStock Quantity: {stockQuantity}\nCategory: {categoryName}";

            bool loop = false;
            while (!loop)
            {
                Console.Clear();
                Console.WriteLine(menuText);
                Console.WriteLine();
                Console.WriteLine("Confirm product registration? [Y/n]: ");

                Console.SetCursorPosition(37, 7);
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    Create.NewProduct(Program.connectionString, productName, brandName, categoryId, productPrice, stockQuantity);
                    Console.Write("Product registered successfully!\nPress any key to continue...");
                    Console.ReadKey();
                    Menu.Home();
                    loop = true;
                }
                else if (userInput == "n")
                {
                    Console.Write("Product registration canceled!\nPress any key to continue...");
                    Console.ReadKey();
                    Menu.Home();
                    loop = true;
                }
                else
                {
                    Console.SetCursorPosition(37, 7);
                    Console.Write("Invalid Option!");
                    Thread.Sleep(700);
                    Console.Clear();
                }
            }
        }

        private static decimal SetValues(string menuText, int consolePosLeft, int consolePosTop)
        {
            decimal value = 0;
            bool endLoop = false;
            while (!endLoop)
            {
                Console.Clear();
                Console.Write(menuText);
                Console.SetCursorPosition(consolePosLeft, consolePosTop);
                if (!decimal.TryParse(_ = Console.ReadLine(), out decimal varValue))
                {
                    Console.SetCursorPosition(consolePosLeft, consolePosTop);
                    Console.Write("Invalid Value!");
                    Thread.Sleep(650);
                    Console.Clear();
                }
                else
                {
                    value = varValue;
                    endLoop = true;
                }
            }
            return value;
        }

        public static int SetCategory(string connectionString, string menuText, int consolePosLeft, int consolePosTop)
        {
            var categories = Read.ListAllCategories(connectionString);
            int categoryOptions = categories.Count;

            int categoryId = 0;
            bool endLoop = false;
            while (!endLoop)
            {
                Console.Clear();
                Console.WriteLine(menuText + "\n\n     Categories:");
                foreach (var item in categories)
                {
                    (int left, int top) = Console.GetCursorPosition();
                    int newHorizontalPosition = 7;
                    Console.SetCursorPosition(newHorizontalPosition, top);
                    Console.WriteLine($"[{item.ProductCategoryID}] - {item.ProductCategoryName}");
                }

                Console.SetCursorPosition(consolePosLeft, consolePosTop);

                if (!int.TryParse(_ = Console.ReadLine(), out int option) || option < 1 || option > categoryOptions)
                {
                    Console.SetCursorPosition(consolePosLeft, consolePosTop);
                    Console.Write("Invalid Option!");
                    Thread.Sleep(650);
                    Console.Clear();
                }
                else
                {
                    categoryId = option;
                    endLoop = true;
                }
            }
            return categoryId;
        }
    }
}
