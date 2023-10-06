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

-- 02. Insert

INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1, 15, 7),
    ('Paris', 2016, 9.78, 7, 1, 5),
    ('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
    ('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
    ('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers ([Name], AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

-- 03. Update

UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished > 2019

-- 04. Delete

DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1,16,31,47)
DELETE FROM Boardgames WHERE PublisherId IN (1,16)
DELETE FROM Publishers WHERE AddressId IN (5)
DELETE FROM Addresses WHERE Town LIKE 'L%'

-- 05. Boardgames by Year of Publication

SELECT
    [Name]
    , Rating
FROM Boardgames
ORDER BY YearPublished, Name DESC