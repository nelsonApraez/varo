CREATE PROCEDURE [dbo].[uspEquiposSolucionesSelectPorIdSolucion]
	 @idSolucion AS uniqueidentifier
AS

   SELECT
		Id,
		IdSolucion,
		Nombre
	FROM EquipoSolucion
	WHERE IdSolucion = @idSolucion
	ORDER BY Nombre
