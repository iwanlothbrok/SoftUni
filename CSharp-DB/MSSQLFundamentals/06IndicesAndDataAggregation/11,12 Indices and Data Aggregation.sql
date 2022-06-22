--14. Employees Minimum Salaries
SELECT 
	    DepartmentID,
		MIN(Salary) as MinimumSalary
 FROM Employees
WHERE DepartmentID LIKE '[2,5,7]' AND YEAR(HireDate) > 1999
GROUP BY DepartmentID
Order by DepartmentID



--16. Employees Maximum Salaries
SELECT 
	    DepartmentID,
		MAX(Salary) as MaxSalary
 FROM Employees
 WHERE Salary NOT Between 30000 and 70000
GROUP BY DepartmentID



--17. Employees Count Salaries
SELECT COUNT(Salary) AS [Count]
 FROM Employees
 WHERE ManagerID IS NULL



 --19. Salary Challenge
SELECT TOP 10 FirstName,
              LastName,
              DepartmentID
FROM Employees AS e
WHERE Salary >
(
    SELECT AVG(Salary)
    FROM Employees AS em
    WHERE e.DepartmentID = em.DepartmentID
);