CREATE DATABASE Airport

GO

USE Airport

GO

-- 01. DDL

CREATE TABLE Passengers(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FullName] VARCHAR(100) UNIQUE NOT NULL,
    [Email] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [FirstName] VARCHAR(30) UNIQUE NOT NULL,
    [LastName] VARCHAR(30) UNIQUE NOT NULL,
    [Age] TINYINT CHECK (Age >= 21 AND AGE <= 62) NOT NULL,
    [Rating] FLOAT CHECK (Rating >= 0.0 AND Rating <= 10.0)
)

CREATE TABLE AircraftTypes(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [TypeName] VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Manufacturer] VARCHAR(25) NOT NULL,
    [Model] VARCHAR(30) NOT NULL,
    [Year] INT NOT NULL,
    [FlightHours] INT,
    [Condition] CHAR(1) NOT NULL,
    [TypeId] INT FOREIGN KEY REFERENCES AircraftTypes([Id]) NOT NULL
)

CREATE TABLE PilotsAircraft(
    [AircraftId] INT NOT NULL,
    [PilotId] INT NOT NULL,
    CONSTRAINT PK_AircraftsPilots PRIMARY KEY (AircraftId, PilotId),
    CONSTRAINT FK_AircraftsPilots_Aircraft FOREIGN KEY (AircraftId) REFERENCES Aircraft([Id]),
    CONSTRAINT FK_AircraftsPilots_Pilot FOREIGN KEY (PilotId) REFERENCES Pilots([Id])
)

CREATE TABLE Airports(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AirportName] VARCHAR(70) UNIQUE NOT NULL,
    [Country] VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [AirportId] INT FOREIGN KEY REFERENCES Airports([Id]) NOT NULL,
    [Start] DATETIME NOT NULL,
    [AircraftId] INT FOREIGN KEY REFERENCES Aircraft([Id]) NOT NULL,
    [PassengerId] INT FOREIGN KEY REFERENCES Passengers([Id]) NOT NULL,
    [TicketPrice] DECIMAL(16, 2) NOT NULL DEFAULT 15
)

-- 02. Insert

INSERT INTO Passengers
SELECT
    p.FirstName + ' ' + p.LastName,
    p.FirstName + p.LastName + '@gmail.com'
FROM Pilots AS p
WHERE p.Id BETWEEN 5 AND 15

-- 03. Update

UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'C' OR Condition = 'B')
AND (FlightHours IS NULL OR FlightHours <= 100)
AND Year >= 2013

-- 04. Delete

DELETE FROM Passengers WHERE LEN(FullName) <= 10

-- 05. Aircraft

SELECT
    Manufacturer
    , Model
    , FlightHours
    , Condition
FROM Aircraft
ORDER BY FlightHours DESC