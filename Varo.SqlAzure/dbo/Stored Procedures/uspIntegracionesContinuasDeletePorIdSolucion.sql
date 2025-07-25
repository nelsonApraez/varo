CREATE PROCEDURE [dbo].[uspIntegracionesContinuasDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

	DELETE FROM IntegracionesContinuas
	WHERE IdSolucion = @idSolucion
