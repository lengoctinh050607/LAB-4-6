CREATE DATABASE bai2lab8DBO;
GO

USE bai2lab8DBO;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Email NVARCHAR(100) NOT NULL UNIQUE, 
    PhoneNumber NVARCHAR(15) UNIQUE,
    Password NVARCHAR(100) NOT NULL 
);
GO

INSERT INTO Users (Email, PhoneNumber, Password) VALUES 
('admin@gmail.com', '0901234567', '123456'), 
('thepv@gmail.com', '0987654321', 'adminpass');
GO