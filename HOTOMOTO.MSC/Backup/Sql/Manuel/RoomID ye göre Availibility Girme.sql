-- 49, 50, 51, 52, 53, 54
DECLARE @Quantity int
DECLARE @RoomID int
SET @RoomID = 54
SET @Quantity = 20

DECLARE @StartDate DateTime
DECLARE @EndDate DateTime

SET @StartDate = '2007.11.01'
SET @EndDate = '2008.03.15'

WHILE (@StartDate<=@EndDate)
BEGIN
	INSERT INTO [TURQUIA].[dbo].[RoomAvailabilities]
           ([AvailabilityDate]
           ,[RoomID]
           ,[Quantity])
     VALUES
           (@StartDate
           ,@RoomID
           ,@Quantity)
	SET @StartDate = Dateadd(Day, 1, @StartDate)
END