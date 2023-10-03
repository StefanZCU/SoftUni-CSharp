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
    , SUM(DepositAmount)
FROM WizzardDeposits
GROUP BY DepositGroup

-- 06. Deposits Sum for Ollivander Family

SELECT
    DepositGroup
    , SUM(DepositAmount)
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup