/*
INSERT INTO TURQUIA.dbo.UserCommands
Select * 
From TURQUIA_ERICH.dbo.UserCommands TEUC
WHERE TEUC.UserCommandID NOT IN 
(SELECT UserCommandID From TURQUIA.dbo.UserCommands TUC)
GO

INSERT INTO TURQUIA.dbo.UserCommands_ML
Select * 
From TURQUIA_ERICH.dbo.UserCommands_ML TEUCML
WHERE NOT EXISTS 
(SELECT * From TURQUIA.dbo.UserCommands_ML TUC 
WHERE TEUCML.LanguageID = TUC.LanguageID AND TEUCML.UserCommandID = TUC.UserCommandID)
GO

DELETE FROM TURQUIA.dbo.UserPermissions_UserCommands

INSERT INTO TURQUIA.dbo.UserPermissions_UserCommands
Select * 
From TURQUIA_ERICH.dbo.UserPermissions_UserCommands
*/

UPDATE TURQUIA.dbo.UserCommands 
SET
	TURQUIA.dbo.UserCommands.Code=TEUC.Code,
	TURQUIA.dbo.UserCommands.Value=TEUC.Value,
	TURQUIA.dbo.UserCommands.isHidden=TEUC.isHidden,
	TURQUIA.dbo.UserCommands.ParentID=TEUC.ParentID,
	TURQUIA.dbo.UserCommands.ShowOrder=TEUC.ShowOrder,
	TURQUIA.dbo.UserCommands.CreateDate=TEUC.CreateDate,
	TURQUIA.dbo.UserCommands.CreatedBy=TEUC.CreatedBy,
	TURQUIA.dbo.UserCommands.ModifyDate=TEUC.ModifyDate,
	TURQUIA.dbo.UserCommands.ModifiedBy=TEUC.ModifiedBy,
	TURQUIA.dbo.UserCommands.isActive=TEUC.isActive
FROM
	 TURQUIA_ERICH.dbo.UserCommands TEUC WHERE TURQUIA.dbo.UserCommands.UserCommandID = TEUC.UserCommandID

UPDATE TURQUIA.dbo.UserCommands_ML
SET
	TURQUIA.dbo.UserCommands_ML.Title = TEUCML.Title,
	TURQUIA.dbo.UserCommands_ML.Description = TEUCML.Description
FROM
	 TURQUIA_ERICH.dbo.UserCommands_ML TEUCML WHERE 
TURQUIA.dbo.UserCommands_ML.UserCommandID = TEUCML.UserCommandID
AND TURQUIA.dbo.UserCommands_ML.LanguageID = TEUCML.LanguageID
