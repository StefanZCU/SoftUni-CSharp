-- 01. DDL

CREATE DATABASE NationalTouristSitesOfBulgaria

GO

USE NationalTouristSitesOfBulgaria

GO

CREATE TABLE Categories(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [Municipality] VARCHAR(50),
    [Province] VARCHAR(50)
)

CREATE TABLE Sites(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(100) NOT NULL,
    [LocationId] INT FOREIGN KEY REFERENCES Locations([Id]) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
    [Establishment] VARCHAR(15)
)

CREATE TABLE Tourists(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [Age] INT CHECK ([Age] >= 0 AND [Age] <= 120) NOT NULL,
    [PhoneNumber] VARCHAR(20) NOT NULL,
    [Nationality] VARCHAR(30) NOT NULL,
    [Reward] VARCHAR(20)
)

CREATE TABLE SitesTourists(
    [TouristId] INT NOT NULL,
    [SiteId] INT NOT NULL,
    CONSTRAINT PK_TouristsSites PRIMARY KEY (TouristId, SiteId),
    CONSTRAINT FK_TouristsSites_Tourist FOREIGN KEY (TouristId) REFERENCES Tourists([Id]),
    CONSTRAINT FK_TouristsSites_Site FOREIGN KEY (SiteId) REFERENCES Sites([Id])
)

CREATE TABLE BonusPrizes(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
    [TouristId] INT NOT NULL,
    [BonusPrizeId] INT NOT NULL,
    CONSTRAINT PK_TouristsBonusPrizes PRIMARY KEY (TouristId, BonusPrizeId),
    CONSTRAINT FK_TouristsBonusPrizes_Tourist FOREIGN KEY (TouristId) REFERENCES Tourists([Id]),
    CONSTRAINT FK_TouristsBonusPrizes_BonusPrize FOREIGN KEY (BonusPrizeId) REFERENCES BonusPrizes([Id])
)

-- 02. Insert

INSERT INTO Tourists ([Name], Age, PhoneNumber, Nationality, Reward)
VALUES
    ('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
    ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
    ('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
    ('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
    ('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites ([Name], LocationId, CategoryId, Establishment)
VALUES
    ('Ustra fortress', 90, 7, 'X'),
    ('Karlanovo Pyramids', 65, 7, NULL),
    ('The Tomb of Tsar Sevt', 63, 8 , 'V BC'),
    ('Sinite Kamani Natural Park', 17, 1, NULL),
    ('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

-- 03. Update

UPDATE [Sites]
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

-- 04. Delete

DELETE FROM TouristsBonusPrizes WHERE BonusPrizeId = 5
DELETE FROM BonusPrizes WHERE Id = 5

-- 05. Tourists

SELECT
    [Name]
    , Age
    , PhoneNumber
    , Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

-- 06. Sites with Their Location and Category

SELECT
    s.[Name] AS [Site]
    , l.[Name] AS [Location]
    , s.Establishment
    , c.[Name] AS [Category]
FROM Sites AS s
    JOIN Locations AS l ON s.LocationId = l.Id
    JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY Category DESC, Location, Site

-- 07. Count of Sites in Sofia Province

SELECT
    l.Province
    , l.Municipality
    , l.Name AS [Location]
    , COUNT(s.LocationId) AS [CountOfSites]
FROM
    Locations AS l
    JOIN Sites AS s ON l.Id = s.LocationId
WHERE l.Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.Name
ORDER BY CountOfSites DESC, Location

-- 08. Tourist Sites established BC

SELECT
    s.[Name] AS [Site]
    , l.[Name] AS [Location]
    , l.Municipality
    , l.Province
    , s.Establishment
FROM
    Sites AS s
    JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.[Name] NOT LIKE 'B%'
  AND l.[Name] NOT LIKE 'M%'
  AND l.[Name] NOT LIKE 'D%'
AND s.Establishment LIKE '%BC'
ORDER BY s.Name

-- 09. Tourists with their Bonus Prizes

SELECT
    t.[Name]
    , t.Age
    , t.PhoneNumber
    , t.Nationality
    , CASE
        WHEN tbp.BonusPrizeId IS NULL THEN '(no bonus prize)'
        WHEN tbp.BonusPrizeId IS NOT NULL THEN bp.Name
    END
FROM
    Tourists AS t
    LEFT JOIN TouristsBonusPrizes AS tbp on t.Id = tbp.TouristId
    LEFT JOIN BonusPrizes AS bp on tbp.BonusPrizeId = bp.Id
ORDER BY t.[Name]
