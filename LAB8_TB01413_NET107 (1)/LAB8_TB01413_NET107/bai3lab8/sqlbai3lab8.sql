
CREATE DATABASE bai3lab8;
GO

USE bai3lab8;
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE, 
    Password NVARCHAR(100) NOT NULL 
);
GO
INSERT INTO Users (Username, Password) VALUES 
('cookie_tester', '123456'), 
('user_cookie', 'pass123');
GO