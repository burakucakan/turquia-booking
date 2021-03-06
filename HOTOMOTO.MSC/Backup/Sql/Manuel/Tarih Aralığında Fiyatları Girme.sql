DECLARE @HotelID int, @RoomID int, @Capacity int, @PriceID1 int, @PriceID2 int, @PriceID3 int
DECLARE @StartDay datetime, @EndDay datetime

SET @HotelID = 47
SET @StartDay = '2008.01.03'
SET @EndDay = '2008.03.15'
SET @PriceID1 = 37
SET @PriceID2 = 35
SET @PriceID3 = 21

SELECT @RoomID = RoomID FROM Rooms WHERE HotelID = @HotelID

WHILE(@StartDay<=@EndDay)
BEGIN
	SET @Capacity = 1
	INSERT INTO [dbo].[RoomPriceListPrices]
		   ([RoomPriceListID]
		   ,[RoomID]
		   ,[Capacity]
		   ,[Day]
		   ,[PriceID])
	 VALUES
		   (1
		   ,@RoomID
		   ,@Capacity
		   ,@StartDay
		   ,@PriceID1)

	SET @Capacity = @Capacity + 1

	INSERT INTO [dbo].[RoomPriceListPrices]
		   ([RoomPriceListID]
		   ,[RoomID]
		   ,[Capacity]
		   ,[Day]
		   ,[PriceID])
	 VALUES
		   (1
		   ,@RoomID
		   ,@Capacity
		   ,@StartDay
		   ,@PriceID2)

	SET @Capacity = @Capacity + 1

	INSERT INTO [dbo].[RoomPriceListPrices]
		   ([RoomPriceListID]
		   ,[RoomID]
		   ,[Capacity]
		   ,[Day]
		   ,[PriceID])
	 VALUES
		   (1
		   ,@RoomID
		   ,@Capacity
		   ,@StartDay
		   ,@PriceID3)

SET @StartDay = Dateadd(Day, 1, @StartDay)
END

--SELECT [RoomPriceListPriceID]
--      ,[RoomPriceListID]
--      ,[RoomID]
--      ,[Capacity]
--      ,[Day]
--      ,[PriceID]
--  FROM [dbo].[RoomPriceListPrices]
--where [RoomID] = 50
--
--UPDATE [RoomPriceListPrices]
--SET Capacity = 2
--WHERE Capacity = 3 AND PriceID = 17 AND RoomID=49
--
--DELETE [RoomPriceListPrices]
--WHERE RoomID=49