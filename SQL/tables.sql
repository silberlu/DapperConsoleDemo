CREATE TABLE ProductCategory (
    ProductCategoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductCategoryName NVARCHAR(100),
    Description NVARCHAR(255)
);

CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255),
    BrandName NVARCHAR(100),
    ProductCategoryID INT,
    Price DECIMAL(18, 2),
    StockQuantity INT,
    FOREIGN KEY (ProductCategoryID) REFERENCES ProductCategory(ProductCategoryID)
);
