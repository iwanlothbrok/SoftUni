SELECT * FROM Employees
ORDER BY [Salary], [LastName] DESC 


CREATE VIEW V_EmployeesSalaries AS 
SELECT [FirstName], [LastName] , [Salary] 
FROM Employees

CREATE VIEW V_EmployeeNameJobTitle 
    AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle 
  FROM Employees

    SELECT 
DISTINCT JobTitle 
    FROM Employees


SELECT TOP(10) 
*
FROM Projects
ORDER BY [StartDate],[Name]

SELECT TOP(7)
[FirstName],[LastName],[HireDate]
FROM Employees
ORDER BY [HireDate]  DESC

UPDATE Employees
   SET Salary += Salary * 0.12
 WHERE DepartmentID IN(1,2,4,11)

SELECT Salary 
  FROM Employees