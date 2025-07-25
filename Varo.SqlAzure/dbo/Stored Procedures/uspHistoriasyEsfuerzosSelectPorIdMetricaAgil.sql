CREATE PROCEDURE [dbo].[uspHistoriasyEsfuerzosSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT HistoriasyEsfuerzos.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		HistoriasyEsfuerzos.HistoriasEstimadas,
		HistoriasyEsfuerzos.HistoriasLogradas,
		HistoriasyEsfuerzos.EsfuerzoEstimado,
		HistoriasyEsfuerzos.EsfuerzoLogrado,
		HistoriasyEsfuerzos.Observaciones
	FROM MetricasAgiles
	INNER JOIN HistoriasyEsfuerzos
		ON MetricasAgiles.Id = HistoriasyEsfuerzos.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
