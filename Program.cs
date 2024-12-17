using System;
using DapperConsoleDemo.UI;
using DapperConsoleDemo.Data;

namespace DapperConsoleDemo;

class Program
{
    public static string connectionString = "Server=localhost,1433;Database=DapperConsoleDemo;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        Menu.Home();
    }
}
