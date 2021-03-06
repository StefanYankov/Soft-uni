-- 08 Create Table Users
USE Minions

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(max),
    CHECK(DATALENGTH(ProfilePicture) <= 900000),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

SELECT * FROM Users

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Stefan', 'yPQC5Y8zTSqLhHxC',100, '2020-01-02 12:00', 0),
('Serafim', '2g9RM5pq8JuRQHSM', 200, '2020-03-04 12:01', 0),
('Dala', '9yJRa8WD2nz2tNfH', 300, '2020-05-06 12:02', 1),
('Kaka', 'EG9Rwa7Ccds3RbGd', 400, '2020-07-08 12:03', 0),
('Spaska', 'VF9nFnzAnkPrq5gY', 500, '2020-09-10 12:04', 0)

SELECT * FROM Users

