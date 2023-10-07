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

-- 06. Pilots and Aircraft

SELECT
    p.FirstName
    , p.LastName
    , a.Manufacturer
    , a.Model
    , a.FlightHours
FROM
    Pilots AS p
    JOIN PilotsAircraft AS pa on p.Id = pa.PilotId
    JOIN Aircraft AS a on pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL AND a.FlightHours <= 304
ORDER BY a.FlightHours DESC, p.FirstName

-- 07. Top 20 Flight Destinations

SELECT TOP 20
    fd.[Id] AS [DestinationId]
    , fd.Start AS [Start]
    , p.FullName
    , a.AirportName
    , fd.TicketPrice
FROM
    FlightDestinations AS fd
    JOIN Airports AS a ON fd.AirportId = a.Id
    JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(DAY, fd.Start) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName

-- 08. Number of Flights for Each Aircraft

SELECT
    a.[Id] AS [AircraftId]
    , a.Manufacturer
    , a.FlightHours
    , COUNT(fd.AircraftId) AS [FlightDestinationsCount]
    , ROUND(AVG(fd.TicketPrice), 2) AS [AvgPrice]
FROM
    Aircraft AS a
    JOIN FlightDestinations AS fd on a.Id = fd.AircraftId
GROUP BY a.[Id], a.Manufacturer, a.FlightHours
HAVING COUNT(fd.AircraftId) >= 2
ORDER BY FlightDestinationsCount DESC, AircraftId

-- 09. Regular Passengers

SELECT
    p.FullName
    , COUNT(fd.PassengerId) AS [CountOfAircraft]
    , SUM(fd.TicketPrice) AS [TotalPayed]
FROM
    Passengers AS p
    JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
WHERE p.FullName LIKE '_a%'
GROUP BY p.FullName
HAVING COUNT(fd.PassengerId) > 1
ORDER BY p.FullName

-- 10. Full Info for Flight Destinations

SELECT
    a2.AirportName
    , fd.Start AS [DayTime]
    , fd.TicketPrice
    , p.FullName
    , a.Manufacturer
    , a.Model
FROM
    FlightDestinations AS fd
    JOIN Aircraft AS a ON fd.AircraftId = a.Id
    JOIN Airports AS a2 ON fd.AirportId = a2.Id
    JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(HOUR, fd.Start) >= 6 AND DATEPART(HOUR, fd.Start) <= 20
AND fd.TicketPrice > 2500
ORDER BY a.Model

-- 11. Find all Destinations by Email Address

CREATE FUNCTION [udf_FlightDestinationsByEmail](@email VARCHAR(50))
RETURNS INT
BEGIN
    DECLARE @countFlights INT = (
            SELECT
                COUNT(*)
            FROM
                Passengers AS p
                JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
            WHERE p.Email = @email
        )
    RETURN @countFlights
end

-- 12. Full Info for Airports

CREATE PROC [usp_SearchByAirportName] (@airportName VARCHAR(70))
AS
BEGIN
    SELECT
        a.AirportName
        , p.FullName
        , CASE
            WHEN fd.TicketPrice <= 400 THEN 'Low'
            WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
            WHEN fd.TicketPrice > 1501 THEN 'High'
        END AS [LevelOfTicketPrice]
        , a2.Manufacturer
        , a2.Condition
        , at.TypeName
    FROM
        Airports AS a
        JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
        JOIN Passengers AS p ON fd.PassengerId = p.Id
        JOIN Aircraft AS a2 ON fd.AircraftId = a2.Id
        JOIN AircraftTypes AS at ON a2.TypeId = at.Id
    WHERE a.AirportName = @airportName
    ORDER BY a2.Manufacturer, p.FullName
end

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'