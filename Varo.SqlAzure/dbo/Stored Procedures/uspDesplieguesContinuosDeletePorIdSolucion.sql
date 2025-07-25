CREATE PROCEDURE [dbo].[uspDesplieguesContinuosDeletePorIdSolucion]
	@idSolucion AS uniqueidentifier
AS

	DELETE FROM DesplieguesContinuos
	WHERE IdSolucion = @idSolucion
