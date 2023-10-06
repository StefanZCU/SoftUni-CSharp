-- 01. Database Design

CREATE DATABASE Accounting

GO

USE Accounting

GO

CREATE TABLE Countries(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [StreetName] NVARCHAR(20) NOT NULL,
    [StreetNumber] INT,
    [PostCode] INT NOT NULL,
    [City] VARCHAR(25) NOT NULL,
    [CountryId] INT FOREIGN KEY REFERENCES Countries([Id]) NOT NULL
)

CREATE TABLE Vendors(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(25) NOT NULL,
    [NumberVAT] NVARCHAR(15) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL
)

CREATE TABLE Clients(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(25) NOT NULL,
    [NumberVAT] NVARCHAR(15) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL
)

CREATE TABLE Categories(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(35) NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
    [VendorId] INT FOREIGN KEY REFERENCES Vendors([Id]) NOT NULL
)

CREATE TABLE Invoices(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Number] INT UNIQUE NOT NULL,
    [IssueDate] DATETIME2 NOT NULL,
    [DueDate] DATETIME2 NOT NULL,
    [Amount] DECIMAL(18, 2) NOT NULL,
    [Currency] VARCHAR(5) NOT NULL,
    [ClientId] INT FOREIGN KEY REFERENCES Clients([Id]) NOT NULL
)

CREATE TABLE ProductsClients(
	ProductId INT NOT NULL
	, ClientId INT NOT NULL
	, CONSTRAINT PK_ProductsClients PRIMARY KEY (ProductId, ClientId)
	, CONSTRAINT FK_ProductsClients_Products  FOREIGN KEY (ProductId) REFERENCES Products(Id)
	, CONSTRAINT FK_ProductsClients_Clients  FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

-- 02. Insert

INSERT INTO Products (Name, Price, CategoryId, VendorId)
VALUES
    ('SCANIA Oil Filter XD01', 78.69, 1, 1),
    ('MAN Air Filter XD01', 97.38, 1, 5),
    ('DAF Light Bulb 05FG87', 55.00, 2, 13),
    ('ADR Shoes 47-47.5', 49.85, 3, 5),
    ('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (NUMBER, ISSUEDATE, DUEDATE, AMOUNT, CURRENCY, CLIENTID)
VALUES
    (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
    (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
    (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

-- 03. Update

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11

UPDATE Clients
SET AddressId = 3
WHERE Name LIKE '%CO%'

-- 04. Delete

DELETE FROM ProductsClients WHERE ClientId = 11
DELETE FROM Invoices WHERE ClientId = 11
DELETE FROM Clients WHERE NumberVAT LIKE 'IT%'

-- 05. Invoices by Amount and Date

SELECT
    Number
    , Currency
FROM Invoices
ORDER BY Amount DESC, DueDate

-- 06. Products by Category

SELECT
    p.Id
    , p.Name
    , p.Price
    , c.Name AS [CategoryName]
FROM Products AS p
JOIN Categories AS c on c.Id = p.CategoryId
WHERE c.Name IN ('Others', 'ADR')
ORDER BY p.Price DESC

-- 07. Clients without Products

SELECT
    c.Id AS [Id]
    , c.Name AS [Client]
    , CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', c2.Name) AS [Address]
FROM
    Clients AS c
    LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
    JOIN Addresses AS a ON c.AddressId = a.Id
    Join Countries AS c2 ON a.CountryId = c2.Id
WHERE pc.ProductId IS NULL
ORDER BY c.Name

-- 08. First 7 Invoices

SELECT TOP 7
    i.Number
    , i.Amount
    , c.Name AS [Client]
FROM
    Invoices As i
    JOIN Clients AS c on i.ClientId = c.Id
WHERE IssueDate < '2023-01-01'
AND i.Currency = 'EUR'
OR i.Amount > 500 AND c.NumberVAT LIKE 'DE%'
ORDER BY i.Number, i.Amount DESC

