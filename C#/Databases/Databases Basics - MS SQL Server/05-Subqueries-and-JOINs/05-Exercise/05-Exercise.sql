USE SoftUni

GO

exec sp_changedbowner 'sa'

-- Problem 01. Employee Address

SELECT TOP (5)
	EmployeeID,
	JobTitle,
	e.AddressID,
	a.AddressText
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID ASC

-- Problem 02. Addresses with Towns

SELECT TOP (50)
	e.FirstName,
	e.LastName,
	t.[Name] AS Town,
	a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY e.FirstName ASC, e.LastName ASC

-- Problem 03. Sales Employees

SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] LIKE 'Sales'
	ORDER BY e.EmployeeID ASC

-- Problem 04. Employee Departments

SELECT TOP (5) 
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID ASC

-- Problem 05. Employees Without Projects

SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID ASC

-- Problem 06. Employees Hired After

SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Sales', 'Finance')
	WHERE e.HireDate > '1999-01-01'
	ORDER BY e.HireDate ASC

-- Problem 07. Employees With Project


SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID AND p.StartDate > '2002-08-13'
	WHERE p.EndDate IS NULL
	ORDER BY e.EmployeeID ASC

-- Problem 08. Employee 24

SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID AND e.EmployeeID = 24
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID

-- Problem 09. Employee Manager

SELECT 
	e.EmployeeID, 
	e.FirstName, 
	e.ManagerID, 
	m.FirstName AS [ManagerName]
FROM Employees AS e
     JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

-- Problem 10. Employees Summary

SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
	FROM Employees AS e
	LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID ASC

-- Problem 11. Min Average Salary

-- solution #1
SELECT 
	MIN(a.AverageSalary) AS MinAverageSalary
	FROM
	(
	    SELECT AVG(e.Salary) AS AverageSalary
	    FROM Employees AS e
	    GROUP BY e.DepartmentID
	) AS a

-- solution #2
SELECT TOP(1)
	AVG(Salary) AS MinAverageSalary
	FROM Employees AS e
	JOIN Departments as D on d.DepartmentID = e.DepartmentID
	GROUP BY e.DepartmentID
	ORDER BY MinAverageSalary

USE [Geography]

GO

-- Problem 12. Highest Peaks in Bulgaria

SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	JOIN Countries AS c ON mc.CountryCode = c.CountryCode AND c.CountryName = 'Bulgaria'
	WHERE p.Elevation > 2835
	ORDER BY p.Elevation DESC

-- Problem 13. Count Mountain Ranges

-- solution #1
SELECT
	c.CountryCode,
	COUNT(*) AS MountainRanges
	FROM Mountains AS m
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	JOIN Countries AS c ON mc.CountryCode = c.CountryCode AND c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY c.CountryCode

-- solution # 2
SELECT mp.CountryCode, 
       COUNT(mp.MountainId) AS [MountainRanges]
FROM MountainsCountries AS mp
WHERE mp.CountryCode IN('BG', 'RU', 'US')
GROUP BY mp.CountryCode

-- solution # 3 (no group by)

SELECT
	c.CountryCode,
	(SELECT COUNT(mc.CountryCode) FROM MountainsCountries AS mc WHERE c.CountryCode = mc.CountryCode) AS MountainRanges
	FROM Countries AS c
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')

-- Problem 14. Countries With or Without Rivers

SELECT TOP (5)
	c.CountryName,
	r.RiverName
	FROM Rivers AS r
	FULL OUTER JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
	FULL OUTER JOIN Countries AS c ON cr.CountryCode = c.CountryCode 
	WHERE c.ContinentCode IN ('AF')
	ORDER BY c.CountryName ASC

-- Problem 15. Continents and Currencies

SELECT 
	TempResult.ContinentCode,
	TempResult.CurrencyCode,
	TempResult.Total AS CurrencyUsage
	FROM
	(
		SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total,
		DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
			FROM Countries
			GROUP BY ContinentCode, CurrencyCode
	) AS TempResult
	WHERE Ranked = 1 AND Total > 1
	ORDER BY ContinentCode

-- Problem 16. Countries Without any Mountains

SELECT 
	COUNT(*) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE Mc.MountainId IS NULL

-- Problem 17. Highest Peak and Longest River by Country

SELECT TOP (5)
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

-- Problem 18. Highest Peak Name and Elevation by Country

SELECT TOP(5) 
	temp.Country,
	temp.[Highest Peak Name],
	temp.[Highest Peak Elevation],
	temp.Mountain
	FROM
	(
	SELECT 
	c.CountryName AS Country,
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(MAX(p.Elevation),0) AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
	DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	GROUP BY c.CountryName, p.PeakName, m.MountainRange
	) AS temp
	WHERE Ranked = 1
	ORDER BY temp.Country, temp.[Highest Peak Name]
