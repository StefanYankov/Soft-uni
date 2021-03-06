-- 6.Create Transactions Table and a Trigger

-- Create table
CREATE TABLE Transactions (
	Id INT PRIMARY KEY IDENTITY(1,1), 
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldBalance DECIMAL(15, 2) NOT NULL,
	NewBalance DECIMAL(15, 2) NOT NULL,
	Amount AS NewBalance - OldBalance,
	[DateTime] DATETIME2
)

SELECT * FROM Transactions

-- Create trigger
CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
  INSERT INTO Transactions (AccountId, OldBalance, NewBalance, [DateTime])
  SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
  JOIN deleted ON inserted.Id = deleted.Id

-- Test trigger

p_Deposit 1, 25.00
GO

p_Deposit 1, 40.00
GO

p_Withdraw 2, 200.00
GO

p_Deposit 4, 180.00
GO

SELECT * FROM Transactions
