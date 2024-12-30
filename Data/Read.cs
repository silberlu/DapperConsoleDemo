using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperConsoleDemo.Models;
using Microsoft.Data.SqlClient;

namespace DapperConsoleDemo.Data
{
  public static class Read
  {
    public static List<Product> ListAll(string connectionString)
    {
      using (var conexao = new SqlConnection(connectionString))
      {
        var products = conexao.Query<Product>(@"SELECT * FROM Product").ToList();
        return products;
      }
    }

    public static List<Product> SearchName(string connectionString, string keyword)
    {
      using (var conexao = new SqlConnection(connectionString))
      {
        string sql = @"SELECT * FROM Product WHERE [Name] LIKE @Keyword";
        var products = conexao.Query<Product>(sql, new { Keyword = "%" + keyword + "%" }).ToList();
        return products;
      }
    }

    public static Product TakeId(string connectionString, int id)
    {
      using (var conexao = new SqlConnection(connectionString))
      {
        string sql = @"SELECT * FROM Product WHERE [Id] LIKE @ProductId";
        var product = conexao.QueryFirstOrDefault<Product>(sql, new { ProductId = id });
        return product;
      }
    }

    public static List<ProductCategory> ListAllCategories(string connectionString)
    {
      using (var conexao = new SqlConnection(connectionString))
      {
        var categories = conexao.Query<ProductCategory>(@"SELECT * FROM ProductCategory").ToList();
        return categories;
      }
    }
  }
}
