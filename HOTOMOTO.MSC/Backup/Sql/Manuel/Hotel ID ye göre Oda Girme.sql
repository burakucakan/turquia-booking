DECLARE @HotelID int
DECLARE @Identity int
DECLARE @LanguageID int
DECLARE @Capacity int
SET @HotelID = 47
SET @LanguageID = 1
	INSERT INTO [TURQUIA].[dbo].[Rooms]
	           ([HotelID]
	           ,[Capacity]
	           ,[CreateDate]
	           ,[CreatedBy]
	           ,[ModifyDate]
	           ,[ModifiedBy]
	           ,[isActive])
	     VALUES
	           (@HotelID
	           ,3
	           ,GetDate()
	           ,1
	           ,GetDate()
	           ,1
	           ,1)

SET @Identity = @@IDENTITY
WHILE (@LanguageID<4)
BEGIN
	INSERT INTO [TURQUIA].[dbo].[Rooms_ML]
			   ([RoomID]
			   ,[LanguageID]
			   ,[RoomName]
			   ,[Description])
		VALUES
			   (@Identity
			   ,@LanguageID
			   ,'StandartRoom'
			   ,'Standard')

SET @LanguageID = @LanguageID + 1

END

SELECT * FROM Rooms r
INNER JOIN Rooms_ML rML
ON r.RoomID = rML.RoomID
WHERE r.HotelID = @HotelID

/*
IDENTITYE ROOMID YÝ UYGULA BÝRLÝKTE OLSUN
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
*/