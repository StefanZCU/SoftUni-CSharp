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