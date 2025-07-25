CREATE PROCEDURE [dbo].[uspMonitoreoContinuoSelectPorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

   SELECT
		Id,
		IdSolucion,
		Nombre,
		UrlMonitoreo
	
	FROM MonitoreoContinuo
	WHERE IdSolucion = @idSolucion
	ORDER BY Nombre
