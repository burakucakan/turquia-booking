set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- ====================================================
-- Author:		by CARETTA
-- Create date: 20.06.2007 10:45:56
-- Description:	Girilen Tarihler Arasýnda Müsait Olan Otellerin ID sini dönderir 
-- ====================================================

CREATE FUNCTION [dbo].[ReturnAvailabilityHotels] 
(	
	@ArrivalDate smalldatetime,
	@DepartureDate smalldatetime
)
RETURNS TABLE 
AS
RETURN 
(
		SELECT DISTINCT Troo.HotelID
		FROM [Rooms] Troo

		INNER JOIN [RoomAvailabilities] Trav
		ON Troo.[RoomID] =  Trav.[RoomID]

		WHERE	Troo.isActive = 1
			AND Trav.AvailabilityDate >= @ArrivalDate
			AND Trav.AvailabilityDate < @DepartureDate
)
GO
