-- 01. Find Names of All Employees by First Name

SELECT [FirstName], [LastName] FROM Employees
WHERE FirstName LIKE 'Sa%';

-- 02. Find Names of All Employees by Last Name

SELECT [FirstName], [LastName] FROM Employees
WHERE [LastName] LIKE '%ei%';

-- 03. Find First Names of All Employees

SELECT [FirstName] FROM Employees
WHERE [DepartmentID] = 3 OR [DepartmentID] = 10
AND YEAR(HireDate) BETWEEN 1995 AND 2005;

-- 04. Find All Employees Except Engineers

SELECT [FirstName], [LastName] FROM Employees
WHERE [JobTitle] NOT LIKE '%engineer%';

-- 05. Find Towns with Name Length

SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

-- 06. Find Towns Starting With

SELECT * FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 07. Find Towns Not Starting With

SELECT * FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

-- 08. Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName] FROM Employees
WHERE YEAR(HireDate) > 2000

-- 09. Length of Last Name

SELECT [FirstName], [LastName] FROM Employees
WHERE [LastName] LIKE '_____';

-- 10. Rank Employees by Salary

SELECT [EmployeeID]
     , [FirstName]
     , [LastName]
     , [Salary]
     , DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM Employees
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- 11. Find All Employees with Rank 2

SELECT * FROM (
    SELECT [EmployeeID], [FirstName], [LastName], [Salary],
    DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM Employees
)
AS [Selection]
WHERE [Salary] BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY [Salary] DESC

-- 12. Countries Holding 'A' 3 or More Times

USE Geography

GO

SELECT [CountryName] AS [Country Name]
     , [IsoCode] AS [ISO Code]
FROM Countries
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

-- 13. Mix of Peak and River Names

SELECT [PeakName],  [RiverName],
       LOWER(CONCAT(SUBSTRING([PeakName], 1, LEN([PeakName]) - 1), [RiverName])) AS [Mix]
FROM [Peaks], [Rivers]
WHERE RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]