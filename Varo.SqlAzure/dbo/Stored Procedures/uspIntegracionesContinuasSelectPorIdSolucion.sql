CREATE PROCEDURE [dbo].[uspIntegracionesContinuasSelectPorIdSolucion]
	 @idSolucion AS uniqueidentifier
AS

   SELECT
		Id,
		IdSolucion,
		Nombre,
		UrlCompilacion,
		IdProyectoInspeccion
	FROM IntegracionesContinuas
	WHERE IdSolucion = @idSolucion
	ORDER BY Nombre
