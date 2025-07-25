CREATE PROCEDURE [dbo].[uspMonitoreoContinuoDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

	DELETE FROM MonitoreoContinuo
	WHERE IdSolucion = @idSolucion
