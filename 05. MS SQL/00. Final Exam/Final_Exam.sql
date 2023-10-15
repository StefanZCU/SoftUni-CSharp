-- 01. DDL

CREATE DATABASE TouristAgency

GO

USE TouristAgency

GO

CREATE TABLE Countries(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [CountryId] INT FOREIGN KEY REFERENCES Countries([Id]) NOT NULL
)

CREATE TABLE Rooms(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Type] VARCHAR(40) NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [BedCount] INT CHECK (BedCount > 0 AND BedCount <= 10) NOT NULL
)

CREATE TABLE Hotels(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(50) NOT NULL,
    [DestinationId] INT FOREIGN KEY REFERENCES Destinations([Id]) NOT NULL
)

CREATE TABLE Tourists(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [PhoneNumber] VARCHAR(20) NOT NULL,
    [Email] VARCHAR(80),
    [CountryId] INT FOREIGN KEY REFERENCES Countries([Id]) NOT NULL
)

CREATE TABLE Bookings(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [ArrivalDate] DATETIME2 NOT NULL,
    [DepartureDate] DATETIME2 NOT NULL,
    [AdultsCount] INT CHECK(AdultsCount >= 1 AND AdultsCount <= 10) NOT NULL,
    [ChildrenCount] INT CHECK(ChildrenCount >= 0 AND ChildrenCount <= 9) NOT NULL,
    [TouristId] INT FOREIGN KEY REFERENCES Tourists([Id]) NOT NULL,
    [HotelId] INT FOREIGN KEY REFERENCES Hotels([Id]) NOT NULL,
    [RoomId] INT FOREIGN KEY REFERENCES Rooms([Id]) NOT NULL
)

CREATE TABLE HotelsRooms(
    [HotelId] INT NOT NULL,
    [RoomId] INT NOT NULL,
    CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId, RoomId),
    CONSTRAINT FK_HotelsRooms_Hotel FOREIGN KEY (HotelId) REFERENCES Hotels([Id]),
    CONSTRAINT FK_HotelsRooms_Room FOREIGN KEY (RoomId) REFERENCES Rooms([Id])
)

-- 02. Insert

INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

-- 03. Update

--We've decided to change the departure date of the bookings that are scheduled to arrive in December 2023. The updated departure date for these bookings should be set to one day later than their original departure date.
--We need to update the email addresses of tourists, whose names contain "MA". The new value of their email addresses should be set to NULL.


UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE YEAR(DepartureDate) = 2023 AND MONTH(DepartureDate) = 12

UPDATE Tourists
SET Email = NULL
WHERE Email LIKE '%MA%'

-- 04. Delete

-- In table Tourists, delete every tourist, whose Name contains family name "Smith". Keep in mind that there could be foreign key constraint conflicts.

DECLARE @touristsToDelete TABLE (TouristId INT)

INSERT INTO @touristsToDelete (TouristId)
SELECT
    [Id]
FROM Tourists
WHERE Name LIKE '%Smith'

DELETE FROM Bookings WHERE TouristId IN (SELECT TouristId FROM @touristsToDelete)
DELETE FROM Tourists WHERE Id IN (SELECT TouristId FROM @touristsToDelete)


-- 05. Bookings by Price of Room and Arrival Date

-- Select all bookings, ordered by price  of room (descending), then by arrival date (ascending). The arrival date should be formatted in the 'yyyy-MM-dd' format in the query results.
-- Required columns:
-- •	ArrivalDate
-- •	AdultsCount
-- •	ChildrenCount

SELECT
    FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS [ArrivalDate]
    , b.AdultsCount
    , b.ChildrenCount
FROM Bookings as b
    JOIN Rooms AS r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate

-- 06. Hotels by Count of Bookings

--Select all hotels with "VIP Apartment" available. Order results by the count of bookings (count of all bookings for the specific hotel, not only for VIP apartment) made for every hotel (descending).
--Required columns:
--•	Id
--•	Name


SELECT
    h.Id
    , h.[Name]
FROM
    Hotels AS h
    LEFT JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
    LEFT JOIN Rooms AS r ON hr.RoomId = r.Id
    LEFT JOIN Bookings AS b ON h.Id = b.HotelId
WHERE r.Type = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(b.Id) DESC

-- 07. Tourists without Bookings

-- Select all tourists that haven’t booked a hotel yet. Order them by name (ascending).
-- Required columns:
-- •	Id
-- •	Name
-- •	PhoneNumber

SELECT
    t.Id
    , t.[Name]
    , t.PhoneNumber
FROM Tourists AS t
    LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE b.Id IS NULL
ORDER BY t.[Name]

-- 08. First 10 Bookings

-- Select the first 10 bookings that will arrive before 2023-12-31. You will need to select the bookings in hotels with odd-numbered IDs. Sort the results in ascending order, first by CountryName, and then by ArrivalDate.
-- Required columns:
-- •	HotelName
-- •	DestinationName
-- •	CountryName

SELECT TOP 10
    h.[Name] AS [HotelName]
    , d.[Name] AS [DestinationName]
    , c.[Name] AS [CountryName]
FROM
    Bookings AS b
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN Destinations AS d ON h.DestinationId = d.Id
    JOIN Countries AS c ON d.CountryId = c.Id
WHERE b.ArrivalDate < '2023-12-31'
AND h.Id % 2 = 1
ORDER BY c.[Name], b.ArrivalDate

-- 09. Tourists booked in Hotels

-- Select all of the tourists that have a name, not ending in "EZ", and display the names of the hotels, that they have booked a room in. Order by the price of the room (descending).
-- Required columns:
-- •	HotelName
-- •	RoomPrice

SELECT
    h.[Name] AS [HotelName]
    , r.Price AS [RoomPrice]
FROM
    Tourists AS t
    JOIN Bookings AS b ON t.Id = b.TouristId
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN Rooms AS r ON b.RoomId = r.Id
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC

-- 10. Hotels Revenue

-- In this task, you will write an SQL query to calculate the total price of all bookings for each hotel based on the room price and the number of nights guests have stayed. The result should list the hotel names and their corresponding revenue.
-- •	Foreach Booking you should join data for the Hotel and the Room, using the Id references;
-- •	NightsCount – you will need the ArrivalDate and DepartureDate for a DATEDIFF function;
-- •	Calculate the TotalRevenue by summing the price of each booking, using Price of the Room that is referenced to the specific Booking and multiply it by the NightsCount.
-- •	Group all the bookings by HotelName using the reference to the Hotel.
-- •	Order the results by TotalRevenue in descending order.
-- Required columns:
-- •	HotelName
-- •	TotalRevenue

SELECT
    h.[Name] AS [HotelName]
    , SUM(r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS [HotelRevenue]
FROM
    Hotels AS h
    JOIN Bookings AS b ON h.Id = b.HotelId
    JOIN Rooms AS r ON b.RoomId = r.Id
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC

-- 11. Rooms with Tourists

-- Create a user-defined function, named udf_RoomsWithTourists(@name) that receives a room's type.
-- The function should return the total number of tourists that the specific room type has been booked for (adults + children).
-- Hint: A Double Room could be booked for: 2 adults + 0 children, 1 adult + 1 children, 1 adult + 0 children.

CREATE FUNCTION [udf_RoomsWithTourists](@name VARCHAR(40))
RETURNS INT
BEGIN
    DECLARE @countTourists INT = (
            SELECT
                SUM(b.AdultsCount + b.ChildrenCount)
            FROM Rooms AS r
                JOIN Bookings AS b ON r.Id = b.RoomId
            WHERE r.Type = @name
        )
    RETURN @countTourists
end

-- 12. Search for Tourists from a Specific Country

-- Create a stored procedure, named usp_SearchByCountry(@country) that receives a country name.
-- The procedure must print full information about all tourists that have an booked a room and have origin from the given country:
-- Name, PhoneNumber, Email and CountOfBookings (the count of all bookings made).
-- Order them by Name (ascending) and CountOfBookings (descending).

CREATE PROC [usp_SearchByCountry](@country NVARCHAR(50))
AS
BEGIN
    SELECT
        t.[Name]
        , t.PhoneNumber
        , t.Email
        , COUNT(b.TouristId) AS [CountOfBookings]
    FROM
        Tourists AS t
        JOIN Countries AS c ON t.CountryId = c.Id
        JOIN Bookings AS b ON t.Id = b.TouristId
    WHERE c.[Name] = @country
    GROUP BY t.[Name], t.PhoneNumber, t.Email
end