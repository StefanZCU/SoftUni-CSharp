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