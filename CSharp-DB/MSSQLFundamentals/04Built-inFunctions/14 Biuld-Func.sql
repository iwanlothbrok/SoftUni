USE Diablo

--14
SELECT TOP 50 [Name],FORMAT(CAST(Start AS DATE), 'yyyy-MM-dd') AS [Start]
From Games
	WHERE YEAR(Start) = 2011
	OR YEAR(Start) = 2012 
	ORDER BY [Start],[Name]
