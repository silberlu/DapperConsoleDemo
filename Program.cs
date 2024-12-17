using System;
using DapperConsoleDemo.UI;
using DapperConsoleDemo.Data;

namespace DapperConsoleDemo;

class Program
{
    public record ProductCategory(string ProductCategoryName, string Description);

    public record Product(string ProductName, string BrandName, int ProductCategoryID, decimal Price, int StockQuantity);

    public static string connectionString = "Server=localhost,1433;Database=DapperConsoleDemo;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        // Menu.Home();
        var newProduct = Create.NewProduct(connectionString, "G733 Lightspeed Wireless Gaming Headset", "Logitech", 2, 145.99m, 77);
        Console.WriteLine($"Produto Registrado: Id #{newProduct}");
    }
}
