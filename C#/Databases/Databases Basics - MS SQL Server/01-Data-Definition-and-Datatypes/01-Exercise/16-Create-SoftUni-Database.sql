CREATE DATABASE SoftUni

ALTER AUTHORIZATION ON DATABASE::SoftUni TO sa
GO
USE SoftUni

CREATE TABLE Towns (

	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Addresses (

	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
);

CREATE TABLE Departments (
	Id INT PRIMARY KEY Identity,
	[Name] NVARCHAR(30) UNIQUE NOT NULL
);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(20) NOT NULL,
	JobTitle NVARCHAR(15) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	AddressID INT FOREIGN KEY REFERENCES Addresses(Id)
	);


INSERT INTO Towns ([Name]) VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Svilengrad'),
('Troyan')

INSERT INTO Addresses (AddressText, TownId) VALUES
('41, Stoletov blvd.', 1),
('125, Vasil Levski blvd.', 2),
('18, Vladislav Varnenchik blvd.', 3),
('37, Geo Milev str.', 4),
('25, Rakovski str.', 5)

INSERT INTO Departments ([Name]) VALUES
('Production'),
('R&D'),
('Operations'),
('Finance'),
('Administration'),
('Sales'),
('Marketing')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressID) VALUES
('Stefan', 'Krasimirov', 'Yankov', 'Director', 2 , '2011-05-11', 35000, 5),
('Serafim', NULL, 'Gerasimoff', 'VP of Sales', 6, '2018-01-24', 30000 , 1),
('Dala', NULL, 'Vera', 'Accountant', 4 , '2015-12-01', 28000, 4),
('Doktor', 'Oh', 'Boli', 'Researcher' , 2, '2017-05-05', 31000, 3),
('Daskal', ' ', 'Daskalov', 'Teacher', 3, '2011-01-01', 3200, 2)

