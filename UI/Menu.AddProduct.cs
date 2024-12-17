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

            // Console.SetCursorPosition(7, 3);
            var productPrice = SetPriceOrStock(menuText, 7, 3);
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: {productPrice}\nStock Quantity: \nCategory: ";

            // Console.SetCursorPosition(7, 4);
            var stockQuantity = SetPriceOrStock(menuText, 16, 4);
            menuText = $"ADD PRODUCT\nProduct Name: {productName}\nBrand: {brandName}\nPrice: {productPrice}\nStock Quantity: {stockQuantity}\nCategory: ";
            // string errorText = "Invalid Option!";
            // switch (ReadDigit.Check(menuText, errorText, 2, 600, 8, 4))
            // {
            //     case 1: break;
            //     case 2: break;
            //     case 3: break;
            //     default: break;
            // }
        }

        private static decimal SetPriceOrStock(string menuText, int consolePosLeft, int consolePosTop)
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

        public static int SetCategory(string connectionString, string menuText, int positionLeft, int positionTop)
        {
            var categories = Read.ListAllCategories(connectionString);
            int options = categories.Count;
            Console.Write(menuText);
            int categoryId = ReadDigit.Check(menuText, "Invalid Option!", options, 700, positionLeft, positionTop);



            foreach (var item in categories)
            {
                (int left, int top) = Console.GetCursorPosition();
                int newHorizontalPosition = 10;
                Console.SetCursorPosition(newHorizontalPosition, top);
                Console.WriteLine($"[{item.ProductCategoryID}] - {item.ProductCategoryName}");
            }
            return categoryId;
        }
    }
}
