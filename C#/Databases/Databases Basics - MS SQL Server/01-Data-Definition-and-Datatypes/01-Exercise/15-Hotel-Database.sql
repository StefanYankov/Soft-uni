CREATE DATABASE Hotel

USE Hotel

ALTER AUTHORIZATION ON DATABASE::Hotel TO sa

GO

CREATE TABLE Employees (
  Id INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  Title NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max)
);

CREATE TABLE Customers (
  AccountNumber INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  PhoneNumber VARCHAR(15) NOT NULL,
  EmergencyName NVARCHAR(50) NOT NULL,
  EmergencyNumber VARCHAR(15) NOT NULL,
  Notes NVARCHAR(max)
);

CREATE TABLE RoomStatus (
  RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
);

CREATE TABLE RoomTypes (
  RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
);

CREATE TABLE BedTypes (
  BedType NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
);

CREATE TABLE Rooms (
  RoomNumber INT PRIMARY KEY IDENTITY,
  RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType),
  BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType),
  Rate DECIMAL(3, 2) NOT NULL,
  RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
  Notes NVARCHAR(max)
);

CREATE TABLE Payments (
  Id INT PRIMARY KEY IDENTITY,
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
  PaymentDate DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
  FirstDateOccupied DATE NOT NULL,
  LastDateOccupied DATE NOT NULL,
  TotalDays INT NOT NULL,
  AmountCharged DECIMAL(15, 2) NOT NULL,
  TaxRate DECIMAL(4, 2) NOT NULL,
  TaxAmount DECIMAL(15, 2) NOT NULL,
  PaymentTotal DECIMAL(15, 2) NOT NULL,
  Notes NVARCHAR(max),
);

CREATE TABLE Occupancies (
  Id INT PRIMARY KEY IDENTITY,
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
  DateOccupied DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
  RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
  RateApplied DECIMAL(4, 2) NOT NULL,
  PhoneCharge DECIMAL(5, 2) NOT NULL,
  Notes NVARCHAR(max)
);

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Stefan', 'Yankov', 'Director', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('Serafim', 'Gerasimoff', 'Hotel Porter', 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
('Dala', 'Vera', 'Receptionist', 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Christina', 'Leona', '0883125789', 'Harry Potter', '0878563585', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('Gary', 'Brant', '0877665544', 'Jim Raynor', '0885654535', 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
('Jillian', 'Anderson', '0865432125', 'Sarah Connor', '0895324589', 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
(1, 'Vacant'),
(2, 'Occupied'),
(3, 'For cleaning')

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Suite', 'A parlour or living room connected with to one or more bedrooms. (A room with one or more bedrooms and a separate living space.)'),
('Single', 'A room assigned to one person. May have one or more beds. The room size or area of Single Rooms are generally between 37 m² to 45 m².'),
('Double', 'A room assigned to two people. May have one or more beds. The room size or area of Double Rooms are generally between 40 m² to 45 m².')

INSERT INTO BedTypes(BedType, Notes) VALUES
('King Bed', '(Width X Length) 198.12 X 203.2'),
('Standard Double','(Width X Length) 137.16 X 193.04'),
('Modern Cot','(Width X Length) 76 X 188')


INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('Suite', 'King Bed', 5.50, 1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('Single', 'Modern Cot', 4.75, 2, 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
('Double', 'Standard Double', 4.98, 3, 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, '2015-01-25', 1, '2021-05-10', '2021-05-11', 2, 315, 95.5, 127, 668, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
(2, '2018-12-11', 2, '2021-05-10', '2021-05-11', 2, 315, 95.5, 127, 668, 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
(3, '2017-09-01', 3, '2021-05-10', '2021-05-11', 2, 315, 95.5, 127, 668, 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2021-05-30', 1, 1, 14.75, 20.20, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
(2, '2021-05-28', 2, 2, 11.2, 0, 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec.'),
(3, '2021-06-01', 3, 3, 4.7, 3, 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.')
