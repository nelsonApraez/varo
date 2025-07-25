CREATE PROCEDURE [dbo].[uspHistoriasDeletePorId]
	@IdMetricaAgil AS INT

AS

	DELETE FROM [dbo].[Historias]
	 WHERE IdMetricaAgil = @IdMetricaAgil
