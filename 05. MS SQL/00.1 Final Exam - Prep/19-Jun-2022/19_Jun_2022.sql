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
