-- Exercises: Data Definition and Data Types

-- 01 Create Database
CREATE DATABASE Minions;

GO

-- 02 Create Tables
USE Minions

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
)

CREATE Table Towns (
	Id INT NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY (Id)

GO

-- 03 Alter Minions Table
ALTER TABLE Minions
ADD TownId INT NOT NULL;

SELECT * FROM Minions

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionsTownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)