USE SoftUni
--one
------------------------------------------------------
SELECT FirstName,LastName FROM Employees
WHERE FirstName LIKE 'Sa%'
--two
------------------------------------------------------
SELECT FirstName,LastName FROM Employees
WHERE LastName LIKE '%ei%'
--three
------------------------------------------------------
SELECT FirstName FROM Employees
WHERE DepartmentID IN (3,10) AND YEAR(HireDate) BETWEEN 1995 AND 2005
--four
-----------------------------------------------------
SELECT FirstName,LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'
--five
------------------------------------------------------
SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]
--six
------------------------------------------------------
SELECT TownID,[Name] FROM Towns
WHERE LEFT(Name,1)= 'M'
OR LEFT(Name,1)= 'K'
OR LEFT(Name,1)= 'B'
OR LEFT(Name,1)= 'E'
ORDER BY [Name]
--seven
------------------------------------------------------
SELECT TownID,[Name] FROM Towns
WHERE LEFT(Name,1) NOT LIKE '[RBD]'
ORDER BY [Name]
--eight
------------------------------------------------------
CREATE VIEW V_EmployeesHiredAfter2000
AS
     SELECT FirstName,
            LastName
     FROM Employees
     WHERE YEAR(HireDate) > 2000;
 --nine
 -----------------------------------------------------
 SELECT FirstName,LastName FROM Employees
 WHERE LEN(LastName) = 5 

