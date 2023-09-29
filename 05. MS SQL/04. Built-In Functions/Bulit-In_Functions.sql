-- 01. Find Names of All Employees by First Name

SELECT [FirstName], [LastName] FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 02. Find Names of All Employees by Last Name

SELECT [FirstName], [LastName] FROM Employees
WHERE [LastName] LIKE '%ei%'