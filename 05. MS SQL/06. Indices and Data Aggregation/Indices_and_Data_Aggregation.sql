-- 01. Records’ Count

SELECT COUNT(*) AS Count
FROM WizzardDeposits

-- 02. Longest Magic Wand

SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

-- 03. Longest Magic Wand per Deposit Groups

SELECT
    DepositGroup
    , MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04. Smallest Deposit Group per Magic Wand Size *

SELECT TOP 2
    DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- 05. Deposits Sum

SELECT
    DepositGroup
    , SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

-- 06. Deposits Sum for Ollivander Family

SELECT
    DepositGroup
    , SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07. Deposits Filter

SELECT
    DepositGroup
    , SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 08. Deposit Charge

SELECT
    DepositGroup
    , MagicWandCreator
    , MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- 09. Age Groups

SELECT
    [AgeGroup]
    , COUNT([AgeGroup]) AS [WizardCount]
FROM
(
    SELECT
    CASE
        WHEN [Age] <= 10 THEN '[0-10]'
        WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
        WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
        WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
        WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
        WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
        WHEN [Age] > 60 THEN '[61+]'
    END AS [AgeGroup]
FROM WizzardDeposits
    ) AS w
GROUP BY [AgeGroup]

-- 10. First Letter

SELECT
    SUBSTRING(FirstName, 1, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)
ORDER BY FirstLetter

-- 11. Average Interest

SELECT
    DepositGroup
    , IsDepositExpired
    , AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12. Rich Wizard, Poor Wizard *

SELECT
    SUM(wizz1.DepositAmount - wizz2.DepositAmount) AS [SumDifference]
FROM WizzardDeposits AS [wizz1]
LEFT JOIN WizzardDeposits AS [wizz2] ON wizz1.Id = wizz2.Id - 1

-- 13. Departments Total Salaries

USE SoftUni

SELECT
    DepartmentID
    , SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14. Employees Minimum Salaries

SELECT
    DepartmentID
    , MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
  AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- 15. Employees Average Salaries

SELECT * INTO [TemporaryTable]
FROM Employees
WHERE Salary > 30000

DELETE
FROM [TemporaryTable]
WHERE ManagerID = 42

UPDATE [TemporaryTable]
SET Salary += 5000
WHERE DepartmentID = 1

SELECT
    DepartmentID
    , AVG(Salary) AS [AverageSalary]
FROM TemporaryTable
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries

SELECT
    *
FROM(
SELECT
    DepartmentID
    , MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID) AS dt
WHERE dt.MaxSalary > 70000 OR dt.MaxSalary < 30000

-- 17. Employees Count Salaries

SELECT
    COUNT(SALARY) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- 18. 3rd Highest Salary

SELECT [DepartmentID]
     , MAX([Salary]) AS [ThirdHighestSalary]
FROM
    (SELECT [DepartmentID]
            , [Salary]
            , DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC ) AS [ThirdHighestSalary]
    FROM Employees
    ) AS [sal]
WHERE ThirdHighestSalary = 3
GROUP BY [DepartmentID]
