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