-- 01 Examine the Databases
   -- Download and get familiar with the SoftUni, Diablo and Geography database schemas and tables.

-- -- Part I – Queries for SoftUni Database

USE SoftUni

-- 02 Find All Information About Departaments

SELECT * FROM Departments

-- 03 Find all departments

SELECT [Name] FROM Departments

-- 04 Find Salary of Each Employee

SELECT FirstName, LastName, Salary FROM Employees

-- 05 Find Full Name of Each Employee

SELECT FirstName, MiddleName, LastName FROM Employees;

-- 06 Find Email Address of Each Employee

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address] FROM Employees

-- 07 Find All Different Employee's Salaries

SELECT DISTINCT Salary FROM Employees

-- 08 Find all Information About Employees

SELECT * FROM Employees
WHERE (JobTitle = 'Sales Representative')

-- 09 Find Names of All Employees by Salary in Range

SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

-- 10 Find Names of All Employees 

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name] FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-- 11 Find All Employees Without Manager

SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

-- 12 Find All Employees with Salary More Than 50000

SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000 
ORDER BY Salary DESC

-- 13 Find 5 Best Paid Employees.

SELECT TOP(5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

-- 14 Find All Employees Except Marketing

SELECT FirstName, LastName FROM Employees
WHERE DepartmentID <> 4

-- 15 Sort Employees Table

SELECT * FROM Employees
ORDER BY 
Salary DESC,
FirstName ASC,
LastName DESC,
MiddleName ASC

-- 16 Create View Employees with Salaries

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

-- 17 Create View Employees with Job Titles

DROP VIEW V_EmployeeNameJobTitle

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName,' ', MiddleName, ' ', LastName) AS [Full Name],
JobTitle AS [Job Title]
FROM Employees

SELECT * FROM V_EmployeeNameJobTitle

-- 18 Distinct Job Titles

SELECT DISTINCT JobTitle FROM Employees

-- 19 Find First 10 Started Projects

SELECT TOP(10) * FROM Projects
ORDER BY StartDate, [Name]

-- 20 Last 7 Hired Employees

SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

-- 21 Increase Salaries

/*
SELECT * FROM Departments
WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
*/

SELECT Salary FROM Employees
WHERE DepartmentID IN (1,2,4,11)

UPDATE Employees
SET Salary  += Salary *0.12
WHERE DepartmentID IN (1,2,4,11)

/*
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (SELECT DepartmentID FROM Departments
WHERE Name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services'))

SELECT Salary FROM Employees
*/

-- -- Part II – Queries for Geography Database

USE [Geography]

-- 22 All Mountain Peaks

SELECT PeakName FROM Peaks
ORDER BY PeakName ASC

-- 23 Biggest Countries by Population
/*
SELECT TOP(30)
		[CountryName],
		[Population] 
		FROM Countries
			WHERE [ContinentCode] IN (SELECT ContinentCode FROM Continents
			WHERE [ContinentName] IN ('Europe'))
		ORDER BY [Population] DESC
*/


SELECT TOP(30) CountryName, [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName ASC

-- 24 *Countries and Currency (Euro / Not Euro)

SELECT CountryName, CountryCode,
CASE WHEN CurrencyCode = 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS [Currency]
FROM Countries
ORDER BY CountryName

-- -- Part III – Queries for Diablo Database

USE Diablo

SELECT [Name] FROM Characters
ORDER BY [Name] ASC
