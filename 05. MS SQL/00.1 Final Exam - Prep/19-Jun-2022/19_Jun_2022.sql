-- 01. DDL

CREATE DATABASE Zoo
GO

USE Zoo
GO

CREATE TABLE Owners(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AnimalTypeId] INT FOREIGN KEY REFERENCES AnimalTypes([Id]) NOT NULL
)

CREATE TABLE Animals(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(30) NOT NULL,
    [BirthDate] Date NOT NULL,
    [OwnerId] INT FOREIGN KEY REFERENCES Owners([Id]),
    [AnimalTypeId] INT FOREIGN KEY REFERENCES AnimalTypes([Id]) NOT NULL
)

CREATE TABLE AnimalsCages(
    [CageId] INT NOT NULL,
    [AnimalId] INT NOT NULL,
    CONSTRAINT PK_CagesAnimals PRIMARY KEY ([CageId], [AnimalId]),
    CONSTRAINT FK_CagesAnimals_Cage FOREIGN KEY (CageId) REFERENCES Cages([Id]),
    CONSTRAINT FK_CagesAnimals_Animals FOREIGN KEY (AnimalId) REFERENCES Animals([Id])
)

CREATE TABLE VolunteersDepartments(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50),
    [AnimalId] INT FOREIGN KEY REFERENCES Animals([Id]),
    [DepartmentId] INT FOREIGN KEY REFERENCES VolunteersDepartments([Id]) NOT NULL
)

-- 02. Insert

INSERT INTO Volunteers ([Name], PhoneNumber, Address, AnimalId, DepartmentId)
VALUES
    ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
    ('Dimitur Stoev', '0877564223', NULL, 42, 4),
    ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
    ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
    ('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals ([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES
    ('Giraffe', '2018-09-21', 21, 1),
    ('Harpy Eagle', '2015-04-17', 15, 3),
    ('Hamadryas Baboon', '2017-11-02', NULL, 1),
    ('Tuatara', '2021-06-30', 2, 4)

-- 03. Update

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

-- 04. Delete

DELETE FROM Volunteers WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant'

-- 05. Volunteers

SELECT
    [Name]
    , PhoneNumber
    , Address
    , AnimalId
    , DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

-- 06. Animals data

SELECT
    a.[Name]
    , at.AnimalType
    , CONVERT(varchar, a.BirthDate, 104)
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
ORDER BY a.[Name]

-- 07. Owners and Their Animals

SELECT TOP 5
    o.[Name] AS [Owner]
    , COUNT(a.OwnerId) AS [CountOfAnimals]
FROM
    Owners AS o
    JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, Owner
