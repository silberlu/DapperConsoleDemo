using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperConsoleDemo.Data
{
  public static class Create
  {
    public static int NewProduct(string connectionString, string productName, string brandName, int productCategoryID, float price, int stockQuantity)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        int id = connection.ExecuteScalar<int>(@"
                    INSERT INTO [Product]
                        (ProductName, BrandName, ProductCategoryID, Price, StockQuantity)
                    VALUES
                        (@productName, @brandName, @productCategoryID, @price, @stockQuantity);
                    SELECT
                        CAST(scope_identity() AS INT)",
            new { productName, brandName, productCategoryID, price, stockQuantity });
        return id;
      }
    }
  }
}
