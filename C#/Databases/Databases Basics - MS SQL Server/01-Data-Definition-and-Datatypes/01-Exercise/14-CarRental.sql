-- 14 Car Rental Database

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	DailyRate DECIMAL(15,2) NOT NULL,
	WeeklyRate DECIMAL(15,2) NOT NULL,
	MonthlyRate DECIMAL(15,2) NOT NULL,
	WeekendRate DECIMAL(15,2) NOT NULL
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors TINYINT NOT NULL,
	Picture VARBINARY(max) NOT NULL,
	CHECK(DATALENGTH(Picture) <= 2000000),
	Condition NVARCHAR(10) NOT NULL,
	CONSTRAINT CHK_Cars_Condition CHECK (Condition = 'Excellent' OR Condition = 'Very good' OR Condition = 'Good' OR Condition = 'Fair'),
	Available BIT NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber NVARCHAR(20) NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(20) NOT NULL,
	ZIPCode NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel SMALLINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	CHECK(TotalKilometrage = KilometrageEnd - KilometrageStart),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays SMALLINT NOT NULL,
	CHECK(TotalDays = DATEDIFF(day, StartDate, EndDate) + 1),
	RateApplied BIT NOT NULL,
	TaxRate DECIMAL(4, 2) NOT NULL,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(max)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Sedan', 26, 125, 300, 55),
('Coupe', 24, 115, 228, 50),
('Sports Cars', 55, 195, 485, 85)


INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('CA2398OD', 'Toyota', 'Celica', 2006, 1, 4, 1000, 'Excellent', 1),
('CO5169BA', 'Audi', 'R8', 2015, 3, 2, 2000, 'Very good', 0),
('ÎÂ1234ÀÐ', 'Ford', 'Ford Mustang GT', 2015, 2, 2, 3000, 'Good', 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Stefan', 'Yankov', 'Director', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('Serafim', 'Gerasimoff', 'Sales person', 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
('Dala', 'Vera', 'Accountant', 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('I12345678', 'Kaka Penka', 'Cecilia Chapman 711-2880 Nulla St.', 'Mankato Mississippi', '96522', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('J54321', 'Aunt Spaska', 'Iris Watson P.O. Box 283 8562 Fusce Rd.', 'Frederick Nebraska', '20620', 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
('L123123', 'Cousin It', 'Celeste Slater 606-3727 Ullamcorper. Street', 'Roseville NH', '11523', 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 130, 0, 260, 260, '2001-12-30', '2001-12-31', 2, 1, 2, 0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
(2, 2, 2, 150, 0, 300, 300, '2002-03-20', '2002-03-20', 1, 0, 4, 1, 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
(3, 3, 3, 140, 0, 280, 280, '2003-09-15', '2003-09-17', 3, 1, 6, 1, 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')
