USE Geography


--11
SELECT CountryName,
       IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;