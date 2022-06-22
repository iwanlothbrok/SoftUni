SELECT [Salary] FROM Employees

SELECT * FROM Employees 
WHERE [JobTitle] = 'Sales Representative'

SELECT [FirstName] , [LastName], [JobTitle] FROM Employees 
WHERE Salary BETWEEN 20000 AND 30000


SELECT CONCAT([FirstName] , ' ', [MiddleName],' ' ,[LastName]) AS 'Full Name' FROM Employees 
WHERE [Salary] IN(25000,14000,12500,23600)


SELECT [FirstName] , [LastName] FROM Employees 
WHERE [ManagerID] is null

SELECT [FirstName] , [LastName] , [Salary] FROM Employees 
Where [Salary] > 50000 
ORDER BY [Salary] DESC 

SELECT TOP(5) 
[FirstName], [LastName]
FROM Employees
ORDER BY [Salary] DESC

SELECT [FirstName], [LastName]
FROM Employees
WHERE NOT([ManagerID] = 4)

