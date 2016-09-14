DECLARE @LanguageID INT, @UserRoleID INT
SET @LanguageID = 3
SET @UserRoleID = 1

SELECT
	Tur.[UserRoleID],
	Tupc.[UserCommandID],
	Tuc.[Value],
	Tuc.[ParentId],
	TucML.[Title]
FROM [UserRoles] Tur

INNER JOIN [UserRoles_UserPermissions] Turp
ON Tur.[UserRoleID] = Turp.[UserRoleID]

INNER JOIN [UserPermissions_UserCommands] Tupc
ON Tupc.[UserPermissionID] = Turp.[UserPermissionID]

INNER JOIN [UserCommands] Tuc
ON Tuc.[UserCommandID] = Tupc.[UserCommandID]

INNER JOIN [UserCommands_ML] TucML
ON Tuc.[UserCommandID] = TucML.[UserCommandID]

WHERE 
	Tur.[isActive] = 1 AND
	Tuc.[isHidden] = 0 AND
	TucML.[LanguageID] = @LanguageID AND
	Tur.[UserRoleID] = @UserRoleID

