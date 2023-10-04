-- 01. Employees with Salary Above 35000

CREATE PROC [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
    SELECT
        FirstName
        , LastName
    FROM Employees
    WHERE Salary > 35000
END

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

-- 02. Employees with Salary Above Number

CREATE PROC [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18, 4)
AS
BEGIN
    SELECT
        FirstName
        , LastName
    FROM Employees
    WHERE Salary >= @minSalary
end

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100

-- 03. Town Names Starting With

CREATE PROC [usp_GetTownsStartingWith] @startsWithString VARCHAR(10)
AS
BEGIN
    SELECT
        Name AS [Town]
    FROM Towns
    WHERE UPPER(SUBSTRING(Name, 1, LEN(@startsWithString))) = UPPER(@startsWithString)
end

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

-- 04. Employees from Town

CREATE PROC [usp_GetEmployeesFromTown] @townName VARCHAR(50)
AS
BEGIN
    SELECT
        e.FirstName
        , e.LastName
    FROM Employees AS e
    JOIN Addresses AS a ON e.AddressID = a.AddressID
    JOIN Towns AS t ON a.TownID = t.TownID
    WHERE t.Name = @townName
end

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'

-- 05. Salary Level Function

CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
BEGIN
    RETURN CASE
        WHEN @salary < 30000 THEN 'Low'
        WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
        WHEN @salary > 50000 THEN 'High'
    END
end

EXEC [dbo].[ufn_GetSalaryLevel] 13500.00

-- 06. Employees by Salary Level

CREATE PROC [usp_EmployeesBySalaryLevel] @levelOfSalary VARCHAR(10)
AS
BEGIN
    SELECT
        FirstName
        , LastName
    FROM Employees
    WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @levelOfSalary
end

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'

