set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		by CARETTA - Burak UÇAKAN
-- Create date: 18.06.2007
-- Description:	Hotel Arama Sonuçlarını Göster
-- =============================================

ALTER PROCEDURE [dbo].[cproc_GetHotels] 
	@LanguageID int, 
	@CountryID int, 
	@CityID int, 
	@HotelName nvarchar(300),
	@Class varchar(16),
	@ArrivalDate smalldatetime,
	@DepartureDate smalldatetime,
	@RowStart int,
	@RowLimit int	
AS
BEGIN
	DECLARE @RC int

-- GEÇİCİ ÇÖZÜM ASLINDA KAYIT SAYISININ ALINMASI LAZIM
------------------------------------------------------
	SELECT @RC = COUNT(Tho.HotelID)

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
			AND Tho_ML.[HotelName] LIKE '%' + @HotelName + '%'
			AND Thimg.[isDefault] = 1
			AND Thcl.[Title] LIKE @Class
			AND Tho_ML.[LanguageID] = @LanguageID
			AND (THoc.[LanguageID] = @LanguageID OR Tho.[HotelChainID] = 0)
			AND (Thcl.[LanguageID] = @LanguageID OR Tho.[HotelClassID] = 0)
			
			AND Tho.[HotelID] in ( 
				SELECT HotelID FROM [dbo].ReturnAvailabilityHotels(@ArrivalDate, @DepartureDate)
			)
------------------------------------------------------


	SELECT * FROM
	(	
		SELECT Tho.[HotelID]
			  ,Tho_ML.[HotelName]
			  ,ISNULL(THoc.[ChainName], '') 'ChainName'
			  ,ISNULL(Thcl.[Title], '') 'Star'
			  ,Thcl.[Description] 'Class'
			  ,ISNULL(Thimg.[FileName], '') 'ImageFileName'
			  ,LEFT(Tho_ML.[Description], 300) 'Description'

			  ,ROW_NUMBER() OVER (ORDER BY Tho.[HotelID] DESC) AS Row

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
			AND Tho_ML.[HotelName] LIKE '%' + @HotelName + '%'
			AND Thimg.[isDefault] = 1
			AND Thcl.[Title] LIKE @Class
			AND Tho_ML.[LanguageID] = @LanguageID
			AND (THoc.[LanguageID] = @LanguageID OR Tho.[HotelChainID] = 0)
			AND (Thcl.[LanguageID] = @LanguageID OR Tho.[HotelClassID] = 0)
			
			AND Tho.[HotelID] in ( 
				SELECT HotelID FROM [dbo].ReturnAvailabilityHotels(@ArrivalDate, @DepartureDate)
			)
	) AS TResult
	
	WHERE ROW >=@RowStart AND ROW < @RowStart + @RowLimit

	RETURN @RC

END