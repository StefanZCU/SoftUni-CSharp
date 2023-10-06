-- 01. DDL

CREATE DATABASE [BoardGames]

GO

USE [BoardGames]

GO

CREATE TABLE Categories(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [StreetName] NVARCHAR(100) NOT NULL,
    [StreetNumber] INT NOT NULL,
    [Town] VARCHAR(30) NOT NULL,
    [Country] VARCHAR(50) NOT NULL,
    [ZIP] INT NOT NULL
)

CREATE TABLE Publishers(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(30) UNIQUE NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL,
    [Website] NVARCHAR(40),
    [Phone] NVARCHAR(20)
)

CREATE TABLE PlayersRanges(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [PlayersMin] INT NOT NULL,
    [PlayersMax] INT NOT NULL
)

CREATE TABLE Boardgames(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(30) NOT NULL,
    [YearPublished] INT NOT NULL,
    [Rating] DECIMAL(3, 2) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
    [PublisherId] INT FOREIGN KEY REFERENCES Publishers([Id]) NOT NULL,
    [PlayersRangeId] INT FOREIGN KEY REFERENCES PlayersRanges([Id]) NOT NULL
)

CREATE TABLE Creators(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(30) NOT NULL,
    [LastName] NVARCHAR(30) NOT NULL,
    [Email] NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames(
    [CreatorId] INT NOT NULL,
    [BoardgameId] INT NOT NULL,
    CONSTRAINT PK_CreatorsBoardgames PRIMARY KEY (CreatorId, BoardgameId),
    CONSTRAINT FK_CreatorsBoardgames_Creators FOREIGN KEY (CreatorId) REFERENCES Creators([Id]),
    CONSTRAINT FK_CreatorsBoardgames_Boardgames FOREIGN KEY (BoardGameId) REFERENCES Boardgames([Id])
)