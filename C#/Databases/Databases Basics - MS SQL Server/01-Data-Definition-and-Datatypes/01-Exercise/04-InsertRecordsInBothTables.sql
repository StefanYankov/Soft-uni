-- 04 Insert Records in Both Tables

INSERT INTO Towns (Id, [Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

SELECT * FROM Towns

GO

INSERT INTO Minions (Id, [Name], Age, TownId) Values
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM Minions

GO