-- 01. Create Database

CREATE DATABASE [Minions]
USE [Minions]

GO

-- 02. Create Tables

CREATE TABLE [Minions] (
    [Id] INT PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [Age] INT NOT NULL
);

CREATE TABLE [Towns](
    [Id] INT PRIMARY KEY,
    [Name] NVARCHAR(70) NOT NULL
);

-- 03. Alter Minions Table

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO

-- 04. Insert Records in Both Tables

INSERT INTO [Towns]([Id], [Name])
     VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
     VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

-- 05. Truncate Table Minions

TRUNCATE TABLE [Minions]

-- 06. Drop All Tables

DROP TABLE [Minions]
GO
DROP TABLE [Towns]

-- 07. Create Table People

CREATE TABLE [People]
(
    [Id]        INT IDENTITY (1, 1) PRIMARY KEY,
    [Name]      NVARCHAR(200) NOT NULL,
    [Picture]   IMAGE,
    [Height]    DECIMAL(18, 2),
    [Weight]    DECIMAL(18, 2),
    [Gender]    VARCHAR(1)    NOT NULL,
    CHECK ([Gender] = 'm' OR [Gender] = 'f'),
    [Birthdate] DATE      NOT NULL,
    [Biography] NVARCHAR(MAX)
)


INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
VALUES
    ('Pesho', 1.77, 80, 'm', '2001-08-15'),
    ('Stef', 1.85, 93, 'm', '2001-08-15'),
    ('Kris', 1.87, 87, 'm', '2001-10-11'),
    ('Nataliya', 1.65, 43,  'f', '1974-11-08'),
    ('Vladimir', 1.87, 90, 'm', '1973-08-02')

-- 08. Create Table Users

CREATE TABLE [Users]
(
    [Id] BIGINT IDENTITY(1, 1) PRIMARY KEY,
    [Username] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] IMAGE,
    [LastLoginTime] DATETIME2 NOT NULL,
    [IsDeleted] VARCHAR(5) NOT NULL
        CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
VALUES
    ('krisvl5000', 'stefanegei123', '2023-02-01', 'true'),
    ('stefanzcu', 'krisvlegei123', '2022-05-04', 'false'),
    ('peshotraktora', 'peshoegotin333', '2019-06-09', 'false'),
    ('petio', 'petiomama', '2023-05-06', 'true'),
    ('kakababa', 'mamabrato', '2020-06-08', 'false')


-- 09. Change Primary Key

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC079A5F1B5B

ALTER TABLE [Users]
ADD CONSTRAINT [Pk_Composite]
PRIMARY KEY(Id, [Username])

-- 10. Add Check Constraint

ALTER TABLE [Users]
ADD CHECK (LEN([Password]) >= 5)

-- 11. Set Default Value of a Field

ALTER TABLE [Users]
ADD CONSTRAINT df_LoginTime
DEFAULT GETDATE() FOR [LastLoginTime];

-- 12. Set Unique Field

ALTER TABLE [Users]
DROP CONSTRAINT Pk_Composite

ALTER TABLE [Users]
ADD CONSTRAINT Pk_Id_Only
PRIMARY KEY(Id)

ALTER TABLE [Users]
ADD CONSTRAINT Check_User_Len
CHECK(LEN([Username])>=3)

-- 13. Movie Database


CREATE DATABASE [Movies]
GO

USE [Movies]
GO

CREATE TABLE Directors
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DirectorName VARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Directors]
VALUES
    ('Pesho', 'AAA'),
    ('Gosho', 'BBB'),
    ('Milko', 'CCC'),
    ('Sashka', 'DDD'),
    ('Dimitrichko', 'EEE')

CREATE TABLE Genres
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GenreName VARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Genres]
VALUES
    ('Horror', 'FFFF'),
    ('Thriller', 'DDDDD'),
    ('Comedy', 'AAAAAAAA'),
    ('SitCom', 'DDDDDDD'),
    ('Action', 'bbbb')

CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Categories]
VALUES
    ('A', 'AA'),
    ('B', 'BB'),
    ('C', 'CC'),
    ('D', 'DD'),
    ('E', 'EE')

CREATE TABLE Movies
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , DirectorName VARCHAR(50) NOT NULL
    , DirectorId INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL
    , CopyrightYear DATE NOT NULL
    , Lenght TIME NOT NULL
    , GenreId INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
    , CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
    , Rating DECIMAL(18,2) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Movies]
VALUES
    ('A', 1, '1999-01-01', '01:12:00', 2, 3, 8.0, NULL),
    ('B', 2, '1999-01-01', '02:22:00', 3, 4, 7.5, NULL),
    ('C', 3, '2000-01-01', '03:32:00', 4, 5, 7.0, NULL),
    ('D', 4, '2010-01-01', '04:42:00', 5, 5, 6.0, NULL),
    ('E', 5, '1989-01-01', '05:52:00', 1, 2, 5.5, NULL)

-- 14. Car Rental Database

CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

CREATE TABLE [Categories]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [CategoryName] NVARCHAR(50) NOT NULL,
    [DailyRate] DECIMAL(18, 2) NOT NULL,
    [WeeklyRate] DECIMAL(18, 2) NOT NULL,
    [MonthlyRate] DECIMAL(18, 2) NOT NULL,
    [WeekendRate] DECIMAL(18, 2) NOT NULL
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
    ('A', 1.00, 2.00, 3.00, 4.00),
    ('B', 1.00, 2.00, 3.00, 4.00),
    ('C', 1.00, 2.00, 3.00, 4.00)

CREATE TABLE [Cars]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [PlateNumber] NVARCHAR(50) NOT NULL,
    [Manufacturer] NVARCHAR(50) NOT NULL,
    [Model] NVARCHAR(50) NOT NULL,
    [CarYear] DATE NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
    [Doors] INT,
    [Picture] IMAGE,
    [Condition] NVARCHAR(50) NOT NULL,
    [Available] VARCHAR(5) NOT NULL
        CHECK ([Available] = 'true' OR [Available] = 'false')
)

INSERT INTO [Cars]
    ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Condition], [Available])
VALUES
    ('123AAA', 'BMW', 'X6', '1993-04-01', 1, 'Used', 'true'),
    ('456BBB', 'Audi', 'RS7', '2000-05-06', 2, 'New', 'false'),
    ('789CCC', 'Mercedes', 'S350', '2012-01-04', 3, 'Broken', 'false')


CREATE TABLE [Employees]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title])
VALUES
    ('Stefan', 'Zhivkov', 'CEO'),
    ('Kris', 'Velkov', 'CTO'),
    ('Martin', 'Popov', 'MafiaBoss')

CREATE TABLE [Customers]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [DriverLicenseNumber] INT NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(250) NOT NULL,
    [City] NVARCHAR(100) NOT NULL,
    [ZIPCode] INT NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([DriverLicenseNumber], [FullName], [Address], [City], [ZIPCode])
VALUES
    (123456789, 'Stefcho Popov', 'Ivan Vazov 21', 'Sofia', 1000),
    (987654321, 'Kris Velkov', 'Pangaris Boy 45', 'Budeshte', 1495),
    (767676767, 'Stefan Zhivkov', 'Preslav 5', 'Bojurishte', 4321)

CREATE TABLE [RentalOrders]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
    [CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
    [CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
    [TankLevel] NVARCHAR(50) NOT NULL,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT NOT NULL,
    [TotalKilometrage] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [RateApplied] DECIMAL(18, 2) NOT NULL,
    [TaxRate] DECIMAL(18, 2) NOT NULL,
    [OrderStatus] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)



INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
VALUES
    (1, 3, 2, 100, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending'),
    (2, 1, 1, 90, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending'),
    (3, 2, 3, 50, 20000, 25000, 5000, '2020-10-01', '2022-12-01', 100, 50.0, 10.0, 'Approved')

-- 15. Hotel Database

CREATE DATABASE [Hotel]
GO

USE [Hotel]
GO

CREATE TABLE [Employees]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Title] NVARCHAR(30) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]
VALUES
    ('Gosho', 'Petkanov', 'Shefche', NULL),
    ('Milko', 'Dimitrichkov', 'Debilche', NULL),
    ('Bate', 'Toni', 'SoftUniTO', 'Pichaga :D')

CREATE TABLE [Customers]
(
    [Id] INT IDENTITY(1,1),
    [AccountNumber] NVARCHAR(20) NOT NULL PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [PhoneNumber] INT NOT NULL,
    [EmergencyName] VARCHAR(50) NOT NULL,
    [EmergencyPhone] INT NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]
VALUES
    ('ahdahdahdha', 'Gosho', 'Petkov', 2313, 'Grisho', 13719478, NULL),
    ('jdkljgoru', 'Ivan', 'Draganov', 14141, 'Petko', 123214515, NULL),
    ('tewtwr', 'Petkan', 'Ivanov', 25255, 'Zayo', 1423, NULL)

CREATE TABLE [RoomStatus]
(
    [RoomStatus] VARCHAR(50) NOT NULL PRIMARY KEY,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomStatus]
VALUES
    ('Occupied', NULL),
    ('Free', NULL),
    ('Reserved', NULL)

CREATE TABLE [RoomTypes]
(
    [RoomType] VARCHAR(50) NOT NULL PRIMARY KEY,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomTypes]
VALUES
    ('Double', NULL),
    ('Single', NULL),
    ('Apartment', NULL)

CREATE TABLE [BedTypes]
(
    [BedType] VARCHAR(50) NOT NULL PRIMARY KEY,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [BedTypes]
VALUES
    ('King Size', NULL),
    ('Single Bed', NULL),
    ('Double Bed', NULL)

CREATE TABLE [Rooms]
(
    [RoomNumber] INT NOT NULL PRIMARY KEY IDENTITY,
    [RoomType] VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
    [BedType] VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
    [Rate] INT NOT NULL,
    [RoomStatus] VARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Rooms]
VALUES
    ('Double', 'King Size', 5, 'Free', NULL),
    ('Single', 'Single Bed', 2, 'Reserved', NULL),
    ('Apartment', 'Double Bed', 7, 'Occupied', NULL)

CREATE TABLE [Payments]
(
    [Id] INT IDENTITY PRIMARY KEY NOT NULL,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
    [PaymentDate] DATE NOT NULL,
    [AccountNumber] NVARCHAR(20) FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
    [FirstDateOccupied] DATE NOT NULL,
    [LastDateOccupied] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [AmountCharged] DECIMAL(18,2) NOT NULL,
    [TaxRate] DECIMAL(18,2) NOT NULL,
    [TaxAmount] DECIMAL(18,2) NOT NULL,
    [PaymentTotal] DECIMAL(18,2) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments]
VALUES
    (1, '2023-01-01', 'ahdahdahdha', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL),
    (2, '2023-01-01', 'jdkljgoru', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL),
    (3, '2023-01-01', 'tewtwr', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL)

CREATE TABLE [Occupancies](
    [Id] INT IDENTITY PRIMARY KEY NOT NULL,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
    [DateOccupied] DATE NOT NULL,
    [AccountNumber] NVARCHAR(20) FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
    [RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
    [RateApplied] DECIMAL(18,2) NOT NULL,
    [PhoneCharge] DECIMAL(18,2) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies]
VALUES
(1,'2023-01-01', 'ahdahdahdha', 1, 20.0, 10.0, NULL),
(2,'2023-01-01', 'jdkljgoru', 2, 20.0, 10.0, NULL),
(3,'2023-01-01', 'tewtwr', 3, 20.0, 10.0, NULL)

-- 16. Create SoftUni Database




