CREATE DATABASE TableRelationsExercisesDatabase

USE TableRelationsExercisesDatabase

ALTER AUTHORIZATION ON DATABASE::TableRelationsExercisesDatabase TO sa

GO

-- Problem 01: One-To-One Relationship

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8) UNIQUE NOT NULL
);


CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT UNIQUE REFERENCES Passports(PassportId)
);

INSERT INTO Passports (PassportID, PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons (FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

-- Problem 02: One-To-Many Relationship


CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) UNIQUE NOT NULL,
	EstablishedOn DATE NOT NULL
);

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID) NOT NULL
);

INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models ([Name], ManufacturerID) VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

-- Problem 03: Many-To-Many Relationship 

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
);

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT 
	CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

);

INSERT INTO Students ([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams ([Name]) VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101 ),
(1, 102 ),
(2, 101 ),
(3, 103 ),
(2, 102 ),
(2, 103 )

/*
SELECT s.[Name], e.[Name]
	FROM StudentsExams AS se
	JOIN Students AS s ON se.StudentID = s.StudentID
	JOIN Exams AS e ON se.ExamID = e.ExamID
*/

-- Problem 04: Self-Referencing

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--SELECT * FROM Teachers

-- Problem 05: Online Store Database

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATETIME NOT NULL,
	CityID INT REFERENCES Cities(CityID)
);

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID)
);

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
);


CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID),
	CONSTRAINT PK_OrderID_ItemID
	PRIMARY KEY (OrderID, ItemID)
);

-- Problem 06: University Database

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
);

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(15) NOT NULL UNIQUE,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),

	CONSTRAINT PK_StudentID_SubjectID
	PRIMARY KEY (StudentID, SubjectID)
);

-- Problem 09: Peaks in Rila

USE [Geography]

ALTER AUTHORIZATION ON DATABASE::[Geography] TO sa

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC
