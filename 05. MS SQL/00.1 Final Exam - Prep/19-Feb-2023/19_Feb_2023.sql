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

-- 06. Boardgames by Category

SELECT
    b.Id
    , b.[Name]
    , b.YearPublished
    , c.Name AS [CategoryName]
FROM Boardgames AS b
    JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

-- 07. Creators without Boardgames

SELECT
    c.Id
    , CONCAT(c.FirstName, ' ', c.LastName) AS [CreatorName]
    , c.Email
FROM Creators AS c
    LEFT JOIN CreatorsBoardgames AS cb on c.Id = cb.CreatorId
WHERE cb.BoardgameId IS NULL
ORDER BY CreatorName

-- 08. First 5 Boardgames

SELECT TOP 5
    bg.Name
    , bg.Rating
    , c.Name AS [CategoryName]
FROM Boardgames AS bg
    JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
    JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE bg.Rating > 7.00 AND bg.Name LIKE '%a%'
OR bg.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY bg.Name, bg.Rating DESC

-- 09. Creators with Emails

SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS [FullName]
    , c.Email
    , MAX(bg.Rating) AS [Rating]
FROM Creators AS c
    JOIN CreatorsBoardgames AS cb on c.Id = cb.CreatorId
    JOIN Boardgames AS bg on cb.BoardgameId = bg.Id
WHERE c.Email LIKE '%.com'
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), c.Email
ORDER BY [FullName]

-- 10. Creators by Rating

SELECT
    c.LastName
    , CEILING(AVG(bg.Rating)) AS [AverageRating]
    , p.Name AS [PublisherName]
FROM
    Creators AS c
    LEFT JOIN CreatorsBoardgames AS cbg on c.Id = cbg.CreatorId
    JOIN Boardgames AS bg on cbg.BoardgameId = bg.Id
    JOIN Publishers AS p on bg.PublisherId = p.Id
WHERE p.Name = 'Stonemaier Games'
GROUP BY c.LastName, p.Name
ORDER BY AVG(bg.Rating) DESC

-- 11. Creator with Boardgames

CREATE FUNCTION [udf_CreatorWithBoardgames](@name NVARCHAR(30))
RETURNS INT
BEGIN
    DECLARE @totalNumberBoardgames INT = (
        SELECT
            COUNT(*)
        FROM
            Creators AS c
            JOIN CreatorsBoardgames AS cb on c.Id = cb.CreatorId
        WHERE c.FirstName = @name
    )
    RETURN @totalNumberBoardgames
end

-- 12. Search for Boardgame with Specific Category

CREATE PROC [usp_SearchByCategory](@category VARCHAR(50))
AS
BEGIN
    SELECT
        bg.Name
        , bg.YearPublished
        , bg.Rating
        , c.Name AS [CategoryName]
        , p.Name AS [PublisherName]
        , CONCAT(pr.PlayersMin, ' people') AS [MinPlayers]
        , CONCAT(pr.PlayersMax, ' people') AS [MaxPlayers]
    FROM Boardgames AS bg
        JOIN Categories AS c ON bg.CategoryId = c.Id
        JOIN Publishers AS p ON bg.PublisherId = p.Id
        JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
    WHERE c.Name = @category
    ORDER BY PublisherName, YearPublished DESC
end