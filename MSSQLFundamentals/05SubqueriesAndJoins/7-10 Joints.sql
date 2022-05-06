---07. Employees With Project
SELECT TOP (5)
	E.EmployeeID,
	E.FirstName,
	p.Name AS 'ProjectName'
FROM Employees as e
LEFT JOIN EmployeesProjects as ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE YEAR(p.StartDate) > 13/08/2002 AND p.EndDate IS NULL 
ORDER BY e.EmployeeID



---08. Employee 24
SELECT E.EmployeeID,E.FirstName,
  CASE 
   WHEN P.StartDate > '01/01/2005' THEN NULL
   ELSE P.NAME
  END 
  FROM Employees AS E
INNER JOIN EmployeesProjects AS EP ON EP.EmployeeID = E.EmployeeID
INNER JOIN Projects AS P ON EP.ProjectID = P.ProjectID
WHERE E.EmployeeID = 24



---09. Employee Manager
SELECT e.EmployeeID,
       e.FirstName,
       e.ManagerID,
       m.FirstName AS ManagerName
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID;



---10. Employees Summary
SELECT TOP(50)
		 e.EmployeeID,
		 CONCAT(e.FirstName,' ',e.LastName) AS 'EmployeeName',
		 CONCAT(m.FirstName,' ',m.LastName) AS 'ManagerName',
	     d.Name as 'DepartmentName'
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID= d.DepartmentID
ORDER BY e.EmployeeID;




