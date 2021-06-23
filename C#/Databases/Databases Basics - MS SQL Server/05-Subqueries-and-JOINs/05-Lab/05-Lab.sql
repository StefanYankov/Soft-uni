-- Common Table Expressions example

WITH Employees_CTE
(FirstName, LastName, DepartmentName)
AS
(
SELECT 
  e.FirstName,
  e.LastName,
  d.Name
FROM Employees AS e
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
)
SELECT 
  FirstName,
  LastName,
  DepartmentName
FROM Employees_CTE

-- Temp table creation example

CREATE TABLE #TempTable 
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL,
  FacultyNumber INT NOT NULL
)

SELECT * FROM #TempTable
