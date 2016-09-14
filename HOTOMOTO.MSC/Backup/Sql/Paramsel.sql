/* ------------------------------------------------------------
   PROCEDURE:    cproc_Paramsel
   Description:  Parametric Order, Where Clause, Paging   
   AUTHOR:       by CARETTA 31.05.2007 15:50:56
   ------------------------------------------------------------ */

CREATE PROCEDURE cproc_Paramsel
(
	@Columns nvarchar(1024) = '*',
	@TableName varchar(100),
	@WhereClause nvarchar(1024) = NULL,
	@OrderParameter nvarchar(256) = NULL,
	@RowStart int = 0,
	@RowLimit int = 0
)
AS
BEGIN

	DECLARE @Err Int
	DECLARE @Sql nvarchar(4000)	

	SET @Sql = 'SELECT '
	SET @Sql = @Sql + @Columns
	SET @Sql = @Sql + ' FROM [' + @TableName + ']'

	IF (@WhereClause IS NOT NULL)
		SET @Sql = @Sql + ' WHERE ' + @WhereClause

	IF (@OrderParameter IS NOT NULL)
		SET @Sql = @Sql + ' ORDER BY ' + @OrderParameter

	IF (@RowLimit>0)
	BEGIN		
		SET @Sql = REPLACE(@Sql, ' ORDER BY ' + @OrderParameter, ' ')

		IF (@OrderParameter IS NULL)
		BEGIN
			SET @OrderParameter = [dbo].ReturnPK(@TableName)
			IF (@OrderParameter IS NULL)
			BEGIN
				SET @OrderParameter = [dbo].ReturnFirstColumnName(@TableName)
			END
		END

		DECLARE @PagingSql nvarchar(4000)
		SET @Sql = REPLACE(@Sql, 'SELECT ', 'SELECT ROW_NUMBER() OVER(ORDER BY ' + @OrderParameter + ') AS ROW, ')
		SET @PagingSql = ' SELECT * FROM '
		SET @PagingSql = @PagingSql + '(' + @Sql + ') AS TPage'
		SET @PagingSql = @PagingSql + ' WHERE ROW > ' + Convert(nvarchar(10), @RowStart) + ' AND ROW <= ' + Convert(nvarchar(10), @RowStart + @RowLimit)
		SET @Sql = @PagingSql
	END

	EXEC(@Sql)

	Set @Err = @@Error

	RETURN @Err

END
GO