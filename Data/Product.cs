namespace DapperConsoleDemo.Data
{
    public record Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int ProductCategoryID { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product() { }
    }
}
