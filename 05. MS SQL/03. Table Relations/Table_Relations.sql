-- 01. One-To-One Relationship

CREATE TABLE Passports(
    [PassportId] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
    [PassportNumber] VARCHAR(20) NOT NULL
)

CREATE TABLE Persons(
    [PersonID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [FirstName] NVARCHAR(25) NOT NULL,
    [Salary] DECIMAL(18, 2) NOT NULL,
    [PassportID] INT FOREIGN KEY REFERENCES Passports(PassportId) NOT NULL
)

INSERT INTO Passports
VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')

INSERT INTO Persons
VALUES
    ('Roberto', 43300.00, 102),
    ('Tom', 56100.00, 103),
    ('Yana', 60200.00, 101)