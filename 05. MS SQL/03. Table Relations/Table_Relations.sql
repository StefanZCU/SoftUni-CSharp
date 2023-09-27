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

-- 02. One-To-Many Relationship

CREATE TABLE [Manufacturers](
    [ManufacturerID] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(20) NOT NULL,
    [EstablishedOn] DATETIME2 NOT NULL
)

CREATE TABLE [Models](
    [ModelID] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(20) NOT NULL,
    [ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]
VALUES
    ('BMW', '07/03/1916'),
    ('Tesla', '01/01/2003'),
    ('Lada', '01/05/1966')

INSERT INTO [Models]
VALUES
    ('X1', 1),
    ('i6', 1),
    ('Model S', 2),
    ('Model X', 2),
    ('Model 3', 2),
    ('Nova', 3)

-- 03. Many-To-Many Relationship

CREATE TABLE [Students](
    [StudentID] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [Exams](
    [ExamID] INT PRIMARY KEY IDENTITY(101, 1),
    [Name] VARCHAR(20)
)

CREATE TABLE [StudentsExams](
    [StudentID] INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
    [ExamID] INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
    CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO [Students]
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO [Exams]
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO [StudentsExams]
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)


