-- 13 Movies Database

CREATE DATABASE Movies

GO

USE Movies

GO

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX),
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(30) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(2, 1) NOT NULL,
	Notes NVARCHAR(max)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
	('Steven Spielberg', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur laoreet lectus ut condimentum pellentesque. Pellentesque.'),
	('Christopher Nolan', 'Pellentesque nec dolor at ante mattis luctus vitae vel diam.'),
	('James Cameron', 'Integer condimentum tellus sed purus tempor ultrices at ut massa'),
	('Frank Darabont','Morbi venenatis arcu nunc, eu commodo turpis sollicitudin eu.'),
	('Peter Jackson', 'Cras eget metus nisi. Nunc faucibus rutrum metus sed efficitur.')


INSERT INTO Genres (GenreName, Notes) VALUES
	('Action', NULL),
	('Romance', NULL),
	('Drama','Satire drama'),
	('Horror', 'Alternate history'),
	('Fantasy', 'Science fantasy, Dark fantasy, Fairy tales')

INSERT INTO Categories(CategoryName, Notes) VALUES
('By Genre', ''),
('By Language', ''),
('By Year‎', ''),
('By Studio', ''),
('By Topic‎', '')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) Values
('The Shawshank Redemption', 4, 1994, 142, 3, 1, 9.30, 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.'),
('The Dark Knight', 2, 2008, 152, 1, 2, 9.00, 'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.'),
('The Lord of the Rings', 5, 2003, 201, 5, 5, 8.9, 'Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.'),
('Jurassic Park', 1, 1993, 127, 1, 3, 8.1, 'A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park''s cloned dinosaurs to run loose.'),
('Avatar', 3, 2009, 162, 5, 4, 7.8, 'Some text here, etc')

