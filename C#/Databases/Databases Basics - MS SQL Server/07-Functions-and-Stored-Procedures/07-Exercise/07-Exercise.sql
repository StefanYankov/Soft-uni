-- -- Part I – Queries for SoftUni Database

USE SoftUni

-- Problem 01: Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT 
	FirstName,
	LastName
 FROM Employees
 WHERE Salary > 35000
END

-- EXEC usp_GetEmployeesSalaryAbove35000 

-- Problem 02: Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
BEGIN
	SELECT 
	FirstName,
	LastName
 FROM Employees
 WHERE Salary >= @Number
END

-- EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- Problem 03: Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith @StartingString NVARCHAR(30)
AS
BEGIN
	SELECT [Name]
	FROM [Towns]
	WHERE [Name] LIKE @StartingString + '%'
END

-- EXEC usp_GetTownsStartingWith 'B'

-- Problem 04: Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown @TownName NVARCHAR(30)
AS
BEGIN
	SELECT e.[FirstName],
		   e.[LastName]
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns as t ON a.TownID = t.TownID
	WHERE t.Name LIKE @TownName
END

--EXEC usp_GetEmployeesFromTown 'Sofia'

-- Problem 05: Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	IF(@Salary < 30000)
		BEGIN 
		 SET @SalaryLevel = 'Low'
		END
	ELSE IF(@Salary >= 30000 AND @Salary <= 50000)
		BEGIN
		 SET @SalaryLevel = 'Average'
		END
	ELSE IF (@Salary > 50000)
		BEGIN 
		 SET @SalaryLevel = 'High'
		END
	ELSE 
		BEGIN 
		 SET @SalaryLevel = NULL
		END
RETURN @SalaryLevel
END

--SELECT dbo.ufn_GetSalaryLevel(13500.00) AS [Salary Level]
--SELECT dbo.ufn_GetSalaryLevel(43300.00) AS [Salary Level]
--SELECT dbo.ufn_GetSalaryLevel(125500.00) AS [Salary Level]
--SELECT dbo.ufn_GetSalaryLevel(NULL) AS [Salary Level]

--Problem 06: Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
BEGIN
	SELECT
		[FirstName],
		[LastName]FROM Employees
		WHERE @salaryLevel = dbo.ufn_GetSalaryLevel(Salary)
END

--EXEC usp_EmployeesBySalaryLevel 'Low'
--EXEC usp_EmployeesBySalaryLevel 'Average'
--EXEC usp_EmployeesBySalaryLevel 'High'

-- Problem 07: Define Function

-- Option # 1
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(10), @word NVARCHAR(25)) 
RETURNS BIT AS
BEGIN
	DECLARE @Output BIT
	SET @Output = 1
	DECLARE @i INT
	SELECT @i = 0
	WHILE (@i < LEN(@setOfLetters)) -- iterate trough characters
	BEGIN
		SET @i += 1
		If @setOfLetters LIKE '%' + SUBSTRING(@word,@i,1) + '%'
			CONTINUE
		ELSE
			SET @Output = 0
			BREAK
	END
RETURN @Output
END

-- Option # 2
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(10), @word NVARCHAR(25)) 
RETURNS BIT AS
BEGIN
	DECLARE @count INT = 1;

	WHILE (@count< LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word,@count,1)
		IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
			RETURN 0

		SET @count += 1;
	END
	RETURN 1
END


--SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia') AS [Result]
--SELECT dbo.ufn_IsWordComprised('oistmiahf','halves') AS [Result]

-- Problem 08: Delete Employees and Departments

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @empIDsToBeDeleted TABLE
(
	Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

-- -- Part II – Queries for Bank Database

USE Bank

-- Problem 09: Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
   SELECT CONCAT(FirstName, ' ', LastName)
   FROM AccountHolders
END

-- Problem 10: People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(18, 2)
AS
BEGIN
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a 
	ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Number
	ORDER BY FirstName, LastName
END

-- Problem 11: Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL (18, 2), @yearlyInterestRate FLOAT, @numberYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
   RETURN @sum * (POWER(1 + @yearlyInterestRate, @numberYears))
END

-- SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- Problem 12: Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount @accountID INT, @interestRate FLOAT 
AS
BEGIN
	SELECT 
		a.Id, ah.FirstName, 
		ah.LastName, 
		a.Balance AS [Current Balance], 
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a 
	ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountID
END

--EXEC usp_CalculateFutureValueForAccount 1, 0.1

-- Problem 13: *Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE 
AS 
RETURN SELECT
	(
		SELECT SUM(Cash) AS SumCash
	    FROM (
			SELECT 
				g.[Name],
				ug.Cash,
				ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
			FROM UsersGames AS ug
			INNER JOIN Games AS g
			ON ug.GameId = g.Id
			WHERE g.[Name] = @gameName
			) AS RowNumberSubquery
		WHERE RowNumber % 2 != 0
	) AS SumCash

-- SELECT * FROM ufn_CashInUsersGames('Love in a mist')

-- Problem 14: Create table logs

CREATE TABLE Logs (
  LogId INT PRIMARY KEY IDENTITY,
  AccountId INT,
  OldSum MONEY,
  NewSum MONEY
)

CREATE TRIGGER InsertNewEntryIntoLogs
  ON Accounts
  AFTER UPDATE
AS
  INSERT INTO Logs VALUES
  (
    (SELECT Id
     FROM inserted),
    (SELECT Balance
     FROM deleted),
    (SELECT Balance
     FROM inserted)
  )

-- Problem 15: Create Table Emails

CREATE TABLE NotificationEmails (
  Id INT PRIMARY KEY IDENTITY,
  Recipient INT,
  Subject NVARCHAR(MAX),
  Body NVARCHAR(MAX)
)

CREATE TRIGGER CreateNewNotificationEmail
  ON Logs
  AFTER INSERT
AS
  BEGIN
    INSERT INTO NotificationEmails
    VALUES (
      (SELECT AccountId
       FROM inserted),
      (CONCAT('Balance change for account: ', (SELECT AccountId
                                               FROM inserted))),
      (CONCAT('On ', (SELECT GETDATE()
                      FROM inserted), 'your balance was changed from ', (SELECT OldSum
                                                                         FROM inserted), 'to ', (SELECT NewSum
                                                                                                 FROM inserted), '.'))
    )
  END

-- Problem 16: Deposit Money

 CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS
  BEGIN TRANSACTION
  UPDATE Accounts
  SET Balance += @MoneyAmount
  WHERE Id = @AccountId
  COMMIT

-- Problem 17: Withdraw Money Procedure

CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY)
AS
  BEGIN TRANSACTION
  UPDATE Accounts
  SET Balance -= @MoneyAmount
  WHERE Id = @AccountId
  COMMIT

-- Problem 18: Money Transfer

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
  BEGIN
    BEGIN TRANSACTION
    EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
    EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
    IF ((SELECT Balance
         FROM Accounts
         WHERE Accounts.Id = @SenderId) < 0)
      BEGIN
        ROLLBACK
      END
    ELSE
      BEGIN
        COMMIT
      END
  END

-- Problem 20: Massive shopping

DECLARE @gameName NVARCHAR(50) = 'Safflower'
DECLARE @username NVARCHAR(50) = 'Stamat'

DECLARE @userGameId INT = (
  SELECT ug.Id
  FROM UsersGames AS ug
    JOIN Users AS u
      ON ug.UserId = u.Id
    JOIN Games AS g
      ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName)

DECLARE @userGameLevel INT = (SELECT Level
                              FROM UsersGames
                              WHERE Id = @userGameId)
DECLARE @itemsCost MONEY, @availableCash MONEY, @minLevel INT, @maxLevel INT

SET @minLevel = 11
SET @maxLevel = 12
SET @availableCash = (SELECT Cash
                      FROM UsersGames
                      WHERE Id = @userGameId)
SET @itemsCost = (SELECT SUM(Price)
                  FROM Items
                  WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel)

  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @itemsCost
    WHERE Id = @userGameId
    IF (@@ROWCOUNT <> 1)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not make payment', 16, 1)
      END
    ELSE
      BEGIN
        INSERT INTO UserGameItems (ItemId, UserGameId)
          (SELECT
             Id,
             @userGameId
           FROM Items
           WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

        IF ((SELECT COUNT(*)
             FROM Items
             WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
          BEGIN
            ROLLBACK;
            RAISERROR ('Could not buy items', 16, 1)
          END
        ELSE COMMIT;
      END
  END

SET @minLevel = 19
SET @maxLevel = 21
SET @availableCash = (SELECT Cash
                      FROM UsersGames
                      WHERE Id = @userGameId)
SET @itemsCost = (SELECT SUM(Price)
                  FROM Items
                  WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel)

  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @itemsCost
    WHERE Id = @userGameId

    IF (@@ROWCOUNT <> 1)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not make payment', 16, 1)
      END
    ELSE
      BEGIN
        INSERT INTO UserGameItems (ItemId, UserGameId)
          (SELECT
             Id,
             @userGameId
           FROM Items
           WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

        IF ((SELECT COUNT(*)
             FROM Items
             WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
          BEGIN
            ROLLBACK
            RAISERROR ('Could not buy items', 16, 1)
          END
        ELSE COMMIT;
      END
  END

SELECT i.Name AS [Item Name]
FROM UserGameItems AS ugi
  JOIN Items AS i
    ON i.Id = ugi.ItemId
  JOIN UsersGames AS ug
    ON ug.Id = ugi.UserGameId
  JOIN Games AS g
    ON g.Id = ug.GameId
WHERE g.Name = @gameName
ORDER BY [Item Name]

-- Problem 21: Employees with Three Projects

CREATE PROCEDURE usp_AssignProject(@employeeId INT, @projectID INT)
AS
  BEGIN
    BEGIN TRAN
    INSERT INTO EmployeesProjects
    VALUES (@employeeId, @projectID)
    IF (SELECT COUNT(ProjectID)
        FROM EmployeesProjects
        WHERE EmployeeID = @employeeId) > 3
      BEGIN
        RAISERROR ('The employee has too many projects!', 16, 1)
        ROLLBACK
        RETURN
      END
    COMMIT
  END

-- Problem 22: Delete Employees

CREATE TABLE Deleted_Employees
(
  EmployeeId INT PRIMARY KEY IDENTITY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  MiddleName VARCHAR(50),
  JobTitle VARCHAR(50),
  DepartmentId INT,
  Salary DECIMAL(15, 2)
)

CREATE TRIGGER tr_DeleteEmployees
  ON Employees
  AFTER DELETE
AS
  BEGIN
    INSERT INTO Deleted_Employees
      SELECT
        FirstName,
        LastName,
        MiddleName,
        JobTitle,
        DepartmentID,
        Salary
      FROM deleted
  END