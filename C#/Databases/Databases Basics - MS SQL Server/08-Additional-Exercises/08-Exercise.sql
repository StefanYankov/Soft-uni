-- -- PART I – Queries for Diablo Database

USE Diablo


-- Problem 01: Number of Users for Email Provider

SELECT temp.[Email Provider],
		COUNT(temp.id) AS [Number Of Users]
		FROM
(
SELECT 
		 SUBSTRING (
		 Email,
		 CHARINDEX('@', Email) + 1, -- Email is the string to cut from, charindex takes the first letter after @
		 LEN(Email) - CHARINDEX('@', Email) -- Len takes all symbols after @
		 ) AS [Email Provider],
	Id FROM Users
	) AS temp
GROUP BY temp.[Email Provider]
ORDER BY [Number Of Users] DESC, temp.[Email Provider] ASC

-- Problem 02: All Users in Games

SELECT 
	g.Name AS [Game],
	gt.Name AS [Game Type],
	u.Username,
	ug.Level,
	ug.Cash,
	c.Name AS [Character]
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON g.GameTypeId = gt.id
JOIN Characters as c ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username ASC, g.Name ASC

-- Problem 03: Users in Games with Their Items

SELECT 
	u.Username,
	g.Name AS [Game],
	COUNT(i.Name) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON g.GameTypeId = gt.id
JOIN Characters AS c ON ug.CharacterId = c.Id
JOIN UserGameItems AS ugt ON ug.Id = ugt.UserGameId
JOIN Items AS i ON ugt.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Name) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC

-- Problem 04: * User in Games with Their Statistics

SELECT
	u.Username,
	g.[Name] AS [Game],
	MAX(c.[Name]) AS [Character],
	MAX(s1.Strength) + MAX(s2.Strength) + SUM(s3.Strength) AS [Strength],
	MAX(s1.Defence) + MAX(s2.Defence) + SUM(s3.Defence) AS [Defence],
	MAX(s1.Speed) + MAX(s2.Speed) + SUM(s3.Speed) AS [Speed],
	MAX(s1.Mind) + MAX(s2.Mind) + SUM(s3.Mind) AS [Mind],
	MAX(s1.Luck) + MAX(s2.Luck) + SUM(s3.Luck) AS [Luck]
FROM UsersGames AS ug
INNER JOIN Users AS u ON ug.UserId = u.Id
INNER JOIN Games AS g ON ug.GameId = g.Id
INNER JOIN Characters AS c ON ug.CharacterId = c.Id
INNER JOIN [Statistics] AS s1 ON c.StatisticId = s1.Id
INNER JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
INNER JOIN [Statistics] s2 ON gt.BonusStatsId = s2.Id
INNER JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
INNER JOIN Items AS i ON ugi.ItemId = i.Id
INNER JOIN [Statistics] AS s3 ON i.StatisticId = s3.Id
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

-- Problem 05: All Items with Greater than Average Statistics

SELECT
	i.[Name],
	i.[Price],
	i.[MinLevel],
	s.[Strength],
	s.[Defence],
	s.[Speed],
	s.[Luck],
	s.[Mind]
FROM
(
	SELECT Id
	FROM [Statistics]
	WHERE Mind > (SELECT AVG(Mind * 1.0)
	              FROM [Statistics])
	AND Luck > (SELECT AVG(Luck * 1.0)
	              FROM [Statistics])
	AND Speed > (SELECT AVG(Speed * 1.0)
	               FROM [Statistics])
) AS temp
  INNER JOIN [Statistics] AS s
    ON temp.Id = s.Id
  INNER JOIN Items AS i
    ON i.StatisticId = s.Id
ORDER BY [Name]

-- Problem 06: Display All Items about Forbidden Game Type

SELECT
	i.[Name] AS [Item Name],
	i.Price,
	i.MinLevel,
	gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = i.Id
LEFT JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC, [Item Name] ASC

-- Problem 07: Buy Items for User in Game

DECLARE @gameName NVARCHAR(50) = 'Edinburgh'
DECLARE @username NVARCHAR(50) = 'Alex'

DECLARE @userGameId INT = (
  SELECT ug.Id
  FROM UsersGames AS ug
    JOIN Users AS u
      ON ug.UserId = u.Id
    JOIN Games AS g
      ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName
)

DECLARE @availableCash MONEY = (
  SELECT Cash
  FROM UsersGames
  WHERE Id = @userGameId
)

DECLARE @purchasePrice MONEY = (
  SELECT sum(Price)
  FROM Items
  WHERE Name IN (
    'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
    'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
  )
)

IF (@availableCash >= @purchasePrice)
  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @purchasePrice
    WHERE Id = @userGameId

    IF (@@ROWCOUNT <> 1)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not make playment', 16, 1)
        RETURN
      END

    INSERT INTO UserGameItems (ItemId, UserGameId)
      (SELECT
         Id,
         @userGameId
       FROM Items
       WHERE Name IN
             ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
              'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))

    IF ((SELECT count(*)
         FROM Items
         WHERE Name IN (
           'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
           'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
         )) <> @@ROWCOUNT)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not buy items', 16, 1)
        RETURN
      END
    COMMIT
  END

SELECT
	u.Username,
	g.[Name],
	ug.Cash,
	i.[Name] AS [Item Name]
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id
JOIN Users AS u ON ug.UserId = u.Id
JOIN UserGameItems AS item ON ug.Id = item.UserGameId
JOIN Items AS i ON item.ItemId = i.Id
WHERE g.[Name] = @gameName

-- -- PART II – Queries for Geography Database

USE [Geography]

-- Problem 08: Peaks and Mountains

SELECT
	p.PeakName AS [PeakName],
	m.MountainRange AS [Mountain],
	p.Elevation AS [Elevation]
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
ORDER BY Elevation DESC, PeakName ASC

-- Problem 09: Peaks with Mountain, Country and Continent

SELECT
	p.PeakName,
	m.MountainRange,
	c.CountryName,
	con.ContinentName
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries mc ON m.Id = mc.MountainId
JOIN Countries c ON mc.CountryCode = c.CountryCode
JOIN Continents con ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC

-- Problem 10: Rivers by Country

SELECT
	c.CountryName,
	con.ContinentName,
	COUNT(r.Id) AS [RiverCount],
	ISNULL(SUM(r.Length), 0) AS [TotalLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
INNER JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
GROUP BY c.CountryName, con.ContinentName
ORDER BY RiverCount DESC, TotalLength DESC, CountryName ASC

-- Problem 11: Count of Countries by Currency

SELECT
	cc.CurrencyCode AS [CurrencyCode],
	cc.[Description] AS [Currency],
	COUNT(c.CountryName) AS [NumberOfCountries]
FROM Currencies AS cc
LEFT JOIN Countries c ON cc.CurrencyCode = c.CurrencyCode
GROUP BY cc.CurrencyCode, cc.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC

-- Problem 12: Population and Area by Continent

SELECT
	c.ContinentName AS [ContinentName],
	SUM(con.AreaInSqKm) AS [CountriesArea],
	SUM(CAST(con.Population AS FLOAT)) AS [CountriesPopulation]
FROM Continents AS c
JOIN Countries AS con ON con.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC

-- Problem 13: Monasteries by Country

CREATE TABLE Monasteries
(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(MAX) NOT NULL,
  CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries (CountryCode)
)

INSERT INTO Monasteries (Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'),
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
SET [IsDeleted] = 1
WHERE CountryCode IN (
  SELECT a.Code
  FROM (
         SELECT
           c.CountryCode     AS [Code],
           count(cr.RiverId) AS [CountryRiver]
         FROM Countries AS c
         JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
         GROUP BY c.CountryCode
       ) AS a
  WHERE a.CountryRiver > 3
)

SELECT
	m.Name AS [Monastery],
	c.CountryName AS [Country]
FROM Monasteries AS m
JOIN Countries c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted <> 1
ORDER BY Monastery ASC

-- Problem 14: Monasteries by Continents and Countries

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries ([Name], CountryCode)
  (SELECT
     'Hanga Abbey',
     CountryCode
   FROM Countries
   WHERE CountryName = 'Tanzania')

INSERT INTO Monasteries ([Name], CountryCode)
  (SELECT
     'Myin-Tin-Daik',
     CountryCode
   FROM Countries
   WHERE CountryName = 'Myanmar')


SELECT
	con.ContinentName AS [ContinentName],
	c.CountryName AS [CountryName],
	count(m.Id) AS [MonasteriesCount]
FROM Continents AS con
JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY c.CountryName, con.ContinentName
ORDER BY MonasteriesCount DESC, CountryName ASC