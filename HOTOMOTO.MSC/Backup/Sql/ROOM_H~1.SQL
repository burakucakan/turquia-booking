DECLARE @HotelID int 
DECLARE @LanguageID int
DECLARE @StartDate smalldatetime
DECLARE @EndDate smalldatetime

SET @HotelID = 8
SET @LanguageID = 3
SET @StartDate = '2007-06-19'
SET @EndDate = '2007-09-19'

SELECT 
	 TrooAv.[RoomID]
	,TrooML.[RoomName]
	,TrooAv.[Quantity]
	--,TrooAv.[AvailabilityDate]
FROM [RoomAvailabilities] TrooAv

INNER JOIN [Rooms] Troo
ON Troo.[RoomID] = TrooAv.[RoomID]

INNER JOIN [Rooms_ML] TrooML
ON TrooML.[RoomID] = Troo.[RoomID]

WHERE	Troo.HotelID = @HotelID
	AND TrooML.[LanguageID] = @LanguageID
	AND TrooAv.[AvailabilityDate] >= @StartDate
	AND TrooAv.[AvailabilityDate] < @EndDate

GROUP BY TrooAv.[RoomID], TrooML.[RoomName], TrooAv.[Quantity]