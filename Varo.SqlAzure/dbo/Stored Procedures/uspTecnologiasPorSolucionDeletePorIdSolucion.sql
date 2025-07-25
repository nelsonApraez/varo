CREATE PROCEDURE [dbo].[uspTecnologiasPorSolucionDeletePorIdSolucion]
	@idSolucion As uniqueidentifier	

AS
	DELETE FROM dbo.TecnologiasPorSolucion
	WHERE IdSolucion = @idSolucion
