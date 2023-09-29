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
