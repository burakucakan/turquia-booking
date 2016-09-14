DECLARE @LanguageID int, @CountryID int, @CityID int, @Name nvarchar(300), @Class varchar(16)
DECLARE @ArrivalDate smalldatetime, @DepartureDate smalldatetime
SET @LanguageID = 3
SET @CountryID = 216
SET @CityID = 61
SET @Name = '%'
SET @Class = '%'
SET @ArrivalDate = '2007.06.10'
SET @DepartureDate = '2007.10.10'

SELECT Tho.[HotelID]
      ,Tho_ML.[Name]
	  ,ISNULL(THoc.[Name], '') 'ChainName'
	  ,ISNULL(Thcl.[Title], '') 'Star'
	  ,Thcl.[Description] 'Class'
	  ,ISNULL(Thimg.[FileName], '') 'ImageFileName'
      ,LEFT(Tho_ML.[Description], 300) 'Description'
  FROM [Hotels] Tho

INNER JOIN [Hotels_ML] Tho_ML
ON Tho_ML.[HotelID] = Tho.[HotelID]

LEFT JOIN [HotelChains_ML]	THoc
ON THoc.[HotelChainID] = Tho.[HotelChainID]

LEFT JOIN [HotelClasses_ML] Thcl
ON Thcl.[HotelClassID] = Tho.[HotelClassID]

LEFT JOIN [HotelImages] Thimg
ON Thimg.[HotelID] = Tho.[HotelID]

WHERE	Tho.[isActive] = 1
	AND Tho.[CountryID] = @CountryID
	AND Tho.[CityID] = @CityID
	AND Tho_ML.[Name] LIKE '%' + @Name + '%'
	AND Thimg.[isDefault] = 1
	AND Thcl.[Title] LIKE @Class
	AND Tho_ML.[LanguageID] = @LanguageID
	AND (THoc.[LanguageID] = @LanguageID OR Tho.[HotelChainID] = 0)
	AND (Thcl.[LanguageID] = @LanguageID OR Tho.[HotelClassID] = 0)
	
	AND Tho.[HotelID] in (
		SELECT DISTINCT Troo.HotelID
		FROM [Rooms] Troo

		INNER JOIN [RoomAvailabilities] Trav
		ON Troo.[RoomID] =  Trav.[RoomID]

		WHERE	Troo.isActive = 1
			AND Trav.AvailabilityDate >= @ArrivalDate
			AND Trav.AvailabilityDate < @DepartureDate
	)