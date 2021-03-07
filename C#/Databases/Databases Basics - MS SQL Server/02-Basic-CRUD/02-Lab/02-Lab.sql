-- Notes from the lecture

USE SoftUni

-- 01 Employee summary
SELECT 
	FirstName + ' ' + LastName AS 'Full Name',
	JobTitle As 'Job Title',
	Salary
FROM Employees;

-- 02 Highest Peak

USE Geography

CREATE VIEW v_HighestPeak AS
	SELECT TOP (1) * FROM Peaks	ORDER BY Elevation DESC

SELECT * FROM v_HighestPeak

-- 03 Update Projects

USE SoftUni

SELECT * FROM Projects WHERE EndDate IS NULL

UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL
