---12. Highest Peaks in Bulgaria
SELECT 
		mc.CountryCode,
		m.MountainRange,
		p.PeakName,
		p.Elevation
	FROM MountainsCountries as mc 
	LEFT JOIN Mountains AS m ON
mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON
m.Id = p.MountainId
	WHERE mc.CountryCode = 'BG' 
	AND p.Elevation > 2835
	ORDER BY p.Elevation DESC




---13. Count Mountain Ranges
SELECT	c.CountryCode,
		count(m.MountainRange) AS 'MountainRanges'
FROM Countries AS c
	INNER JOIN MountainsCountries mc
		ON c.CountryCode = mc.CountryCode
	INNER JOIN Mountains m
		ON mc.MountainId = m.Id
WHERE c.CountryCode in ('US', 'RU', 'BG')
GROUP BY c.CountryCode



---14. Countries With or Without Rivers
SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Countries AS c 
JOIN Continents AS ct
ON c.ContinentCode = ct.ContinentCode
FULL JOIN CountriesRivers AS cr 
ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r 
ON cr.RiverId = r.Id
WHERE ct.ContinentCode = 'AF'
ORDER BY c.CountryName