CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL)

INSERT INTO Students([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron');

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(50) NOT NULL)

INSERT INTO Exams([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle11g');

CREATE TABLE StudentsExams
(StudentID INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL,
ExamID INT FOREIGN KEY REFERENCES [Exams](ExamID) NOT NULL)

INSERT INTO StudentsExams([StudentID],[ExamID])
	VALUES
	(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103);