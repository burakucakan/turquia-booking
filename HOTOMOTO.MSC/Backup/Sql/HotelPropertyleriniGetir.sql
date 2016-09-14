DECLARE @LanguageID int, @HotelID int
SET @LanguageID = 1
SET @HotelID = 1

SELECT Thp.[HotelPropertyID]
      ,Thp.[IconFileName]
      ,Thp.[isActive]
	  ,ThpML.[Property]
	  ,ThpML.[Description]
  FROM [TURQUIA].[dbo].[HotelProperties] Thp

INNER JOIN [HotelProperties_ML] ThpML
ON Thp.[HotelPropertyID] = ThpML.[HotelPropertyID]

INNER JOIN [Hotels_HotelProperties] Thhp
ON Thhp.[HotelPropertyID] = Thp.[HotelPropertyID]

WHERE	Thp.[isActive] = 1
	AND Thhp.[HotelID] = @HotelID
	AND ThpML.[LanguageID] = @LanguageID