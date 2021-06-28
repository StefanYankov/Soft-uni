-- Gringotts DB for #1 to #12
USE Gringotts

exec sp_changedbowner 'sa'

GO

-- Problem 01. Records’ Count

SELECT 
	COUNT(*) AS [Count]
	FROM WizzardDeposits

-- Problem 02. Longest Magic Wand

SELECT 
	MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

-- Problem 03. Longest Magic Wand per Deposit Groups

SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

-- Problem 04. Smallest Deposit Group per Magic Wand Size

SELECT TOP (2)
	dg.DepositGroup
	FROM (SELECT 
	DepositGroup,
	AVG(MagicWandSize) AS average
	FROM WizzardDeposits AS wd
	GROUP BY wd.DepositGroup
	) AS dg
	ORDER BY dg.average ASC

-- solution # 2
SELECT TOP(2)
	DepositGroup
	FROM WizzardDeposits AS w
	GROUP BY w.DepositGroup
	ORDER BY AVG(MagicWandSize)

-- Problem 05. Deposits Sum

SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits AS wd
	GROUP BY wd.DepositGroup

-- Problem 06. Deposits Sum for Ollivander Family

SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits AS wd
	WHERE MagicWandCreator LIKE ('Ollivander family')
	GROUP BY wd.DepositGroup

-- Problem 07. Deposits Filter

SELECT *
	FROM 
	(
	SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits AS wd
	WHERE MagicWandCreator LIKE ('Ollivander family')
	GROUP BY wd.DepositGroup
	) AS temp
	WHERE temp.TotalSum < 150000
	ORDER BY temp.TotalSum DESC

-- solution # 2
SELECT
	wd.DepositGroup,
	SUM (DepositAmount) AS TotalSum
    FROM WizzardDeposits AS wd
	WHERE wd.MagicWandCreator = 'Ollivander family'
	GROUP BY wd.DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

-- Problem 08. Deposit Charge

SELECT 
	wd.DepositGroup,
	wd.MagicWandCreator,
	MIN(wd.DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits AS wd
	GROUP BY wd.DepositGroup, wd.MagicWandCreator
	ORDER BY wd.MagicWandCreator, wd.DepositGroup

-- Problem 09. Age Groups

SELECT 
	Temp.AgeGroup, COUNT(*) AS WizardCount
	FROM (
	SELECT
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age >= 61 THEN '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits
	) AS Temp
	GROUP BY Temp.AgeGroup
	ORDER BY temp.AgeGroup ASC

-- Problem 10. First Letter

SELECT 
	LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits 
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1)
	ORDER BY FirstLetter

-- Problem 11. Average Interest

SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
    FROM WizzardDeposits
	WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- Problem 12. Rich Wizard, Poor Wizard 

SELECT 
	SUM([Secondary].DepositAmount - Main.DepositAmount) AS SumDifference
	FROM WizzardDeposits AS Main
	JOIN WizzardDeposits AS [Secondary] On Main.Id = ([Secondary].Id + 1)

-- solution # 2
SELECT 
	SUM(temp.[Difference])
	FROM
	(
		SELECT DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY ID) AS [Difference]
		FROM WizzardDeposits
	) AS temp

-- SoftUni DB for 13 and on
USE SoftUni

exec sp_changedbowner 'sa'

GO

-- Problem 13. Departments Total Salaries

SELECT 
	e.DepartmentID,
	SUM (Salary) AS TotalSalary
    FROM Employees AS e
	GROUP BY e.DepartmentID
	ORDER BY e.DepartmentID

-- Problem 14. Employees Minimum Salaries

SELECT 
	e.DepartmentID,
	MIN(e.Salary) AS MinimumSalary
	FROM Employees AS e
	WHERE e.DepartmentID IN(2, 5, 7) 
	AND DATEPART(YEAR, e.HireDate) > '2000'
	GROUP BY DepartmentID

-- Problem 15. Employees Average Salaries

SELECT *
	INTO TempTable
	FROM Employees AS e
	WHERE e.Salary > 30000

DELETE
	FROM TempTable
	WHERE ManagerId = 42

UPDATE TempTable
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT 
	tt.DepartmentID,
	AVG(tt.Salary) AS AverageSalary
	FROM TempTable AS tt
	GROUP BY tt.DepartmentID

-- Problem 16. Employees Maximum Salaries

SELECT 
	e.DepartmentID,
	MAX(e.Salary) AS MaxSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
	HAVING MAX (Salary) NOT BETWEEN 30000 AND 70000

-- Problem 17. Employees Count Salaries

SELECT 
	COUNT(*) AS [Count]
	FROM Employees
	WHERE ManagerID IS NULL

-- Problem 18. 3rd Highest Salary

SELECT DISTINCT
	temp.DepartmentID,
	temp.Salary
	FROM
	(
	SELECT 
		e.DepartmentID,
		e.Salary,
		DENSE_RANK() OVER
						(
						PARTITION BY e.DepartmentID
						ORDER BY Salary DESC
						) AS [Rank]
		FROM Employees AS e
	) AS temp
	WHERE [Rank] = 3

-- Problem 19. Salary Challenge

SELECT TOP(10)
	e.FirstName,
	e.LastName,
	e.DepartmentID
	FROM Employees AS e
	WHERE e.Salary > 
			(
				SELECT 
					AVG(Salary) AS AvgSalary
					FROM Employees AS temp
					WHERE DepartmentID= e.DepartmentID 
					GROUP BY DepartmentID
			)
	ORDER BY DepartmentID ASC
