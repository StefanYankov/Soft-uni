-- 01 - Departments Total Salaries

  SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
	FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID ASC

-- 02 - Having Clause

SELECT e.DepartmentID,
		SUM(e.Salary) AS [TotalSalary]
		FROM Employees AS e
		GROUP BY e.DepartmentID
		HAVING SUM(e.Salary) >= 15000
		ORDER BY [TotalSalary] DESC