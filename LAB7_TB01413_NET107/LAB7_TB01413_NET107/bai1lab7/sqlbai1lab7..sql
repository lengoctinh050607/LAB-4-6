CREATE DATABASE InventoryDb;
GO

USE InventoryDb;
GO

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Color NVARCHAR(50) NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    AvailableQuantity INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT(GETDATE())
);

-- Dữ liệu mẫu
INSERT INTO Products (Name, Category, Color, UnitPrice, AvailableQuantity, CreatedDate)
VALUES (N'Fpoly hcm', N'Cntt', N'Blue', 20.00, 1, '2020-05-17T12:23:48');