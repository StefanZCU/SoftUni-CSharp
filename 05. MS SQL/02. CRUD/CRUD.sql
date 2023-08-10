-- 01. Examine the Databases

-- 02. Find All the Information About Departments

SELECT * FROM [Departments]

-- 03. Find all Department Names

SELECT [Name] FROM [Departments]

-- 04. Find Salary of Each Employee

SELECT [FirstName], [LastName], [Salary] FROM [Employees]

-- 05. Find Full Name of Each Employee

SELECT [FirstName], [MiddleName], [LastName] FROM [Employees]

-- 06. Find Email Address of Each Employee

SELECT
    CONCAT([FirstName],'.', [LastName],'@softuni.bg') AS 'Full Email Address'
FROM [Employees]

-- 07. Find All Different Employee’s Salaries

SELECT DISTINCT
    [Salary] AS 'Salary'
FROM [Employees]

-- 08. Find all Information About Employees

SELECT * FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

-- 09. Find Names of All Employees by Salary in Range

SELECT
    [FirstName]
    ,[LastName]
    ,[JobTitle]
FROM [Employees]
WHERE
    [Salary] >= 20000
    AND [Salary] <= 30000

-- 10. Find Names of All Employees

SELECT
    CONCAT([FirstName],' ', [MiddleName], ' ', [LastName]) AS [Full Name]
FROM [Employees]
WHERE
    [Salary] = 25000
    OR [Salary] = 14000
    OR [Salary] = 12500
    OR [Salary] = 23600


-- 11. Find All Employees Without Manager

SELECT
    [FirstName]
    , [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL

-- 12. Find All Employees with Salary More Than 50000

SELECT
    [FirstName]
    ,[LastName]
    ,[Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC
