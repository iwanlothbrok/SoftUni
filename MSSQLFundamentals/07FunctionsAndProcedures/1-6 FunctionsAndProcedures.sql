--01. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName,LastName
 FROM Employees
 WHERE Salary > 35000

 
 EXEC dbo.usp_GetEmployeesSalaryAbove35000



 --02. Employees with Salary Above Number
 GO
 CREATE PROC usp_GetEmployeesSalaryAboveNumber (@IncomingNum DECIMAL(18,4)) 
		AS
SELECT  FirstName,LastName
 FROM   Employees
 WHERE  Salary >= @IncomingNum

 EXEC usp_GetEmployeesSalaryAboveNumber 48100



 --03. Town Names Starting With
 GO
 CREATE OR ALTER PROC usp_GetTownsStartingWith (@Value VARCHAR(50))
   AS
 SELECT 
	[Name] as Town
 FROM Towns
  WHERE LEFT(Name,LEN(@Value))= @Value


  EXEC usp_GetTownsStartingWith 'B'



--04. Employees from Town
	GO


CREATE PROC usp_GetEmployeesFromTown (@Town VARCHAR(50))
	AS
	SELECT 
	   FirstName
       ,LastName	
  FROM Employees as e
   JOIN Addresses AS a 
  ON e.AddressID = a.AddressID
   JOIN Towns as t
  ON a.TownID = t.TownID
   WHERE t.Name = @Town

EXEC usp_GetEmployeesFromTown 'Sofia'



--05. Salary Level Function
GO

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS VARCHAR(10) AS 
BEGIN 
	DECLARE @SalaryLevel VARCHAR(10)
	IF(@Salary < 30000) 
	 SET @SalaryLevel = 'Low'
	ELSE IF(@Salary >= 30000 AND @Salary <= 50000)
	 SET @SalaryLevel = 'Average'
	ELSE  
	 SET @SalaryLevel = 'High'
RETURN @SalaryLevel

END

GO

SELECT 
	dbo.ufn_GetSalaryLevel(20000)



--06. Employees by Salary Level
GO
CREATE PROC usp_EmployeesBySalaryLevel(@Text VARCHAR(10))  
	AS SELECT 
	FirstName
	,LastName
 FROM Employees
  WHERE dbo.ufn_GetSalaryLevel(Salary) = @Text

 EXEC usp_EmployeesBySalaryLevel 'High'




