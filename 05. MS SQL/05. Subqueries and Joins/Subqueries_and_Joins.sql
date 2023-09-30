-- 01. Employee Address

SELECT TOP 5
    e.[EmployeeID]
    , e.[JobTitle]
    , a.AddressID
    , a.AddressText
FROM
    Employees as e JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID