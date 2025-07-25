CREATE PROCEDURE [dbo].[uspMaestroSelect]
	@nombreMaestro AS VARCHAR(50)
AS
	
	DECLARE @sqlString NVARCHAR(120) = CONCAT(N'SELECT Id, Nombre,NombreEN FROM ', @nombreMaestro)

	EXECUTE dbo.sp_executesql @sqlString

RETURN 0
