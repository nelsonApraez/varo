CREATE PROCEDURE [dbo].[uspHistoriasSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT Historias.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		Historias.Numero,
		Historias.Nombre,
		Historias.EsfuerzoEstimado,
		Historias.EsfuerzoReal,
		Historias.Observaciones
	FROM MetricasAgiles
	INNER JOIN Historias
		ON MetricasAgiles.Id = Historias.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
