--11. Average Interest
SELECT 
	  DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AvarageInterest
 FROM WizzardDeposits
 WHERE YEAR(DepositStartDate) > 1984
 GROUP BY DepositGroup,IsDepositExpired
 ORDER BY DepositGroup DESC, IsDepositExpired



 --12. Rich Wizard, Poor Wizard
 SELECT
	SUM(w1.DepositAmount - w2.DepositAmount) as 'sum_difference'
FROM
    WizzardDeposits as w1, WizzardDeposits as w2
WHERE
    w1.Id - w2.Id = -1




