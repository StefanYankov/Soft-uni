-- 10 Add Check Constraint
USE Minions

ALTER TABLE Users
	ADD CONSTRAINT CK_Password_Length CHECK (LEN(Password) >= 5)