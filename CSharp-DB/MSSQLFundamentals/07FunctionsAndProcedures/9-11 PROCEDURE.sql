--09. Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName 
  AS
  SELECT	
	  CONCAT(FirstName,' ', LastName) AS [FullName]
  FROM AccountHolders

  EXEC usp_GetHoldersFullName



--10. People with Balance Higher Than
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Cash DECIMAL(13,2)) AS 
SELECT FirstName,LastName
  FROM AccountHolders AS ah
   JOIN Accounts AS a ON ah.Id=a.AccountHolderId
 GROUP BY FirstName,LastName
   HAVING SUM(a.Balance) > @Cash


EXEC usp_GetHoldersWithBalanceHigherThan 200



--11. Future Value Function
GO
CREATE FUNCTION ufn_CalculateFutureValue (@Sum MONEY, @Rate FLOAT , @Years INT)
RETURNS MONEY AS
BEGIN
 RETURN @Sum * POWER(1+@Rate,@Years)
END

GO

SELECT  dbo.ufn_CalculateFutureValue (1000, 0.1, 5)