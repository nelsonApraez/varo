CREATE PROCEDURE [dbo].[uspIncendiosSelectPorIdMetricaAgil]
	@IdMetricaAgil AS int
AS

   SELECT Incendios.Id,
		MetricasAgiles.Id AS IdMetricaAgil,
		Incendios.Reportados,
		Incendios.Solucionados,
		Incendios.Observaciones
	FROM MetricasAgiles
	INNER JOIN Incendios
		ON MetricasAgiles.Id = Incendios.IdMetricaAgil
   WHERE MetricasAgiles.Id = @IdMetricaAgil
