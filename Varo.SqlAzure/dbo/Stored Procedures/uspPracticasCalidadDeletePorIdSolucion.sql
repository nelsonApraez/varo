CREATE PROCEDURE [dbo].[uspPracticasCalidadDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

	DELETE FROM PracticasCalidad
	WHERE IdSolucion = @idSolucion
