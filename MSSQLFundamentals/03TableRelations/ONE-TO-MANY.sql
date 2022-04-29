

CREATE TABLE Manufacturers(
ManufacturersID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATETIME2 NOT NULL)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES[Manufacturers](ManufacturersID) NOT NULL)

INSERT INTO Manufacturers([Name],EstablishedOn)
	VALUES
	('BMW','07/03/2000'),
	('Tesla','01/01/2003'),
	('Lada','01/05/1996');


INSERT INTO Models([Name],ManufacturerID)
	VALUES
	('X1',1)
	,('i6',1)
	,('Model S',2)
	,('Model X',2)
	,('Model 3',2)
	,('Nova',3);