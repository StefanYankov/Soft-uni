-- Problem 9 Change Primary Key
USE Minions

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07583795C1

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id, Username)

