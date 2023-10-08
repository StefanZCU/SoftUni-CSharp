CREATE DATABASE CigarShop

GO

USE CigarShop

GO

-- 01. DDL

CREATE TABLE Sizes(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Length] INT CHECK(Length BETWEEN 10 AND 25) NOT NULL,
    [RingRange] DECIMAL(2, 1) CHECK(RingRange BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE Tastes(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [TasteType] VARCHAR(20) NOT NULL,
    [TasteStrength] VARCHAR(15) NOT NULL,
    [ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [BrandName] VARCHAR(30) UNIQUE NOT NULL,
    [BrandDescription] VARCHAR(MAX)
)

CREATE TABLE Cigars(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [CigarName] VARCHAR(80) NOT NULL,
    [BrandId] INT FOREIGN KEY REFERENCES Brands([Id]) NOT NULL,
    [TastId] INT FOREIGN KEY REFERENCES Tastes([Id]) NOT NULL,
    [SizeId] INT FOREIGN KEY REFERENCES Sizes([Id]) NOT NULL,
    [PriceForSingleCigar] MONEY NOT NULL,
    [ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Town] VARCHAR(30) NOT NULL,
    [Country] NVARCHAR(30) NOT NULL,
    [Streat] NVARCHAR(100) NOT NULL,
    [ZIP] VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] NVARCHAR(30) NOT NULL,
    [LastName] NVARCHAR(30) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL
)

CREATE TABLE ClientsCigars(
    [ClientId] INT NOT NULL,
    [CigarId] INT NOT NULL,
    CONSTRAINT PK_ClientsCigars PRIMARY KEY (ClientId, CigarId),
    CONSTRAINT FK_ClientsCigars_Client FOREIGN KEY (ClientId) REFERENCES Clients([Id]),
    CONSTRAINT FK_ClientsCigars_Cigar FOREIGN KEY (CigarId) REFERENCES Cigars([Id])
)

-- 02. Insert

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
    ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
    ('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
    ('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.5, 'hoyo-du-maire-stick_17.jpg'),
    ('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
    ('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES
    ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
    ('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
    ('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

-- 03. Update

UPDATE Cigars
SET PriceForSingleCigar += PriceForSingleCigar * 0.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

-- 04. Delete

BEGIN TRANSACTION
DELETE FROM Clients
WHERE AddressId IN
(
    SELECT Id
    FROM Addresses
    WHERE Country LIKE 'C%'
)

DELETE FROM Addresses
WHERE Country LIKE 'C%'
COMMIT TRANSACTION

-- 05. Cigars by Price

SELECT
    CigarName
    , PriceForSingleCigar
    , ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

-- 06. Cigars by Taste

SELECT
    c.Id
    , c.CigarName
    , c.PriceForSingleCigar
    , t.TasteType
    , t.TasteStrength
FROM Cigars AS c
    JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

-- 07. Clients without Cigars

SELECT
    c.Id
    , CONCAT(c.FirstName, ' ', c.LastName) AS [ClientName]
    , c.Email
FROM
    Clients AS c
    LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName

-- 08. First 5 Cigars

SELECT TOP 5
    c.CigarName
    , c.PriceForSingleCigar
    , c.ImageURL
FROM
    Cigars AS c
    JOIN Sizes AS s ON c.SizeId = s.Id
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%'
OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

-- 09. Clients with ZIP Codes

SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS [FullName]
    , a.Country
    , a.ZIP
    , FORMAT(MAX(c2.PriceForSingleCigar), 'C')
FROM
    Clients AS c
    JOIN Addresses AS a ON c.AddressId = a.Id
    JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
    JOIN Cigars AS c2 ON cc.CigarId = c2.Id
WHERE a.ZIP NOT LIKE '%[^0-9.]%'
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), a.Country, a.ZIP
ORDER BY FullName

-- 10. Cigars by Size

SELECT
    c.LastName
    , AVG(s.Length) AS [CigarLength]
    , CEILING(AVG(s.RingRange)) AS [CigarRingRange]
FROM
    Clients AS c
    LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
    JOIN Cigars AS c2 ON cc.CigarId = c2.Id
    JOIN Sizes AS s On c2.SizeId = s.Id
WHERE cc.CigarId IS NOT NULL
GROUP BY c.LastName
ORDER BY CigarLength DESC