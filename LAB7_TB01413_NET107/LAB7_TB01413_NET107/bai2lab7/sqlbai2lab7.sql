
IF DB_ID('lab7bai2') IS NOT NULL
    DROP DATABASE lab7bai2;
GO

CREATE DATABASE lab7bai2;
GO

USE lab7bai2;
GO


CREATE TABLE [dbo].[Products](
    [Id] [int] IDENTITY(1,1) NOT NULL,
     NOT NULL,
    [Price] [decimal](18, 2) NOT NULL,
     NULL,
    [Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) 
);
GO


SET IDENTITY_INSERT [dbo].[Products] ON;
GO

INSERT [dbo].[Products] ([Id], [Name], [Price], [ImageUrl], [Description]) VALUES
(1, N'Accessories', 100.00, N'/images/Accessories.jpg', N'Various camera accessories.'),
(2, N'Cameras', 2500.00, N'/images/Cameras.jpeg', N'Digital & mirrorless cameras.'),
(3, N'Lenses', 900.00, N'/images/leica5.png', N'High quality camera lenses.'),
(4, N'Cases', 120.00, N'/images/cases.jpg', N'Protective cases for cameras.'),
(5, N'Bags', 150.00, N'/images/bags.jpeg', N'Camera bags for travelling.'),
(6, N'Thumbs Up', 90.00, N'/images/Thumbs Up.jpg', N'Thumbs Up grip for better handling.'),
(7, N'Leica S (Typ 006)', 18500.00, N'/images/leica1.jpg', N'Leica S (Typ 006) body, medium format professional camera.'),
(8, N'Leica S (Typ 006) / 70mm Lens Set', 15995.00, N'/images/leica2.jpeg', N'Leica S (Typ 006) body with 70mm Summarit lens set.'),
(9, N'Leica S (Typ 007)', 16900.00, N'/images/007typ.jpeg', N'Leica S (Typ 007) digital medium format camera.'),
(10, N'Leica S and SL Lens Cap E82', 60.00, N'/images/leica4.jpeg', N'Lens cap E82 for Leica S and SL lenses.'),
(11, N'Leica S Edition 100 Set', 34500.00, N'/images/leica3.jpeg', N'Limited Leica S Edition 100 anniversary set.');
GO

SET IDENTITY_INSERT [dbo].[Products] OFF;
GO
PRINT 'Database lab7bai2 và bảng Products đã tạo và chèn dữ liệu thành công!';
