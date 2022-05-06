--01. Records’ Count
SELECT COUNT(*) FROM WizzardDeposits



--02. Longest Magic Wand
SELECT MAX(MagicWandSize) as 'LongestMagicWand'
	FROM WizzardDeposits



--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup,MAX(MagicWandSize) as 'LongestMagicWand'
	FROM WizzardDeposits
		GROUP BY DepositGroup



--04. Smallest Deposit Group per Magic Wand Size 
SELECT TOP 2 DepositGroup 
  FROM WizzardDeposits
 GROUP BY DepositGroup
 ORDER BY AVG(MagicWandSize)
			


--05. Deposits Sum
SELECT 
		 DepositGroup,
		 SUM(DepositAmount) as 'TotalSum'
	FROM WizzardDeposits
		GROUP BY DepositGroup



--06. Deposits Sum for Ollivander Family
SELECT 
		 DepositGroup,
		 SUM(DepositAmount) as 'TotalSum'
	FROM WizzardDeposits
	WHERE(MagicWandCreator) = 'Ollivander Family'
		GROUP BY DepositGroup



--07. Deposits Filter
SELECT 
		 DepositGroup,
		 SUM(DepositAmount) as 'TotalSum'
	FROM WizzardDeposits
	WHERE(MagicWandCreator) = 'Ollivander Family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount)< 150000
	ORDER BY TotalSum DESC
				 


--08. Deposit Charge
SELECT 
		 DepositGroup,
		 MagicWandCreator,
		 MIN(DepositCharge) as [MinDepositCharge]
		 FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator



--09. Age Groups
SELECT 
	CASE
	  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
COUNT(*) AS [WizardCount]
	FROM WizzardDeposits
GROUP BY CASE
	  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN Age >= 61 THEN '[61+]'
	END



--10. First Letter

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter; 