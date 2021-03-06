-- 12 Set Unique Field
USE Minions

ALTER TABLE Users
	ADD CONSTRAINT CHK_Users_Username
	CHECK (LEN(Username) >= 3)

SELECT * FROM Users

INSERT INTO Users(Username, [Password], ProfilePicture, IsDeleted) VALUES
('GE','uNKL5JnHbMec9z78', 600, 0)

SELECT * FROM Users

GO

ALTER TABLE Users
	ADD CONSTRAINT UC_Username
	UNIQUE (Username)

SELECT * FROM Users

INSERT INTO Users(Username, [Password], ProfilePicture, IsDeleted) VALUES
('Gencho','uNKL5JnHbMec9z78', 600, 0)

SELECT * FROM Users