USE SoftUni

---01. Employee Address
SELECT TOP(5)
	e.EmployeeID,
	e.JobTitle,
	e.AddressID,
	ad.AddressText
FROM Employees AS e
JOIN Addresses AS ad ON 
e.AddressID = ad.AddressID
ORDER BY e.AddressID 


---02. Addresses with Towns
SELECT TOP(50)
	em.FirstName,
	em.LastName,
	t.Name AS Town,
	a.AddressText
FROM Employees AS em
JOIN Addresses AS a ON 
em.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY em.FirstName,em.LastName


---03. Sales Employees
SELECT 
	em.EmployeeID,
	em.FirstName,
	em.LastName,
	d.Name AS 'DepartmentName'
FROM Employees AS em
JOIN Departments AS d 
ON em.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY em.EmployeeID


---04. Employee Departments
SELECT TOP(5)
	em.EmployeeID,
	em.FirstName,
	em.Salary,
	d.Name as 'DepartmentName'
FROM Employees AS em
JOIN Departments AS d 
ON em.DepartmentID = d.DepartmentID
WHERE em.Salary>15000
ORDER BY d.DepartmentID



---05. Employees Without Projects
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON
e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID



---06. Employees Hired After
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.Name AS 'DeptName'
FROM Employees AS e
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE YEAR(e.HireDate) > 1-1-1999 AND d.Name IN ('Sales','Finance')
ORDER BY e.HireDate