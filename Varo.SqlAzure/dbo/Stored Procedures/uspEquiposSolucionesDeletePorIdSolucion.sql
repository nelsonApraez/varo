CREATE PROCEDURE [dbo].[uspEquiposSolucionesDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

	DELETE FROM EquipoSolucion
	WHERE IdSolucion = @idSolucion
