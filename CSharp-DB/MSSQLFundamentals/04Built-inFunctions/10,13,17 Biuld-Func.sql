USE SoftUni

--10 EXERCISE

SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS RANK
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC 


--13 EXERCISE 

USE Geography

SELECT Peaks.PeakName, Rivers.RiverName, 
LOWER((Peaks.PeakName) + SUBSTRING(Rivers.RiverName,2,LEN(Rivers.Rivername))) AS 'Mix' 
FROM Peaks
JOIN Rivers
ON RIGHT(Peaks.PeakName,1) = LEFT(Rivers.RiverName,1)
ORDER BY Mix


--17 EXERCISE
USE Diablo

SELECT [Name] as 'Game',
CASE 
	WHEN DATEPART(HOUR,Start)<12 THEN 'Morning'
	WHEN DATEPART(HOUR,Start)<18 AND DATEPART(HOUR,START)>= 12 THEN 'Afternoon'
	WHEN DATEPART(HOUR,Start)>=18 AND DATEPART(HOUR,START)< 24 THEN 'Evening'
	END AS 'Part of the Day',
CASE 
	WHEN Duration<=3 THEN 'Extra Short'
	WHEN Duration >=4 AND Duration <=6 THEN 'Short'
	WHEN Duration >6 THEN 'Long'
	When Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name],[Duration],[Part of the Day]