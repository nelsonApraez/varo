CREATE PROCEDURE [dbo].[uspDesplieguesContinuosSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

   SELECT
		Id,
		IdSolucion,
		Nombre,
		UrlDespliegue
	
	FROM DesplieguesContinuos
	WHERE IdSolucion = @idSolucion
	ORDER BY Nombre
