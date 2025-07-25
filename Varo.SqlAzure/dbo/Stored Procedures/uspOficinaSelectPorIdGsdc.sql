CREATE PROCEDURE [dbo].[uspOficinaSelectPorIdGsdc]
 @idGsdc AS tinyint
AS
	
	SELECT Id,
		   Nombre
	FROM dbo.Oficinas
	WHERE IdGsdc = @idGsdc

RETURN 0
