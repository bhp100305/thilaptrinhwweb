CREATE DATABASE BuiiHuyPhu_231230867_de02;
GO

USE BuiiHuyPhu_231230867_de02;
GO

CREATE TABLE BhpCatalog (
    hvtId INT IDENTITY(1,1) PRIMARY KEY,
    hvtCateName NVARCHAR(100) NOT NULL,
    hvtCatePrice INT CHECK (hvtCatePrice BETWEEN 100 AND 5000),
    hvtCateQty INT NOT NULL,
    hvtPicture NVARCHAR(255),
    hvtCateActive BIT
);
GO
