set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		by CARETTA
-- Create date: 14.06.2007
-- Description:	Login Kontrol
-- =============================================
CREATE PROCEDURE [dbo].[cproc_LoginControl] 
	@CustomerCode CHAR(10),
	@UserName NVARCHAR(32),
	@Password NVARCHAR(128)
AS
BEGIN
	SELECT [Tus].[UserID]
		  ,[Tus].[CustomerID]
		  ,[Tus].[FirstName]
		  ,[Tus].[LastName]
		  ,[Tus].[EmailAddress] 'UserMail'
		  ,[Tus].[isEmailConfirmed]
		  ,[Tus].[Username]
		  ,[Tus].[Password]
		  ,[Tus].[UserRoleID]

		  ,[Tcu].[CustomerCode]
		  ,[Tcu].[CompanyName]
		  ,[Tcu].[CustomerName]
		  ,[Tcu].[CustomerTypeID]
		  ,[Tcu].[EmailAddress] 'CustomerMail'
		  ,[Tcu].[Website]

	FROM [Users] Tus
	INNER JOIN [Customers] Tcu
	ON [Tcu].[CustomerID] = [Tus].[CustomerID]
	WHERE
		[Tcu].[CustomerCode] = @CustomerCode AND
		[Tus].[Username] = @UserName AND
		[Tus].[Password] = @Password AND
		[Tus].[isActive] = 1 AND
		[Tcu].[isActive] = 1
END
GO
