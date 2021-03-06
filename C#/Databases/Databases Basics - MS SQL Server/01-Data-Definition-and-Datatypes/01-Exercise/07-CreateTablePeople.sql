-- 07 Create Table People

CREATE TABLE People (
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  Picture VARBINARY(max),
  CHECK(DATALENGTH(Picture) <= 2097152),
  Height REAL,
  Weight REAL,
  Gender CHAR(1) NOT NULL,
  CHECK(Gender = 'm' OR GENDER = 'f'),
  Birthdate DATE NOT NULL,
  Biography NVARCHAR(max)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Stefan Yankov', 1000, 1.78, 70, 'm', '1987-02-02', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend maximus nisl, et venenatis lorem vulputate sed.'),
('Serafim Gerasimoff', 2000, 1.80, 75, 'm', '1990-03-04', 'Fusce cursus nisl et rhoncus semper. Sed bibendum egestas lorem non accumsan purus faucibus nec. '),
('Dala Vera', 3000, 1.65, 60, 'f', '1991-05-06', 'Maecenas non porttitor sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.'),
('Kaka Penka', 4000, 1.60, 55, 'f', '1992-07-08', 'Suspendisse potenti. Morbi eget justo eget ante venenatis tincidunt. Nulla eu gravida nisl. Maecenas mattis molestie cursus.'),
('Spaska', 5000, 1.55, 50, 'f', '1993-09-10', ' Vivamus semper, ante pharetra ornare lacinia, ipsum nunc finibus orci, at malesuada magna diam nec magna. Nunc bibendum sodales purus nec rhoncus.')

SELECT * FROM People
