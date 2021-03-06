SELECT	Tc.[CityID],
		Tc.[CountryID],
		Tc.[isActive],
		TcML.[CityID],
		TcML.[LanguageID],
		TcML.[Name],
		TcML.[Link],
		Tco.[CountryID],
		Tco.[isActive],
		TcoML.[CountryID],
		TcoML.[LanguageID],
		TcoML.[Name]
FROM [Cities] Tc

INNER JOIN [Cities_ML] TcML
ON Tc.[CityID] = TcML.[CityID]

INNER JOIN [Countries] Tco
ON Tco.[CountryID] = Tc.[CountryID]

INNER JOIN [Countries_ML] TcoML
ON TcoML.[CountryID] = Tco.[CountryID]

WHERE Tc.[isActive] = 1