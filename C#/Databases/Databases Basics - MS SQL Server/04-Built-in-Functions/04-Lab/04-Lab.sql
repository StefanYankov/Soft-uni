-- 01 Obfuscate CC Numbers

USE Demo

SELECT * FROM Customers

CREATE VIEW vw_PublicPaymentInfo AS
SELECT CustomerID,
       FirstName,
       LastName,
	   CONCAT(LEFT(PaymentNumber, 6), REPLICATE('*', LEN(PaymentNumber) - 6)) AS PaymentNumber
FROM Customers

SELECT * FROM vw_PublicPaymentInfo

SELECT Id,
(A*H)/2 AS Area
From Triangles2

-- 02 Line Length

SELECT Id, X1, Y1, X2, Y2,
	SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2))
	AS Length
	FROM Lines

-- 03 Pallets

SELECT * FROM Products

SELECT
  CEILING(
    CEILING(
      CAST(Quantity AS float) / 
      BoxCapacity) / PalletCapacity)
    AS [Number of pallets]
  FROM Products

 
USE SoftUni
SELECT * FROM Projects WHERE DATEPART(QUARTER, StartDate) = 3

-- 04 Quarterly report

USE Orders

SELECT * FROM Orders

SELECT ProductName, 
       DATEPART(QUARTER, OrderDate) AS Quarter,
       DATEPART(MONTH, OrderDate) AS Month,
       DATEPART(YEAR, OrderDate) AS Year,
       DATEPART(DAY, OrderDate) AS Day
FROM Orders

GO

USE SoftUni

SELECT EmployeeID, FirstName, LastName,
       DATEDIFF(YEAR, HireDate, GETDATE())
    AS [Years In Service]
  FROM Employees
  ORDER BY [Years In Service] DESC
