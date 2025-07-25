CREATE PROCEDURE [dbo].[uspHistoriasyEsfuerzosDeletePorId]
	@IdMetricaAgil AS INT

AS

	DELETE FROM [dbo].[HistoriasyEsfuerzos]
	 WHERE IdMetricaAgil = @IdMetricaAgil
