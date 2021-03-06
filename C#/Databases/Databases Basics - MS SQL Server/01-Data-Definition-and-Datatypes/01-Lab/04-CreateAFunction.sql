-- 4.Create a Function

CREATE FUNCTION f_CalculateTotalBalance (@ClientID INT)
RETURNS Decimal(15,2)
BEGIN
	DECLARE @result AS DECIMAL(15,2) = (
		SELECT SUM(Balance)
		FROM Accounts WHERE ClientID = @ClientID
		)
		RETURN @result
END

SELECT dbo.f_CalculateTotalBalance(4) AS Balance