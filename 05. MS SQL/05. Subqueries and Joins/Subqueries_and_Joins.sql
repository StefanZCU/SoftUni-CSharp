-- 01. Employee Address

SELECT TOP 5
    e.[EmployeeID]
    , e.[JobTitle]
    , a.AddressID
    , a.AddressText
FROM
    Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- 02. Addresses with Towns

SELECT TOP 50
    e.FirstName
    , e.LastName
    , t.[Name] AS Town
    , a.AddressText
FROM
    Employees AS e
        JOIN Addresses as a ON e.AddressID = a.AddressID
        JOIN Towns as t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- 03. Sales Employees

SELECT
    e.EmployeeID
    , e.FirstName
    , e.LastName
    , d.Name AS [DepartmentName]
FROM
    Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- 04. Employee Departments

SELECT TOP 5
    e.EmployeeID
    , e.FirstName
    , e.Salary
    , d.Name AS [DepartmentName]
FROM
    Employees AS e JOIN Departments AS D ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

-- 05. Employees Without Projects

SELECT TOP 3
    e.EmployeeID
    , e.FirstName
FROM
    Employees AS e LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

-- 06. Employees Hired After

SELECT
    e.FirstName
    , e.LastName
    , e.HireDate
    , d.Name AS [DeptName]
FROM
    Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-1-1'
AND d.Name = 'Sales' OR d.Name = 'Finance'
ORDER BY e.HireDate

-- 07. Employees With Project

SELECT TOP 5
    e.EmployeeID
    , e.FirstName
    , p.Name AS [ProjectName]
FROM
    Employees AS e
        JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
        JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- 08. Employee 24

SELECT
    e.EmployeeID
    , e.FirstName
    , IIF(DATEPART(YEAR, p.StartDate) < 2005, p.Name, NULL) AS [ProjectName]
FROM
    Employees AS e
        JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
        JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- 09. Employee Manager

SELECT
    e.EmployeeID
    , e.FirstName
    , e.ManagerID
    , e2.FirstName AS ManagerName
FROM
    Employees AS e JOIN Employees AS e2 ON e.ManagerID = e2.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- 10. Employees Summary

SELECT TOP 50
    e1.EmployeeID
    , CONCAT(e1.FirstName, ' ', e1.LastName) AS [EmployeeName]
    , CONCAT(e2.FirstName, ' ', e2.LastName) AS [ManagerName]
    , d.[Name] AS [DepartmentName]
FROM
    Employees AS e1
        JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
        JOIN Departments AS d ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID

-- 11. Min Average Salary

SELECT
	MIN(a.AverageSalary) AS MinAverageSalary
FROM
(
	SELECT
		e.[DepartmentID],
		AVG(e.[Salary]) AS [AverageSalary]
	FROM [Employees] AS [e]
	GROUP BY e.[DepartmentID]
) AS [a]

-- 12. Highest Peaks in Bulgaria

USE Geography

SELECT
    mc.CountryCode
    , m.MountainRange
    , p.PeakName
    , p.Elevation
FROM
    Peaks AS p
    JOIN MountainsCountries AS mc ON p.MountainId = mc.MountainId
    JOIN Mountains AS m ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges

SELECT
    mc.CountryCode,
    COUNT(mc.CountryCode)
FROM MountainsCountries as mc
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode

-- 14. Countries With or Without Rivers

SELECT TOP 5
    c.CountryName
    , r.RiverName
FROM
    Countries AS c
    LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
    LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15. Continents and Currencies

SELECT
	r.ContinentCode,
	r.CurrencyCode,
	r.CurrencyUsage
FROM
(
	SELECT
      c.[ContinentCode],
	  c.[CurrencyCode],
	  COUNT(c.[CurrencyCode]) AS [CurrencyUsage],
	  DENSE_RANK() OVER
	  (
		PARTITION BY c.[ContinentCode]
		ORDER BY COUNT(c.[CurrencyCode]) DESC
	  ) AS [CurrencyRank]
	  FROM [Countries] AS [c]
	  GROUP BY c.[ContinentCode],c.[CurrencyCode]
	  HAVING COUNT(c.[CurrencyCode]) > 1
) AS r
WHERE r.CurrencyRank = 1
ORDER BY r.ContinentCode

-- 16. Countries Without any Mountains

SELECT
    COUNT(c.CountryCode) AS Count
FROM
    Countries AS c
    LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

-- 17. Highest Peak and Longest River by Country

SELECT TOP 5
    c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.Length) AS [LongestRiverLength]
FROM
    Countries AS c
    FULL JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    FULL JOIN Peaks AS p ON mc.MountainId = p.MountainId
    FULL JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
    FULL JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

-- 18. Highest Peak Name and Elevation by Country

SELECT TOP(5)
	[Country],
	CASE
		WHEN [PeakName] IS NULL THEN '(no highest peak)'
		ELSE [PeakName]
	END AS [Highest Peak Name],
	CASE
		WHEN [Elevation] IS NULL THEN 0
		ELSE [Elevation]
	END AS [Highest Peak Elevation],
	CASE
		WHEN [MountainRange] IS NULL THEN '(no mountain)'
		ELSE [MountainRange]
	END AS [Mountain]

FROM
(
	SELECT
		c.[CountryName] AS [Country],
		m.[MountainRange],
		p.[PeakName],
		p.[Elevation],
		DENSE_RANK() OVER
		(
			PARTITION BY c.[CountryName]
			ORDER BY p.[Elevation] DESC
		) AS [PeakRank]
	FROM [Countries] AS [c]
	LEFT JOIN [MountainsCountries] AS [mc]
		ON mc.[CountryCode] = c.[CountryCode]
	LEFT JOIN [Mountains] AS [m]
		ON mc.[MountainId] = m.[Id]
	LEFT JOIN [Peaks] AS [p]
		ON p.[MountainId] = m.[Id]
) AS [PeakRankingTable]
WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]

