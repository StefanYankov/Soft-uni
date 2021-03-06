-- 11 Set Default Value of a Field
USE Minions

ALTER TABLE Users
	ADD CONSTRAINT df_LastLoginTime
	DEFAULT GETDATE()
	FOR LastLoginTime

SELECT * FROM Users

INSERT INTO Users(Username, [Password], ProfilePicture, IsDeleted) VALUES
('Gencho','uNKL5JnHbMec9z78', 600, 0)

SELECT * FROM Users