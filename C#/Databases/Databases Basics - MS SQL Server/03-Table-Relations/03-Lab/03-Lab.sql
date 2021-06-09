-- DB Design

CREATE DATABASE CoursesTest

USE CoursesTest

ALTER AUTHORIZATION ON DATABASE::CoursesTest TO sa

GO

-- Identify Entities and Identify Table Columns
CREATE TABLE Students
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	FacultyNumber CHAR(8) NOT NULL UNIQUE,
	Photo VARBINARY(MAX),
	DateOfEnlistment DATE,
	Courses NVARCHAR(500) NOT NULL
);

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
);

-- One to many
CREATE TABLE Course
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL UNIQUE,
	TownId INT REFERENCES Towns(Id)
);

INSERT INTO Students ([Name], FacultyNumber, Photo, DateOfEnlistment, Courses) VALUES
('Serafim Gerasimoff', 'F000001', 12345, CAST( GETDATE() AS Date ), 'C#, Python, PHP, C++, JavaScript, Java'),
('Dala Vera', 'F000002', 12346, CAST( GETDATE() AS Date ), 'C#, Python, PHP, C++, JavaScript'),
('Christina Leona', 'F000003', 12347, CAST( GETDATE() AS Date ), 'C#, C++, JavaScript'),
('Gillian Anderson', 'F000004', 12348, CAST( GETDATE() AS Date ), 'Python, PHP, JavaScript'),
('Fox Mulder', 'F000005', 12349, CAST( GETDATE() AS Date ), 'C#, C++, Java');

INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Ruse'),
('Varna'),
('Stara Zagora')

INSERT INTO Course ([Name], TownId) VALUES
('C#', 1),
('Python', 2),
('HTML', 3),
('PHP', 4 ),
('CSS', 1 ), 
('JavaScript', 1)

SELECT * FROM Course

SELECT * FROM STUDENTS

-- Many to Many

CREATE TABLE StudentsInCourses
(
	StudentId INT REFERENCES Students(Id),
	CourseId INT REFERENCES Course(Id),
	Mark DECIMAL(3,2),
	CHECK(Mark BETWEEN 2.00 AND 6.00),
	CONSTRAINT PK_StudentsCourses PRIMARY KEY (StudentId, CourseId)
);

SELECT * FROM StudentsInCourses

INSERT INTO StudentsInCourses (StudentId, CourseId, Mark) VALUES
(1, 1, 6.00),
(1, 3, 5.50),
(1, 2, 5.00),
(2, 2, 4.30),
(2, 4, 2.00),
(3, 4, 2.00),
(3, 1, 4.25)

-- Drop redundant column once Database is normalized
SELECT * from Students
ALTER TABLE Students
DROP COLUMN Courses


-- Join tables so we can see the information

-- without alias 
--SELECT *
--	FROM Course
--	JOIN Towns
--		ON Course.TownId = Towns.Id

-- With alias
SELECT * 
	FROM Course AS c
	JOIN Towns as t
		ON c.TownId = t.Id

-- multi-join

SELECT s.Name, c.Name, t.Name, sc.Mark
	FROM StudentsInCourses AS sc
	JOIN Course C ON sc.CourseId = c.Id
	JOIN Students s ON sc.StudentId = s.Id
	JOIN Towns t ON c.TownId = t.Id
	WHERE sc.Mark IS NOT NULL

-- Problem: Peaks in Rila

USE [Geography]

ALTER AUTHORIZATION ON DATABASE::[Geography] TO sa

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC
