CREATE PROCEDURE [dbo].[uspCalidadCodigoDeletePorId]
	@idMetricaAgil AS INT

AS

	DELETE FROM [dbo].[CalidadCodigo]
	 WHERE IdMetricaAgil = @idMetricaAgil
