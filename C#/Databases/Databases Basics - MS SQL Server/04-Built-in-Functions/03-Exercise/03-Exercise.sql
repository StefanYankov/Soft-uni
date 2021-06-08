-- -- Part I – Queries for SoftUni Database

USE Softuni

-- 01 Find Names of All Employees by First Name

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'SA%'

-- 02 Find Names of All employees by Last Name 

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03 Find First Names of All Employees

SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND (DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005)

-- 04 Find All Employees Except Engineers

SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE JobTitle NOT LIKE ('%engineer%')

-- 05 Find Towns with Name Length 

SELECT [Name] FROM Towns
WHERE LEN([NAME]) BETWEEN 5 AND 6
ORDER BY [Name] ASC

-- 06 Find Towns Starting With

SELECT* FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
-- WHERE [Name] LIKE ('[MKBE]%')
ORDER BY [Name] ASC

-- 07 Find Towns Not Starting With

SELECT * FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

-- 08 Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

-- 09 Length of Last Name

SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

-- 10 Rank Employees by Salary

SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION  BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11 Find All Employees with Rank 2

-- Option # 1
SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION  BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS temp
WHERE temp.[Rank] = 2
ORDER BY temp.[Salary] DESC

-- Option # 2
WITH Employee_CTE AS
(SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION  BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees)
SELECT * FROM Employee_CTE
WHERE (Salary BETWEEN 10000 AND 50000) AND [Rank] = 2
ORDER BY Salary DESC

-- -- Part II – Queries for Geography Database
USE [Geography]

-- 12 Countries Holding ‘A’ 3 or More Times

SELECT * FROM Countries

SELECT CountryName AS [Country name], IsoCode AS [ISO code] FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
ORDER BY IsoCode

--  13 Mix of Peak and River Names

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks as p, Rivers as r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

-- -- Part III – Queries for Diablo Database

USE Diablo

-- 14 Games from 2011 and 2012 year
SELECT TOP(50) [Name],
               FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	      FROM Games
	     WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
      ORDER BY [Start], 
               [Name]

-- 15 User Email Providers

  SELECT Username,
		 SUBSTRING (
		 Email,
		 CHARINDEX('@', Email) + 1, -- Email is the string to cut from, charindex takes the first letter after @
		 LEN(Email) - CHARINDEX('@', Email) -- Len takes all symbols after @
		 )
	  AS [Email Provider]
    FROM Users
ORDER BY [Email Provider],
         Username

-- 16 Get Users with IPAdress Like Pattern

  SELECT Username,
         IpAddress AS [IP Address]
    FROM Users
   WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

-- 17 Show All Games with Duration and Part of the Day

-- -- Part IV – Date Functions Queries

Use Orders

-- 18 Orders Table

SELECT ProductName,
       OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders
